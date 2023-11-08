# Release History

## 1.1.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.1 (2023-09-19)

### Features Added
- Added support for PSTN dial-out capability

### Added
- Added new overloads for CreateRoom (CreateRoomAsync) and UpdateRooms (UpdateRoomsAsync) with options : CreateRoomOptions and UpdateRoomOptions. 

## 1.0.0 (2023-06-12)
General Availability version of the Azure Communication Services Rooms .NET SDK.

## 1.0.0-beta.2 (2023-05-17)

### Features Added
- Added new function `ListRooms` to list all created rooms by returning `Pageable<CommunicationRoom>`.
- Added pagination support for `GetParticipants` by returning `Pageable<RoomParticipant>`.

### Breaking Changes
- Changed: Replaced `AddParticipants` and `UpdateParticipants` with `AddOrUpdateParticipants`.
- Changed: Renamed `RoleType` to `ParticipantRole`.
- Changed: Renamed `CreatedOn` to `CreatedAt` in `CommunicationRoom`.
- Changed: `UpdateRoom` no longer accepts participant list as input.
- Removed: `RoomJoinPolicy`, all rooms are invite-only by default.
- Removed: `Participants` from `CommunicationRoom` class.


## 1.0.0-beta.1 (2022-08-10)
- Initial version of Azure Communication Services Rooms .NET SDK.
