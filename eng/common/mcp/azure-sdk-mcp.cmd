@echo off
REM Azure SDK MCP Server Wrapper for Windows
REM This script checks for PowerShell 7 (pwsh) and provides installation instructions if not found.

setlocal

REM Check if pwsh is available
where pwsh >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo ================================================================================
    echo  ERROR: PowerShell 7 ^(pwsh^) is required but not installed.
    echo ================================================================================
    echo.
    echo  The Azure SDK MCP Server requires PowerShell 7 or later.
    echo.
    echo  To install PowerShell 7 on Windows, run one of the following commands:
    echo.
    echo    Using winget ^(recommended^):
    echo      winget install Microsoft.PowerShell
    echo.
    echo    Using Chocolatey:
    echo      choco install powershell-core
    echo.
    echo    Manual download:
    echo      https://github.com/PowerShell/PowerShell/releases
    echo.
    echo  After installing, restart VS Code and try again.
    echo ================================================================================
    echo.
    exit /b 1
)

REM PowerShell 7 is available, run the MCP server script
pwsh -NoLogo -NoProfile -File "%~dpn0.ps1" %*
