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
Response roleDefinitionsResponse = definitionsClient.GetRoleDefinitions(true);
BinaryData roleDefinitionsContent = roleDefinitionsResponse.Content;
using JsonDocument roleDefinitionsJson = JsonDocument.Parse(roleDefinitionsContent.ToMemory());

JsonElement adminRoleJson = roleDefinitionsJson.RootElement.EnumerateArray().
    Single(role => role.GetProperty("name").ToString() == "Synapse Administrator");
Guid adminRoleId = new Guid(adminRoleJson.GetProperty("id").ToString());

string assignedScope = "workspaces/<my-workspace-name>";

// Replace the string below with the ID you'd like to assign the role.
Guid principalId = /*<my-principal-id>"*/ Guid.NewGuid();

// Replace the string below with the ID of the assignment you'd like to use.
string assignmentId = "<my-assignment-id>";
```

Then create an instance of `RoleAssignmentOptions` with the requested values. Finally call `CreateRoleAssignment` with the options to create the role assignment.

```C# Snippet:CreateRoleAssignment
var roleAssignmentDetails = new
{
    roleId = adminRoleId,
    principalId = Guid.NewGuid(),
    scope = assignedScope
};

Response addedRoleAssignmentResponse = roleAssignmentsClient.CreateRoleAssignment(assignmentId, RequestContent.Create(roleAssignmentDetails), ContentType.ApplicationJson);
BinaryData addedRoleAssignmentContent = addedRoleAssignmentResponse.Content;
using JsonDocument addedRoleAssignmentJson = JsonDocument.Parse(addedRoleAssignmentContent.ToMemory());
string addedRoleAssignmentId = addedRoleAssignmentJson.RootElement.GetProperty("id").ToString();
```

## Retrieve a role assignment

To retrieve the details of assignment call `GetRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:RetrieveRoleAssignment
Response roleAssignmentResponse = roleAssignmentsClient.GetRoleAssignmentById(addedRoleAssignmentId, new());
BinaryData roleAssignmentContent = roleAssignmentResponse.Content;
using JsonDocument roleAssignmentJson = JsonDocument.Parse(roleAssignmentContent.ToMemory());
string roleAssignmentRoleDefinitionId = roleAssignmentJson.RootElement.GetProperty("roleDefinitionId").ToString();
string roleAssignmentPrincipalId = roleAssignmentJson.RootElement.GetProperty("principalId").ToString();
Console.WriteLine($"Role {roleAssignmentRoleDefinitionId} is assigned to {roleAssignmentPrincipalId}.");
```

## List role assignments

To enumerate all role assignments in the Synapse workspace call `GetRoleAssignments`.

```C# Snippet:ListRoleAssignments
Response roleAssignmentsResponse = roleAssignmentsClient.GetRoleAssignments();
BinaryData roleAssignmentsContent = roleAssignmentsResponse.Content;
using JsonDocument roleAssignmentsJson = JsonDocument.Parse(roleAssignmentsContent.ToMemory());

foreach (JsonElement assignmentJson in roleAssignmentsJson.RootElement.GetProperty("value").EnumerateArray())
{
    Console.WriteLine(assignmentJson.GetProperty("id").ToString());
}
```

## Delete a role assignment

To delete a role assignment no longer needed you can call `DeleteRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:DeleteRoleAssignment
roleAssignmentsClient.DeleteRoleAssignmentById(addedRoleAssignmentId);
```
