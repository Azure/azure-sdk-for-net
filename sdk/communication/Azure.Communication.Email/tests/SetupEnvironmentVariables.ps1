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
    del env:COMMUNICATION_LIVETEST_DYNAMIC_CONNECTION_STRING *> $null
    del env:COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING *> $null
    del env:AZURE_MANAGED_FROM_EMAIL_ADDRESS *> $null
    del env:TO_EMAIL_ADDRESS *> $null

    $env:COMMUNICATION_LIVETEST_DYNAMIC_CONNECTION_STRING = $connectionString
    $env:COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING = $connectionString
    $env:AZURE_MANAGED_FROM_EMAIL_ADDRESS = $fromEmailAddress
    $env:TO_EMAIL_ADDRESS = $toEmailAddress
}

del env:AZURE_TEST_MODE
$env:AZURE_TEST_MODE = $TestMode

[System.Environment]::SetEnvironmentVariable('COMMUNICATION_LIVETEST_DYNAMIC_CONNECTION_STRING', $connectionString, 'User')
[System.Environment]::SetEnvironmentVariable('COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING', $connectionString, 'User')
[System.Environment]::SetEnvironmentVariable('AZURE_MANAGED_FROM_EMAIL_ADDRESS', $fromEmailAddress, 'User')
[System.Environment]::SetEnvironmentVariable('TO_EMAIL_ADDRESS', $toEmailAddress, 'User')
[System.Environment]::SetEnvironmentVariable('AZURE_TEST_MODE', $TestMode, 'User')

Get-ChildItem env: | Where-Object {(
    $_.name -eq "COMMUNICATION_LIVETEST_DYNAMIC_CONNECTION_STRING" -or `
    $_.name -eq "COMMUNICATION_LIVETEST_STATIC_CONNECTION_STRING" -or `
    $_.name -eq "AZURE_MANAGED_FROM_EMAIL_ADDRESS" -or `
    $_.name -eq "TO_EMAIL_ADDRESS" -or `
    $_.name -eq "AZURE_TEST_MODE")}

