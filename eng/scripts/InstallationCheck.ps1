param (
    [Parameter()]
    [string] $ArtifactsDirectory,

    [Parameter()]
    [string] $Artifact,

    [Parameter()]
    [string] $PipelineWorkspace
)

Write-Host "dotnet new console --no-restore"
dotnet new console --no-restore
$localFeed = "$PipelineWorkspace/$ArtifactsDirectory-signed/$Artifact"

$version = "1.0.3-beta.20201120"#(Get-Content "$PipelineWorkspace/$ArtifactsDirectory-signed/PackageInfo/$Artifact.json" | ConvertFrom-Json).Version

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
    if ($retries -ge 5) {#
      Write-Host "dotnet remove package $Artifact"#
      dotnet remove package $Artifact#
      $version = $version.replace(".error","")
      Write-Host "dotnet add package $Artifact --version $version --no-restore"
      dotnet add package $Artifact --version $version --no-restore
    }#
    Write-Host "dotnet nuget locals all --clear"
    dotnet nuget locals all --clear
    Write-Host "Restore failed, retrying in 1 minute..."
    sleep 60
  } else {
    break
  }
}
