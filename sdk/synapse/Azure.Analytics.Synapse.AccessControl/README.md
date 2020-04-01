# Azure Synapse Analytics Access Control client library for .NET

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](http://azure.microsoft.com/en-us/develop/net/).

The Azure Synapse Analytics access control client library enables programmatically managing role assignments.

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](http://azure.microsoft.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

## Prerequisites

- Microsoft Azure Subscription: To call Microsoft Azure services, including Azure Synapse, you need to first [create an account](https://account.windowsazure.com/Home/Index). If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits.

- The Azure Synapse client library shares the same [Prerequisites](https://github.com/azure/azure-sdk-for-net#prerequisites) as the Microsoft Azure SDK for .NET.

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
var request = new RoleAssignmentRequest(roleId:role.Id, principalId:principalId);
RoleAssignmentDetails roleAssignmentAdded = client.CreateRoleAssignment(request);
```

### Retrieve a role assignment

`GetRoleAssignmentById` retrieves a role assignment by the given principal ID.

```C# Snippet:RetrieveRoleAssignment
RoleAssignmentDetails roleAssignment = client.GetRoleAssignmentById(principalId);
```

### List role assignments
`GetRoleAssignments` enumerates the role assignments in the Synapse workspace.

```C# Snippet:ListRoleAssignments
var roleAssignments = client.GetRoleAssignments().Value;
foreach (var assignment in roleAssignments)
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

## Key concepts

### AccessControlClient
With a `AccessControlClient` you can get role assignments from the workspace, create new role assignments, and delete role assignments.

## Troubleshooting

Please open issue in github.

## Next steps

The next step is adding more examples

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
