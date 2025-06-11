# Release History

## 1.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.5 (2025-06-04)

### Other Changes

- Reshipping due to issue with symbols publishing in previous version.

## 1.0.0-beta.4 (2025-06-03)

### Features Added
- Added backcompat models.
- Mark media events as `EditorBrowsableState.Never` as the service has been deprecated.

## 1.0.0-beta.3 (2025-05-19)

### Features Added
- Added new communication events.
- Added new API management events.
- Add `EdgeSolutionVersionPublishedEventData` Edge event.

## 1.0.0-beta.2 (2025-02-21)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.
- Added various new system events and properties for existing events.

### Breaking Changes

- MQTT event naming was fixed to use correct casing.
- Media services events were removed as the service has been deprecated.
- Various properties were changed to be nullable.

## 1.0.0-beta.1 (2024-06-19)

### Features Added

- Initial beta release of Azure.Messaging.EventGrid.SystemEvents.
