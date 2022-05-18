using Azure.IoT.DeviceUpdate;
using Azure.Identity;
using Azure;
using Azure.Core;

#region LRO

string endpoint = "https://example.iot.com";
string instanceId = "<instance>";
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
Operation operation = await client.ImportDevicesAsync(WaitUntil.Started, "<action>", new BinaryData("<update>"));
string operationId = operation.Id;

// TODO: Get this from operation
//string statusUpdateEndpoint = "https:///example.iot.com/importDeviceStatus/22";
string continuationToken = operation.ContinuationToken;

// Coming back later
//Operation rehydratedOperation = new ProtocolOperation(new Uri(statusUpdateEndpoint), "<api-version>", client.Pipeline, ClientOptions.Default, new RequestContext());

ProtocolOperation rehydratedOperation = new ProtocolOperation(continuationToken, "<api-version>", client.Pipeline, ClientOptions.Default, new RequestContext());

#endregion

//#region Samples
//// APIView: https://apiview.dev/Assemblies/Review/d8425ea2f8bd4d9eb58b27062f0b0a50

//string endpoint = "https://example.iot.com";
//string instanceId = "<instance>";

//DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());

//#endregion

