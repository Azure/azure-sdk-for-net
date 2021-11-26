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
  - AFDDomainHttpsParametersSecret
directive:
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
    where: $.definitions.AFDDomainHttpsParameters.properties
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
    where: $.definitions.AFDDomainHttpsParameters.properties.secret
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
      to: AFDProfiles_GetLogAnalyticsMetrics
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsRankings
      to: AFDProfiles_GetLogAnalyticsRankings
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsLocations
      to: AFDProfiles_GetLogAnalyticsLocations
  - rename-operation:
      from: LogAnalytics_GetLogAnalyticsResources
      to: AFDProfiles_GetLogAnalyticsResources
  - rename-operation:
      from: LogAnalytics_GetWafLogAnalyticsMetrics
      to: AFDProfiles_GetWafLogAnalyticsMetrics
  - rename-operation:
      from: LogAnalytics_GetWafLogAnalyticsRankings
      to: AFDProfiles_GetWafLogAnalyticsRankings
  - from: swagger-document
    where: $.definitions
    transform: >
      for (var key in $) {
          if (key.startsWith('AFD')) {
          const newKey = key.replace('AFD', 'Afd');
          $[key]['x-ms-client-name'] = newKey
              if (key === 'AfdDomain') {
                  $[key]['x-ms-client-name'] = 'AfdCustomDomain'
              }
          }
      }
  - remove-operation: AFDProfiles_CheckHostNameAvailability
  - remove-operation: Secrets_Update
  - remove-operation: Validate_Secret
```
