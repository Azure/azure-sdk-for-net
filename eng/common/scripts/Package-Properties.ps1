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

    PackageProps([string]$name, [string]$version, [string]$directoryPath, [string]$serviceDirectory, [string]$group = "", [string]$artifactName = "") {
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory, $group, $artifactName)
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
        [string]$group,
        [string]$artifactName
    ) {
        $this.Group = $group
        $this.ArtifactName = $artifactName
        $this.Initialize($name, $version, $directoryPath, $serviceDirectory)
    }

    hidden [PSCustomObject]ParseYmlForArtifact([string]$ymlPath, [bool]$soleCIYml = $false) {
        $content = LoadFrom-Yaml $ymlPath
        if ($content) {
            $artifacts = GetValueSafelyFrom-Yaml $content @("extends", "parameters", "Artifacts")
            $artifactForCurrentPackage = @{}

            if ($artifacts) {
                # If there's an artifactName match that to the name field from the yml
                if ($this.ArtifactName) {
                    # Additionally, if there's a group, then the group and artifactName need to match the groupId and name in the yml
                    if ($this.Group) {
                        $artifactForCurrentPackage = $artifacts | Where-Object { $_["name"] -eq $this.ArtifactName -and $_["groupId"] -eq $this.Group}
                    } else {
                        # just matching the artifactName
                        $artifactForCurrentPackage = $artifacts | Where-Object { $_["name"] -eq $this.ArtifactName }
                    }
                } else {
                    # This is the default, match the Name to the name field from the yml
                    $artifactForCurrentPackage = $artifacts | Where-Object { $_["name"] -eq $this.Name }
                }
            }

            # if we found an artifact for the current package OR this is the sole ci.yml for the given service directory,
            # we should count this ci file as the source of the matrix for this package
            if ($artifactForCurrentPackage -or $soleCIYml) {
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

    [System.IO.FileInfo[]]ResolveCIFolderPath() {
        $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
        $ciFolderPath = Join-Path -Path $RepoRoot -ChildPath (Join-Path "sdk" $this.ServiceDirectory)
        $ciFiles = @()

        # if this path exists, then we should look in it for the ci.yml files and return nothing if nothing is found
        if (Test-Path $ciFolderPath){
            $ciFiles = @(Get-ChildItem -Path $ciFolderPath -Filter "ci*.yml" -File)
        }
        # if not, we should at least try to resolve the eng/ folder to fall back and see if that's where the path exists
        else {
            $ciFolderPath = Join-Path -Path $RepoRoot -ChildPath (Join-Path "eng" $this.ServiceDirectory)
            if (Test-Path $ciFolderPath) {
                $ciFiles = @(Get-ChildItem -Path $ciFolderPath -Filter "ci*.yml" -File)
            }
        }

        return $ciFiles
    }

    [PSCustomObject]GetCIYmlForArtifact() {
        $ciFiles = @($this.ResolveCIFolderPath())
        $ciArtifactResult = $null
        $soleCIYml = ($ciFiles.Count -eq 1)

        foreach ($ciFile in $ciFiles) {
            $ciArtifactResult = $this.ParseYmlForArtifact($ciFile.FullName, $soleCIYml)
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

            if ($ciArtifactResult -and $null -ne $ciArtifactResult.ArtifactConfig) {
                $this.ArtifactDetails = [Hashtable]$ciArtifactResult.ArtifactConfig

                $repoRoot = Resolve-Path (Join-Path $PSScriptRoot ".." ".." "..")
                $ciYamlPath = (Resolve-Path -Path $ciArtifactResult.Location -Relative -RelativeBasePath $repoRoot).TrimStart(".").Replace("`\", "/")
                $relRoot = [System.IO.Path]::GetDirectoryName($ciYamlPath).Replace("`\", "/")

                if (-not $this.ArtifactDetails["triggeringPaths"]) {
                    $this.ArtifactDetails["triggeringPaths"] = @()
                }

                # if we know this is the matrix for our file, we should now see if there is a custom matrix config for the package
                $serviceTriggeringPaths = GetValueSafelyFrom-Yaml $ciArtifactResult.ParsedYml @("extends", "parameters", "TriggeringPaths")
                if ($serviceTriggeringPaths){
                    $this.ArtifactDetails["triggeringPaths"] += $serviceTriggeringPaths
                }

                $adjustedPaths = @()

                # we need to convert relative references to absolute references within the repo
                # this will make it extremely easy to compare triggering paths to files in the deleted+changed file list.
                for ($i = 0; $i -lt $this.ArtifactDetails["triggeringPaths"].Count; $i++) {
                    $currentPath = $this.ArtifactDetails["triggeringPaths"][$i]
                    $newPath = Join-Path $repoRoot $currentPath
                    if (!$currentPath.StartsWith("/")) {
                        $newPath = Join-Path $repoRoot $relRoot $currentPath
                    }
                    # it is a possibility that users may have a triggerPath dependency on a file that no longer exists.
                    # before we resolve it to get rid of possible relative references, we should check if the file exists
                    # if it doesn't, we should just leave it as is. Otherwise we would _crash_ here when a user accidentally
                    # left a triggeringPath on a file that had been deleted
                    if (Test-Path $newPath) {
                        $adjustedPaths += (Resolve-Path -Path $newPath -Relative -RelativeBasePath $repoRoot).TrimStart(".").Replace("`\", "/")
                    }
                }
                $this.ArtifactDetails["triggeringPaths"] = $adjustedPaths
                $this.ArtifactDetails["triggeringPaths"] += $ciYamlPath

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
# GroupId is optional and is used to filter packages for languages that support group identifiers (e.g., Java).
# When GroupId is provided, the function will match both the package name and the group ID.
function Get-PkgProperties {
    Param
    (
        [Parameter(Mandatory = $true)]
        [string]$PackageName,
        [string]$ServiceDirectory,
        [string]$GroupId
    )

    Write-Host "Get-PkgProperties called with PackageName: [$PackageName], ServiceDirectory: [$ServiceDirectory], GroupId: [$GroupId]"

    $allPkgProps = Get-AllPkgProperties -ServiceDirectory $ServiceDirectory
    
    if ([string]::IsNullOrEmpty($GroupId)) {
        $pkgProps = $allPkgProps.Where({ $_.Name -eq $PackageName -or $_.ArtifactName -eq $PackageName });
    }
    else {
        $pkgProps = $allPkgProps.Where({ 
            ($_.Name -eq $PackageName -or $_.ArtifactName -eq $PackageName) -and 
            ($_.PSObject.Properties.Name -contains "Group" -and $_.Group -eq $GroupId)
        });
    }

    if ($pkgProps.Count -ge 1) {
        if ($pkgProps.Count -gt 1) {
            Write-Host "Found more than one project with the name [$PackageName], choosing the first one under $($pkgProps[0].DirectoryPath)"
        }
        return $pkgProps[0]
    }

    if ([string]::IsNullOrEmpty($GroupId)) {
        LogError "Failed to retrieve Properties for [$PackageName]"
    }
    else {
        LogError "Failed to retrieve Properties for [$PackageName] with GroupId [$GroupId]. Ensure the package has a Group property matching the specified GroupId."
    }
    return $null
}

function Get-PackagesFromPackageInfo([string]$PackageInfoFolder, [bool]$IncludeIndirect, [ScriptBlock]$CustomCompareFunction = $null) {
    $packages = Get-ChildItem -R -Path $PackageInfoFolder -Filter "*.json" | ForEach-Object {
        Get-Content $_.FullName | ConvertFrom-Json
    }

    if (-not $includeIndirect) {
        $packages = $packages | Where-Object { $_.IncludedForValidation -eq $false }
    }

    if ($CustomCompareFunction) {
        $packages = $packages | Where-Object { &$CustomCompareFunction $_ }
    }

    return $packages
}


function Get-TriggerPaths([PSCustomObject]$AllPackageProperties) {
    $existingTriggeringPaths = @()
    $AllPackageProperties | ForEach-Object {
        if ($_.ArtifactDetails) {
            $pathsForArtifact = $_.ArtifactDetails["triggeringPaths"]
            foreach ($triggerPath in $pathsForArtifact){
                # we only care about triggering paths that are actual files, not directories
                # go by by the assumption that if the triggerPath has an extension, it's a file :)
                if ([System.IO.Path]::HasExtension($triggerPath)) {
                    $existingTriggeringPaths += $triggerPath
                }
            }
        }
    }

    return ($existingTriggeringPaths | Select-Object -Unique)
}

function Update-TargetedFilesForTriggerPaths([string[]]$TargetedFiles, [string[]]$TriggeringPaths) {
    # now we simply loop through the files a single time, keeping all the files that are a triggeringPath
    # for the rest of the files, simply group by what directory they belong to
    # the new TargetedFiles array will contain only the changed directories + the files that actually aligned to a triggeringPath
    $processedFiles = @()
    $Triggers = [System.Collections.ArrayList]$TriggeringPaths
    $i = 0
    foreach ($file in $TargetedFiles) {
        $isExistingTriggerPath = $false

        for ($i = 0; $i -lt $Triggers.Count; $i++) {
            $triggerPath = $Triggers[$i]
            # targeted files comes from the `changedPaths` property of the diff, which is
            # a list of relative file paths from root. Not starting with a /.
            # However, the triggerPaths are absolute paths, so we need to resolve the targeted file
            # to the same format
            if ($triggerPath -and "/$file" -eq "$triggerPath") {
                $isExistingTriggerPath = $true
                break
            }
        }

        if ($isExistingTriggerPath) {
            # we know that we should have a valid $i that we can use to remove the triggerPath from the list
            # so that it gets smaller as we find items
            $Triggers.RemoveAt($i)
            $processedFiles += $file
        }
        else {
            # Get directory path by removing the filename
            $directoryPath = Split-Path -Path $file -Parent
            if ($directoryPath) {
                $processedFiles += $directoryPath
            } else {
                # In case there's no parent directory (root file), keep the original
                $processedFiles += $file
            }
        }
    }

    return ($processedFiles | Select-Object -Unique)
}

function Update-TargetedFilesForExclude([string[]]$TargetedFiles, [string[]]$ExcludePaths) {
    $files = @()
    foreach ($file in $TargetedFiles) {
        $shouldExclude = $false
        foreach ($exclude in $ExcludePaths) {
            if ($file.StartsWith($exclude,'CurrentCultureIgnoreCase')) {
                $shouldExclude = $true
                break
            }
        }
        if (!$shouldExclude) {
            $files += $file
        }
    }
    return ,$files
}

function Get-PrPkgProperties([string]$InputDiffJson) {
    $packagesWithChanges = @()
    $additionalValidationPackages = @()
    $lookup = @{}
    $directoryIndex = @{}

    $allPackageProperties = Get-AllPkgProperties
    $diff = Get-Content $InputDiffJson | ConvertFrom-Json
    $targetedFiles = $diff.ChangedFiles

    if ($diff.DeletedFiles) {
        if (-not $targetedFiles) {
            $targetedFiles = @()
        }
        $targetedFiles += $diff.DeletedFiles
    }

    $existingTriggeringPaths = Get-TriggerPaths $allPackageProperties
    $targetedFiles = Update-TargetedFilesForExclude $targetedFiles $diff.ExcludePaths
    $targetedFiles = Update-TargetedFilesForTriggerPaths $targetedFiles $existingTriggeringPaths

    # Sort so that we very quickly find any directly changed packages before hitting service level changes.
    # This is important because due to the way we traverse the changed files, the instant we evaluate a pkg
    # as directly or indirectly changed, we exit the file loop and move on to the next pkg.
    # The problem is, a package may be detected as indirectly changed _before_ we get to the file that directly changed it!
    # To avoid this without wonky changes to the detection algorithm, we simply sort our files by their depth, so we will always
    # detect direct package changes first!
    $targetedFiles = $targetedFiles | Sort-Object { ($_.Split("/").Count) } -Descending
    $pkgCounter = 1

    # this is the primary loop that identifies the packages that have changes
    foreach ($pkg in $allPackageProperties) {
        Write-Verbose "Processing changed files against $($pkg.Name). $pkgCounter of $($allPackageProperties.Count)."
        $pkgDirectory = (Resolve-Path "$($pkg.DirectoryPath)").Path.Replace("`\", "/")
        $lookupKey = $pkgDirectory.Replace($RepoRoot, "").TrimStart('\/')
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
            $filePath = (Join-Path $RepoRoot $file).Replace("`\", "/")

            # handle direct changes to packages
            $shouldInclude = $filePath -eq $pkgDirectory -or $filePath -like "$pkgDirectory/*"

            $includeMsg = "Including '$($pkg.Name)' because of changed file '$filePath'."

            # we only need to do additional work for indirect packages if we haven't already decided
            # to include this package due to this file
            if (-not $shouldInclude) {
                # handle changes to files that are RELATED to each package
                foreach($triggerPath in $triggeringPaths) {
                    $resolvedRelativePath = (Join-Path $RepoRoot $triggerPath).Replace("`\", "/")
                    # triggerPaths can be direct files, so we need to check both startswith and direct equality
                    $includedForValidation = ($filePath -like ("$resolvedRelativePath/*") -or $filePath -eq $resolvedRelativePath)
                    $shouldInclude = $shouldInclude -or $includedForValidation
                    if ($includedForValidation) {
                        $includeMsg += " - (triggerPath: '$triggerPath')"
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
                    $directory = [System.IO.Path]::GetDirectoryName($ciYml).Replace("`\", "/")

                    # this filepath doesn't apply to this service directory at all, so we can break out of this loop
                    if (-not $filePath.StartsWith("$directory/")) {
                        break
                    }

                    $relative = $filePath.SubString($directory.Length + 1)

                    if ($relative.Contains("/") -or -not [IO.Path]::GetExtension($relative)){
                        # this is a bare folder OR exists deeper than the service directory, so we can skip
                        break
                    }

                    # this GCI is very expensive, so we want to cache the result
                    $soleCIYml = $true
                    if ($directoryIndex[$directory]) {
                        $soleCIYml = $directoryIndex[$directory]
                    }
                    else {
                        $soleCIYml = (Get-ChildItem -Path $directory -Filter "ci*.yml" -File).Count -eq 1
                        $directoryIndex[$directory] = $soleCIYml
                    }

                    if ($soleCIYml -and $filePath.StartsWith($directory)) {
                        if (-not $shouldInclude) {
                            $shouldInclude = $true
                        }
                        break
                    }
                }
            }

            if ($shouldInclude) {

                LogInfo $includeMsg
                $packagesWithChanges += $pkg

                if ($pkg.AdditionalValidationPackages) {
                    $additionalValidationPackages += $pkg.AdditionalValidationPackages
                }

                # avoid adding the same package multiple times
                break
            }
        }

        $pkgCounter++
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
                LogInfo "Including '$($pkg.Name)' for validation only because it is a dependency of another package."
                $packagesWithChanges += $pkg
            }
        }
    }

    # now pass along the set of packages we've identified, the diff itself, and the full set of package properties
    # to locate any additional packages that should be included for validation
    if ($AdditionalValidationPackagesFromPackageSetFn -and (Test-Path "Function:$AdditionalValidationPackagesFromPackageSetFn")) {
        $additionalPackages = &$AdditionalValidationPackagesFromPackageSetFn $packagesWithChanges $diff $allPackageProperties
        $packagesWithChanges += $additionalPackages
        foreach ($pkg in $additionalPackages) {
            LogInfo "Including '$($pkg.Name)' from the additional validation package set."
        }
    }

    # finally, if we have gotten all the way here and we still don't have any packages, we should include the template service
    # packages. We should never return NO validation.
    if ($packagesWithChanges.Count -eq 0) {
        # most of our languages use `template` as the service directory for the template service, but `go` uses `template/aztemplate`.
        $packagesWithChanges += ($allPackageProperties | Where-Object { $_.ServiceDirectory -eq "template"-or $_.ServiceDirectory -eq "template/aztemplate" })
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
