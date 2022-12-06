# Room Service Requests

This sample demonstrates how to send requests to room service.

To get started you'll need a Communication Service Resource.  See [README] for prerequisites and instructions.

## Creating an `RoomsClient`

Rooms clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, Rooms clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using Azure.Communication.Rooms
```

## Create a new room

To create a new  ACS room, call the `CreateRoom` or `CreateRoomAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
var validFrom = DateTime.UtcNow;
var validUntil = validFrom.AddDays(1);
List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
createRoomParticipants.Add(participant1);
createRoomParticipants.Add(participant2);
Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
```

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync
var validFrom = DateTime.UtcNow;
var validUntil = validFrom.AddDays(1);
List<RoomParticipant> createRoomParticipants = new List<RoomParticipant>();
RoomParticipant participant1 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), RoleType.Presenter);
RoomParticipant participant2 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), RoleType.Attendee);
createRoomParticipants.Add(participant1);
createRoomParticipants.Add(participant2);
Response<CommunicationRoom> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, createRoomParticipants);
CommunicationRoom createCommunicationRoom = createRoomResponse.Value;
```

## Create a new open room

To create a new  ACS open room, call the `CreateRoom` or `CreateRoomAsync` function from the RoomsClient with the roomJoinPolicy set to CommunicationServiceUsersValue. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateOpenRoomAsync
Response<CommunicationRoom> createOpenRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.CommunicationServiceUsers);
CommunicationRoom createCommunicationOpenRoom = createOpenRoomResponse.Value;
```

## Update an existing room

To update an existing ACS room, call the `UpdateRoom` or `UpdateRoomAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
```
```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync
Response<CommunicationRoom> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
CommunicationRoom updateCommunicationRoom = updateRoomResponse.Value;
```

## Get an existing room

To create an existing ACS room, call the `GetRoom` or `GetRoomAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
Response<CommunicationRoom> getRoomResponse = await roomsClient.GetRoomAsync(
    createdRoomId: "existing room Id which is created already
    createdRoomId);
CommunicationRoom getCommunicationRoom = getRoomResponse.Value;
```


## Delete an existing room

To delete an existing ACS room, call the `DeleteRoom` or `DeleteRoomAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(
    createdRoomId: "existing room Id which is created already
     createdRoomId);
```

## Add Participants to an existing room

To add participants to an existing ACS room, call the `AddParticipants` or `AddParticipantsAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants
List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>();
toAddCommunicationUsers.Add(participant3);

Response addParticipantResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
```

## Update Participants in an existing room

To update participants in an existing ACS room, call the `UpdateParticipants` or `UpdateParticipantsAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateParticipants
List<RoomParticipant> toUpdateCommunicationUsers = new List<RoomParticipant>();
participant3 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser3), "Presenter");
participant4 = new RoomParticipant(new CommunicationUserIdentifier(communicationUser4), "Presenter");
toUpdateCommunicationUsers.Add(participant3);
toUpdateCommunicationUsers.Add(participant4);

Response updateParticipantResponse = await roomsClient.UpdateParticipantsAsync(createdRoomId, toUpdateCommunicationUsers);
```

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
List<CommunicationIdentifier> toRemoveCommunicationUsers = new List<CommunicationIdentifier>();
toRemoveCommunicationUsers.Add(new CommunicationUserIdentifier(communicationUser2));

Response removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
```

## Get participants in an existing room

To get participants from an existing ACS room, call the `GetParticipants` or `GetParticipantsAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
Response<ParticipantsCollection> participantResponse = await roomsClient.GetParticipantsAsync(createdRoomId);
```
