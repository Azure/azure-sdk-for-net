# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2024-04-03)
This Azure DevCenter library release uses the 2023-04-01 GA API.

### Features Added

- Added models and models serialization for each Dev Center concept
- Added methods in the clients returning the serialized model, not only BinaryData

### Breaking Changes

- Renamed `AzureDeveloperDevCenterClientOptions` back to `DevCenterClientOptions` 

## 1.0.0-beta.3 (2023-10-31)
This release updates the Azure DevCenter library to use the 2023-04-01 GA API.

### Breaking Changes

 - `EnvironmentsClient` renamed to `DeploymentEnvironmentsClient`
 - `DevBoxesClient` and `DeploymentEnvironmentsClient` no longer accepts project as a constructor parameter
 - `DeploymentEnvironmentsClient` now works with "environment definitions" instead of "catalog items"
 - Creating a new environment requires passing `environmentDefinitionName` instead of `catalogItemName`
 - Creating a new environment requires passing an additional parameter `catalogName`
 - `DevCenterClientOptions` renamed to `AzureDeveloperDevCenterClientOptions`
 - No more default parameters in the clients. `userId`, `filter`, `maxCount`, `hibernate` and `context` parameters need to be specified in the methods.   
 - `GetAction` renamed to `GetDevBoxAction`
 - `GetActions` renamed to `GetDevBoxActions`


## 1.0.0-beta.2 (2023-02-07)
This release updates the Azure DevCenter library to use the 2022-11-11-preview API.

### Breaking Changes

- `DevBoxClient`, `DevCenterClient`, and `EnvironmentsClient` now accept an endpoint URI on construction rather than tenant ID + dev center name.

### Features Added

- Added upcoming actions APIs to dev boxes.
    - `DelayUpcomingAction`
    - `GetUpcomingAction`
    - `GetUpcomingActions`
    - `SkipUpcomingAction`

### Bugs Fixed

- Invalid response types removed from `DeleteDevBox`, `StartDevBox`, and `StopDevBox` APIs.
- Invalid `DeleteEnvironmentAction` API removed from `EnvironmentsClient`.
- Unimplemented artifacts APIs removed from `EnvironmentsClient`.

## 1.0.0-beta.1 (2022-11-11)
This is the initial release of the Azure DevCenter library.
