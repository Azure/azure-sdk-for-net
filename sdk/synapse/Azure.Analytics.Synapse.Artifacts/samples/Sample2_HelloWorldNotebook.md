# Create, Retrieve and Delete a Synapse Notebook

This sample demonstrates basic operations with two core classes in this library: `NotebookClient` and `NotebookResource`. `NotebookClient` is used to interact with notebooks on Azure Synapse - each method call sends a request to the service's REST API. `NotebookResource`, along with related classes Notebook and `NotebookCell`, represent a notebook within Synapse. The sample walks through the basics of adding, retrieving, deleting a notebook. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Artifacts/README.md) for links and instructions.

## Create pipeline client

To interact with notebooks on Azure Synapse, you need to instantiate a `NotebookClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateNotebookClient
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";
var client = new NotebookClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

## Create a notebook

To create an notebook, first create one or more `NotebookCell` with contents, and pass those into the `Notebook` constructor. 

```C# Snippet:ConfigureNotebookResource
string notebookName = "Test-Notebook";
var cell = new NotebookCell("code", new NotebookMetadata (), new string[] {
    "from azureml.opendatasets import NycTlcYellow\n",
    "\n",
    "data = NycTlcYellow()\n",
    "df = data.to_spark_dataframe()\n",
    "# Display 10 rows\n",
    "display(df.limit(10))"
});
var newNotebook = new Notebook(new NotebookMetadata(), 4, 2, new NotebookCell[] { cell });
var notebookResource = new NotebookResource(notebookName, newNotebook);
```

One a notebook is created, it cas be added to a NotebookResource, which is uploaded with the `StartCreateOrUpdateNotebookAsync` method on `NotebookClient`.

```C# Snippet:CreateNotebook
NotebookCreateOrUpdateNotebookOperation operation = await client.StartCreateOrUpdateNotebookAsync(notebookName, notebookResource);
await operation.WaitForCompletionAsync();
Console.WriteLine("The notebook is created");
```

## Retrieve a pipeline

To retrieve a notebook call `GetNotebook`, passing in the notebook name.

```C# Snippet:RetrieveNotebook
NotebookResource retrievedNotebook = client.GetNotebook(notebookName);
```

## List notebooks

To enumerate all notebooks in the Synapse workspace call `GetNotebooksByWorkspace`.

```C# Snippet:ListNotebooks
Pageable<NotebookResource> notebooks = client.GetNotebooksByWorkspace();
foreach (NotebookResource notebook in notebooks)
{
    Console.WriteLine(notebook.Name);
}
```

## Delete a notebook

To delete a notebook no longer needed call `StartDeleteNotebook`, passing in the notebook name.

```C# Snippet:DeleteNotebook
NotebookDeleteNotebookOperation deleteNotebookOperation = client.StartDeleteNotebook(notebookName);
await deleteNotebookOperation.WaitForCompletionAsync();
```
