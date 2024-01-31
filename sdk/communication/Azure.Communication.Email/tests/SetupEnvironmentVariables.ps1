param (
    [Parameter(Mandatory=$True)]
    [ValidateSet('LIVE','RECORD','PLAYBACK')]
    [string]$TestMode,
    [switch]$NoLogin,
    [switch]$NoSecrets
)

if (!$NoLogin)
{
    Write-Host "Please login with your Microsoft account." -ForegroundColor blue
    az login | out-null
    $wsh = New-Object -ComObject Wscript.Shell 
    $wsh.Sendkeys("%{TAB}")
}

if (!$NoSecrets)
{
    Write-Host "Getting keyvault secrets"
    $connectionString = az keyvault secret show --name "CommunicationService-ConnectionString" --vault-name "emailsdktestingkv" --query "value" -o tsv
    $fromEmailAddress = az keyvault secret show --name "AzureManaged-From-EmailAddress" --vault-name "emailsdktestingkv" --query "value" -o tsv
    $toEmailAddress = az keyvault secret show --name "To-EmailAddress" --vault-name "emailsdktestingkv" --query "value" -o tsv
}

Write-Host "Setting environment variables"
if (!$NoSecrets)
{
    del env:COMMUNICATION_CONNECTION_STRING_EMAIL *> $null
    del env:SENDER_ADDRESS *> $null
    del env:RECIPIENT_ADDRESS *> $null

    $env:COMMUNICATION_CONNECTION_STRING_EMAIL = $connectionString
    $env:SENDER_ADDRESS = $fromEmailAddress
    $env:RECIPIENT_ADDRESS = $toEmailAddress
}

del env:AZURE_TEST_MODE
$env:AZURE_TEST_MODE = $TestMode

[System.Environment]::SetEnvironmentVariable('COMMUNICATION_CONNECTION_STRING_EMAIL', $connectionString, 'User')
[System.Environment]::SetEnvironmentVariable('SENDER_ADDRESS', $fromEmailAddress, 'User')
[System.Environment]::SetEnvironmentVariable('RECIPIENT_ADDRESS', $toEmailAddress, 'User')
[System.Environment]::SetEnvironmentVariable('AZURE_TEST_MODE', $TestMode, 'User')

Get-ChildItem env: | Where-Object {(
    $_.name -eq "COMMUNICATION_CONNECTION_STRING_EMAIL" -or `
    $_.name -eq "SENDER_ADDRESS" -or `
    $_.name -eq "RECIPIENT_ADDRESS" -or `
    $_.name -eq "AZURE_TEST_MODE")}
