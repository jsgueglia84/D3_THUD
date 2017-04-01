using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace D3_ThudLauncher
{
    public class ClickOnPointTool
    {

        [DllImport("user32.dll")]
        private static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] Input[] pInputs, int cbSize);

        internal struct Input
        {
            public uint Type;
            public Mousekeybdhardwareinput Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct Mousekeybdhardwareinput
        {
            [FieldOffset(0)]
            public MouseInput Mouse;
        }

        internal struct MouseInput
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }


        public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            var oldPos = Cursor.Position;

            //get screen coordinates
            ClientToScreen(wndHandle, ref clientPoint);

            //set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            var inputMouseDown = new Input {Type = 0};
            //input type mouse
            inputMouseDown.Data.Mouse.Flags = 0x0002; //left button down

            var inputMouseUp = new Input {Type = 0};
            //input type mouse
            inputMouseUp.Data.Mouse.Flags = 0x0004; //left button up

            var inputs = new[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

            //return mouse 
            Cursor.Position = oldPos;
        }

    }
}
