# Azure Key Vault Certificate client library for .NET
Azure Key Vault is a cloud service that provides secure storage and automated management of certificates used throughout a cloud application. Multiple certificate, and multiple versions of the same certificate, can be kept in the Key Vault. Each certificate in the vault has a policy associated with it which controls the issuance and lifetime of the certificate, along with actions to be taken as certificates near expiry.

The Azure Key Vault Certificate client library enables programmatically managing certificates, offering methods to create, update, list and delete certificates, policies, issuers and contacts. The library also supports managing pending certificate operations, and management of deleted certificates.

[Source code][certificate_client_src] | [Package (NuGet)][certificate_client_nuget_package] | [API reference documentation][API_reference] | [Product documentation][keyvault_docs] | [Samples][certificate_client_samples]

## Getting started

### Install the package
Install the Azure Key Vault Keys client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Security.KeyVault.Keys -IncludePrerelease
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Key Vault. If you need to create a Key Vault, you can use the Azure Portal or [Azure CLI][azure_cli].

If you use the Azure CLI, replace `<your-resource-group-name>` and `<your-key-vault-name>` with your own, unique names:

```PowerShell
az keyvault create --resource-group <your-resource-group-name> --name <your-key-vault-name>
```

 #### Create/Get credentials
Use the [Azure CLI][azure_cli] snippet below to create/get client secret credentials.

 * Create a service principal and configure its access to Azure resources:
    ```PowerShell
    az ad sp create-for-rbac -n <your-application-name> --skip-assignment
    ```
    Output:
    ```json
    {
        "appId": "generated-app-ID",
        "displayName": "dummy-app-name",
        "name": "http://dummy-app-name",
        "password": "random-password",
        "tenant": "tenant-ID"
    }
    ```
* Use the returned credentials above to set  **AZURE_CLIENT_ID**(appId), **AZURE_CLIENT_SECRET**(password) and **AZURE_TENANT_ID**(tenant) environment variables. The following example shows a way to do this in Powershell:
    ```PowerShell
    $Env:AZURE_CLIENT_ID="generated-app-ID"
    $Env:AZURE_CLIENT_SECRET="random-password"
    $Env:AZURE_TENANT_ID="tenant-ID"
    ```

* Grant the above mentioned application authorization to perform key operations on the key vault:
    ```PowerShell
    az keyvault set-policy --name <your-key-vault-name> --spn $AZURE_CLIENT_ID --key-permissions backup delete get list create
    ```
    > --key-permissions:
    > Accepted values: backup, create, decrypt, delete, encrypt, get, import, list, purge, recover, restore, sign, unwrapKey, update, verify, wrapKey

* Use the above mentioned Key Vault name to retrieve details of your Vault which also contains your Key Vault URL:
    ```PowerShell
    az keyvault show --name <your-key-vault-name> 
    ```

#### Create KeyClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** with the above returned URI, you can create the [CertificateClient][certificate_client_class]:

```c#
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;

// Create a new key client using the default credential from Azure.Identity
var client = new CertificateClient(vaultUri: <your-vault-url>, credential: new DefaultAzureCredential());
```
## Key concepts
With a `CertificateClient` you can get certificates from the vault, create new certificates and 
new versions of existing certificates, update certificate metadata, and delete certificates. You 
can also manage certificate issuers, contacts, and management policies of certificates. This is 
illustrated in the examples below.

## Examples
This section contains code snippets covering common tasks:
* [Create a Certificate](#create-a-certificate)
* [Retrieve a Certificate](#retrieve-a-certificate)
* [Update an existing Certificate](#update-an-existing-certificate)
* [Delete a Certificate](#delete-a-certificate)
* [List Certificates](#list-certificates)

### Create a Certificate
`StartCreateCertificate` creates a Certificate to be stored in the Azure Key Vault. If a certificate with 
the same name already exists, then a new version of the certificate is created.
When creating the certificate the user can specify the policy which controls the certificate lifetime. If no policy is speicired the default policy will be used. The `StartCreateCertificate` operation returns a `CertificateOperation`. The following example creates a self signed certificate with the default policy.
```c#
// create a certificate, this starts a long running operation to create and sign the certificate
CertificateOperation operation = await Client.StartCreateCertificateAsync("MyCertificate");

// optionally you can await the completion of the certificate opteration
// NOTE: 
CertificateWithPolicy certificate = await WaitForCompletion(operation);
```

> NOTE: Depending on the certificate issuer and validation methods, certificate creation and signing can take an indeterministic amount of time. Users should only wait on certificate operations when the operation can be reasonably completed in the scope of the application, such as with self signed certificates or issuers with well known response times.

### Retrieve a Certificate
`GetCertificateWithPolicy` retrieves the latest version of a certificate stored in the Key Vault along with its `CertificatePolicy`.
```c#
CertificateWithPolicy certificateWithPolicy = await Client.GetCertificateWithPolicyAsync("MyCertificate");
```

`GetCertificate` retrieves a specific version of a certificate in the vault.
```c#
Certificate certificate = await Client.GetCertificateAsync(certificateWithPolicy.Name, certificateWithPolicy.Version);
```
### Update an existing Certificate
`UpdateCertificate` updates a certificate stored in the Key Vault.
```c#
IDictionary<string, string> tags = new Dictionary<string, string>() { { "key1", "value1" } };

Certificate updated = await Client.UpdateCertificateAsync(certName, certVersion, tags: expTags);
```

### Delete a Certificate
`delete_certificate` deletes all versions of a certificate stored in the Key Vault. When [soft-delete][soft_delete] 
is not enabled for the Key Vault, this operation permanently deletes the certificate. If soft delete is enabled the certificate is marked for deletion and can be optionally purged or recovered up until its scheduled purge date.
```c#
DeletedCertificate deletedCert = await Client.DeleteCertificateAsync(certName);

Console.WriteLine(deletedCert.ScheduledPurgeDate);

await Client.PurgeDeletedCertificate(certName);
```

## Troubleshooting

### General
When you interact with the Azure Key Vault Key client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a Key that doesn't exist in your Key Vault, a `404` error is returned, indicating `Not Found`.

```c#
try
{
  Key key = await Client.GetCertficateAsync("MyCertificate");
}
catch (RequestFailedException ex)
{
  System.Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the Client Request ID of the operation.

```
Message: 
    Azure.RequestFailedException : Service request failed.
    Status: 404 (Not Found) 
Content:
    {"error":{"code":"CertificateNotFound","message":"Certificate not found: MyCertificate"}}
    
Headers:
    Cache-Control: no-cache
    Pragma: no-cache
    Server: Microsoft-IIS/10.0
    x-ms-keyvault-region: westus
    x-ms-request-id: 625f870e-10ea-41e5-8380-282e5cf768f2
    x-ms-keyvault-service-version: 1.1.0.866
    x-ms-keyvault-network-info: addr=131.107.174.199;act_addr_fam=InterNetwork;
    X-AspNet-Version: 4.0.30319
    X-Powered-By: ASP.NET
    Strict-Transport-Security: max-age=31536000;includeSubDomains
    X-Content-Type-Options: nosniff
    Date: Tue, 18 Jun 2019 16:02:11 GMT
    Content-Length: 75
    Content-Type: application/json; charset=utf-8
    Expires: -1
```
## Next steps
Key Vault Certificates client library samples are available to you in this GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Key Vault:
* [HelloWorld.cs][hello_world_sync] and [HelloWorldAsync.cs][hello_world_async] - for working with Azure Key Vault, including:
  * Create a certificate
  * Get an existing certificate
  * Update an existing certificate
  * Delete a certificate

* [GetCertificates.cs][get_cetificates_sync] and [GetCertificatesAsync.cs][get_cetificates_async] - Example code for working with Key Vault certificates, including:
  * Create certificates
  * List all certificates in the Key Vault
  * List versions of a specified certificate
  * Delete certificates from the Key Vault
  * List deleted certificates in the Key Vault

 ###  Additional Documentation
- For more extensive documentation on Azure Key Vault, see the [API reference documentation][keyvault_rest].
- For Secrets client library see [Secrets client library][secrets_client_library].
- For Keys client library see [Keys client library][keys_client_library].


<!-- LINKS -->
[certificate_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/src
[certificate_client_nuget_package]: https://www.nuget.org/packages/Azure.Security.KeyVault.Certificate/
[API_reference]: https://azure.github.io/azure-sdk-for-net/api/KeyVault/Azure.Security.KeyVault.Certificates.html
[keyvault_docs]: https://docs.microsoft.com/en-us/azure/key-vault/
[certificate_client_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/samples
[nuget]: https://www.nuget.org/
[azure_sub]: https://azure.microsoft.com/free/
[azure_cli]: https://docs.microsoft.com/cli/azure
[certificate_client_class]: src/CertificateClient.cs
[soft_delete]: https://docs.microsoft.com/en-us/azure/key-vault/key-vault-ovw-soft-delete
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[keyvault_rest]: https://docs.microsoft.com/en-us/rest/api/keyvault/
[secrets_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets
[keys_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys
[get_cetificates_async]: samples/Sample2_GetCertificatesAsync.cs
[get_cetificates_sync]: samples/Sample2_GetCertificates.cs

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fkeyvault%2FAzure.Security.KeyVault.Keys%2FFREADME.png)
