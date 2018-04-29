# Diablo III and TurboHUD

This simple tool starts Diablo III and TurboHUD at once.

## How it does it?

1. Launch Diablo III's exe which launch Battle.net (by default)
1. Once the Battle.net app is launched, the tool clicks on Play (Carefull here, you **MUST** have Diablo III selected in the left pannel by default or else the tool will launch the default game and will hang in a loop)
1. Once DIablo III's process is launched, it wait 5 seconds then launch TurboHUD and shuts itself down.

## How to use it?

You **must** have created a new user and denied its access to your TurboHUD folder (See [TurboHUD's forum](http://www.ownedcore.com/forums/diablo-3/turbohud/turbohud-support/612776-how-protect-against-warden.html))

1. Open the project in Visual Studio and compile it, or use the compîled version found [here](https://github.com/yonguelink/D3_THUD/blob/master/D3_ThudLauncher.exe)
1. Create a new user in Windows that does NOT have admin privileges, and is locked from accessing TurboHUD's folder

	* Execute Diablo's launcher and in the settings make sure the game will be launched in 32 bit (as TurboHUD doesn't support 64 bit, and might never)
1. The executable takes four arguments:

	1. TurboHUD complete path (by default : D:\THUD\THUD.exe)
	1. Diablo III complete path (by default: C:\Program File\Diablo III\Diablo III.exe)
	1. The user name which should run Diablo (by default: diablo)
	1. The password for that user (by default: diablo)
1. You can run the executable using CMD or create a shortcut
1. To Create the shortcut

	1. Create a new shortcut pointing to the compiled EXE of this tool
	1. Right click on the shortcut and click on `Properties`
	1. Inside the `Properties`, in the `Target` box add at the end the full path to TurboHUD and Diablo III

		* Path to the exe should be free from `"` and path to TurboHUD and Diablo III should be between `"`
		* An exemple:
		
			* `C:\D3\D3_ThudLauncher.exe "C:\THUD\THUD.exe" "C:\Program Files\Diablo III\Diablo III.exe" "diablo" "diablo"`
