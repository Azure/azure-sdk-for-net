@echo off
REM Build and run the test data generator
REM Usage: generate-test-data.bat [options]

setlocal

set SCRIPT_DIR=%~dp0
set PROJECT_DIR=%SCRIPT_DIR%
set OUTPUT_DIR=%SCRIPT_DIR%..\TestAudio

echo Building Test Data Generator...
dotnet build "%PROJECT_DIR%TestDataGenerator.csproj" --configuration Release

if errorlevel 1 (
    echo Build failed!
    exit /b 1
)

echo Generating test data...
dotnet run --project "%PROJECT_DIR%TestDataGenerator.csproj" --configuration Release -- --output "%OUTPUT_DIR%" %*

if errorlevel 1 (
    echo Generation failed!
    exit /b 1
)

echo Test data generation complete!
echo Files generated in: %OUTPUT_DIR%