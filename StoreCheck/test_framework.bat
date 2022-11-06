@echo off
chcp 65001
set ps1=%cd%/test_framework.ps1
powershell.exe -command "$OutputEncoding = [console]::InputEncoding = [console]::OutputEncoding = [Text.UTF8Encoding]::UTF8"
powershell.exe -NoProfile -ExecutionPolicy RemoteSigned -file %ps1%

pause
exit