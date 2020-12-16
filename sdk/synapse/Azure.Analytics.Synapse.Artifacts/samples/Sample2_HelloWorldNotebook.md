```C# Snippet:CreateNotebookClient
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";
var client = new NotebookClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

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

```C# Snippet:CreateNotebook
NotebookCreateOrUpdateNotebookOperation operation = await client.StartCreateOrUpdateNotebookAsync(notebookName, notebookResource);
await operation.WaitForCompletionAsync();
Console.WriteLine("Notebook is created");
```

```C# Snippet:RetrieveNotebook
NotebookResource retrievedNotebook = client.GetNotebook(notebookName);
```

```C# Snippet:ListNotebooks
Pageable<NotebookResource> notebooks = client.GetNotebooksByWorkspace();
foreach (NotebookResource notebook in notebooks)
{
    Console.WriteLine(notebook.Name);
}
```


```C# Snippet:DeleteNotebook
client.StartDeleteNotebook(notebookName);
```