# ---------------------------------------------------------------------------------- 
    # Copyright (c) Microsoft Corporation. All rights reserved.
    # Licensed under the MIT License. See License.txt in the project root for
    # license information.
# ---------------------------------------------------------------------------------- 

<#

.SYNOPSIS
    Powershell script that creates a new powershell script that will generate the sdk code

.DESCRIPTION
    A helper utility script that creates a powershell script that can generate sdk for given RP into a path specified in the config file

.PARAMETER ResourceProvider
    The resource provider for which to create the code generation script. Eg. compute/resource-manager

.PARAMETER ScriptPath
    If path for the sdk directory has not been properly set up in the config file, use this param to set it explicitly. It is recommended to set the --csharp-sdks-folder in the config file, this is a worst case backdoor. Eg: $PSScript\Generated
#>

[cmdletbinding(SupportsShouldProcess=$True)]
Param(
    [Parameter(Mandatory = $true, HelpMessage="The resource provider for which to create the code generation script. Eg. compute/resource-manager")]
    [string] $ResourceProvider,
    [Parameter(Mandatory = $true, HelpMessage="Directory path where the script should get generated. It should usually be right next to csproj for the sdk project. Eg: <some_path>\src\SDKs\Compute\Management.Compute\")]
    [string] $ScriptPath,
    [Parameter(Mandatory = $false, HelpMessage="If path for the sdk directory has not been properly set up in the config file, use this param to set it explicitly. It is recommended to set the --csharp-sdks-folder in the config file, this is a worst case backdoor. Eg: $PSScript\Generated")]
    [string] $SdkGenerationDirectory
)

$ScriptPath = $(Resolve-Path -Path $ScriptPath)
if(!$(Test-Path -Path $ScriptPath))
{
    Write-Error "Path $ScriptPath does not exist, please provide a valid path"
    Exit
}

if($(Test-Path -Path "$ScriptPath\generate.ps1"))
{
    Write-Warning "File `"$ScriptPath\generate.ps1`" already exists, exiting script."
    Exit
}

$scriptTxt = "Start-AutoRestCodeGeneration -ResourceProvider `"$ResourceProvider`" -AutoRestVersion `"latest`""

if(![string]::IsNullOrWhiteSpace)
{
    $scriptTxt = $scriptTxt + " -SdkGenerationDirectory $SdkGenerationDirectory"
}

Write-Host "Creating file `"$ScriptPath\generate.ps1`" ..."
New-Item -Path $ScriptPath -Name "generate.ps1" -ItemType "File"

Write-Host "Writing to created script file"
Set-Content -Path "$ScriptPath\generate.ps1" -Value $scriptTxt
Write-Host "AutoRest Code generation script created successfully!!"