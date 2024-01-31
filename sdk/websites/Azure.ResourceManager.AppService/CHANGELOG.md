# Release History

## 1.1.0-beta.5 (Unreleased)

### Features Added

- Enable the new model serialization by using the System.ClientModel, refer this [document](https://aka.ms/azsdk/net/mrw) for more details.

### Breaking Changes

### Bugs Fixed

-Add `200` to the response code of the `SyncFunctionTriggers`

### Other Changes

## 1.1.0-beta.4 (2023-11-30)

### Features Added

- Enable mocking for extension methods, refer this [document](https://aka.ms/azsdk/net/mocking) for more details.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.9.0.

## 1.1.0-beta.3 (2023-09-14)

### Bugs Fixed

- Due to `HealthCheckUri` not being a valid URI, add a new property `HealthCheckUriString` to replace it in order to fix the URI format issue.

## 1.1.0-beta.2 (2023-09-06)

### Bugs Fixed

- Fixed an issue that exception throws when `Uri` type field is empty during deserialization of `WebAppBackupData`.
- Fixed an issue that exception throws when `Uri` type field is empty during deserialization of `WebSiteInstanceStatusData`.
- Fixed an issue that exception throws when `Uri` type field is empty during deserialization of `AppServiceTableStorageApplicationLogsConfig`.

## 1.1.0-beta.1 (2023-05-31)

### Features Added

- Enable the model factory feature for model mocking, more information can be found [here](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking-factory-builder).
- Added `AppCertificateData.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `AppCertificateData.Thumbprint` has been hidden but is still available.
- Added `AppServiceVirtualNetworkData.CertThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `AppServiceVirtualNetworkData.CertThumbprint` has been hidden but is still available.
- Added `HostNameBindingData.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `HostNameBindingData.Thumbprint` has been hidden but is still available.
- Added `AppCertificatePatch.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `AppCertificatePatch.Thumbprint` has been hidden but is still available.
- Added `AppServiceAadRegistration.ClientSecretCertificateThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `AppServiceAadRegistration.ClientSecretCertificateThumbprint` has been hidden but is still available.
- Added `AppServiceCertificateDetails.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `AppServiceCertificateDetails.Thumbprint` has been hidden but is still available.
- Added `AppServiceVirtualNetworkProperties.CertThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `AppServiceVirtualNetworkProperties.CertThumbprint` has been hidden but is still available.
- Added `HostNameSslState.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `HostNameSslState.Thumbprint` has been hidden but is still available.
- Added `SiteAuthSettings.ClientSecretCertificateThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `SiteAuthSettings.ClientSecretCertificateThumbprint` has been hidden but is still available.
- Added `PublicCertificateData.ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `PublicCertificateData.Thumbprint` has been hidden but is still available.

### Other Changes

- Upgraded dependent Azure.Core to 1.32.0.
- Upgraded dependent Azure.ResourceManager to 1.6.0.

## 1.0.2 (2023-04-27)

### Bugs Fixed

- Fixed issue #34745. Introduced new property `RelayArmId` in `HybridConnectionData` class to replace the property `RelayArmUri` with a wrong type `Uri`.
- Fixed issue #35146. BadRequest when calling CreateOrUpdateFunctionSecretAsync

### Other Changes in API

Added property 'ResourceIdentifier RelayArmId' in type Azure.ResourceManager.AppService.HybridConnectionData
Added property 'WebAppKeyInfoProperties Properties' in type Azure.ResourceManager.AppService.Models.WebAppKeyInfo
Added type 'Azure.ResourceManager.AppService.Models.WebAppKeyInfoProperties'
Obsoleted property 'Uri RelayArmUri' in type Azure.ResourceManager.AppService.HybridConnectionData
Obsoleted property 'String Name' in type Azure.ResourceManager.AppService.Models.WebAppKeyInfo
Obsoleted property 'String Value' in type Azure.ResourceManager.AppService.Models.WebAppKeyInfo

### Azure SDK Dependency Changes

Upgraded Azure.Core from 1.28.0 to 1.31.0

## 1.0.1 (2023-02-20)

### Bugs Fixed

- Fixed serialization issue when service returns empty string for `KeyVaultId` in `AppCertificateData` and `AppCertificatePatch`.

### Other Changes

- Upgraded dependent `Azure.Core` to `1.28.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.4.0`.

## 1.0.0 (2022-09-29)

This release is the first stable release of the AppService Management library.

### Breaking Changes

Polishing since last public beta release:
- Corrected the format of all `IPAddress` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent Azure.ResourceManager to 1.3.1.
- Optimized the implementation of methods related to tag operations.

## 1.0.0-beta.4 (2022-08-29)

### Breaking Changes

Polishing since last public beta release:
- Prepended `AppService` prefix to all single / simple model names.
- Corrected the format of all `ResourceIdentifier` type properties / parameters.
- Corrected the format of all `AzureLocation` type properties / parameters.
- Corrected all acronyms that not follow [.Net Naming Guidelines](https://docs.microsoft.com/dotnet/standard/design-guidelines/naming-guidelines).
- Corrected enumeration name by following [Naming Enumerations Rule](https://docs.microsoft.com/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations).
- Corrected the suffix of `DateTimeOffset` properties / parameters.
- Corrected the name of interval / duration properties / parameters that end with units.
- Optimized the name of some models and functions.

### Other Changes

- Upgraded dependent `Azure.ResourceManager` to 1.3.0

## 1.0.0-beta.3 (2022-07-12)

### Breaking Changes

- Base type of `AnalysisDefinitionData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ApiKeyVaultReferenceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceCertificateOrderData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `AppServiceCertificateResourceData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `AppServiceDetectorData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceDomainData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `AppServiceEnvironmentData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `AppServicePlanData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `AseV3NetworkingConfigurationData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `BackupItemData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `CertificateData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `ContinuousWebJobData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `CsmPublishingCredentialsPoliciesEntityData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DeletedSiteData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DeploymentData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DetectorDefinitionAutoGeneratedData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DiagnosticCategoryData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DomainOwnershipIdentifierData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `FunctionEnvelopeData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `HostNameBindingData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `HybridConnectionData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `HybridConnectionLimitsData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `IdentifierData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `KubeEnvironmentData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `MigrateMySqlStatusData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `MSDeployStatusData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `NetworkFeaturesData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `PremierAddOnData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `PrivateAccessData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ProcessInfoData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ProcessModuleInfoData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `PublicCertificateData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RecommendationRuleData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RelayServiceConnectionEntityData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RemotePrivateEndpointConnectionARMResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RemotePrivateEndpointConnectionARMResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteConfigData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteExtensionInfoData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteLogsConfigData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteSourceControlData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SlotConfigNamesResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SourceControlData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteARMResourceData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `StaticSiteBuildARMResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteCustomDomainOverviewARMResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteUserProvidedFunctionAppARMResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SwiftVirtualNetworkData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `TopLevelDomainData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `TriggeredJobHistoryData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `UserData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `VnetGatewayData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `VnetInfoResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `WebJobData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `WebSiteData` changed to `Azure.ResourceManager.Models.TrackedResourceData`.
- Base type of `WebSiteInstanceStatusData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `WorkerPoolResourceData` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AddressResponse` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ApplicationStackResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceCertificateOrderPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceCertificateResourcePatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceDomainPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceEnvironmentPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServicePlanPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceRecommendation` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AppServiceUsage` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `AzureStoragePropertyDictionaryResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `BackupRequest` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `BillingMeter` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `CertificateEmail` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `CertificateOrderAction` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `CertificatePatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ConnectionStringDictionary` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `CustomHostnameAnalysisResult` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DeletedAppRestoreRequest` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DiagnosticAnalysis` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `DiagnosticDetectorResponse` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `FunctionAppStack` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `GeoRegion` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `HybridConnectionKey` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `KubeEnvironmentPatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `MigrateMySqlContent` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `MsDeploy` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `MsDeployLog` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `PremierAddOnOffer` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `PremierAddOnPatchResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `PrivateLinkConnectionApprovalRequestResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ProcessThreadInfo` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `PushSettings` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ReissueCertificateOrderContent` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RemotePrivateEndpointConnection` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RenewCertificateOrderContent` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `ResourceMetricDefinition` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `RestoreRequest` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteAuthSettings` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteAuthSettingsV2` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SiteConfigurationSnapshotInfo` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SitePatchResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SitePhpErrorLogFlag` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SlotDifference` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `Snapshot` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `SnapshotRestoreRequest` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteARMResourcePatch` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteCustomDomainRequestPropertiesARMResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteFunctionOverviewARMResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteResetPropertiesARMResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSitesWorkflowPreview` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSitesWorkflowPreviewContent` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteUserARMResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteUserInvitationRequestResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteUserInvitationResponseResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteUserProvidedFunctionApp` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StaticSiteZipDeploymentARMResource` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StorageMigrationContent` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StorageMigrationResponse` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StringDictionary` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `StringList` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `VnetContent` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `VnetRoute` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `VnetValidationFailureDetails` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `VnetValidationTestFailure` changed to `Azure.ResourceManager.Models.ResourceData`.
- Base type of `WebAppStack` changed to `Azure.ResourceManager.Models.ResourceData`.
- Type `AppServiceResource` was removed.
- Type `ProxyOnlyResource` was removed.

## 1.0.0-beta.2 (2022-04-08)

### Breaking Changes

- Simplify `type` property names.
- Normalized the body parameter type names for PUT / POST / PATCH operations if it is only used as input.

### Other Changes

- Upgrade dependency to Azure.ResourceManager 1.0.0

## 1.0.0-beta.1 (2022-03-31)

### Breaking Changes

New design of track 2 initial commit.

### Package Name

The package name has been changed from `Microsoft.Azure.Management.Websites` to `Azure.ResourceManager.AppService`.

### General New Features

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
