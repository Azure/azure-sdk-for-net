# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Cdn
namespace: Azure.ResourceManager.Cdn
title: CdnManagementClient
require: https://github.com/Azure/azure-rest-api-specs/blob/9b87e611b5016ed5c8d0eea2ee4578be782e7feb/specification/cdn/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - LogAnalytics_GetLogAnalyticsMetrics
  - LogAnalytics_GetWafLogAnalyticsMetrics
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

mgmt-debug:
  show-serialized-names: true

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
  Profiles_CdnCanMigrateToAfd: CheckCdnMigrationCompatibility
  Profiles_CdnMigrateToAfd: MigrateCdnToAfd
  Profiles_MigrationAbort: AbortMigration

rename-mapping:
  CacheType: CdnCacheLevel
  SslProtocol: DeliveryRuleSslProtocol
  Endpoint.properties.customDomains: DeepCreatedCustomDomains
  WafMetricsSeriesUnit: WafMetricsResponseSeriesItemUnit
  WafMetricsGranularity: WafMetricsResponseGranularity
  MetricsSeriesUnit: MetricsResponseSeriesItemUnit
  MetricsGranularity: MetricsResponseGranularity
  Profile.properties.frontDoorId: -|uuid
  DeepCreatedOrigin.properties.privateLinkResourceId: -|arm-id
  EndpointPropertiesUpdateParametersWebApplicationFirewallPolicyLink.id: -|arm-id
  Origin: CdnOrigin
  Origin.properties.privateLinkResourceId: -|arm-id
  OriginGroup: CdnOriginGroup
  CustomDomain: CdnCustomDomain
  ValidateCustomDomainInput: ValidateCustomDomainContent
  ValidateCustomDomainOutput: ValidateCustomDomainResult
  HealthProbeParameters: HealthProbeSettings
  DeliveryRuleSocketAddrCondition: DeliveryRuleSocketAddressCondition
  SocketAddrMatchConditionParameters: SocketAddressMatchCondition
  SocketAddrMatchConditionParameters.typeName: ConditionType
  SocketAddrMatchConditionParametersTypeName: SocketAddressMatchConditionType
  SocketAddrMatchConditionParametersTypeName.DeliveryRuleSocketAddrConditionParameters: SocketAddressCondition
  SocketAddrMatchConditionParameters.operator: SocketAddressOperator
  CdnManagedHttpsParameters: CdnManagedHttpsContent
  UserManagedHttpsParameters: UserManagedHttpsContent
  ResponseBasedOriginErrorDetectionParameters: ResponseBasedOriginErrorDetectionSettings
  HttpErrorRangeParameters: HttpErrorRange
  CheckNameAvailabilityInput: CdnNameAvailabilityContent
  CheckNameAvailabilityOutput: CdnNameAvailabilityResult
  ValidateProbeOutput: ValidateProbeResult
  ResourceUsage: CdnUsage
  ValidateCustomDomainOutput.customDomainValidated: isCustomDomainValid
  ResponseBasedOriginErrorDetectionParameters.responseBasedDetectedErrorTypes: responseBasedDetectedErrorType
  CustomDomain.properties.customHttpsParameters: customDomainHttpsContent
  CustomDomain.properties.customHttpsProvisioningSubstate: customHttpsAvailabilityState
  SsoUri.ssoUriValue: availableSsoUri
  CustomerCertificateProperties.expirationDate: -|date-time
  ManagedCertificateProperties.expirationDate: -|date-time
  DomainValidationProperties.expirationDate: expiresDate|date-time
  FrontDoorActivatedResourceInfo.id: -|arm-id
  Usage.id: -|arm-id
  AfdPurgeParameters: FrontDoorPurgeParameters
  AfdRouteCacheConfiguration: FrontDoorRouteCacheConfiguration
  Route: FrontDoorRoute
  RuleSet: FrontDoorRuleSet
  Rule: FrontDoorRule
  SecurityPolicy: FrontDoorSecurityPolicy
  Secret: FrontDoorSecret
  ValidateSecretOutput: ValidateSecretResult
  LoadBalancingSettingsParameters: LoadBalancingSettings
  CompressionSettings: RouteCacheCompressionSettings
  UsageName: FrontDoorUsageResourceName
  Usage: FrontDoorUsage
  AzureFirstPartyManagedCertificateParameters: AzureFirstPartyManagedCertificateProperties
  UrlSigningKeyParameters: UriSigningKeyProperties
  CheckHostNameAvailabilityInput: HostNameAvailabilityContent
  CheckEndpointNameAvailabilityInput: EndpointNameAvailabilityContent
  CheckEndpointNameAvailabilityOutput: EndpointNameAvailabilityResult
  SecurityPolicyWebApplicationFirewallParameters: SecurityPolicyWebApplicationFirewall
  AFDDomain.properties.azureDnsZone: dnsZone
  AFDDomainUpdateParameters.properties.azureDnsZone: DnsZone
  AFDOrigin.properties.azureOrigin: origin
  AFDOriginUpdateParameters.properties.azureOrigin: origin
  AFDOriginGroup.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes: trafficRestorationTimeInMinutes
  AFDOriginGroupUpdateParameters.properties.trafficRestorationTimeToHealedOrNewEndpointsInMinutes: trafficRestorationTimeInMinutes
  MatchCondition: CustomRuleMatchCondition
  ManagedRuleSet: WafPolicyManagedRuleSet
  ManagedRuleGroupOverride: ManagedRuleGroupOverrideSetting
  CdnWebApplicationFirewallPolicy.properties.rateLimitRules: RateLimitSettings
  ManagedRuleOverride: ManagedRuleOverrideSetting
  MatchCondition.operator: matchOperator
  CdnWebApplicationFirewallPolicy.properties.customRules: CustomSettings
  Endpoint: CdnEndpoint
  SocketAddrOperator: SocketAddressOperator
  CacheExpirationActionParameters: CacheExpirationActionProperties
  CacheExpirationActionParameters.cacheDuration: -|duration-constant
  CacheExpirationActionParametersTypeName: CacheExpirationActionType
  CacheExpirationActionParameters.typeName: ActionType
  CacheExpirationActionParametersTypeName.DeliveryRuleCacheExpirationActionParameters: CacheExpirationAction
  CacheKeyQueryStringActionParameters: CacheKeyQueryStringActionProperties
  CacheKeyQueryStringActionParameters.typeName: ActionType
  CacheKeyQueryStringActionParametersTypeName: CacheKeyQueryStringActionType
  CacheKeyQueryStringActionParametersTypeName.DeliveryRuleCacheKeyQueryStringBehaviorActionParameters: CacheKeyQueryStringBehaviorAction
  CacheConfiguration.cacheDuration: -|duration-constant
  ClientPortMatchConditionParametersTypeName.DeliveryRuleClientPortConditionParameters: ClientPortCondition
  ProtocolType: SecureDeliveryProtocolType
  ProbeProtocol: HealthProbeProtocol
  CustomHttpsProvisioningSubstate: CustomHttpsAvailabilityState
  CacheBehavior: CacheBehaviorSetting
  CertificateType: CdnManagedCertificateType
  MinimumTlsVersion: CdnMinimumTlsVersion
  ResourceType: CdnResourceType
  EndpointProvisioningState: CdnEndpointProvisioningState
  ResourceUsageUnit: CdnUsageUnit
  DeleteRule: CertificateDeleteAction
  UpdateRule: CertificateUpdateAction
  Transform: PreTransformCategory
  Algorithm: UriSigningAlgorithm
  IsDeviceMatchConditionParametersMatchValuesItem: IsDeviceMatchConditionMatchValue
  RequestMethodMatchConditionParametersMatchValuesItem: RequestMethodMatchConditionMatchValue
  RequestSchemeMatchConditionParametersMatchValuesItem: RequestSchemeMatchConditionMatchValue
  UrlRewriteActionParameters.typeName: ActionType
  UrlRewriteActionParametersTypeName: UriRewriteActionType
  UrlRewriteActionParametersTypeName.DeliveryRuleUrlRewriteActionParameters: UriRewriteAction
  UrlRewriteActionParameters: UriRewriteActionProperties
  UrlSigningActionParameters: UriSigningActionProperties
  UrlSigningActionParameters.typeName: ActionType
  UrlSigningActionParametersTypeName: UriSigningActionType
  UrlSigningActionParametersTypeName.DeliveryRuleUrlSigningActionParameters: UriSigningAction
  UrlRedirectActionParameters: UriRedirectActionProperties
  UrlRedirectActionParameters.typeName: ActionType
  UrlRedirectActionParametersTypeName: UriRedirectActionType
  UrlRedirectActionParametersTypeName.DeliveryRuleUrlRedirectActionParameters: UriRedirectAction
  UrlPathMatchConditionParameters: UriPathMatchCondition
  UrlPathMatchConditionParameters.typeName: ConditionType
  UrlPathMatchConditionParametersTypeName: UriPathMatchConditionType
  UrlPathMatchConditionParametersTypeName.DeliveryRuleUrlPathMatchConditionParameters: UriPathMatchCondition
  UrlPathMatchConditionParameters.operator: UriPathOperator
  UrlFileNameMatchConditionParameters: UriFileNameMatchCondition
  UrlFileNameMatchConditionParameters.typeName: ConditionType
  UrlFileNameMatchConditionParametersTypeName: UriFileNameMatchConditionType
  UrlFileNameMatchConditionParametersTypeName.DeliveryRuleUrlFilenameConditionParameters: UriFilenameCondition
  UrlFileNameMatchConditionParameters.operator: UriFileNameOperator
  UrlFileExtensionMatchConditionParameters: UriFileExtensionMatchCondition
  UrlFileExtensionMatchConditionParameters.typeName: ConditionType
  UrlFileExtensionMatchConditionParametersTypeName: UriFileExtensionMatchConditionType
  UrlFileExtensionMatchConditionParametersTypeName.DeliveryRuleUrlFileExtensionMatchConditionParameters: UriFileExtensionMatchCondition
  UrlFileExtensionMatchConditionParameters.operator: UriFileExtensionOperator
  SslProtocolMatchConditionParameters: DeliveryRuleSslProtocolMatchCondition
  SslProtocolMatchConditionParameters.typeName: SslProtocolMatchConditionType
  SslProtocolMatchConditionParametersTypeName: SslProtocolMatchConditionType
  SslProtocolMatchConditionParametersTypeName.DeliveryRuleSslProtocolConditionParameters: SslProtocolCondition
  SslProtocolMatchConditionParameters.operator: SslProtocolOperator
  ServerPortMatchConditionParameters: ServerPortMatchCondition
  ServerPortMatchConditionParameters.typeName: ConditionType
  ServerPortMatchConditionParametersTypeName: ServerPortMatchConditionType
  ServerPortMatchConditionParametersTypeName.DeliveryRuleServerPortConditionParameters: ServerPortCondition
  ServerPortMatchConditionParameters.operator: ServerPortOperator
  RouteConfigurationOverrideActionParameters: RouteConfigurationOverrideActionProperties
  RouteConfigurationOverrideActionParameters.typeName: ActionType
  RouteConfigurationOverrideActionParametersTypeName: RouteConfigurationOverrideActionType
  RouteConfigurationOverrideActionParametersTypeName.DeliveryRuleRouteConfigurationOverrideActionParameters: RouteConfigurationOverrideAction
  RequestUriMatchConditionParameters: RequestUriMatchCondition
  RequestUriMatchConditionParameters.typeName: ConditionType
  RequestUriMatchConditionParametersTypeName: RequestUriMatchConditionType
  RequestUriMatchConditionParametersTypeName.DeliveryRuleRequestUriConditionParameters: RequestUriCondition
  RequestUriMatchConditionParameters.operator: RequestUriOperator
  RequestSchemeMatchConditionParameters: RequestSchemeMatchCondition
  RequestSchemeMatchConditionParameters.typeName: ConditionType
  RequestSchemeMatchConditionParametersTypeName: RequestSchemeMatchConditionType
  RequestSchemeMatchConditionParametersTypeName.DeliveryRuleRequestSchemeConditionParameters: RequestSchemeCondition
  RequestSchemeMatchConditionParameters.operator: RequestSchemeOperator
  RequestMethodMatchConditionParameters: RequestMethodMatchCondition
  RequestMethodMatchConditionParameters.typeName: ConditionType
  RequestMethodMatchConditionParametersTypeName: RequestMethodMatchConditionType
  RequestMethodMatchConditionParametersTypeName.DeliveryRuleRequestMethodConditionParameters: RequestMethodCondition
  RequestMethodMatchConditionParameters.operator: RequestMethodOperator
  RequestHeaderMatchConditionParameters: RequestHeaderMatchCondition
  RequestHeaderMatchConditionParameters.typeName: ConditionType
  RequestHeaderMatchConditionParametersTypeName: RequestHeaderMatchConditionType
  RequestHeaderMatchConditionParametersTypeName.DeliveryRuleRequestHeaderConditionParameters: RequestHeaderCondition
  RequestHeaderMatchConditionParameters.operator: RequestHeaderOperator
  RequestBodyMatchConditionParameters: RequestBodyMatchCondition
  RequestBodyMatchConditionParameters.typeName: ConditionType
  RequestBodyMatchConditionParametersTypeName: RequestBodyMatchConditionType
  RequestBodyMatchConditionParametersTypeName.DeliveryRuleRequestBodyConditionParameters: RequestBodyCondition
  RequestBodyMatchConditionParameters.operator: RequestBodyOperator
  RemoteAddressMatchConditionParameters: RemoteAddressMatchCondition
  RemoteAddressMatchConditionParameters.typeName: ConditionType
  RemoteAddressMatchConditionParametersTypeName: RemoteAddressMatchConditionType
  RemoteAddressMatchConditionParametersTypeName.DeliveryRuleRemoteAddressConditionParameters: RemoteAddressCondition
  RemoteAddressMatchConditionParameters.operator: RemoteAddressOperator
  QueryStringMatchConditionParameters: QueryStringMatchCondition
  QueryStringMatchConditionParameters.typeName: ConditionType
  QueryStringMatchConditionParametersTypeName: QueryStringMatchConditionType
  QueryStringMatchConditionParametersTypeName.DeliveryRuleQueryStringConditionParameters: QueryStringCondition
  QueryStringMatchConditionParameters.operator: QueryStringOperator
  PostArgsMatchConditionParameters: PostArgsMatchCondition
  PostArgsMatchConditionParameters.typeName: ConditionType
  PostArgsMatchConditionParametersTypeName: PostArgsMatchConditionType
  PostArgsMatchConditionParametersTypeName.DeliveryRulePostArgsConditionParameters: PostArgsCondition
  PostArgsMatchConditionParameters.operator: PostArgsOperator
  OriginGroupOverrideActionParameters: OriginGroupOverrideActionProperties
  OriginGroupOverrideActionParameters.typeName: ActionType
  OriginGroupOverrideActionParametersTypeName: OriginGroupOverrideActionType
  OriginGroupOverrideActionParametersTypeName.DeliveryRuleOriginGroupOverrideActionParameters: OriginGroupOverrideAction
  KeyVaultCertificateSourceParameters: KeyVaultCertificateSource
  KeyVaultSigningKeyParameters: KeyVaultSigningKey
  KeyVaultCertificateSourceParameters.typeName: SourceType
  KeyVaultCertificateSourceParametersTypeName: KeyVaultCertificateSourceType
  KeyVaultCertificateSourceParametersTypeName.KeyVaultCertificateSourceParameters: KeyVaultCertificateSource
  KeyVaultSigningKeyParameters.typeName: KeyType
  KeyVaultSigningKeyParametersTypeName: KeyVaultSigningKeyType
  KeyVaultSigningKeyParametersTypeName.KeyVaultSigningKeyParameters: KeyVaultSigningKey
  IsDeviceMatchConditionParameters: IsDeviceMatchCondition
  IsDeviceMatchConditionParameters.typeName: ConditionType
  IsDeviceMatchConditionParametersTypeName: IsDeviceMatchConditionType
  IsDeviceMatchConditionParametersTypeName.DeliveryRuleIsDeviceConditionParameters: IsDeviceCondition
  IsDeviceMatchConditionParameters.operator: IsDeviceOperator
  HttpVersionMatchConditionParameters: HttpVersionMatchCondition
  HttpVersionMatchConditionParameters.typeName: ConditionType
  HttpVersionMatchConditionParametersTypeName: HttpVersionMatchConditionType
  HttpVersionMatchConditionParametersTypeName.DeliveryRuleHttpVersionConditionParameters: HttpVersionCondition
  HttpVersionMatchConditionParameters.operator: HttpVersionOperator
  HostNameMatchConditionParameters: HostNameMatchCondition
  HostNameMatchConditionParameters.typeName: ConditionType
  HostNameMatchConditionParametersTypeName: HostNameMatchConditionType
  HostNameMatchConditionParametersTypeName.DeliveryRuleHostNameConditionParameters: HostNameCondition
  HostNameMatchConditionParameters.operator: HostNameOperator
  HeaderActionParameters: HeaderActionProperties
  HeaderActionParameters.typeName: ActionType
  HeaderActionParametersTypeName: HeaderActionType
  HeaderActionParametersTypeName.DeliveryRuleHeaderActionParameters: HeaderAction
  CookiesMatchConditionParameters: CookiesMatchCondition
  CookiesMatchConditionParameters.typeName: ConditionType
  CookiesMatchConditionParametersTypeName: CookiesMatchConditionType
  CookiesMatchConditionParametersTypeName.DeliveryRuleCookiesConditionParameters: CookiesCondition
  CookiesMatchConditionParameters.operator: CookiesOperator
  ClientPortMatchConditionParameters: ClientPortMatchCondition
  ClientPortMatchConditionParameters.typeName: ConditionType
  ClientPortMatchConditionParametersTypeName: ClientPortMatchConditionType
  ClientPortMatchConditionParameters.operator: ClientPortOperator
  CdnCertificateSourceParameters: CdnCertificateSource
  CdnCertificateSourceParameters.typeName: SourceType
  CdnCertificateSourceParametersTypeName: CdnCertificateSourceType
  CdnCertificateSourceParametersTypeName.CdnCertificateSourceParameters: CdnCertificateSource
  PolicySettings: WafPolicySettings
  ProvisioningState: WebApplicationFirewallPolicyProvisioningState
  ActionType: OverrideActionType
  ManagedRuleEnabledState: ManagedRuleSetupState
  Operator: MatchOperator
  ActivatedResourceReference: FrontDoorActivatedResourceInfo
  ActivatedResourceReference.id: -|arm-id
  CustomerCertificateParameters: CustomerCertificateProperties
  SecretParameters: FrontDoorSecretProperties
  AutoGeneratedDomainNameLabelScope: DomainNameLabelScope
  ManagedCertificateParameters: ManagedCertificateProperties
  SecretProperties: SecretDetails
  SecurityPolicyProperties: SecurityPolicyDetails
  SecurityPolicyPropertiesParameters: SecurityPolicyProperties
  AfdCertificateType: FrontDoorCertificateType
  AfdMinimumTlsVersion: FrontDoorMinimumTlsVersion
  AfdQueryStringCachingBehavior: FrontDoorQueryStringCachingBehavior
  CustomerCertificateParameters.expirationDate: ExpiresOn|date-time
  ManagedCertificateParameters.expirationDate: ExpiresOn|date-time
  DeploymentStatus: FrontDoorDeploymentStatus
  AfdProvisioningState: FrontDoorProvisioningState
  AFDDomain.properties.preValidatedCustomDomainResourceId: PreValidatedCustomDomainResource
  AFDDomainUpdateParameters.properties.preValidatedCustomDomainResourceId: PreValidatedCustomDomainResource
  UsageUnit: FrontDoorUsageUnit
  Status: ValidationStatus
  DeliveryRuleActionParameters: DeliveryRuleActionProperties
  DeliveryRuleConditionParameters: DeliveryRuleConditionProperties
  CertificateSourceParameters: CertificateSourceProperties
  CanMigrateResult.id: ResourceId
  MigrateResult.id: ResourceId
  IsDeviceMatchValue: IsDeviceMatchConditionMatchValue
  KeyVaultSigningKeyParametersType: KeyVaultSigningKeyType
  RequestMethodMatchValue: RequestMethodMatchConditionMatchValue
  RequestSchemeMatchValue: RequestSchemeMatchConditionMatchValue
  KeyVaultSigningKeyParametersType.KeyVaultSigningKeyParameters: KeyVaultSigningKey

directive:
  - from: swagger-document
    where: $.definitions..parameters
    transform: >
      $['x-ms-client-name'] = 'properties';
  - from: cdn.json
    where: $.definitions
    transform: >
      $.RequestSchemeMatchConditionParameters.properties.operator['x-ms-enum'] = {
            "name": "RequestSchemeOperator",
            "modelAsString": true
        };
      $.DeliveryRuleAction.properties.name['x-ms-enum'].name = 'DeliveryRuleActionType';
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
      $.policySettings.properties.defaultCustomBlockResponseStatusCode['x-nullable'] = true;
      $.policySettings.properties.defaultCustomBlockResponseBody['x-nullable'] = true;
  - remove-operation: Validate_Secret
```
