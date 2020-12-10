param(
    [string]$ProjectFile = './SmokeTest.csproj',
    [switch]$SkipVersionValidation,
    [switch]$CI,
    [switch]$Nightly
)

. $PSScriptRoot/../../../eng/common/scripts/SemVer.ps1

# To exclude a package version create an entry whose key is the package to
# exclude whose value is a hash table of versions to exclude.
# Example:
# $PACKAGE_EXCLUSIONS = @{
#     'Azure.Security.Keyvault.Secrets' = @{
#         '4.1.0-dev.20191102.1' = $true;
#         '4.1.0-dev.20191103.1' = $true;
#     }
# }
$PACKAGE_EXCLUSIONS = @{ }

$PACKAGE_REFERENCE_XPATH = '//Project/ItemGroup/PackageReference'

# Matches the dev.yyyymmdd portion of the version string
$DEV_DATE_REGEX = 'dev\.(\d{8})'

$baselineVersionDate = $null;

$RELEASE_FEED_URL = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json'
$NIGHTLY_FEED_NAME = 'NightlyFeed'
$NIGHTLY_FEED_URL = 'https://azuresdkartifacts.blob.core.windows.net/azure-sdk-for-net/index.json'

function Log-Warning($message) {
    if ($CI) {
        Write-Host "##vso[task.logissue type=warning]$message"
    } else {
        Write-Warning $message
    }
}

function GetAllNightlyPackages {
    Register-PackageSource `
        -Name $NIGHTLY_FEED_NAME `
        -Location $NIGHTLY_FEED_URL `
        -ProviderName Nuget `
        -ErrorAction SilentlyContinue `

    # List all packages from the source specified by $FeedName. Packages are sorted
    # ascending by version according to semver rules (e.g. 4.0.0-preview.1 comes
    # before 4.0.0) not lexicographically.
    # Packages cannot be filtered at this stage because the sleet feed to which they
    # are published does not support filtering by name.
    return Find-Package -Source $NIGHTLY_FEED_NAME -AllVersion -AllowPrereleaseVersions
}

function GetAllPackages {
    if ($Nightly) {
        return GetAllNightlyPackages
    }
    return Find-Package -Source $RELEASE_FEED_URL -AllVersion -AllowPrereleaseVersions
}

function GetLatestPackage([array]$packageList, [string]$packageName) {
    # This assumes that the versions coming back from Find-Package are
    # sorted ascending. It excludes any version that is in the corresponding
    # $PACKAGE_EXCLUSIONS entry
    $versions = ($packageList `
        | Where-Object { $_.Name -eq $packageName }
        | Where-Object { `
            -not ( $PACKAGE_EXCLUSIONS.ContainsKey($packageName) `
            -and $PACKAGE_EXCLUSIONS[$packageName].ContainsKey($_.Version)) `
        }
        | Select-Object -ExpandProperty Version)

    if (!$versions) {
        Write-Warning "Did not find any versions for $($packageName)"
        return
    }

    $sorted = [AzureEngSemanticVersion]::SortVersionStrings($versions)
    return $sorted | Select-Object -First 1
}

function SetLatestPackageVersions([object]$csproj) {
    # For each PackageReference in the csproj, find the latest version of that
    # package from the dev feed which is not in the excluded list.
    $allPackages = GetAllPackages
    $csproj |
        Select-XML $PACKAGE_REFERENCE_XPATH |
        Where-Object { $_.Node.HasAttribute('Version') } |
        ForEach-Object {
            # Resolve package version:
            $packageName = $_.Node.Include

            $targetVersion = GetLatestPackage $allPackages $packageName

            if ($targetVersion -eq $null) {
                return
            }

            Write-Host "Setting $packageName to $targetVersion"
            $_.Node.Version = "$targetVersion"


            # Validate package version date component matches
            if ($SkipVersionValidation) {
                return
            }

            if ($_.Node.Version -match $DEV_DATE_REGEX) {
                if ($baselineVersionDate -eq $null) {
                    Write-Host "Using baseline version date: $($matches[1])"
                    $baselineVersionDate = $matches[1]
                }

                if ($baselineVersionDate -ne $matches[1]) {
                    Log-Warning "$($_.Node.Include) uses invalid version. Expected: $baselineVersionDate, Actual: $($matches[1])"
                }
            }
        }
}

function UpdateCsprojVersions {
    $projectFilePath = Resolve-Path -Path $ProjectFile
    [xml]$csproj = Get-Content $projectFilePath
    SetLatestPackageVersions $csproj
    $csproj.Save($projectFilePath)
}

UpdateCsprojVersions
