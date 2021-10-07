# Create, Retrieve and Delete a Synapse Role Assignment

This sample demonstrates basic operations with two core classes in this library: `AccessControlClient` and `RoleAssignmentDetails`. `AccessControlClient` is used to call the Azure Synapse service - each method call sends a request to the service's REST API. `RoleAssignmentDetails` is an entity that represents a role assignment within Synapse. The sample walks through the basics of adding, retrieving, and deleting role assignment. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/README.md) for links and instructions.

## Create access control client

To interact with Azure Synapse, you need to instantiate a `AccessControlClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateAccessControlClient
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

RoleAssignmentsClient roleAssignmentsClient = new RoleAssignmentsClient(new Uri(endpoint), new DefaultAzureCredential());
RoleDefinitionsClient definitionsClient = new RoleDefinitionsClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Create a role assignment

First, you need to the determine the ID of the role you wish to assign, along with the ID of the principal you wish to assign that role.

```C# Snippet:PrepCreateRoleAssignment
Response<IReadOnlyList<SynapseRoleDefinition>> roles = definitionsClient.ListRoleDefinitions();
SynapseRoleDefinition role = roles.Value.Single(role => role.Name == "Synapse Administrator");
Guid roleId = role.Id.Value;

string assignedScope = "workspaces/<my-workspace-name>";

// Replace the string below with the ID you'd like to assign the role.
Guid principalId = /*<my-principal-id>"*/ Guid.NewGuid();

// Replace the string below with the ID of the assignment you'd like to use.
string assignmentId = "<my-assignment-id>";
```

Then create an instance of `RoleAssignmentOptions` with the requested values. Finally call `CreateRoleAssignment` with the options to create the role assignment.

```C# Snippet:CreateRoleAssignment
Response<RoleAssignmentDetails> response = roleAssignmentsClient.CreateRoleAssignment (assignmentId, roleId, principalId, assignedScope);
RoleAssignmentDetails roleAssignmentAdded = response.Value;
```

## Retrieve a role assignment

To retrieve the details of assignment call `GetRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:RetrieveRoleAssignment
RoleAssignmentDetails roleAssignment = roleAssignmentsClient.GetRoleAssignmentById(roleAssignmentAdded.Id);
Console.WriteLine($"Role {roleAssignment.RoleDefinitionId} is assigned to {roleAssignment.PrincipalId}.");
```

## List role assignments

To enumerate all role assignments in the Synapse workspace call `GetRoleAssignments`.

```C# Snippet:ListRoleAssignments
Response<IReadOnlyList<SynapseRoleDefinition>> roleAssignments = definitionsClient.ListRoleDefinitions();
foreach (SynapseRoleDefinition assignment in roleAssignments.Value)
{
    Console.WriteLine(assignment.Id);
}
```

## Delete a role assignment

To delete a role assignment no longer needed you can call `DeleteRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:DeleteRoleAssignment
roleAssignmentsClient.DeleteRoleAssignmentById(roleAssignment.Id);
```
