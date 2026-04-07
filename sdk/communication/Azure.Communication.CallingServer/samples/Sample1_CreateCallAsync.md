# Create Call

This sample demonstrates how to make a call to a recipient phone number.

To get started you'll need a Communication Service Resource.  See [README][README] for prerequisites and instructions.

## Creating a `CallAutomationClient`

CallAutomation client can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal.

```C#
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
CallAutomationClient callAutomationClient = new CallAutomationClient(connectionString);
```

## Make a call to a phone number recipient

To make a Call, call the `CreateCallAsync` function from the `CallClient`. The returned value is `CreateCallResult` objects that contains the created Call's Id if succeed, else throws a RequestFailedException.
```C#
CallSource callSource = new CallSource(
       new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
       );
callSource.CallerId = new PhoneNumberIdentifier("<caller-id-phonenumber>") // E.164 formatted recipient phone number
```
```C#
CreateCallResult createCallResult = await callAutomationClient.CreateCallAsync(
    source: callSource,
    targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
    callbackEndpoint: new Uri(TestEnvironment.AppCallbackUrl)
    );
Console.WriteLine($"Call connection id: {createCallResult.CallConnectionProperties.CallConnectionId}");
```

[README]: https://github.com/Azure/azure-sdk-for-net/blob/a20e269162fa88a43e5ba0e5bb28f2e76c74a484/sdk/communication/Azure.Communication.CallingServer/README.md#getting-started
