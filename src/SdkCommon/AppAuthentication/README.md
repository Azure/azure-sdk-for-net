## Microsoft.Azure.Services.AppAuthentication Library

### Purpose
Make it easy to authenticate to Azure Services (that support Azure AD Authentication), and help avoid credentials in source code and configuration files. 

Enables a service to authenticate to Azure services using the developer's Azure Active Directory/ Microsoft account during development, and authenticate as itself (using OAuth 2.0 Client Credentials flow) when deployed to Azure. This reduces the need to manually create and distribute Azure AD App Credentials amongst developers in the team, which is both cumbersome, and increases the risk of compromise of credentials. 

Provides a layer of abstraction over "get access token" to call Azure services (for service-to-service authentication scenarios), allowing for use of Visual Studio, Azure CLI, or Integrated Windows Authentication for local development, 
and automatic switch to use of Managed Service Identity (MSI) when deployed to Azure (App Service or Azure VM), without any code or configuration change. It also supports use of service principals for scenarios where MSI is not available, or where the developer's security context cannot be used during local development. 

### Documentation
Documentation can be found [here](https://go.microsoft.com/fwlink/p/?linkid=862452).

### Samples
1. [Fetch a secret from Azure Key Vault at run-time from an App Service with a Managed Service Identity (MSI).](https://github.com/Azure-Samples/app-service-msi-keyvault-dotnet)
2. [Programmatically deploy an ARM template from an Azure VM with a Managed Service Identity (MSI).](https://github.com/Azure-Samples/windowsvm-msi-arm-dotnet)
3. [.NET Core sample to programmatically call Azure Services from an Azure Linux VM with a Managed Service Identity.](https://github.com/Azure-Samples/linuxvm-msi-keyvault-arm-dotnet/)

### Code organization
The library is organized in these layers:
1. Calling application will call AzureServiceTokenProvider to get an access token to call an Azure Service. 
2. AzureServiceTokenProvider will check if the token is available in a global in-memory cache. If so, will return it. 
3. If not in cache, AzureServiceTokenProvider will call the next layer, which are a set of Token Providers. These are in the TokenProviders folder. 
4. Each of the token providers then use a client to get the token. The client layer consists of 
    1. A Process Manager for calling Azure CLI. **az account get-access-token --resource https://vault.azure.net/**
    2. ADAL for getting tokens using Client Secret, Certificate, or Integrated Windows Authentication.
    3. HttpClient to get token using MSI.

    The clients get the token from Azure AD, either directly (e.g. ADAL) or in-directly (MSI/ Azure CLI). The client layer is Mocked in the unit tests cases. 
 5. The token is returned up the layers and cached, before being returned to the calling application.

### Running test cases
**Unit Test Cases**

On Windows, open a command prompt, navigate to the unit test folder, and run **dotnet test**. This will run tests for both .NET 4.5.2 and .NET Standard 1.4. 

On Linux, open a command prompt, navigate to the unit test folder, and run **dotnet test -f netcoreapp1.1**. This will run tests for .NET Standard 1.4. 

**Integration Test Cases**

Integration test cases test the actual flow for Client Secret, Client Certificate, Azure CLI, and Integrated Windows Authentication. The Integrated Windows Authentication test can only be run on a domain joined machine, where domain is synced with Azure AD. 

Before running these test cases, ensure that you
1. Have Azure CLI 2.0 installed. 
2. Have logged into Azure CLI using **az login**
3. Set an environment variable named **AppAuthenticationTestCertUrl** to a certificate in Azure Key Vault e.g. https://myvault.vault.azure.net/secrets/cert1
   
   Integration test cases use AzureServiceTokenProvider itself to get a token for Graph API (using Azure CLI), to create Azure AD applications and service principals, and then test those flows. 
   
On Windows, open a command prompt, navigate to the integration test folder, and run **dotnet test**. This will run tests for both .NET 4.5.2 and .NET Standard 1.4. 

On Linux, open a command prompt, navigate to the integration test folder, and run **dotnet test -f netcoreapp1.1**. This will run tests for .NET Standard 1.4. 