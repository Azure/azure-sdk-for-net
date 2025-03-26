$Language = "dotnet"
$LanguageShort = "net"
$LanguageDisplayName = ".NET"
$PackageRepository = "Nuget"
$packagePattern = "*.nupkg"
$MetadataUri = "https://raw.githubusercontent.com/Azure/azure-sdk/main/_data/releases/latest/dotnet-packages.csv"
$GithubUri = "https://github.com/Azure/azure-sdk-for-net"
$PackageRepositoryUri = "https://www.nuget.org/packages"

. "$PSScriptRoot/docs/Docs-ToC.ps1"

$DependencyCalculationPackages = @(
  "Azure.Core",
  "Azure.ResourceManager"
)

function processTestProject($projPath) {
  $cleanPath = $projPath -replace "^\$\(RepoRoot\)", ""

  # Split the path into segments
  $pathSegments = $cleanPath -split "[\\/]"

  # Find the index of the 'tests' directory
  $testsIndex = $pathSegments.IndexOf("tests")

  if ($testsIndex -gt 0) {
      # Reconstruct the path up to the directory just above 'tests'
      $parentDirectory = ($pathSegments[0..($testsIndex - 1)] -join [System.IO.Path]::DirectorySeparatorChar)
      return $parentDirectory
  } else {
      Write-Error "Unable to retrieve a package directory for this this test project: $projPath"
      # If 'tests' is not found, return the original path (optional behavior)
      $_
  }
}

function Get-AllPackageInfoFromRepo($serviceDirectory)
{
  $allPackageProps = @()
  # $addDevVersion is a global variable set by a parameter in
  # Save-Package-Properties.ps1
  $shouldAddDevVersion = Get-Variable -Name 'addDevVersion' -ValueOnly -ErrorAction 'Ignore'
  $ServiceProj = Join-Path -Path $EngDir -ChildPath "service.proj"
  Write-Host "Get-AllPackageInfoFromRepo::Executing msbuild"
  Write-Host "dotnet msbuild /nologo /t:GetPackageInfo $ServiceProj /p:ServiceDirectory=$serviceDirectory /p:AddDevVersion=$shouldAddDevVersion"

  $msbuildOutput = dotnet msbuild `
    /nologo `
    /t:GetPackageInfo `
    $ServiceProj `
    /p:ServiceDirectory=$serviceDirectory `
    /p:AddDevVersion=$shouldAddDevVersion

  foreach ($projectOutput in $msbuildOutput)
  {
    if (!$projectOutput) {
      Write-Host "Get-AllPackageInfoFromRepo::projectOutput was null or empty, skipping"
      continue
    }

    $pkgPath, $serviceDirectory, $pkgName, $pkgVersion, $sdkType, $isNewSdk, $dllFolder = $projectOutput.Split(' ',[System.StringSplitOptions]::RemoveEmptyEntries).Trim("'")
    if(!(Test-Path $pkgPath)) {
      Write-Host "Parsed package path `$pkgPath` does not exist so skipping the package line '$projectOutput'."
      continue
    }

    $pkgProp = [PackageProps]::new($pkgName, $pkgVersion, $pkgPath, $serviceDirectory)
    $pkgProp.SdkType = $sdkType
    $pkgProp.IsNewSdk = ($isNewSdk -eq 'true')
    $pkgProp.ArtifactName = $pkgName
    $pkgProp.IncludedForValidation = $false
    $pkgProp.DirectoryPath = ($pkgProp.DirectoryPath)

    if ($pkgProp.Name -in $DependencyCalculationPackages -and $env:DISCOVER_DEPENDENT_PACKAGES) {
      Write-Host "Calculating dependencies for $($pkgProp.Name)"
      $outputFilePath = Join-Path $RepoRoot "$($pkgProp.Name)_dependencylist.txt"
      $buildOutputPath = Join-Path $RepoRoot "$($pkgProp.Name)_dependencylistoutput.txt"

      if (!(Test-Path $outputFilePath)) {
        try {
          $command = "dotnet build /t:ProjectDependsOn ./eng/service.proj /p:TestDependsOnDependency=`"$($pkgProp.Name)`" /p:IncludeSrc=false " +
          "/p:IncludeStress=false /p:IncludeSamples=false /p:IncludePerf=false /p:RunApiCompat=false /p:InheritDocEnabled=false /p:BuildProjectReferences=false" +
          " /p:OutputProjectFilePath=`"$outputFilePath`" > $buildOutputPath 2>&1"

          Invoke-LoggedCommand $command | Out-Null
        }
        catch {
            Write-Host "Failed calculating dependencies for $($pkgProp.Name). Exit code $LASTEXITCODE."
            Write-Host "Dumping erroring build output."
            Write-Host (Get-Content -Raw $buildOutputPath)
            continue
        }
      }

      $pkgRelPath = $pkgProp.DirectoryPath.Replace($RepoRoot, "").TrimStart("\/")

      if (Test-Path $outputFilePath) {
        $dependentProjects = Get-Content $outputFilePath
        $testPackages = @{}

        foreach ($projectLine in $dependentProjects) {
          $testPackage = processTestProject($projectLine)
          if ($testPackage -and $testPackage -ne $pkgRelPath) {
            if ($testPackages[$testPackage]) {
              $testPackages[$testPackage] += 1
            }
            else {
              $testPackages[$testPackage] = 1
            }
          }
        }

        $pkgProp.AdditionalValidationPackages = $testPackages.Keys

        Write-Host "Cleaning up $outputFilePath."
      }
    }

    $allPackageProps += $pkgProp
  }

  return $allPackageProps
}

<#
.DESCRIPTION
This function governs the logic for determining which packages should be included for validation in net - pullrequest
when the PR contains changes to files outside of package directories.

.PARAMETER LocatedPackages
The set of packages that have been directly changed in the PR.

.PARAMETER diffObj
The diff object that contains the set of changed and deleted files in the PR.

.PARAMETER AllPkgProps
The entire set of package properties for the repository.

#>
function Get-dotnet-AdditionalValidationPackagesFromPackageSet {
  param(
    [Parameter(Mandatory=$true)]
    $LocatedPackages,
    [Parameter(Mandatory=$true)]
    $diffObj,
    [Parameter(Mandatory=$true)]
    $AllPkgProps
  )
  $additionalValidationPackages = @()
  $uniqueResultSet = @()
  function isOther($fileName) {
    $startsWithPrefixes = @(".config", ".devcontainer", ".github", ".vscode", "common", "doc", "eng", "samples")

    $startsWith = $false
    foreach ($prefix in $startsWithPrefixes) {
      if ($fileName.StartsWith($prefix)) {
        $startsWith = $true
      }
    }

    return $startsWith
  }

  # ensure we observe deleted files too
  $targetedFiles = @($diffObj.ChangedFiles + $diffObj.DeletedFiles)

  # The targetedFiles needs to filter out anything in the ExcludePaths
  # otherwise it'll end up processing things below that it shouldn't be.
  foreach ($excludePath in $diffObj.ExcludePaths) {
    $targetedFiles = $targetedFiles | Where-Object { -not $_.StartsWith($excludePath) }
  }

  # this section will identify
  #  - any service-level changes
  #  - any shared package changes that should be treated as a service-level change. EG changes to Azure.Storage.Shared.
  # and add all packages within that service to the validation set. these will be treated as "directly" changed packages.
  $changedServices = @()
  if ($targetedFiles) {
    foreach($file in $targetedFiles) {
      $pathComponents = $file -split "/"
      # handle changes only in sdk/<service>/<file>.<extension>
      if ($pathComponents.Length -eq 3 -and $pathComponents[0] -eq "sdk") {
        $changedServices += $pathComponents[1]
      }

      # handle any changes under sdk/<file>.<extension> or any files
      # in the repository root
      if (($pathComponents.Length -eq 2 -and $pathComponents[0] -eq "sdk") -or
          ($pathComponents.Length -eq 1)) {
        $changedServices += "template"
      }

      # changes to a Azure.*.Shared within a service directory should include all packages within that service directory
      if ($file.Replace('\', '/') -match ".*sdk/.*/.*\.Shared/.*") {
        $changedServices += $pathComponents[1]
      }
    }
    # dedupe the changedServices list before processing
    $changedServices = $changedServices | Get-Unique
    foreach ($changedService in $changedServices) {
      $additionalPackages = $AllPkgProps | Where-Object { $_.ServiceDirectory -eq $changedService }

      foreach ($pkg in $additionalPackages) {
        if ($uniqueResultSet -notcontains $pkg -and $LocatedPackages -notcontains $pkg) {
          # notice the lack of setting IncludedForValidation to true. This is because these "changed services"
          # are specifically where a file within the service, but not an individual package within that service has changed.
          # we want this package to be fully validated
          $uniqueResultSet += $pkg
        }
      }
    }
  }

  # handle any changes to files that are not within a package directory
  $othersChanged = @()
  if ($targetedFiles) {
    $othersChanged = $targetedFiles | Where-Object { isOther($_) }
  }

  if ($othersChanged) {
    $additionalPackages = @(
      "Azure.Template"
    ) | ForEach-Object { $me=$_; $AllPkgProps | Where-Object { $_.Name -eq $me } | Select-Object -First 1 }

    $additionalValidationPackages += $additionalPackages
  }

  # walk the packages added purely for validation, if they haven't been added yet, add them
  # these packages aren't considered "directly" changed, so we will set IncludedForValidation to true for them
  foreach ($pkg in $additionalValidationPackages) {
    if ($uniqueResultSet -notcontains $pkg -and $LocatedPackages -notcontains $pkg) {
      $pkg.IncludedForValidation = $true
      $uniqueResultSet += $pkg
    }
  }

  Write-Host "Returning additional packages for validation: $($uniqueResultSet.Count)"
  foreach ($pkg in $uniqueResultSet) {
    Write-Host "  - $($pkg.Name)"
  }

  return $uniqueResultSet
}

# Returns the nuget publish status of a package id and version.
function IsNugetPackageVersionPublished ($pkgId, $pkgVersion)
{
  $nugetUri = "https://api.nuget.org/v3-flatcontainer/$($pkgId.ToLowerInvariant())/index.json"

  try
  {
    $nugetVersions = Invoke-RestMethod -MaximumRetryCount 3 -RetryIntervalSec 10 -uri $nugetUri -Method "GET"
    return $nugetVersions.versions.Contains($pkgVersion)
  }
  catch
  {
    $statusCode = $_.Exception.Response.StatusCode.value__
    $statusDescription = $_.Exception.Response.ReasonPhrase

    # if this is 404ing, then this pkg has never been published before
    if ($statusCode -eq 404) {
      return $False
    }

    Write-Host "Nuget Invocation failed:"
    Write-Host "StatusCode:" $statusCode
    Write-Host "StatusDescription:" $statusDescription
    exit(1)
  }
}

# Parse out package publishing information given a nupkg ZIP format.
function Get-dotnet-PackageInfoFromPackageFile ($pkg, $workingDirectory)
{
  $workFolder = "$workingDirectory$($pkg.Basename)"
  $zipFileLocation = "$workFolder/$($pkg.Basename).zip"
  $releaseNotes = ""
  $readmeContent = ""

  New-Item -ItemType Directory -Force -Path $workFolder

  Copy-Item -Path $pkg -Destination $zipFileLocation
  Expand-Archive -Path $zipFileLocation -DestinationPath $workFolder
  [xml] $packageXML = Get-ChildItem -Path "$workFolder/*.nuspec" | Get-Content
  $pkgId = $packageXML.package.metadata.id
  $docsReadMeName = $pkgId -replace "^Azure." , ""
  $pkgVersion = $packageXML.package.metadata.version

  $changeLogLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "CHANGELOG.md")[0]
  if ($changeLogLoc)
  {
    $releaseNotes = Get-ChangeLogEntryAsString -ChangeLogLocation $changeLogLoc -VersionString $pkgVersion
  }

  $readmeContentLoc = @(Get-ChildItem -Path $workFolder -Recurse -Include "README.md")[0]
  if ($readmeContentLoc)
  {
    $readmeContent = Get-Content -Raw $readmeContentLoc
  }

  Remove-Item $workFolder -Force  -Recurse -ErrorAction SilentlyContinue

  return New-Object PSObject -Property @{
    PackageId      = $pkgId
    PackageVersion = $pkgVersion
    ReleaseTag     = "$($pkgId)_$($pkgVersion)"
    Deployable     = $forceCreate -or !(IsNugetPackageVersionPublished -pkgId $pkgId -pkgVersion $pkgVersion)
    ReleaseNotes   = $releaseNotes
    ReadmeContent  = $readmeContent
    DocsReadMeName = $docsReadMeName
  }
}

# Return list of nupkg artifacts
function Get-dotnet-Package-Artifacts ($Location)
{
  $pkgs = @(Get-ChildItem $Location -Recurse | Where-Object -FilterScript {$_.Name.EndsWith(".nupkg") -and -not $_.Name.EndsWith(".symbols.nupkg")})
  if (!$pkgs)
  {
    Write-Host "$($Location) does not have any package"
    return $null
  }
  elseif ($pkgs.Count -ne 1)
  {
    Write-Host "$($Location) should contain only one (1) published package"
    Write-Host "No of Packages $($pkgs.Count)"
    return $null
  }
  return $pkgs[0]
}

# Stage and Upload Docs to blob Storage
function Publish-dotnet-GithubIODocs ($DocLocation, $PublicArtifactLocation)
{
  $PublishedPkg = Get-dotnet-Package-Artifacts $DocLocation
  if (!$PublishedPkg)
  {
    Write-Host "Package is not available in artifact path $($DocLocation)"
    exit 1
  }

  $PublishedDocs = Get-ChildItem "${DocLocation}" | Where-Object -FilterScript {$_.Name.EndsWith("docs.zip")}

  if ($PublishedDoc.Count -gt 1)
  {
      Write-Host "$($DocLocation) should contain only one (1) published package and docs"
      Write-Host "No of Docs $($PublishedDoc.Count)"
      exit 1
  }

  $DocsStagingDir = "$WorkingDirectory/docstaging"
  $TempDir = "$WorkingDirectory/temp"

  New-Item -ItemType directory -Path $DocsStagingDir
  New-Item -ItemType directory -Path $TempDir

  Expand-Archive -LiteralPath $PublishedDocs[0].FullName -DestinationPath $DocsStagingDir
  $pkgProperties = Get-dotnet-PackageInfoFromPackageFile -pkg $PublishedPkg.FullName -workingDirectory $TempDir

  Write-Host "Start Upload for $($pkgProperties.ReleaseTag)"
  Write-Host "DocDir $($DocsStagingDir)"
  Write-Host "PkgName $($pkgProperties.PackageId)"
  Write-Host "DocVersion $($pkgProperties.PackageVersion)"
  Upload-Blobs -DocDir "$($DocsStagingDir)" -PkgName $pkgProperties.PackageId -DocVersion $pkgProperties.PackageVersion -ReleaseTag $pkgProperties.ReleaseTag
}

function Get-dotnet-GithubIoDocIndex()
{
  # Update the main.js and docfx.json language content
  UpdateDocIndexFiles -appTitleLang $LanguageDisplayName
  # Fetch out all package metadata from csv file.
  $metadata = Get-CSVMetadata -MetadataUri $MetadataUri
  # Get the artifacts name from blob storage
  $artifacts =  Get-BlobStorage-Artifacts `
    -blobDirectoryRegex "^dotnet/(.*)/$" `
    -blobArtifactsReplacement '$1' `
    -storageAccountName 'azuresdkdocs' `
    -storageContainerName '$web' `
    -storagePrefix 'dotnet/'

  # Build up the artifact to service name mapping for GithubIo toc.
  $tocContent = Get-TocMapping -metadata $metadata -artifacts $artifacts
  # Generate yml/md toc files and build site.
  GenerateDocfxTocContent -tocContent $tocContent -lang $LanguageDisplayName -campaignId "UA-62780441-41"
}

# details on CSV schema can be found here
# https://review.docs.microsoft.com/en-us/help/onboard/admin/reference/dotnet/documenting-nuget?branch=master#set-up-the-ci-job
function Update-dotnet-CIConfig($pkgs, $ciRepo, $locationInDocRepo, $monikerId=$null)
{
  $csvLoc = (Join-Path -Path $ciRepo -ChildPath $locationInDocRepo)

  if (-not (Test-Path $csvLoc)) {
    Write-Error "Unable to locate package csv at location $csvLoc, exiting."
    exit(1)
  }

  $allCSVRows = Get-Content $csvLoc
  $visibleInCI = @{}

  # first pull what's already available
  for ($i=0; $i -lt $allCSVRows.Length; $i++) {
    $pkgDef = $allCSVRows[$i]

    # get rid of the modifiers to get just the package id
    $id = $pkgDef.split(",")[1] -replace "\[.*?\]", ""

    $visibleInCI[$id] = $i
  }

  foreach ($releasingPkg in $pkgs) {
    $installModifiers = "tfm=netstandard2.0"
    if ($releasingPkg.IsPrerelease) {
      $installModifiers += ";isPrerelease=true"
    }
    $lineId = $releasingPkg.PackageId.Replace(".","").ToLower()

    if ($visibleInCI.ContainsKey($releasingPkg.PackageId)) {
      $packagesIndex = $visibleInCI[$releasingPkg.PackageId]
      $allCSVRows[$packagesIndex] = "$($lineId),[$installModifiers]$($releasingPkg.PackageId)"
    }
    else {
      $newItem = "$($lineId),[$installModifiers]$($releasingPkg.PackageId)"
      $allCSVRows += ($newItem)
    }
  }

  Set-Content -Path $csvLoc -Value $allCSVRows
}

# function is used to auto generate API View
function Find-dotnet-Artifacts-For-Apireview($artifactDir, $packageName)
{
  # Find all nupkg files in given artifact directory
  $PackageArtifactPath = Join-Path $artifactDir $packageName
  $pkg = Get-dotnet-Package-Artifacts $PackageArtifactPath
  if (!$pkg)
  {
    Write-Host "Package is not available in artifact path $($PackageArtifactPath)"
    return $null
  }
  $packages = @{ $pkg.Name = $pkg.FullName }
  return $packages
}

function SetPackageVersion ($PackageName, $Version, $ServiceDirectory, $ReleaseDate, $ReplaceLatestEntryTitle=$true)
{
  if($null -eq $ReleaseDate)
  {
    $ReleaseDate = Get-Date -Format "yyyy-MM-dd"
  }
  & "$EngDir/scripts/Update-PkgVersion.ps1" -ServiceDirectory $ServiceDirectory -PackageName $PackageName `
  -NewVersionString $Version -ReleaseDate $ReleaseDate -ReplaceLatestEntryTitle $ReplaceLatestEntryTitle
}

function GetExistingPackageVersions ($PackageName, $GroupId=$null)
{
  try {
    $PackageName = $PackageName.ToLower()
    $existingVersion = Invoke-RestMethod -Method GET -Uri "https://api.nuget.org/v3-flatcontainer/${PackageName}/index.json"
    return $existingVersion.versions
  }
  catch {
    if ($_.Exception.Response.StatusCode -ne 404)
    {
      LogError "Failed to retrieve package versions for ${PackageName}. $($_.Exception.Message)"
    }
    return $null
  }
}

function Get-dotnet-DocsMsMetadataForPackage($PackageInfo) {
  $readmeName = $PackageInfo.Name.ToLower()

  # Readme names (which are used in the URL) should not include redundant terms
  # when viewed in URL form. For example:
  # https://docs.microsoft.com/en-us/dotnet/api/overview/azure/storage.blobs-readme
  # Note how the end of the URL doesn't look like:
  # ".../azure/azure.storage.blobs-readme"

  # This logic eliminates a preceeding "azure." in the readme filename.
  # "azure.storage.blobs" -> "storage.blobs"
  if ($readmeName.StartsWith('azure.')) {
    $readmeName = $readmeName.Substring(6)
  }

  New-Object PSObject -Property @{
    DocsMsReadMeName = $readmeName
    LatestReadMeLocation = 'api/overview/azure/latest'
    PreviewReadMeLocation = 'api/overview/azure/preview'
    LegacyReadMeLocation = 'api/overview/azure/legacy'
    Suffix = ''
  }
}

# Details on CSV schema:
# https://review.docs.microsoft.com/en-us/help/onboard/admin/reference/dotnet/documenting-nuget?branch=master#set-up-the-ci-job
#
# PowerShell's included Import-Csv cmdlet is not sufficient for parsing this
# format because it does not easily handle rows whose number of columns is
# greater than the number of columns in the first row. We must manually parse
# this CSV file.
function Get-DocsCiConfig($configPath) {
  Write-Host "Loading csv from $configPath"
  $output = @()
  foreach ($row in Get-Content $configPath) {
      # CSV format:
      # {package_moniker_base_string},{package_ID},{version_1},{version_2},...,{version_N}
      #
      # The {package_ID} field can contain optional properties denoted by square
      # brackets of the format: [key=value;key=value;...]

      # Split the rows by the comma
      $fields = $row.Split(',')

      if (!$fields -or $fields.Count -lt 2) {
        LogError "Please check the csv entry: $configPath."
        LogError "Do include the package name for each of the csv entry."
      }
      # If the {package_ID} field contains optional properties inside square
      # brackets, parse those properties into key value pairs. In the case of
      # duplicate keys, the last one wins.
      $rawProperties = ''
      $packageProperties = [ordered]@{}
      if ($fields[1] -match '\[(.*)\]') {
          $rawProperties = $Matches[1]
          foreach ($propertyExpression in $rawProperties.Split(';')) {
              $propertyParts = $propertyExpression.Split('=')
              $packageProperties[$propertyParts[0]] = $propertyParts[1]
          }
      }

      # Matches the "Package.Name" from the {package_ID} field. Possible
      # formats:
      # [key=value;key=value]Package.Name
      # Package.Name
      $packageName = ''
      if ($fields[1] -match '(\[.*\])?(.*)') {
          $packageName = $Matches[2]
      } else {
          Write-Error "Could not find package id in row: $row"
      }

      # Remaining entries in the row are versions, add them to the package
      # properties
      $outputVersions = @()
      if ($fields.Count -gt 2 -and $fields[2]) {
        $outputVersions = $fields[2..($fields.Count - 1)]
      }

      # Example row:
      # packagemoniker,[key1=value1;key2=value2]Package.Name,1.0.0,1.2.3-beta.1
      $output += [PSCustomObject]@{
          Id = $fields[0];                  # packagemoniker
          Name = $packageName;              # Package.Name
          Properties = $packageProperties;  # @{key1='value1'; key2='value2'}
          Versions = $outputVersions        # @('1.0.0', '1.2.3-beta.1')
      }
  }

  return $output
}

function EnsureCustomSource($package) {
  # $PackageSourceOverride is a global variable provided in
  # Update-DocsMsPackages.ps1. Its value can set a "customSource" property.
  # If it is empty then the property is not overridden.
  $customPackageSource = Get-Variable -Name 'PackageSourceOverride' -ValueOnly -ErrorAction 'Ignore'
  if (!$customPackageSource) {
    return $package
  }

  if (!(Get-PackageSource -Name CustomPackageSource -ErrorAction Ignore)) {
    Write-Host "Registering custom package source $customPackageSource"
    Register-PackageSource `
      -Name CustomPackageSource `
      -Location $customPackageSource `
      -ProviderName NuGet `
      -Force
  }

  Write-Host "Checking custom package source for $($package.Name)"
  try {
    $existingVersions = Find-Package `
      -Name $package.Name `
      -Source CustomPackageSource `
      -AllVersions `
      -AllowPrereleaseVersions

      if (!$? -or !$existingVersions) {
        Write-Host "Failed to find package $($package.Name) in custom source $customPackageSource"
        return $package
      }
  }
  catch {
    Write-Error $_ -ErrorAction Continue
    return $package
  }

  # Matches package version against output:
  # "Azure.Security.KeyVault.Secrets 4.3.0-alpha.20210915.3"
  $matchedVersion = $existingVersions.Where({$_.Version -eq $package.Versions})

  if (!$matchedVersion) {
    return $package
  }

  $package.Properties['customSource'] = $customPackageSource
  return $package
}

function Get-dotnet-EmitterName() {
  return "@azure-tools/typespec-csharp"
}

function Get-dotnet-EmitterAdditionalOptions([string]$projectDirectory) {
  return "--option @azure-tools/typespec-csharp.emitter-output-dir=$projectDirectory/src"
}

function Update-dotnet-GeneratedSdks([string]$PackageDirectoriesFile) {
  Push-Location $RepoRoot
  try {
    Write-Host "`n`n======================================================================"
    Write-Host "Generating projects" -ForegroundColor Yellow
    Write-Host "======================================================================`n"

    $packageDirectories = Get-Content $PackageDirectoriesFile | ConvertFrom-Json

    # Build the project list override file

    $lines = @('<Project>', '  <ItemGroup>')

    foreach ($directory in $packageDirectories) {
      $projects = Get-ChildItem -Path "$RepoRoot/sdk/$directory" -Filter "*.csproj" -Recurse
      foreach ($project in $projects) {
        $lines += "    <ProjectReference Include=`"$($project.FullName)`" />"
      }
    }

    $lines += '  </ItemGroup>', '</Project>'
    $artifactsPath = Join-Path $RepoRoot "artifacts"
    $projectListOverrideFile = Join-Path $artifactsPath "GeneratedSdks.proj"

    Write-Host "Creating project list override file $projectListOverrideFile`:"
    $lines | ForEach-Object { "  $_" } | Out-Host

    New-Item $artifactsPath -ItemType Directory -Force | Out-Null
    $lines | Out-File $projectListOverrideFile -Encoding UTF8
    Write-Host "`n"

    # Install autorest locally
    Invoke-LoggedCommand "npm ci --prefix $RepoRoot"

    Write-Host "Running npm ci over emitter-package.json in a temp folder to prime the npm cache"

    $tempFolder = New-TemporaryFile
    $tempFolder | Remove-Item -Force
    New-Item $tempFolder -ItemType Directory -Force | Out-Null

    Push-Location $tempFolder
    try {
        Copy-Item "$RepoRoot/eng/emitter-package.json" "package.json"
        if(Test-Path "$RepoRoot/eng/emitter-package-lock.json") {
            Copy-Item "$RepoRoot/eng/emitter-package-lock.json" "package-lock.json"
            Invoke-LoggedCommand "npm ci"
        } else {
          Invoke-LoggedCommand "npm install"
        }
    }
    finally {
      Pop-Location
      $tempFolder | Remove-Item -Force -Recurse
    }

    # Generate projects
    $showSummary = ($env:SYSTEM_DEBUG -eq 'true') -or ($VerbosePreference -ne 'SilentlyContinue')
    $summaryArgs = $showSummary ? "/v:n /ds" : ""

    Invoke-LoggedCommand "dotnet msbuild /restore /t:GenerateCode /p:ProjectListOverrideFile=$(Resolve-Path $projectListOverrideFile -Relative) $summaryArgs eng\service.proj"
  }
  finally {
    Pop-Location
  }
}

function Get-dotnet-ApiviewStatusCheckRequirement($packageInfo) {
  if ($packageInfo.IsNewSdk -and ($packageInfo.SdkType -eq "client" -or $packageInfo.SdkType -eq "mgmt")) {
    return $true
  }
  return $false
}
