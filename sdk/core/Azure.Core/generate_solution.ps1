$RepoRoot = Resolve-Path $PSScriptRoot\..\..\..
$ObjDirectory = "$RepoRoot\artifacts\obj";
dotnet restore $RepoRoot\eng\service.proj

$slnName = "Azure.Core.All.sln";

foreach ($projectName in Get-ChildItem -Directory $ObjDirectory)
{
    Write-Host "Processing $projectName\project.assets.json"
    $assets = Get-Content -Raw $projectName\project.assets.json;

    if (($projectName.Name.StartsWith("Azure.")) -or ($assets -Match "Azure.Core"))
    {
        $assetsJson = ConvertFrom-Json $assets;
        $projectPath = $assetsJson.project.restore.projectPath;
        dotnet sln $slnName add $projectPath
    }
}