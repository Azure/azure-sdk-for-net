# Azure Communication CallAutomation client library for .NET

This package contains a C# SDK for Azure Communication Call Automation.

[Source code][source] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication CallAutomation client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.CallAutomation
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`CallAutomationClient` provides the functionality to answer incoming call or initialize an outbound call.

### Using statements
```C#
using Azure.Communication.CallAutomation;
```

### Authenticate the client
Call Automation client can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C#
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
CallAutomationClient callAutomationClient = new CallAutomationClient(connectionString);
```

Or alternatively using a valid Active Directory token.
```C#
var endpoint = new Uri("https://my-resource.communication.azure.com");
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new CallAutomationClient(endpoint, tokenCredential);
```

## Examples
### Make a call to a phone number recipient
To make an outbound call, call the `CreateCall` or `CreateCallAsync` function from the `CallAutomationClient`.
```C#
CallInvite callInvite = new CallInvite(
    new PhoneNumberIdentifier("<targets-phone-number>"),
    new PhoneNumberIdentifier("<caller-id-phonenumber>")
    );  // E.164 formatted recipient phone number

// create call with above invitation
createCallResult = await callAutomationClient.CreateCallAsync(
    callInvite,
    new Uri("<YOUR-CALLBACK-URL>")
    );

Console.WriteLine($"Call connection id: {createCallResult.CallConnectionProperties.CallConnectionId}");
```

### Handle Mid-Connection callback events
Your app will receive mid-connection callback events via the callbackEndpoint you provided. You will need to write event handler controller to receive the events and direct your app flow based on your business logic.
```C#
/// <summary>
/// Handle call back events.
/// </summary>>
[HttpPost]
[Route("/CallBackEvent")]
public IActionResult OnMidConnectionCallBackEvent([FromBody] CloudEvent[] events)
{
    try
    {
        if (events != null)
        {
            // Helper function to parse CloudEvent to a CallAutomation event.
            CallAutomationEventData callBackEvent = CallAutomationEventParser.Parse(events.FirstOrDefault());

            switch (callBackEvent)
            {
                case CallConnected ev:
                    # logic to handle a CallConnected event
                    break;
                case CallDisconnected ev:
                    # logic to handle a CallDisConnected event
                    break;
                case ParticipantsUpdated ev:
                    # cast the event into a ParticipantUpdated event and do something with it. Eg. iterate through the participants
                    ParticipantsUpdated updatedEvent = (ParticipantsUpdated)ev;
                    break;
                case AddParticipantsSucceeded ev:
                    # logic to handle an AddParticipantsSucceeded event
                    break;
                case AddParticipantsFailed ev:
                    # logic to handle an AddParticipantsFailed event
                    break;
                case CallTransferAccepted ev:
                    # logic to handle CallTransferAccepted event
                    break;
                case CallTransferFailed ev:
                    # logic to handle CallTransferFailed event
                    break;
                default:
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        // handle exception
    }
    return Ok();
}
```

### Handle Mid-Connection events with CallAutomation's EventProcessor
To easily handle mid-connection events, Call Automation's SDK provides easier way to handle these events.
Take a look at `CallAutomationEventProcessor`. this will ensure correlation between call and events more easily.
```C#
[HttpPost]
[Route("/CallBackEvent")]
public IActionResult OnMidConnectionCallBackEvent([FromBody] CloudEvent[] events)
{
    try
    {
        // process incoming event for EventProcessor
        _callAutomationClient.GetEventProcessor().ProcessEvents(cloudEvents);
    }
    catch (Exception ex)
    {
        // handle exception
    }
    return Ok();
}
```
`ProcessEvents` is required for EventProcessor to work.
After event is being consumed by EventProcessor, you can start using its feature.

See below for example: where you are making a call with `CreateCall`, and wait for `CallConnected` event of the call.
```C#
CallInvite callInvite = new CallInvite(
    new PhoneNumberIdentifier("<targets-phone-number>"),
    new PhoneNumberIdentifier("<caller-id-phonenumber>")
    );  // E.164 formatted recipient phone number

// create call with above invitation
createCallResult = await callAutomationClient.CreateCallAsync(
    callInvite,
    new Uri("<YOUR-CALLBACK-URL>")
    );

// giving 30 seconds timeout for call reciever to answer
CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
CancellationToken token = cts.Token;

try
{
    // this will wait until CreateCall is completed or Timesout!
    CreateCallEventResult eventResult = await createCallResult.WaitForEventAsync(token);

    // Once this is recieved, you know the call is now connected.
    CallConnected returnedEvent = eventResult.SuccessEvent;

    // ...Do more actions, such as Play or AddParticipant, since the call is established...
}
catch (OperationCanceledException ex)
{
    // Timeout exception happend!
    // Call likely was never answered.
}
```
If cancellation token was not passed with timeout, the default timeout is 4 minutes.

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

## Next steps
- [Call Automation Overview][overview]
- [Incoming Call Concept][incomingcall]
- [Build a customer interaction workflow using Call Automation][build1]
- [Redirect inbound telephony calls with Call Automation][build2]
- [Quickstart: Play action][build3]
- [Quickstart: Recognize action][build4]
- [Read more about Call Recording in Azure Communication Services][recording1]
- [Record and download calls with Event Grid][recording2]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.CallAutomation/src
[overview]: https://learn.microsoft.com/azure/communication-services/concepts/voice-video-calling/call-automation
[incomingcall]: https://learn.microsoft.com/azure/communication-services/concepts/voice-video-calling/incoming-call-notification
[build1]: https://learn.microsoft.com/azure/communication-services/quickstarts/voice-video-calling/callflows-for-customer-interactions?pivots=programming-language-csha
[build2]: https://learn.microsoft.com/azure/communication-services/how-tos/call-automation-sdk/redirect-inbound-telephony-calls?pivots=programming-language-csharp
[build3]: https://learn.microsoft.com/azure/communication-services/quickstarts/voice-video-calling/play-action?pivots=programming-language-csharp
[build4]: https://learn.microsoft.com/azure/communication-services/quickstarts/voice-video-calling/recognize-action?pivots=programming-language-csharp
[recording1]: https://learn.microsoft.com/azure/communication-services/concepts/voice-video-calling/call-recording
[recording2]: https://learn.microsoft.com/azure/communication-services/quickstarts/voice-video-calling/get-started-call-recording?pivots=programming-language-csharp
