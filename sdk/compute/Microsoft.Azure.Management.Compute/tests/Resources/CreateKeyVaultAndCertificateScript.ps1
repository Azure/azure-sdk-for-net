Param(
  [Parameter(Mandatory=$true)]  [string]$subscriptionId,
  [Parameter(Mandatory=$false)] [string]$region            = "eastasia",
  [Parameter(Mandatory=$false)] [string]$resourceGroupName = "pslibtestosprofile",
  [Parameter(Mandatory=$false)] [string]$keyVaultName      = "pslibtestkeyvault"
)
$PfxCertifcate = ""
$PfxCertifcatePassword = "[PLACEHOLDER]"

Switch-AzureMode AzureResourceManager
Select-AzureSubscription -SubscriptionId $subscriptionId
New-AzureResourceGroup -Name $resourceGroupName -Location $region
$keyVault = New-AzureKeyVault -ResourceGroupName $resourceGroupName -Location $region -VaultName $keyVaultName -EnabledForDeployment

$CertificateJson = @"
{
  "data":     "$PfxCertifcate",
  "dataType": "pfx",
  "password": "$PfxCertifcatePassword"
}
"@

$CertificateBytes = [System.Text.Encoding]::UTF8.GetBytes($CertificateJson)
$JsonEncodedCertificate = [System.Convert]::ToBase64String($CertificateBytes)
$secret = ConvertTo-SecureString -String $JsonEncodedCertificate -AsPlainText -Force
$secretName = "WinRM"
$secret = Set-AzureKeyVaultSecret -VaultName $keyVaultName -Name $secretName -SecretValue $secret

Write-Host "Please Use the values below during recording:"
Write-Host
Write-Host -ForegroundColor Green "KeyVaultId: " $keyVault.ResourceId
Write-Host
Write-Host -ForegroundColor Green "CertificateUrl: " $secret.Id
Write-Host
Write-Host
Write-Host "After recording completes, Please  delete the whole resource group which contains the key vault, using the following command"
Write-Host -ForegroundColor Yellow  "  Remove-AzureResourceGroup -Name $resourceGroupName "
