param (
    [Parameter()]
    [string] $ArtifactsDirectory,

    [Parameter()]
    [string] $Artifact,

    [Parameter()]
    [string] $RetryLimit = 30
)

mkdir InstallationCheck
cd "InstallationCheck"

Write-Host "dotnet new console --no-restore"
dotnet new console --no-restore

# Opt out of Central Package Management so that the dynamically added
# PackageReference with an explicit Version attribute is allowed.
'<Project></Project>' | Set-Content "Directory.Build.props"
'<Project></Project>' | Set-Content "Directory.Build.targets"

$localFeed = "$ArtifactsDirectory/$Artifact"

$version = (Get-Content "$ArtifactsDirectory/PackageInfo/$Artifact.json" | ConvertFrom-Json).Version

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
