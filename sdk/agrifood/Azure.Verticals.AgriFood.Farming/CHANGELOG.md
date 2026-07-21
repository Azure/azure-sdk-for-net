# Release History

## 1.0.0-beta.3 (Unreleased)

### Breaking Changes

- Renamed the sub-clients to service-prefixed names to comply with type-naming guidelines: `Attachments`→`FarmingAttachments`, `Boundaries`→`FarmingBoundaries`, `Crops`→`FarmingCrops`, `Devices`→`FarmingDevices`, `Farms`→`FarmingFarms`, `Fields`→`FarmingFields`, `Insights`→`FarmingInsights`, `Parties`→`FarmingParties`, `Prescriptions`→`FarmingPrescriptions`, `Scenes`→`FarmingScenes`, `Seasons`→`FarmingSeasons`, `Sensors`→`FarmingSensors`, `Weather`→`FarmingWeather`, `Zones`→`FarmingZones`. The corresponding `Get<Name>Client()` accessors were renamed accordingly (for example, `GetFarmsClient()`→`GetFarmingFarmsClient()`).

## 1.0.0-beta.2 (2023-02-22)

### Features Added

- Adding clients for Sensor Integration which includes crud operations on DeviceDataModels, Devices, SensorDataModels, Sensors, SensorMappings, SensorPartnerIntegration and get Sensor events.
- Renaming farmers to parties as per the new API version
- Renaming Crop Variety to Crop Product
- Adding new APIs for STAC search

## 1.0.0-beta.1 (2021-05-26)

### New Features

- Initial Preview Release of the Azure FarmBeats client library for .NET
