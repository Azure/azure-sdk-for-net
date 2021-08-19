$EnvFilePath = $env:ENV_FILE

$envFileMap = @{}

foreach($line in Get-Content $EnvFilePath) {
    $idx = $line.IndexOf("=")
    if ($idx -gt 0) {
        $key = $line.Substring(0, $idx)
        $val = $line.Substring($idx + 1)
        $envFileMap.Add($key, $val)
    }
}

$envFileMap.Add("STORAGE_TENANT_ID", $envFileMap["AZURE_TENANT_ID"])

& /azure-sdk-for-net/sdk/storage/test-resources-post.ps1 -DeploymentOutputs $envFileMap -TenantId $envFileMap["AZURE_TENANT_ID"] -TestApplicationId $envFileMap["AZURE_CLIENT_ID"] -TestApplicationSecret $envFileMap["AZURE_CLIENT_SECRET"]
