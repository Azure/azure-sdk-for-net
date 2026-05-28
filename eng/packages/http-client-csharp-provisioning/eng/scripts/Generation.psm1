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

function Get-Provisioning-TspCommand {
    param (
        [string]$specFile,
        [string]$generationDir,
        [bool]$generateStub = $false,
        [string]$apiVersion = $null,
        [bool]$debug = $false
    )
    $command = "npx tsp compile $specFile"
    $command += " --trace @azure-typespec/http-client-csharp-provisioning"
    $command += " --emit $repoRoot/.."
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $command += " --config=$configFile"
    }
    $command += " --option @azure-typespec/http-client-csharp-provisioning.emitter-output-dir=$generationDir"
    $command += " --option @azure-typespec/http-client-csharp-provisioning.save-inputs=true"
    if ($generateStub) {
        $command += " --option @azure-typespec/http-client-csharp-provisioning.plugin-name=AzureStubPlugin"
    }

    if ($apiVersion) {
        $command += " --option @azure-typespec/http-client-csharp-provisioning.api-version=$apiVersion"
    }

    $command += " --option @azure-typespec/http-client-csharp-provisioning.new-project=true"

    if ($debug) {
        $command += " --option @azure-typespec/http-client-csharp-provisioning.debug=true"
    }

    return $command
}

function Refresh-Provisioning-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke "npm run build:emitter" "$repoRoot/../../http-client-csharp-provisioning"
    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    Invoke "dotnet build $repoRoot/../../http-client-csharp-provisioning/generator/Azure.Generator.Provisioning/src"
    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Get-Provisioning-TspCommand"
Export-ModuleMember -Function "Refresh-Provisioning-Build"
