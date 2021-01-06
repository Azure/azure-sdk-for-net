param(
    [string]$ProjectFile = './SmokeTest.csproj',
    [switch]$SkipVersionValidation,
    [switch]$CI,
    [switch]$Daily
)

. $PSScriptRoot/../../../eng/common/scripts/SemVer.ps1

$PACKAGE_REFERENCE_XPATH = '//Project/ItemGroup/PackageReference'

# Matches the dev.yyyymmdd portion of the version string
$ALPHA_DATE_REGEX = 'alpha\.(\d{8})'

$baselineVersionDate = $null;

$PACKAGE_FEED_URL = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json'

function Log-Warning($message) {
    if ($CI) {
        Write-Host "##vso[task.logissue type=warning]$message"
    } else {
        Write-Warning $message
    }
}

function GetAllPackages {
    $packages = Find-Package -Source $PACKAGE_FEED_URL -AllVersion -AllowPrereleaseVersions
    if ($Daily) {
        return $packages | Where-Object { $_.Version.Contains("alpha") }
    }
    return $packages | Where-Object { !$_.Version.Contains("alpha") -and !$_.Version.Contains("dev") }
}

function GetLatestPackage([array]$packageList, [string]$packageName) {
    $versions = ($packageList
        | Where-Object { $_.Name -eq $packageName }
        | Select-Object -ExpandProperty Version)

    if (!$versions) {
        Write-Warning "Did not find any versions for $($packageName)"
        return
    }

    $sorted = [AzureEngSemanticVersion]::SortVersionStrings($versions)
    return $sorted | Select-Object -First 1
}

function SetLatestPackageVersions([xml]$csproj) {
    # For each PackageReference in the csproj, find the latest version of that
    # package from the dev feed which is not in the excluded list.
    $allPackages = GetAllPackages
    $csproj |
        Select-XML $PACKAGE_REFERENCE_XPATH |
        Where-Object { $_.Node.HasAttribute('Version') } |
        Where-Object { -not $_.Node.HasAttribute('DoNotUpdate') }
        ForEach-Object {
            # Resolve package version:
            $packageName = $_.Node.Include

            $targetVersion = GetLatestPackage $allPackages $packageName

            if ($null -eq $targetVersion) {
                return
            }

            Write-Host "Setting $packageName to $targetVersion"
            $_.Node.Version = "$targetVersion"


            # Validate package version date component matches
            if ($SkipVersionValidation) {
                return
            }

            if ($_.Node.Version -match $ALPHA_DATE_REGEX) {
                $capture = $matches[1]
                if ($null -eq $baselineVersionDate) {
                    Write-Host "Using baseline version date: $capture"
                    $baselineVersionDate = $capture
                }

                if ($baselineVersionDate -ne $matches[1]) {
                    Log-Warning "$($_.Node.Include) uses invalid version. Expected: $baselineVersionDate, Actual: $capture"
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
