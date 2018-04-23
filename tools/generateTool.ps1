# ---------------------------------------------------------------------------------- 
    # Copyright (c) Microsoft Corporation. All rights reserved.
    # Licensed under the MIT License. See License.txt in the project root for
    # license information.
# ----------------------------------------------------------------------------------

<#

.SYNOPSIS
    Powershell script that generates the C# code for your sdk usin the config file provided

.DESCRIPTION
    This script:
    - fetches the config file from user/branch provided
    - Generates code based off the config file provided
    - into the directory path provided

.PARAMETER ResourceProvider
    The Resource provider for whom to generate the code; also helps determine path where config file is located in repo

.PARAMETER Version
    The AutoRest version to use to generate the code, "latest" is recommended

.PARAMETER SpecsRepoFork
    The Rest Spec repo fork which contains the config file

.PARAMETER SpecsRepoBranch
    The Branch which contains the config file

.PARAMETER SpecsRepoName
    The name of the repo that contains the config file (Can only be either of azure-rest-api-specs or azure-rest-api-specs-pr)

.PARAMETER SdkRootDirectory
    The root path in csharp-sdks-folder in config file where to generate the code

.PARAMETER SdkGenerationDirectory
    The path where to generate the code
    
#>
[CmdletBinding(DefaultParameterSetName="rootdir")]
Param(
    [Parameter(Mandatory = $true)]
    [string] $ResourceProvider,
    [Parameter(Mandatory = $false)]
    [string] $SpecsRepoFork = "Azure",
    [Parameter(Mandatory = $false)]
    [string] $SpecsRepoName = "azure-rest-api-specs",
    [Parameter(Mandatory = $false)]
    [string] $SpecsRepoBranch = "master",
    [Parameter(Mandatory = $false)]
    [string] $AutoRestVersion = "latest",
    [Parameter(Mandatory = $false)]
    [switch] $PowershellInvoker,
    [Parameter(ParameterSetName="rootdir", Mandatory=$false)]
    [string] $SdkRootDirectory,
    [Parameter(ParameterSetName="legacyrootdir", Mandatory=$false)]
    [string] $SdkDirectory,
    [Parameter(ParameterSetName="finaldir", Mandatory=$false)]
    [string] $SdkGenerationDirectory,
    [Parameter(Mandatory = $false)]
    [string] $Namespace,
    [Parameter(Mandatory = $false)]
    [string] $ConfigFileTag
)

$errorStream = New-Object -TypeName "System.Text.StringBuilder";
$outputStream = New-Object -TypeName "System.Text.StringBuilder";
$currPath = split-path $SCRIPT:MyInvocation.MyCommand.Path -parent
$modulePath = "$currPath\SdkBuildTools\psModules\CodeGenerationModules\generateDotNetSdkCode.psm1"
$logFile = "$currPath\..\src\SDKs\_metadata\$($ResourceProvider.Replace("/","_")).txt"

function NotifyError {
    param (
        [string] $errorMsg
    )
    Write-Error $errorMsg
    $errorFilePath = "$currPath\SdkBuildTools"
    If(!(test-path $errorFilePath))
    {
        New-Item -ItemType Directory -Force -Path $errorFilePath
    }
    $errorMsg | Out-File -FilePath "$errorFilePath\errorLog.txt"
    Start-Process "$errorFilePath\errorLog.txt"
}

if([string]::IsNullOrWhiteSpace($SdkDirectory)) {
    $SdkDirectory = "$currPath\..\src\SDKs\"
}

if ($SpecsRepoName.EndsWith("-pr")) {
    NotifyError "AutoRest cannot generate sdk from a spec in private repos."
}

if (-not ($modulePath | Test-Path)) {
    NotifyError "Could not find code generation module at: $modulePath. Please run `msbuild build.proj` to install the module."
    Exit -1
}

if([string]::IsNullOrWhiteSpace($SdkRootDirectory)) {
    $SdkRootDirectory = $SdkDirectory
}

Import-Module "$modulePath"

if (-not (Get-Module -ListAvailable -Name "$modulePath")) {
    NotifyError "Could not find module: $modulePath. Please run `msbuild build.proj` to install the module."
    Exit -1
}

function Start-Script {
    Write-InfoLog "Importing code generation module" -logToConsole

    Install-AutoRest $AutoRestVersion

    $configFile="https://github.com/$SpecsRepoFork/$SpecsRepoName/blob/$SpecsRepoBranch/specification/$ResourceProvider/readme.md"
    Write-InfoLog "Commencing code generation"  -logToConsole
    
    if(-not [string]::IsNullOrWhiteSpace($SdkRootDirectory)) {
        Start-CodeGeneration -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch -SdkRootDirectory $SdkRootDirectory -AutoRestVersion $AutoRestVersion -SpecsRepoName $SpecsRepoName -Namespace $Namespace -ConfigFileTag $ConfigFileTag
    }
    elseif(-not [string]::IsNullOrWhiteSpace($SdkGenerationDirectory)) {
        Start-CodeGeneration -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch -SdkGenerationDirectory $SdkGenerationDirectory -AutoRestVersion $AutoRestVersion -SpecsRepoName $SpecsRepoName -Namespace $Namespace -ConfigFileTag $ConfigFileTag
    }
    else {
        Write-ErrorLog "Could not find an output directory to generate code, aborting."
    }
    
    $invokerMessage = ".\tools\generate.ps1 was invoked by"
    if($PowershellInvoker) {
        Write-InfoLog "$invokerMessage generate.ps1" -logToFile
    }
    else {
        Write-InfoLog "$invokerMessage generate.cmd" -logToFile
    }
}

try {
    Start-Script
}
catch {
    Write-ErrorLog $_.ToString() -logToConsole
    Write-ErrorLog $_.ToString() -logToFile
}
finally {
    Get-OutputStream | Out-File -FilePath $logFile -Encoding utf8 | Out-Null
    Get-ErrorStream | Out-File -FilePath $logFile -Append -Encoding utf8 | Out-Null
    Clear-OutputStreams
    Get-Module -ListAvailable "$modulePath" | Remove-Module
}