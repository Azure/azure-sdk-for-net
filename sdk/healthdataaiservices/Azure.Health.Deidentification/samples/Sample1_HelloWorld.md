# Realtime Deidentification

This sample demonstrates how to create a `DeidentificationClient` and then deidentify a `string`.

 ## Create a DeidentificationClient



```C# Snippet:AzHealthDeidSample1_CreateDeidClient
string serviceEndpoint = "https://example.api.cac001.deid.azure.com";
TokenCredential credential = new DefaultAzureCredential();

DeidentificationClient client = new DeidentificationClient(
    new Uri(serviceEndpoint),
    credential,
    new DeidentificationClientOptions()
);
```
