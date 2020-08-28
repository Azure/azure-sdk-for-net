# Helper functions for retireving useful information from azure-sdk-for-* repo
# Example Use : Import-Module .\eng\common\scripts\modules
class PackageProps
{
    [string]$pkgName
    [string]$pkgVersion
    [string]$pkgDirectoryPath
    [string]$pkgServiceName
    [string]$pkgReadMePath
    [string]$pkgChangeLogPath
    [string]$pkgGroup

    PackageProps([string]$pkgName,[string]$pkgVersion,[string]$pkgDirectoryPath,[string]$pkgServiceName)
    {
        $this.Initialize($pkgName, $pkgVersion, $pkgDirectoryPath, $pkgServiceName)
    }

    PackageProps([string]$pkgName,[string]$pkgVersion,[string]$pkgDirectoryPath,[string]$pkgServiceName,[string]$pkgGroup="")
    {
        $this.Initialize($pkgName, $pkgVersion, $pkgDirectoryPath, $pkgServiceName, $pkgGroup)
    }

    hidden [void]Initialize(
        [string]$pkgName,
        [string]$pkgVersion,
        [string]$pkgDirectoryPath,
        [string]$pkgServiceName
    )
    {
        $this.pkgName = $pkgName
        $this.pkgVersion = $pkgVersion
        $this.pkgDirectoryPath = $pkgDirectoryPath
        $this.pkgServiceName = $pkgServiceName

        if (Test-Path (Join-Path $pkgDirectoryPath "README.md"))
        {
            $this.pkgReadMePath = Join-Path $pkgDirectoryPath "README.md"
        } 
        else
        {
            $this.pkgReadMePath = $null
        }

        if (Test-Path (Join-Path $pkgDirectoryPath "CHANGELOG.md"))
        {
            $this.pkgChangeLogPath = Join-Path $pkgDirectoryPath "CHANGELOG.md"
        } 
        else
        {
            $this.pkgChangeLogPath = $null
        }
    }

    hidden [void]Initialize(
        [string]$pkgName,
        [string]$pkgVersion,
        [string]$pkgDirectoryPath,
        [string]$pkgServiceName,
        [string]$pkgGroup
    )
    {
        $this.Initialize($pkgName, $pkgVersion, $pkgDirectoryPath, $pkgServiceName)
        $this.pkgGroup = $pkgGroup
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
        [Parameter(Mandatory=$true)]
        [string]$PackageName,
        [Parameter(Mandatory=$true)]
        [string]$ServiceName
    )

    $pkgDirectoryName = $null
    $pkgDirectoryPath = $null
    $serviceDirectoryPath = Join-Path $RepoRoot "sdk" $ServiceName
    if (!(Test-Path $serviceDirectoryPath))
    {
        Write-Error "Service Directory $ServiceName does not exist"
        exit 1
    }

    $directoriesPresent = Get-ChildItem $serviceDirectoryPath -Directory

    foreach ($directory in $directoriesPresent)
    {
        $pkgDirectoryPath = Join-Path $serviceDirectoryPath $directory.Name
        if ($ExtractPkgProps)
        {
            $pkgProps = &$ExtractPkgProps -pkgPath $pkgDirectoryPath -serviceName $ServiceName -pkgName $PackageName
        }
        else
        {
            Write-Error "The function '${ExtractPkgProps}' was not found."
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
function Get-AllPkgProperties ([string]$ServiceName=$null)
{
    $pkgPropsResult = @()

    if ([string]::IsNullOrEmpty($ServiceName))
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
                    $pkgPropsResult = Operate-OnPackages -activePkgList $activePkgList -serviceName $dir.Name -pkgPropsResult $pkgPropsResult
                }
            }
        }
    } 
    else
    {
        $serviceDir = Join-Path $RepoRoot "sdk" $ServiceName
        if (Test-Path (Join-Path $serviceDir "ci.yml"))
        {
            $activePkgList = Get-PkgListFromYml -ciYmlPath (Join-Path $serviceDir "ci.yml")
            if ($activePkgList -ne $null)
            {
                $pkgPropsResult = Operate-OnPackages -activePkgList $activePkgList -serviceName $ServiceName -pkgPropsResult $pkgPropsResult
            }
        }
    }

    return $pkgPropsResult
}

function Operate-OnPackages ($activePkgList, $serviceName, [Array]$pkgPropsResult)
{
    foreach ($pkg in $activePkgList)
    {
        $pkgProps = Get-PkgProperties -PackageName $pkg["name"] -ServiceName $serviceName
        $pkgPropsResult += $pkgProps
    }
    return $pkgPropsResult
}

function Get-PkgListFromYml ($ciYmlPath)
{
    $ProgressPreference = "SilentlyContinue"
    Register-PSRepository -Default -ErrorAction:SilentlyContinue
    Install-Module -Name powershell-yaml -RequiredVersion 0.4.1 -Force -Scope CurrentUser
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