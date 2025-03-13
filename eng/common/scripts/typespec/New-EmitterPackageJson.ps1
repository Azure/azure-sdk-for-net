#Requires -Version 7.0
[CmdletBinding()]
param (
    [parameter(Mandatory = $true)]
    [ValidateScript({ Test-Path $_ })]
    [string]$PackageJsonPath,

    [parameter(Mandatory = $false)]
    [ValidateScript({ Test-Path $_ })]
    [string]$OverridesPath,

    [parameter(Mandatory = $true)]
    [string]$OutputDirectory,

    [parameter(Mandatory = $false)]
    [string]$PackageJsonFileName = "emitter-package.json"
)

$packageJson = Get-Content $PackageJsonPath | ConvertFrom-Json -AsHashtable

# If we provide OverridesPath, use that to load a hashtable of version overrides
$overrides = [ordered]@{}

if ($OverridesPath) {
    Write-Host "Using overrides from $OverridesPath`:`n"
    $overridesJson = Get-Content $OverridesPath | ConvertFrom-Json -AsHashtable
    foreach ($key in $overridesJson.Keys | Sort-Object) {
        $overrides[$key] = $overridesJson[$key]
    }
    Write-Host ($overrides | ConvertTo-Json)
    Write-Host ""
}

# If there's a peer dependency and a dev dependency for the same package, carry the
# dev dependency forward into emitter-package.json

$devDependencies = [ordered]@{}

$possiblyPinnedPackages = $packageJson['azure-sdk/emitter-package-json-pinning'] ?? $packageJson.peerDependencies.Keys;

foreach ($package in $possiblyPinnedPackages | Sort-Object) {
    $pinnedVersion = $packageJson.devDependencies[$package]
    if ($pinnedVersion -and -not $overrides[$package]) {
        #We have a dev pinned version that isn't overridden by the overrides.json file
        Write-Host "Pinning $package to $pinnedVersion"
        $devDependencies[$package] = $pinnedVersion
    }
}

$emitterPackageJson = [ordered]@{
  "main" = "dist/src/index.js"
  "dependencies" = @{
      $packageJson.name = $overrides[$packageJson.name] ?? $packageJson.version
  }
}

# you shouldn't specify the same package in both dependencies and overrides
$overrides.Remove($packageJson.name)

# Avoid adding an empty devDependencies section
if($devDependencies.Keys.Count -gt 0) {
  $emitterPackageJson["devDependencies"] = $devDependencies
}

# Avoid adding an empty overrides section
if($overrides.Keys.Count -gt 0) {
    $emitterPackageJson["overrides"] = $overrides
}

New-Item $OutputDirectory -ItemType Directory -ErrorAction SilentlyContinue | Out-Null
$OutputDirectory = Resolve-Path $OutputDirectory

$dest = Join-Path $OutputDirectory $PackageJsonFileName
$destJson = $emitterPackageJson | ConvertTo-Json -Depth 100

Write-Host "Generating $dest"
$destJson | Out-File $dest

Write-Host $destJson
