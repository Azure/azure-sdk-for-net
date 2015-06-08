#Azure Key Vault .NET Sample Code

##Contents
1. \samples - Key Vault sample applications 
1. \scripts - PowerShell sample scripts for generating setting files 

##Pre-requisites
1. Visual Studio 2013 or Visual Studio 2012
2. Azure SDK 2.5 and an active Azure subscription
3. Azure PowerShell version 0.9.1 or newer
4. NuGet version 2.7 or newer
5. nuget.org (https://www.nuget.org/api/v2/) should be an available package source in Visual Studio NuGet Package Manager settings

##Sample Applications
> Please read the [documentation about Key Vault][2] to familiarize yourself with the basic concepts of Key Vault before running this sample application.

###Sample #1 - HelloKeyVault
A console application that walks through the key scenarios supported by Key Vault:

  1. Create/Import a key (HSM or software keys)
  2. Encrypt a secret using a content key
  3. Wrap the content key using a Key Vault key
  4. Unwrap the content key
  5. Decrypt the secret
  6. Set a secret

#####Setup steps
Update the app configuration settings in HelloKeyVault\App.config with your vault URL, application principal ID and secret. The information can optionally be generated using *scripts\GetAppConfigSettings.ps1*. To use the sample script, follow these steps:

 1. Update the values of mandatory variables in GetAppConfigSettings.ps1
 2. Launch the Microsoft Azure PowerShell window
 3. Run the GetAppConfigSettings.ps1 script within the Microsoft Azure PowerShell window
 4. Copy the results of the script into the HelloKeyVault\App.config file

#####Running the sample application
Once the setup steps are completed, build and run the HelloKeyVault.exe program.  Observe the results printed out in the command line window.

###Sample #2 - SampleAzureWebService
This sample app demonstrates how an Azure web service can access secrets like passwords or storage account credentials through Key Vault. It uses X509 certificate based authentication when talking to Key Vault. The sample application is a simple message board service that runs on Azure. Users can save messages and view the recent messages. In the background, the application saves and retrieves these messages from an Azure Storage Table. 

Such applications typically require credentials in their service configuration, for example, the credentials to the storage account. This app accesses the storage account without needing the storage account key available to it during deployment time - it gets the key from Key Vault during runtime.

#####Setup steps
1. Create a new X509 certificate or get an existing one to use as the Key Vault authentication certificate. To create a new X509 certificate, [makecert][8] or [openssl][3] can be used. For example the following commands will generate a certificate file from a private key and a certificate signing request file:
	- openssl [genrsa][4] -des3 -out keyvault.key 2048
	- openssl [req][5] -new -key keyvault.key -out keyvault.csr
		- *Note: It is OK to choose the default answer for each question*
	- openssl [x509][6] -req -days 3000 -in keyvault.csr -signkey keyvault.key -out keyvault.cer
		- *Note:  The keyvault.cer file is a required input to the GetServiceConfigSettings.ps1 script* 
	- openssl [pkcs12][7] -export -out keyvault.pfx -inkey keyvault.key -in keyvault.cer
1. Create a new Azure cloud service in the [Azure management portal][1].  Upload the PFX file for the certificate you just created into the certificate tab for the cloud service. For instructions see [service certificate][9].
1. Create a new Azure storage account in the [Azure management portal][1].  Remember the storage account name -- you'll need it as an input parameter for the GetServiceConfigSettings.ps1 script.
1. Update the service configuration settings in ServiceConfiguration.Cloud.cscfg by providing:
	- Key Vault authentication certificate thumbprint (you can find the thumbprint in the 'detailed' tab of the certificate).
	- Name of the storage account to store messages in.
	- URI to a Key Vault secret, containing a storage account key. 
	- Client ID of the application that you have registered in Azure Active Directory with X509 certificate based credentials.
   
	For step 3 the service configuration settings can be generated using *scripts\GetServiceConfigSettings.ps1*. To use the sample script, follow these steps:

	 1. Update the values of mandatory variables in GetServiceConfigSettings.ps1
	 2. Launch the Microsoft Azure PowerShell window
	 3. Run the GetServiceConfigSettings.ps1 script within the Microsoft Azure PowerShell window
	 4. Copy the results of the script into both CSCFG files in the project

1. To deploy the service to the cloud, log into Azure portal and create a Cloud Service. Upload the certificate to this service.

#####Running the sample application
Once the setup steps are completed, enter the values into the ServiceConfiguration.Cloud.cscfg. Build and publish the web service to Azure, to the cloud service created above which has the authentication certificate.

>NOTE: You can also deploy the application locally, to the Azure Compute Emulator. In this case, the Key Vault authentication certificate with the private key must be installed in the local machine's Personal certificate store.

Navigate to the web service from your browser to save messages and read recent messages. Look at the traces displayed to see what's happening in the background.

Now go back to the Azure portal and regenerate the storage account keys. The web service will now fail to load or save messages, as expected. Read the trace messages to confirm this. Use Set-AzureKeyVaultSecret PowerShell cmdlet to update the secret stored in your vault. Notice the web service starts to work again without having to redeploy or reconfigure it.

[1]: http://manage.windowsazure.com
[2]: http://go.microsoft.com/fwlink/?LinkID=512410 
[3]: http://www.openssl.org/related/binaries.html
[4]: https://www.openssl.org/docs/apps/genrsa.html
[5]: https://www.openssl.org/docs/apps/req.html
[6]: https://www.openssl.org/docs/apps/x509.html
[7]: https://www.openssl.org/docs/apps/pkcs12.html
[8]: http://msdn.microsoft.com/en-us/library/vstudio/bfsktky3(v=vs.100).aspx
[9]: http://msdn.microsoft.com/en-us/library/azure/gg981929.aspx
