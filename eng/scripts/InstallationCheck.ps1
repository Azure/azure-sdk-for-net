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
$localFeed = "$ArtifactsDirectory/$Artifact"

$version = (Get-Content "$ArtifactsDirectory/PackageInfo/$Artifact.json" | ConvertFrom-Json).Version

Write-Host "dotnet add package $Artifact --version $version --no-restore"
dotnet add package $Artifact --version $version --no-restore
if ($LASTEXITCODE) {
  exit $LASTEXITCODE
}

while ($retries++ -lt $RetryLimit) {
  Write-Host "dotnet restore -s https://api.nuget.org/v3/index.json -s $localFeed --no-cache --verbosity detailed"
  dotnet restore -s https://api.nuget.org/v3/index.json -s $localFeed --no-cache --verbosity detailed
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
