param(
    [string]$ProjectFile = './SmokeTest.csproj',
    [switch]$SkipVersionValidation,
    [switch]$CI
)

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

$NIGHTLY_FEED_NAME = 'NightlyFeed'
$NIGHTLY_FEED_URL = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json'

function Log-Warning($message) {
    if ($CI) {
        Write-Host "##vso[task.logissue type=warning]$message"
    } else {
        Write-Warning $message
    }
}
Unregister-PackageSource -Name $NIGHTLY_FEED_NAME -ErrorAction SilentlyContinue;
Register-PackageSource `
    -Name $NIGHTLY_FEED_NAME `
    -Location $NIGHTLY_FEED_URL `
    -ProviderName Nuget `
    -ErrorAction SilentlyContinue `

$baselineVersionDate = $null;

# For each PackageReferecne in the csproj, find the latest version of that
# package from the dev feed which is not in the excluded list.
$projectFilePath = Resolve-Path -Path $ProjectFile
[xml]$csproj = Get-Content $ProjectFile
$csproj |
    Select-XML $PACKAGE_REFERENCE_XPATH |
    Where-Object { $_.Node.HasAttribute('Version') } |
    ForEach-Object {
        # Resolve package version:
        $packageName = $_.Node.Include
        
        $allVersions = Find-Package -Source $NIGHTLY_FEED_NAME -AllVersion -AllowPrereleaseVersions -Name $packageName -ErrorAction SilentlyContinue
        
        if (!$allVersions)
        {
            if ($packageName.StartsWith("Azure."))
            {
                throw "Unable to find a package version for $packageName" 
            }
            else
            {
                Write-Host "$packageName package not found on the nightly feed"
                return;
            }
        }

        # Find the latest published package by date to avoid version ordering conflicts with old *-dev.* packages
        # This excludes any version that is in the corresponding $PACKAGE_EXCLUSIONS entry
        $targetVersion = ($allVersions |
            Where-Object { $_.Source -eq $NIGHTLY_FEED_NAME } |
            Where-Object { -not ( $PACKAGE_EXCLUSIONS.ContainsKey($packageName) -and $PACKAGE_EXCLUSIONS[$packageName].ContainsKey($_.Version)) } |
            Sort-Object -Property @{expression={if ($_.Metadata) { $_.Metadata["published"] }}} |
            Select-Object -First 1).Version

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

$csproj.Save($projectFilePath)
