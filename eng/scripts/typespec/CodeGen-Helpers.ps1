#Requires -Version 7.0

function Get-NpmDependencyVersion([string]$PackageJsonPath, [string]$PackageName, [switch]$DependenciesOnly) {
    $json = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json -AsHashtable
    $dependencies = $json["dependencies"]
    $peerDependencies = $json["peerDependencies"]
    $version = if ($dependencies) { $dependencies[$PackageName] }
    if (-not $version -and -not $DependenciesOnly -and $peerDependencies) {
        $version = $peerDependencies[$PackageName]
    }
    return $version
}

function Get-PackageJsonVersion([string]$PackageJsonPath) {
    $json = Get-Content $PackageJsonPath -Raw | ConvertFrom-Json
    return $json.version
}

function Assert-VersionNotNewerThanApproved(
    [string]$Name,
    [string]$Version,
    [string]$ApprovedVersion,
    [string]$ApprovedVersionPath
) {
    try {
        $current = [System.Management.Automation.SemanticVersion]::new($Version)
        $approved = [System.Management.Automation.SemanticVersion]::new($ApprovedVersion)
    }
    catch {
        throw "Unable to compare $Name version '$Version' with approved version '$ApprovedVersion': $($_.Exception.Message)"
    }

    if ($current.CompareTo($approved) -gt 0) {
        throw "$Name version '$Version' is newer than the approved version '$ApprovedVersion' in '$ApprovedVersionPath'. Wait for the approved emitter package descriptor to be updated before advancing this dependency."
    }
}

function Assert-EmitterDependencies(
    [string]$RepoRoot,
    [ValidateSet("eng/packages/http-client-csharp", "eng/packages/http-client-csharp-mgmt")]
    [string]$EmitterPackagePath
) {
    $ErrorActionPreference = "Stop"
    $descriptors = @{
        "@typespec/http-client-csharp" = "eng/http-client-csharp-emitter-package.json"
        "@azure-typespec/http-client-csharp" = "eng/azure-typespec-http-client-csharp-emitter-package.json"
    }
    $dependencies = @("@typespec/http-client-csharp")
    if ($EmitterPackagePath -eq "eng/packages/http-client-csharp-mgmt") {
        $dependencies += "@azure-typespec/http-client-csharp"
    }

    $directory = Join-Path $RepoRoot $EmitterPackagePath
    $manifest = Get-Content (Join-Path $directory "package.json") -Raw | ConvertFrom-Json -AsHashtable
    $lock = Get-Content (Join-Path $directory "package-lock.json") -Raw | ConvertFrom-Json -AsHashtable
    if ($lock.lockfileVersion -notin @(2, 3) -or -not $lock.packages) {
        throw "$EmitterPackagePath/package-lock.json must contain npm lockfileVersion 2 or 3 package resolutions."
    }
    foreach ($dependency in $dependencies) {
        $referenced = if ($manifest.dependencies) { $manifest.dependencies[$dependency] } else { "" }
        $name = "$($manifest.name) ($EmitterPackagePath) dependency '$dependency'"
        $descriptorPath = Join-Path $RepoRoot $descriptors[$dependency]
        $approved = Get-NpmDependencyVersion $descriptorPath $dependency -DependenciesOnly
        Assert-VersionNotNewerThanApproved "$name referenced" $referenced $approved $descriptorPath

        $lockRoot = $lock.packages['']
        $lockReference = if ($lockRoot.dependencies) { $lockRoot.dependencies[$dependency] } else { "" }
        if ($lockReference -cne $referenced) {
            throw "${name}: package-lock.json root reference '$lockReference' does not match manifest version '$referenced'. Run npm install --package-lock-only in '$directory' and commit both files."
        }
        $direct = $lock.packages["node_modules/$dependency"]
        if (-not $direct -or $direct.version -cne $referenced) {
            throw "${name}: direct package-lock.json resolved version '$($direct.version)' does not match manifest version '$referenced'. Run npm install --package-lock-only in '$directory' and commit both files."
        }
        $resolutionPattern = '(^|/)node_modules/' + [regex]::Escape($dependency) + '$'
        foreach ($entry in $lock.packages.GetEnumerator() | Where-Object { $_.Key -cmatch $resolutionPattern }) {
            Assert-VersionNotNewerThanApproved `
                "$name referenced version '$referenced', resolved at '$($entry.Key)'" `
                $entry.Value.version $approved $descriptorPath
        }
        Write-Host "$name manifest and lockfile versions do not exceed approved version '$approved'."
    }
}
