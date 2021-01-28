# Azure Synapse Analytics Access Control client library for .NET

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](https://azure.microsoft.com/develop/net/).

The Azure Synapse Analytics access control client library enables programmatically managing role assignments.

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](https://azure.microsoft.com/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package
Install the Azure Synapse Analytics access control client library for .NET with [NuGet](https://www.nuget.org/packages/Azure.Analytics.Synapse.AccessControl/):

```PowerShell
dotnet add package Azure.Analytics.Synapse.AccessControl --version 0.1.0-preview.1
```

### Prerequisites
- **Azure Subscription:**  To use Azure services, including Azure Synapse, you'll need a subscription.  If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://account.windowsazure.com/Home/Index).
- An existing Azure Synapse workspace. If you need to create an Azure Synapse workspace, you can use the [Azure Portal](https://portal.azure.com/) or [Azure CLI](https://docs.microsoft.com/cli/azure).

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
In order to interact with the Azure Synapse Analytics service, you'll need to create an instance of the [AccessControlClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.AccessControl/src/Customization/AccessControlClient.cs) class. You need a **workspace endpoint**, which you may see as "Development endpoint" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity). To use the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity#defaultazurecredential) provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

## Key concepts

### AccessControlClient
With a `AccessControlClient` you can get role assignments from the workspace, create new role assignments, and delete role assignments.

### Role Assignment
The way you control access to Synapse resources is to create role assignments. A role assignment is the process of attaching a role definition to a user, group, service principal, or managed identity at a particular scope for the purpose of granting access. Access is granted by creating a role assignment, and access is revoked by removing a role assignment.

## Examples
The Azure.Analytics.Synapse.AccessControl package supports synchronous and asynchronous APIs. The following section covers some of the most common Azure Synapse Analytics access control related tasks:

### Role assignment examples
* [Create access control client](#create-access-control-client)
* [Create a role assignment](#create-a-role-assignment)
* [Retrieve a role assignment](#retrieve-a-role-assignment)
* [List role assignments](#list-role-assignments)
* [Delete a role assignment](#delete-a-role-assignment)

### Create access control client

To interact with Azure Synapse, you need to instantiate a `AccessControlClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateAccessControlClient
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

AccessControlClient client = new AccessControlClient(new Uri(endpoint), new DefaultAzureCredential());
```

### Create a role assignment

First, you need to the determine the ID of the role you wish to assign, along with the ID of the principal you wish to assign that role.

```C# Snippet:PrepCreateRoleAssignment
Pageable<SynapseRole> roles = client.GetRoleDefinitions();
SynapseRole role = roles.Single(role => role.Name == "Workspace Admin");
string roleID = role.Id;

// Replace the string below with the ID you'd like to assign the role.
string principalId = "<my-principal-id>";
```

Then create an instance of `RoleAssignmentOptions` with the requested values. Finally call `CreateRoleAssignment` with the options to create the role assignment.

```C# Snippet:CreateRoleAssignment
RoleAssignmentOptions request = new RoleAssignmentOptions(roleID, principalId);
Response<RoleAssignmentDetails> response = client.CreateRoleAssignment(request);
RoleAssignmentDetails roleAssignmentAdded = response.Value;
```

### Retrieve a role assignment

You can retrieve the details of a role assignment by calling `GetRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:RetrieveRoleAssignment
RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(roleAssignmentAdded.Id);
Console.WriteLine($"Role {roleAssignment.RoleId} is assigned to {roleAssignment.PrincipalId}.");
```

### List role assignments

To enumerate all role assignments in the Synapse workspace you can call `GetRoleAssignments`.

```C# Snippet:ListRoleAssignments
Response<IReadOnlyList<RoleAssignmentDetails>> roleAssignments = client.GetRoleAssignments();
foreach (RoleAssignmentDetails assignment in roleAssignments.Value)
{
    Console.WriteLine(assignment.Id);
}
```

### Delete a role assignment

To delete a role assignment no longer needed you can call `DeleteRoleAssignmentById`, passing in the assignment ID.

```C# Snippet:DeleteRoleAssignment
client.DeleteRoleAssignmentById(roleAssignment.Id);
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
