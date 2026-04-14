param(
    $ArtifactPath,
    $AzsdkPath,
    $Repo
)

. "$PSScriptRoot/common.ps1"

$succeeded = $true

foreach ($pkgPropertiesFile in Get-ChildItem -Path $ArtifactPath -File) {
    $pkgProperties = Get-Content -Path $pkgPropertiesFile | ConvertFrom-Json
    Write-Host "Validating codeowners for package: $($pkgProperties.Name) $($pkgProperties.DirectoryPath)"

    # Validate packages with a release date (intended to release)
    if ($pkgProperties.ReleaseStatus -ne "Unreleased") {
        $output = & $AzsdkPath config codeowners check-package `
            --directory-path $pkgProperties.DirectoryPath `
            --repo $Repo `
            --output json

        if ($LASTEXITCODE) {
            Write-Host $output
            Write-Host "  Codeowners validation failed for package: $($pkgProperties.DirectoryPath)"
            $succeeded = $false
        } else {
            Write-Host "  Codeowners validation succeeded for package: $($pkgProperties.DirectoryPath)"
        }
    } else {
        Write-Host "  Skipping CODEOWNERS validation, package is not intended to release."
    }
}

if (!$succeeded) {
    LogError "Codeowners validation failed for one or more packages."
    exit 1
}
exit 0
