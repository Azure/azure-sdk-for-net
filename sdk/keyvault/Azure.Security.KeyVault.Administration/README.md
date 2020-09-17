# Azure KeyVault Administration client library for .NET

Azure Key Vault is a cloud service for securely storing and accessing secrets. A secret is anything to which you want to tightly control 
access, such as API keys, passwords, or certificates. A vault is a logical group of secrets.

The Azure Key Vault administration library clients support administrative tasks such as full backup / restore and key-level role-based access control (RBAC).

[Source code][admin_client_src] | [Package (NuGet)][admin_client_nuget_package] | [Product documentation][keyvault_docs] | [Samples][admin_client_samples]

## Getting started

### Install the package
Install the Azure Key Vault administration client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet install Azure.Security.KeyVault.Administration --version 4.0.0-beta.1
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure Key Vault. If you need to create an Azure Key Vault, you can use the [Azure CLI][azure_cli].

See the final two steps in the next section for details on creating the Key Vault with the Azure CLI.

### Authenticate the client
In order to control permissions to the Key Vault service, you'll need to create an instance of the [KeyVaultAccessControlClient][rbac_client] class. 
You need a **vault URL**, which you may see as "DNS Name" in the portal,  and **client secret credentials (client id, client secret, tenant id)** 
to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with 
[Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
dotnet install Azure.Identity
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
        "displayName": "some-app-name",
        "name": "http://some-app-name",
        "password": "random-password",
        "tenant": "tenant-ID"
    }
    ```
* Take note of the service principal objectId
    ```PowerShell
    az ad sp show --id <appId> --query objectId
    ```
    Output:
    ```
    "<your-service-principal-object-id>"
    ```
* Use the returned credentials above to set  **AZURE_CLIENT_ID** (appId), **AZURE_CLIENT_SECRET** (password), and **AZURE_TENANT_ID** (tenant) 
environment variables. The following example shows a way to do this in Powershell:
    ```PowerShell
    $Env:AZURE_CLIENT_ID="generated-app-ID"
    $Env:AZURE_CLIENT_SECRET="random-password"
    $Env:AZURE_TENANT_ID="tenant-ID"
    ```

* Create the Key Vault and grant the above mentioned application authorization to perform administrative operations on the Azure Key Vault 
(replace `<your-resource-group-name>` and `<your-key-vault-name>` with your own, unique names and `<your-service-principal-object-id>` with the value from above):
    ```
    az keyvault create --hsm-name <your-key-vault-name> --resource-group <your-resource-group-name> --administrators <your-service-principal-object-id> --location <your-azure-location>
    ```

* Use the above mentioned Azure Key Vault name to retrieve details of your Vault which also contains your Azure Key Vault URL:
    ```PowerShell
    az keyvault show --hsm-name <your-key-vault-name>
    ```

#### Create KeyVaultAccessControlClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** 
with the above returned URI, you can create the [KeyVaultAccessControlClient][rbac_client]:

```C# Snippet:HelloCreateKeyVaultAccessControlClient
KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

#### Create KeyVaultBackupClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** 
with the above returned URI, you can create the [KeyVaultBackupClient][backup_client]:

```C# Snippet:HelloCreateKeyVaultBackupClient
KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Key concepts

### KeyVaultRoleDefinition
A `KeyVaultRoleDefinition` is a collection of permissions. A role definition defines the operations that can be performed, such as read, write, 
and delete. It can also define the operations that are excluded from allowed operations.

KeyVaultRoleDefinitions can be listed and specified as part of a `KeyVaultRoleAssignment`.

### KeyVaultRoleAssignment. 
A `KeyVaultRoleAssignment` is the association of a KeyVaultRoleDefinition to a service principal. They can be created, listed, fetched individually, and deleted.

### KeyVaultAccessControlClient
A `KeyVaultAccessControlClient` provides both synchronous and asynchronous operations allowing for management of `KeyVaultRoleDefinition` and `KeyVaultRoleAssignment` objects.

### KeyVaultBackupClient

A `KeyVaultBackupClient` provides both synchronous and asynchronous operations for performing full key backups, full key restores, and selective key restores.

### BackupOperation

A `BackupOperation` represents a long running operation for a full key backup.

### RestoreOperation

A `RestoreOperation` represents a long running operation for both a full key and selective key restore.

## Examples
The Azure.Security.KeyVault.Administration package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the `client` created above for either [access control](#create-keyvaultaccesscontrolclient) or [backup](#create-KeyVaultBackupClient) clients, covering some of the most common Azure Key Vault access control related tasks:

### Sync examples
- Access control
    - [Listing All Role Definitions](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#listing-all-role-definitions-sync)
    - [Listing All Role Assignments](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#listing-all-role-assignments)
    - [Creating a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#creating-a-role-assignment)
    - [Getting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#getting-a-role-assignment)
    - [Deleting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#deleting-a-role-assignment)
- Backup and restore
    - [Performing a full key backup](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldSync.md#performing-a-full-key-backup)
    - [Performing a full key restore](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldSync.md#performing-a-full-key-restore)

### Async examples
- Access control
    - [Listing All Role Definitions](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#listing-all-role-definitions-sync)
    - [Listing All Role Assignments](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#listing-all-role-assignments)
    - [Creating a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#creating-a-role-assignment)
    - [Getting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#getting-a-role-assignment)
    - [Deleting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#deleting-a-role-assignment)
- Backup and restore
    - [Performing a full key backup](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldAsync.md#performing-a-full-key-backup)
    - [Performing a full key restore](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldAsync.md#performing-a-full-key-restore)

## Troubleshooting

When you interact with the Azure Key Vault administration library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a role assignment that doesn't exist in your Azure Key Vault, a `404` error is returned, indicating "Not Found".

```C# Snippet:RoleAssignmentNotFound
try
{
    KeyVaultRoleAssignment roleAssignment = client.GetRoleAssignment(KeyVaultRoleScope.Global, "example-name");
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

```
Azure.RequestFailedException: Service request failed.
Status: 404 (Not Found)

Content:
{"error":{"code":"RoleAssignmentNotFound","message":"Requested role assignment not found (Activity ID: a67f09f4-b68e-11ea-bd6d-0242ac120006)"}}

Headers:
X-Content-Type-Options: REDACTED
x-ms-request-id: a67f09f4-b68e-11ea-bd6d-0242ac120006
Content-Length: 143
Content-Type: application/json
```

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Get started with our [samples][admin_client_samples].

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[azure_sub]: https://azure.microsoft.com/free/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[rbac_client]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/src/KeyVaultAccessControlClient.cs
[backup_client]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Administration/src/KeyVaultBackupClient.cs
[keyvault_docs]: https://docs.microsoft.com/azure/key-vault/
[keyvault_rest]: https://docs.microsoft.com/rest/api/keyvault/
[admin_client_nuget_package]: https://www.nuget.org/packages?q=Azure.Security.KeyVault.Administration
[admin_client_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Administration/samples
[admin_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Administration/src
[JWK]: https://tools.ietf.org/html/rfc7517
[nuget]: https://www.nuget.org/
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Microsoft.Azure.KeyVault/CONTRIBUTING.md


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftables%2FAzure.Data.Tables%2FREADME.png)
