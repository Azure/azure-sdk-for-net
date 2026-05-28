# Release History

## 1.6.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.5.0 (2025-09-28)

### Other Changes
- Update the dependencies to the latest versions.

## 1.4.0 (2024-09-25)

### Other Changes
- Updated the (de)serialization of Web PubSub CloudEvents with `System.Text.Json` library.

## 1.3.0 (2024-09-04)

### Features Added
- Support MQTT event handlers.
- Add `Content` field in `WebPubSubClientCertificate` to carry over client certificate content.

## 1.2.0 (2022-10-31)

### Features Added
- Add `Headers` field in `ConnectEventRequest` to carry over client headers.

## 1.1.0 (2021-11-24)

### Features Added
- Add a `ConnectionStates` dictionary to `WebPubSubConnectionContext` to manage connection state.

### Breaking Changes
- The serialization format of `WebPubSubConnectionContext.States` has changed to be proper JSON intead of an object with nested values encoded as JSON strings.

## 1.0.0 (2021-11-09)

### Breaking Changes
- Rename `MessageDataType` to `WebPubSubDataType`.

## 1.0.0-beta.1 (2021-11-09)

### Features Added

- Common library to define the upstream requests and responses from Service to Server in Azure Web PubSub service.
