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
        [string]$PackageName,
        [string]$ArtifactName,
        [string]$ServiceDirectory
    )

    if (!$PackageName -and !$ArtifactName)
    {
        LogError "You must PackageName or ArtifactName Argument"
        return $null
    }
    
    if ($ServiceDirectory)
    {
        if (Test-Path $ServiceDirectory)
        {
            $ServiceDirectoryName = Split-Path $ServiceDirectory -Leaf
        }
        else 
        {
            $ServiceDirectoryName = $ServiceDirectory
        }
        $AllPkgProps = Get-AllPkgProperties -ServiceDirectoryName $ServiceDirectoryName
    }
    else 
    {
        $AllPkgProps = Get-AllPkgProperties
    }

    foreach ($pkgProp in $AllPkgProps)
    {
        if($PackageName -and ($pkgProp.Name -eq $PackageName))
        {
            return $pkgProp
        }

        if ($ArtifactName -and ($pkgProp.ArtifactName -eq $ArtifactName))
        {
            return $pkgProp
        }
    }

    if ($PackageName) { LogWarning "Failed to retrive Properties for [ $PackageName ]" }
    if ($ArtifactName) { LogWarning "Failed to retrive Properties for [ $ArtifactName ]" }
    return $null
}

# Takes ServiceName and Repo Root Directory
# Returns important properties for each package in the specified service, or entire repo if the serviceName is not specified
# Returns an Table of service key to array values of PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
function Get-AllPkgProperties ([string]$ServiceDirectoryName = $null)
{
    $pkgPropsResult = @()

    if ([string]::IsNullOrEmpty($ServiceDirectoryName))
    {
        $searchDir = Join-Path $RepoRoot "sdk"
        foreach ($dir in (Get-ChildItem $searchDir -Directory))
        {
            $serviceDirPath = Join-Path $searchDir $dir.Name
            $ciYmlFiles = Get-ChildItem $serviceDirPath -filter "ci.*yml"

            foreach($ciYmlFile in $ciYmlFiles)
            {
                $activeArtifactList = Get-ArtifactListFromYml -ciYmlPath $ciYmlFile.FullName
                if ($null -ne $activeArtifactList)
                {
                    $pkgPropsResult = Operate-OnArtifacts -activeArtifactList $activeArtifactList -serviceDirectoryPath $serviceDirPath `
                    -ServiceDirectoryName $dir.Name -pkgPropsResult $pkgPropsResult
                }
            }
        }
    } 
    else
    {
        $serviceDirPath = Join-Path $RepoRoot "sdk" $ServiceDirectoryName
        $ciYmlFiles = Get-ChildItem $serviceDirPath -filter "ci.*yml"

        foreach($ciYmlFile in $ciYmlFiles)
        {
            $activeArtifactList = Get-ArtifactListFromYml -ciYmlPath $ciYmlFile.FullName
            if ($null -ne $activeArtifactList)
            {
                $pkgPropsResult = Operate-OnArtifacts -activeArtifactList $activeArtifactList -serviceDirectoryPath $serviceDirPath `
                -serviceDirectoryName $ServiceDirectoryName -pkgPropsResult $pkgPropsResult
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

function Operate-OnArtifacts ($activeArtifactList, $serviceDirectoryPath, $serviceDirectoryName, [Array]$pkgPropsResult)
{
    foreach ($artifact in $activeArtifactList)
    {
        $directoriesPresent = Get-ChildItem $serviceDirectoryPath -Directory
        $artifactName = $artifact["name"]

        foreach ($directory in $directoriesPresent)
        {
            $pkgDirectoryPath = Join-Path $serviceDirectoryPath $directory.Name

            if ($GetPackageInfoFromRepoFn -and (Test-Path "Function:$GetPackageInfoFromRepoFn"))
            {
                $pkgProps = &$GetPackageInfoFromRepoFn -pkgPath $pkgDirectoryPath -serviceDirectory $serviceDirectoryName -artifactName $artifactName
                if ($null -ne  $pkgProps)
                {
                    $pkgPropsResult += $pkgProps
                }
            }
            else
            {
                LogError "The function for '$GetPackageInfoFromRepoFn' was not found.`
                Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
                See https://github.com/Azure/azure-sdk-tools/blob/master/doc/common/common_engsys.md#code-structure"
            }
        }
    }
    return $pkgPropsResult
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
    if ($artifactsInCI -eq $null)
    {
        LogError "Failed to retrive package names in ci $ciYmlPath"
    }
    return $artifactsInCI
}