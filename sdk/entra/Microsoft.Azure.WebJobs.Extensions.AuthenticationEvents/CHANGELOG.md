# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.5 (Unreleased)

### Bugs Fixed

- Updated Event Metrics to use GetExecutingAssembly instead of static dll name. This is to resolve the azure function error: Could not load file or assembly 'C:\Program Files (x86)\SiteExtensions\Functions\4.27.5\32bit\Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.dll'. The system cannot find the file specified.

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
