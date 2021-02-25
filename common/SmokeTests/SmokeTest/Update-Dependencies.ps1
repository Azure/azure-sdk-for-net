param(
    [string]$ProjectFile = './SmokeTest.csproj',
    [string]$ArtifactsPath,
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

function GetPackageVersion([array]$packageList, [string]$packageName) {
    if ($Daily -or -not $ArtifactsPath) {
        return GetLatestPackage $packageList $packageName
    }

    if (-not (Test-Path (Join-Path $ArtifactsPath $packageName))) {
      Write-Host "No build artifact directory for smoke test dependency $packageName. Using latest upstream version."
      return GetLatestPackage $packageList $packageName
    }

    $pkg = Get-ChildItem "$ArtifactsPath/$packageName/*.nupkg" | Select-Object -First 1
    if ($pkg -match "$packageName\.(.*)\.nupkg") {
        $version = $matches[1]
        Write-Host "Found build artifact for $packageName with version $version. Using artifact version."
        return $version
    } else {
      throw "No build artifact packages found for smoke test dependency '$packageName'."
    }
}

function SetLatestPackageVersions([xml]$csproj) {
    # For each PackageReference in the csproj, find the latest version of that
    # package from the dev feed which is not in the excluded list.
    $allPackages = GetAllPackages
    $csproj |
        Select-XML $PACKAGE_REFERENCE_XPATH
        | Where-Object { $_.Node.HasAttribute('Version') }
        | Where-Object { -not ($Daily -and $_.Node.HasAttribute('OverrideDailyVersion')) }
        | ForEach-Object {
            # Resolve package version:
            $packageName = $_.Node.Include

            $targetVersion = GetPackageVersion $allPackages $packageName

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
