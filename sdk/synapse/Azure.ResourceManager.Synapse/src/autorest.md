# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Synapse
namespace: Azure.ResourceManager.Synapse
# The readme.md in swagger repo contains invalid setting for C# sdk
# require: /mnt/vss/_work/1/s/azure-rest-api-specs/specification/synapse/resource-manager/readme.md
tag: package-composite-v2
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true   # Mitigate the duplication schema 'ErrorResponse' issue

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

list-exception:
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/schemas/{schemaName}/tables/{tableName}/columns/{columnName}/sensitivityLabels/{sensitivityLabelSource}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/connectionPolicies/{connectionPolicyName}
  - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/vulnerabilityAssessments/{vulnerabilityAssessmentName}/rules/{ruleId}/baselines/{baselineName}

override-operation-name:
  IntegrationRuntimeStatus_Get: GetIntegrationRuntimeStatus

directive:
  - remove-operation: Operations_List
  - remove-operation: Operations_GetLocationHeaderResult
  - remove-operation: Operations_GetAzureAsyncHeaderResult
  - from: operations.json
    where: $.definitions
    transform: >
      $.OperationMetaLogSpecification.properties.blobDuration['format'] = 'duration';
  - from: sqlPool.json
    where: $.definitions
    transform: >
      $.MaintenanceWindowTimeRange.properties.duration['format'] = 'duration';
  - from: kustoPool.json
    where: $.definitions
    transform: >
      $.DatabaseCheckNameRequest.properties.type['x-ms-client-name'] = 'resourceType';
      $.DatabaseCheckNameRequest.properties.type['x-ms-enum']['name'] = 'KustoDatabaseResourceType';
  # Fix the dubplicate schema 'PrivateEndpointConnectionForPrivateLinkHubBasic'
  - from: privatelinkhub.json
    where: $.definitions
    transform: >
      $.PrivateLinkHubProperties.properties.privateEndpointConnections.items['$ref'] = '../../../../common/v1/privateEndpointConnection.json#/definitions/PrivateEndpointConnectionForPrivateLinkHubBasic';
      delete $.PrivateEndpointConnectionForPrivateLinkHubBasic;
  # Fix the duplicating schema 'SecurityAlertPolicyName'
  - from: sqlPool.json
    where: $.paths..parameters[?(@.name === 'securityAlertPolicyName')]
    transform: >
      $['x-ms-enum']['name'] = 'SqlPoolSecurityAlertPolicyName';
  - from: sqlServer.json
    where: $.paths..parameters[?(@.name === 'securityAlertPolicyName')]
    transform: >
      $['x-ms-enum']['name'] = 'SqlServerSecurityAlertPolicyName';

```

### Tag: package-composite-v2

These settings apply only when --tag=package-composite-v2 is specified on the command line.

```yaml $(tag) == 'package-composite-v2'
input-file:
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/azureADOnlyAuthentication.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/checkNameAvailability.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/firewallRule.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/keys.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/operations.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privateEndpointConnections.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privateLinkResources.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/privatelinkhub.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/sqlPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/sqlServer.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/stable/2021-06-01/workspace.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/bigDataPool.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/library.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/integrationRuntime.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/sparkConfiguration.json
  - https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/synapse/resource-manager/Microsoft.Synapse/preview/2021-06-01-preview/kustoPool.json
```
