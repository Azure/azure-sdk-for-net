# Azure Communication Rooms client library for .NET

This package contains a C# SDK for the Rooms Service of Azure Communication Services.
Azure Communication Services (ACS) Rooms is a set of APIs, used by Contoso server applications to create a server-managed conversation space with fixed set of lifetime and participants, pre-defining rules from server-tier both who and when can communicate (like scheduled meeting creation).

With the general availability release of ACS Rooms, Contoso will be able to:

    - Create a meeting space with known time coordinates (validFrom/validUntil)
    - Join voice/video calls within that meeting space using the ACS web calling SDK or native mobile calling SDKs
    - Add participants to a room
    - Assign pre-defined roles to room participants

The main scenarios where Rooms can best be used:

    - Virtual Visits (e.g., telemedicine, remote financial advisor, virtual classroom, etc...)
    - Virtual Events (e.g., live event, company all-hands, live concert, etc...)

[Source code][source] <!--| [Package (NuGet)][package]--> | [Product documentation][product_docs] | [Samples][source_samples]
## Getting started

### Install the package
Install the Azure Communication Rooms client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Rooms
``` 

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Key concepts
`RoomsClient` provides the functionality to create room, update room, get room, list rooms, delete room, add participants, update participants, remove participants, and list participants.

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
### Create a room
To create a room, call the `CreateRoom` or `CreateRoomAsync` function from `RoomsClient`.
The `validFrom`, `validUntil` and `participants` arguments are all optional. If `validFrom` and `validUntil` are not provided, then the default for `validFrom` is current date time and the default for `validUntil` is `validFrom + 180 days`.
When defining `RoomParticipant`, if role is not specified, then it will be `Attendee` by default.
Starting in 1.1.0-beta.1 release, `pstnDialOutEnabled` is added to enable PSTN Dial-Out feature in a Room. 
The returned value is `Response<CommunicationRoom>` which contains created room details as well as the status and associated error codes in case of a failure.

Starting in 1.1.0-beta.1 release, ACS Rooms supports PSTN Dial-Out feature. To create room with PSTN Dial-Out property, call `CreateRoom` or `CreateRoomAsync` function with `createRoomOptions` parameter and set `PstnDialOutEnabled` to either true or false. If `PstnDialOutEnabled` is not provided, then the default value for `PstnDialOutEnabled` is false.
This parameter contains `ValidFrom`, `ValidUntil`, `PstnDialOutEnabled` and `Participants` properties. Those properties are optional.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
// Create communication users using the CommunicationIdentityClient
Response<CommunicationUserIdentifier> communicationUser1 = await communicationIdentityClient.CreateUserAsync();
Response<CommunicationUserIdentifier> communicationUser2 = await communicationIdentityClient.CreateUserAsync();

DateTimeOffset validFrom = DateTimeOffset.UtcNow;
DateTimeOffset validUntil = validFrom.AddDays(1);
RoomParticipant participant1 = new RoomParticipant(communicationUser1.Value); // If role is not provided, then it is set as Attendee by default
RoomParticipant participant2 = new RoomParticipant(communicationUser2.Value) { Role = ParticipantRole.Presenter};
List<RoomParticipant> invitedParticipants = new List<RoomParticipant>
{
    participant1,
    participant2
};

Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, invitedParticipants);
CommunicationRoom createCommunicationRoom = createRoomResponse.Value;

// Starting in 1.1.0-beta.1 release,CreateRoom function also takes roomCreateOptions as parameter
bool pstnDialOutEnabled = true;
CreateRoomOptions roomCreateOptions = new CreateRoomOptions()
{
    ValidFrom = validFrom,
    ValidUntil = validUntil,
    PstnDialOutEnabled = pstnDialOutEnabled,
    Participants = invitedParticipants
};

createRoomResponse = await roomsClient.CreateRoomAsync(roomCreateOptions);
createCommunicationRoom = createRoomResponse.Value;
```

### Update a room
The `validFrom` and `validUntil` properties of a created room can be updated by calling the `UpdateRoom` or `UpdateRoomAsync` function from `RoomsClient`.

Starting in 1.1.0-beta.1 release, ACS Rooms supports PSTN Dial-Out feature. To update room with PSTN Dial-Out property, call `UpdateRoom` or `UpdateRoomAsync` function with `updateRoomOptions` parameter and set `PstnDialOutEnabled` to either true or false.If `PstnDialOutEnabled` is not provided, there there is no changes to `PstnDialOutEnabled` property in the room.
The `updateRoomOptions` parameter contains `ValidFrom`, `ValidUntil` and `PstnDialOutEnabled` properties. Those properties are optional.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
validUntil = validFrom.AddDays(30);
Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;

// Starting in 1.1.0-beta.1 release,UpdateRoom function also takes roomCreateOptions as parameter
UpdateRoomOptions roomUpdateOptions = new UpdateRoomOptions()
{
    ValidFrom = validFrom,
    ValidUntil = validUntil,
    PstnDialOutEnabled = pstnDialOutEnabled,
};

updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, roomUpdateOptions);
updateCommunicationRoom = updateRoomResponse.Value;
```

### Get a created room
A created room can be retrieved by calling the `GetRoom` or `GetRoomAsync` function from `RoomsClient` and passing in the associated `roomId`.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
```

### Get all rooms
All valid rooms created under an ACS resource can be retrieved by calling the `GetRooms` or `GetRoomsAsync` function from `RoomsClient`.
```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomsAsync
// Retrieve the first 2 pages of active rooms
const int PageSize = 30;
const int PageCount = 2;
int maxRoomCount = PageCount * PageSize;
int counter = 1;

AsyncPageable<CommunicationRoom> allRooms = roomsClient.GetRoomsAsync();
await foreach (CommunicationRoom room in allRooms)
{
    Console.WriteLine($"Room with id {room.Id} is valid from {room.ValidFrom} to {room.ValidUntil}.");
    counter++;

    if (counter == maxRoomCount)
    {
        break;
    }
}
```

### Delete room
To delete a room, call the `DeleteRoom` or `DeleteRoomAsync` function from RoomsClient.
```C# Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
```

### Add Or update participants in a room
In order to add new participants or update existing participants, call the `AddOrUpdateParticipants` or `AddOrUpdateParticipantsAsync` function from RoomsClient.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_AddOrUpdateParticipants
Response<CommunicationUserIdentifier> communicationUser3 = await communicationIdentityClient.CreateUserAsync();
RoomParticipant newParticipant = new RoomParticipant(communicationUser3.Value) { Role = ParticipantRole.Consumer };

// Previous snippet for create room added participant2 as Presenter
participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Attendee };

List<RoomParticipant> participantsToAddOrUpdate = new List<RoomParticipant>
{
    participant2,   // participant2 updated from Presenter to Attendee
    newParticipant, // newParticipant added to the room
};

Response addOrUpdateParticipantResponse = await roomsClient.AddOrUpdateParticipantsAsync(createdRoomId, participantsToAddOrUpdate);
```

### Remove participants in a room
To remove participants from a room, call the `RemoveParticipants` or `RemoveParticipantsAsync` function from RoomsClient.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
List<CommunicationIdentifier> participantsToRemove = new List<CommunicationIdentifier>
{
   communicationUser1,
   communicationUser2
};
Response removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, participantsToRemove);
```


### Get participants in a room
To get all the participants from a room, call the `GetParticipants` or `GetParticipantsAsync` function from RoomsClient.
The returned value is `Pageable<RoomParticipant>` or `AsyncPageable<RoomParticipant>` which contains the paginated list of participants.
```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
await foreach (RoomParticipant participant in allParticipants)
{
    Console.WriteLine($" Participant with id {participant.CommunicationIdentifier.RawId} is a {participant.Role}");
}
```

## Troubleshooting
### Service Responses
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.
```C# Snippet:Azure_Communication_RoomsClient_Tests_Troubleshooting
try
{
    CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
    Response<CommunicationUserIdentifier> communicationUser1 = await communicationIdentityClient.CreateUserAsync();
    Response<CommunicationUserIdentifier> communicationUser2 = await communicationIdentityClient.CreateUserAsync();
    DateTimeOffset validFrom = DateTimeOffset.UtcNow;
    DateTimeOffset validUntil = validFrom.AddDays(1);
    List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
    RoomParticipant participant1 = new RoomParticipant(communicationUser1.Value) { Role = ParticipantRole.Presenter };
    RoomParticipant participant2 = new RoomParticipant(communicationUser2.Value) { Role = ParticipantRole.Attendee };
    Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, createRoomParticipants);
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
[nextsteps]: https://learn.microsoft.com/azure/communication-services/quickstarts/rooms/get-started-rooms?tabs=windows&pivots=programming-language-csharp
[nuget]: https://www.nuget.org/
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Rooms/src
[source_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Rooms/tests/Samples

<!-- TODO -->
Update the sample code links once the sdk is published
