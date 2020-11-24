# Azure Key Vault Certificate client library for .NET
Azure Key Vault is a cloud service that provides secure storage and automated management of certificates used throughout a cloud application. Multiple certificates, and multiple versions of the same certificate, can be kept in the Azure Key Vault. Each certificate in the vault has a policy associated with it which controls the issuance and lifetime of the certificate, along with actions to be taken as certificates near expiry.

The Azure Key Vault certificates client library enables programmatically managing certificates, offering methods to create, update, list, and delete certificates, policies, issuers, and contacts. The library also supports managing pending certificate operations and management of deleted certificates.

[Source code][certificate_client_src] | [Package (NuGet)][certificate_client_nuget_package] | [API reference documentation][API_reference] | [Product documentation][keyvault_docs] | [Samples][certificate_client_samples] | [Migration guide][migration_guide]

## Getting started

### Install the package
Install the Azure Key Vault certificates client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Security.KeyVault.Certificates --version 4.2.0-beta.3
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure Key Vault. If you need to create an Azure Key Vault, you can use the Azure Portal or [Azure CLI][azure_cli].

If you use the Azure CLI, replace `<your-resource-group-name>` and `<your-key-vault-name>` with your own, unique names:

```PowerShell
az keyvault create --resource-group <your-resource-group-name> --name <your-key-vault-name>
```

### Authenticate the client
In order to interact with the Azure Key Vault service, you'll need to create an instance of the [CertificateClient][certificate_client_class] class. You need a **vault url**, which you may see as "DNS Name" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
dotnet add package Azure.Identity
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
* Use the returned credentials above to set  **AZURE_CLIENT_ID** (appId), **AZURE_CLIENT_SECRET** (password), and **AZURE_TENANT_ID** (tenant) environment variables. The following example shows a way to do this in Powershell:
    ```PowerShell
    $Env:AZURE_CLIENT_ID="generated-app-ID"
    $Env:AZURE_CLIENT_SECRET="random-password"
    $Env:AZURE_TENANT_ID="tenant-ID"
    ```

* Grant the above mentioned application authorization to perform certificate operations on the Azure Key Vault:
    ```PowerShell
    az keyvault set-policy --name <your-key-vault-name> --spn $Env:AZURE_CLIENT_ID --certificate-permissions backup delete get list create update purge
    ```
    > --certificate-permissions:
    > Allowed values: backup, create, delete, deleteissuers, get, getissuers, import, list, listissuers, managecontacts, manageissuers, purge, recover, restore, setissuers, update.

* Use the above mentioned Azure Key Vault name to retrieve details of your Vault which also contains your Azure Key Vault URL:
    ```PowerShell
    az keyvault show --name <your-key-vault-name>
    ```

#### Create CertificateClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** with the above returned URI, you can create the [CertificateClient][certificate_client_class]:

```C# Snippet:CreateCertificateClient
// Create a new certificate client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
var client = new CertificateClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
```

## Key concepts
### KeyVaultCertificate
A `KeyVaultCertificate` is the fundamental resource within Azure Key Vault. You'll use certificates to encrypt and verify encrypted or signed data.

### CertificateClient
With a `CertificateClient` you can get certificates from the vault, create new certificates and
new versions of existing certificates, update certificate metadata, and delete certificates. You
can also manage certificate issuers, contacts, and management policies of certificates. This is
illustrated in the examples below.

## Examples
The Azure.Security.KeyVault.Certificates package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the `client`[created above](#create-certificateclient), covering some of the most common Azure Key Vault certificate service related tasks:

### Sync examples
* [Create a certificate](#create-a-certificate)
* [Retrieve a certificate](#retrieve-a-certificate)
* [Update an existing certificate](#update-an-existing-certificate)
* [List certificates](#list-certificates)
* [Delete a certificate](#delete-a-certificate)

### Async examples
* [Create a certificate asynchronously](#create-a-certificate-asynchronously)
* [List certificates asynchronously](#list-certificates-asynchronously)
* [Delete a certificate asynchronously](#delete-a-certificate-asynchronously)

### Create a certificate
`StartCreateCertificate` creates a certificate to be stored in the Azure Key Vault. If a certificate with 
the same name already exists, then a new version of the certificate is created.
When creating the certificate the user can specify the policy which controls the certificate lifetime. If no policy is specified the default policy will be used. The `StartCreateCertificate` operation returns a `CertificateOperation`. The following example creates a self-signed certificate with the default policy.

```C# Snippet:CreateCertificate
// Create a certificate. This starts a long running operation to create and sign the certificate.
CertificateOperation operation = client.StartCreateCertificate("MyCertificate", CertificatePolicy.Default);

// You can await the completion of the create certificate operation.
// You should run UpdateStatus in another thread or do other work like pumping messages between calls.
while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}

KeyVaultCertificateWithPolicy certificate = operation.Value;
```

> NOTE: Depending on the certificate issuer and validation methods, certificate creation and signing can take an indeterminate amount of time. Users should only wait on certificate operations when the operation can be reasonably completed in the scope of the application, such as with self-signed certificates or issuers with well known response times.

### Retrieve a certificate
`GetCertificate` retrieves the latest version of a certificate stored in the Azure Key Vault along with its `CertificatePolicy`.

```C# Snippet:RetrieveCertificate
KeyVaultCertificateWithPolicy certificateWithPolicy = client.GetCertificate("MyCertificate");
```

`GetCertificateVersion` retrieves a specific version of a certificate in the vault.

```C# Snippet:GetCertificate
KeyVaultCertificate certificate = client.GetCertificateVersion(certificateWithPolicy.Name, certificateWithPolicy.Properties.Version);
```

### Update an existing certificate
`UpdateCertificate` updates a certificate stored in the Azure Key Vault.

```C# Snippet:UpdateCertificate
CertificateProperties certificateProperties = new CertificateProperties(certificate.Id);
certificateProperties.Tags["key1"] = "value1";

KeyVaultCertificate updated = client.UpdateCertificateProperties(certificateProperties);
```

### List certificates
`GetCertificates` enumerates the certificates in the vault, returning select properties of the
certificate. Sensitive fields of the certificate will not be returned. This operation
requires the certificates/list permission.
  
```C# Snippet:ListCertificates
Pageable<CertificateProperties> allCertificates = client.GetPropertiesOfCertificates();

foreach (CertificateProperties certificateProperties in allCertificates)
{
    Console.WriteLine(certificateProperties.Name);
}
```

### Delete a certificate
`DeleteCertificate` deletes all versions of a certificate stored in the Azure Key Vault. When [soft-delete][soft_delete] 
is not enabled for the Azure Key Vault, this operation permanently deletes the certificate. If soft delete is enabled the certificate is marked for deletion and can be optionally purged or recovered up until its scheduled purge date.

```C# Snippet:DeleteAndPurgeCertificate
DeleteCertificateOperation operation = client.StartDeleteCertificate("MyCertificate");

// You only need to wait for completion if you want to purge or recover the certificate.
// You should call `UpdateStatus` in another thread or after doing additional work like pumping messages.
while (!operation.HasCompleted)
{
    Thread.Sleep(2000);

    operation.UpdateStatus();
}

DeletedCertificate certificate = operation.Value;
client.PurgeDeletedCertificate(certificate.Name);
```

### Create a certificate asynchronously
The asynchronous APIs are identical to their synchronous counterparts, but return with the typical "Async" suffix for asynchronous methods and return a `Task`.

This example creates a certificate in the Azure Key Vault with the specified optional arguments.

```C# Snippet:CreateCertificateAsync
// Create a certificate. This starts a long running operation to create and sign the certificate.
CertificateOperation operation = await client.StartCreateCertificateAsync("MyCertificate", CertificatePolicy.Default);

// You can await the completion of the create certificate operation.
KeyVaultCertificateWithPolicy certificate = await operation.WaitForCompletionAsync();
```

### List certificates asynchronously
Listing certificate does not rely on awaiting the `GetPropertiesOfCertificatesAsync` method, but returns an `AsyncPageable<CertificateProperties>` that you can use with the `await foreach` statement:

```C# Snippet:ListCertificatesAsync
AsyncPageable<CertificateProperties> allCertificates = client.GetPropertiesOfCertificatesAsync();

await foreach (CertificateProperties certificateProperties in allCertificates)
{
    Console.WriteLine(certificateProperties.Name);
}
```

### Delete a certificate asynchronously
When deleting a certificate asynchronously before you purge it, you can await the `WaitForCompletionAsync` method on the operation.
By default, this loops indefinitely but you can cancel it by passing a `CancellationToken`.

```C# Snippet:DeleteAndPurgeCertificateAsync
DeleteCertificateOperation operation = await client.StartDeleteCertificateAsync("MyCertificate");

// You only need to wait for completion if you want to purge or recover the certificate.
await operation.WaitForCompletionAsync();

DeletedCertificate certificate = operation.Value;
await client.PurgeDeletedCertificateAsync(certificate.Name);
```

## Troubleshooting

### General
When you interact with the Azure Key Vault certificates client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a Key that doesn't exist in your Azure Key Vault, a `404` error is returned, indicating `Not Found`.

```C# Snippet:CertificateNotFound
try
{
    KeyVaultCertificateWithPolicy certificateWithPolicy = client.GetCertificate("SomeCertificate");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
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
Several Azure Key Vault certificates client library samples are available to you in this GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Azure Key Vault:
* [Sample1_HelloWorld.md][hello_world_sample] - for working with Azure Key Vault certificates, including:
  * Create a certificate
  * Get an existing certificate
  * Update an existing certificate
  * Delete a certificate

* [Sample2_GetCertificates.md][get_cetificates_sample] - Example code for working with Azure Key Vault certificates, including:
  * Create certificates
  * List all certificates in the Key Vault
  * List versions of a specified certificate
  * Delete certificates from the Key Vault
  * List deleted certificates in the Key Vault

 ###  Additional Documentation
* For more extensive documentation on Azure Key Vault, see the [API reference documentation][keyvault_rest].
* For Secrets client library see [Secrets client library][secrets_client_library].
* For Keys client library see [Keys client library][keys_client_library].

## Contributing
See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to these libraries.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact opencode@microsoft.com with any additional questions or comments.

<!-- LINKS -->
[certificate_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/src
[certificate_client_nuget_package]: https://www.nuget.org/packages/Azure.Security.KeyVault.Certificates/
[API_reference]: https://docs.microsoft.com/dotnet/api/azure.security.keyvault.certificates
[keyvault_docs]: https://docs.microsoft.com/azure/key-vault/
[certificate_client_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/samples
[nuget]: https://www.nuget.org/
[azure_sub]: https://azure.microsoft.com/free/
[azure_cli]: https://docs.microsoft.com/cli/azure
[certificate_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/src/CertificateClient.cs
[soft_delete]: https://docs.microsoft.com/azure/key-vault/key-vault-ovw-soft-delete
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity#defaultazurecredential
[keyvault_rest]: https://docs.microsoft.com/rest/api/keyvault/
[secrets_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets
[keys_client_library]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys
[hello_world_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/samples/Sample1_HelloWorld.md
[get_cetificates_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/samples/Sample2_GetCertificates.md
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/CONTRIBUTING.md
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Certificates/MigrationGuide.md

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fkeyvault%2FAzure.Security.KeyVault.Certificates%2FREADME.png)
