$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')

function Invoke($command, $executePath=$repoRoot)
{
    Write-Host "> $command"
    Push-Location $executePath
    if ($IsLinux -or $IsMacOs)
    {
        sh -c "$command 2>&1"
    }
    else
    {
        cmd /c "$command 2>&1"
    }
    Pop-Location

    if($LastExitCode -ne 0)
    {
        Write-Error "Command failed to execute: $command"
    }
}

function Get-TspCommand {
    param (
        [string]$specFile,
        [string]$generationDir
    )
    $command = "npx tsp compile $specFile"
    $command += " --trace @azure-tools/csharp-plugin"
    $command += " --emit @azure-tools/csharp-plugin"
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $command += " --config=$configFile"
    }
    $command += " --option @azure-tools/csharp-plugin.emitter-output-dir=$generationDir"
    $command += " --option @azure-tools/csharp-plugin.save-inputs=true"
    return $command
}

function Refresh-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke "npm run build:emitter"
    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    # generating Azure.Generator.csproj is enough
    Invoke "dotnet build $repoRoot/../generator/Azure.Generator/src"
    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Get-TspCommand"
Export-ModuleMember -Function "Refresh-Build"
