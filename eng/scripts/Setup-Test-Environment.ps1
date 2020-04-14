param (
    [Parameter(Mandatory=$true)]
    [string]$service,
    [string]$keyVault = "AzureSDK-Dev-TestSecrets"
    )

az account show | Out-Null;

if ($LASTEXITCODE -ne 0)
{
    Write-Error "Azure CLI with an active login is required. Please check the 'az account show' output."
}

$secrets = (az keyvault secret list --vault-name $keyVault --output json | ConvertFrom-Json);

$languagePrefix = "net-";
$prefix = $languagePrefix + $service + "-";

foreach ($secret in $secrets)
{
    $id = $secret.id;
    $name = $id.Substring($id.LastIndexOf('/') + 1);

    if ($name.StartsWith($prefix))
    {
        $value = (az keyvault secret show --id $id | ConvertFrom-Json).value;
        $variableName = $name.Substring($languagePrefix.Length).Replace('-', '_').ToUpper();

        Write-Host "Setting" $variableName to $value;
        [Environment]::SetEnvironmentVariable($variableName, $value);
    }
}