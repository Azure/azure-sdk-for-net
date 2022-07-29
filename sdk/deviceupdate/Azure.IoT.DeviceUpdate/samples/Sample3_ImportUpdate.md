# Get updates

This sample demonstrates using `DeviceUpdateClient` class in this library to import new device update. `DeviceUpdateClient` is used to manage updates in Device Update for IoT Hub - each method call sends a request to the service's REST API.  To get started, you'll need a connection string to the Azure App Configuration. See the [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/deviceupdate/Azure.IoT.DeviceUpdate/README.md) for links and instructions.

 ## Create a DeviceUpdateClient
 
Let's assume you have device update (provided by device builder) and you want to import it into your Device Update for IoT Hub instance. For device update to be importable you need not only 
the actual payload file but also the corresponding import manifest document. See [Import-Concepts](https://docs.microsoft.com/azure/iot-hub-device-update/import-concepts) for details about import manifest.
 
For the sample below, you can set `accountEndpoint` and `instance` in an environment variable.

```C#
var credentials = new DefaultAzureCredential();
var client = new DeviceUpdateClient(accountEndpoint, instance, credentials);
```

## Create import request

Before we can import device update, we need to upload all device update artifacts, in our case payload file and import manifest file, to an Azure Blob container. Let's assume we have local artifact file paths `payloadFilePath`, `manifestFilePath` and Azure Blob container Urls `payloadUrl` and `manifestUrl`.

```C#
var payload = new FileInfo(payloadFilePath);
var manifest = new FileInfo(manifestFilePath);
SHA256 sha256 = SHA256.Create();
string manifestHash;
using (FileStream fileStream = File.OpenRead(filePath))
{
  byte[] hash = sha256.ComputeHash(fileStream);
  manifestHash = Convert.ToBase64String(hash);
}
var content = new[]
{
  new
  {
    importManifest = new
    {
      url = manifestUrl,
      sizeInBytes = manifest.Length,
      hashes = new
      {
        sha256 = manifestHash
      }
    },
    files = new[]
    {
      new
      {
        fileName = payload.Name,
        url = payloadUrl
      }
    },
  }
};

var requestBody = JsonSerializer.Serialize(content);
```

## Import update

Now that we have import request ready, we can start the import operation. The import is a long running operation that might take up to an hour for really big files.

```C#
var response = client.ImportUpdate(WaitUntil.Completed, RequestContent.Create(requestBody));
var doc = JsonDocument.Parse(response.Value.ToMemory());
Console.WriteLine(doc.RootElement.GetProperty("status").ToString());
```
