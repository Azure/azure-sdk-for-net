# Release History

## 1.1.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0-beta.1 (2026-03-11)

### Features Added

- Added support for `NetworkSecurityPerimeter` resources:
  - `NetworkSecurityPerimeter`
  - `NetworkSecurityPerimeterAccessRule`
  - `NetworkSecurityPerimeterAssociation`
  - `NetworkSecurityPerimeterLink`
  - `NetworkSecurityPerimeterLoggingConfiguration`
  - `NetworkSecurityPerimeterProfile`

## 1.0.0 (2026-03-04)

### Features Added

- Regenerated from `Azure.ResourceManager.Network` version 1.15.0.
- Added `ServiceGatewayId` property to `NatGateway` and `SubnetResource`.
- Added new `FirewallPolicyIntrusionDetectionProfileType` values: `Off`, `Emerging`, `Core`, and `Extended`.

## 1.0.0-beta.4 (2026-03-02)

### Breaking Changes

- Removed generated enum `SyncRemoteAddressSpace`. This type was not used by any public API.

## 1.0.0-beta.3 (2026-01-07)

### Features Added

- Updated to latest api-version.
- Added `PrivateDnsZoneGroup` resource.

## 1.0.0-beta.2 (2025-12-10)

### Other Changes

- Bump dependent package `Azure.Provisioning` to 1.4.0

## 1.0.0-beta.1 (2025-09-05)

### Features Added

- Initial beta release of new Azure.Provisioning.Network.
