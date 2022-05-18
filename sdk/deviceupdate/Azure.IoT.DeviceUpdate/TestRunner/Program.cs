using Azure.IoT.DeviceUpdate;
using Azure.Identity;
using Azure;

#region LRO

string endpoint = "https://example.iot.com";
string instanceId = "<instance>";
DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
Operation operation = await client.ImportDevicesAsync(WaitUntil.Started, "<action>", new BinaryData("<update>"));
string operationId = operation.Id;


// Coming back later
Operation<BinaryData> rehydratedOperation = new ProtocolOperation()



////await operation.UpdateStatusAsync();

//if (!operation.HasCompleted)
//{
//    // Save out operation id
//    Console.WriteLine(operation.Id);
//}

//string operationId = operation.Id;

Console.WriteLine("All done. :)");

#endregion

//#region Samples
//// APIView: https://apiview.dev/Assemblies/Review/d8425ea2f8bd4d9eb58b27062f0b0a50

//string endpoint = "https://example.iot.com";
//string instanceId = "<instance>";

//DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());

//#endregion

