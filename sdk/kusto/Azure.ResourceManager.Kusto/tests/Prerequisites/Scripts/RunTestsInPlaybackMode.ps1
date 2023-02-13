Write-Host "Going to run test in record mode, please make sure required resources exists, if not, please run 'CreateTestResurces.ps1'" -ForegroundColor Green

$Env:AZURE_TEST_MODE = "Playback"

dotnet build
dotnet test -f net6.0
