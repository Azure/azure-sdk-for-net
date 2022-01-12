Set-StrictMode -Version Latest

$RepoRoot = Resolve-Path $PSScriptRoot\..\..\..
$ObjDirectory = "$RepoRoot\artifacts\obj";
dotnet restore $RepoRoot\eng\service.proj

Push-Location $PSScriptRoot

$diff = git diff --name-only upstream/main -- $RepoRoot/sdk/core/Azure.Core/src/Shared/

Write-Host "Building solution for projects referencing shared source:"
Write-Host $diff

$sharedFiles = $diff -split "\n"
For ($i=0; $i -lt $sharedFiles.Length; $i++) {
    $sharedFiles[$i] = Split-Path $sharedFiles[$i] -Leaf
}


$sharedFilesPattern =  Join-String -Separator "|" -InputObject $sharedFiles
$sharedFilesPattern = ("'" + $sharedFilesPattern + "'")

try
{
    $slnName = "Azure.Core.SharedRef.All.sln";
    if (!(Test-Path $slnName))
    {
        dotnet new sln -n "Azure.Core.SharedRef.All"
    }
    $dirs = Get-ChildItem -Directory $ObjDirectory
    $projects = $dirs | %{ 
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
            if ((Test-Path $projectPath) -and (Select-String -Path $projectPath -Pattern $sharedFilesPattern -Quiet))
            {
                return $projectPath;
            }
        }
    }

    # Do another pass to get all projects that reference the ones discovered in the first pass. This will typically be test projects.
    Write-Host "Checking for additional projects that reference shared source"
    $foundProjectsPattern = Join-String -Separator "|" -InputObject $projects
    $foundProjectsPattern = $foundProjectsPattern.Replace("\", "\\\\").Replace(".", "\.")

    $projectsIncludingRefs = $dirs | %{ 
        $assetsFile = "$_\project.assets.json"
        Write-Host -NoNewline "."

        if (!(Test-Path $assetsFile))
        {
            return;
        }

        $assets = Get-Content -Raw $assetsFile;
        $assetsJson = ConvertFrom-Json $assets;
        $projectPath = $assetsJson.project.restore.projectPath
        if (($projects -contains $projectPath) -or (Select-String -Path $assetsFile -Pattern $foundProjectsPattern -Quiet))
        {
            return $projectPath;
        }
    }

    $len = $projectsIncludingRefs.Length
    if ($len -gt 20)
    {
        dotnet sln $slnName add $projectsIncludingRefs[0..($len/2)]
        dotnet sln $slnName add $projectsIncludingRefs[($len/2 + 1)..($len-1)]
    } else
    {
        dotnet sln $slnName add $projectsIncludingRefs
    }
}
catch{
    Write-Host $_
}
finally
{
    Pop-Location
}
