# Creating a Role Assignment for Specific Scopes

By default role assignments apply to the global scope. It is also possible to be more specific by applying an assignment to the all keys scope or a specific `KeyVaultKey`.
For information about interacting with a `KeyVaultKey` with a `KeyClient`, see the [Key Client README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) for links and instructions.

## Assigning a Role to the All Keys Scope

Let's assign a role to a service principal so that it applies to all keys. To do this we'll need a service principal object Id and a role definition Id.

See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Administration/README.md) for links and instructions on how to generate a new service principal and obtain it's object Id.
You can also get the object Id for your currently signed in account by running the following [Azure CLI][azure_cli] command.
```
az ad signed-in-user show --query objectId
```

A role definition Id can be obtained from the `Id` property of one of the role definitions returned from `GetRoleAssignments`.

```C# Snippet:CreateRoleAssignmentKeysScope
string definitionIdToAssign = "<roleDefinitionId>";
string servicePrincipalObjectId = "<objectId>";

KeyVaultRoleAssignment keysScopedAssignment = await client.CreateRoleAssignmentAsync(KeyVaultRoleScope.Global, definitionIdToAssign, servicePrincipalObjectId);
```

## Assigning a Role to a specific Key Scope

Let's assign a role to a service principal so that it applies to a specific `KeyVaultKey`. To do this we'll use the role definition Id and a service principal object Id from the previous sample.
We'll also need the name of an existing `KeyVaultKey` to get it from the service using a `KeyClient` so that its `Id` can be referenced.

```C# Snippet:CreateRoleAssignmentKeyScope
string keyName = "<your-key-name>";
KeyVaultKey key = await keyClient.GetKeyAsync(keyName);

KeyVaultRoleAssignment keyScopedAssignment = await client.CreateRoleAssignmentAsync(new KeyVaultRoleScope(key.Id), definitionIdToAssign, servicePrincipalObjectId);
```
