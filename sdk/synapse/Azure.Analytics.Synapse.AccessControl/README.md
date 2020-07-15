# Azure Synapse Analytics Access Control client library for .NET

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](http://azure.microsoft.com/en-us/develop/net/).

The Azure Synapse Analytics access control client library enables programmatically managing role assignments.

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](http://azure.microsoft.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package
Install the Azure Synapse Analytics access control client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Analytics.Synapse.AccessControl --version 0.1.0-preview.1
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure Synapse workspace. If you need to create an Azure Synapse workspace, you can use the Azure Portal or [Azure CLI][azure_cli].

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
In order to interact with the Azure Synapse Analytics service, you'll need to create an instance of the [AccessControlClient][accesscontrol_client_class] class. You need a **workspace endpoint**, which you may see as "Development endpoint" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
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
* [Create a role assignment](#create-a-role-assignment)
* [Retrieve a role assignment](#retrieve-a-role-assignment)
* [List role assignments](#list-role-assignments)
* [Delete a role assignment](#delete-a-role-assignment)

### Create a role assignment

`CreateRoleAssignment` creates a role assignment.

```C# Snippet:CreateRoleAssignment
RoleAssignmentOptions options = new RoleAssignmentOptions(sqlAdminRoleId, principalId);
RoleAssignmentDetails roleAssignment = client.CreateRoleAssignment(options);
```

### Retrieve a role assignment

`GetRoleAssignmentById` retrieves a role assignment by the given principal ID.

```C# Snippet:RetrieveRoleAssignment
RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(principalId);
```

### List role assignments
`GetRoleAssignments` enumerates the role assignments in the Synapse workspace.

```C# Snippet:ListRoleAssignments
IReadOnlyList<RoleAssignmentDetails> roleAssignments = client.GetRoleAssignments().Value;
foreach (RoleAssignmentDetails assignment in roleAssignments)
{
    Console.WriteLine(assignment.Id);
}
```

### Delete a role assignment

`DeleteRoleAssignmentById` deletes a role assignment by the given principal ID.

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
