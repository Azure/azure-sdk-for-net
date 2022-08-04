# Room Service Requests

This sample demonstrates how to send requests to room service.

To get started you'll need a Communication Service Resource.  See [README] for prerequisites and instructions.

## Creating an `RoomsClient`

Rooms clients can be authenticated using the connection string acquired from an Azure Communication Resource in the Azure Portal. Alternatively, Rooms clients can also be authenticated using a valid token credential.

```C# Snippet:Azure_Communication_Rooms_Tests_UsingStatements
using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Communication.Rooms
```

## Create a new room

To create a new  ACS room, call the `CreateRoom` or `CreateRoomAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync - Creating a room with Participants
RoomRequest request = new RoomRequest();
Response<RoomModel> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.InviteOnly, participants);
RoomModel createCommunicationRoom = createRoomResponse.Value;
```

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateRoomAsync - Creating a room without Participants
RoomRequest request = new RoomRequest();
Response<RoomModel> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil);
RoomModel createCommunicationRoom = createRoomResponse.Value;
```

## Create a new open room

To create a new  ACS open room, call the `CreateRoom` or `CreateRoomAsync` function from the RoomsClient with the roomJoinPolicy set to CommunicationServiceUsersValue. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_CreateOpenRoomAsync
RoomRequest request = new RoomRequest();
Response<RoomModel> createRoomResponse = await roomsClient.CreateRoomAsync(validFrom, validUntil, RoomJoinPolicy.CommunicationServiceUsersValue);
RoomModel createCommunicationRoom = createRoomResponse.Value;
```

## Update an existing room

To update an existing ACS room, call the `UpdateRoom` or `UpdateRoomAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync - update a room's valid from, valid until and participants
Response<RoomModel> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil, RoomJoinPolicy.InviteOnly, participants);
RoomModel updateCommunicationRoom = updateRoomResponse.Value;
```
```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateRoomAsync - update a room's valid from, valid until
Response<RoomModel> updateRoomResponse = await roomsClient.UpdateRoomAsync(createdRoomId, validFrom, validUntil);
RoomModel updateCommunicationRoom = updateRoomResponse.Value;
```

## Get an existing room

To create an existing ACS room, call the `GetRoom` or `GetRoomAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetRoomAsync
Response<RoomModel> getRoomResponse = await roomsClient.GetRoomAsync(createdRoomId)
RoomModel getCommunicationRoom = getRoomResponse.Value;
```


## Delete an existing room

To delete an existing ACS room, call the `DeleteRoom` or `DeleteRoomAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_DeleteRoomAsync
Response deleteRoomResponse = await roomsClient.DeleteRoomAsync(createdRoomId)
```

## Add Participants to an existing room

To add participants to an existing ACS room, call the `AddParticipants` or `AddParticipantsAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_AddParticipants
var communicationUser1 = "8:acs:067a8658-0bae-44f3-b157-194921040238_be3a83c1-f5d9-49ee-a427-0e9b917c063e";
var communicationUser2 = "8:acs:067a8658-0bae-44f3-b157-194921040238_be3a83c6-f5d9-79ee-a427-0e9b917c063e";
var communicationUser3 = "8:acs:067a8658-0bae-44f3-b157-194921040238_be3a83c6-f5d9-80ee-a427-0e9b917c063e";

List<RoomParticipant> toAddCommunicationUsers = new List<RoomParticipant>();
toAddCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser1), "Presenter"));
toAddCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser2), "Attendee");
toAddCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser3), "Attendee");

Response<RoomModel> addParticipantResponse = await roomsClient.AddParticipantsAsync(createdRoomId, toAddCommunicationUsers);
RoomModel addedParticipantsRoom = addParticipantResponse.Value;
```

## Update Participants in an existing room

To update participants in an existing ACS room, call the `UpdateParticipants` or `UpdateParticipantsAsync` function from the RoomsClient. The returned value is `RoomModel` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_UpdateParticipants
var communicationUser1 = "8:acs:067a8658-0bae-44f3-b157-194921040238_be3a83c1-f5d9-49ee-a427-0e9b917c063e";
var communicationUser2 = "8:acs:067a8658-0bae-44f3-b157-194921040238_be3a83c6-f5d9-79ee-a427-0e9b917c063e";
var communicationUser3 = "8:acs:067a8658-0bae-44f3-b157-194921040238_be3a83c6-f5d9-80ee-a427-0e9b917c063e";

List<RoomParticipant> toUpdateCommunicationUsers = new List<RoomParticipant>();
toAddCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser1)));
toAddCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser2)));
toAddCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser3));

Response<RoomModel> updateParticipantResponse = await roomsClient.UpdateParticipantsAsync(createdRoomId, toUpdateCommunicationUsers);
RoomModel updatedParticipantsRoom = updateParticipantResponse.Value;

## Remove participants from an existing room

To remove participants from an existing ACS room, call the `RemoveParticipants` or `RemoveParticipantsAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_RemoveParticipants
List<RoomParticipant> toRemoveCommunicationUsers = new List<RoomParticipant>();
toRemoveCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser1)));
toRemoveCommunicationUsers.Add(new RoomParticipant(new CommunicationUserIdentifier(communicationUser2)));

Response<RoomModel> removeParticipantResponse = await roomsClient.RemoveParticipantsAsync(createdRoomId, toRemoveCommunicationUsers);
RoomModel removedParticipantsRoom = removeParticipantResponse.Value;
```

## Get participants in an existing room

To get participants from an existing ACS room, call the `GetParticipants` or `GetParticipantsAsync` function from the RoomsClient. The returned value is `RoomResult` objects that contains the status and associated error codes in case of a failure.

```C# Snippet:Azure_Communication_Rooms_Tests_Samples_GetParticipants
Response<ParticipantsCollection> getParticipantResponse = await roomsClient.getParticipantsAsync(createdRoomId);
ParticipantsCollection roomParticipants = getParticipantResponse.Value;
```
