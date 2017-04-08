# Azure Key Vault .NET Sample Code

## Contents
1. \samples - Key Vault sample applications 
1. \scripts - PowerShell sample scripts for generating setting files 

## Pre-requisites
1. Visual Studio 2015 or Visual Studio 2013
2. Azure SDK 2.9 
3. Azure PowerShell version 2.1.0 or newer
4. NuGet version 2.7 or newer
5. nuget.org (https://www.nuget.org/api/v2/) should be an available package source in Visual Studio NuGet Package Manager settings
6. Active Azure subscription


> Please read the [documentation about Key Vault][2] to familiarize yourself with the basic concepts of Key Vault before running this sample application.

## Sample #1 - HelloKeyVault
A console application that walks through the key scenarios supported by Key Vault:

  1. Create/Import a key (HSM or software keys)
  2. Encrypt a secret using a content key
  3. Wrap the content key using a Key Vault key
  4. Unwrap the content key
  5. Decrypt the secret
  6. Set a secret
  7. Create, Import, Export certificate

### Setup steps

Run the sample script *scripts\GetAppConfigSettings.ps1* and then update the app configuration settings in HelloKeyVault\App.config with your vault URL, application principal ID and thumbprint generated from the script. The script will do the following:

1. Create a self-signed certificate for authentication with Azure Active Directory
2. Create a application and service principal if it doesn't exist
3. Create a resource group if it doesn't exist
4. Create a key vault if it doesn't exist
5. Set appropriate key vault access policy
 

To use the sample script, follow these steps:
 
 1. Update the values of mandatory variables in GetAppConfigSettings.ps1
 2. Launch the Microsoft Azure PowerShell window
 3. Run the GetAppConfigSettings.ps1 script within the Microsoft Azure PowerShell window
 4. Copy the results of the script into the HelloKeyVault\App.config file

### Running the sample application
Once the setup steps are completed, build and run the HelloKeyVault.exe program.  Observe the results printed out in the command line window.

## Sample #2 - SampleAzureWebService

This sample app demonstrates how an Azure web service can retrieve application secrets like passwords or storage account credentials from Key Vault at run-time.  This eliminates the need to package secret values with the deployment package.  This sample app also demonstrates managing a single bootstrapping X509 certificate that is used to authenticate with the Key Vault.


The web app presents an online message board to users and uses an Azure storage account to persist the message board contents.  The storage account access key is retrieved from the Key Vault service at run-time.

The web app also demonstrates secret caching using a custom configuration manager. The configuration manager handles resolving a secret ID to a corresponding secret value and caching the secret value for a specified period of time. It also caches service configuration settings and refreshes them when updated.

### Setup steps

1. Create a new Azure cloud service in the [Azure management portal][1].  Upload the PFX file for the certificate you just created into the certificate tab for the cloud service. For instructions see step 3 in [service certificate][9].
2. Create a new Azure storage account in the [Azure management portal][1].  Remember the storage account name -- you'll need it as an input parameter for the GetServiceConfigSettings.ps1 script.
3. Run the sample script *scripts\GetServiceConfigSettings.ps1* and then update the service configuration settings in ServiceConfiguration.Cloud.cscfg generated from the script. The script will do the following:
    - Create a self-signed certificate for authentication with Azure Active Directory
    - Create a application and service principal if it doesn't exist
    - Create a resource group if it doesn't exist
    - Create a key vault if it doesn't exist
    - Create a new storage account if doesn't exist
    - Set appropriate key vault access policy
    - Store the storage key as a secret in key vault
4. To use the sample script, follow these steps:
	 1. Update the values of mandatory variables in GetServiceConfigSettings.ps1
	 2. Launch the Microsoft Azure PowerShell window
	 3. Run the GetServiceConfigSettings.ps1 script within the Microsoft Azure PowerShell window
	 4. Copy the results of the script into both CSCFG files in the project
5. Update the service configuration settings in ServiceConfiguration.Cloud.cscfg by providing:
	- Key Vault authentication certificate thumbprint (you can find the thumbprint in the 'detailed' tab of the certificate).
	- Name of the storage account to store messages in.
	- URI to a Key Vault secret, containing a storage account key. 
	- Duration that the secret should be cached (e.g. 00:20:00).
	- Client ID of the application that you have registered in Azure Active Directory with X509 certificate based credentials.

### Running the sample application

Once the setup steps are completed, build and publish the web service to the Azure cloud service created in the setup steps.  Note that the service configuration file and the package used to publish contain no secret values.

>NOTE: You can also deploy the application locally, to the Azure Compute Emulator. In this case, the Key Vault authentication certificate with the private key must be installed in the local machine's Personal certificate store.

Navigate to the web service from your browser to save messages and read recent messages. Look at the traces displayed to see what's happening in the background.


### Updating the app's secret values

To update the storage account key, stored in the Key Vault secret, follow these steps:

 1. Go back to the Azure portal and regenerate the storage account keys.
 2. The web service will now fail to load or save messages, as expected. 
 3. Read the trace messages to confirm this. 
 4. Use Set-AzureKeyVaultSecret PowerShell cmdlet to update the secret stored in your vault.
	
There are two ways to get the updated secret values into the app:

 - Wait for the cached secret value to reach its expiry time and get refreshed. When the cached secret reaches its expiry time the service will retrieve the updated secret.
 - Force the application to re-read the service configuration settings by making a change to the service configuration (e.g. .cscfg file) in the running service. This triggers an event within the service to flush the cached service configurations and secrets. Consequently, the new configuration settings get retrieved, secret IDs get resolved to their corresponding values and the new values get cached. 
	
After the cached secret value gets updated with the new storage account key, the message board application will start to work again.

[1]: http://manage.windowsazure.com
[2]: http://go.microsoft.com/fwlink/?LinkID=512410 
[3]: http://msdn.microsoft.com/en-us/library/vstudio/bfsktky3(v=vs.100).aspx
[4]: https://azure.microsoft.com/en-us/documentation/articles/cloud-services-configure-ssl-certificate/

