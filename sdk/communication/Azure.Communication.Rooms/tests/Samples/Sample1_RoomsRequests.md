# Room Service Requests

This sample demonstrates how to send requests to room service.

To get started you'll need a Communication Service Resource.  See [README] for prerequisites and instructions.

## Creating an `RoomsClient`

Rooms clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, Rooms clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using Azure.Communication.Rooms
```

## Create a new room

To create a new  ACS room, call the `CreateRoom` or `CreateRoomAsync` function from the RoomsClient. The returned value is `Response<CommunicationRoom>` which contains `CommunicationRoom` as well as the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
// Create communication users using the CommunicationIdentityClient
var communicationUser1 = communicationIdentityClient.CreateUserAsync().Result.Value;
var communicationUser2 = communicationIdentityClient.CreateUserAsync().Result.Value;

var validFrom = DateTimeOffset.UtcNow;
var validUntil = validFrom.AddDays(1);
RoomParticipant participant1 = new RoomParticipant(communicationUser1); // If role is not provided, then it is set as Attendee by default
RoomParticipant participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Presenter};
List<RoomParticipant> invitedParticipants = new List<RoomParticipant>
{
    participant1,
    participant2
};

Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, invitedParticipants);
CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
```

## Update an existing room

To update an existing ACS room, call the `UpdateRoom` or `UpdateRoomAsync` function from the RoomsClient. The returned value is `Response<CommunicationRoom>` which contains `CommunicationRoom` as well as the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
validUntil = validFrom.AddDays(30);
Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
```

## Get an existing room

To create an existing ACS room, call the `GetRoom` or `GetRoomAsync` function from the RoomsClient. The returned value is `Response<CommunicationRoom>` which contains `CommunicationRoom` as well as the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId);
CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
```


## Delete an existing room

To delete an existing ACS room, call the `DeleteRoom` or `DeleteRoomAsync` function from the RoomsClient. The returned value is `Response` object that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId);
```

## Upsert Participants to an existing room

To upsert participants to an existing ACS room, call the `UpsertParticipants` or `UpsertParticipantsAsync` function from the RoomsClient.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpsertParticipants
CommunicationIdentifier communicationUser3 = communicationIdentityClient.CreateUserAsync().Result.Value;
RoomParticipant newParticipant = new RoomParticipant(communicationUser3) { Role = ParticipantRole.Consumer };

// Previous snippet for create room added participant2 as Presenter
participant2 = new RoomParticipant(communicationUser2) { Role = ParticipantRole.Attendee };

List<RoomParticipant> participantsToUpsert = new List<RoomParticipant>
{
    participant2,   // participant2 updated from Presenter to Attendee
    newParticipant, // newParticipant added to the room
};

Response<UpsertParticipantsResult> upsertParticipantResponse = await roomsClient.UpsertParticipantsAsync(createdRoomId, participantsToUpsert);
```

## Remove Participants in an existing room

To remove participants in an existing ACS room, call the `RemoveParticipants` or `RemoveParticipantsAsync` function from the RoomsClient.
```C# Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
List<CommunicationIdentifier> participantsToRemove = new List<CommunicationIdentifier>
{
   communicationUser1,
   communicationUser2
};
Response<RemoveParticipantsResult> removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, participantsToRemove);
```

## Get participants in an existing room

To get participants from an existing ACS room, call the `GetParticipants` or `GetParticipantsAsync` function from the RoomsClient.
The returned value is `AsyncPageable<RoomParticipant>` or `Pageable<RoomParticipant>` which contains the paginated list of participants.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
AsyncPageable<RoomParticipant> allParticipants = roomsClient.GetParticipantsAsync(createdRoomId);
await foreach (RoomParticipant participant in allParticipants)
{
    Console.WriteLine($" Participant with id {participant.CommunicationIdentifier.RawId} is a {participant.Role}");
}
```
