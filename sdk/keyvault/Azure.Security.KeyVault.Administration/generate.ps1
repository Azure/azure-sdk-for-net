#
# Generate Azure.Security.KeyVault.Administration
#
Push-Location $PSScriptRoot/src/

# We're doing a copy instead of a reference until we can merge them together
# because AutoRest doesn't play well with two remote swagger files.  (We only
# warn on failure so offline regeneration plays nicely for those of us coding
# on the bus.)
Write-Output "Copying latest swagger files..."

$basepath = 'https://raw.githubusercontent.com/Azure/azure-rest-api-specs/189fe8eb8d1ce60c9a782bbd1a0d632ffd70f1ae/specification/keyvault/data-plane/Microsoft.KeyVault/preview/7.2-preview/'

$backuprestore = $basepath + 'backuprestore.json'
$common = $basepath + 'common.json'
$rbac = $basepath + 'rbac.json'

Invoke-WebRequest -Uri $backuprestore `
    -OutFile ./swagger/backuprestore.json `
    -ErrorAction Continue

Invoke-WebRequest -Uri $common `
    -OutFile ./swagger/common.json `
    -ErrorAction Continue

Invoke-WebRequest -Uri $rbac `
    -OutFile ./swagger/rbac.json `
    -ErrorAction Continue

Write-Output "Generating Azure.Security.KeyVault.Administration..."
dotnet msbuild /t:GenerateCode

Pop-Location
