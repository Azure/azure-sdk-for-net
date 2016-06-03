#Azure Key Vault .NET Sample Code

##Contents
1. \samples - Key Vault sample applications 
1. \scripts - PowerShell sample scripts for generating setting files 

##Pre-requisites
1. Visual Studio 2015 or Visual Studio 2013
2. Azure SDK 2.8 
3. Azure PowerShell version 1.0.0 or newer
4. NuGet version 2.7 or newer
5. nuget.org (https://www.nuget.org/api/v2/) should be an available package source in Visual Studio NuGet Package Manager settings
6. Active Azure subscription


> Please read the [documentation about Key Vault][2] to familiarize yourself with the basic concepts of Key Vault before running this sample application.

##Common steps for both samples - Create a X509 Certificate

To create a new X509 certificate, [makecert][8] or [openssl][3] can be used. For example, the following commands will generate a certificate file from a private key and a certificate signing request file:
	- openssl [genrsa][4] -des3 -out keyvault.key 2048
	- openssl [req][5] -new -key keyvault.key -out keyvault.csr
		- *Note: It is OK to choose the default answer for each question*
	- openssl [x509][6] -req -days 3000 -in keyvault.csr -signkey keyvault.key -out keyvault.cer
	- openssl [pkcs12][7] -export -out keyvault.pfx -inkey keyvault.key -in keyvault.cer
	Or use [makecert][8] from Developer Command Prompt for Visual Studio:
	- makecert -sv keyvault.pvk -n "CN=Key Vault Credentials" keyvault.cer -pe -len 2048 -a sha256
	    - Follow prompts
	- pvk2pfx -pvk keyvault.pvk -spc keyvault.cer -pfx keyvault.pfx -pi <pvk-password>
	- *Note:  The keyvault.cer file is a required input to the GetServiceConfigSettings.ps1 and GetAppConfigSettings.ps1 scripts* 

##Sample #1 - HelloKeyVault
A console application that walks through the key scenarios supported by Key Vault:

  1. Create/Import a key (HSM or software keys)
  2. Encrypt a secret using a content key
  3. Wrap the content key using a Key Vault key
  4. Unwrap the content key
  5. Decrypt the secret
  6. Set a secret

###Setup steps
Update the app configuration settings in HelloKeyVault\App.config with your vault URL, application principal ID and secret. The information can optionally be generated using *scripts\GetAppConfigSettings.ps1*. To use the sample script, follow these steps:
 1. Create a new X509 certificate or get an existing one to use as the Key Vault authentication certificate. See common steps above.
       - From explorer, right-click on the pfx file and click 'Install PFX'
       - Select 'Local Machine', accept all defaults. Confirm installed cert under Personal -> Certificates by running certlm.msc 
 2. Update the values of mandatory variables in GetAppConfigSettings.ps1
 3. Launch the Microsoft Azure PowerShell window
 4. Run the GetAppConfigSettings.ps1 script within the Microsoft Azure PowerShell window
 5. Copy the results of the script into the HelloKeyVault\App.config file

###Running the sample application
Once the setup steps are completed, build and run the HelloKeyVault.exe program.  Observe the results printed out in the command line window.

##Sample #2 - SampleAzureWebService

This sample app demonstrates how an Azure web service can retrieve application secrets like passwords or storage account credentials from Key Vault at run-time.  This eliminates the need to package secret values with the deployment package.  This sample app also demonstrates managing a single bootstrapping X509 certificate that is used to authenticate with the Key Vault.


The web app presents an online message board to users and uses an Azure storage account to persist the message board contents.  The storage account access key is retrieved from the Key Vault service at run-time.

The web app also demonstrates secret caching using a custom configuration manager. The configuration manager handles resolving a secret ID to a corresponding secret value and caching the secret value for a specified period of time. It also caches service configuration settings and refreshes them when updated.

###Setup steps
1. Create a new X509 certificate or get an existing one to use as the Key Vault authentication certificate. See common steps above.
	
2. Create a new Azure cloud service in the [Azure management portal][1].  Upload the PFX file for the certificate you just created into the certificate tab for the cloud service. For instructions see step 3 in [service certificate][9].
3. Create a new Azure storage account in the [Azure management portal][1].  Remember the storage account name -- you'll need it as an input parameter for the GetServiceConfigSettings.ps1 script.
4. Update the service configuration settings in ServiceConfiguration.Cloud.cscfg by providing:
	- Key Vault authentication certificate thumbprint (you can find the thumbprint in the 'detailed' tab of the certificate).
	- Name of the storage account to store messages in.
	- URI to a Key Vault secret, containing a storage account key. 
	- Duration that the secret should be cached (e.g. 00:20:00).
	- Client ID of the application that you have registered in Azure Active Directory with X509 certificate based credentials.
   
	For step 4 the service configuration settings can be generated using *scripts\GetServiceConfigSettings.ps1*. To use the sample script, follow these steps:

	 1. Update the values of mandatory variables in GetServiceConfigSettings.ps1
	 2. Launch the Microsoft Azure PowerShell window
	 3. Run the GetServiceConfigSettings.ps1 script within the Microsoft Azure PowerShell window
	 4. Copy the results of the script into both CSCFG files in the project



###Running the sample application

Once the setup steps are completed, build and publish the web service to the Azure cloud service created in the setup steps.  Note that the service configuration file and the package used to publish contain no secret values.

>NOTE: You can also deploy the application locally, to the Azure Compute Emulator. In this case, the Key Vault authentication certificate with the private key must be installed in the local machine's Personal certificate store.

Navigate to the web service from your browser to save messages and read recent messages. Look at the traces displayed to see what's happening in the background.


###Updating the app's secret values

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
[3]: http://www.openssl.org/related/binaries.html
[4]: https://www.openssl.org/docs/apps/genrsa.html
[5]: https://www.openssl.org/docs/apps/req.html
[6]: https://www.openssl.org/docs/apps/x509.html
[7]: https://www.openssl.org/docs/apps/pkcs12.html
[8]: http://msdn.microsoft.com/en-us/library/vstudio/bfsktky3(v=vs.100).aspx
[9]: https://azure.microsoft.com/en-us/documentation/articles/cloud-services-configure-ssl-certificate/

