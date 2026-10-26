# Release History

## 1.0.0 (2026-10-15)

This is the first stable release of this library.

### Features Added

- Upgraded API version from `2026-10-01-preview` to the stable `2026-11-01` version.

### Breaking Changes

The following changes apply when upgrading from `1.0.0-beta.6`.

- Renamed the following public model types to align with the GA naming conventions. Update references to these types, including their constructors and the corresponding `ArmCloudHealthModelFactory` methods. Properties, method parameters, return types, and derived types that use these models now reference the new names.

  | Previous name | GA name |
  | --- | --- |
  | `DependenciesSignalGroupV2` | `HealthModelDependenciesSignalGroup` |
  | `DiscoveryError` | `HealthModelDiscoveryError` |
  | `DiscoveryRuleRecommendedSignalsBehavior` | `HealthModelDiscoveryRuleRecommendedSignalsBehavior` |
  | `DiscoveryRuleRelationshipDiscoveryBehavior` | `HealthModelDiscoveryRuleRelationshipDiscoveryBehavior` |
  | `DiscoveryRuleSpecification` | `HealthModelDiscoveryRuleSpecification` |
  | `EntityCoordinates` | `HealthModelEntityCoordinates` |
  | `EntityIcon` | `HealthModelEntityIcon` |
  | `EntityImpact` | `HealthModelEntityImpact` |
  | `EntitySignalThresholdRuleV2` | `EntitySignalThresholdRule` |
  | `ExternalSignal` | `HealthModelExternalSignal` |
  | `MetricAggregationType` | `HealthModelMetricAggregationType` |
  | `ResourceSignal` | `HealthModelResourceMetricSignal` |
  | `ResourceSignals` | `HealthModelResourceSignals` |
  | `SignalAggregationGroup` | `HealthModelSignalAggregationGroup` |
  | `SignalConfiguration` | `HealthModelSignalConfiguration` |
  | `SignalHistoryDataPoint` | `HealthModelSignalHistoryDataPoint` |
  | `SignalInstanceProperties` | `HealthModelSignalInstanceProperties` |
  | `SignalRecommendationConfiguration` | `HealthModelSignalRecommendationConfiguration` |
  | `SignalStatus` | `HealthModelSignalStatus` |

  The intermediate GA-generation names `CloudHealthMetricAggregationType`, `CloudHealthSignalConfiguration`, `CloudHealthSignalInstanceProperties`, and `CloudHealthSignalStatus` were also replaced by the corresponding `HealthModel` names above. The existing legacy types `DependenciesSignalGroupV1` and `EntitySignalThresholdRuleV1` retain their names.

- Renamed the predefined `EntitySignalRefreshInterval` members to descriptive C# names. Their ISO-8601 wire values are unchanged.

  | Previous member / wire value | GA member |
  | --- | --- |
  | `PT1M` | `OneMinute` |
  | `PT5M` | `FiveMinutes` |
  | `PT10M` | `TenMinutes` |
  | `PT15M` | `FifteenMinutes` |
  | `PT30M` | `ThirtyMinutes` |
  | `PT1H` | `OneHour` |
  | `PT2H` | `TwoHours` |

- Changed `HealthModelSignalConfiguration.ApplicableResourceTypes` (previously `SignalConfiguration.ApplicableResourceTypes`) from `IList<string>` to `IList<Azure.Core.ResourceType>`. The corresponding `ArmCloudHealthModelFactory.HealthModelSignalConfiguration` method now accepts `IEnumerable<Azure.Core.ResourceType>` instead of `IEnumerable<string>` for `applicableResourceTypes`. Update callers to use `ResourceType` values.

## 1.0.0-beta.6 (2026-10-15)

### Features Added

- Upgraded API version to 2026-10-01-preview

## 1.0.0-beta.5 (2026-09-04)

### Features Added

- Upgraded API version to 2026-09-01-preview

## 1.0.0-beta.4 (2026-08-06)

### Features Added

Additional Signal refresh interval added

## 1.0.0-beta.3 (2026-06-08)

### Features Added

Upgraded api-version to 2026-05-01-preview.

## 1.0.0-beta.2 (2026-04-20)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.53.0`.
- Upgraded dependent `Azure.ResourceManager` to `1.14.0`.

## 1.0.0-beta.1 (2025-06-20)

### Features Added

-   Initial SDK release for 'Microsoft.CloudHealth' resource provider/namespace.

### Features Added

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities:

    - Support MSAL.NET, Azure.Identity is out of box for supporting MSAL.NET.
    - Support [OpenTelemetry](https://opentelemetry.io/) for distributed tracing.
    - HTTP pipeline with custom policies.
    - Better error-handling.
    - Support uniform telemetry across all languages.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://docs.microsoft.com//dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
