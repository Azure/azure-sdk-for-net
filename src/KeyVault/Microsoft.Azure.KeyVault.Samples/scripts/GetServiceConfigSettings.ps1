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

# **********************************************************************************************
# Prep the cert credential data
# **********************************************************************************************
$x509 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$x509.Import($pathToCertFile)
$credValue = [System.Convert]::ToBase64String($x509.GetRawCertData())
$now = [System.DateTime]::Now
$oneYearFromNow = $now.AddYears(1)

# **********************************************************************************************
# Create application in AAD if needed
# **********************************************************************************************
$SvcPrincipals = (Get-AzureADServicePrincipal -SearchString $applicationName)
if(-not $SvcPrincipals)
{
    # Create a new AD application if not created before
    $identifierUri = [string]::Format("http://localhost:8080/{0}",[Guid]::NewGuid().ToString("N"))
    $homePage = "http://contoso.com"
    Write-Host "Creating a new AAD Application"
    $ADApp = New-AzureADApplication -DisplayName $applicationName -HomePage $homePage -IdentifierUris $identifierUri  -KeyValue $credValue -KeyType "AsymmetricX509Cert" -KeyUsage "Verify" -StartDate $now -EndDate $oneYearFromNow
    Write-Host "Creating a new AAD service principal"
    $servicePrincipal = New-AzureADServicePrincipal -ApplicationId $ADApp.ApplicationId
}
else
{
    # Assume that the existing app was created earlier with the right X509 credentials. We don't modify the existing app to add new credentials here.
    Write-Host "WARNING: An application with the specified name ($applicationName) already exists." -ForegroundColor Yellow -BackgroundColor Black
    Write-Host "         Proceeding with script execution assuming that the app has the correct X509 credentials already set." -ForegroundColor Yellow -BackgroundColor Black
    Write-Host "         If you are not sure about the existing app's credentials, choose an app name that doesn't already exist and the script with create it and set the specified credentials for you." -ForegroundColor Yellow -BackgroundColor Black
    $servicePrincipal = $SvcPrincipals[0]
}


# **********************************************************************************************
# Create the resource group and vault if needed
# **********************************************************************************************
$rg = Get-AzureResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue
if (-not $rg)
{
    New-AzureResourceGroup -Name $resourceGroupName -Location $location   
}

$vault = Get-AzureKeyVault -VaultName $vaultName -ErrorAction SilentlyContinue
if (-not $vault)
{
  $vault = New-AzureKeyVault -VaultName $vaultName `
                             -ResourceGroupName $resourceGroupName `
                             -Sku premium `
                             -Location $location
}

# Specify full privileges to the vault for the application
Set-AzureKeyVaultAccessPolicy -VaultName $vaultName `
	-ObjectId $servicePrincipal.Id `
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
'<Setting name="KeyVaultAuthClientId" value="' + $servicePrincipal.ApplicationId + '" />'
'<Setting name="KeyVaultAuthCertThumbprint" value="' + $myCertThumbprint + '" />'
'<Certificate name="KeyVaultAuthCert" thumbprint="' + $myCertThumbprint + '" thumbprintAlgorithm="sha1" />'
Write-Host

