# Release History

## 1.2.0-beta.1 (Unreleased)

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
