# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Cdn
namespace: Azure.ResourceManager.Cdn
title: CdnManagementClient
require: https://github.com/Azure/azure-rest-api-specs/blob/236c7ce93e9bcb875e1fbe1db8602a3a159ee2ae/specification/cdn/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  skipped-operations:
  - LogAnalytics_GetLogAnalyticsMetrics
  - LogAnalytics_GetWafLogAnalyticsMetrics
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

operation-id-mappings:
  CdnEndpoint:
      profileName: Microsoft.Cdn/operationresults/profileresults
      endpointName: Microsoft.Cdn/operationresults/profileresults/endpointresults
  CdnCustomDomain:
      profileName: Microsoft.Cdn/operationresults/profileresults
      endpointName: Microsoft.Cdn/operationresults/profileresults/endpointresults
      customDomainName: Microsoft.Cdn/operationresults/profileresults/endpointresults/customdomainresults

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'defaultCustomBlockResponseBody': 'any'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

acronym-mapping:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs|ips
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4|ipv4
  Ipv6: IPv6|ipv6
  Ipsec: IPsec|ipsec
  SSO: Sso
  URI: Uri
  Etag: ETag|etag
  Url: Uri
  URL: Uri
  AFDDomainHttpsParameters: FrontDoorCustomDomainHttpsContent
  AFDDomain: FrontDoorCustomDomain
  AFD: FrontDoor
  GET: Get
  PUT: Put
  SHA256: Sha256
  EndpointPropertiesUpdateParametersDeliveryPolicy: EndpointDeliveryPolicy

no-property-type-replacement:
  - ContinentsResponseContinentsItem
  - EndpointPropertiesUpdateParametersDefaultOriginGroup
  - EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink
  - FrontDoorCustomDomainHttpsContentSecret
  - FrontDoorCustomDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId
override-operation-name:
  CheckNameAvailability: CheckCdnNameAvailability
  CheckNameAvailabilityWithSubscription: CheckCdnNameAvailabilityWithSubscription
  FrontDoorProfiles_CheckHostNameAvailability: CheckFrontDoorProfileHostNameAvailability
  LogAnalytics_GetLogAnalyticsMetrics: GetLogAnalyticsMetrics
  LogAnalytics_GetLogAnalyticsRankings: GetLogAnalyticsRankings
  LogAnalytics_GetLogAnalyticsResources: GetLogAnalyticsResources
  LogAnalytics_GetLogAnalyticsLocations: GetLogAnalyticsLocations
  LogAnalytics_GetWafLogAnalyticsMetrics: GetWafLogAnalyticsMetrics
  LogAnalytics_GetWafLogAnalyticsRankings: GetWafLogAnalyticsRankings
  Profiles_ListResourceUsage: GetResourceUsages
  CdnEndpoints_ListResourceUsage: GetResourceUsages
  FrontDoorProfiles_ListResourceUsage: GetFrontDoorProfileResourceUsages
  FrontDoorEndpoints_ListResourceUsage: GetResourceUsages
  FrontDoorOriginGroups_ListResourceUsage: GetResourceUsages
  FrontDoorRuleSets_ListResourceUsage: GetResourceUsages

rename-mapping:
  SecretProperties: FrontDoorSecretProperties
  CacheLevel: CdnCacheLevel
  SslProtocol: DeliveryRuleSslProtocol
  SslProtocolMatchCondition: DeliveryRuleSslProtocolMatchCondition

directive:
  - from: swagger-document
    where: $.definitions..parameters
    transform: >
      $['x-ms-client-name'] = 'properties';
  - from: cdn.json
    where: $.definitions
    transform: >
      $.SocketAddrMatchConditionParameters.properties.operator['x-ms-enum'].name = 'SocketAddressOperator';
      $.RequestSchemeMatchConditionParameters.properties.operator['x-ms-enum'] = {
          "name": "RequestSchemeOperator"
        }
      for (var key in $) {
            if (key.endsWith('Parameters')) {
                for (var property in $[key].properties) {
                    if (property === 'typeName' && $[key].properties[property].enum.length === 1) {
                        const newKey = key.replace('Parameters', '');
                        $[key]['x-ms-client-name'] = newKey;
                        if(key.endsWith('ActionParameters')) {
                             $[key]['x-ms-client-name'] = newKey + 'Properties';
                        }
                        if(key.endsWith('ConditionParameters')) {
                            $[key].properties.operator['x-ms-client-name'] = $[key].properties.operator['x-ms-enum'].name;
                        }
                        $[key].properties.typeName['x-ms-client-name'] = 'type';
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
      $.CacheExpirationActionParameters.properties.cacheDuration['x-ms-format'] = 'duration-constant';
      $.CacheConfiguration.properties.cacheDuration['x-ms-format'] = 'duration-constant';
      $.OriginUpdatePropertiesParameters.properties.privateLinkResourceId['x-ms-format'] = 'arm-id';
      $.DeepCreatedOriginProperties.properties.privateLinkResourceId['x-ms-format'] = 'arm-id';
      $.EndpointPropertiesUpdateParameters.properties.webApplicationFirewallPolicyLink.properties.id['x-ms-format'] = 'arm-id';
      $.Endpoint['x-ms-client-name'] = 'CdnEndpoint';
      $.Origin['x-ms-client-name'] = 'CdnOrigin';
      $.OriginGroup['x-ms-client-name'] = 'CdnOriginGroup';
      $.CustomDomain['x-ms-client-name'] = 'CdnCustomDomain';
      $.ValidateCustomDomainInput['x-ms-client-name'] = 'ValidateCustomDomainContent';
      $.ValidateCustomDomainOutput['x-ms-client-name'] = 'ValidateCustomDomainResult';
      $.HealthProbeParameters['x-ms-client-name'] = 'HealthProbeSettings';
      $.DeliveryRuleSocketAddrCondition['x-ms-client-name'] = 'DeliveryRuleSocketAddressCondition';
      $.SocketAddrMatchConditionParameters['x-ms-client-name'] = 'SocketAddressMatchCondition';
      $.CdnManagedHttpsParameters['x-ms-client-name'] = 'CdnManagedHttpsContent';
      $.UserManagedHttpsParameters['x-ms-client-name'] = 'UserManagedHttpsContent';
      $.ResponseBasedOriginErrorDetectionParameters['x-ms-client-name'] = 'ResponseBasedOriginErrorDetectionSettings';
      $.HttpErrorRangeParameters['x-ms-client-name'] = 'HttpErrorRange';
      $.CheckNameAvailabilityInput['x-ms-client-name'] = 'CdnNameAvailabilityContent';
      $.CheckNameAvailabilityOutput['x-ms-client-name'] = 'CdnNameAvailabilityResult';
      $.ValidateProbeOutput['x-ms-client-name'] = 'ValidateProbeResult';
      $.ResourceUsage['x-ms-client-name'] = 'CdnUsage';
      $.HealthProbeParameters.properties.probeProtocol['x-ms-enum'].name = 'HealthProbeProtocol';
      $.CustomDomainHttpsParameters.properties.protocolType['x-ms-enum'].name = 'SecureDeliveryProtocolType';
      $.ResponseBasedOriginErrorDetectionParameters.properties.responseBasedDetectedErrorTypes['x-ms-client-name'] = 'responseBasedDetectedErrorType';
      $.ValidateCustomDomainOutput.properties.customDomainValidated['x-ms-client-name'] = 'isCustomDomainValid';
      $.CustomDomainProperties.properties.customHttpsParameters['x-ms-client-name'] = 'customDomainHttpsContent';
      $.CustomDomainProperties.properties.customHttpsProvisioningSubstate['x-ms-client-name'] = 'customHttpsAvailabilityState';
      $.SsoUri.properties.ssoUriValue['x-ms-client-name'] = 'availableSsoUri';
      $.CustomDomainProperties.properties.customHttpsProvisioningSubstate['x-ms-enum'].name = 'CustomHttpsAvailabilityState';
      $.CacheExpirationActionParameters.properties.cacheBehavior['x-ms-enum'].name = 'cacheBehaviorSetting';
      $.CacheExpirationActionParameters.properties.cacheType['x-ms-enum'].name = 'cacheLevel';
      $.CdnCertificateSourceParameters.properties.certificateType['x-ms-enum'].name = 'CdnManagedCertificateType';
      $.ResourceType['x-ms-enum'].name = 'CdnResourceType';
      $.CustomDomainHttpsParameters.properties.minimumTlsVersion['x-ms-enum'].name = 'CdnMinimumTlsVersion';
      $.ResourceType['x-ms-enum'].values = [
                                {
                                    "value": "Microsoft.Cdn/Profiles/Endpoints",
                                    "name": "Endpoints"
                                },
                                {
                                    "value": "Microsoft.Cdn/Profiles/AfdEndpoints",
                                    "name": "FrontDoorEndpoints"
                                }
                            ]
      $.SocketAddrMatchConditionParameters.properties.typeName['x-ms-enum'].name = 'SocketAddressMatchConditionType';
      $.SocketAddrMatchConditionParameters.properties.typeName['x-ms-enum'].values[0].name = 'SocketAddressCondition';
      $.transform['x-ms-enum'].name = 'preTransformCategory';
      $.KeyVaultCertificateSourceParameters.properties.updateRule['x-ms-enum'].name = 'certificateUpdateAction';
      $.KeyVaultCertificateSourceParameters.properties.deleteRule['x-ms-enum'].name = 'certificateDeleteAction';
      $.DeliveryRuleAction.properties.name['x-ms-enum'].name = 'DeliveryRuleActionType';
      $.UrlSigningActionParameters.properties.algorithm['x-ms-enum'].name = 'urlSigningAlgorithm';
      $.ResourceUsage.properties.unit['x-ms-enum'].name = 'CdnUsageUnit';
      $.EndpointProperties.properties.provisioningState['x-ms-enum'].name = 'CdnEndpointProvisioningState';
      $.IsDeviceMatchConditionParameters.properties.matchValues.items['x-ms-enum'] = {
            "name": "IsDeviceMatchConditionMatchValue",
            "modelAsString": true
        }
      $.RequestMethodMatchConditionParameters.properties.matchValues.items['x-ms-enum'] = {
            "name": "RequestMethodMatchConditionMatchValue",
            "modelAsString": true
        }
      $.RequestSchemeMatchConditionParameters.properties.operator['x-ms-enum'] = {
            "name": "RequestSchemeOperator",
            "modelAsString": true
        }
      $.RequestSchemeMatchConditionParameters.properties.matchValues.items['x-ms-enum'] = {
            "name": "RequestSchemeMatchConditionMatchValue",
            "modelAsString": true
        }
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
      $.CustomerCertificateParameters.properties.expirationDate['format'] = 'date-time';
      $.ManagedCertificateParameters.properties.expirationDate['format'] = 'date-time';
      $.DomainValidationProperties.properties.expirationDate['format'] = 'date-time';
      $.ActivatedResourceReference.properties.id['x-ms-format'] = 'arm-id';
      $.Usage.properties.id['x-ms-format'] = 'arm-id';
      $.AfdPurgeParameters['x-ms-client-name'] = 'FrontDoorPurgeParameters';
      $.AfdRouteCacheConfiguration['x-ms-client-name'] = 'FrontDoorRouteCacheConfiguration';
      $.Route['x-ms-client-name'] = 'FrontDoorRoute';
      $.RuleSet['x-ms-client-name'] = 'FrontDoorRuleSet';
      $.Rule['x-ms-client-name'] = 'FrontDoorRule';
      $.SecurityPolicy['x-ms-client-name'] = 'FrontDoorSecurityPolicy';
      $.Secret['x-ms-client-name'] = 'FrontDoorSecret';
      $.ValidateSecretOutput['x-ms-client-name'] = 'ValidateSecretResult';
      $.LoadBalancingSettingsParameters['x-ms-client-name'] = 'LoadBalancingSettings';
      $.CompressionSettings['x-ms-client-name'] = 'RouteCacheCompressionSettings';
      $.UsageName['x-ms-client-name'] = 'FrontDoorUsageResourceName';
      $.Usage['x-ms-client-name'] = 'FrontDoorUsage';
      $.SecretProperties['x-ms-client-name'] = 'SecretDetails';
      $.SecurityPolicyProperties['x-ms-client-name'] = 'SecurityPolicyDetails';
      $.SecretParameters['x-ms-client-name'] = 'SecretProperties';
      $.SecurityPolicyPropertiesParameters['x-ms-client-name'] = 'SecurityPolicyProperties';
      $.AzureFirstPartyManagedCertificateParameters['x-ms-client-name'] = 'AzureFirstPartyManagedCertificateProperties';
      $.CustomerCertificateParameters['x-ms-client-name'] = 'CustomerCertificateProperties';
      $.ManagedCertificateParameters['x-ms-client-name'] = 'ManagedCertificateProperties';
      $.UrlSigningKeyParameters['x-ms-client-name'] = 'UriSigningKeyProperties';
      $.CheckHostNameAvailabilityInput['x-ms-client-name'] = 'HostNameAvailabilityContent';
      $.CheckEndpointNameAvailabilityInput['x-ms-client-name'] = 'EndpointNameAvailabilityContent';
      $.CheckEndpointNameAvailabilityOutput['x-ms-client-name'] = 'EndpointNameAvailabilityResult';
      $.SecurityPolicyWebApplicationFirewallParameters['x-ms-client-name'] = 'SecurityPolicyWebApplicationFirewall';
      $.ActivatedResourceReference['x-ms-client-name'] = 'FrontDoorActivatedResourceInfo';
      $.CustomerCertificateParameters.properties.expirationDate['x-ms-client-name'] = 'expiresDate';
      $.ManagedCertificateParameters.properties.expirationDate['x-ms-client-name'] = 'expiresDate';
      $.DomainValidationProperties.properties.expirationDate['x-ms-client-name'] = 'expiresDate';
      $.AFDDomainUpdatePropertiesParameters.properties.azureDnsZone['x-ms-client-name'] = 'dnsZone';
      $.AFDOriginUpdatePropertiesParameters.properties.azureOrigin['x-ms-client-name'] = 'origin';
      $.AFDOriginGroupUpdatePropertiesParameters.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes['x-ms-client-name'] = 'trafficRestorationTimeInMinutes';
      $.AutoGeneratedDomainNameLabelScope['x-ms-enum'].name = 'DomainNameLabelScope';
      $.AFDStateProperties.properties.deploymentStatus['x-ms-enum'].name = 'FrontDoorDeploymentStatus';
      $.AFDStateProperties.properties.provisioningState['x-ms-enum'].name = 'FrontDoorProvisioningState';
      $.AFDEndpointProtocols['x-ms-enum'].name = 'FrontDoorEndpointProtocol';
      $.ValidateSecretOutput.properties.status['x-ms-enum'].name = 'validationStatus';
      $.AFDDomainHttpsParameters.properties.certificateType['x-ms-enum'].name = 'FrontDoorCertificateType';
      $.AFDDomainHttpsParameters.properties.minimumTlsVersion['x-ms-enum'].name = 'FrontDoorMinimumTlsVersion';
      $.AfdRouteCacheConfiguration.properties.queryStringCachingBehavior['x-ms-enum'].name = 'FrontDoorQueryStringCachingBehavior';
      $.Usage.properties.unit['x-ms-enum'].name = 'FrontDoorUsageUnit';
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
                  const newOperationId = oldOperationId.replace('AFD', 'FrontDoor')
                  $[key][method]['operationId'] = newOperationId
              }
              if (oldOperationId.startsWith('Routes') || oldOperationId.startsWith('RuleSets') || oldOperationId.startsWith('Rules') || oldOperationId.startsWith('SecurityPolicies') || oldOperationId.startsWith('Secrets')) {
                  const newOperationId = 'FrontDoor' + oldOperationId
                  $[key][method]['operationId'] = newOperationId
              }
          }
      }
  - from: cdnwebapplicationfirewall.json
    where: $.definitions
    transform: >
      $.CdnEndpoint['x-ms-client-name'] = 'CdnEndpointReference';
      $.policySettings['x-ms-client-name'] = 'WafPolicySettings';
      $.MatchCondition['x-ms-client-name'] = 'CustomRuleMatchCondition';
      $.ActionType['x-ms-enum'].name = 'OverrideActionType';
      $.ManagedRuleSet['x-ms-client-name'] = 'WafPolicyManagedRuleSet';
      $.ManagedRuleGroupOverride['x-ms-client-name'] = 'ManagedRuleGroupOverrideSetting';
      $.ManagedRuleOverride['x-ms-client-name'] = 'ManagedRuleOverrideSetting';
      $.ManagedRuleOverride.properties.enabledState['x-ms-enum'].name = 'ManagedRuleSetupState';
      $.CdnWebApplicationFirewallPolicyProperties.properties.rateLimitRules['x-ms-client-name'] = 'RateLimitSettings';
      $.CdnWebApplicationFirewallPolicyProperties.properties.customRules['x-ms-client-name'] = 'CustomSettings';
      $.CdnWebApplicationFirewallPolicyProperties.properties.provisioningState['x-ms-enum'].name = 'WebApplicationFirewallPolicyProvisioningState';
      $.MatchCondition.properties.operator['x-ms-client-name'] = 'matchOperator';
      $.MatchCondition.properties.operator['x-ms-enum'].name = 'matchOperator';
      $.policySettings.properties.defaultCustomBlockResponseStatusCode['x-nullable'] = true;
      $.policySettings.properties.defaultCustomBlockResponseBody['x-nullable'] = true;
  - remove-operation: Validate_Secret
```
