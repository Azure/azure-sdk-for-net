# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: PrivateDns
namespace: Azure.ResourceManager.PrivateDns
require: https://github.com/Azure/azure-rest-api-specs/blob/6b08774c89877269e73e11ac3ecbd1bd4e14f5a0/specification/privatedns/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  sample: false
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*Guid': 'uuid'
  'ifMatch': 'etag'
  'IPv6Address': 'ip-address'
  'IPv4Address': 'ip-address'

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
  ARecord: PrivateDnsARecordInfo
  AaaaRecord: PrivateDnsAaaaRecordInfo
  CnameRecord: PrivateDnsCnameRecordInfo
  MxRecord: PrivateDnsMXRecordInfo
  PtrRecord: PrivateDnsPtrRecordInfo
  SoaRecord: PrivateDnsSoaRecordInfo
  SrvRecord: PrivateDnsSrvRecordInfo
  TxtRecord: PrivateDnsTxtRecordInfo
  ProvisioningState : PrivateDnsProvisioningState

override-operation-name:
  RecordSets_List: GetRecords

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/A: PrivateDnsARecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/AAAA: PrivateDnsAaaaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/CNAME: PrivateDnsCnameRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/MX: PrivateDnsMXRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/PTR: PrivateDnsPtrRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/SOA: PrivateDnsSoaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/SRV: PrivateDnsSrvRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/privateDnsZones/{privateZoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/privateDnsZones/TXT: PrivateDnsTxtRecord

directive:
  - from: privatedns.json
    where: $.definitions
    transform: >
      $.PrivateZone["x-ms-client-name"] = "PrivateDnsZone";
      $.RecordSet["x-ms-client-name"] = "PrivateDnsRecord";
      $.RecordSetListResult["x-ms-client-name"] = "PrivateDnsRecordListResult";
      $.RecordSetProperties["x-ms-client-name"] = "PrivateDnsRecordProperties";
      $.RecordSetProperties.properties.ttl["x-ms-client-name"] = "TtlInSeconds";
      $.RecordSetProperties.properties.mxRecords["x-ms-client-name"] = "PrivateDnsMXRecords";
      $.PrivateZoneProperties.properties.numberOfRecordSets["x-ms-client-name"] = "numberOfRecords";
      $.PtrRecord.properties.ptrdname["x-ms-client-name"] = "PtrDomainName";
      $.TxtRecord.properties.value["x-ms-client-name"] = "values";
      $.PrivateZoneProperties.properties.maxNumberOfRecordSets["x-ms-client-name"] = "maxNumberOfRecords";

# FooTime => FooTimeInSeconds
  - from: privatedns.json
    where: $.definitions
    transform: >
      $.SoaRecord.properties.expireTime["x-ms-client-name"] = "expireTimeInSeconds";
      $.SoaRecord.properties.retryTime["x-ms-client-name"] = "retryTimeInSeconds";
      $.SoaRecord.properties.minimumTtl["x-ms-client-name"] = "minimumTtlInSeconds";
      $.SoaRecord.properties.refreshTime["x-ms-client-name"] = "refreshTimeInSeconds";
```
