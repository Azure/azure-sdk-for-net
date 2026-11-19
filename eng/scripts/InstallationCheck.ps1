param (
    [Parameter()]
    [string] $ArtifactsDirectory,

    [Parameter()]
    [string] $Artifact,

    [Parameter()]
    [string] $RetryLimit = 30
)

$localFeed = "$ArtifactsDirectory/$Artifact"
$version = (Get-Content "$ArtifactsDirectory/PackageInfo/$Artifact.json" -Raw -ErrorAction Stop | ConvertFrom-Json -ErrorAction Stop).Version
if ([string]::IsNullOrWhiteSpace($version)) {
    throw "Missing release version in PackageInfo/$Artifact.json."
}

# A remote feed can satisfy restore even when the signed artifact has the wrong version.
# Validate the actual package that publication will upload before consulting any feed.
$packages = @(Get-ChildItem -LiteralPath $localFeed -Filter "*.nupkg" -File -ErrorAction Stop |
    Where-Object Name -NotLike "*.symbols.nupkg")
if ($packages.Count -ne 1) {
    throw "Expected exactly one product nupkg in '$localFeed'; found $($packages.Count)."
}

$package = [IO.Compression.ZipFile]::OpenRead($packages[0].FullName)
try {
    $nuspecEntries = @($package.Entries | Where-Object { $_.FullName -eq $_.Name -and $_.Name -like "*.nuspec" })
    if ($nuspecEntries.Count -ne 1) {
        throw "Expected exactly one root nuspec in '$($packages[0].Name)'."
    }
    $reader = [IO.StreamReader]::new($nuspecEntries[0].Open())
    try {
        [xml]$nuspec = $reader.ReadToEnd()
    } finally {
        $reader.Dispose()
    }
} finally {
    $package.Dispose()
}

$packageId = $nuspec.package.metadata.id
$packageVersion = $nuspec.package.metadata.version
if ($packageId -ne $Artifact -or $packageVersion -ne $version) {
    throw "Signed package '$packageId' version '$packageVersion' does not match expected '$Artifact' version '$version'."
}
Write-Host "Validated signed package $packageId $packageVersion."

mkdir InstallationCheck
cd "InstallationCheck"

Write-Host "dotnet new console --no-restore"
dotnet new console --no-restore

# Opt out of Central Package Management so that the dynamically added
# PackageReference with an explicit Version attribute is allowed.
'<Project></Project>' | Set-Content "Directory.Build.props"
'<Project></Project>' | Set-Content "Directory.Build.targets"

Write-Host "dotnet add package $Artifact --version $version --no-restore"
dotnet add package $Artifact --version $version --no-restore
if ($LASTEXITCODE) {
  exit $LASTEXITCODE
}

$internalFeed = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json"

while ($retries++ -lt $RetryLimit) {
  Write-Host "dotnet restore -s $internalFeed -s $localFeed --no-cache --verbosity detailed"
  dotnet restore -s $internalFeed -s $localFeed --no-cache --verbosity detailed
  if ($LASTEXITCODE) {
    if ($retries -ge $RetryLimit) {
      exit $LASTEXITCODE
    }
    Write-Host "dotnet clean"
    dotnet clean
    Write-Host "Restore failed, retrying in 1 minute..."
    sleep 60
  } else {
    break
  }
}
