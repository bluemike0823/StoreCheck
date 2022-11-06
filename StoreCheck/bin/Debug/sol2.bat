@echo off
net stop "Print Spooler"
::set ps2=%cd%\sol2.ps1
::powershell.exe -NoProfile -ExecutionPolicy RemoteSigned -file %ps2%

::del /s /q %SystemRoot%\system32\spool\PRINTERS\*.*
net start "Print Spooler"
::echo ps2_work
::pause

::powershell.exe -ExecutionPolicy RemoteSigned -file sol2_2.ps1