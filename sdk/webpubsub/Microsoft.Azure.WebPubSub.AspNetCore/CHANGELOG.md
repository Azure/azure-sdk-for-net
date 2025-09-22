# Release History

## 1.5.0 (2025-09-23)

### Features Added
- Support a custom hub name in `MapWebPubSubHub` extension method.

### Other Changes
- Upgrade `Azure.Messaging.WebPubSub` to 1.6.0.

## 1.4.0 (2024-09-25)

### Features Added
- Support MQTT client event handling.

## 1.3.0 (2024-04-10)

### Features Added

- Upgrade `Azure.Messaging.WebPubSub` to 1.3.0.
- Improve Hub method to support more accurate exceptions.

## 1.2.0 (2023-08-28)

### Bugs Fixed

- Fix multi request origins validation.

## 1.1.0 (2023-07-12)

### Bugs Fixed

- Fix secondary key validation failed.
- Fix multi request origins validation.

## 1.0.0 (2023-03-22)

### Features Added

- Generally available of `Microsoft.Azure.WebPubSub.AspNetCore` package.

### Breaking Changes

- Rename `ServiceEndpoint` to `WebPubSubServiceEndpoint`.

### Bugs Fixed

- Fix `Headers` field in `ConnectEventRequest` that was missed.

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
