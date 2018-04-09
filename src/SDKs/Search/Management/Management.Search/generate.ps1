# ---------------------------------------------------------------------------------- 
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for
# license information.
# ---------------------------------------------------------------------------------- 

<#

.SYNOPSIS
    Powershell script that generates the C# SDK code for Microsoft.Azure.Management.Search from a Swagger spec

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

powershell.exe -ExecutionPolicy Bypass -NoLogo -NonInteractive -NoProfile -File "$repoRoot\tools\generateTool.ps1" -ResourceProvider "search/resource-manager" -PowershellInvoker  -AutoRestVersion "latest" -SpecsRepoFork $SpecsRepoFork -SpecsRepoBranch $SpecsRepoBranch
