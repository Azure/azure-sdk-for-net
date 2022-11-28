# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2022-11-11)

### Features Added
- Support `Headers` field in `ConnectEventRequest` to carry over client headers.

### Bugs Fixed
- Fix the issue about `expiresAfter` with corner values.

## 1.0.0-beta.3 (2022-01-06)

### Features Added

- Integrate with rest client to inject `WebPubSubServiceClient<TWebPubSubHub>` in hub methods.

## 1.0.0-beta.2 (2021-11-24)

### Features Added

- Add a `ConnectionStates` dictionary to `UserEventResponse` and `ConnectEventResponse` to manage connection state.

## 1.0.0-beta.1 (2021-11-09)

### Features Added

- Server side library to read and handle upstream requests using Azure Web PubSub service.
