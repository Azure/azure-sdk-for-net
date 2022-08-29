# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Dns
namespace: Azure.ResourceManager.Dns
require: https://github.com/Azure/azure-rest-api-specs/blob/48a49f06399fbdf21f17406b5042f96a5d573bf0/specification/dns/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
  lenient-model-deduplication: true

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
  ARecord: ARecordInfo
  AaaaRecord: AaaaRecordInfo
  MxRecord: MXRecordInfo
  NsRecord: NSRecordInfo
  PtrRecord: PtrRecordInfo
  SrvRecord: SrvRecordInfo
  TxtRecord: TxtRecordInfo
  CnameRecord: CnameRecordInfo
  SoaRecord: SoaRecordInfo
  CaaRecord: CaaRecordInfo

override-operation-name:
  RecordSets_ListByDnsZone: GetRecordSets
  RecordSets_ListAllByDnsZone: GetAllRecordSets

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/A: ARecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/AAAA: AaaaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CAA: CaaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CNAME: CnameRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/MX: MXRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/NS: NSRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/PTR: PtrRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/SOA: SoaRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/SRV: SrvRecord
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/TXT: TxtRecord
# Add nullable annotations
directive:
  - from: swagger-document
    where: $.definitions.ZoneProperties
    transform: $.properties.maxNumberOfRecordsPerRecordSet["x-nullable"] = true;
# Rename models
  - from: swagger-document
    where: $.definitions.ZoneUpdate
    transform: $["x-ms-client-name"] = "ZoneUpdateOptions";

  - from: swagger-document
    where: $.definitions.NsRecord.properties.nsdname
    transform: $["x-ms-client-name"] = "DnsNSDomainName";
  - from: swagger-document
    where: $.definitions.PtrRecord.properties.ptrdname
    transform: $["x-ms-client-name"] = "DnsPtrDomainName";
  - from: swagger-document
    where: $.definitions.RecordSetProperties.properties.TTL
    transform: $["x-ms-client-name"] = "TtlInSeconds";
  - from: swagger-document
    where: $.definitions.TxtRecord.properties.value
    transform: $["x-ms-client-name"] = "values";

# FooTime => FooTimeInSeconds
  - from: swagger-document
    where: $.definitions.SoaRecord.properties.expireTime
    transform: $["x-ms-client-name"] = "expireTimeInSeconds";
  - from: swagger-document
    where: $.definitions.SoaRecord.properties.retryTime
    transform: $["x-ms-client-name"] = "retryTimeInSeconds";
  - from: swagger-document
    where: $.definitions.SoaRecord.properties.minimumTTL
    transform: $["x-ms-client-name"] = "minimumTtlInSeconds";
  - from: swagger-document
    where: $.definitions.SoaRecord.properties.refreshTime
    transform: $["x-ms-client-name"] = "refreshTimeInSeconds";

# Add Prepend Name
  - from: swagger-document
    where: $.definitions.Zone
    transform: $["x-ms-client-name"] = "DnsZone";
  - from: swagger-document
    where: $.definitions.ZoneProperties.properties.zoneType
    transform: $["x-ms-enum"].name = "DnsZoneType";
  - from: swagger-document
    where: $.definitions.ZoneListResult
    transform: $["x-ms-client-name"] = "DnsZoneListResult";

# Mx Ns => MX NS
  - from: swagger-document
    where: $.definitions.RecordSetProperties.properties.MXRecords
    transform: $["x-ms-client-name"] = "MXRecords";
  - from: swagger-document
    where: $.definitions.RecordSetProperties.properties.NSRecords
    transform: $["x-ms-client-name"] = "NSRecords";
```
