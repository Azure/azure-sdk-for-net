param (
    [Parameter(Mandatory=$true)]
    [string]$service,
    [string]$keyVault = "AzureSDK-Dev-TestSecrets"
    )

$secrets = (az keyvault secret list --vault-name $keyVault --output json | ConvertFrom-Json);
$secrets | Write-Host;

$languagePrefix = "net-";
$prefix = $languagePrefix + $service + "-";

foreach ($secret in $secrets)
{
    $id = $secret.id;
    $name = $id.Substring($id.LastIndexOf('/') + 1);

    if ($name.StartsWith($prefix))
    {
        $value = (az keyvault secret show --id $id | ConvertFrom-Json).value;
        $variableName = $name.Substring($languagePrefix.Length).Replace('-', '_');

        Write-Host "Setting" $variableName to $value;
        [Environment]::SetEnvironmentVariable($variableName, $value);
    }
}