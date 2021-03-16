# Helper functions for retireving useful information from azure-sdk-for-* repo
. "${PSScriptRoot}\logging.ps1"

class PackageProps
{
    [string]$Name
    [string]$Version
    [string]$DirectoryPath
    [string]$ServiceDirectory
    [string]$ReadMePath
    [string]$ChangeLogPath
    [string]$Group
    [string]$SdkType
    [boolean]$IsNewSdk
    [string]$ArtifactName

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory)
    {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory)
    }

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory, [string]$group = "")
    {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory, $group)
    }

    hidden [void]Initialize(
        [string]$name,
        [string]$version,
        [string]$directoryPath,
        [string]$serviceDirectory
    )
    {
        $this.Name = $name
        $this.Version = $version
        $this.DirectoryPath = $directoryPath
        $this.ServiceDirectory = $serviceDirectory

        if (Test-Path (Join-Path $directoryPath "README.md"))
        {
            $this.ReadMePath = Join-Path $directoryPath "README.md"
        } 
        else
        {
            $this.ReadMePath = $null
        }

        if (Test-Path (Join-Path $directoryPath "CHANGELOG.md"))
        {
            $this.ChangeLogPath = Join-Path $directoryPath "CHANGELOG.md"
        } 
        else
        {
            $this.ChangeLogPath = $null
        }
    }

    hidden [void]Initialize(
        [string]$name,
        [string]$version,
        [string]$directoryPath,
        [string]$serviceDirectory,
        [string]$group
    )
    {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory)
        $this.Group = $group
    }
}

# Takes package name and service Name
# Returns important properties of the package as related to the language repo
# Returns a PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
# Note: python is required for parsing python package properties.
function Get-PkgProperties
{
    Param
    (
        [Parameter(Mandatory = $true)]
        [string]$PackageName,
        [string]$ServiceDirectory
    )

    $AllPkgProps = Get-AllPkgProperties -ServiceDirectory $ServiceDirectory

    foreach ($pkgProp in $AllPkgProps)
    {
        if(($pkgProp.Name -eq $PackageName) -or ($pkgProp.ArtifactName -eq $PackageName))
        {
            return $pkgProp
        }
    }

    LogError "Failed to retrive Properties for [ $PackageName ]"
    return $null
}

# Takes ServiceName and Repo Root Directory
# Returns important properties for each package in the specified service, or entire repo if the serviceName is not specified
# Returns an Table of service key to array values of PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
function Get-AllPkgProperties ([string]$ServiceDirectory = $null)
{
    $pkgPropsResult = @()

    if (Test-Path "Function:Get-AllPackageInfoFromRepo")
    {
        $pkgPropsResult = Get-AllPackageInfoFromRepo -ServiceDirectory $serviceDirectory
    }
    else
    {
        if ([string]::IsNullOrEmpty($ServiceDirectory))
        {
            foreach ($dir in (Get-ChildItem (Join-Path $RepoRoot "sdk") -Directory))
            {
                $pkgPropsResult += Get-PkgPropsForEntireService -serviceDirectoryPath $dir.FullName
            }
        } 
        else
        {
            $pkgPropsResult = Get-PkgPropsForEntireService -serviceDirectoryPath (Join-Path $RepoRoot "sdk" $ServiceDirectory)
        }
    }

    return $pkgPropsResult
}

# Given the metadata url under https://github.com/Azure/azure-sdk/tree/master/_data/releases/latest, 
# the function will return the csv metadata back as part of response.
function Get-CSVMetadata ([string]$MetadataUri=$MetadataUri)
{
    $metadataResponse = Invoke-RestMethod -Uri $MetadataUri -method "GET" -MaximumRetryCount 3 -RetryIntervalSec 10 | ConvertFrom-Csv
    return $metadataResponse
}

function Get-PkgPropsForEntireService ($serviceDirectoryPath)
{
    $projectProps = @() # Properties from very project inthe service
    $packageProps = @() # Properties for artifacts specified in ci.yml
    $serviceDirectory = (Split-Path -Path $serviceDirectoryPath -Leaf)

    if (!$GetPackageInfoFromRepoFn -or !(Test-Path "Function:$GetPackageInfoFromRepoFn"))
    {
        LogError "The function for '$GetPackageInfoFromRepoFn' was not found.`
        Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
        See https://github.com/Azure/azure-sdk-tools/blob/master/doc/common/common_engsys.md#code-structure"
    }

    foreach ($directory in (Get-ChildItem $serviceDirectoryPath -Directory))
    {
        $pkgDirectoryPath = Join-Path $serviceDirectoryPath $directory.Name
        $pkgProps = &$GetPackageInfoFromRepoFn $pkgDirectoryPath $serviceDirectory
        if ($null -ne  $pkgProps)
        {
            $projectProps += $pkgProps
        }
    }

    $ciYmlFiles = Get-ChildItem $serviceDirectoryPath -filter "ci.*yml"
    foreach($ciYmlFile in $ciYmlFiles)
    {
        $activeArtifactList = Get-ArtifactListFromYml -ciYmlPath $ciYmlFile.FullName
        foreach ($artifact in $activeArtifactList)
        {
            $packageProps += $projectProps | Where-Object { $_.ArtifactName -eq $artifact["name"] -and $_.Group -eq $artifact["groupId"] }
        }
    }

    return $packageProps
}

function Get-ArtifactListFromYml ($ciYmlPath)
{
    $ProgressPreference = "SilentlyContinue"
    if ((Get-PSRepository | ?{$_.Name -eq "PSGallery"}).Count -eq 0)
    {
        Register-PSRepository -Default -ErrorAction:SilentlyContinue
    }

    if ((Get-Module -ListAvailable -Name powershell-yaml | ?{$_.Version -eq "0.4.2"}).Count -eq 0)
    {
        Install-Module -Name powershell-yaml -RequiredVersion 0.4.2 -Force -Scope CurrentUser
    }

    $ciYmlContent = Get-Content $ciYmlPath -Raw
    $ciYmlObj = ConvertFrom-Yaml $ciYmlContent -Ordered
    if ($ciYmlObj.Contains("stages"))
    {
        $artifactsInCI = $ciYmlObj["stages"][0]["parameters"]["Artifacts"]
    }
    elseif ($ciYmlObj.Contains("extends")) 
    {
        $artifactsInCI = $ciYmlObj["extends"]["parameters"]["Artifacts"]
    }
    return $artifactsInCI
}