```C# Snippet:CreateDataFlowClientPrep
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

string dataFlowName = "Test-DataFlow";
```

```C# Snippet:CreateDataFlowClient
DataFlowClient client = new DataFlowClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

```C# Snippet:CreateDataFlow
DataFlowCreateOrUpdateDataFlowOperation operation = client.StartCreateOrUpdateDataFlow(dataFlowName, new DataFlowResource(new DataFlow()));
Response<DataFlowResource> createdDataflow = await operation.WaitForCompletionAsync();
```

```C# Snippet:RetrieveDataFlow
DataFlowResource retrievedDataflow = client.GetDataFlow(dataFlowName);
```

```C# Snippet:ListDataFlows
Pageable<DataFlowResource> dataFlows = client.GetDataFlowsByWorkspace();
foreach (DataFlowResource dataflow in dataFlows)
{
    System.Console.WriteLine(dataflow.Name);
}
```

```C# Snippet:DeleteDataFlow
DataFlowDeleteDataFlowOperation deleteOperation = client.StartDeleteDataFlow(dataFlowName);
await deleteOperation.WaitForCompletionAsync();
```