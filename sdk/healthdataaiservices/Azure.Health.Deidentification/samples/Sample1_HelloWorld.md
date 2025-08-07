# Realtime Deidentification

This sample demonstrates how to create a `DeidentificationClient` and then deidentify a `string`.

## Create a DeidentificationClient

The service endpoint url can be pulled from the azure portal `Service Url`.

```C# Snippet:AzHealthDeidSample1_HelloWorld
DeidentificationClient client = new(
    new Uri(serviceEndpoint),
    credential,
    new DeidentificationClientOptions()
);
```

## Build Request and Call Function

```C# Snippet:AzHealthDeidSample1_CreateRequest
DeidentificationContent content = new("Hello, John!");

Response<DeidentificationResult> result = client.DeidentifyText(content);
string outputString = result.Value.OutputText;
Console.WriteLine(outputString); // Hello, Tom!
```
