# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: RecoveryServicesSiteRecovery
namespace: Azure.ResourceManager.RecoveryServicesSiteRecovery
require: https://github.com/Azure/azure-rest-api-specs/blob/95fb710c0025b325306898a3210333eaaf5d5e62/specification/recoveryservicessiterecovery/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  InMageRcmFailbackReplicationDetails.targetvCenterId: TargetVCenterId

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
  LRS: Lrs
  SSD: Ssd
  Vmware: VMware|vmware
  VCPUs: VCpus
  Vcenter: VCenter

request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs/export: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{resourceName}/replicationJobs/{jobName}

directive:
  - remove-operation: Operations_List
  # Because can't rename the purge operation, so have to make this change to avoid compiling error.
  # Issue filed here: https://github.com/Azure/autorest.csharp/issues/2743
  - remove-operation: ReplicationFabrics_Purge
  - remove-operation: ReplicationRecoveryServicesProviders_Purge
  # Why the `client` value can't be processing correctly but only `method`?
  - from: service.json
    where: $.parameters
    transform: >
      $.ResourceGroupName['x-ms-parameter-location'] = 'method';
      $.ResourceName['x-ms-parameter-location'] = 'method';

```
