<#
.SYNOPSIS
Bumps up package versions after release

.DESCRIPTION
This script bumps up package versions following conventions defined at https://github.com/Azure/azure-sdk/blob/master/docs/policies/releases.md#incrementing-after-release-net

.PARAMETER RepoRoot
The Root of the repo

.PARAMETER ServiceDirectory
The Name of the Service Directory

.PARAMETER PackageName
The Name of the Package

.PARAMETER PackageDirName
Used in the case where the package directory name is different from the package name. e.g in cognitiveservice packages

.PARAMETER NewVersionString
Use this to overide version incement logic and set a version specified by this parameter


.EXAMPLE
Updating package version for Azure.Core
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core

Updating package version for Azure.Core with a specified verion
Update-PkgVersion.ps1 -ServiceDirectory core -PackageName Azure.Core -NewVersionString 2.0.5

Updating package version for Microsoft.Azure.CognitiveServices.AnomalyDetector
Update-PkgVersion.ps1 -ServiceDirectory cognitiveservices -PackageName Microsoft.Azure.CognitiveServices.AnomalyDetector -PackageDirName AnomalyDetector

#>

[CmdletBinding()]
Param (
    [ValidateNotNullOrEmpty()]
    [string] $RepoRoot = "${PSScriptRoot}/..",
    [Parameter(Mandatory=$True)]
    [string] $ServiceDirectory,
    [Parameter(Mandatory=$True)]
    [string] $PackageName,
    [string] $PackageDirName,
    [string] $NewVersionString
)
# Regular expression as specified in https://semver.org/#is-there-a-suggested-regular-expression-regex-to-check-a-semver-string
$VERSION_REGEX = "^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$"

# Updated Version in csproj and changelog using computed or set NewVersionString
function Update-Version($Unreleased=$True, $ReplaceVersion=$False)
{
    Write-Verbose "New Version: ${NewPackageVersion}"
    ${PackageVersion}.Node.InnerText = $NewPackageVersion
    $CsprojData.Save($PackageCsprojPath)

    # Increment Version in ChangeLog file
    & "${PSScriptRoot}/common/Update-Change-Log.ps1" -Version $NewPackageVersion -ChangeLogPath $ChangelogPath -Unreleased $Unreleased -ReplaceVersion $ReplaceVersion
}

# Parse a VersionString to verify that it is right
function Parse-Version($VerisionString)
{
    if ([System.String]::IsNullOrEmpty($VerisionString))
    {
        Write-Error "Missing or Empty Version property ${VerisionString}"
        exit 1
    }

    if ($VerisionString -Match $VERSION_REGEX)
    {
        if($Matches[4] -eq $null){$Pre = @()}
        else{$Pre = $Matches[4].Split(".")}
        $VersionTable = @{
            major = [int]$Matches[1]
            minor = [int]$Matches[2]
            patch = [int]$Matches[3]
            pretag = [string]$Pre[0]
            prever = [int]$Pre[1]
        }

        if ($VersionTable['pretag'] -ne '' -and $VersionTable['pretag'] -ne 'preview')
        {
            Write-Error "Unexpected pre-release identifier '$($VersionTable['pretag'])', should be 'preview'"
            exit 1
        }

        if ($VersionTable['pretag'] -eq 'preview' -and $VersionTable['prever'] -lt 1)
        {
            Write-Error "Unexpected pre-release version '$($VersionTable['prever'])', should be greater than '1'"
            exit 1
        }
        return $VersionTable
    }
    else
    {
        Write-Error "Version property contains incorrect format. It should be in format 'X.Y.Z[-preview.N]'"
        exit 1
    }
}

# Obtain Current Package Version
if ([System.String]::IsNullOrEmpty($PackageDirName)) {$PackageDirName = $PackageName}
$CsprojData = New-Object -TypeName XML
$CsprojData.PreserveWhitespace = $True
$PackageCsprojPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $PackageDirName "src" "${PackageName}.csproj"
$ChangelogPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $PackageDirName "CHANGELOG.md"
$CsprojData.Load($PackageCsprojPath)
$PackageVersion = Select-XML -Xml $CsprojData -XPath '/Project/PropertyGroup/Version'


if ([System.String]::IsNullOrEmpty($NewVersionString))
{
    $VersionTable = Parse-Version($PackageVersion)
    Write-Verbose "Current Version: ${PackageVersion}"
    # Increment Version
    if ([System.String]::IsNullOrEmpty($VersionTable['pretag']))
    {
        $VersionTable['pretag'] = 'preview'
        $VersionTable['prever'] = 1
        $VersionTable['minor']++
        $VersionTable['patch'] = 0
    }
    else
    {
        $VersionTable['prever']++
    }

    $NewPackageVersion = "{0}.{1}.{2}-{3}.{4}" -F $VersionTable['major'], $VersionTable['minor'], $VersionTable['patch'], $VersionTable['pretag'], $VersionTable['prever']
    Update-Version
}
else
{
    # Use specified VersionString
    $VersionTable = Parse-Version($NewVersionString)
    if ($VersionTable['pretag'] -eq '')
    {
        $NewPackageVersion = "{0}.{1}.{2}" -F $VersionTable['major'], $VersionTable['minor'], $VersionTable['patch']
    }
    else
    {
        $NewPackageVersion = "{0}.{1}.{2}-{3}.{4}" -F $VersionTable['major'], $VersionTable['minor'], $VersionTable['patch'], $VersionTable['pretag'], $VersionTable['prever']
    }
    Update-Version -Unreleased $False -ReplaceVersion $True
}