# Start Dialog

This sample demonstrates how to add an IVR-powered dialog to a phone call and start it.

To get started you will need:
- A Communication Service Resource.  See [README][README] for prerequisites and instructions.
- A Nuance Mix Bot or a Power Virtual Agent IVR. See [Nuance Mix][Nuance_Mix] for instructions

## Creating a `CallAutomationClient`

A CallDialog instance requires the creation of a CallAutomation client. This can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal
```C#
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
CallAutomationClient callAutomationClient = new CallAutomationClient(connectionString);
```

## Dialog Dependencies and Creating a `CallDialog` Instance

The Dialog relies on an already running call (see the [Create Call Sample][create_call_sample]) to run. With an existing call, take the CallConnectionId to create the CallDialog instance
```C#
var callConnection = client.GetCallConnection(@event.CallConnectionId);
var callDialog = callConnection.GetCallDialog();
```
For an example on managing the connection, refer to the [Quickstart][Quickstart].

## Starting the Dialog

To make a new Dialog, call the `StartDialogAsync` from the `CallDialog` client. Its options parameter requires the input type, the ID of the Bot App, and the DialogContext. The contents of the DialogContext depends on the IVR bot in use - a sample of a context class is provided below.
The returned value is `DialogResult` objects that contain the Dialog ID and call Id if successful, otherwise will throw RequestFailedException
```C#
public class SampleContext
{
    public SampleContext(string scriptName, string recordId)
    {
        ScriptName = scriptName;
        RecordId = recordId;
    }
    public string ScriptName { get; set; }
    public string RecordId { get; set; }
}
```
```C#
Dictionary<string, object> dialogContext = new Dictionary<string, object>()
{
    { "context", new SampleContext("sampleName", "sampleId")}
};
string botAppId; // Each Dialog Bot App has an ID in the form of a Guid. See the Quickstart for an example of how to acquire the botAppId
```
```C#
var dialogOptions = new StartDialogOptions(DialogInputType.PowerVirtualAgents, botAppId, dialogContext)
{
    OperationContext = "DialogStart"
};
await callDialog.StartDialogAsync(dialogOptions);
```

<!-- Links -->
[README]: https://github.com/Azure/azure-sdk-for-net/blob/a20e269162fa88a43e5ba0e5bb28f2e76c74a484/sdk/communication/Azure.Communication.CallingServer/README.md#getting-started
[create_call_sample]: https://github.com/Azure/azure-sdk-for-net/blob/a20e269162fa88a43e5ba0e5bb28f2e76c74a484/sdk/communication/Azure.Communication.CallingServer/samples/Sample1_CreateCallAsync.md
[Quickstart]: https://github.com/Azure/communication-preview/blob/0e88fc78cc3eddaab8b8a9fe631420a2a1092eca/samples/Dialog%20Quickstart/CallAutomation_Dialog/readme.md
[Nuance_Mix]: https://docs.nuance.com/mix/