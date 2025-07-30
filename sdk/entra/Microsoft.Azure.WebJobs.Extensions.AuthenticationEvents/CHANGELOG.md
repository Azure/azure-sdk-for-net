# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-07-29)

### Other Changes
- Package will target netstandard 2.0 and net 8.0.
- Package will reference the latest stable releases of its dependencies. 

## 1.0.1 (2024-06-25)

### Other Changes
- Updated README.md to reflect the latest changes

## 1.0.0 (2024-05-15)

### Other Changes
- Removed '--prerelease' from README.md

## 1.0.0-beta.8 (2024-05-01)

### Other Changes
- Updated Prefix WebJobs for WebjobsAuthenticationEventsTokenClaim -> WebJobsAuthenticationEventsTokenClaim

## 1.0.0-beta.7 (2024-04-15)

### Other Changes
- Consildated namespaces. Removing:
	- Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
	- Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions
	- Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Data

- Added Prefix WebJobs and WebJobsAuthenticationEvents to objects
	- ActionableCloudEventResponse -> WebJobsActionableCloudEventResponse
	- ActionableResponse -> WebJobsActionableResponse
	- AuthenticationEventAction -> WebJobsAuthenticationEventAction
	- AuthenticationEventAction -> WebJobsAuthenticationEventAction
	- AuthenticationEventContext -> WebJobsAuthenticationEventsContext
	- AuthenticationEventContextClient -> WebJobsAuthenticationEventsContextClient
	- AuthenticationEventContextServicePrincipal -> WebJobsAuthenticationEventsContextServicePrincipal
	- AuthenticationEventContextServicePrincipal -> WebJobsAuthenticationEventsContextServicePrincipal
	- AuthenticationEventContextUser -> WebJobsAuthenticationEventsContextUser
	- AuthenticationEventData -> WebJobsAuthenticationEventData
	- AuthenticationEventMetadataAttribute -> WebJobsAuthenticationEventMetadataAttribute
	- AuthenticationEventRequest -> WebJobsAuthenticationEventRequest
	- AuthenticationEventResponse -> WebJobsAuthenticationEventResponse
	- AuthenticationEventWebJobsStartup  -> WebJobsAuthenticationEventWebJobsStartup
	- CloudEventData -> WebJobsAuthenticationEventsCloudEventRequest
	- CloudEventData -> WebJobsAuthenticationEventsTypedData
	- ProvideClaimsForToken -> WebJobsProvideClaimsForToken
	- RequestStatusType -> WebJobsAuthenticationEventsRequestStatusType
	- TokenClaim -> WebjobsAuthenticationEventsTokenClaim
	- TokenIssuanceAction -> WebJobsTokenIssuanceAction
	- TokenIssuanceStartData -> WebJobsTokenIssuanceStartData
	- TokenIssuanceStartRequest -> WebJobsTokenIssuanceStartRequest
	- TokenIssuanceStartResponse -> WebJobsTokenIssuanceStartResponse

## 1.0.0-beta.6 (2024-03-13)

### Features Added

- Updated token internal validation to utlizie Microsoft.IdentityModel.Protocols.OpenIdConnect to get OIDC configuration.

### Breaking Changes

- Removing 'TeantId' from the AuthenticationEventTrigger Attribute API configuration
- Adding 'AuthorizedPartyAppId', 'AuthorityUrl' to the AuthenticationEventTrigger Attribute API configuration
- Adding 'AuthenticationEvents__ShowPIIDataInLogsKey` (defaults to true) to configuration manager for logging PIIData in logs
- Updated the Failed and Completed methods to not be async

### Bugs Fixed

- Made the request validation errors return 400 and the response validation errors return 500.

### Other Changes

- Cleaned out unused methods.
- Renamed MiscTests.cs to RequestResponseModelTests.cs

## 1.0.0-beta.5 (2023-12-07)

### Bugs Fixed

- Updated Event Metrics to use Assembly.GetName instead of static dll name.

## 1.0.0-beta.4 (2023-11-23)

### Features

- Added metrics to header. Will be used to track the number of requests and responses for each action.

### Bugs Fixed

- Updated ODataType signature. This was done to make sure the contracts were consistent across all services.
- Empty or null response actions will throw a bad response. There should be at lease one action passed as this is the main purpose of the SDK library. 
- Made the source field in the request a required field. 
- Made the request validation errors return 500. This way, we can identify that 500 errors as internal and should be marked as failures whereas response object errors should return 400s since they are customer input errors and should be identified as CallerErrors in our service.
- Made the ODataType field in the request a required field.
- Made the errors for JSON payload more descriptive when an invalid character is passed.
- Added JsonDocument TryParse check to validate payload is JSON format.

## 1.0.0-beta.3 (2022-12-13)

### Other Changes

- Changed event request "Payload" property to "Data"
- Removed country attribute from AuthenticationEventContextUser
- Added createdDateTime to AuthenticationEventContextUser
- Added new request status type for validation failure.
- Validation Errors raise 500 response.
- Added CustomAuthenticationExtensionId to Data.
- Removed AuthenticationEventsId from Data.

## 1.0.0-beta.2 (2022-11-08)

### Other Changes

- Removed legacy onTokenIssuanceStart contracts
- Updated responses to return 500 Internal error
- Added additional validation for Token Claims

## 1.0.0-beta.1 (2022-09-14)

### Other Changes

- The initial beta release
