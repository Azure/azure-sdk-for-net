param(
    [Parameter()]
    [string] $TestName
)

$user = $env:UserName
$fileName = "$user.config.json"
$oldConfig = Get-Content -Path $PSScriptRoot/config/$fileName

$newConfig = @"
{
    "TestMode": "Record"
}
"@

Write-Host("Updating user config file to Record test mode`n")
$newConfig | Out-File "$PSScriptRoot\config\$fileName"

if (-not $TestName)
{
    # Run all tests
    dotnet test
}
else
{
    # Run only specified test
    dotnet test --filter FullyQualifiedName~$TestName
}

$newConfig = @"
{
    "TestMode": "Playback"
}
"@

Write-Host("Updating user config file to Playback test mode and checking if tests succeed.`n")
$newConfig | Out-File "$PSScriptRoot\config\$fileName"

if (-not $TestName)
{
    # Run all tests
    dotnet test
}
else
{
    # Run only specified test
    dotnet test --filter FullyQualifiedName~$TestName
}

Write-Host("Restoring to original user config file settings.`n")
$oldConfig | Out-File "$PSScriptRoot\config\$fileName"
