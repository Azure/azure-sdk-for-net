# Release History

## 1.1.0 (2025-06-13)

### Features Added

- Class `QualityMeasureInference` added
- Class `ScoringAndAssessmentInference` added
- Class `GuidanceInference` added  

## 1.0.0 (2024-08-16)
- GA release

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes
- Client Changes
    - POST call replaced with PUT
- Request changes:
    - Renamed createdDateTime into createdAt
    - Patients - Info renamed into Patients - Details
    - Unique ID required to be added in the request parameters
	- Make use of Managed Identity for authentication
- Response changes:
    - "Datetime" field on FollowupCommunication renamed into "createdAt" field
    - Renamed createdDateTime into createdAt
    - Renamed expirationDateTime into expiresAt
    - Renamed lastUpdateDateTime into updatedAt

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-03-01)

- Initial preview of the Azure.Health.Insights.RadiologyInsights client library.
