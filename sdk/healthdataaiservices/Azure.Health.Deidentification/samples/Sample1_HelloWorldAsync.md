# Realtime Deidentification Async

This sample demonstrates how to create a `DeidentificationClient` and then deidentify a `string`.

## Create a DeidentificationClient

The service endpoint url can be pulled from the azure portal `Service Url`.

```C# Snippet:AzHealthDeidSample1Async_HelloWorld
DeidentificationClient client = new(
    new Uri(serviceEndpoint),
    credential,
    new DeidentificationClientOptions()
);
```

## Build Request and Call Function

```C# Snippet:AzHealthDeidSample1Async_CreateRequest
DeidentificationContent content = new("Hello, John!");

Response<DeidentificationResult> result = await client.DeidentifyTextAsync(content);
string outputString = result.Value.OutputText;
Console.WriteLine(outputString); // Hello, Tom!
```
