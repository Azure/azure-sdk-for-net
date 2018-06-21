# ---------------------------------------------------------------------------------- 
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# ---------------------------------------------------------------------------------- 

<#

.SYNOPSIS
    Powershell script that generates the C# SDK code for Microsoft.Azure.Search.Service from a Swagger spec

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
$sharedGenerateFolder = "$generateFolder\..\..\Microsoft.Azure.Search.Common\Generated"

Start-AutoRestCodeGeneration -ResourceProvider "search/data-plane/Microsoft.Azure.Search.Service" -AutoRestVersion "latest" -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch

Write-Output "Deleting extra files and cleaning up..."

# Move any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient to Common.
if (Test-Path -Path $sharedGenerateFolder)
{
    Remove-Item -Recurse -Force $sharedGenerateFolder
}

New-Item -ItemType Directory $sharedGenerateFolder
Move-Item "$generateFolder\Models\SearchRequestOptions.cs" $sharedGenerateFolder

Write-Output "Finished cleanup."
