# **********************************************************************************************
# This sample PowerShell gets the settings you'll need for the app.config file
# **********************************************************************************************

# **********************************************************************************************
# You MUST set the following values before running this script
# **********************************************************************************************
$vaultName           = 'MyVaultName'
$resourceGroupName   = 'MyResourceGroupName'
$applicationName     = 'MyAppName'
$pathToCertFile      = 'C:\path\Certificate.cer'


# **********************************************************************************************
# You MAY set the following values before running this script
# **********************************************************************************************
$location            = 'East US'                          # Get-AzureLocation

# **********************************************************************************************
# Generates a secure 32-byte symmetric key for authentication
# **********************************************************************************************
Function GenerateSymmetricKey()
{
    $key = New-Object byte[](32)
    $rng = [System.Security.Cryptography.RNGCryptoServiceProvider]::Create()
    $rng.GetBytes($key)
    return [System.Convert]::ToBase64String($key)
}

# **********************************************************************************************
# Should we bounce this script execution?
# **********************************************************************************************
if (($vaultName -eq 'MyVaultName') -or `
    ($resourceGroupName -eq 'MyResourceGroupName') -or `
	($applicationName -eq 'MyAppName') -or `
	($pathToCertFile -eq 'C:\path\Certificate.cer'))
{
	Write-Host 'You must edit the values at the top of this script before executing' -foregroundcolor Yellow
	exit
}
# **********************************************************************************************
# Log into Azure
# **********************************************************************************************
Write-Host 'Please log into Azure Resource Manager now' -foregroundcolor Green
Login-AzureRmAccount
$VerbosePreference = "SilentlyContinue"

# **********************************************************************************************
# Prep the cert credential data
# **********************************************************************************************
$x509 = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2
$x509.Import($pathToCertFile)
$myCertThumbprint = $x509.Thumbprint

$credValue = [System.Convert]::ToBase64String($x509.GetRawCertData())
$now = [System.DateTime]::Now
$oneYearFromNow = $now.AddYears(1)

# **********************************************************************************************
# Create application in AAD if needed
# **********************************************************************************************
$SvcPrincipals = (Get-AzureRmADServicePrincipal -SearchString $applicationName)
if(-not $SvcPrincipals)
{
    # Create a new AD application if not created before
    $identifierUri = [string]::Format("http://localhost:8080/{0}",[Guid]::NewGuid().ToString("N"))
    $homePage = "http://contoso.com"
    Write-Host "Creating a new AAD Application"
    $ADApp = New-AzureRmADApplication -DisplayName $applicationName -HomePage $homePage -IdentifierUris $identifierUri  -KeyValue $credValue -KeyType "AsymmetricX509Cert" -KeyUsage "Verify" -StartDate $now -EndDate $oneYearFromNow
    Write-Host "Creating a new AAD service principal"
    $servicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $ADApp.ApplicationId
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
$rg = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue
if (-not $rg)
{
    New-AzureRmResourceGroup -Name $resourceGroupName -Location $location   
}

$vault = Get-AzureRmKeyVault -VaultName $vaultName -ErrorAction SilentlyContinue
if (-not $vault)
{
    Write-Host "Creating vault $vaultName"
    $vault = New-AzureRmKeyVault -VaultName $vaultName `
                             -ResourceGroupName $resourceGroupName `
                             -Sku premium `
                             -Location $location
}

# Specify full privileges to the vault for the application
Write-Host "Setting access policy"
Set-AzureRmKeyVaultAccessPolicy -VaultName $vaultName `
	-ObjectId $servicePrincipal.Id `
	-PermissionsToKeys all `
	-PermissionsToSecrets all

# **********************************************************************************************
# Print the XML settings that should be copied into the app.config file
# **********************************************************************************************
Write-Host "Paste the following settings into the app.config file for the HelloKeyVault project:" -ForegroundColor Cyan
'<add key="VaultUrl" value="' + $vault.VaultUri + '"/>'
'<add key="AuthClientId" value="' + $servicePrincipal.ApplicationId + '"/>'
'<add key="AuthCertThumbprint" value="' + $myCertThumbprint + '"/>'
Write-Host
