# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Cdn
namespace: Azure.ResourceManager.Cdn
title: CdnManagementClient
require: https://github.com/Azure/azure-rest-api-specs/blob/a0c83df51e02f4e0b21ff3ae72c5a1ac52f72586/specification/cdn/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
output-folder: Generated/
operation-id-mappings:
  CdnEndpoint:
      profileName: Microsoft.Cdn/operationresults/profileresults
      endpointName: Microsoft.Cdn/operationresults/profileresults/endpointresults
rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  Vmos: VmOS
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  Url: Uri
  URL: Uri
  AFDDomain: AfdCustomDomain
  AFD: Afd
  GET: Get
  PUT: Put
  TLSv1: Tls10
  TLSv11: Tls11
  TLSv12: Tls12
  TLS10: Tls10
  TLS12: Tls12
  SHA256: Sha256

no-property-type-replacement: 
  - ContinentsResponseContinentsItem
  - EndpointPropertiesUpdateParametersDefaultOriginGroup
  - EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink
  - AfdCustomDomainHttpsContentSecret
  - AfdCustomDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId
override-operation-name:
  CheckNameAvailability: CheckCdnNameAvailability
  CheckNameAvailabilityWithSubscription: CheckCdnNameAvailabilityWithSubscription
  AfdProfiles_CheckHostNameAvailability: CheckAfdProfileHostNameAvailability
  LogAnalytics_GetLogAnalyticsMetrics: GetLogAnalyticsMetrics
  LogAnalytics_GetLogAnalyticsRankings: GetLogAnalyticsRankings
  LogAnalytics_GetLogAnalyticsResources: GetLogAnalyticsResources
  LogAnalytics_GetLogAnalyticsLocations: GetLogAnalyticsLocations
  LogAnalytics_GetWafLogAnalyticsMetrics: GetWafLogAnalyticsMetrics
  LogAnalytics_GetWafLogAnalyticsRankings: GetWafLogAnalyticsRankings
  AfdEndpoints_ListResourceUsage: GetAfdEndpointResourceUsage
directive:
  - from: cdn.json
    where: $.definitions
    transform: >
      for (var key in $) {
            if (key.endsWith('Parameters')) {
                for (var property in $[key].properties) {
                    if (property === 'typeName' && $[key].properties[property].enum.length === 1) {
                        const newKey = key.replace('Parameters', '');
                        $[key]['x-ms-client-name'] = newKey + 'Definition';
                        $[key].properties.typeName['x-ms-client-name'] = 'typeDefinition';
                        $[key].properties.typeName['x-ms-enum'] = {
                            "name": newKey + 'Type',
                            "modelAsString": true,
                            "values": [
                                {
                                    "value": $[key].properties.typeName.enum[0],
                                    "name": $[key].properties.typeName.enum[0].replace(/^(DeliveryRule)/, '').replace(/(Parameters)$/, '')
                                }
                            ]
                        }
                    }
                }
            }
        }
      $.ProfileProperties.properties.frontDoorId['format'] = 'uuid';
      $.OriginUpdatePropertiesParameters.properties.privateLinkResourceId['x-ms-format'] = 'arm-id';
      $.DeepCreatedOriginProperties.properties.privateLinkResourceId['x-ms-format'] = 'arm-id';
      $.EndpointPropertiesUpdateParameters.properties.webApplicationFirewallPolicyLink.properties.id['x-ms-format'] = 'arm-id';
      $.ValidateCustomDomainInput['x-ms-client-name'] = 'ValidateCustomDomainContent';
      $.ValidateCustomDomainOutput['x-ms-client-name'] = 'ValidateCustomDomainResult';
      $.HealthProbeParameters['x-ms-client-name'] = 'HealthProbeSettings';
      $.DeliveryRuleSocketAddrCondition['x-ms-client-name'] = 'DeliveryRuleSocketAddressCondition';
      $.SocketAddrMatchConditionParameters['x-ms-client-name'] = 'SocketAddressMatchConditionDefinition';
      $.ValidateCustomDomainOutput.properties.customDomainValidated['x-ms-client-name'] = 'isCustomDomainValid';
      $.CustomDomainProperties.properties.customHttpsParameters['x-ms-client-name'] = 'customDomainHttpsContent';
      $.CustomDomainProperties.properties.customHttpsProvisioningSubstate['x-ms-client-name'] = 'customHttpsAvailabilityState';
      $.SsoUri.properties.ssoUriValue['x-ms-client-name'] = 'availableSsoUri';
      $.CustomDomainProperties.properties.customHttpsProvisioningSubstate['x-ms-enum'].name = 'CustomHttpsAvailabilityState';
      $.CacheExpirationActionParameters.properties.cacheBehavior['x-ms-enum'].name = 'cacheBehaviorSettings';
      $.CacheExpirationActionParameters.properties.cacheType['x-ms-enum'].name = 'cacheLevel';
      $.CdnCertificateSourceParameters.properties.certificateType['x-ms-enum'].name = 'CdnManagedCertificateType';
      $.ResourceType['x-ms-enum'].name = 'CdnResourceType';
      $.SocketAddrMatchConditionParameters.properties.operator['x-ms-enum'].name = 'SocketAddressOperator';
      $.SocketAddrMatchConditionParameters.properties.typeName['x-ms-enum'].name = 'SocketAddressMatchConditionType';
      $.SocketAddrMatchConditionParameters.properties.typeName['x-ms-enum'].values[0].name = 'SocketAddressCondition';
      $.transform['x-ms-enum'].name = 'preTransformCategory';
      $.KeyVaultCertificateSourceParameters.properties.updateRule['x-ms-enum'].name = 'certificateUpdateAction';
      $.KeyVaultCertificateSourceParameters.properties.deleteRule['x-ms-enum'].name = 'certificateDeleteAction';
      $.DeliveryRuleAction.properties.name['x-ms-enum'].name = 'DeliveryRuleActionType';
      $.EndpointPropertiesUpdateParameters.properties.defaultOriginGroup = {
            "description": "A reference to the origin group.",
            "type": "object",
            "properties": {
                "id": {
                    "type": "string",
                    "description": "Resource ID.",
                    "x-ms-format": "arm-id"
                }
            }
        }
      $.EndpointPropertiesUpdateParameters.properties.defaultOriginGroup['x-nullable'] = true;
      $.EndpointPropertiesUpdateParameters.properties.optimizationType['x-nullable'] = true;
      $.EndpointPropertiesUpdateParameters.properties.urlSigningKeys['x-nullable'] = true;
      $.EndpointPropertiesUpdateParameters.properties.deliveryPolicy['x-nullable'] = true;
      $.EndpointPropertiesUpdateParameters.properties.webApplicationFirewallPolicyLink['x-nullable'] = true;
      $.DeepCreatedOriginGroupProperties.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes['x-nullable'] = true;
      $.OriginGroupUpdatePropertiesParameters.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes['x-nullable'] = true;
      $.DeepCreatedOriginGroupProperties.properties.responseBasedOriginErrorDetectionSettings['x-nullable'] = true;
      $.OriginGroupUpdatePropertiesParameters.properties.responseBasedOriginErrorDetectionSettings['x-nullable'] = true;
      $.DeepCreatedOriginGroupProperties.properties.healthProbeSettings['x-nullable'] = true;
      $.OriginGroupUpdatePropertiesParameters.properties.healthProbeSettings['x-nullable'] = true;
      $.DeepCreatedOriginProperties.properties.httpPort['x-nullable'] = true;
      $.OriginUpdatePropertiesParameters.properties.httpPort['x-nullable'] = true;
      $.DeepCreatedOriginProperties.properties.httpsPort['x-nullable'] = true;
      $.OriginUpdatePropertiesParameters.properties.httpsPort['x-nullable'] = true;
      $.DeepCreatedOriginProperties.properties.priority['x-nullable'] = true;
      $.OriginUpdatePropertiesParameters.properties.priority['x-nullable'] = true;
      $.DeepCreatedOriginProperties.properties.weight['x-nullable'] = true;
      $.OriginUpdatePropertiesParameters.properties.weight['x-nullable'] = true;
      $.DeepCreatedOriginProperties.properties.privateEndpointStatus['x-nullable'] = true;
      $.OriginProperties.properties.privateEndpointStatus['x-nullable'] = true;
      $.ProfileProperties.properties.originResponseTimeoutSeconds['x-nullable'] = true;
      $.CustomDomainProperties.properties.customHttpsParameters['x-nullable'] = true;
      $.RouteConfigurationOverrideActionParameters.properties.originGroupOverride['x-nullable'] = true;
      $.CacheConfiguration.properties.cacheDuration['x-nullable'] = true;
      $.OriginUpdatePropertiesParameters.properties.privateLinkResourceId['x-nullable'] = true;
      $.DeepCreatedOriginProperties.properties.privateLinkResourceId['x-nullable'] = true;
  - from: cdn.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/endpoints/{endpointName}'].put.parameters[3]['x-ms-client-name'] = 'endpointInput';
      for (var key in $) {
          for (var method in $[key]) {
              const oldOperationId = $[key][method]['operationId']
              if (oldOperationId.startsWith('Endpoint') || oldOperationId.startsWith('Origin') || oldOperationId.startsWith('OriginGroup') || oldOperationId.startsWith('CustomDomain')) {
                  const newOperationId = 'Cdn' + oldOperationId
                  $[key][method]['operationId'] = newOperationId
              }
          }
      }
  - from: afdx.json
    where: $.definitions
    transform: >
      $.ActivatedResourceReference.properties.id['x-ms-format'] = 'arm-id';
      $.Usage.properties.id['x-ms-format'] = 'arm-id';
      $.AFDDomainUpdatePropertiesParameters.properties.azureDnsZone['x-ms-client-name'] = 'dnsZone';
      $.AFDOriginUpdatePropertiesParameters.properties.azureOrigin['x-ms-client-name'] = 'origin';
      $.LoadBalancingSettingsParameters['x-ms-client-name'] = 'LoadBalancingSettings';
      $.CompressionSettings['x-ms-client-name'] = 'RouteCacheCompressionSettings';
      $.UsageName['x-ms-client-name'] = 'CdnUsageResourceName';
      $.AFDOriginGroupUpdatePropertiesParameters.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes['x-ms-client-name'] = 'trafficRestorationTimeInMinutes';
      $.AutoGeneratedDomainNameLabelScope['x-ms-enum'].name = 'DomainNameLabelScope';
      $.AFDStateProperties.properties.deploymentStatus['x-ms-enum'].name = 'AfdDeploymentStatus';
      $.AFDEndpointProtocols['x-ms-enum'].name = 'AfdEndpointProtocols';
      $.AFDDomainHttpsParameters.properties.secret = {
            "description": "Resource reference to the secret. ie. subs/rg/profile/secret",
            "type": "object",
            "properties": {
                "id": {
                    "type": "string",
                    "description": "Resource ID.",
                    "x-ms-format": "arm-id"
                }
            }
        }
      $.AFDDomainUpdatePropertiesParameters.properties.preValidatedCustomDomainResourceId = {
            "x-ms-client-name": "preValidatedCustomDomainResource",
            "description": "Resource reference to the Azure resource where custom domain ownership was prevalidated",
            "type": "object",
            "properties": {
                "id": {
                    "type": "string",
                    "description": "Resource ID.",
                    "x-ms-format": "arm-id"
                }
            }
        }
      $.AFDDomainHttpsParameters.properties.secret['x-nullable'] = true;
      $.AFDOriginGroupUpdatePropertiesParameters.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes['x-nullable'] = true;
      $.WafMetricsResponse.properties.series.items.properties.groups['x-nullable'] = true;
      $.AFDOriginUpdatePropertiesParameters.properties.priority['x-nullable'] = true;
      $.AFDOriginUpdatePropertiesParameters.properties.weight['x-nullable'] = true;
      $.AFDOriginUpdatePropertiesParameters.properties.sharedPrivateLinkResource['x-nullable'] = true;
      $.AFDDomainUpdatePropertiesParameters.properties.preValidatedCustomDomainResourceId['x-nullable'] = true;
      $.RouteUpdatePropertiesParameters.properties.cacheConfiguration['x-nullable'] = true;
      $.AFDEndpointProperties.properties.autoGeneratedDomainNameLabelScope['x-nullable'] = true;
  - from: afdx.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/afdEndpoints/{endpointName}'].put.parameters[3]['x-ms-client-name'] = 'endpointInput';
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
          }
      }
  - from: cdnwebapplicationfirewall.json
    where: $.definitions
    transform: >
      $.CdnWebApplicationFirewallPolicy.properties.etag['x-ms-format'] = 'etag';
      $.CdnEndpoint['x-ms-client-name'] = 'CdnEndpointReference';
      $.CdnWebApplicationFirewallPolicyProperties.properties.rateLimitRules['x-ms-client-name'] = 'RateLimitSettings';
      $.CdnWebApplicationFirewallPolicyProperties.properties.customRules['x-ms-client-name'] = 'CustomSettings';
      $.policySettings.properties.defaultCustomBlockResponseStatusCode['x-nullable'] = true;
  - from: swagger-document
    where: $.definitions
    transform: >
        for (var key in $) {
            if (key === 'AFDDomainHttpsParameters')
            {
                const newKey = 'AfdCustomDomainHttpsContent'
                $[newKey] = $[key]
                delete $[key]
            }
        }
  - from: swagger-document
    where: $.definitions.AFDDomainUpdatePropertiesParameters.properties.tlsSettings
    transform: $['$ref'] = '#/definitions/AfdCustomDomainHttpsContent'
  - from: swagger-document
    where: $.definitions
    transform: >
      for (var key in $) {
          if (['Endpoint', 'Origin', 'OriginGroup', 'CustomDomain'].includes(key)) {
              const newKey = 'Cdn' + key;
              $[key]['x-ms-client-name'] = newKey
          }
          if (['Route', 'RuleSet', 'Rule', 'SecurityPolicy', 'Secret'].includes(key)) {
              const newKey = 'Afd' + key;
              $[key]['x-ms-client-name'] = newKey
          }
          if (['CdnManagedHttpsParameters', 'CdnWebApplicationFirewallPolicyPatchParameters', 'CustomDomainHttpsParameters', 'CustomDomainParameters', 'EndpointUpdateParameters', 'LoadParameters', 'OriginGroupUpdateParameters', 'OriginUpdateParameters', 'ProfileUpdateParameters', 'PurgeParameters', 'RouteUpdateParameters', 'RuleUpdateParameters', 'UserManagedHttpsParameters', 'SecurityPolicyUpdateParameters'].includes(key)) {
              const newKey = key.replace('Parameters', 'Content');
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
  - from: cdn.json
    where: $.definitions.CacheExpirationActionParameters.properties.cacheDuration
    transform: >
      $["format"] = "duration";
      $["x-ms-format"] = "duration-constant";
  - from: cdn.json
    where: $.definitions.CacheConfiguration.properties.cacheDuration
    transform: >
      $["format"] = "duration";
      $["x-ms-format"] = "duration-constant";
  - from: swagger-document
    where: $.definitions.ValidateSecretOutput.properties.status
    transform: >
      $['x-ms-enum'] = {
          "name": "validationStatus",
          "modelAsString": true
      }
  - remove-operation: Validate_Secret
```
