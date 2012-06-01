@echo off
rem This is only for SDK 1.4 and not a best practice to detect DevFabric.
if ("%WA_CONTAINER_SID%") == ("") goto Exit

echo Installing Web-Mgmt-Service
if exist "%windir%\system32\ServerManagerCmd.exe" "%windir%\system32\ServerManagerCmd.exe" -install Web-Mgmt-Service
echo Configuring Web-Mgmt-Service
sc config wmsvc start= auto 
net stop wmsvc
echo Setting the registry key
%windir%\regedit /s EnableRemoteManagement.reg

echo Installing WebDeploy
"%~dp0Webpicmdline.exe" /products: WDeployNoSMO /AcceptEula
echo Configuring WebDeploy
sc config msdepsvc start= auto 
net stop msdepsvc

echo Starting required services
net start wmsvc
net start msdepsvc
exit /b 0

:Exit
echo Running on DevFabric. No action taken.
