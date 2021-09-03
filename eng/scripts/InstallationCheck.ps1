param (
    [Parameter()]
    [string] $ArtifactsDirectory,

    [Parameter()]
    [string] $Artifact,

    [Parameter()]
    [string] $PipelineWorkspace
)

mkdir InstallationCheck
cd "InstallationCheck"

Write-Host "dotnet new console --no-restore"
dotnet new console --no-restore
$localFeed = "$PipelineWorkspace/$ArtifactsDirectory-signed/$Artifact"

$version = (Get-Content "$PipelineWorkspace/$ArtifactsDirectory-signed/PackageInfo/$Artifact.json" | ConvertFrom-Json).Version

Write-Host "dotnet add package $Artifact --version $version --no-restore"
dotnet add package $Artifact --version $version --no-restore
if ($LASTEXITCODE) {
  exit $LASTEXITCODE
}

while ($retries++ -lt 30) {
  Write-Host "dotnet restore -s https://api.nuget.org/v3/index.json -s $localFeed --no-cache --verbosity detailed"
  dotnet restore -s https://api.nuget.org/v3/index.json -s $localFeed --no-cache --verbosity detailed
  if ($LASTEXITCODE) {
    if ($retries -ge 30) {
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
