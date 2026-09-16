# Azure.Provisioning.AppService ApiCompat Report

Updated on 2026-09-16 from:

```powershell
dotnet build sdk\websites\Azure.Provisioning.AppService\src\Azure.Provisioning.AppService.csproj --no-restore --verbosity:minimal
```

## Summary

The build failed ApiCompat with **44 unique compatibility diagnostics**. The same diagnostics occur for `netstandard2.0`, `net8.0`, and `net10.0`.

| Category | API changes | ApiCompat diagnostics |
|---|---:|---:|
| Removed public properties | 15 properties | 28 |
| Changed property types | 15 properties | 15 |
| Missing enum members | 1 member | 1 |
| **Total** | **31 changes** | **44** |

ApiCompat reports property getters and setters independently. Therefore, a removed read/write property normally produces two `CP0002` diagnostics.

## Unresolved issues

### 1. Removed public properties

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
| `SiteCertificate` | `Thumbprint` (read-only) | 1 |
| `SiteSlotCertificate` | `Thumbprint` (read-only) | 1 |

The certificate types now expose `ThumbprintString`, so the two `Thumbprint` failures appear to be API renames rather than removal of the underlying service data.

### 2. Changed property types

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

### 3. Missing enum member

`AppServiceSupportedTlsVersion.One3` is missing. The migrated enum exposes `Tls1_3`, making this an enum-member rename.

### Concentration and suggested order

The failures are concentrated rather than spread evenly:

1. Restore the `WebSite` and `WebSiteSlot` VNet flags: **16 diagnostics**.
2. Address the 15 scalar/model type changes.
3. Restore smaller renamed or removed members: `ApiDefinitionUri`, certificate `Thumbprint`, function app properties, and `One3`.

The VNet flag cluster accounts for **16 of 44 diagnostics (36%)**. The remaining work consists mainly of deliberate API-shape compatibility customizations.

## Resolved issues

### 1. Publishing-policy compatibility resources

The four legacy publishing-credential policy resource types have been restored as compatibility classes:

| Compatibility type | Generated base type | Fixed resource name |
|---|---|---|
| `ScmSiteBasicPublishingCredentialsPolicy` | `SiteBasicPublishingCredentialsPolicy` | `scm` |
| `ScmSiteSlotBasicPublishingCredentialsPolicy` | `SiteSlotBasicPublishingCredentialsPolicy` | `scm` |
| `WebSiteFtpPublishingCredentialsPolicy` | `SiteBasicPublishingCredentialsPolicy` | `ftp` |
| `WebSiteSlotFtpPublishingCredentialsPolicy` | `SiteSlotBasicPublishingCredentialsPolicy` | `ftp` |

The four original missing top-level type diagnostics and their nested `ResourceVersions` compatibility diagnostics are resolved. Each compatibility class owns its historical nested API-version metadata because nested types are not inherited as derived-type CLR metadata.

### 2. Deployment-extension compatibility properties

The seven legacy deployment-input properties have been restored on `SiteExtension`, `SiteInstanceExtension`, `SiteSlotExtension`, and `SiteSlotInstanceExtension`:

| Property | Bicep path |
|---|---|
| `ConnectionString` | `properties.connectionString` |
| `DBType` | `properties.dbType` |
| `IsAppOffline` | `properties.appOffline` |
| `PackageUri` | `properties.packageUri` |
| `SetParameters` | `properties.setParameters` |
| `SetParametersXmlFileUri` | `properties.setParametersXmlFileUri` |
| `SkipAppData` | `properties.skipAppData` |

The authoritative `Microsoft.Web@2025-03-01` Bicep schema declares all seven as write-only members of `MSDeployCoreOrMSDeployStatusProperties` and uses that model for all four writable resources. No legacy property was excluded. Custom partial classes temporarily restore the create-body properties omitted from the generated response model because of [#61011](https://github.com/Azure/azure-sdk-for-net/issues/61011). This resolves **28 removed properties and 56 diagnostics**.

### 3. Additional read/create model compatibility

The same [#61011](https://github.com/Azure/azure-sdk-for-net/issues/61011) limitation affected one write-only property and seven writable properties whose setters were omitted from generated response-oriented models:

| Type | Restored compatibility API | Bicep path |
|---|---|---|
| `StaticSiteCustomDomainOverview` | `ValidationMethod` | `properties.validationMethod` |
| `AppServiceVirtualNetworkRoute` | setter for `Kind` | `kind` |
| `AppServiceVirtualNetworkRoute` | setters for `StartAddress`, `EndAddress`, and `RouteType` | `properties.startAddress`, `properties.endAddress`, and `properties.routeType` |
| `RemotePrivateEndpointConnection` | setter for `Kind` | `kind` |
| `RemotePrivateEndpointConnection` | setters for `IPAddresses` and `PrivateLinkServiceConnectionState` | `properties.ipAddresses` and `properties.privateLinkServiceConnectionState` |

The `Microsoft.Web@2025-03-01` Bicep schema marks none of these fields read-only. Custom partial classes preserve their prior writable API surface and resolve **9 diagnostics**.
