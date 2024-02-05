# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Dns
namespace: Azure.ResourceManager.Dns
require: https://github.com/Azure/azure-rest-api-specs/blob/48a49f06399fbdf21f17406b5042f96a5d573bf0/specification/dns/resource-manager/readme.md
# tag: package-2018-05
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
  sample: false
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true
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
  SAS: Sas
  SKU: Sku
  SMB: Smb
  NFS: Nfs
  LRS: Lrs
  ZRS: Zrs
  GRS: Grs
  TLS: Tls
  AAD: Aad
  GET: Get
  PUT: Put
  RecordType: DnsRecordType
  ARecord: DnsARecordInfo
  AaaaRecord: DnsAaaaRecordInfo
  MxRecord: DnsMXRecordInfo
  NsRecord: DnsNSRecordInfo
  PtrRecord: DnsPtrRecordInfo
  SrvRecord: DnsSrvRecordInfo
  TxtRecord: DnsTxtRecordInfo
  CnameRecord: DnsCnameRecordInfo
  SoaRecord: DnsSoaRecordInfo
  CaaRecord: DnsCaaRecordInfo

override-operation-name:
  RecordSets_ListByDnsZone: GetAllRecordData # Change back to GetRecords once the polymorphic resource change is merged.
  DnsResourceReference_GetByTargetResources: GetDnsResourceReferencesByTargetResources
  Zones_List: GetDnsZones

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/A: DnsARecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/AAAA: DnsAaaaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CAA: DnsCaaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CNAME: DnsCnameRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/MX: DnsMXRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/NS: DnsNSRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/PTR: DnsPtrRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/SOA: DnsSoaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/SRV: DnsSrvRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/TXT: DnsTxtRecord

directive:
  - remove-operation: RecordSets_ListAllByDnsZone
  - from: swagger-document
    where: $.definitions
    transform: >
      $.RecordSet["x-ms-client-name"] = "DnsRecord";
      $.RecordSetListResult["x-ms-client-name"] = "DnsRecordListResult";
      $.ZoneUpdate["x-ms-client-name"] = "ZoneUpdateOptions";
      $.NsRecord.properties.nsdname["x-ms-client-name"] = "DnsNSDomainName";
      $.PtrRecord.properties.ptrdname["x-ms-client-name"] = "DnsPtrDomainName";
      $.RecordSetProperties.properties.TTL["x-ms-client-name"] = "TtlInSeconds";
      $.TxtRecord.properties.value["x-ms-client-name"] = "values";
      $.ZoneProperties.properties.maxNumberOfRecordsPerRecordSet["x-nullable"] = true;
      $.ZoneProperties.properties.maxNumberOfRecordSets["x-ms-client-name"] = "maxNumberOfRecords";
      $.ZoneProperties.properties.maxNumberOfRecordsPerRecordSet["x-ms-client-name"] = "maxNumberOfRecordsPerRecord";
      $.ZoneProperties.properties.numberOfRecordSets["x-ms-client-name"] = "numberOfRecords";

# FooTime => FooTimeInSeconds
  - from: swagger-document
    where: $.definitions
    transform: >
      $.SoaRecord.properties.expireTime["x-ms-client-name"] = "expireTimeInSeconds";
      $.SoaRecord.properties.retryTime["x-ms-client-name"] = "retryTimeInSeconds";
      $.SoaRecord.properties.minimumTTL["x-ms-client-name"] = "minimumTtlInSeconds";
      $.SoaRecord.properties.refreshTime["x-ms-client-name"] = "refreshTimeInSeconds";

# Add Prepend Name
  - from: swagger-document
    where: $.definitions
    transform: >
      $.Zone["x-ms-client-name"] = "DnsZone";
      $.ZoneProperties.properties.zoneType["x-ms-enum"].name = "DnsZoneType";
      $.ZoneListResult["x-ms-client-name"] = "DnsZoneListResult";

# Mx Ns => MX NS
  - from: swagger-document
    where: $.definitions
    transform: >
      $.RecordSetProperties.properties.MXRecords["x-ms-client-name"] = "MXRecords";
      $.RecordSetProperties.properties.NSRecords["x-ms-client-name"] = "NSRecords";
```
