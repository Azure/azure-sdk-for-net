# ---------------------------------------------------------------------------------- 
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# ---------------------------------------------------------------------------------- 

<#

.SYNOPSIS
    Powershell script that generates the C# SDK code for Microsoft.Azure.Search.Data from a Swagger spec

.DESCRIPTION
    This script:
    - fetches the config file from user/branch provided
    - Generates code based off the config file provided

.PARAMETER SpecsRepoFork
    The Rest Spec repo fork which contains the config file; the default is Azure.

.PARAMETER SpecsRepoBranch
    The Branch which contains the config file; the default is master.

#>

Param(
    [string] $SpecsRepoFork = "Azure",
    [string] $SpecsRepoBranch = "master"
)

$repoRoot = "$PSScriptRoot\..\..\..\..\.."
$generateFolder = "$PSScriptRoot\Generated"

Start-AutoRestCodeGeneration -ResourceProvider "search/data-plane/Microsoft.Azure.Search.Data" -AutoRestVersion "latest" -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch

Write-Output "Deleting extra files and cleaning up..."

# Delete any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient.
Remove-Item "$generateFolder\Models\SearchRequestOptions.cs"

# Delete extra files we don't need.
Remove-Item "$generateFolder\DocumentsProxyOperationsExtensions.cs"

# Make any necessary modifications
powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File .\Fix-GeneratedCode.ps1

Write-Output "Finished cleanup."
