# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: Monitor
namespace: Azure.ResourceManager.Monitor
require: C:\Users\dapzhang\Documents\workspace\azure-rest-api-specs/specification/monitor/resource-manager/readme.md

clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true

mgmt-debug:
  show-request-path: true

directive:
  - rename-model:
      from: AzureMonitorPrivateLinkScope
      to: PrivateLinkScope
  - rename-model:
      from: ScopedResource
      to: ScopedPrivateLink
  - rename-model:
      from: PrivateLinkResource
      to: PrivateLink
  - rename-model:
      from: MetricAlertResource
      to: MetricAlert
  - rename-model:
      from: DataCollectionRuleAssociation
      to: DataCollectionRuleAssociationProperties
  - rename-model:
      from: DataCollectionRuleAssociationProxyOnlyResource
      to: DataCollectionRuleAssociation
  - rename-model:
      from: ActionGroup
      to: ActionGroupProperties
  - rename-model:
      from: ActionGroupResource
      to: ActionGroup
  - rename-model:
      from: ActivityLogAlert
      to: ActivityLogAlertProperties
  - rename-model:
      from: ActivityLogAlertResource
      to: ActivityLogAlert
  - rename-model:
      from: AlertRule
      to: AlertRuleProperties
  - rename-model:
      from: AlertRuleResource
      to: AlertRule
  - rename-model:
      from: AutoscaleSetting
      to: AutoscaleSettingProperties
  - rename-model:
      from: AutoscaleSettingResource
      to: AutoscaleSetting
  - rename-model:
      from: DataCollectionEndpoint
      to: DataCollectionEndpointProperties
  - rename-model:
      from: DataCollectionEndpointResource
      to: DataCollectionEndpoint
  - rename-model:
      from: DataCollectionRule
      to: DataCollectionRuleProperties
  - rename-model:
      from: DataCollectionRuleResource
      to: DataCollectionRule
  - rename-model:
      from: DiagnosticSettingsCategory
      to: DiagnosticSettingsCategoryProperties
  - rename-model:
      from: DiagnosticSettingsCategoryResource
      to: DiagnosticSettingsCategory
  - rename-model:
      from: DiagnosticSettings
      to: DiagnosticSettingsProperties
  - rename-model:
      from: DiagnosticSettingsResource
      to: DiagnosticSettings
  - rename-model:
      from: LogProfileResource
      to: LogProfile
  - rename-model:
      from: LogSearchRule
      to: LogSearchRuleProperties
  - rename-model:
      from: LogSearchRuleResource
      to: LogSearchRule
  - rename-model:
      from: VMInsightsOnboardingStatus
      to: VmInsightsOnboardingStatus
```
