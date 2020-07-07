@ECHO OFF
PowerShell -NoProfile -NoLogo -ExecutionPolicy unrestricted -Command "./build.ps1 %*; exit $LASTEXITCODE"