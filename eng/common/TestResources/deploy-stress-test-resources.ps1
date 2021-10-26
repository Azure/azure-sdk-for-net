$secrets = @{}
$secretsDir = "/mnt/secrets/static/*"
Get-ChildItem -Path $secretsDir | ForEach-Object {
    foreach($line in Get-Content $_) {
        $idx = $line.IndexOf("=")
        if ($idx -gt 0) {
            $key = $line.Substring(0, $idx)
            $val = $line.Substring($idx + 1)
            $secrets.Add($key, $val)
        }
    }
}

$templateParams = Get-Content "/mnt/testresources/parameters.json" | ConvertFrom-json -AsHashTable
mkdir /azure
Copy-Item "/common/scripts/stress-testing/test-resources-post.ps1" -Destination "/azure/"
Copy-Item "/mnt/testresources/*" -Destination "/azure/"

& $PSScriptRoot/New-TestResources.ps1 `
    -BaseName $env:BASE_NAME `
    -SubscriptionId $secrets.AZURE_SUBSCRIPTION_ID `
    -TenantId $secrets.AZURE_TENANT_ID `
    -ProvisionerApplicationId $secrets.AZURE_CLIENT_ID `
    -ProvisionerApplicationSecret $secrets.AZURE_CLIENT_SECRET `
    -TestApplicationId $secrets.AZURE_CLIENT_ID `
    -TestApplicationSecret $secrets.AZURE_CLIENT_SECRET `
    -TestApplicationOid $secrets.AZURE_CLIENT_OID `
    -ArmTemplateParameters $templateParams `
    -Location 'westus2' `
    -DeleteAfterHours 168 `
    -ServiceDirectory '/azure/' `
    -CI `
    -Force 

#>