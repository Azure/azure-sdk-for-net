# **********************************************************************************************
# This sample PowerShell gets the settings you'll need for the *.cscfg files
# **********************************************************************************************

# **********************************************************************************************
# You MUST set the following values before running this script
# **********************************************************************************************
$vaultName           = 'MyVaultName'
$resourceGroupName   = 'MyResourceGroupName'
$applicationName     = 'MyAppName'
$storageName         = 'MyStorageName'
$pathToCertFile      = 'C:\path\Certificate.cer'

# **********************************************************************************************
# You MAY set the following values before running this script
# **********************************************************************************************
$location            = 'East US'                          # Get-AzureLocation
$secretName          = 'MyStorageAccessSecret'

# **********************************************************************************************
# Should we bounce this script execution?
# **********************************************************************************************
if (($vaultName -eq 'MyVaultName') -or `
    ($resourceGroupName -eq 'MyResourceGroupName') -or `
	($applicationName -eq 'MyAppName') -or `
	($storageName -eq 'MyStorageName') -or `
	($pathToCertFile -eq 'C:\path\Certificate.cer'))
{
	Write-Host 'You must edit the values at the top of this script before executing' -foregroundcolor Yellow
	exit
}
if (-not (get-module -Name 'KeyVaultManager'))
{
	Write-Host 'You must import the KeyVaultManager module before executing this script' -foregroundcolor Yellow
	exit
}
if (-not (Test-Path $pathToCertFile))
{
	Write-Host 'No certificate file found at '$pathToCertFile -foregroundcolor Yellow
	exit
}

# **********************************************************************************************
# Log into Azure
# **********************************************************************************************
Write-Host 'Please log into Azure now' -foregroundcolor Green
Add-AzureAccount
$VerbosePreference = "SilentlyContinue"
Switch-AzureMode AzureResourceManager
$azureTenantId = (Get-AzureSubscription -Current).TenantId # Set your current subscription tenant ID

# **********************************************************************************************
# Log into AAD graph (use the same credentials)
# **********************************************************************************************
Write-Host 'Now please use the same user name to log into Azure Active Directory' -foregroundcolor Green
Connect-AzureAD -DomainName $azureTenantId

# **********************************************************************************************
# Create application in AAD if needed
# **********************************************************************************************
$ADApps = (Get-AzureADApplication -Name $applicationName)
if(-not $ADApps)
{
    # Create a new AD application if not created before
    $ADApp = New-AzureADApplication -DisplayName $applicationName
}
else
{
    $ADApp = $ADApps[0]
}

# Add certificate to the application
Add-AzureADApplicationCredential -ObjectId $ADApp.objectId `
								 -FilePath $pathToCertFile

# **********************************************************************************************
# Create the vault if needed
# **********************************************************************************************
$vault = Get-AzureKeyVault -VaultName $vaultName
if (-not $vault)
{
  $vault = New-AzureKeyVault -VaultName $vaultName `
                             -ResourceGroupName $resourceGroupName `
                             -Sku premium `
                             -Location $location
}

# Specify full privileges to the vault for the application
$servicePrincipal = (Get-AzureADServicePrincipal -SearchString $ADApp.displayName)
Set-AzureKeyVaultAccessPolicy -VaultName $vaultName `
	-ObjectId $servicePrincipal[0].Id `
	-PermissionsToKeys all `
	-PermissionsToSecrets all

# **********************************************************************************************
# Store storage account access key as a secret in the vault
# **********************************************************************************************
$VerbosePreference = "SilentlyContinue"
Switch-AzureMode AzureServiceManagement
$storagekey = (Get-AzureStorageKey -StorageAccountName $storageName).Primary
Switch-AzureMode AzureResourceManager
$secret = Set-AzureKeyVaultSecret -VaultName $vaultName `
								  -Name $secretName `
								  -SecretValue (ConvertTo-SecureString -String $storagekey -AsPlainText -Force) 
								  
# **********************************************************************************************
# Retrieve thumbprint for certificate authorized to access vault
# **********************************************************************************************
$myCertificate = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$myCertificate.Import($pathToCertFile);
$myCertThumbprint = $myCertificate.Thumbprint

# **********************************************************************************************
# Print the XML settings that should be copied into the CSCFG files
# **********************************************************************************************
Write-Host "Place the following into both CSCFG files for the SampleAzureWebService project:" -ForegroundColor Cyan
'<Setting name="StorageAccountName" value="' + $storageName + '" />'
'<Setting name="StorageAccountKeySecretUrl" value="' + $secret.Id.Substring(0, $secret.Id.LastIndexOf('/')) + '" />'
'<Setting name="KeyVaultAuthClientId" value="' + $ADApp.appId + '" />'
'<Setting name="KeyVaultAuthCertThumbprint" value="' + $myCertThumbprint + '" />'
'<Certificate name="KeyVaultAuthCert" thumbprint="' + $myCertThumbprint + '" thumbprintAlgorithm="sha1" />'
Write-Host

