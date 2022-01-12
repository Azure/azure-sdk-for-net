# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
library-name: Cdn
namespace: Azure.ResourceManager.Cdn
require: https://github.com/Azure/azure-rest-api-specs/blob/2cd7c6eacc5430d8956885e8d19b87ce3f3ebd6e/specification/cdn/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
modelerfour:
  lenient-model-deduplication: true
no-property-type-replacement: 
  - ContinentsResponseContinentsItem
  - EndpointPropertiesUpdateParametersDefaultOriginGroup
  - EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink
  - AfdCustomDomainHttpsParametersSecret
directive:
  - from: swagger-document
    where: $.definitions
    transform: >
        for (var key in $) {
            if (key === 'AFDDomainHttpsParameters')
            {
                const newKey = 'AfdCustomDomainHttpsParameters'
                $[newKey] = $[key]
                delete $[key]
            }
        }
  - from: swagger-document
    where: $.definitions.AFDDomainUpdatePropertiesParameters.properties.tlsSettings
    transform: $['$ref'] = '#/definitions/AfdCustomDomainHttpsParameters'
  - from: swagger-document
    where: $.definitions.EndpointPropertiesUpdateParameters.properties
    transform: >
        $.defaultOriginGroup = {
            "description": "A reference to the origin group.",
            "type": "object",
            "properties": {
                "id": {
                    "type": "string",
                    "description": "Resource ID."
                }
            }
        }
  - from: swagger-document
    where: $.definitions.AfdCustomDomainHttpsParameters.properties
    transform: >
        $.secret = {
            "description": "Resource reference to the secret. ie. subs/rg/profile/secret",
            "type": "object",
            "properties": {
                "id": {
                    "type": "string",
                    "description": "Resource ID."
                }
            }
        }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/origins/{originName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}/originGroups/{originGroupName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/customDomains/{customDomainName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/afdEndpoints/{endpointName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/originGroups/{originGroupName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/originGroups/{originGroupName}/origins/{originName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/afdEndpoints/{endpointName}/routes/{routeName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/securityPolicies/{securityPolicyName}'].patch
    transform: >
      $['x-ms-long-running-operation-options'] = {
          "final-state-via": "original-uri"
      }
  - from: swagger-document
    where: $.definitions.EndpointPropertiesUpdateParameters.properties.defaultOriginGroup
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.EndpointPropertiesUpdateParameters.properties.optimizationType
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.EndpointPropertiesUpdateParameters.properties.urlSigningKeys
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.EndpointPropertiesUpdateParameters.properties.deliveryPolicy
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.EndpointPropertiesUpdateParameters.properties.webApplicationFirewallPolicyLink
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.*.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes
    transform: $['x-nullable'] = true
  - from: cdn.json
    where: $.definitions.*.properties.responseBasedOriginErrorDetectionSettings
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.AFDOriginGroupUpdatePropertiesParameters.properties.responseBasedAfdOriginErrorDetectionSettings
    transform: $['x-nullable'] = true
  - from: cdn.json
    where: $.definitions.*.properties.healthProbeSettings
    transform: $['x-nullable'] = true
  - from: cdn.json
    where: $.definitions.*.properties.httpPort
    transform: $['x-nullable'] = true
  - from: cdn.json
    where: $.definitions.*.properties.httpsPort
    transform: $['x-nullable'] = true
  - from: cdn.json
    where: $.definitions.*.properties.priority
    transform: $['x-nullable'] = true
  - from: cdn.json
    where: $.definitions.*.properties.weight
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.OriginProperties.properties.privateEndpointStatus
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.WafMetricsResponse.properties.series.items.properties.groups
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.AfdCustomDomainHttpsParameters.properties.secret
    transform: $['x-nullable'] = true
  - from: afdx.json
    where: $.definitions.*.properties.priority
    transform: $['x-nullable'] = true
  - from: afdx.json
    where: $.definitions.*.properties.weight
    transform: $['x-nullable'] = true
  - from: afdx.json
    where: $.definitions.AFDOriginUpdatePropertiesParameters.properties.sharedPrivateLinkResource
    transform: $['x-nullable'] = true
  - from: swagger-document
    where: $.definitions.policySettings.properties.defaultCustomBlockResponseStatusCode
    transform: $['x-nullable'] = true  
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}'].put.parameters[3]
    transform: $['x-ms-client-name'] = 'endpointInput'
  - from: swagger-document
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/afdEndpoints/{endpointName}'].put.parameters[3]
    transform: $['x-ms-client-name'] = 'endpointInput'
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsMetrics
      to: AfdProfiles_GetLogAnalyticsMetrics
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsRankings
      to: AfdProfiles_GetLogAnalyticsRankings
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsLocations
      to: AfdProfiles_GetLogAnalyticsLocations
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsResources
      to: AfdProfiles_GetLogAnalyticsResources
  - rename-operation:
      from: LogAnalytics_GetWafLogAnalyticsMetrics
      to: AfdProfiles_GetWafLogAnalyticsMetrics
  - rename-operation:
      from: LogAnalytics_GetWafLogAnalyticsRankings
      to: AfdProfiles_GetWafLogAnalyticsRankings
  - remove-operation: AFDProfiles_CheckHostNameAvailability
  - remove-operation: Secrets_Update
  - remove-operation: Validate_Secret
#  - remove-operation: CheckNameAvailability
  - from: swagger-document
    where: $.definitions.AFDEndpointProtocols
    transform: >
      $['x-ms-enum'] = {
          "name": "AfdEndpointProtocols",
          "modelAsString": true
      }
  - from: swagger-document
    where: $.definitions
    transform: >
      for (var key in $) {
          if (key.startsWith('AFD')) {
              const newKey = key.replace('AFD', 'Afd');
              $[key]['x-ms-client-name'] = newKey
              if (['AFDEndpointUpdateParameters', 'AFDOriginGroupUpdateParameters', 'AFDOriginUpdateParameters'].includes(key)) {
                  const newerKey = newKey.replace('Parameters', 'Options');
                  $[key]['x-ms-client-name'] = newerKey
              }
          }
          if (key.startsWith('AFDDomain')) {
              const newKey = key.replace('AFDDomain', 'AfdCustomDomain');
              $[key]['x-ms-client-name'] = newKey
              if (key === 'AFDDomainUpdateParameters') {
                  const newerKey = newKey.replace('Parameters', 'Options');
                  $[key]['x-ms-client-name'] = newerKey
              }
          }
          if (['Endpoint', 'Origin', 'OriginGroup', 'CustomDomain'].includes(key)) {
              const newKey = 'Cdn' + key;
              $[key]['x-ms-client-name'] = newKey
          }
          if (['Route', 'RuleSet', 'Rule', 'SecurityPolicy', 'Secret'].includes(key)) {
              const newKey = 'Afd' + key;
              $[key]['x-ms-client-name'] = newKey
          }
          if (['AfdPurgeParameters', 'CdnManagedHttpsParameters', 'CdnWebApplicationFirewallPolicyPatchParameters', 'CustomDomainHttpsParameters', 'CustomDomainParameters', 'EndpointUpdateParameters', 'LoadParameters', 'OriginGroupUpdateParameters', 'OriginUpdateParameters', 'ProfileUpdateParameters', 'PurgeParameters', 'RouteUpdateParameters', 'RuleUpdateParameters', 'UserManagedHttpsParameters'].includes(key)) {
              const newKey = key.replace('Parameters', 'Options');
              $[key]['x-ms-client-name'] = newKey
          }
      }
  - from: swagger-document
    where: $.definitions.UrlSigningActionParameters.properties.algorithm
    transform: >
      $['x-ms-enum'] = {
          "name": "urlSigningAlgorithm",
          "modelAsString": true
      }
  - from: swagger-document
    where: $.definitions.MatchCondition.properties.operator
    transform: >
      $['x-ms-enum'] = {
          "name": "matchOperator",
          "modelAsString": true
      }
  - from: swagger-document
    where: $.definitions.transform
    transform: >
      $['x-ms-enum'] = {
          "name": "transformCategory",
          "modelAsString": true
      }
  - from: swagger-document
    where: $.paths
    transform: >
      for (var key in $) {
          for (var method in $[key]) {
              const oldOperationId = $[key][method]['operationId']
              if (oldOperationId.startsWith('AFD')) {
                  const newOperationId = oldOperationId.replace('AFD', 'Afd')
                  $[key][method]['operationId'] = newOperationId
              }
              if (oldOperationId.startsWith('Routes') || oldOperationId.startsWith('RuleSets') || oldOperationId.startsWith('Rules') || oldOperationId.startsWith('SecurityPolicies') || oldOperationId.startsWith('Secrets')) {
                  const newOperationId = 'Afd' + oldOperationId
                  $[key][method]['operationId'] = newOperationId
              }
              if (oldOperationId.startsWith('Endpoint') || oldOperationId.startsWith('Origin') || oldOperationId.startsWith('OriginGroup') || oldOperationId.startsWith('CustomDomain')) {
                  const newOperationId = 'Cdn' + oldOperationId
                  $[key][method]['operationId'] = newOperationId
              }
          }
      }
```
