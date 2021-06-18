# Azure Communication CallingServer client library for .NET

This package contains a C# SDK for Azure Communication Services for Calling.

[Source code][source] |[Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication CallingServer client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.CallingServer --version 1.0.0-beta.1
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`CallingServerClient` provides the functionality to make call connection, join call connection or initialize a server call.

### Using statements
```C# Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using System;
using System.Collections.Generic;
using Azure.Communication.CallingServer;
```

### Authenticate the client
Calling server client can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_ServerCalling_Tests_Samples_CreateServerCallingClient
var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
CallingServerClient callingServerClient = new CallingServerClient(connectionString);
```

## Examples
### Make a call to a phone number recipient
To make an outbound call, call the `CreateCallConnection` or `CreateCallConnectionAsync` function from the `CallingServerClient`.
```C# Snippet:Azure_Communication_Call_Tests_CreateCallOptions
var createCallOption = new CreateCallOptions(
       new Uri(TestEnvironment.AppCallbackUrl),
       new[] { MediaType.Audio },
       new[]
       {
           EventSubscriptionType.ParticipantsUpdated,
           EventSubscriptionType.DtmfReceived
       });
```
```C# Snippet:Azure_Communication_Call_Tests_CreateCallAsync
var callConnection = await callingServerClient.CreateCallConnectionAsync(
    source: new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
    targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
    options: createCallOption // The options for creating a call.
    );
Console.WriteLine($"Call connection id: {callConnection.Value.CallConnectionId}");
```

## Troubleshooting
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.

## Next steps

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/
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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/a20e269162fa88a43e5ba0e5bb28f2e76c74a484/sdk/communication/Azure.Communication.CallingServer/src
