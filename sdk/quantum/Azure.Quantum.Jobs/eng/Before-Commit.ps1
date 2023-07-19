# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$ExportAPIScript = Join-Path $PSScriptRoot "../../../../eng/scripts/Export-API.ps1" 
&$ExportAPIScript -ServiceDirectory "quantum" -SDKType  "client" | Write-Verbose

$UpdateSnippetsScript = Join-Path $PSScriptRoot "../../../../eng/scripts/Update-Snippets.ps1" 
&$UpdateSnippetsScript -ServiceDirectory "quantum" | Write-Verbose

