$repoRoot = Resolve-Path (Join-Path $PSScriptRoot '..')
$tspClientDir = Resolve-Path (Join-Path $PSScriptRoot '../../../../common/tsp-client')

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

function Install-TspClient {
    Push-Location $tspClientDir
    try {
        if (!(Test-Path "node_modules")) {
            Write-Host "Installing tsp-client dependencies from $tspClientDir"
            npm ci
            if($LastExitCode -ne 0) {
                Write-Error "Failed to install tsp-client dependencies"
            }
        }
    }
    finally {
        Pop-Location
    }
}

function Get-Mgmt-TspCommand {
    param (
        [string]$specFile,
        [string]$generationDir,
        [bool]$generateStub = $false,
        [string]$apiVersion = $null,
        [bool]$debug = $false
    )
    Install-TspClient
    
    $command = "cd `"$tspClientDir`" && npx tsp compile `"$specFile`""
    $command += " --trace @azure-typespec/http-client-csharp-mgmt"
    $command += " --emit `"$repoRoot/..`""
    $configFile = Join-Path $generationDir "tspconfig.yaml"
    if (Test-Path $configFile) {
        $command += " --config=`"$configFile`""
    }
    $command += " --option @azure-typespec/http-client-csharp-mgmt.emitter-output-dir=`"$generationDir`""
    $command += " --option @azure-typespec/http-client-csharp-mgmt.save-inputs=true"
    if ($generateStub) {
        $command += " --option @azure-typespec/http-client-csharp-mgmt.plugin-name=AzureStubPlugin"
    }

    if ($apiVersion) {
        $command += " --option @azure-typespec/http-client-csharp-mgmt.api-version=$apiVersion"
    }

    $command += " --option @azure-typespec/http-client-csharp-mgmt.new-project=true"

    if ($debug) {
        $command += " --option @azure-typespec/http-client-csharp-mgmt.debug=true"
    }

    return $command
}

function Refresh-Mgmt-Build {
    Write-Host "Building emitter and generator" -ForegroundColor Cyan
    Invoke "npm run build:emitter" "$repoRoot/../../http-client-csharp-mgmt"
    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    # we don't want to build the entire solution because the test projects might not build until after regeneration
    Invoke "dotnet build $repoRoot/../../http-client-csharp-mgmt/generator/Azure.Generator.Management/src"
    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

function Compare-Paths {
    param (
        [string]$path1,
        [string]$path2
    )

    # Normalize the directory separators
    $normalizedPath1 = $path1 -replace '/', '\'
    $normalizedPath2 = $path2 -replace '/', '\'

    # Strip off http from the beginning of path2 if it exists
    if ($normalizedPath2.StartsWith("http\")) {
        $normalizedPath2 = $normalizedPath2.Substring(5)
    }

    # Compare the normalized paths
    return $normalizedPath1.Contains($normalizedPath2)
}

function Generate-Srv-Driven {
    param (
      [string]$specFilePath,
      [string]$outputDir,
      [bool]$generateStub = $false,
      [bool]$createOutputDirIfNotExist = $true
    )

    $v1Dir = $(Join-Path $outputDir "v1")
    if ($createOutputDirIfNotExist -and -not (Test-Path $v1Dir)) {
        New-Item -ItemType Directory -Path $v1Dir | Out-Null
    }

    $v2Dir = $(Join-Path $outputDir "v2")
    if ($createOutputDirIfNotExist -and -not (Test-Path $v2Dir)) {
        New-Item -ItemType Directory -Path $v2Dir | Out-Null
    }

    ## get the last two directories of the output directory and add V1/V2 to disambiguate the namespaces
    $namespaceRoot = $(($outputDir.Split([System.IO.Path]::DirectorySeparatorChar)[-2..-1] | `
        ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1) }) -replace '-(\p{L})', { $_.Groups[1].Value.ToUpper() } -replace '\W', '' -join ".")
    $v1SpecFilePath = $(Join-Path $specFilePath "old.tsp")
    $v2SpecFilePath = $(Join-Path $specFilePath "main.tsp")

    Invoke (Get-TspCommand $v1SpecFilePath $v1Dir -generateStub $generateStub)
    Invoke (Get-TspCommand $v2SpecFilePath $v2Dir -generateStub $generateStub)

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

function Generate-Versioning {
    param (
      [string]$specFilePath,
      [string]$outputDir,
      [bool]$generateStub = $false,
      [bool]$createOutputDirIfNotExist = $true
    )

    $v1Dir = $(Join-Path $outputDir "v1")
    if ($createOutputDirIfNotExist -and -not (Test-Path $v1Dir)) {
        New-Item -ItemType Directory -Path $v1Dir | Out-Null
    }

    $v2Dir = $(Join-Path $outputDir "v2")
    if ($createOutputDirIfNotExist -and -not (Test-Path $v2Dir)) {
        New-Item -ItemType Directory -Path $v2Dir | Out-Null
    }
    $outputFolders = $outputDir.Split([System.IO.Path]::DirectorySeparatorChar)
    ## get the last two directories of the output directory and add V1/V2 to disambiguate the namespaces
    $namespaceRoot = $(($outputFolders[-2..-1] | `
                           ForEach-Object { $_.Substring(0,1).ToUpper() + $_.Substring(1) }) -join ".")

    Invoke (Get-TspCommand $specFilePath $v1Dir -generateStub $generateStub -apiVersion "v1")
    Invoke (Get-TspCommand $specFilePath $v2Dir -generateStub $generateStub -apiVersion "v2")

    if ($outputFolders.Contains("removed")) {
        $v2PreviewDir = $(Join-Path $outputDir "v2Preview")
        if ($createOutputDirIfNotExist -and -not (Test-Path $v2PreviewDir)) {
            New-Item -ItemType Directory -Path $v2PreviewDir | Out-Null
        }
        Invoke (Get-TspCommand $specFilePath $v2PreviewDir -generateStub $generateStub -apiVersion "v2preview")
    }

    # exit if the generation failed
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}


Export-ModuleMember -Function "Invoke"
Export-ModuleMember -Function "Get-Mgmt-TspCommand"
Export-ModuleMember -Function "Refresh-Mgmt-Build"
Export-ModuleMember -Function "Compare-Paths"
Export-ModuleMember -Function "Generate-Srv-Driven"
Export-ModuleMember -Function "Generate-Versioning"
