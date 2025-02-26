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
    [HashTable]$CIParameters

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

        $this.CIParameters = @{"CIMatrixConfigs" = @()}
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
                    ParsedYml = $content
                    Location = $ymlPath
                }

                return $result
            }
        }
        return $null
    }

    [PSCustomObject]GetCIYmlForArtifact() {
        $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")

        $ciFolderPath = Join-Path -Path $RepoRoot -ChildPath (Join-Path "sdk" $this.ServiceDirectory)
        $ciFiles = Get-ChildItem -Path $ciFolderPath -Filter "ci*.yml" -File
        $ciArtifactResult = $null

        foreach ($ciFile in $ciFiles) {
            $ciArtifactResult = $this.ParseYmlForArtifact($ciFile.FullName)
            if ($ciArtifactResult) {
                break
            }
        }

        return $ciArtifactResult
    }

    [void]InitializeCIArtifacts() {
        if (-not $env:SYSTEM_TEAMPROJECTID  -and -not $env:GITHUB_ACTIONS) {
            return
        }

        if (-not $this.ArtifactDetails) {
            $ciArtifactResult = $this.GetCIYmlForArtifact()

            if ($ciArtifactResult) {
                $this.ArtifactDetails = [Hashtable]$ciArtifactResult.ArtifactConfig

                if (-not $this.ArtifactDetails["triggeringPaths"]) {
                    $this.ArtifactDetails["triggeringPaths"] = @()
                }
                $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
                $relativePath = (Resolve-Path -Path $ciArtifactResult.Location -Relative -RelativeBasePath $RepoRoot).TrimStart(".").Replace("`\", "/")
                $this.ArtifactDetails["triggeringPaths"] += $relativePath

                $this.CIParameters["CIMatrixConfigs"] = @()

                # if we know this is the matrix for our file, we should now see if there is a custom matrix config for the package
                $matrixConfigList = GetValueSafelyFrom-Yaml $ciArtifactResult.ParsedYml @("extends", "parameters", "MatrixConfigs")

                if ($matrixConfigList) {
                    $this.CIParameters["CIMatrixConfigs"] += $matrixConfigList
                }

                $additionalMatrixConfigList = GetValueSafelyFrom-Yaml $ciArtifactResult.ParsedYml @("extends", "parameters", "AdditionalMatrixConfigs")

                if ($additionalMatrixConfigList) {
                    $this.CIParameters["CIMatrixConfigs"] += $additionalMatrixConfigList
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

    $excludePaths = $diff.ExcludePaths

    $additionalValidationPackages = @()
    $lookup = @{}

    # this is the primary loop that identifies the packages that have changes
    foreach ($pkg in $allPackageProperties) {
        $pkgDirectory = Resolve-Path "$($pkg.DirectoryPath)"
        $lookupKey = ($pkg.DirectoryPath).Replace($RepoRoot, "").TrimStart('\/')
        $lookup[$lookupKey] = $pkg

        # we only honor the individual artifact triggers
        # if we were to honor the ci-level triggers, we would simply
        # end up in a situation where any change to a service would
        # still trigger every package in that service. individual package triggers
        # must be added to handle this.
        $triggeringPaths = @()
        if ($pkg.ArtifactDetails -and $pkg.ArtifactDetails["triggeringPaths"]) {
            $triggeringPaths = $pkg.ArtifactDetails["triggeringPaths"]
        }

        foreach ($file in $targetedFiles) {
            $pathComponents = $file -split "/"
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

            # handle direct changes to packages
            $shouldInclude = $filePath -like (Join-Path "$pkgDirectory" "*")

            # handle changes to files that are RELATED to each package
            foreach($triggerPath in $triggeringPaths) {
                $resolvedRelativePath = (Join-Path $RepoRoot $triggerPath)
                if (!$triggerPath.StartsWith("/")){
                    $resolvedRelativePath = (Join-Path $RepoRoot "sdk" "$($pkg.ServiceDirectory)" $triggerPath)
                }

                # if we are including this package due to one of its additional trigger paths, we need
                # to ensure we're counting it as included for validation, not as an actual package change
                if ($resolvedRelativePath) {
                    $includedForValidation = $filePath -like (Join-Path "$resolvedRelativePath" "*")
                    $shouldInclude = $shouldInclude -or $includedForValidation
                    if ($includedForValidation) {
                        $pkg.IncludedForValidation = $true
                    }
                    break
                }
            }

            # handle service-level changes to the ci.yml files
            # we are using the ci.yml file being added automatically to each artifactdetails as the input
            # for this task. This is because we can resolve a service directory from the ci.yml, and if
            # there is a single ci.yml in that directory, we can assume that any file change in that directory
            # will apply to all packages that exist in that directory.
            $triggeringCIYmls = $triggeringPaths | Where-Object { $_ -like "*ci*.yml" }

            foreach($yml in $triggeringCIYmls) {
                # given that this path is coming from the populated triggering paths in the artifact,
                # we can assume that the path to the ci.yml will successfully resolve.
                $ciYml = Join-Path $RepoRoot $yml
                # ensure we terminate the service directory with a /
                $directory = [System.IO.Path]::GetDirectoryName($ciYml).Replace("`\", "/") + "/"
                $soleCIYml = (Get-ChildItem -Path $directory -Filter "ci*.yml" -File).Count -eq 1

                if ($soleCIYml -and $filePath.Replace("`\", "/").StartsWith($directory)) {
                    if (-not $shouldInclude) {
                        $pkg.IncludedForValidation = $true
                        $shouldInclude = $true
                    }
                    break
                }
                else {
                    # if the ci.yml is not the only file in the directory, we cannot assume that any file changed within the directory that isn't the ci.yml
                    # should trigger this package
                    Write-Host "Skipping adding package for file `"$file`" because the ci yml `"$yml`" is not the only file in the service directory `"$directory`""
                }
            }

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

    # add all of the packages that were added purely for validation purposes
    # this is executed separately because we need to identify packages added this way as only included for validation
    # we don't actually need to build or analyze them. only test them.
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

    # now pass along the set of packages we've identified, the diff itself, and the full set of package properties
    # to locate any additional packages that should be included for validation
    if ($AdditionalValidationPackagesFromPackageSetFn -and (Test-Path "Function:$AdditionalValidationPackagesFromPackageSetFn")) {
        $packagesWithChanges += &$AdditionalValidationPackagesFromPackageSetFn $packagesWithChanges $diff $allPackageProperties
    }

    # finally, if we have gotten all the way here and we still don't have any packages, we should include the template service
    # packages. We should never return NO validation.
    if ($packagesWithChanges.Count -eq 0) {
        $packagesWithChanges += ($allPackageProperties | Where-Object { $_.ServiceDirectory -eq "template" })
        foreach ($package in $packagesWithChanges) {
            $package.IncludedForValidation = $true
        }
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
