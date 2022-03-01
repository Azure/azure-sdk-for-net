Set-StrictMode -Version Latest

$RepoRoot = Resolve-Path $PSScriptRoot\..\..\..
$ObjDirectory = "$RepoRoot\artifacts\obj";
dotnet restore $RepoRoot\eng\service.proj

Push-Location $PSScriptRoot

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
            $projectPath = $assetsJson.project.restore.projectPath
            if (Test-Path $projectPath)
            {
                return $projectPath;
            }
        }
    }

    $len = $projects.Length
    dotnet sln $slnName add $projects[0..($len/2)]
    dotnet sln $slnName add $projects[($len/2 + 1)..($len-1)]
}
finally
{
    Pop-Location
}
