# Azure Synapse Analytics Artifacts client library for .NET

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](https://azure.microsoft.com/develop/net/).

The Azure Synapse Analytics development client library enables programmatically managing artifacts, offering methods to create, update, list, and delete pipelines, datasets, data flows, notebooks, Spark job definitions, SQL scripts, linked services and triggers.

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](https://azure.microsoft.com/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package
Install the Azure Synapse Analytics development client library for .NET with [NuGet](https://www.nuget.org/packages/Azure.Analytics.Synapse.Artifacts/):

```PowerShell
dotnet add package Azure.Analytics.Synapse.Artifacts --version 0.1.0-preview.2
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
In order to interact with part of the Azure Synapse Analytics service, you'll need to create an instance of the respective client class:

- [BigDataPoolsClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/BigDataPoolsClient.cs)
- [DataFlowClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/DataFlowClient.cs)
- [DataFlowDebugSessionClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/DataFlowDebugSessionClient.cs)
- [DatasetClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/DatasetClient.cs)
- [IntegrationRuntimesClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/IntegrationRuntimesClient.cs)
- [LinkedServiceClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/LinkedServiceClient.cs)
- [NotebookClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/NotebookClient.cs)
- [PipelineClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/PipelineClient.cs)
- [PipelineRunClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/PipelineRunClient.cs)
- [SparkJobDefinitionClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/SparkJobDefinitionClient.cs)
- [SqlPoolsClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/SqlPoolsClient.cs)
- [SqlScriptClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/SqlScriptClient.cs)
- [TriggerClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/TriggerClient.cs)
- [TriggerRunClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/TriggerRunClient.cs)
- [WorkspaceClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/WorkspaceClient.cs)
- [WorkspaceGitRepoManagementClient](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/src/Customization/WorkspaceGitRepoManagementClient.cs)

You need a **workspace endpoint**, which you may see as "Development endpoint" in the portal,  and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity). To use the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity#defaultazurecredential) provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

## Examples
The Azure.Analytics.Synapse.Artifacts package supports synchronous and asynchronous APIs. The following section covers some of the most common Azure Synapse Analytics development related tasks:

### Notebook examples
* [Create a notebook](#create-a-notebook)
* [Retrieve a notebook](#retrieve-a-notebook)
* [List notebooks](#list-notebooks)
* [Delete a notebook](#delete-a-notebook)

### Create a notebook

`CreateOrUpdateNotebook` creates a notebook.

```C# Snippet:CreateNotebook
NotebookCreateOrUpdateNotebookOperation operation = await client.StartCreateOrUpdateNotebookAsync(notebookName, notebookResource);
await operation.WaitForCompletionAsync();
Console.WriteLine("The notebook is created");
```

### Retrieve a notebook

`GetNoteBook` retrieves a notebook.

```C# Snippet:RetrieveNotebook
NotebookResource retrievedNotebook = client.GetNotebook(notebookName);
```

### List notebooks
`GetNotebooksByWorkspace` enumerates the notebooks in the Synapse workspace.

```C# Snippet:ListNotebooks
Pageable<NotebookResource> notebooks = client.GetNotebooksByWorkspace();
foreach (NotebookResource notebook in notebooks)
{
    Console.WriteLine(notebook.Name);
}
```

### Delete a notebook

`DeleteNotebook` deletes a notebook.

```C# Snippet:DeleteNotebook
NotebookDeleteNotebookOperation deleteNotebookOperation = client.StartDeleteNotebook(notebookName);
await deleteNotebookOperation.WaitForCompletionAsync();
```

## To build

For information on building the Azure Synapse client library, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build)

## Target frameworks

For information about the target frameworks of the Azure Synapse client library, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.  

## Key concepts

### NotebookControlClient
With a notebook client you can create, update, list, and delete pipelines, datasets, data flows, notebooks, Spark job definitions, SQL scripts, linked services and triggers.

## Troubleshooting

Please open issue in github.

## Next steps

The next step is adding more examples

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
