# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.1 (2024-07-30)

### Bugs Fixed

- Fixed serialization of binary application properties.
- Fixed the logic used to set the `TimeToLive` value of the `AmqpMessageHeader` for received messages to be based on the difference of the `AbsoluteExpiryTime` and `CreationTime` properties of the `AmqpMessageProperties`.

## 1.3.0 (2023-03-02)

### Acknowledgments
Thank you to our developer community members who helped to make the Azure.Core.Amqp client library better with their contributions to this release:

- Daniel Marbach  _([GitHub](https://github.com/danielmarbach))_

### Features Added
- Added `ToBytes` and `FromBytes` methods to `AmqpAnnotatedMessage` to allow for serialization and deserialization of the message.

### Breaking Changes

- The nullability annotations were updated for the following properties of `AmqpAnnotatedMessage` to allow null values to be set in the dictionary, to comply with the [AMQP specification](https://docs.oasis-open.org/amqp/core/v1.0/os/amqp-core-messaging-v1.0-os.html#section-message-format):
  - `ApplicationProperties`
  - `DeliveryAnnotations`
  - `MessageAnnotations`
  - `Footer`

### Other Changes

- Make `AmqpAddress` and `AmqpMessageId` readonly structs. _(A community contribution, courtesy of [danielmarbach](https://github.com/danielmarbach))_

## 1.2.0 (2021-07-06)

### Added
- All section properties of the `AmqpAnnotatedMessage` are now lazily allocated to reflect that they are defined as optional in the AMQP specification, section 3.2.

- The `HasSection` method has been added to `AmqpAnnotatedMessage` to allow inspecting the property for a section to determine if it is populated without triggering an allocation.

## 1.1.0 (2021-06-16)

### Added
- General availability for Sequence and Value body messages.

## 1.1.0-beta.1 (2021-04-06)

### Added
- Added support for Sequence and Value body messages.

## 1.0.0 (2020-11-23)
- General availability release of Azure.Core.Amqp.

## 1.0.0-beta.1 (2020-11-04)

### Added
- AMQP models.
