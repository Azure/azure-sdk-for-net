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

.PARAMETER SdkFolder
    The path where to generate the code

.EXAMPLE
    A sample command that uses the function or script, optionally followed
    by sample output and a description. Repeat this keyword for each example.

.NOTES
    Additional information about the function or script.

.LINK
    The name of a related topic. Repeat this keyword for each related topic.

    This content appears in the Related Links section of the Help topic.

    The Link keyword content can also include a Uniform Resource Identifier
    (URI) to an online version of the same Help topic. The online version
    opens when you use the Online parameter of Get-Help. The URI must begin
    with "http" or "https".
#>

Param(
    [Parameter(Mandatory = $true)]
    [string] $ResourceProvider = "compute/resource-manager",
    [string] $SpecsRepoFork = "Azure",
    [string] $SpecsRepoName = "azure-rest-api-specs",
    [string] $SpecsRepoBranch = "master",
    [string] $SdkDirectory,
    [string] $AutoRestVersion = "latest",
    [switch] $PowershellInvoker
)

$errorStream = New-Object -TypeName "System.Text.StringBuilder";
$outputStream = New-Object -TypeName "System.Text.StringBuilder";
$currPath = split-path $SCRIPT:MyInvocation.MyCommand.Path -parent
if([string]::IsNullOrEmpty($SdkDirectory))
{
    $SdkDirectory = "$currPath\..\src\SDKs\"
}
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

if (-not ($modulePath | Test-Path)) {
    NotifyError "Could not find code generation module at: $modulePath. Please run `msbuild build.proj` to install the module."
    Exit -1
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
    Start-CodeGeneration -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch -SdkDirectory $SdkDirectory -AutoRestVersion $AutoRestVersion -SpecsRepoName $SpecsRepoName
    
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
    Get-OutputStream | Out-File -FilePath $logFile | Out-Null
    Get-ErrorStream | Out-File -FilePath $logFile -Append | Out-Null
    Clear-OutputStreams
    Get-Module -ListAvailable "$modulePath" | Remove-Module 
}