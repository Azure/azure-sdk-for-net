# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

$SwaggerTagVersion = "preview/2021-11-01-preview"

$SpecsRepo = "https://github.com/Azure/azure-rest-api-specs.git"
$SpecsBranch = "main"
$SpecsCommitId = ""
$PathAllowList = ("specification/quantum")

$TempFolder = Join-Path $PSScriptRoot "../temp/"
$SpecsFolder = Join-Path $TempFolder  "/specs/"

# Check-out specs repo to get the latest swagger API Definition file
$CheckoutScript = Join-Path $PSScriptRoot "./Checkout-Repo.ps1" 
&$CheckoutScript -RepoUrl $SpecsRepo -TargetFolder $SpecsFolder -PathAllowList $PathAllowList -BranchName $SpecsBranch -CommitId $SpecsCommitId -Force | Write-Verbose

$AutoRestConfig = Join-Path $PSScriptRoot "../src/autorest.md"

# Make sure we have the latest AutoRest
npm install -g autorest@latest | Write-Verbose

# Delete the old generated client and copy the new one there
$AzureQuantumClient_Folder =  Join-Path $PSScriptRoot "../src/Generated/"
if (Test-Path $AzureQuantumClient_Folder) {
    Remove-Item $AzureQuantumClient_Folder -Recurse | Write-Verbose
}


$NewAutorestConfig = @"
# Generated code configuration

Run ``dotnet build /t:GenerateCode`` to generate code.

`````` yaml
input-file:
    `$(this-folder)../temp/specs/specification/quantum/data-plane/Microsoft.Quantum/$SwaggerTagVersion/quantum.json
``````
"@

try
{
    Copy-Item $AutoRestConfig -Destination "$AutoRestConfig.bkp" -Force | Write-Verbose

    Set-Content -Path $AutoRestConfig -Value $NewAutorestConfig | Write-Verbose

    # Generate the client
    dotnet build /t:GenerateCode /p:AutoRestAdditionalParameters="--verbose" | Write-Verbose
}
finally
{
    Copy-Item "$AutoRestConfig.bkp" -Destination $AutoRestConfig -Force | Write-Verbose
    Remove-Item "$AutoRestConfig.bkp" -Force | Write-Verbose
}
