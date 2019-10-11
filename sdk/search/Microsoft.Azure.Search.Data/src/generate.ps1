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
    [string] $SpecsRepoBranch = "master",
    [string] $Tag = ""
)

"$PSScriptRoot\..\..\Install-BuildTools.ps1"

$generateFolder = "$PSScriptRoot\Generated"

# TODO: Change AutoRestVersion back to "latest" when the hanging issue is fixed.
Start-AutoRestCodeGeneration -ResourceProvider "search/data-plane/Microsoft.Azure.Search.Data" -AutoRestVersion "2.0.4302" -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch -ConfigFileTag $Tag

Write-Output "Deleting extra files and cleaning up..."

# Delete any extra files generated for types that are shared between SearchServiceClient and SearchIndexClient.
Remove-Item "$generateFolder\Models\SearchRequestOptions.cs"

# Delete extra files we don't need.
Remove-Item "$generateFolder\DocumentsOperationsExtensions.cs"

Write-Output "Finished cleanup."
