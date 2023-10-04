# Release History

## 1.0.4 (Unreleased)

### Features

- Added metrics to header. Will be used to track the number of requests and responses for each action.

### Other Changes

- Change version semantics to Major.Minor.Patch

### Bugs Fixed

- Updated ODataType signature. This was done to make sure the contracts were consistent across all services.
- Empty or null response actions will throw a bad response. There should be at lease one action passed as this is the main purpose of the SDK library. 
- Made the source field in the request a required field. 
- Made the request validation errors return 500. This way, we can identify that 500 errors as internal and should be marked as failures whereas response object errors should return 400s since they are customer input errors and should be identified as CallerErrors in our service.
- Made the ODataType field in the request a required field.

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
