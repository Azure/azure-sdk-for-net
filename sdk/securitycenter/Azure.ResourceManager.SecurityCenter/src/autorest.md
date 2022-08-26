# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SecurityCenter
namespace: Azure.ResourceManager.SecurityCenter
require: https://github.com/Azure/azure-rest-api-specs/blob/e686ed79e9b0bbc10355fd8d7ba36d1a07e4ba28/specification/security/resource-manager/readme.md
tag: package-composite-v3
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  OnPremiseResourceDetails.vmuuid: VmUuid|uuid
  RecommendationType.IoT_ACRAuthentication: IotAcrAuthentication
  RecommendationType.IoT_IPFilter_DenyAll: IotIPFilterDenyAll
  RecommendationType.IoT_IPFilter_PermissiveRule: IotIPFilterPermissiveRule

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-rules:
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
  IoT: Iot
  TLS: Tls

list-exception:
  - /{resourceId}/providers/Microsoft.Security/assessments/{assessmentName}
  - /subscriptions/{subscriptionId}/providers/Microsoft.Security/locations/{ascLocation}/applicationWhitelistings/{groupName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/allowedConnections/{connectionType}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/topologies/{topologyResourceName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/discoveredSecuritySolutions/{discoveredSecuritySolutionName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/ExternalSecuritySolutions/{externalSecuritySolutionsName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/locations/{ascLocation}/securitySolutions/{securitySolutionName}

directive:
  - rename-operation:
      from: SecurityConnectorApplication_Get
      to: SecurityConnectorApplications_Get
  - rename-operation:
      from: SecurityConnectorApplication_CreateOrUpdate
      to: SecurityConnectorApplications_CreateOrUpdate
  - rename-operation:
      from: SecurityConnectorApplication_Delete
      to: SecurityConnectorApplications_Delete
  - rename-operation:
      from: SecurityConnectorGovernanceRule_List
      to: SecurityConnectorGovernanceRules_List
  - from: externalSecuritySolutions.json
    where: $.definitions
    transform: >
      $.ExternalSecuritySolutionKind.properties.kind['x-ms-enum']['name'] = 'ExternalSecuritySolutionKindType';
      $.AadConnectivityState.properties.connectivityState['x-ms-enum']['name'] = 'AadConnectivityStateType';
  - from: jitNetworkAccessPolicies.json
    where: $.definitions
    transform: >
      $.JitNetworkAccessPortRule.properties.maxRequestAccessDuration['format'] = 'duration';
  - from: types.json
    where: $.definitions.Kind
    transform: >
      $['x-ms-client-name'] = 'ResourceKind';
  - from: securityConnectors.json
    where: $.definitions
    transform: >
      $.defenderForServersAwsOffering.properties.vaAutoProvisioning.properties.configuration.properties.type['x-ms-enum']['name'] = 'VAAutoProvisioningType';
      $.defenderForServersAwsOffering.properties.subPlan.properties.type['x-ms-enum']['name'] = 'AvailableSubPlanType';
      $.defenderForServersGcpOffering.properties.vaAutoProvisioning.properties.configuration.properties.type['x-ms-enum']['name'] = 'VAAutoProvisioningType';
      $.defenderForServersGcpOffering.properties.subPlan.properties.type['x-ms-enum']['name'] = 'AvailableSubPlanType';
  - from: alerts.json
    where: $.definitions
    transform: >
      $.ResourceIdentifier['x-ms-client-name'] = 'AlertResourceIdentifier';
  # TODO: temporary remove these operations to mitigate the exception from BuildParameterMapping in Autorext.CSharp
  - remove-operation: InformationProtectionPolicies_Get
  - remove-operation: Tasks_UpdateSubscriptionLevelTaskState
  - remove-operation: Tasks_UpdateResourceGroupLevelTaskState
```