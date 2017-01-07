# Diablo III and TurboHUD

This simple tool starts Diablo III and TurboHUD at once.

## How it does it?

0. Launch Diablo III's exe which launch Battle.net (by default)
0. Once the Battle.net app is launched, the tool clicks on Play (Carefull here, you **MUST** have Diablo III selected in the left pannel by default or else the tool will launch the default game and will hang in a loop)
0. Once DIablo III's process is launched, it wait 5 seconds then launch TurboHUD and shuts itself down.

## How to use it?

You **must** have created a new user and denied its access to your TurboHUD folder (See [TurboHUD's forum](http://turbohud.freeforums.net/thread/2980/protect-warden))

0. Open the project in Visual Studio and compile it, or use the compîled version found [here](https://github.com/yonguelink/D3_THUD/blob/master/D3_ThudLauncher.exe)
0. Create a new user in Windows that does NOT have admin privileges, and is locked from accessing TurboHUD's folder
	*. Execute Diablo's launcher and in the settings make sure the game will be launched in 32 bit (as TurboHUD doesn't support 64 bit, and might never)
0. The executable takes four arguments:
	0. TurboHUD complete path (by default : D:\THUD\THUD.exe)
	0. Diablo III complete path (by default: C:\Program File\Diablo III\Diablo III.exe)
	0. The user name which should run Diablo (by default: diablo)
	0. The password for that user (by default: diablo)
0. You can run the executable using CMD or create a shortcut
0. To Create the shortcut
	0. Create a new shortcut pointing to the compiled EXE of this tool
	0. Right click on the shortcut and click on `Properties`
	0. Inside the `Properties`, in the `Target` box add at the end the full path to TurboHUD and Diablo III
		* Path to the exe should be free from `"` and path to TurboHUD and Diablo III should be between `"`
		* An exemple:
			* `C:\D3\D3_ThudLauncher.exe "C:\THUD\THUD.exe" "C:\Program Files\Diablo III\Diablo III.exe" "diablo" "diablo"`