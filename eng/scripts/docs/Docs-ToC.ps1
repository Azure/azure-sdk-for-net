function Get-NamespacesFromDll($dllPath) {
    $file = [System.IO.File]::OpenRead($dllPath)
    $namespaces = @()
    try {
        # Use to parse the namespaces out from the dll file.
        $pe = [System.Reflection.PortableExecutable.PEReader]::new($file)
        try {
            $meta = [System.Reflection.Metadata.PEReaderExtensions]::GetMetadataReader($pe)
            foreach ($typeHandle in $meta.TypeDefinitions) {
                $type = $meta.GetTypeDefinition($typeHandle)
                $attr = $type.Attributes
                if ($attr -band 'Public' -and !$type.IsNested) {
                    $namespaces += $meta.GetString($type.Namespace)
                }
            }
        } finally {
            $pe.Dispose()
        }
    } finally {
        $file.Dispose()
    }
    return $namespaces | Sort-Object -Unique
}

function DownloadNugetPackage($package, $version, $destination) {
    # $PackageSourceOverride is a global variable provided in
    # Update-DocsMsToc.ps1. Its value can set a "customSource" property.
    # If it is empty then the property is not overridden.
    $customPackageSource = Get-Variable -Name 'PackageSourceOverride' -ValueOnly -ErrorAction 'Ignore'
    # Download package from nuget, if no package found in nuget, then search devops public feeds if set.
    LogDebug "Downloading source: '$customPackageSource'. If it is empty, we default to use nuget gallery."
    if ($customPackageSource) {
        nuget install -FallbackSource $customPackageSource $package -Version $version -DirectDownload -DependencyVersion Ignore -OutputDirectory $destination
    }
    else {
        nuget install $package -Version $version -DirectDownload -DependencyVersion Ignore -OutputDirectory $destination
    }
}

function Fetch-NamespacesFromNupkg ($package, $version) {
    $tempLocation = (Join-Path ([System.IO.Path]::GetTempPath()) "extractNupkg")
    if (!(Test-Path $tempLocation)) {
        New-Item -ItemType Directory -Path $tempLocation -Force | Out-Null
    }
    LogDebug "Downloading nupkg package $package with version $version to $tempLocation ...."
    DownloadNugetPackage -package $package -version $version -destination $tempLocation | Out-Null
    $packageFolder = "$package.$version"
    if ($LASTEXITCODE -ne 0 -or !$(Test-Path $tempLocation/$packageFolder)) {
        LogDebug "Did not download the package correctly. Skipping..."
        return @()
    }
    LogDebug "Searching for dll file..."
    $dllFiles = @()
    $dllFileName = ""
    if (Test-Path "$tempLocation/$packageFolder/lib/netstandard2.0/"){
        $dllFiles = @(Get-ChildItem "$tempLocation/$packageFolder/lib/netstandard2.0/*" -Filter '*.dll' -Recurse)
    }
    if (!$dllFiles) {
        LogWarning "Can't find any dll file from $tempLocation/$packageFolder with target netstandard2.0."
        $dllFiles = Get-ChildItem "$tempLocation/$packageFolder/lib/*" -Filter '*.dll' -Recurse
        if (!$dllFiles) {
            LogError "Can't find any dll file from $tempLocation/$packageFolder."
            return @()
        }
    }
    elseif ($dllFiles.Count -gt 1) {
        LogWarning "There are multiple dll files in target netstandard2.0 for $package."
        if (Test-Path "$tempLocation/$packageFolder/lib/netstandard2.0/$package.dll") {
            LogDebug "Use the dll file $package.dll"
            $dllFileName = "$tempLocation/$packageFolder/lib/netstandard2.0/$package.dll"
        }
    }
    if (!$dllFileName) {
        $dllFiles = $dllFiles | Get-Unique | Sort-Object
        $dllFileName = $dllFiles[0].FullName
    }
    LogDebug "Dll file found: $dllFileName"
    $namespaces = Get-NamespacesFromDll $dllFileName
    if (!$namespaces) {
        LogError "Can't find namespaces from dll file $dllFileName."
        return @()
    }
    return $namespaces
}

function Get-dotnet-OnboardedDocsMsPackages($DocRepoLocation) {
    $packageOnboardingFiles = @(
        "$DocRepoLocation/bundlepackages/azure-dotnet.csv",
        "$DocRepoLocation/bundlepackages/azure-dotnet-preview.csv",
        "$DocRepoLocation/bundlepackages/azure-dotnet-legacy.csv")

    $onboardedPackages = @{}
    foreach ($file in $packageOnboardingFiles) {
        $onboardingSpec = Get-Content $file
        foreach ($spec in $onboardingSpec) {
            $packageInfo = $spec -split ","
            if (!$packageInfo -or ($packageInfo.Count -lt 2)) {
                LogError "Please check the package info in csv file $file. Please have at least one package and follow the format {name index, package name, version(optional)}"
                return $null
            }
            $packageName = $packageInfo[1].Trim() -replace "\[.*\](.*)", '$1'
            $onboardedPackages[$packageName] = $null
        }
    }
    return $onboardedPackages
}

# The function use docs package info as a key and metadata/package.json as value to build a map.
function Get-dotnet-OnboardedDocsMsPackagesForMoniker ($DocRepoLocation, $moniker) {
    $onboardingSpec = "$DocRepoLocation/bundlepackages/azure-dotnet.csv"
    if ("preview" -eq $moniker) {
        $onboardingSpec = "$DocRepoLocation/bundlepackages/azure-dotnet-preview.csv"
    }
    $onboardedPackages = @{}
    $packageInfos = Get-DocsCiConfig $onboardingSpec
    foreach ($packageInfo in $packageInfos) {
        $packageName = $packageInfo.Name
        if (!$packageName) {
            LogError "Package name not found. Please check csv file for the packageId: $($packageInfo.Id)"
        }
        $jsonFile = "$DocRepoLocation/metadata/$moniker/$packageName.json"
        if (Test-Path $jsonFile) {
            $packageInfoJson = ConvertFrom-Json (Get-Content $jsonFile -Raw)
            if (!($packageInfoJson.PSObject.Members.Name -contains "DirectoryPath")) {
                $packageInfoJson | Add-Member -Name "DirectoryPath" -value "" -MemberType NoteProperty
            }
            $onboardedPackages["$packageName"] = $packageInfoJson
        }
        else {
            LogDebug "There is no package json for package $packageName."
            $onboardedPackages["$packageName"] = $null
        }
    }
    return $onboardedPackages
}

function GetPackageReadmeName($packageMetadata) {
    # Fallback to get package-level readme name if metadata file info does not exist
    $packageLevelReadmeName = $packageMetadata.Package.ToLower().Replace('azure.', '')
  
    # If there is a metadata json for the package use the DocsMsReadmeName from
    # the metadata function
    if ($packageMetadata.PSObject.Members.Name -contains "FileMetadata") {
      $readmeMetadata = &$GetDocsMsMetadataForPackageFn -PackageInfo $packageMetadata.FileMetadata
      $packageLevelReadmeName = $readmeMetadata.DocsMsReadMeName
    }
    return $packageLevelReadmeName
}
  
# Defined in common.ps1
# $GetDocsMsTocDataFn = "Get-${Language}-DocsMsTocData"
function Get-dotnet-DocsMsTocData($packageMetadata, $docRepoLocation, $PackageSourceOverride) {
    $packageLevelReadmeName = GetPackageReadmeName -packageMetadata $packageMetadata
    $packageTocHeader = GetDocsTocDisplayName $packageMetadata

    $children = Get-Toc-Children `
        -package $packageMetadata.Package `
        -docRepoLocation $docRepoLocation 

    if (!$children) {
        LogWarning "Did not find the package namespaces for $($packageMetadata.Package)"
    }
    $output = [PSCustomObject]@{
      PackageLevelReadmeHref = "~/api/overview/azure/{moniker}/$packageLevelReadmeName-readme.md"
      PackageTocHeader       = $packageTocHeader
      TocChildren            = @($children)
    }
  
    return $output
}


# TODO: Refactor
$script:PackageMetadataJsonLookup = $null
function GetPackageMetadataJsonLookup($docRepoLocation) { 
    if ($script:PackageMetadataJsonLookup) {
        return $script:PackageMetadataJsonLookup
    }

    $script:PackageMetadataJsonLookup = @{}
    $packageJsonFiles = Get-ChildItem $docRepoLocation/metadata/ -Filter *.json -Recurse
    foreach ($packageJsonFile in $packageJsonFiles) {
        $packageJson = Get-Content $packageJsonFile -Raw | ConvertFrom-Json -AsHashtable

        if (!$script:PackageMetadataJsonLookup.ContainsKey($packageJson.Name)) { 
            $script:PackageMetadataJsonLookup[$packageJson.Name] = @($packageJson)
        } else { 
            $script:PackageMetadataJsonLookup[$packageJson.Name] += $packageJson
        }
    }

    return $script:PackageMetadataJsonLookup
}

function Get-Toc-Children($package, $docRepoLocation) {
    $packageTable = GetPackageMetadataJsonLookup $docRepoLocation

    $namespaces = @()
    if ($packageTable.ContainsKey($package)) { 
        foreach ($entry in $packageTable[$package]) {
            if ($entry.ContainsKey('Namespaces')) {
                $namespaces += $entry['Namespaces']
            }
        }
    }

    return $namespaces | Sort-Object -Unique
}

function Get-dotnet-PackageLevelReadme ($packageMetadata) {
    return GetPackageReadmeName -packageMetadata $packageMetadata
}
