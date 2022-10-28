# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: OperationalInsights
namespace: Azure.ResourceManager.OperationalInsights
require: /mnt/vss/_work/1/s/azure-rest-api-specs/specification/operationalinsights/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

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
  - remove-operation: OperationStatuses_Get
  # Dup model `SystemData` in this RP, should use the common type
  - from: QueryPackQueries.json
    where: $.definitions
    transform: >
      delete $.SystemData;
      delete $.IdentityType;
      $.AzureResourceProperties.properties.systemData['$ref'] = '../../../../../common-types/resource-management/v2/types.json#/definitions/ErrorResponse';
  # Codegen can't handle integter enum properly, should be fixed before GA
  - from: Workspaces.json
    where: $.definitions
    transform: >
      delete $.WorkspaceSku.properties.capacityReservationLevel['enum'];
      delete $.WorkspaceSku.properties.capacityReservationLevel['x-ms-enum'];
  # Codegen can't handle integter enum properly, should be fixed before GA
  - from: Clusters.json
    where: $.definitions
    transform: >
      delete $.ClusterSku.properties.capacity['enum'];
      delete $.ClusterSku.properties.capacity['x-ms-enum'];
  # The `type` is reserved name
  - from: Tables.json
    where: $.definitions
    transform: >
      $.Column.properties.type['x-ms-client-name'] = 'ColumnType';

```
