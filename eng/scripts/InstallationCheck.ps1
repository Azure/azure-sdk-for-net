param (
    [Parameter()]
    [string] $ArtifactsDirectory,

    [Parameter()]
    [string] $Artifact,

    [Parameter()]
    [string] $PipelineWorkspace
)

Write-Host "dotnet new console"
dotnet new console
$localFeed = "$PipelineWorkspace/$ArtifactsDirectory-signed/$Artifact"
Write-Host "dotnet nuget add source $localFeed"
dotnet nuget add source $localFeed

$version = (Get-ChildItem "$localFeed/*.nupkg" -Exclude "*.symbols.nupkg" -Name).replace(".nupkg","").replace("$Artifact.","")
Write-Host "dotnet add package $Artifact --version $version --no-restore"
dotnet add package $Artifact --version $version --no-restore
if ($LASTEXITCODE) {
    exit $LASTEXITCODE
}

Write-Host "dotnet nuget locals all --clear"
dotnet nuget locals all --clear

Write-Host "dotnet restore -s https://api.nuget.org/v3/index.json -s $localFeed --no-cache --verbosity detailed"
dotnet restore -s https://api.nuget.org/v3/index.json -s $localFeed --no-cache --verbosity detailed
if ($LASTEXITCODE) {
    exit $LASTEXITCODE
}