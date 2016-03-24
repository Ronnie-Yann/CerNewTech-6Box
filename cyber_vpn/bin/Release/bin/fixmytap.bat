@echo off
cls
TITLE TAP-Win32 driver Fixer
Color 02
echo.
echo.
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo     x                                                               x
echo     €                   TAP-Win32 driver Fixer                      € 
echo     x                                                               x
echo     €-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-€
echo     x                                                               x 
echo     €                        Processing.....                        € 
echo     x                                                               x
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo.
echo WARNING: this script will delete ALL TAP virtual adapters (use the device manager to delete adapters one at a time)
echo.
cd %~dp0
"tapinstallWin32.exe" remove tap0901
rem Add a new TAP virtual ethernet adapter
tapinstallWin32.exe install "..\driver\win32\OemWin2k.inf" tap0901
echo.
echo.
echo.
echo.
echo.
echo.
echo.
echo.
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo     x                                                               x
echo     €                   TAP-Win32 driver Fixer                      € 
echo     x                                                               x
echo     €-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-€
echo     x                                                               x 
echo     €                         Finished                              € 
echo     x                                                               x
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo.
echo Tap Driver erros fixed successfully....
timeout 10