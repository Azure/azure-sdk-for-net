@echo off
REM Copyright (c) Microsoft Corporation. All rights reserved.
REM Licensed under the MIT License.
REM
REM This script sets up environment variables for running Content Understanding SDK tests on Windows.
REM
REM Usage:
REM   setup_test_env.cmd
REM
REM This script will:
REM   1. Look for a .env file in the current directory
REM   2. Load environment variables from the .env file
REM   3. Set them in the current command prompt session
REM
REM To use:
REM   1. Copy env.sample to .env: copy env.sample .env
REM   2. Edit .env and fill in your actual values
REM   3. Run this script: setup_test_env.cmd
REM   4. Run your tests: dotnet test

setlocal EnableDelayedExpansion

REM Get the directory where this script is located
set "SCRIPT_DIR=%~dp0"
set "ENV_FILE=%SCRIPT_DIR%.env"

REM Check if .env file exists
if not exist "%ENV_FILE%" (
    echo Error: .env file not found at %ENV_FILE%
    echo.
    echo Please:
    echo   1. Copy env.sample to .env: copy env.sample .env
    echo   2. Edit .env and fill in your actual values
    echo   3. Run this script again
    exit /b 1
)

echo Loading environment variables from .env file...
echo.

REM Read .env file and set environment variables
REM Skip comments (lines starting with #) and empty lines
for /f "usebackq tokens=1,* delims==" %%a in ("%ENV_FILE%") do (
    set "line=%%a"
    set "value=%%b"

    REM Skip empty lines and comments
    if not "!line!"=="" (
        if not "!line:~0,1!"=="#" (
            REM Remove leading/trailing whitespace from variable name
            set "var_name=!line!"
            set "var_name=!var_name: =!"

            REM Set the environment variable
            if not "!var_name!"=="" (
                if defined value (
                    set "!var_name!=!value!"
                    echo Set !var_name!
                ) else (
                    REM Variable with no value (empty)
                    set "!var_name!="
                    echo Set !var_name! (empty)
                )
            )
        )
    )
)

echo.
echo Environment variables loaded successfully!
echo.
echo You can now run tests with: dotnet test
echo.
echo Note: These environment variables are only set in this command prompt session.
echo       If you open a new command prompt, run this script again.

endlocal




