# Release History

## 1.1.0 (2021-11-24)

### Features Added
- Add a `ConnectionStates` dictionary to `WebPubSubConnectionContext` to manage connection state.
- Add the `TryGetConnectionState<T>` method in `WebPubSubConnectionContext` to get connection state in specific type.

### Breaking Changes
- The serialization format of `WebPubSubConnectionContext` has changed to be proper JSON intead of an object with nested values encoded as JSON strings.

## 1.0.0 (2021-11-09)

### Breaking Changes
- Rename `MessageDataType` to `WebPubSubDataType`.

## 1.0.0-beta.1 (2021-11-09)

### Features Added

- Common library to define the upstream requests and responses from Service to Server in Azure Web PubSub service.
