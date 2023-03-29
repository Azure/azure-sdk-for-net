# Release History

## 1.0.0-beta.2 (2023-03-31-preview)

### Features Added
- Added new function `ListRooms` to list all created rooms by returning `Pageable<CommunicationRoom>`,
- Added pagination support for `GetParticipants` by returning `Pageable<RoomParticipant>`.

### Breaking Changes
- Removed `Participants` from `CommunicationRoom` class.
- Removed `RoomJoinPolicy`, all rooms are invite-only by default.
- `UpdateRoom` no longer accepts participant list as input.
- Replaced `AddParticipants` and `UpdateParticipants` with `UpsertParticipants`
- Renamed `RoleType` to `ParticipantRole`
- Renamed `CreatedOn` to `CreatedAt` in `CommunicationRoom`

## 1.0.0-beta.1 (2022-08-10)
- Initial version of Azure Communication Services Rooms .NET SDK.
