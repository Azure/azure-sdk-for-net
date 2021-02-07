```C# Snippet:CreateDatasetClientPrep
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

string storageName = "<my-storage-name>";

string dataSetName = "Test-Dataset";
```

```C# Snippet:CreateDatasetClient
DatasetClient client = new DatasetClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

```C# Snippet:CreateDataset
Dataset data = new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, storageName));
DatasetCreateOrUpdateDatasetOperation operation = client.StartCreateOrUpdateDataset(dataSetName, new DatasetResource(data));
Response<DatasetResource> createdDataset = await operation.WaitForCompletionAsync();
```

```C# Snippet:RetrieveDataset
DatasetResource retrievedDataset = client.GetDataset(dataSetName);
```

```C# Snippet:ListDatasets
Pageable<DatasetResource> datasets = client.GetDatasetsByWorkspace();
foreach (DatasetResource dataset in datasets)
{
    System.Console.WriteLine(dataset.Name);
}
```

```C# Snippet:DeleteDataset
DatasetDeleteDatasetOperation deleteDatasetOperation = client.StartDeleteDataset(dataSetName);
await deleteDatasetOperation.WaitForCompletionAsync();
```