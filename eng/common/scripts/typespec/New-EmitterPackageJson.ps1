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
$overrides = @{}

if ($OverridesPath) {
    Write-Host "Using overrides from $OverridesPath`:`n"
    $overrides = Get-Content $OverridesPath | ConvertFrom-Json -AsHashtable
    Write-Host ($overrides | ConvertTo-Json)
    Write-Host ""
}


# If there's a peer dependency and a dev dependency for the same package, carry the
# dev dependency forward into emitter-package.json

$devDependencies = @{}

foreach ($package in $packageJson.peerDependencies.Keys) {
    $pinnedVersion = $packageJson.devDependencies[$package]
    if ($pinnedVersion -and -not $overrides[$package]) {
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
