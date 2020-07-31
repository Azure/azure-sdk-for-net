# Creating, getting, and deleting role assignments

This sample demonstrates how to create, get, and delete role assignments in Azure Key Vault.
To get started, you'll need a URI to an Azure Key Vault. See the [README](../README.md) for links and instructions.

## Creating a KeyVaultAccessControlClient

To create a new `KeyVaultAccessControlClient` to create, get, or delete role assignments, you need the endpoint to an Azure Key Vault and credentials.
You can use the [DefaultAzureCredential][DefaultAzureCredential] to try a number of common authentication methods optimized for both running as a service and development.

In the sample below, you can set `keyVaultUrl` based on an environment variable, configuration setting, or any way that works for your application.

```C# Snippet:HelloCreateKeyVaultAccessControlClient
KeyVaultAccessControlClient client = new KeyVaultAccessControlClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
```

## Listing All Role Definitions (Sync)

In order to assign a role to a service principal, we'll have to know which role definitions are available. Let's get all of them.

```C# Snippet:GetRoleDefinitionsSync
List<RoleDefinition> roleDefinitions = client.GetRoleDefinitions(RoleAssignmentScope.Global).ToList();
```

## Listing All Role Assignments

Before assigning any new roles, let's get all the current role assignments.

```C# Snippet:GetRoleAssignmentsSync
List<RoleAssignment> roleAssignments = client.GetRoleAssignments(RoleAssignmentScope.Global).ToList();
```

# Creating a Role Assignment

Now let's assign a role to a service principal. To do this we'll need a role definition Id and a service principal object Id.

A role definition Id can be obtained from the `Id` property of one of the role definitions returned from `GetRoleAssignments`.

See the [README](../README.md) for links and instructions on how to generate a new service principal and obtain it's object Id.
You can also get the object Id for your currently signed in account by running the following [Azure CLI][azure_cli] command.
```
az ad signed-in-user show --query objectId
```

```C# Snippet:CreateRoleAssignment
string definitionIdToAssign = "<roleDefinitionId>";
string servicePrincipalObjectId = "<objectId>";

RoleAssignmentProperties properties = new RoleAssignmentProperties(definitionIdToAssign, servicePrincipalObjectId);
RoleAssignment createdAssignment = client.CreateRoleAssignment(RoleAssignmentScope.Global, properties);
```

# Getting a Role Assignment

To get an existing role assignment, we'll need the `Name` property from an existing assignment. Let's use the `createdAssignment` from the previous example.

```C# Snippet:GetRoleAssignment
RoleAssignment fetchedAssignment = client.GetRoleAssignment(RoleAssignmentScope.Global, createdAssignment.Name);
```

# Deleting a Role Assignment
To remove a role assignment from a service principal, the role assignment must be deleted. Let's delete the `createdAssignment` from the previous example.

```C# Snippet:DeleteRoleAssignment
RoleAssignment deletedAssignment = client.DeleteRoleAssignment(RoleAssignmentScope.Global, createdAssignment.Name);
```

<!-- LINKS -->
[azure_cli]: https://docs.microsoft.com/cli/azure
