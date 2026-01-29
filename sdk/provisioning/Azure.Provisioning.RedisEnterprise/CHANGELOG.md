# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-12-04)

### Features Added

- Update api-version to `2025-07-01`.
- Removed `ExperimentalAttribute` on the assembly.

### Breaking Changes

- Removed model `RedisEnterprisePrivateEndpointConnectionData`. Please use `RedisEnterprisePrivateEndpointConnection` instead.
- Changed the type of property `RedisEnterpriseCluster.PrivateEndpointConnections` from `BicepList<RedisEnterprisePrivateEndpointConnectionData>` to `BicepList<RedisEnterprisePrivateEndpointConnection>`.

## 1.0.0 (2025-08-26)

### Features Added

- The new Azure.Provisioning.RedisEnterprise experience.

## 1.0.0-beta.1 (2025-07-25)

### Features Added

- Initial beta release of new Azure.Provisioning.RedisEnterprise.
