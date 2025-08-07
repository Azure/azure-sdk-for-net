Write-Host "Going to run test in playback mode" -ForegroundColor Green

$Env:AZURE_TEST_MODE = "Playback"

dotnet build
dotnet test -f net8.0
