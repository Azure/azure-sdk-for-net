. "$PSScriptRoot/../../common/scripts/common.ps1"

Set-StrictMode -Version 3

function GetPropertyString($docsCiConfigProperties) {
    $propertyArray = @()
    foreach ($key in $docsCiConfigProperties.Keys) {
        $propertyArray += "$key=$($docsCiConfigProperties[$key])"
    }
    return $propertyArray -join ';'
}

function Get-DocsCiLine2($item) {
    $line = ''
    if ($item.ContainsKey('DocsCiConfigProperties') -and $item['DocsCiConfigProperties'].Count -gt 0) {
        $line = "$($item['Id']),[$(GetPropertyString $item['DocsCiConfigProperties'])]$($item['Name'])"
    } else {
        $line = "$($item['Id']),$($item['Name'])"
    }

    if ($item.ContainsKey('Version') -and $item['Version']) {
        $line += ",$($item['Version'])"
    }

    return $line
}

function SetDocsCiConfigProperties($item, $moniker, $packageSourceOverride) {
    # Order properties so that output is deterministic (more simple diffs)
    $properties = [ordered]@{}
    if ($item.ContainsKey('DocsCiConfigProperties')) {
        $properties = $item['DocsCiConfigProperties']
    }

    # Set tfm to netstandard2.0 if not already set
    if ('tfm' -notin $properties.Keys) {
        $properties['tfm'] = 'netstandard2.0'
    }

    # When in the preview moniker, always set isPrerelease to true
    if ($moniker -eq 'preview') {
        $properties['isPrerelease'] = 'true'
    }

    # Handle dev version overrides for daily docs
    if ($item['DevVersion'] -and $packageSourceOverride) {
        $properties['isPrerelease'] = 'true'
        $properties['customSource'] = $packageSourceOverride
    }

    $item['DocsCiConfigProperties'] = $properties

    return $item
}

function GetCiConfigPath($docRepoLocation, $moniker) {
    $csvPath = Join-Path $docRepoLocation "bundlepackages/azure-dotnet.csv"
    if ($moniker -eq 'preview') {
        $csvPath = Join-Path $docRepoLocation "bundlepackages/azure-dotnet-preview.csv"
    } elseif ($moniker -eq 'legacy') {
        $csvPath = Join-Path $docRepoLocation "bundlepackages/azure-dotnet-legacy.csv"
    }
    return $csvPath
}

function GetPackageId($packageName) { 
    return $packageName.Replace('.', '').ToLower()
}

# $SetDocsPackageOnboarding = "Set-${Language}-DocsPackageOnboarding"
function Set-dotnet-DocsPackageOnboarding($moniker, $metadata, $docRepoLocation, $packageSourceOverride) {
    $lines = @()
    foreach ($package in $metadata) {
        $package.Id = GetPackageId $package.Name
        $package = SetDocsCiConfigProperties $package $moniker $packageSourceOverride

        $line = Get-DocsCiLine2 $package
        $lines += $line
    }

    Set-Content -Path (GetCiConfigPath $docRepoLocation $moniker) -Value $lines
}

# $GetDocsPackagesAlreadyOnboarded = "Get-${Language}-DocsPackagesAlreadyOnboarded"
function Get-dotnet-DocsPackagesAlreadyOnboarded($docRepoLocation, $moniker) {
    $onboardedPackages = Get-DocsCiConfig (GetCiConfigPath $docRepoLocation $moniker)

    $onboardedPackageHash = @{}
    foreach ($package in $onboardedPackages) {
        $packageProperties = @{ 
            Name = $package.Name
        }

        if ($package.Versions -is [array]) {
            if ($package.Versions.Count -gt 1) { 
                throw "Too many versions supplied for package: $(package.Name) in moniker: $moniker"
            }

            if ($package.Versions.Count -eq 1) { 
                $packageProperties['Version'] = $package.Versions[0]
            } else {
                # Versions is an empty array, set to an empty string
                $packageProperties['Version'] = ''
            }
        }

        $onboardedPackageHash[$package.Name] = $packageProperties
    }
    return $onboardedPackageHash
}
