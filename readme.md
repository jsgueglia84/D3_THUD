# Diablo III and TurboHUD

This simple tool starts Diablo III and TurboHUD at once.

## How it does it?

0. Launch Diablo III's exe which launch Battle.net (by default)
0. Once the Battle.net app is launched, the tool clicks on Play (Carefull here, you **MUST** have Diablo III selected in the left pannel by default *its something I'll change in next version*)
0. Once DIablo III's process is launched, it wait 5 seconds then launch TurboHUD and shuts itself down.

## How to use it?

0. Open the project in Visual Studio and compile it (Send me a message for the compiled version)
0. The executable takes two arguments:
	0. TurboHUD complete path (by default : D:\THUD\THUD.exe)
	0. Diablo III complete path (by default: C:\Program File\Diablo III\Diablo III.exe)
0. You can run the executable using CMD or create a shortcut
0. To Create the shortcut
	0. Create a new shortcut pointing to the compiled EXE of this tool
	0. Right click on the shortcut and click on `Properties`
	0. Inside the `Properties`, in the `Target` box add at the end the full path to TurboHUD and Diablo III
		* Path to the exe should be free from `"` and path to TurboHUD and Diablo III should be between `"`
		* An exemple:
			* `D:\D3\D3_ThudLauncher.exe "D:\THUD\THUD.exe" "C:\Program Files\Diablo III\Diablo III.exe"`