// See https://aka.ms/new-console-template for more information


using Azure.IoT.DeviceUpdate;
using Azure.Identity;
using Azure;

string endpoint = "https://example.iot.com";
string instanceId = "<instance>";


DeviceManagementClient client = new DeviceManagementClient(endpoint, instanceId, new DefaultAzureCredential());
Operation<BinaryData> operation = await client.ImportDevicesAsync(WaitUntil.Started, "<action>", new BinaryData("<data>"));
await operation.UpdateStatusAsync();

if (!operation.HasCompleted)
{
    // Save out operation id
    Console.WriteLine(operation.Id);
}

string operationId = operation.Id;

// Coming back later

Operation<BinaryData> resumeOperation = client.GetUpdateStatusOperation(operationId);



Console.WriteLine("All done. :)");
