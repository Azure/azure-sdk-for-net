# Release History

## 1.0.0-beta.2 (Unreleased)
- GA release

### Features Added

### Breaking Changes
- Client Changes
    - POST call replaced with PUT
- Request changes:
    - Renamed createdDateTime into createdAt
    - Patients - Info renamed into Patients - Details
    - Unique ID required to be added in the request parameters
- Response changes:
    - "Datetime" field on FollowupCommunication renamed into "createdAt" field
    - Renamed createdDateTime into createdAt
    - Renamed expirationDateTime into expiresAt
    - Renamed lastUpdateDateTime into updatedAt

### Bugs Fixed

### Other Changes

## 1.0.0-beta.1 (2024-03-01)

- Initial preview of the Azure.Health.Insights.RadiologyInsights client library.
