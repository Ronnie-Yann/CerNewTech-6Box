@echo off
cls
TITLE TAP-Win32 driver Installation
Color 02
echo.
echo.
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo     x                                                               x
echo     €                TAP-Win32 driver Installation                  € 
echo     x                                                               x
echo     €-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-€
echo     x                                                               x 
echo     €                  Press Any Key To Install!                    € 
echo     x                                                               x
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo.
pause
cd %~dp0
tapinstallWin32.exe install "..\driver\win32\OemWin2k.inf" tap0901
pause