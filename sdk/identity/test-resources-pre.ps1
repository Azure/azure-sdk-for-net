[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param (
    # Captures any arguments from eng/New-TestResources.ps1 not declared here (no parameter errors).
    [Parameter(ValueFromRemainingArguments = $true)]
    $RemainingArguments,

    [Parameter()]
    [ValidatePattern('^[0-9a-f]{8}(-[0-9a-f]{4}){3}-[0-9a-f]{12}$')]
    [string] $TestApplicationId,

    [Parameter()]
    [string] $TestApplicationSecret,

    [Parameter(ParameterSetName = 'Provisioner', Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string] $TenantId
)

Import-Module -Name $PSScriptRoot/../../eng/common/scripts/X509Certificate2 -Verbose

ssh-keygen -t rsa -b 4096 -f $PSScriptRoot/sshKey -N '' -C ''
$sshKey = Get-Content $PSScriptRoot/sshKey.pub

$templateFileParameters['sshPubKey'] = $sshKey

# Get the max version that is not preview and then get the name of the patch version with the max value
az login --service-principal -u $TestApplicationId -p $TestApplicationSecret --tenant $TenantId
$versions = az aks get-versions -l westus -o json | ConvertFrom-Json
Write-Host "AKS versions: $($versions | ConvertTo-Json -Depth 100)"
$patchVersions = $versions.values | Where-Object { $_.isPreview -eq $null } | Select-Object -ExpandProperty patchVersions
Write-Host "AKS patch versions: $($patchVersions | ConvertTo-Json -Depth 100)"
$latestAksVersion = $patchVersions | Get-Member -MemberType NoteProperty | Select-Object -ExpandProperty Name | Sort-Object -Descending | Select-Object -First 1
Write-Host "Latest AKS version: $latestAksVersion"
$templateFileParameters['latestAksVersion'] = $latestAksVersion

if (!$CI) {
    # TODO: Remove this once auto-cloud config downloads are supported locally
    Write-Host "Skipping cert setup in local testing mode"
    return
}

if ($EnvironmentVariables -eq $null -or $EnvironmentVariables.Count -eq 0) {
    throw "EnvironmentVariables must be set in the calling script New-TestResources.ps1"
}

$tmp = $env:TEMP ? $env:TEMP : [System.IO.Path]::GetTempPath()
$pfxPath = Join-Path $tmp "test.pfx"
$pemPath = Join-Path $tmp "test.pem"
$sniPath = Join-Path $tmp "testsni.pfx"

Write-Host "Creating identity test files: $pfxPath $pemPath $sniPath"

[System.Convert]::FromBase64String($EnvironmentVariables['PFX_CONTENTS']) | Set-Content -Path $pfxPath -AsByteStream
Set-Content -Path $pemPath -Value $EnvironmentVariables['PEM_CONTENTS']
[System.Convert]::FromBase64String($EnvironmentVariables['SNI_CONTENTS']) | Set-Content -Path $sniPath -AsByteStream

# Set for pipeline
Write-Host "##vso[task.setvariable variable=IDENTITY_SP_CERT_PFX;]$pfxPath"
Write-Host "##vso[task.setvariable variable=IDENTITY_SP_CERT_PEM;]$pemPath"
Write-Host "##vso[task.setvariable variable=IDENTITY_SP_CERT_SNI;]$sniPath"
# Set for local
$env:IDENTITY_SP_CERT_PFX = $pfxPath
$env:IDENTITY_SP_CERT_PEM = $pemPath
$env:IDENTITY_SP_CERT_SNI = $sniPath