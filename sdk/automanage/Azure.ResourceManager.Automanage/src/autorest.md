# Generated code configuration
Run `dotnet build /t:GenerateCode` to generate code.
``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: Automanage
namespace: Azure.ResourceManager.Automanage
require: https://github.com/Azure/azure-rest-api-specs/blob/4b5fe2fb0a5066c4ff2bd429dbd5e1afda6afab3/specification/automanage/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
request-path-is-non-resource:
  - /{scope}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}
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
directive:
  # these operations will be supported in the future
  - remove-operation: BestPracticesVersions_Get
  - remove-operation: BestPracticesVersions_ListByTenant
#use scope parameter on the two paths that are defined multiple times
  - from: automanage.json
    where: $.paths
    transform: $['/{scope}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}'] = $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}']
  - from: automanage.json
    where: $.paths
    transform: $['/{scope}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}'] = $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}']
#add definition for scope parameter
  - from: automanage.json
    where: $.paths['/{scope}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}']
    transform: >
      $.put.parameters = [
          {
            "name": "scope",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The scope the configuration profile assignments apply to.  Valid scopes are /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}, or /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}",
            "x-ms-skip-url-encoding": true
          },
          {
            "name": "configurationProfileAssignmentName",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "Name of the configuration profile assignment. Only default is supported."
          },
          {
            "name": "parameters",
            "in": "body",
            "required": true,
            "schema": {
            "$ref": "#/definitions/ConfigurationProfileAssignment"
            },
            "description": "Parameters supplied to the create or update configuration profile assignment."
          },
          {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
          }
      ];
      $.get.parameters = [
          {
            "name": "scope",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The scope the configuration profile assignments apply to.  Valid scopes are /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}, or /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}",
            "x-ms-skip-url-encoding": true
          },
          {
            "name": "configurationProfileAssignmentName",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The configuration profile assignment name."
          },
          {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
          }
      ];
      $.delete.parameters = [
          {
            "name": "scope",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The scope the configuration profile assignments apply to.  Valid scopes are /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}, or /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}",
            "x-ms-skip-url-encoding": true
          },
          {
            "name": "configurationProfileAssignmentName",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The configuration profile assignment name."
          },
          {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
          }
      ];
  - from: automanage.json
    where: $.paths['/{scope}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}'].get.parameters
    transform: >
      $ = [
          {
            "name": "scope",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The scope the configuration profile assignments apply to.  Valid scopes are /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}, /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}, or /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}",
            "x-ms-skip-url-encoding": true
          },
          {
            "name": "configurationProfileAssignmentName",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The configuration profile assignment name."
          },
          {
            "name": "reportName",
            "in": "path",
            "required": true,
            "type": "string",
            "description": "The report name."
          },
          {
            "$ref": "../../../../../common-types/resource-management/v2/types.json#/parameters/ApiVersionParameter"
          }
      ]
#remove old paths
  - from: automanage.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}']
    transform: $ = {}
  - from: automanage.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}']
    transform: $ = {}
  - from: automanage.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}']
    transform: $ = {}
  - from: automanage.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}']
    transform: $ = {}
  - from: automanage.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.HybridCompute/machines/{machineName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}']
    transform: $ = {}
  - from: automanage.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AzureStackHci/clusters/{clusterName}/providers/Microsoft.Automanage/configurationProfileAssignments/{configurationProfileAssignmentName}/reports/{reportName}']
    transform: $ = {}
```
