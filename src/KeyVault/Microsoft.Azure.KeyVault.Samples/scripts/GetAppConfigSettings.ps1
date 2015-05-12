# **********************************************************************************************
# This sample PowerShell gets the settings you'll need for the app.config file
# **********************************************************************************************

# **********************************************************************************************
# You MUST set the following values before running this script
# **********************************************************************************************
$vaultName           = 'MyVaultName'
$resourceGroupName   = 'MyResourceGroupName'
$applicationName     = 'MyAppName'

# **********************************************************************************************
# You MAY set the following values before running this script
# **********************************************************************************************
$applicationPassword = [Guid]::NewGuid()
$location            = 'East US'                          # Get-AzureLocation

# **********************************************************************************************
# Should we bounce this script execution?
# **********************************************************************************************
if (($vaultName -eq 'MyVaultName') -or ($resourceGroupName -eq 'MyResourceGroupName') -or ($applicationName -eq 'MyAppName'))
{
	Write-Host 'You must edit the values at the top of this script before executing' -foregroundcolor Yellow
	exit
}
if (-not (get-module -Name 'KeyVaultManager'))
{
	Write-Host 'You must import the KeyVaultManager module before executing this script' -foregroundcolor Yellow
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

# Add a new password to the application
Add-AzureADApplicationCredential -ObjectId $ADApp.objectId `
								 -Password $applicationPassword

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
# Print the XML settings that should be copied into the app.config file
# **********************************************************************************************
Write-Host "Paste the following settings into the app.config file for the HelloKeyVault project:" -ForegroundColor Cyan
'<add key="VaultUrl" value="' + $vault.Properties["vaultUri"] + '"/>'
'<add key="AuthClientId" value="' + $ADApp.appId + '"/>'
'<add key="AuthClientSecret" value="' + $applicationPassword + '"/>'
Write-Host
