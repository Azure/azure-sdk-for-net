# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2022-09-09)

### Features Added
- Added filter to DeviceManagement.ListDeviceClasses method
- Updated description for some methods to be more descriptive and less ambiguous

### Breaking Changes
- Removed filter from DeviceManagement.ListBestUpdatesForGroup method
- DeploymentDeviceStatesFilter.DeviceState property type changed from DeviceState to DeviceDeploymentState

## 1.0.0-beta.4 (2022-07-11)

### Features Added
- Added RelatedFiles and DownloadHandler to Update
- Updated various model that reference update to include not only UpdateId but also update Description and FriendlyName
- Removed device tag concept
- Allow to filter by deployment status in the GetDevicesAsync method
- Added ability to update device class friendly name
- Added ability to delete device class
- Added device class subgroups to groups
- Added new method to retrieve devices health information

### Breaking Changes
- DeviceUpdateClient models updated
- DeviceManagementClient models updated

## 1.0.0-beta.3 (2022-01-17)

### Features Added
- Added DeviceManagementClient
- Added DeviceUpdateClient
- Added GetDeviceModule Operation
- Added device import operations

### Breaking Changes
- Removed all models

### Other Changes
- Release Azure Device Update for IoT Hub library with protocol methods.

## 1.0.0-beta.2 (2021-04-06)
- Update root namespace from Azure.Iot.DeviceUpdate to Azure.IoT.DeviceUpdate

## 1.0.0-beta.1 (2021-03-03)
- This is the initial release of Azure Device Update for IoT Hub library.
