# Azure.Provisioning.AppService ApiCompat Report

Updated on 2026-09-16 from:

```powershell
dotnet build sdk\websites\Azure.Provisioning.AppService\src\Azure.Provisioning.AppService.csproj --no-restore --verbosity:minimal
```

## Summary

The build failed ApiCompat with **109 unique compatibility diagnostics**. The same diagnostics occur for `netstandard2.0`, `net8.0`, and `net10.0`.

| Category | API changes | ApiCompat diagnostics |
|---|---:|---:|
| Removed public properties | 44 properties | 86 |
| Changed property types | 15 properties | 15 |
| Removed public setters | 7 properties | 7 |
| Missing enum members | 1 member | 1 |
| **Total** | **67 changes** | **109** |

ApiCompat reports property getters and setters independently. Therefore, a removed read/write property normally produces two `CP0002` diagnostics.

## 1. Publishing-policy compatibility resources

The four legacy publishing-credential policy resource types have been restored as compatibility classes:

| Compatibility type | Generated base type | Fixed resource name |
|---|---|---|
| `ScmSiteBasicPublishingCredentialsPolicy` | `SiteBasicPublishingCredentialsPolicy` | `scm` |
| `ScmSiteSlotBasicPublishingCredentialsPolicy` | `SiteSlotBasicPublishingCredentialsPolicy` | `scm` |
| `WebSiteFtpPublishingCredentialsPolicy` | `SiteBasicPublishingCredentialsPolicy` | `ftp` |
| `WebSiteSlotFtpPublishingCredentialsPolicy` | `SiteSlotBasicPublishingCredentialsPolicy` | `ftp` |

The four original missing top-level type diagnostics and their nested `ResourceVersions` compatibility diagnostics are resolved. Each compatibility class owns its historical nested API-version metadata because nested types are not inherited as derived-type CLR metadata.

## 2. Removed public properties

### Deployment-extension resources

The following seven read/write properties are absent from each of `SiteExtension`, `SiteInstanceExtension`, `SiteSlotExtension`, and `SiteSlotInstanceExtension`:

- `ConnectionString`
- `DBType`
- `IsAppOffline`
- `PackageUri`
- `SetParameters`
- `SetParametersXmlFileUri`
- `SkipAppData`

This accounts for **28 removed properties and 56 diagnostics**.

### Web site VNet settings

The following four read/write properties are absent from both `WebSite` and `WebSiteSlot`:

- `IsVnetBackupRestoreEnabled`
- `IsVnetContentShareEnabled`
- `IsVnetImagePullEnabled`
- `IsVnetRouteAllEnabled`

This accounts for **8 removed properties and 16 diagnostics**.

### API definition URI

The read/write `ApiDefinitionUri` property is absent from:

- `SiteConfigProperties`
- `WebSiteConfig`
- `WebSiteSlotConfig`

This accounts for **3 removed properties and 6 diagnostics**.

### Function app models

| Type | Removed read/write property |
|---|---|
| `FunctionAppScaleAndConcurrency` | `ConcurrentHttpPerInstanceConcurrency` |
| `FunctionAppStorage` | `Value` |

This accounts for **2 removed properties and 4 diagnostics**.

### Other removed properties

| Type | Removed property | Diagnostics |
|---|---|---:|
| `StaticSiteCustomDomainOverview` | `ValidationMethod` (read/write) | 2 |
| `SiteCertificate` | `Thumbprint` (read-only) | 1 |
| `SiteSlotCertificate` | `Thumbprint` (read-only) | 1 |

The certificate types now expose `ThumbprintString`, so the two `Thumbprint` failures appear to be API renames rather than removal of the underlying service data.

## 3. Changed property types

These properties still exist, but their migrated getter signatures no longer match the previous package:

| Type.property | Previous type | Current type |
|---|---|---|
| `AppServiceBlobStorageApplicationLogsConfig.SasUri` | `BicepValue<Uri>` | `BicepValue<string>` |
| `AppServiceBlobStorageHttpLogsConfig.SasUri` | `BicepValue<Uri>` | `BicepValue<string>` |
| `AppServiceIPSecurityRestriction.VnetSubnetResourceId` | `BicepValue<ResourceIdentifier>` | `BicepValue<string>` |
| `AppServiceSkuDescription.Locations` | `BicepList<AzureLocation>` | `BicepList<string>` |
| `CloningInfo.CorrelationId` | `BicepValue<Guid>` | `BicepValue<string>` |
| `CloningInfo.SourceWebAppLocation` | `BicepValue<AzureLocation>` | `BicepValue<string>` |
| `GitHubActionContainerConfiguration.ServerUri` | `BicepValue<Uri>` | `BicepValue<string>` |
| `OpenIdConnectConfig.CertificationUri` | `BicepValue<Uri>` | `BicepValue<string>` |
| `PrivateAccessVirtualNetwork.ResourceId` | `BicepValue<ResourceIdentifier>` | `BicepValue<string>` |
| `RampUpRule.ChangeDecisionCallbackUri` | `BicepValue<Uri>` | `BicepValue<string>` |
| `ResponseMessageEnvelopeRemotePrivateEndpointConnection.Error` | `BicepValue<Azure.ResponseError>` | `ErrorEntity` |
| `ResponseMessageEnvelopeRemotePrivateEndpointConnection.Location` | `BicepValue<AzureLocation>` | `BicepValue<string>` |
| `StaticSiteDatabaseConnectionOverview.ResourceId` | `BicepValue<ResourceIdentifier>` | `BicepValue<string>` |
| `StaticSiteLinkedBackendInfo.BackendResourceId` | `BicepValue<string>` | `BicepValue<ResourceIdentifier>` |
| `StaticSiteTemplate.TemplateRepositoryUri` | `BicepValue<Uri>` | `BicepValue<string>` |

Most of this category is scalar semantic drift from URI, resource identifier, location, or GUID types to `string`. `StaticSiteLinkedBackendInfo.BackendResourceId` changed in the opposite direction, from `string` to `ResourceIdentifier`.

## 4. Removed public setters

These properties remain readable but became read-only:

| Type | Properties |
|---|---|
| `AppServiceVirtualNetworkRoute` | `EndAddress`, `Kind`, `RouteType`, `StartAddress` |
| `RemotePrivateEndpointConnection` | `IPAddresses`, `Kind`, `PrivateLinkServiceConnectionState` |

This category produces **7 `CP0002` diagnostics**.

## 5. Missing enum member

`AppServiceSupportedTlsVersion.One3` is missing. The migrated enum exposes `Tls1_3`, making this an enum-member rename.

## Concentration and suggested order

The failures are concentrated rather than spread evenly:

1. Restore the four deployment-extension property sets first: **56 diagnostics**.
2. Restore the `WebSite` and `WebSiteSlot` VNet flags: **16 diagnostics**.
3. Address the 15 scalar/model type changes and 7 setter-accessibility changes.
4. Restore smaller renamed or removed members: `ApiDefinitionUri`, certificate `Thumbprint`, `ValidationMethod`, function app properties, and `One3`.

The first two clusters account for **72 of 109 diagnostics (66%)**. The remaining work consists mainly of deliberate API-shape compatibility customizations.
