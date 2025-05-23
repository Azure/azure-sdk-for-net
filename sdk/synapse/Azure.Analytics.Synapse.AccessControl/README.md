# Azure Synapse Analytics Access Control client library for .NET

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](https://azure.microsoft.com/develop/net/).

The Azure Synapse Analytics access control client library enables programmatically managing role assignments.

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs.

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](https://azure.microsoft.com/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package

Install the Azure Synapse Analytics access control client library for .NET with [NuGet](https://www.nuget.org/packages/Azure.Analytics.Synapse.AccessControl/):

```dotnetcli
dotnet add package Azure.Analytics.Synapse.AccessControl --prerelease
```

### Prerequisites

- **Azure Subscription:** To use Azure services, including Azure Synapse, you'll need a subscription. If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account]https://azure.microsoft.com/account).
- An existing Azure Synapse workspace. If you need to create an Azure Synapse workspace, you can use the [Azure Portal](https://portal.azure.com/) or [Azure CLI](https://learn.microsoft.com/cli/azure).

If you use the Azure CLI, the command looks like below:

```PowerShell
az synapse workspace create \
    --name <your-workspace-name> \
    --resource-group <your-resource-group-name> \
    --storage-account <your-storage-account-name> \
    --file-system <your-storage-file-system-name> \
    --sql-admin-login-user <your-sql-admin-user-name> \
    --sql-admin-login-password <your-sql-admin-user-password> \
    --location <your-workspace-location>
```

### Authenticate the client

In order to interact with the Azure Synapse Analytics service, you'll need to create an instance of a [RoleAssignmentsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/src/Generated/RoleAssignmentsClient.cs) and/or a [RoleDefinitionsClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/src/Generated/RoleDefinitionsClient.cs) class.

You will also need a **workspace endpoint**, which you may see as "Development endpoint" in the portal, and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity). To use the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#defaultazurecredential) provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

## Key concepts

### RoleAssignmentsClient & RoleDefinitionsClient

With a `RoleAssignmentsClient` you can create, update, and delete role assignments. With a `RoleDefinitionsClient` you can get role assignments from the workspace.

### Role Assignment

The way you control access to Synapse resources is to create role assignments. A role assignment is the process of attaching a role definition to a user, group, service principal, or managed identity at a particular scope for the purpose of granting access. Access is granted by creating a role assignment, and access is revoked by removing a role assignment.

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

The Azure.Analytics.Synapse.AccessControl package supports synchronous and asynchronous APIs. The following section covers some of the most common Azure Synapse Analytics access control related tasks:

### Role assignment examples

- [Create access control client](#create-access-control-client)
- [Create a role assignment](#create-a-role-assignment)
- [Retrieve a role assignment](#retrieve-a-role-assignment)
- [List role assignments](#list-role-assignments)
- [Delete a role assignment](#delete-a-role-assignment)

### Create access control client

To interact with Azure Synapse, you need to instantiate a `RoleAssignmentsClient` and a `RoleDefinitionsClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateAccessControlClient
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

RoleAssignmentsClient roleAssignmentsClient = new RoleAssignmentsClient(new Uri(endpoint), new DefaultAzureCredential());
RoleDefinitionsClient definitionsClient = new RoleDefinitionsClient(new Uri(endpoint), new DefaultAzureCredential());
```

### Create a role assignment

First, you need to the determine the ID of the role you wish to assign, along with the ID of the principal you wish to assign that role.

```C# Snippet:PrepCreateRoleAssignment
Response roleDefinitionsResponse = definitionsClient.GetRoleDefinitions(true, null, new());
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

Then call `CreateRoleAssignment` with the options to create the role assignment.

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

### Retrieve a role assignment

You can retrieve the details of a role assignment by calling `GetRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:RetrieveRoleAssignment
Response roleAssignmentResponse = roleAssignmentsClient.GetRoleAssignmentById(addedRoleAssignmentId, new());
BinaryData roleAssignmentContent = roleAssignmentResponse.Content;
using JsonDocument roleAssignmentJson = JsonDocument.Parse(roleAssignmentContent.ToMemory());
string roleAssignmentRoleDefinitionId = roleAssignmentJson.RootElement.GetProperty("roleDefinitionId").ToString();
string roleAssignmentPrincipalId = roleAssignmentJson.RootElement.GetProperty("principalId").ToString();
Console.WriteLine($"Role {roleAssignmentRoleDefinitionId} is assigned to {roleAssignmentPrincipalId}.");
```

### List role assignments

To enumerate all role assignments in the Synapse workspace you can call `ListRoleAssignments`.

```C# Snippet:ListRoleAssignments
Response roleAssignmentsResponse = roleAssignmentsClient.GetRoleAssignments(null, null, null, null, new());
BinaryData roleAssignmentsContent = roleAssignmentsResponse.Content;
using JsonDocument roleAssignmentsJson = JsonDocument.Parse(roleAssignmentsContent.ToMemory());

foreach (JsonElement assignmentJson in roleAssignmentsJson.RootElement.GetProperty("value").EnumerateArray())
{
    Console.WriteLine(assignmentJson.GetProperty("id").ToString());
}
```

### Delete a role assignment

To delete a role assignment no longer needed you can call `DeleteRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:DeleteRoleAssignment
roleAssignmentsClient.DeleteRoleAssignmentById(addedRoleAssignmentId);
```

## To build

For information on building the Azure Synapse client library, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build)

## Target frameworks

For information about the target frameworks of the Azure Synapse client library, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.

## Troubleshooting

Please open issue in github.

## Next steps

The next step is adding more examples

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
