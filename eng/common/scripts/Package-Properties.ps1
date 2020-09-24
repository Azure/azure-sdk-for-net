# Helper functions for retireving useful information from azure-sdk-for-* repo
class PackageProps
{
    [string]$Name
    [string]$Version
    [string]$DirectoryPath
    [string]$ServiceDirectory
    [string]$ReadMePath
    [string]$ChangeLogPath
    [string]$Group

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory)
    {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory, "")
    }

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory, [string]$group = "")
    {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory, $group)
    }

    hidden [void]Initialize(
        [string]$name,
        [string]$version,
        [string]$directoryPath,
        [string]$serviceDirectory,
        [string]$group
    )
    {
        $this.Name = $name
        $this.Version = $version
        $this.DirectoryPath = $directoryPath
        $this.ServiceDirectory = $serviceDirectory
        $this.Group = $group
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
}

Import-Module powershell-yaml
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

    $serviceDirectoryPath = Join-Path $RepoRoot "sdk" $ServiceDirectory
    if (!(Test-Path $serviceDirectoryPath))
    {
        Write-Error "Service Directory $ServiceDirectory does not exist"
        exit 1
    }

    $directoriesPresent = Get-ChildItem $serviceDirectoryPath -Directory

    foreach ($directory in $directoriesPresent)
    {
        $pkgDirectoryPath = Join-Path $serviceDirectoryPath $directory.Name
        if ($GetPackageInfoFromRepoFn)
        {
            $pkgProps = &$GetPackageInfoFromRepoFn -pkgPath $pkgDirectoryPath -serviceDirectory $ServiceDirectory -pkgName $PackageName
        }
        else
        {
            Write-Error "The function 'Get-${Language}-PackageInfoFromRepo' was not found."
        }

        if ($pkgProps -ne $null)
        {
            return $pkgProps
        }
    }
    Write-Error "Failed to retrive Properties for $PackageName"
}

# Takes ServiceName and Repo Root Directory
# Returns important properties for each package in the specified service, or entire repo if the serviceName is not specified
# Returns an Table of service key to array values of PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
function Get-AllPkgProperties ([string]$ServiceDirectory = $null, [bool]$includeMgmt = $true)
{
    $pkgPropsResult = @()

    if ([string]::IsNullOrEmpty($ServiceDirectory))
    {
        $searchDir = Join-Path $RepoRoot "sdk"
        foreach ($dir in (Get-ChildItem $searchDir -Directory))
        {
            $serviceDir = Join-Path $searchDir $dir.Name
            $ciFiles = fetchCiFiles -serviceDirectory $serviceDir -includeincludeMgmtPkg $includeMgmt

            foreach ($ciFile in $ciFiles)
            {
                $pkgPropsResult = Operate-OnPackages -ciFilePath $ciFile -ServiceDirectory $dir.Name -pkgPropsResult $pkgPropsResult
            }
        }
    } 
    else
    {
        $serviceDir = Join-Path $RepoRoot "sdk" $ServiceDirectory
        $ciFiles = fetchCiFiles -serviceDirectory $serviceDir -includeincludeMgmtPkg $includeMgmt
        foreach ($ciFile in $ciFiles) {
            $pkgPropsResult = Operate-OnPackages -ciFilePath $ciFile -ServiceDirectory $ServiceDirectory -pkgPropsResult $pkgPropsResult
        }
    }

    return $pkgPropsResult
}

function GetMetaData($lang){
    switch ($lang) {
      "java" {
        $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/java-packages.csv"
        break
      }
      ".net" {
        $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/dotnet-packages.csv"
        break
      }
      "python" {
        $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/python-packages.csv"
        break
      }
      "javascript" {
        $metadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/master/_data/releases/latest/js-packages.csv"
        break
      }
      default {
        Write-Host "Unrecognized Language: $language"
        exit(1)
      }
    }
  
    $metadataResponse = Invoke-RestMethod -Uri $metadataUri -method "GET" -MaximumRetryCount 3 -RetryIntervalSec 10 | ConvertFrom-Csv
  
    return $metadataResponse
}

function fetchCiFiles([string]$serviceDirectory, [bool]$includeMgmtPkg) {
    # We'd better to display artifacts based on the order of ci.yml, ci.data.yml and ci.mgmt.yml.
    $ciFiles = @()
    if (Test-Path (Join-Path $serviceDirectory ci.yml)) {
        $ciFiles += (Join-Path $serviceDirectory ci.yml)
    }
    if (Test-Path (Join-Path $serviceDirectory ci.data.yml)) {
        $ciFiles += (Join-Path $serviceDirectory ci.data.yml)
    }
    if ($includeMgmt -and (Test-Path (Join-Path $serviceDirectory ci.mgmt.yml))) {
        $includeMgmtPkg += (Join-Path $serviceDirectory ci.mgmt.yml)
    }
    return $ciFiles
}

function Operate-OnPackages ($ciFilePath, $ServiceDirectory, [Array]$pkgPropsResult)
{
    $activePkgList = Get-PkgListFromYml -ciYmlPath $ciFilePath
    foreach ($pkg in $activePkgList.name)
    {
        $pkgProps = Get-PkgProperties -PackageName $pkg -ServiceDirectory $ServiceDirectory
        $pkgPropsResult += $pkgProps
    }
    return $pkgPropsResult
}

function Get-PkgListFromYml ($ciYmlPath)
{
    $ProgressPreference = "SilentlyContinue"
    Register-PSRepository -Default -ErrorAction:SilentlyContinue
    # Install-Module -Name powershell-yaml -RequiredVersion 0.4.1 -Force -Scope CurrentUser
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
        Write-Error "Failed to retrive package names in ci $ciYmlPath"
    }
    return $artifactsInCI
}