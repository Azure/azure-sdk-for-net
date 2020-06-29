# Wrapper Script for ChangeLog Verification
param (
    [Parameter(Mandatory=$true)]
    [string]$PackageName,
    [Parameter(Mandatory=$true)]
    [string]$ServiceName,
    [string]$RepoRoot,
    [ValidateSet("net","java","js","python")]
    [string]$Language,
    [string]$RepoName,
    [boolean]$ForRelease=$False
)

Import-Module "${PSScriptRoot}/modules/common-manifest.psd1"

if ([System.String]::IsNullOrEmpty($Language))
{
    $Language = $RepoName.Substring($RepoName.LastIndexOf('-') + 1)
}

$PackageProp = Get-PkgProperties -PackageName $PackageName -ServiceName $ServiceName -Language $Language -RepoRoot $RepoRoot
Confirm-ChangeLog -ChangeLogLocation $PackageProp.pkgChangeLogPath -VersionString $PackageProp.pkgReadMePath -ForRelease $ForRelease