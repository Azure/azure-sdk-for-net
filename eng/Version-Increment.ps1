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

.EXAMPLE
Updating package version for core

Version-Increment.ps1 -RepoRoot "C:\Git\azure-sdk-for-net" -ServiceDirectory core -PackageName Azure.Core

#>

[CmdletBinding()]
Param (
    [Parameter(Position=0)]
    [ValidateNotNullOrEmpty()]
    [string] $RepoRoot = "${PSScriptRoot}/..",
    [Parameter(Mandatory=$True)]
    [string] $ServiceDirectory,
    [Parameter(Mandatory=$True)]
    [string] $PackageName
)
# Regular expression as specified in https://semver.org/#is-there-a-suggested-regular-expression-regex-to-check-a-semver-string
$VERSION_REGEX = "^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$"

$CsprojData = New-Object -TypeName XML
$PackageCsprojPath = Join-Path $RepoRoot "sdk" $ServiceDirectory $PackageName "src" "${PackageName}.csproj"
$CsprojData.Load($PackageCsprojPath)

$PackageVersion = Select-XML -Xml $CsprojData -XPath '/Project/PropertyGroup/Version'
if ([System.String]::IsNullOrEmpty($PackageVersion))
{
    Write-Error "Missing Version property in project file ${PackageCsprojPath}"
    exit 1
}

Write-Verbose "Current Version: ${PackageVersion}"

$Major = $Minor = $Patch = $Pre = $PreTag = $PreVer = $Null

if ($PackageVersion -Match $VERSION_REGEX)
{
    if($Matches[4] -eq $null){$Pre = @()}
    else{$Pre = $Matches[4].Split(".")}

    $Major = [int]$Matches[1]
    $Minor = [int]$Matches[2]
    $Patch = [int]$Matches[3]
    $PreTag = [string]$Pre[0]
    $PreVer = [int]$Pre[1]
}
else
{
    Write-Error "Version property contains incorrect format. It should be in format 'X.Y.Z[-preview.N]'"
    exit 1
}


# Increment Version
if ([System.String]::IsNullOrEmpty($PreTag))
{
    $PreTag = 'preview'
    $PreVer = 1
    $Minor++
    $Patch = 0
}
elseif ($PreTag -eq 'preview' -and $PreVer -ne $Null)
{
    $PreVer++
}
else
{
    Write-Error "Unexpected pre-release identifier '${PreTag}'"
    exit 1
}


$NewPackageVersion = "{0}.{1}.{2}-{3}.{4}" -F $Major, $Minor, $Patch, $PreTag, $PreVer
Write-Verbose "New Version: ${NewPackageVersion}"
${PackageVersion}.Node.InnerText = $NewPackageVersion
$CsprojData.Save($PackageCsprojPath)