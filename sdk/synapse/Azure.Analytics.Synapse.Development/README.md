# Azure Synapse Analytics Development client library for .NET

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](http://azure.microsoft.com/en-us/develop/net/).

The Azure Synapse Analytics development client library enables programmatically managing artifacts, offering methods to create, update, list, and delete pipelines, datasets, data flows, notebooks, Spark job definitions, SQL scripts, linked services and triggers.

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](http://azure.microsoft.com/en-us/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

## Prerequisites

- Microsoft Azure Subscription: To call Microsoft Azure services, including Azure Synapse, you need to first [create an account](https://account.windowsazure.com/Home/Index). If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits.

- The Azure Synapse client library shares the same [Prerequisites](https://github.com/azure/azure-sdk-for-net#prerequisites) as the Microsoft Azure SDK for .NET.

## Examples
The Azure.Analytics.Synapse.Development package supports synchronous and asynchronous APIs. The following section covers some of the most common Azure Synapse Analytics development related tasks:

### Notebook examples
* [Create a notebook](#create-a-notebook)
* [Retrieve a notebook](#retrieve-a-notebook)
* [List notebooks](#list-notebooks)
* [Delete a notebook](#delete-a-notebook)

### Create a notebook

`CreateOrUpdateNotebook` creates a notebook.

```C# Snippet:CreateNotebook
var notebook = new Notebook(new NotebookMetadata
{
    LanguageInfo = new NotebookLanguageInfo(name:"Python")
},
nbformat: 4,
nbformatMinor: 2,
new List<NotebookCell>());
NotebookClient.CreateOrUpdateNotebook("MyNotebook", new NotebookResource(notebook));
```

### Retrieve a notebook

`GetNoteBook` retrieves a notebook.

```C# Snippet:RetrieveNotebook
NotebookResource notebook = NotebookClient.GetNotebook("MyNotebook");
```

### List notebooks
`GetNotebooksByWorkspace` enumerates the notebooks in the Synapse workspace.

```C# Snippet:ListRoleAssignments
var notebooks = NotebookClient.GetNotebooksByWorkspace();
foreach (var notebook in notebooks)
{
    System.Console.WriteLine(notebook.Name);
}
```

### Delete a notebook

`DeleteNotebook` deletes a notebook.

```C# Snippet:DeleteNotebook
NotebookClient.DeleteNotebook("MyNotebook");
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
