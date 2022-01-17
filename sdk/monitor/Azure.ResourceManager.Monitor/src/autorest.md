# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: Monitor
namespace: Azure.ResourceManager.Monitor
require: https://github.com/Azure/azure-rest-api-specs/blob/35f8a4df47aedc1ce185c854595cba6b83fa6c71/specification/monitor/resource-manager/readme.md

clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true
#   naming:
#     override:
#       DataCollectionEndpoint: DataCollectionEndpointProperties

mgmt-debug:
  show-request-path: true

directive:
  - from: swagger-document
    where: $.definitions.ActivityLogAlert.properties.actions
    transform: >
        $["x-nullable"] = true;
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
  - from: swagger-document
    where: $.definitions.DataCollectionRuleAssociationProxyOnlyResource.properties.properties
    transform:  >
        $ = {
          "description": "Resource properties.",
          "allOf": [
            {
              "$ref": "#/definitions/DataCollectionRuleAssociation"
            }
          ],
          "x-ms-client-flatten": false
        }
#   - rename-model:
#       from: DataCollectionRuleAssociation
#       to: DataCollectionRuleAssociationProperties
  - from: swagger-document
    where: $.definitions.DataCollectionRuleAssociation
    transform: $["x-ms-client-name"] = "DataCollectionRuleAssociationProperties"
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
  - from: swagger-document
    where: $.definitions.DataCollectionEndpointResource.properties.properties
    transform:  >
        $ = {
          "description": "Resource properties.",
          "allOf": [
            {
              "$ref": "#/definitions/DataCollectionEndpoint"
            }
          ],
          "x-ms-client-flatten": false
        }
#   - rename-model:
#       from: DataCollectionEndpoint
#       to: DataCollectionEndpointProperties
  - from: swagger-document
    where: $.definitions.DataCollectionEndpoint
    transform: $["x-ms-client-name"] = "DataCollectionEndpointProperties"
  - rename-model:
      from: DataCollectionEndpointResource
      to: DataCollectionEndpoint
  - from: swagger-document
    where: $.definitions.DataCollectionRuleResource.properties.properties
    transform:  >
        $ = {
          "description": "Resource properties.",
          "allOf": [
            {
              "$ref": "#/definitions/DataCollectionRule"
            }
          ],
          "x-ms-client-flatten": false
        }
#   - rename-model:
#       from: DataCollectionRule
#       to: DataCollectionRuleProperties
  - from: swagger-document
    where: $.definitions.DataCollectionRule
    transform: $["x-ms-client-name"] = "DataCollectionRuleProperties"
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
#   - rename-model:
#       from: Resource
#       to: MonitorResource
  - from: activityLogAlerts_API.json
    where: $.definitions.Resource
    transform: $["x-ms-client-name"] = "ActivityLogAlertsResource"
```
