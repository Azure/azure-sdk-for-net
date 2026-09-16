# Azure.Provisioning.AppService ApiCompat Report

Updated on 2026-09-16 from:

```powershell
dotnet build sdk\websites\Azure.Provisioning.AppService\src\Azure.Provisioning.AppService.csproj --no-restore --verbosity:minimal
```

## Summary

The build failed ApiCompat with **4 unique compatibility diagnostics**. The same diagnostics occur for `netstandard2.0`, `net8.0`, and `net10.0`.

| Category | API changes | ApiCompat diagnostics |
|---|---:|---:|
| Removed public properties | 1 property | 2 |
| Changed property types | 1 property | 1 |
| Missing enum members | 1 member | 1 |
| **Total** | **3 changes** | **4** |

ApiCompat reports property getters and setters independently. Therefore, a removed read/write property normally produces two `CP0002` diagnostics.

## Unresolved issues

### 1. Removed public properties

| Type | Removed read/write property |
|---|---|
| `FunctionAppStorage` | `Value` |

This accounts for **1 removed property and 2 diagnostics**.

### 2. Changed property types

This property still exists, but its migrated getter signature no longer matches the previous package:

| Type.property | Previous type | Current type |
|---|---|---|
| `ResponseMessageEnvelopeRemotePrivateEndpointConnection.Error` | `BicepValue<Azure.ResponseError>` | `ErrorEntity` |

This model-type difference cannot be addressed through a scalar `@@alternateType` customization.

### 3. Missing enum member

`AppServiceSupportedTlsVersion.One3` is missing. The migrated enum exposes `Tls1_3`, making this an enum-member rename.

### Concentration and suggested order

The remaining work consists of three deliberate API-shape compatibility customizations: restoring `FunctionAppStorage.Value`, preserving the legacy `Azure.ResponseError` representation, and restoring `AppServiceSupportedTlsVersion.One3`.

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

### 4. Legacy flattened VNet properties

The following legacy properties have been restored on both `WebSite` and `WebSiteSlot`:

- `IsVnetBackupRestoreEnabled`
- `IsVnetContentShareEnabled`
- `IsVnetImagePullEnabled`
- `IsVnetRouteAllEnabled`

Each public compatibility property is hidden from IntelliSense with `EditorBrowsableState.Never` and delegates to an internal `SiteProperties` property that preserves its original flattened wire path under `properties`. The current management library retains the same public compatibility APIs without marking them obsolete. New code should use `OutboundVnetRouting`.

This restores **8 properties and resolves 16 diagnostics**.

### 5. Legacy API definition URI

The URI-typed `ApiDefinitionUri` property has been restored on:

- `SiteConfigProperties`
- `WebSiteConfig`
- `WebSiteSlotConfig`

The current schema still uses `apiDefinition.url`, but the generated API now exposes it as the string-typed `ApiDefinitionUriStringValue` through an internal `AppServiceApiDefinitionInfo` model. The management library preserves the old URI-typed property with `EditorBrowsableState.Never` and no obsolete attribute.

The provisioning compatibility implementation follows the same public pattern. An internal URI-typed property preserves the `url` wire binding, and the three public EBN properties flatten it through the current nested models. This resolves **6 diagnostics**.

### 6. Function app HTTP concurrency property name

`FunctionAppScaleAndConcurrency.ConcurrentHttpPerInstanceConcurrency` has been restored with `CodeGenMember`, replacing the generated `TriggersConcurrentHttpPerInstanceConcurrency` name. The generated `Triggers` prefix exposed the nested wire-model structure rather than describing the public setting, while the legacy name continues to map to `triggers.http.perInstanceConcurrency`.

This restores **1 property and resolves 2 diagnostics**.

### 7. Legacy binary certificate thumbprints

The legacy `BicepValue<BinaryData> Thumbprint` getter has been restored on both `SiteCertificate` and `SiteSlotCertificate` without replacing the current string-typed `ThumbprintString` API. An internal output-only `CertificateProperties.Thumbprint` binding preserves the shared `properties.thumbprint` wire path.

The compatibility properties match the management library by using `EditorBrowsableState.Never` and an obsolete attribute directing callers to `ThumbprintString`. Explanatory notes document why both semantic representations are retained.

This restores **2 properties and resolves 2 diagnostics**.

### 8. Scalar semantic types

TypeSpec `@@alternateType` customizations now align 14 provisioning properties with the semantic types exposed by the current management library:

| Type.property | Restored type |
|---|---|
| `AppServiceBlobStorageApplicationLogsConfig.SasUri` | `BicepValue<Uri>` |
| `AppServiceBlobStorageHttpLogsConfig.SasUri` | `BicepValue<Uri>` |
| `AppServiceIPSecurityRestriction.VnetSubnetResourceId` | `BicepValue<ResourceIdentifier>` |
| `AppServiceSkuDescription.Locations` | `BicepList<AzureLocation>` |
| `CloningInfo.CorrelationId` | `BicepValue<Guid>` |
| `CloningInfo.SourceWebAppLocation` | `BicepValue<AzureLocation>` |
| `GitHubActionContainerConfiguration.ServerUri` | `BicepValue<Uri>` |
| `OpenIdConnectConfig.CertificationUri` | `BicepValue<Uri>` |
| `PrivateAccessVirtualNetwork.ResourceId` | `BicepValue<ResourceIdentifier>` |
| `RampUpRule.ChangeDecisionCallbackUri` | `BicepValue<Uri>` |
| `ResponseMessageEnvelopeRemotePrivateEndpointConnection.Location` | `BicepValue<AzureLocation>` |
| `StaticSiteDatabaseConnectionOverview.ResourceId` | `BicepValue<ResourceIdentifier>` |
| `StaticSiteLinkedBackendInfo.BackendResourceId` | `BicepValue<string>` |
| `StaticSiteTemplate.TemplateRepositoryUri` | `BicepValue<Uri>` |

The linked-backend resource ID required removing an existing `armResourceIdentifier` override because both the legacy provisioning API and the management API expose it as `string`. These changes resolve **14 diagnostics**.
