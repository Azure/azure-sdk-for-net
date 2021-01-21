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
        [Parameter(Mandatory = $true)]
        [string]$ServiceDirectory
    )

    $pkgDirectoryPath = $null
    $serviceDirectoryPath = Join-Path $RepoRoot "sdk" $ServiceDirectory
    if (!(Test-Path $serviceDirectoryPath))
    {
        LogError "Service Directory $ServiceDirectory does not exist"
        return $null
    }

    $directoriesPresent = Get-ChildItem $serviceDirectoryPath -Directory

    foreach ($directory in $directoriesPresent)
    {
        $pkgDirectoryPath = Join-Path $serviceDirectoryPath $directory.Name

        if ($GetPackageInfoFromRepoFn -and (Test-Path "Function:$GetPackageInfoFromRepoFn"))
        {
            $pkgProps = &$GetPackageInfoFromRepoFn -pkgPath $pkgDirectoryPath -serviceDirectory $ServiceDirectory -pkgName $PackageName
        }
        else
        {
            LogError "The function for '$GetPackageInfoFromRepoFn' was not found.`
            Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
            See https://github.com/Azure/azure-sdk-tools/blob/master/doc/common/common_engsys.md#code-structure"
        }

        if ($pkgProps -ne $null)
        {
            return $pkgProps
        }
    }
    LogWarning "Failed to retrive Properties for $PackageName"
    return $null
}

# Takes ServiceName and Repo Root Directory
# Returns important properties for each package in the specified service, or entire repo if the serviceName is not specified
# Returns an Table of service key to array values of PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
function Get-AllPkgProperties ([string]$ServiceDirectory = $null)
{
    $pkgPropsResult = @()

    if ([string]::IsNullOrEmpty($ServiceDirectory))
    {
        $searchDir = Join-Path $RepoRoot "sdk"
        foreach ($dir in (Get-ChildItem $searchDir -Directory))
        {
            $serviceDir = Join-Path $searchDir $dir.Name

            if (Test-Path (Join-Path $serviceDir "ci.yml"))
            {
                $activePkgList = Get-PkgListFromYml -ciYmlPath (Join-Path $serviceDir "ci.yml")
                if ($activePkgList -ne $null)
                {
                    $pkgPropsResult = Operate-OnPackages -activePkgList $activePkgList -ServiceDirectory $dir.Name -pkgPropsResult $pkgPropsResult
                }
            }
        }
    } 
    else
    {
        $serviceDir = Join-Path $RepoRoot "sdk" $ServiceDirectory
        if (Test-Path (Join-Path $serviceDir "ci.yml"))
        {
            $activePkgList = Get-PkgListFromYml -ciYmlPath (Join-Path $serviceDir "ci.yml")
            if ($activePkgList -ne $null)
            {
                $pkgPropsResult = Operate-OnPackages -activePkgList $activePkgList -ServiceDirectory $ServiceDirectory -pkgPropsResult $pkgPropsResult
            }
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

function Operate-OnPackages ($activePkgList, $ServiceDirectory, [Array]$pkgPropsResult)
{
    foreach ($pkg in $activePkgList)
    {
        LogDebug "Operating on $($pkg["name"])"
        $pkgProps = Get-PkgProperties -PackageName $pkg["name"] -ServiceDirectory $ServiceDirectory
        if ($null -ne  $pkgProps)
        {
            $pkgPropsResult += $pkgProps
        }
    }
    return $pkgPropsResult
}

function Get-PkgListFromYml ($ciYmlPath)
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
    if ($artifactsInCI -eq $null)
    {
        LogError "Failed to retrive package names in ci $ciYmlPath"
    }
    return $artifactsInCI
}