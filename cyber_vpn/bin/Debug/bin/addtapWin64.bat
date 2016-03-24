@echo off
cls
TITLE TAP-Win64 driver Installation
Color 02
echo.
echo.
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo     x                                                               x
echo     €                TAP-Win64 driver Installation                  € 
echo     x                                                               x
echo     €-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-x-€
echo     x                                                               x 
echo     €                  Press Any Key To Install!                    € 
echo     x                                                               x
echo     €x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€x€ 
echo.
pause
cd %~dp0
rem Add a new TAP virtual ethernet adapter
tapinstallWin64.exe install "..\driver\win64\OemWin2k.inf" tap0901
pause