# Azure Communication Rooms client library for .NET

This package contains a C# SDK for the Rooms Service of Azure Communication Services.

Rooms overview
    Azure Communication Services (ACS) Rooms is a set of APIs, used by Contoso server applications to create a server-managed conversation space with fixed set of lifetime and participants, pre-defining rules from server-tier both who and when can communicate (like scheduled meeting creation).

With the Public Preview release of ACS Rooms, Contoso will be able to:
    create a meeting space with known time coordinates (start/end time),
    join voice/video calls within that meeting space using the ACS web calling SDK or native mobile calling SDKs,
    add participants to a room,
    assign pre-defined roles to room participants,
    set rooms call join policies (e.g., open or closed room), and
    consume Event Grid notifications for calling events.
    The server-side functionalities can be accessed via a refreshed API and a full set of SDKs (.NET, Java, Python, JavaScript/TypeScript).

The main scenarios where Rooms can best be used:
    Virtual Visits (e.g., telemedicine, remote financial advisor, virtual classroom, etc...)
    Virtual Events (e.g., live event, company all-hands, live concert, etc...)
    Champion scenarios


[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]
## Getting started

### Install the package
Install the Azure Communication Rooms client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Rooms --prerelease
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`RoomsClient` provides the functionality to create room, update room, get room, delete room, add participants, remove participant, update participant and get participants.

### Using statements
```C# Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using Azure.Communication.Rooms
```

### Authenticate the client
Rooms clients can be authenticated using the connection string acquired from an Azure Communication Resource in the [Azure Portal][azure_portal].

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomsClient
var connectionString = Environment.GetEnvironmentVariable("connection_string") // Find your Communication Services resource in the Azure portal
RoomsClient client = new RoomsClient(connectionString);
```

## Examples

The following sections provide several code snippets covering some of the most common tasks, which is available at Sample1_RoomsRequests.md

## Troubleshooting
### Service Responses
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.
```C# Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
try
{
    CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
    var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
    var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value.Id;
    var validFrom = DateTime.UtcNow;
    var validUntil = validFrom.AddDays(1);
    List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
    RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
    RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
    CommunicationRoom createRoomResult = createRoomResponse.Value;
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Next steps
- [Read more about Rooms in Azure Communication Services][nextsteps]

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

<!-- TODO -->
Update the sample code links once the sdk is published
