# Azure KeyVault Administration client library for .NET

Azure Key Vault is a cloud service for securely storing and accessing secrets. A secret is anything that you want to tightly control access to, such as API keys, passwords, or certificates. A vault is a logical group of secrets.

The Azure Key Vault administration library clients support administrative tasks such as full backup / restore and key-level role-based access control (RBAC).

## Getting started

### Install the package
Install the Azure Key Vault administration client library for .NET with [NuGet][nuget]:

```PowerShell
Install-Package Azure.Security.KeyVault.Administration --version 4.2.0-preview.1
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure Key Vault. If you need to create an Azure Key Vault, you can use the [Azure CLI][azure_cli].

See the final two steps in the next section for details on creating the Key Vault with the Azure CLI.

### Authenticate the client
In order to interact with the Key Vault service, you'll need to create an instance of the [KeyVaultAccessControlClient][rbac_client] class. You need a **vault url**, which you may see as "DNS Name" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
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
* Use the returned credentials above to set  **AZURE_CLIENT_ID** (appId), **AZURE_CLIENT_SECRET** (password), and **AZURE_TENANT_ID** (tenant) environment variables. The following example shows a way to do this in Powershell:
    ```PowerShell
    $Env:AZURE_CLIENT_ID="generated-app-ID"
    $Env:AZURE_CLIENT_SECRET="random-password"
    $Env:AZURE_TENANT_ID="tenant-ID"
    ```

* Create the Key Vault and grant the above mentioned application authorization to perform administrative operations on the Azure Key Vault (replace `<your-resource-group-name>` and `<your-key-vault-name>` with your own, unique names and `<your-service-principal-object-id>` with the value from above):
    ```
    az keyvault create --hsm-name <your-key-vault-name> --resource-group <your-resource-group-name> --administrators <your-service-principal-object-id> --location <your-azure-location>
    ```

* Use the above mentioned Azure Key Vault name to retrieve details of your Vault which also contains your Azure Key Vault URL:
    ```PowerShell
    az keyvault show --hsm-name <your-key-vault-name>
    ```

#### Create KeyVaultAccessControlClient
Once you've populated the **AZURE_CLIENT_ID**, **AZURE_CLIENT_SECRET** and **AZURE_TENANT_ID** environment variables and replaced **your-vault-url** with the above returned URI, you can create the [KeyVaultAccessControlClient][rbac_client]:

```C# Snippet:CreateKeyVaultAccessControlClient
// Create a new access control client using the default credential from Azure.Identity using environment variables previously set,
// including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

// Retrieve all the role definitions.
List<RoleDefinition> roleDefinitions = client.GetRoleDefinitions(RoleAssignmentScope.Global).ToList();

// Retrieve all the role assignments.
List<RoleAssignment> roleAssignments = client.GetRoleAssignments(RoleAssignmentScope.Global).ToList();
```

## Key concepts

### RoleDefinition
A `RoleDefinition` is a collection of permissions. A role definition defines the operations that can be performed, such as read, write, and delete. It can also define the operations that are excluded from allowed operations.

RoleDefinitions can be listed and specified as part of a `RoleAssignment`.

### RoleAssignment. 
A `RoleAssignment` is the association of a RoleDefinition to a service principal. They can be created, listed, fetched individually, and deleted.

### KeyVaultAccessControlClient
A `KeyVaultAccessControlClient` provides both synchronous and asynchronous operations allowing for management of `RoleDefinition` and `RoleAssignment` objects.

## Examples
The Azure.Security.KeyVault.Administration package supports synchronous and asynchronous APIs.

The following section provides several code snippets using the `client` [created above](#create-keyvaultaccesscontrolclient), covering some of the most common Azure Key Vault access control related tasks:

### List the role definitions
List the role definitions available for assignment.

```C# Snippet:GetRoleDefinitions
Pageable<RoleDefinition> allDefinitions = client.GetRoleDefinitions(RoleAssignmentScope.Global);

foreach (RoleDefinition roleDefinition in allDefinitions)
{
    Console.WriteLine(roleDefinition.Id);
    Console.WriteLine(roleDefinition.RoleName);
    Console.WriteLine(roleDefinition.Description);
    Console.WriteLine();
}
```

### Create, Get, and Delete a role assignment
Assign a role to a service principal. This will require a role definition id from the list retrieved in the [above snippet](#list-the-role-definitions) and the principal object id retrieved in the [Create/Get credentials](#create/get-credentials)

```C# Snippet:ReadmeCreateRoleAssignment
// Replace <roleDefinitionId> with a role definition Id from the definitions returned from the List the role definitions section above
string definitionIdToAssign = "<roleDefinitionId>";

// Replace <objectId> with the service principal object id from the Create/Get credentials section above
string servicePrincipalObjectId = "<objectId>";

RoleAssignmentProperties properties = new RoleAssignmentProperties(definitionIdToAssign, servicePrincipalObjectId);
RoleAssignment createdAssignment = client.CreateRoleAssignment(RoleAssignmentScope.Global, properties);

Console.WriteLine(createdAssignment.Name);
Console.WriteLine(createdAssignment.Properties.PrincipalId);
Console.WriteLine(createdAssignment.Properties.RoleDefinitionId);

RoleAssignment fetchedAssignment = client.GetRoleAssignment(RoleAssignmentScope.Global, createdAssignment.Name);

Console.WriteLine(fetchedAssignment.Name);
Console.WriteLine(fetchedAssignment.Properties.PrincipalId);
Console.WriteLine(fetchedAssignment.Properties.RoleDefinitionId);

RoleAssignment deletedAssignment = client.DeleteRoleAssignment(RoleAssignmentScope.Global, createdAssignment.Name);

Console.WriteLine(deletedAssignment.Name);
Console.WriteLine(deletedAssignment.Properties.PrincipalId);
Console.WriteLine(deletedAssignment.Properties.RoleDefinitionId);
```

## Troubleshooting

When you interact with the Azure Key Vault administration library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to retrieve a role assignment that doesn't exist in your Azure Key Vault, a `404` error is returned, indicating "Not Found".

```C# Snippet:RoleAssignmentNotFound
try
{
    RoleAssignment roleAssignment = client.GetRoleAssignment(RoleAssignmentScope.Global, "invalid-name");
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

## Next steps

Content forthcoming

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
[keyvault_docs]: https://docs.microsoft.com/azure/key-vault/
[keyvault_rest]: https://docs.microsoft.com/rest/api/keyvault/
[JWK]: https://tools.ietf.org/html/rfc7517
[nuget]: https://www.nuget.org/
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Microsoft.Azure.KeyVault/CONTRIBUTING.md


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftables%2FAzure.Data.Tables%2FREADME.png)
