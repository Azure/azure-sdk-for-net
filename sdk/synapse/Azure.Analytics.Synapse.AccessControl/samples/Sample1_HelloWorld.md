# Create, Retrieve and Delete a Synapse Role Assignment

This sample demonstrates basic operations with two core classes in this library: `AccessControlClient` and `RoleAssignmentDetails`. `AccessControlClient` is used to call the Azure Synapse service - each method call sends a request to the service's REST API. `RoleAssignmentDetails` is an entity that represents a role assignment within Synapse. The sample walks through the basics of adding, retrieving, and deleting role assignment. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/README.md) for links and instructions.

## Create access control client

To interact with Azure Synapse, you need to instantiate a `AccessControlClient`. It requires an endpoint URL and a `TokenCredential`.

## Create a role assignment

First, you need to the determine the ID of the role you wish to assign, along with the ID of the principal you wish to assign that role.

Then create an instance of `RoleAssignmentOptions` with the requested values. Finally call `CreateRoleAssignment` with the options to create the role assignment.

## Retrieve a role assignment

To retrieve the details of assignment call `GetRoleAssignmentById`, passing in the assignment ID.

## List role assignments

To enumerate all role assignments in the Synapse workspace call `GetRoleAssignments`.

## Delete a role assignment

To delete a role assignment no longer needed you can call `DeleteRoleAssignmentById`, passing in the assignment ID.
