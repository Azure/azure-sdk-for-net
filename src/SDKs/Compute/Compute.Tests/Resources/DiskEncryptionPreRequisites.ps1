Param(
  [Parameter(Mandatory = $true, 
             HelpMessage="Name of the resource group to which the KeyVault belongs to.  A new resource group with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$resourceGroupName,

  [Parameter(Mandatory = $true,
             HelpMessage="Name of the KeyVault in which encryption keys are to be placed. A new vault with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$keyVaultName,

  [Parameter(Mandatory = $true,
             HelpMessage="Location of the KeyVault. Important note: Make sure the KeyVault and VMs to be encrypted are in the same region / location.")]
  [ValidateNotNullOrEmpty()]
  [string]$location,

  [Parameter(Mandatory = $true,
             HelpMessage="Name of the AAD application that will be used to write secrets to KeyVault. A new application with this name will be created if one doesn't exist. If this app already exists, pass aadClientSecret parameter to the script")]
  [ValidateNotNullOrEmpty()]
  [string]$aadAppName,

  [Parameter(Mandatory = $false,
             HelpMessage="Client secret of the AAD application that was created earlier")]
  [ValidateNotNullOrEmpty()]
  [string]$aadClientSecret,

  [Parameter(Mandatory = $false,
             HelpMessage="Identifier of the Azure subscription to be used. Default subscription will be used if not specified.")]
  [ValidateNotNullOrEmpty()]
  [string]$subscriptionId,

  [Parameter(Mandatory = $false,
             HelpMessage="Name of optional key encryption key in KeyVault. A new key with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$keyEncryptionKeyName

)

########################################################################################################################
# Section1:  Log-in to Azure and select appropriate subscription. 
########################################################################################################################
  

#    Write-Host 'Please log into Azure now' -foregroundcolor Green;
#    Login-AzureRmAccount -ErrorAction "Stop" 1> $null;

#    if($subscriptionId)
#    {
#        Select-AzureRmSubscription -SubscriptionId $subscriptionId;
#    }


########################################################################################################################
# Section2:  Create AAD app . Fill in $aadClientSecret variable if AAD app was already created
########################################################################################################################


    # Check if AAD app with $aadAppName was already created
    $SvcPrincipals = (Get-AzureRmADServicePrincipal -SearchString $aadAppName);
    if(-not $SvcPrincipals)
    {
        # Create a new AD application if not created before
        $identifierUri = [string]::Format("http://localhost:8080/{0}",[Guid]::NewGuid().ToString("N"));
        $defaultHomePage = 'http://contoso.com';
        $now = [System.DateTime]::Now;
        $oneYearFromNow = $now.AddYears(1);
        $aadClientSecret = [Guid]::NewGuid();

        Write-Host "Creating new AAD application ($aadAppName)";
        $ADApp = New-AzureRmADApplication -DisplayName $aadAppName -HomePage $defaultHomePage -IdentifierUris $identifierUri  -StartDate $now -EndDate $oneYearFromNow -Password $aadClientSecret;
        $servicePrincipal = New-AzureRmADServicePrincipal -ApplicationId $ADApp.ApplicationId;
        $SvcPrincipals = (Get-AzureRmADServicePrincipal -SearchString $aadAppName);
        if(-not $SvcPrincipals)
        {
            # AAD app wasn't created 
            Write-Error "Failed to create AAD app $aadAppName. Please log-in to Azure using Login-AzureRmAccount  and try again";
            return;
        }
        $aadClientID = $servicePrincipal.ApplicationId;
        Write-Host "Created a new AAD Application ($aadAppName) with ID: $aadClientID ";
    }
    else
    {
        if(-not $aadClientSecret)
        {
            $aadClientSecret = Read-Host -Prompt "Aad application ($aadAppName) was already created, input corresponding aadClientSecret and hit ENTER. It can be retrieved from https://manage.windowsazure.com portal" ;
        }
        if(-not $aadClientSecret)
        {
            Write-Error "Aad application ($aadAppName) was already created. Re-run the script by supplying aadClientSecret parameter with corresponding secret from https://manage.windowsazure.com portal";
            return;
        }
        $aadClientID = $SvcPrincipals[0].ApplicationId;
    }

# Before proceeding to Section3, make sure $aadClientID  and $aadClientSecret have valid values
########################################################################################################################
# Section3:  Create KeyVault or setup existing keyVault
########################################################################################################################

    Try
    {
        $resGroup = Get-AzureRmResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue;
    }
    Catch [System.ArgumentException]
    {
        Write-Host "Couldn't find resource group:  ($resourceGroupName)";
        $resGroup = $null;
    }
    
    #Create a new resource group if it doesn't exist
    if (-not $resGroup)
    {
        Write-Host "Creating new resource group:  ($resourceGroupName)";
        $resGroup = New-AzureRmResourceGroup -Name $resourceGroupName -Location $location;
        Write-Host "Created a new resource group named $resourceGroupName to place keyVault";
    }
    
    Try
    {
        $keyVault = Get-AzureRmKeyVault -VaultName $keyVaultName -ErrorAction SilentlyContinue;
    }
    Catch [System.ArgumentException]
    {
        Write-Host "Couldn't find Key Vault: $keyVaultName";
        $keyVault = $null;
    }
    
    #Create a new vault if vault doesn't exist
    if (-not $keyVault)
    {
        Write-Host "Creating new key vault:  ($keyVaultName)";
        $keyVault = New-AzureRmKeyVault -VaultName $keyVaultName -ResourceGroupName $resourceGroupName -Sku Standard -Location $location;
        Write-Host "Created a new KeyVault named $keyVaultName to store encryption keys";
    }
    # Specify privileges to the vault for the AAD application - https://msdn.microsoft.com/en-us/library/mt603625.aspx
    Set-AzureRmKeyVaultAccessPolicy -VaultName $keyVaultName -ServicePrincipalName $aadClientID -PermissionsToKeys wrapKey -PermissionsToSecrets set;

    Set-AzureRmKeyVaultAccessPolicy -VaultName $keyVaultName -EnabledForDiskEncryption;
    
    $diskEncryptionKeyVaultUrl = $keyVault.VaultUri;
	$keyVaultResourceId = $keyVault.ResourceId;

    if($keyEncryptionKeyName)
    {
        Try
        {
            $kek = Get-AzureKeyVaultKey -VaultName $keyVaultName -Name $keyEncryptionKeyName -ErrorAction SilentlyContinue;
        }
        Catch [Microsoft.Azure.KeyVault.KeyVaultClientException]
        {
            Write-Host "Couldn't find key encryption key named : $keyEncryptionKeyName in Key Vault: $keyVaultName";
            $kek = $null;
        } 

        if(-not $kek)
        {
            Write-Host "Creating new key encryption key named:$keyEncryptionKeyName in Key Vault: $keyVaultName";
            $kek = Add-AzureKeyVaultKey -VaultName $keyVaultName -Name $keyEncryptionKeyName -Destination Software -ErrorAction SilentlyContinue;
            Write-Host "Created  key encryption key named:$keyEncryptionKeyName in Key Vault: $keyVaultName";
        }

        $keyEncryptionKeyUrl = $kek.Key.Kid;
    }   

########################################################################################################################
# Section4:  Displays values that should be used while enabling encryption. Please note these down
########################################################################################################################
    Write-Host "Please note down below aadClientID, aadClientSecret, diskEncryptionKeyVaultUrl, keyVaultResourceId values that will be needed to enable encryption on your VMs " -foregroundcolor Green;
    Write-Host "`t aadClientID: $aadClientID" -foregroundcolor Green;
    Write-Host "`t aadClientSecret: $aadClientSecret" -foregroundcolor Green;
    Write-Host "`t diskEncryptionKeyVaultUrl: $diskEncryptionKeyVaultUrl" -foregroundcolor Green;
    Write-Host "`t keyVaultResourceId: $keyVaultResourceId" -foregroundcolor Green;
    if($keyEncryptionKeyName)
    {
        Write-Host "`t keyEncryptionKeyURL: $keyEncryptionKeyUrl" -foregroundcolor Green;
    }
    Write-Host "Please Press [Enter] after saving values displayed above. They are needed to enable encryption using Set-AzureRmVmDiskEncryptionExtension cmdlet" -foregroundcolor Green;
    Read-Host;

########################################################################################################################
# For each VM you want to encrypt, run the below cmdlet
#    $vmName = 'Name of VM to encrypt';
#    Set-AzureRmVMDiskEncryptionExtension -ResourceGroupName $resourceGroupName -VMName $vmName -AadClientID $aadClientID -AadClientSecret $aadClientSecret -DiskEncryptionKeyVaultUrl $diskEncryptionKeyVaultUrl -DiskEncryptionKeyVaultId $keyVaultResourceId;
########################################################################################################################