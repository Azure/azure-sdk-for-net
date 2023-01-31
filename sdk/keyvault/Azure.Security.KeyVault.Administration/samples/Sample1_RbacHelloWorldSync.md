# Creating, getting, and deleting role assignments (Sync)

This sample demonstrates how to create, get, and delete role assignments in Azure Managed HSM.
To get started, you'll need a URI to an Azure Managed HSM. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions.

## Creating a KeyVaultAccessControlClient

To create a new `KeyVaultAccessControlClient` to create, get, or delete role assignments, you need the endpoint to an Azure Managed HSM and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `managedHsmUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:HelloCreateKeyVaultAccessControlClient
KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(new Uri(managedHsmUrl), new DefaultAzureCredential());
```

## Listing All Role Definitions

In order to assign a role to a service principal, we'll have to know which role definitions are available. Let's get all of them.

```C# Snippet:GetRoleDefinitionsSync
List<KeyVaultRoleDefinition> roleDefinitions = client.GetRoleDefinitions(KeyVaultRoleScope.Global).ToList();
```

## Listing All Role Assignments

Before assigning any new roles, let's get all the current role assignments.

```C# Snippet:GetRoleAssignmentsSync
List<KeyVaultRoleAssignment> roleAssignments = client.GetRoleAssignments(KeyVaultRoleScope.Global).ToList();
```

## Creating a Role Assignment

Now let's assign a role to a service principal. To do this we'll need a role definition Id and a service principal object Id.

A role definition Id can be obtained from the `Id` property of one of the role definitions returned from `GetRoleAssignments`.

See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions on how to generate a new service principal and obtain it's object Id.
You can also get the object Id for your currently signed in account by running the following [Azure CLI][azure_cli] command.

```PowerShell
az ad signed-in-user show --query objectId
```

```C# Snippet:CreateRoleAssignment
string definitionIdToAssign = "<roleDefinitionId>";
string servicePrincipalObjectId = "<objectId>";

KeyVaultRoleAssignment createdAssignment = client.CreateRoleAssignment(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId);
```

## Getting a Role Assignment

To get an existing role assignment, we'll need the `Name` property from an existing assignment. Let's use the `createdAssignment` from the previous example.

```C# Snippet:GetRoleAssignment
KeyVaultRoleAssignment fetchedAssignment = client.GetRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);
```

## Deleting a Role Assignment

To remove a role assignment from a service principal, the role assignment must be deleted. Let's delete the `createdAssignment` from the previous example.

```C# Snippet:DeleteRoleAssignment
client.DeleteRoleAssignment(KeyVaultRoleScope.Global, createdAssignment.Name);
```

## Creating a Role Definition

You can also create custom role definitions with custom permissions:

```C# Snippet:CreateRoleDefinition
CreateOrUpdateRoleDefinitionOptions options = new CreateOrUpdateRoleDefinitionOptions(KeyVaultRoleScope.Global)
{
    RoleName = "Managed HSM Data Decryptor",
    Description = "Can only decrypt data using the private key stored in Managed HSM",
    Permissions =
    {
        new KeyVaultPermission()
        {
            DataActions =
            {
                KeyVaultDataAction.DecryptHsmKey
            }
        }
    }
};
KeyVaultRoleDefinition createdDefinition = client.CreateOrUpdateRoleDefinition(options);
```

## Getting a Role Definition

To get a role definition, you'll need to know the globally unique ID (GUID) instead of the name like with role assignments:

```C# Snippet:GetRoleDefinition
Guid roleDefinitionId = new Guid(createdDefinition.Name);
KeyVaultRoleDefinition fetchedDefinition = client.GetRoleDefinition(KeyVaultRoleScope.Global, roleDefinitionId);
```

## Deleting a Role Definition

To delete a role definition, you'll need to know the globally unique ID (GUID) instead of the name like with role assignments:

```C# Snippet:DeleteRoleDefinition
client.DeleteRoleDefinition(KeyVaultRoleScope.Global, roleDefinitionId);
```

<!-- LINKS -->
[azure_cli]: https://learn.microsoft.com/cli/azure
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
