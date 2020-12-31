Set-StrictMode -Version Latest

$RepoRoot = Resolve-Path $PSScriptRoot\..\..\..
$ObjDirectory = "$RepoRoot\artifacts\obj";
dotnet restore $RepoRoot\eng\service.proj

pushd $PSScriptRoot

try
{
    $slnName = "Azure.Core.All.sln";
    if (!(Test-Path $slnName))
    {
        dotnet new sln -n "Azure.Core.All"
    }
    $projects = Get-ChildItem -Directory $ObjDirectory | %{ 
        $assetsFile = "$_\project.assets.json"

        if (!(Test-Path $assetsFile))
        {
            return;
        }

        Write-Host "Processing $assetsFile"
        $assets = Get-Content -Raw $assetsFile;

        if (($_.Name.StartsWith("Azure.")) -or ($assets -Match "Azure.Core"))
        {
            $assetsJson = ConvertFrom-Json $assets;
            return $assetsJson.project.restore.projectPath;
        }
    }

    dotnet sln $slnName add $projects
}
finally
{
    popd
}