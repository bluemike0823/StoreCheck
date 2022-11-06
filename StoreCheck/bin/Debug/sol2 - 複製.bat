@echo off
:: BatchGotAdmin (Run as Admin code starts)
:: 1. call cacls & config for checking admin
::
REM --> Check for permissions
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
echo Requesting administrative privileges...
goto UACPrompt
) else ( goto gotAdmin )
:UACPrompt
echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"

echo UAC.ShellExecute "%~s0", "", "", "runas" ,1 >> "%temp%\getadmin.vbs"
"%temp%\getadmin.vbs"
pause
exit /B

:: %~dp0 / %cd%
:: %~dp0 means the path which file exist
:: %cd%  means the path works now
:: %0    means the batch itself
:: %~d0  means the driver 
:: %~p0  the path which file exist
:: %~x0  the extension of file
:: %~n0 the batch name

:gotAdmin
::if exist "%temp%\getadmin.vbs" ( del "%temp%\getadmin.vbs" )
pushd "%CD%"
CD /D "%~dp0"
:: BatchGotAdmin (Run as Admin code ends)
:: Your codes should start from the following line
::+==========================================================+
::+					WORK BELOW						  		 +
::+							MY FRIEND					     +
::+==========================================================+

net stop "Print Spooler"
::set ps2=%cd%\sol2.ps1
::powershell.exe -NoProfile -ExecutionPolicy RemoteSigned -file %ps2%

::del /s /q %SystemRoot%\system32\spool\PRINTERS\*.*
net start "Print Spooler"
::echo ps2_work
pause

::powershell.exe -ExecutionPolicy RemoteSigned -file sol2_2.ps1