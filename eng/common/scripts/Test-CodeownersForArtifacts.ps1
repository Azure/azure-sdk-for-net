param(
    [string] $AzsdkPath,
    [string] $PackageInfoDirectory,
    [array] $SdkTypes,
    [string] $Repo
)

. "$PSScriptRoot/common.ps1"

$failedPackages = @()

foreach ($pkgPropertiesFile in Get-ChildItem -Path $PackageInfoDirectory -Filter '*.json' -File) {
    $pkgProperties = Get-Content -Raw -Path $pkgPropertiesFile | ConvertFrom-Json
    if ($SdkTypes -notcontains $pkgProperties.SdkType) {
        Write-Host "Skipping package: $($pkgProperties.Name) $($pkgProperties.DirectoryPath) because its SdkType '$($pkgProperties.SdkType)' is not in the list of SdkTypes to validate."
        continue
    }

    Write-Host "Validating codeowners for package: $($pkgProperties.Name) $($pkgProperties.DirectoryPath)"

    # Validate packages with a release date (intended to release)
    if ($pkgProperties.ReleaseStatus -ne "Unreleased") {
        $output = & $AzsdkPath config codeowners check-package `
            --directory-path $pkgProperties.DirectoryPath `
            --repo $Repo `
            --output json 2>&1

        if ($LASTEXITCODE) {
            LogError "Codeowners validation failed for package: $($pkgProperties.DirectoryPath)"
            $output | Write-Host
            $failedPackages += $pkgProperties.DirectoryPath
        } else {
            Write-Host "  Codeowners validation succeeded for package: $($pkgProperties.DirectoryPath)"
        }
    } else {
        Write-Host "  Skipping CODEOWNERS validation, package is not intended to release."
    }
}

if ($failedPackages.Count -gt 0) {
    Write-Host ""
    Write-Host "Failed Packages:"
    foreach ($directoryPath in $failedPackages) {
        LogError "  - $directoryPath does not have sufficient code owners coverage"
    }
    LogError "Codeowners validation failed for one or more packages. See http://aka.ms/azsdk/codeowners for instructions to fix the issue."
    exit 1
}
exit 0
