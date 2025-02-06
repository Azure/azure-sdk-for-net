# Helper functions for retrieving useful information from azure-sdk-for-* repo
. "${PSScriptRoot}\logging.ps1"
. "${PSScriptRoot}\Helpers\Package-Helpers.ps1"
class PackageProps {
    [string]$Name
    [string]$Version
    [string]$DevVersion
    [string]$DirectoryPath
    [string]$ServiceDirectory
    [string]$ReadMePath
    [string]$ChangeLogPath
    [string]$Group
    [string]$SdkType
    [boolean]$IsNewSdk
    [string]$ArtifactName
    [string]$ReleaseStatus
    # was this package purely included because other packages included it as an AdditionalValidationPackage?
    [boolean]$IncludedForValidation
    # does this package include other packages that we should trigger validation for or
    # additional packages required for validation of this one
    [string[]]$AdditionalValidationPackages
    [HashTable]$ArtifactDetails
    [HashTable[]]$CIMatrixConfigs

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory) {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory)
    }

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory, [string]$group = "") {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory, $group)
    }

    hidden [void]Initialize(
        [string]$name,
        [string]$version,
        [string]$directoryPath,
        [string]$serviceDirectory
    ) {
        $this.Name = $name
        $this.Version = $version
        $this.DirectoryPath = $directoryPath
        $this.ServiceDirectory = $serviceDirectory
        $this.IncludedForValidation = $false

        if (Test-Path (Join-Path $directoryPath "README.md")) {
            $this.ReadMePath = Join-Path $directoryPath "README.md"
        }
        else {
            $this.ReadMePath = $null
        }

        if (Test-Path (Join-Path $directoryPath "CHANGELOG.md")) {
            $this.ChangeLogPath = Join-Path $directoryPath "CHANGELOG.md"
            # Get release date for current version and set in package property
            $changeLogEntry = Get-ChangeLogEntry -ChangeLogLocation $this.ChangeLogPath -VersionString $this.Version
            if ($changeLogEntry -and $changeLogEntry.ReleaseStatus) {
                $this.ReleaseStatus = $changeLogEntry.ReleaseStatus.Trim().Trim("()")
            }
        }
        else {
            $this.ChangeLogPath = $null
        }

        $this.InitializeCIArtifacts()
    }

    hidden [void]Initialize(
        [string]$name,
        [string]$version,
        [string]$directoryPath,
        [string]$serviceDirectory,
        [string]$group
    ) {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory)
        $this.Group = $group
    }

    hidden [PSCustomObject]ParseYmlForArtifact([string]$ymlPath) {
        $content = LoadFrom-Yaml $ymlPath
        if ($content) {
            $artifacts = GetValueSafelyFrom-Yaml $content @("extends", "parameters", "Artifacts")
            $artifactForCurrentPackage = $null

            if ($artifacts) {
                $artifactForCurrentPackage = $artifacts | Where-Object { $_["name"] -eq $this.ArtifactName -or $_["name"] -eq $this.Name }
            }

            # if we found an artifact for the current package, we should count this ci file as the source of the matrix for this package
            if ($artifactForCurrentPackage) {
                $result = [PSCustomObject]@{
                    ArtifactConfig = [HashTable]$artifactForCurrentPackage
                    MatrixConfigs  = @()
                }

                # if we know this is the matrix for our file, we should now see if there is a custom matrix config for the package
                $matrixConfigList = GetValueSafelyFrom-Yaml $content @("extends", "parameters", "MatrixConfigs")

                if ($matrixConfigList) {
                    $result.MatrixConfigs = $matrixConfigList
                }

                return $result
            }
        }
        return $null
    }

    [void]InitializeCIArtifacts() {
        if (-not $env:SYSTEM_TEAMPROJECTID  -and -not $env:GITHUB_ACTIONS) {
            return
        }

        $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")

        $ciFolderPath = Join-Path -Path $RepoRoot -ChildPath (Join-Path "sdk" $this.ServiceDirectory)
        $ciFiles = Get-ChildItem -Path $ciFolderPath -Filter "ci*.yml" -File

        if (-not $this.ArtifactDetails) {
            foreach ($ciFile in $ciFiles) {
                $ciArtifactResult = $this.ParseYmlForArtifact($ciFile.FullName)
                if ($ciArtifactResult) {
                    $this.ArtifactDetails = [Hashtable]$ciArtifactResult.ArtifactConfig
                    $this.CIMatrixConfigs = $ciArtifactResult.MatrixConfigs
                    # if this package appeared in this ci file, then we should
                    # treat this CI file as the source of the Matrix for this package
                    break
                }
            }
        }
    }
}

# Takes package name and service Name
# Returns important properties of the package relative to the language repo
# Returns a PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
# Note: python is required for parsing python package properties.
function Get-PkgProperties {
    Param
    (
        [Parameter(Mandatory = $true)]
        [string]$PackageName,
        [string]$ServiceDirectory
    )

    $allPkgProps = Get-AllPkgProperties -ServiceDirectory $ServiceDirectory
    $pkgProps = $allPkgProps.Where({ $_.Name -eq $PackageName -or $_.ArtifactName -eq $PackageName });

    if ($pkgProps.Count -ge 1) {
        if ($pkgProps.Count -gt 1) {
            Write-Host "Found more than one project with the name [$PackageName], choosing the first one under $($pkgProps[0].DirectoryPath)"
        }
        return $pkgProps[0]
    }

    LogError "Failed to retrieve Properties for [$PackageName]"
    return $null
}

function Get-PrPkgProperties([string]$InputDiffJson) {
    $packagesWithChanges = @()

    $allPackageProperties = Get-AllPkgProperties
    $diff = Get-Content $InputDiffJson | ConvertFrom-Json
    $targetedFiles = $diff.ChangedFiles

    if ($diff.DeletedFiles) {
        if (-not $targetedFiles) {
            $targetedFiles = @()
        }
        $targetedFiles += $diff.DeletedFiles
    }

    # The exclude paths and the targeted files paths aren't full OS paths, they're
    # GitHub paths meaning they're relative to the repo root and slashes are forward
    # slashes "/". The ExcludePaths need to have a trailing slash added in order
    # correctly test for string matches without overmatching. For example, if a pr
    # had files sdk/foo/file1 and sdk/foobar/file2 with the exclude of anything in
    # sdk/foo, it should only exclude things under sdk/foo. The TrimEnd is just in
    # case one of the paths ends with a slash, it doesn't add a second one.
    $excludePaths = $diff.ExcludePaths | ForEach-Object { $_.TrimEnd("/") + "/" }

    $additionalValidationPackages = @()
    $lookup = @{}

    foreach ($pkg in $allPackageProperties) {
        $pkgDirectory = Resolve-Path "$($pkg.DirectoryPath)"
        $lookupKey = ($pkg.DirectoryPath).Replace($RepoRoot, "").TrimStart('\/')
        $lookup[$lookupKey] = $pkg

        foreach ($file in $targetedFiles) {
            $shouldExclude = $false
            foreach ($exclude in $excludePaths) {
                if ($file.StartsWith($exclude,'CurrentCultureIgnoreCase')) {
                    $shouldExclude = $true
                    break
                }
            }
            if ($shouldExclude) {
                continue
            }
            $filePath = (Join-Path $RepoRoot $file)
            $shouldInclude = $filePath -like (Join-Path "$pkgDirectory" "*")
            if ($shouldInclude) {
                $packagesWithChanges += $pkg

                if ($pkg.AdditionalValidationPackages) {
                    $additionalValidationPackages += $pkg.AdditionalValidationPackages
                }

                # avoid adding the same package multiple times
                break
            }
        }
    }

    $existingPackageNames = @($packagesWithChanges | ForEach-Object { $_.Name })
    foreach ($addition in $additionalValidationPackages) {
        $key = $addition.Replace($RepoRoot, "").TrimStart('\/')

        if ($lookup[$key]) {
            $pkg = $lookup[$key]

            if ($pkg.Name -notin $existingPackageNames) {
                $pkg.IncludedForValidation = $true
                $packagesWithChanges += $pkg
            }
        }
    }

    if ($AdditionalValidationPackagesFromPackageSetFn -and (Test-Path "Function:$AdditionalValidationPackagesFromPackageSetFn")) {
        $packagesWithChanges += &$AdditionalValidationPackagesFromPackageSetFn $packagesWithChanges $diff $allPackageProperties
    }

    return $packagesWithChanges
}

# Takes ServiceName and Repo Root Directory
# Returns important properties for each package in the specified service, or entire repo if the serviceName is not specified
# Returns a Table of service key to array values of PS Object with properties @ { pkgName, pkgVersion, pkgDirectoryPath, pkgReadMePath, pkgChangeLogPath }
function Get-AllPkgProperties ([string]$ServiceDirectory = $null) {
    $pkgPropsResult = @()

    if (Test-Path "Function:Get-AllPackageInfoFromRepo") {
        $pkgPropsResult = Get-AllPackageInfoFromRepo -ServiceDirectory $serviceDirectory
    }
    else {
        if ([string]::IsNullOrEmpty($ServiceDirectory)) {
            foreach ($dir in (Get-ChildItem (Join-Path $RepoRoot "sdk") -Directory)) {
                $pkgPropsResult += Get-PkgPropsForEntireService -serviceDirectoryPath $dir.FullName
            }
        }
        else {
            $pkgPropsResult = Get-PkgPropsForEntireService -serviceDirectoryPath (Join-Path $RepoRoot "sdk" $ServiceDirectory)
        }
    }

    return $pkgPropsResult
}

# Given the metadata url under https://github.com/Azure/azure-sdk/tree/main/_data/releases/latest,
# the function will return the csv metadata back as part of the response.
function Get-CSVMetadata ([string]$MetadataUri = $MetadataUri) {
    $metadataResponse = Invoke-RestMethod -Uri $MetadataUri -method "GET" -MaximumRetryCount 3 -RetryIntervalSec 10 | ConvertFrom-Csv
    return $metadataResponse
}

function Get-PkgPropsForEntireService ($serviceDirectoryPath) {
    $projectProps = @() # Properties from every project in the service
    $serviceDirectory = $serviceDirectoryPath -replace '^.*[\\/]+sdk[\\/]+([^\\/]+).*$', '$1'

    if (!$GetPackageInfoFromRepoFn -or !(Test-Path "Function:$GetPackageInfoFromRepoFn")) {
        LogError "The function for '$GetPackageInfoFromRepoFn' was not found.`
        Make sure it is present in eng/scripts/Language-Settings.ps1 and referenced in eng/common/scripts/common.ps1.`
        See https://github.com/Azure/azure-sdk-tools/blob/main/doc/common/common_engsys.md#code-structure"
    }

    foreach ($directory in (Get-ChildItem $serviceDirectoryPath -Directory)) {
        $pkgProps = &$GetPackageInfoFromRepoFn $directory.FullName $serviceDirectory
        if ($null -ne $pkgProps) {
            $projectProps += $pkgProps
        }
    }

    return $projectProps
}
