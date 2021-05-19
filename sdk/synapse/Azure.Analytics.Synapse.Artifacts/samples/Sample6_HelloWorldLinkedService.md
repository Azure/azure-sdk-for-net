```C# Snippet:CreateLinkedServiceClientPrep
// Replace the string below with your actual endpoint url.
string endpoint = "<my-endpoint-url>";

// Replace the string below with your actual datalake endpoint url.
string dataLakeEndpoint = "<my-datalake-url>";

string serviceName = "Test-LinkedService";
```

```C# Snippet:CreateLinkedServiceClient
LinkedServiceClient client = new LinkedServiceClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
```

```C# Snippet:CreateLinkedService
LinkedServiceResource serviceResource = new LinkedServiceResource(new AzureDataLakeStoreLinkedService(dataLakeEndpoint));
LinkedServiceCreateOrUpdateLinkedServiceOperation operation = client.StartCreateOrUpdateLinkedService(serviceName, serviceResource);
Response<LinkedServiceResource> createdService = await operation.WaitForCompletionAsync();
```

```C# Snippet:RetrieveLinkedService
LinkedServiceResource retrievedService = client.GetLinkedService(serviceName);
```

```C# Snippet:ListLinkedServices
Pageable<LinkedServiceResource> linkedServices = client.GetLinkedServicesByWorkspace();
foreach (LinkedServiceResource linkedService in linkedServices)
{
    System.Console.WriteLine(linkedService.Name);
}
```

```C# Snippet:DeleteLinkedService
LinkedServiceDeleteLinkedServiceOperation deleteLinkedServiceOperation = client.StartDeleteLinkedService(serviceName);
await deleteLinkedServiceOperation.WaitForCompletionAsync();
```