# Release History

## 1.1.0-beta.2 (Unreleased)

### Features Added

- Upgraded API version to `2026-09-05-preview`.
- Added `ComputeSkuMixPlacementGenerateResult.Id` so the recommendation identifier is returned once per response.
- Added `ComputeSkuMixPlacementGenerateResult.CapacityLimits` and the `ComputeSkuMixPlacementCapacityLimit` model, which report the capacity ceiling that constrained a recommendation.
- Added the `SkuMixPlacementCapacityLimitReason` enum with values `None`, `InsufficientCapacity`, `InsufficientQuota`, and `SkuNotAvailable`.

### Breaking Changes

- Removed `ComputeSkuMixPlacementDeploymentChoice.Id`. Use `ComputeSkuMixPlacementGenerateResult.Id` instead; the identifier now applies to the whole response rather than to each individual placement choice.
- Removed `ComputeSkuMixPlacementItem.CapacityMax`. Use `ComputeSkuMixPlacementGenerateResult.CapacityLimits` instead, which reports the same ceiling along with the `Reason` it was applied.

## 1.1.0-beta.1 (2026-08-07)

### Features Added

- Upgraded API version to `2026-05-05-preview`.
- Added `SkuMixPlacement` scoring support via `GetComputeSkuMixPlacement`.

## 1.0.0 (2026-06-02)

This is the first stable release of this library.

### Other Changes

- Upgraded dependent Azure.Core to 1.57.0.
- Upgraded dependent Azure.ResourceManager to 1.14.0.

## 1.0.0-beta.2 (2025-11-03)

### Bugs Fixed

Fixed issue [53564](https://github.com/Azure/azure-sdk-for-net/issues/53564): Resolved incorrect request data of `GetSpotPlacementScore` operation.

## 1.0.0-beta.1 (2025-09-30)

### Features Added

- Release `Spot Placement Score` version `2025-06-05`
