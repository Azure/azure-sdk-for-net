# Release History

## 1.4.0-beta.2 (2025-11-10)

### Features Added

- Added extension method `BicepValueExtensions.ToBicepExpression` which converts any `IBicepValue` into `BicepExpression` to build up complex expressions in bicep. For more details, please refer to the documents in `README`.
- Added `BicepFunction.GetResourceId` corresponding to bicep built-in function `resourceId`.
- Added `BicepFunction.GetExtensionResourceId` corresponding to bicep built-in function `extensionResourceId`.

### Bugs Fixed

- Enabled the ability to assign expressions into a property with type of a `ProvisionableConstruct` via low level APIs.
- Fixed exception when output variable has a type of array or object.
- Fixed bug when indexing output list or dictionary, a `KeyNotFoundException` was always thrown. ([#48491](https://github.com/Azure/azure-sdk-for-net/issues/48491))

### Other Changes

- Now collection types (`BicepList<T>` and `BicepDictionary<T>`) would be able to force to be empty. ([#53346](https://github.com/Azure/azure-sdk-for-net/issues/53346))

## 1.4.0-beta.1 (2025-09-03)

### Features Added

- Added a new protected API in `ProvisionableConstruct` to support a `ProvisionableResource` as property of another `ProvisionableConstruct`.

## 1.3.0 (2025-08-01)

### Features Added

- Supported `FormattableString` in `BicepFunction.Interpolate` method. ([#47360](https://github.com/Azure/azure-sdk-for-net/issues/47360))

## 1.2.1 (2025-07-09)

### Bugs Fixed

- Fixed the incorrect property name for discriminators in `AzureCliScript` and `AzurePowerShellScript` ([#51135](https://github.com/Azure/azure-sdk-for-net/issues/51135))
- Fixed the incorrect format for `TimeSpan` properties in `AzureCliScript` and `AzurePowerShellScript` ([#51135](https://github.com/Azure/azure-sdk-for-net/issues/51135))

## 1.2.0 (2025-07-02)

### Features Added

- Updated models to match the latest API version for ArmDeployment and ArmDeploymentScript.
- Added derived types (`AzureCliScript` and `AzurePowerShellScript`) for `ArmDeploymentScript` to support different kind of deployment scripts.
    - Please note that usually `ArmDeploymentScript` should not be constructed directly, but rather through the `AzureCliScript` or `AzurePowerShellScript` constructors.

## 1.1.0 (2025-06-16)

### Features Added

- Updated to use latest API version.

## 1.0.1 (2025-05-30)

### Bugs Fixed

- Now floating number values are properly serialized into bicep via `json()` function ([#48249](https://github.com/Azure/azure-sdk-for-net/issues/48249))
- Fixed issues in interpolated strings ([#48493](https://github.com/Azure/azure-sdk-for-net/issues/48493))

## 1.0.0 (2024-10-25)

### Features Added

- The new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.

## 0.3.0 (2024-05-14)

### Features Added

- Added support for all Bicep parameter/output types.

### Other Changes

- Updated dependency on Azure Resource Manager libraries to leverage serialization fix involving property assignments.

## 0.2.0 (2024-04-24)

### Features Added

- Initial non-beta release.

## 0.2.0-beta.2 (2024-04-09)

### Features Added

- Added `AddDependency` method.

## 0.2.0-beta.1 (2024-04-04)

### Features Added

- Split the Azure.Provisioning package into separate packages for each supported Azure service.

## 0.1.0-beta.2 (2024-03-28)

### Features Added

- Added `storageSizeInGB` paramater to `PostgreSqlFlexibleServerData` constructor.

## 0.1.0-beta.1 (2024-03-26)

### Features Added

- Initial beta release of Azure.Provisioning.
