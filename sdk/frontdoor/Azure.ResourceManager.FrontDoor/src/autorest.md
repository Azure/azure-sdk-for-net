# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: FrontDoor
namespace: Azure.ResourceManager.FrontDoor
require: https://github.com/Azure/azure-rest-api-specs/blob/f11631f1c1057d8363f9e3f9597c73b90f8924c8/specification/frontdoor/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
deserialize-null-collection-as-null-value: true

override-operation-name:
  Endpoints_PurgeContent: PurgeContent
  FrontDoorNameAvailabilityWithSubscription_Check: CheckFrontDoorNameAvailability

rename-mapping:
  Experiment: FrontDoorExperiment
  State: FrontDoorExperimentState
  Endpoint: FrontDoorExperimentEndpointProperties
  Experiment.properties.endpointA: ExperimentEndpointA
  Experiment.properties.endpointB: ExperimentEndpointB
  Timeseries: FrontDoorTimeseriesInfo
  Timeseries.properties.endpoint: -|Uri
  Timeseries.properties.startDateTimeUTC: StartOn
  Timeseries.properties.endDateTimeUTC: EndOn
  WebApplicationFirewallPolicy.properties.customRules: CustomRuleList
  HealthProbeSettingsModel: FrontDoorHealthProbeSettingsData
  LoadBalancingSettingsModel: FrontDoorLoadBalancingSettingsData
  RoutingRule: RoutingRuleData
  PurgeParameters: FrontDoorEndpointPurgeContent
  ValidateCustomDomainInput: FrontDoorValidateCustomDomainContent
  ValidateCustomDomainOutput: FrontDoorValidateCustomDomainResult
  ValidateCustomDomainOutput.customDomainValidated: IsCustomDomainValidated
  CustomHttpsProvisioningState: FrontendEndpointCustomHttpsProvisioningState
  CustomHttpsProvisioningSubstate: FrontendEndpointCustomHttpsProvisioningSubstate
  Profile: FrontDoorNetworkExperimentProfile
  ProfileUpdateModel: FrontDoorNetworkExperimentProfilePatch
  RulesEngine: FrontDoorRulesEngine
  WebApplicationFirewallPolicy: FrontDoorWebApplicationFirewallPolicy
  PolicySettings: FrontDoorWebApplicationFirewallPolicySettings
  PolicyResourceState: FrontDoorWebApplicationFirewallPolicyResourceState
  CustomRule: WebApplicationCustomRule
  CheckNameAvailabilityInput: FrontDoorNameAvailabilityContent
  CheckNameAvailabilityOutput: FrontDoorNameAvailabilityResult
  ActionType: RuleMatchActionType
  Availability: FrontDoorNameAvailabilityState
  Backend: FrontDoorBackend
  Backend.privateLinkResourceId: -|arm-id
  Backend.privateLinkLocation: -|azure-location
  PrivateEndpointStatus: BackendPrivateEndpointStatus
  BackendPool: FrontDoorBackendPool
  BackendPoolsSettings.sendRecvTimeoutSeconds: SendRecvTimeoutInSeconds
  FrontDoorCertificateType: FrontDoorEndpointConnectionCertificateType
  CustomHttpsProvisioningSubstate.PendingDomainControlValidationREquestApproval: PendingDomainControlValidationRequestApproval
  MatchCondition: WebApplicationRuleMatchCondition
  MatchCondition.negateCondition: IsNegateCondition
  MatchVariable: WebApplicationRuleMatchVariable
  Operator: WebApplicationRuleMatchOperator
  Operator.RegEx: RegEX
  TransformType: WebApplicationRuleMatchTransformType
  TransformType.UrlDecode: UriDecode
  TransformType.UrlEncode: UriEncode
  RuleType: WebApplicationRuleType
  FrontDoorHealthProbeMethod.GET: Get
  HeaderAction: RulesEngineHeaderAction
  HeaderActionType: RulesEngineHeaderActionType
  LatencyScorecard.properties.id: LatencyScorecardId
  LatencyScorecard.properties.name: LatencyScorecardName
  LatencyScorecard.properties.endpointA: ScorecardEndpointA-| Uri
  LatencyScorecard.properties.endpointB: ScorecardEndpointB-| Uri
  LatencyScorecard.properties.startDateTimeUTC: StartOn
  LatencyScorecard.properties.endDateTimeUTC: EndOn
  PolicyMode: FrontDoorWebApplicationFirewallPolicyMode
  RulesEngineMatchCondition.negateCondition: IsNegateCondition
  Transform: RulesEngineMatchTransform
  Transform.UrlDecode: UriDecode
  Transform.UrlEncode: UriEncode
  ResourceType: FrontDoorResourceType
  MinimumTLSVersion: FrontDoorRequiredMinimumTlsVersion
  LatencyMetric.endDateTimeUTC: EndOn
  AggregationInterval: FrontDoorTimeSeriesInfoAggregationInterval
  TimeseriesAggregationInterval: FrontDoorTimeSeriesAggregationInterval
  CacheConfiguration: FrontDoorCacheConfiguration
  EndpointType: FrontDoorEndpointType
  EndpointType.AFD: AzureFrontDoor
  EndpointType.ATM: AzureTrafficManager
  TimeseriesDataPoint: FrontDoorTimeSeriesDataPoint
  TimeseriesInfo: FrontDoorTimeSeriesInfo
  TimeseriesType: FrontDoorTimeSeriesType
  VariableName: FrontDoorWebApplicationFirewallPolicyGroupByVariableName
  GroupByVariable: FrontDoorWebApplicationFirewallPolicyGroupByVariable

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
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
  Vmos: VmOS
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
  UTC: Utc
  TLS: Tls
  AFD: Afd
  ATM: Atm
  CDN: Cdn
  Timeseries: TimeSeries

directive:
  - from: networkexperiment.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/LatencyScorecard'].get.parameters[5].format = 'date-time';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/LatencyScorecard'].get.parameters[5]['x-ms-client-name'] = 'endOn';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries'].get.parameters[5]['x-ms-client-name'] = 'startOn';
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/NetworkExperimentProfiles/{profileName}/Experiments/{experimentName}/Timeseries'].get.parameters[6]['x-ms-client-name'] = 'endOn';
  - from: networkexperiment.json
    where: $.definitions
    transform: >
      $.TimeseriesProperties.properties.startDateTimeUTC['format'] = 'date-time';
      $.TimeseriesProperties.properties.endDateTimeUTC['format'] = 'date-time';
      $.TimeseriesDataPoint.properties.dateTimeUTC['format'] = 'date-time';
      $.LatencyMetric.properties.endDateTimeUTC['format'] = 'date-time';
  - from: network.json
    where: $.definitions
    transform: >
      $.Resource['x-ms-client-name'] = 'FrontDoorResourceModel';
      $.FrontDoorResource = {
        'properties': {
            'id': {
              'type': 'string',
              'description': 'Resource ID.',
              'x-ms-format': 'arm-id'
            },
            'name': {
              'type': 'string',
              'description': 'Resource name.'
            },
            'type': {
              'readOnly': true,
              'type': 'string',
              'description': 'Resource type.',
              'x-ms-format': 'resource-type'
            }
          },
        'description': 'Common resource representation.',
        'x-ms-azure-resource': true,
        'x-ms-client-name': 'FrontDoorResourceData'
      };
  - from: frontdoor.json
    where: $.definitions[?(@.allOf && @.properties.name && !@.properties.name.readOnly && @.properties.type && @.properties.type.readOnly)]
    transform: >
      if ($.allOf[0]['$ref'].includes('network.json#/definitions/SubResource'))
      {
        $.allOf[0]['$ref'] = $.allOf[0]['$ref'].replace('SubResource', 'FrontDoorResource');
        delete $.properties.name;
        delete $.properties.type;
      }
  - from: frontdoor.json
    where: $.definitions
    transform: >
      $.FrontendEndpointUpdateParameters.properties.sessionAffinityTtlSeconds['x-ms-client-name'] = 'SessionAffinityTtlInSeconds';
  - from: swagger-document
    where: $.definitions.ForwardingConfiguration.properties.cacheConfiguration
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RoutingRuleUpdateParameters.properties.rulesEngine
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointUpdateParameters.properties.webApplicationFirewallPolicyLink
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RoutingRuleUpdateParameters.properties.webApplicationFirewallPolicyLink
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Backend.properties.privateLinkResourceId
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Backend.properties.privateLinkLocation
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.Backend.properties.privateEndpointStatus
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RulesEngineAction.properties.routeConfigurationOverride
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RulesEngineRule.properties.matchConditions
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.RulesEngineRule.properties.matchProcessingBehavior
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsProvisioningState
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsProvisioningSubstate
    transform: >
        $["x-nullable"] = true;
  - from: swagger-document
    where: $.definitions.FrontendEndpointProperties.properties.customHttpsConfiguration
    transform: >
        $["x-nullable"] = true;

```
