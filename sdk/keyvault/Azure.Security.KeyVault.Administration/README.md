# Azure KeyVault Administration client library for .NET

Azure Key Vault Managed HSM is a fully-managed, highly-available, single-tenant, standards-compliant cloud service that enables you to safeguard
cryptographic keys for your cloud applications using FIPS 140-2 Level 3 validated HSMs.

The Azure Key Vault administration library clients support administrative tasks such as full backup / restore and key-level role-based access control (RBAC).

[Source code][admin_client_src] | [Package (NuGet)][admin_client_nuget_package] | [Product documentation][managedhsm_docs] | [Samples][admin_client_samples]

## Getting started

### Install the package

Install the Azure Key Vault administration client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Security.KeyVault.Administration
```

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Azure Key Vault. If you need to create an Azure Key Vault, you can use the [Azure CLI][azure_cli].
* Authorization to an existing Azure Key Vault using either [RBAC][rbac_guide] (recommended) or [access control][access_policy].

To create a Managed HSM resource, run the following CLI command:

```PowerShell
az keyvault create --hsm-name <your-key-vault-name> --resource-group <your-resource-group-name> --administrators <your-user-object-id> --location <your-azure-location>
```

To get `<your-user-object-id>` you can run the following CLI command:

```PowerShell
az ad user show --id <your-user-principal> --query id
```

### Authenticate the client

In order to interact with the Azure Key Vault service, you'll need to create an instance of the client classes below. You need a **vault url**, which you may see as "DNS Name" in the portal,
and credentials to instantiate a client object.

The examples shown below use a [`DefaultAzureCredential`][DefaultAzureCredential], which is appropriate for most scenarios including local development and production environments.
Additionally, we recommend using a managed identity for authentication in production environments.
You can find more information on different ways of authenticating and their corresponding credential types in the [Azure Identity][azure_identity] documentation.

To use the `DefaultAzureCredential` provider shown below,
or other credential providers provided with the Azure SDK, you must first install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

#### Activate your managed HSM

All data plane commands are disabled until the HSM is activated. You will not be able to create keys or assign roles.
Only the designated administrators that were assigned during the create command can activate the HSM. To activate the HSM you must download the security domain.

To activate your HSM you need:

* A minimum of 3 RSA key-pairs (maximum 10)
* Specify the minimum number of keys required to decrypt the security domain (quorum)

To activate the HSM you send at least 3 (maximum 10) RSA public keys to the HSM. The HSM encrypts the security domain with these keys and sends it back.
Once this security domain is successfully downloaded, your HSM is ready to use.
You also need to specify quorum, which is the minimum number of private keys required to decrypt the security domain.

The example below shows how to use openssl to generate 3 self-signed certificates.

```PowerShell
openssl req -newkey rsa:2048 -nodes -keyout cert_0.key -x509 -days 365 -out cert_0.cer
openssl req -newkey rsa:2048 -nodes -keyout cert_1.key -x509 -days 365 -out cert_1.cer
openssl req -newkey rsa:2048 -nodes -keyout cert_2.key -x509 -days 365 -out cert_2.cer
```

Use the `az keyvault security-domain download` command to download the security domain and activate your managed HSM.
The example below uses 3 RSA key pairs (only public keys are needed for this command) and sets the quorum to 2.

```PowerShell
az keyvault security-domain download --hsm-name <your-managed-hsm-name> --sd-wrapping-keys ./certs/cert_0.cer ./certs/cert_1.cer ./certs/cert_2.cer --sd-quorum 2 --security-domain-file ContosoMHSM-SD.json
```

#### Controlling access to your managed HSM

The designated administrators assigned during creation are automatically added to the "Managed HSM Administrators" [built-in role][built_in_roles],
who are able to download a security domain and [manage roles for data plane access][access_control], among other limited permissions.

To perform other actions on keys, you need to assign principals to other roles such as "Managed HSM Crypto User", which can perform non-destructive key operations:

```PowerShell
az keyvault role assignment create --hsm-name <your-managed-hsm-name> --role "Managed HSM Crypto User" --scope / --assignee-object-id <principal-or-user-object-ID> --assignee-principal-type <principal-type>
```

Please read [best practices][best_practices] for properly securing your managed HSM.

#### Create KeyVaultAccessControlClient

Instantiate a `DefaultAzureCredential` to pass to the `KeyVaultAccessControlClient`.
The same instance of a token credential can be used with multiple clients if they will be authenticating with the same identity.

```C# Snippet:HelloCreateKeyVaultAccessControlClient
KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

#### Create KeyVaultBackupClient

Instantiate a `DefaultAzureCredential` to pass to the `KeyVaultBackupClient`.
The same instance of a token credential can be used with multiple clients if they will be authenticating with the same identity.

```C# Snippet:HelloCreateKeyVaultBackupClient
KeyVaultBackupClient client = new KeyVaultBackupClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

#### Create KeyVaultSettingClient

Instantiate a `DefaultAzureCredential` to pass to the `KeyVaultSettingsClient`.
The same instance of a token credential can be used with multiple clients if they will be authenticating with the same identity.

```C# Snippet:KeyVaultSettingsClient_Create
KeyVaultSettingsClient client = new KeyVaultSettingsClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Key concepts

### KeyVaultRoleDefinition

A `KeyVaultRoleDefinition` is a collection of permissions. A role definition defines the operations that can be performed, such as read, write,
and delete. It can also define the operations that are excluded from allowed operations.

KeyVaultRoleDefinitions can be listed and specified as part of a `KeyVaultRoleAssignment`.

### KeyVaultRoleAssignment

A `KeyVaultRoleAssignment` is the association of a KeyVaultRoleDefinition to a service principal. They can be created, listed, fetched individually, and deleted.

### KeyVaultAccessControlClient

A `KeyVaultAccessControlClient` provides both synchronous and asynchronous operations allowing for management of `KeyVaultRoleDefinition` and `KeyVaultRoleAssignment` objects.

### KeyVaultBackupClient

A `KeyVaultBackupClient` provides both synchronous and asynchronous operations for performing full key backups, full key restores, and selective key restores.

### BackupOperation

A `BackupOperation` represents a long running operation for a full key backup.

### RestoreOperation

A `RestoreOperation` represents a long running operation for both a full key and selective key restore.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The Azure.Security.KeyVault.Administration package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the `client` created above for either [access control](#create-keyvaultaccesscontrolclient) or [backup](#create-keyvaultbackupclient) clients, covering some of the most common Azure Key Vault access control related tasks:

### Sync examples

* Access control
  * [Listing All Role Definitions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#listing-all-role-definitions)
  * [Listing All Role Assignments](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#listing-all-role-assignments)
  * [Creating a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#creating-a-role-assignment)
  * [Getting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#getting-a-role-assignment)
  * [Deleting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldSync.md#deleting-a-role-assignment)
* Backup and restore
  * [Performing a full key backup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldSync.md#performing-a-full-key-backup)
  * [Performing a full key restore](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldSync.md#performing-a-full-key-restore)

### Async examples

* Access control
  * [Listing All Role Definitions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#listing-all-role-definitions)
  * [Listing All Role Assignments](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#listing-all-role-assignments)
  * [Creating a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#creating-a-role-assignment)
  * [Getting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#getting-a-role-assignment)
  * [Deleting a Role Assignment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_RbacHelloWorldAsync.md#deleting-a-role-assignment)
* Backup and restore
  * [Performing a full key backup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldAsync.md#performing-a-full-key-backup)
  * [Performing a full key restore](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples/Sample1_BackupHelloWorldAsync.md#performing-a-full-key-restore)

## Troubleshooting

See our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/TROUBLESHOOTING.md)
for details on how to diagnose various failure scenarios.

### General

When you interact with the Azure Key Vault Administration library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

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

```text
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
To create an Azure SDK log listener that outputs messages to console, use the `AzureEventSourceListener.CreateConsoleLogger` method.

```c#
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
details, visit <https://cla.microsoft.com>.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact <opencode@microsoft.com> with any
additional questions or comments.

<!-- LINKS -->
[access_control]: https://learn.microsoft.com/azure/key-vault/managed-hsm/access-control
[access_policy]: https://learn.microsoft.com/azure/key-vault/general/assign-access-policy
[rbac_guide]: https://learn.microsoft.com/azure/key-vault/general/rbac-guide
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[best_practices]: https://learn.microsoft.com/azure/key-vault/managed-hsm/best-practices
[built_in_roles]: https://learn.microsoft.com/azure/key-vault/managed-hsm/built-in-roles
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[managedhsm_docs]: https://learn.microsoft.com/azure/key-vault/managed-hsm/
[keyvault_rest]: https://learn.microsoft.com/rest/api/keyvault/
[admin_client_nuget_package]: https://www.nuget.org/packages?q=Azure.Security.KeyVault.Administration
[admin_client_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Administration/samples
[admin_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Administration/src
[nuget]: https://www.nuget.org/
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftables%2FAzure.Data.Tables%2FREADME.png)
