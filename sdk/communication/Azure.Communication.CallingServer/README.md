# Azure Communication CallAutomation client library for .NET

This package contains a C# SDK for Azure Communication Call Automation.

[Source code][source] |[Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication CallAutomation client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.CallingServer --prerelease
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`CallAutomationClient` provides the functionality to answer incoming call or initialize an outbound call.

### Using statements
```C#
using System;
using System.Collections.Generic;
using Azure.Communication.CallingServer;
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
CallSource callSource = new CallSource(
       new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
       );
callSource.CallerId = new PhoneNumberIdentifier("<caller-id-phonenumber>") // E.164 formatted phone number that's associated to your Azure Communication Resource
```
```C#
CreateCallResult createCallResult = await callAutomationClient.CreateCallAsync(
    source: callSource,
    targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
    callbackEndpoint: new Uri(TestEnvironment.AppCallbackUrl)
    );
Console.WriteLine($"Call connection id: {createCallResult.CallConnectionProperties.CallConnectionId}");
```

### Handle Mid-Connection call back events
Your app will receive mid-connection call back events via the callbackEndpoint you provided. You will need to write event handler controller to receive the events and direct your app flow based on your business logic.
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
                // Helper function to parse CloudEvent to a CallingServer event.
                CallAutomationEventBase callBackEvent = EventParser.Parse(events.FirstOrDefault());
            
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

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

## Next steps

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
[communication_resource_docs]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://learn.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://learn.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[product_docs]: https://learn.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/a20e269162fa88a43e5ba0e5bb28f2e76c74a484/sdk/communication/Azure.Communication.CallingServer/src
