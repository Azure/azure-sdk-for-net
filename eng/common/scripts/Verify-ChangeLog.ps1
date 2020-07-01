# Wrapper Script for ChangeLog Verification
param (
    [String]$ChangeLogLocation,
    [String]$VersionString,
    [string]$PackageName,
    [string]$ServiceName,
    [string]$RepoRoot,
    [ValidateSet("net","java","js","python")]
    [string]$Language,
    [string]$RepoName,
    [boolean]$ForRelease=$False
)

. (Join-Path $PSScriptRoot SemVer.ps1)
Import-Module (Join-Path $PSScriptRoot modules ChangeLog-Operations.psm1)

if ((Test-Path $ChangeLogLocation) -and -not([System.String]::IsNullOrEmpty($VersionString)))
{
    Confirm-ChangeLogEntry -ChangeLogLocation $ChangeLogLocation -VersionString $VersionString -ForRelease $ForRelease
}
else 
{
    Import-Module (Join-Path $PSScriptRoot modules Package-Properties.psm1)
    if ([System.String]::IsNullOrEmpty($Language))
    {
        $Language = $RepoName.Substring($RepoName.LastIndexOf('-') + 1)
    }

    $PackageProp = Get-PkgProperties -PackageName $PackageName -ServiceName $ServiceName -Language $Language -RepoRoot $RepoRoot
    Confirm-ChangeLogEntry -ChangeLogLocation $PackageProp.pkgChangeLogPath -VersionString $PackageProp.pkgVersion -ForRelease $ForRelease
}