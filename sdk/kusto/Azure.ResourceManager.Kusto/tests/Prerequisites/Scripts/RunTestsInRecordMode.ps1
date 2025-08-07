Write-Host "Going to run test in record mode, please make sure required resources exists, if not, please run 'CreateTestResurces.ps1'" -ForegroundColor Green

$Env:AZURE_TEST_MODE = "Record"

dotnet build
dotnet test -f net8.0
