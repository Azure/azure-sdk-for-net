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

override-operation-name:
  RecordSets_ListByDnsZone: GetRecordSets
  RecordSets_ListAllByDnsZone: GetAllRecordSets

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/A: RecordSetA
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/AAAA: RecordSetAaaa
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CAA: RecordSetCaa
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CNAME: RecordSetCname
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/MX: RecordSetMX
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/NS: RecordSetNS
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/PTR: RecordSetPtr
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/SOA: RecordSetSoa
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/SRV: RecordSetSrv
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/TXT: RecordSetTxt
# Add nullable annotations
directive:
  - from: swagger-document
    where: $.definitions.ZoneProperties
    transform: >
      $.properties.maxNumberOfRecordsPerRecordSet["x-nullable"] = true;
# Rename models
  - from: swagger-document
    where: $.definitions.ZoneUpdate
    transform: >
      $["x-ms-client-name"] = "ZoneUpdateOptions";

  - from: swagger-document
    where: $.definitions.NsRecord.properties.nsdname
    transform: $["x-ms-client-name"] = "NsdName";
  - from: swagger-document
    where: $.definitions.PtrRecord.properties.ptrdname
    transform: $["x-ms-client-name"] = "PtrdName";

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

# Add prepend name to 10 RecordSet
  - from: swagger-document
    where: $.definitions.ARecord
    transform: $["x-ms-client-name"] = "DnsARecord";
  - from: swagger-document
    where: $.definitions.AaaaRecord
    transform: $["x-ms-client-name"] = "DnsAaaaRecord";
  - from: swagger-document
    where: $.definitions.MxRecord
    transform: $["x-ms-client-name"] = "DnsMXRecord";
  - from: swagger-document
    where: $.definitions.NsRecord
    transform: $["x-ms-client-name"] = "DnsNSRecord";
  - from: swagger-document
    where: $.definitions.PtrRecord
    transform: $["x-ms-client-name"] = "DnsPtrRecord";
  - from: swagger-document
    where: $.definitions.SrvRecord
    transform: $["x-ms-client-name"] = "DnsSrvRecord";
  - from: swagger-document
    where: $.definitions.TxtRecord
    transform: $["x-ms-client-name"] = "DnsTxtRecord";
  - from: swagger-document
    where: $.definitions.CnameRecord
    transform: $["x-ms-client-name"] = "DnsCnameRecord";
  - from: swagger-document
    where: $.definitions.SoaRecord
    transform: $["x-ms-client-name"] = "DnsSoaRecord";
  - from: swagger-document
    where: $.definitions.CaaRecord
    transform: $["x-ms-client-name"] = "DnsCaaRecord";

# Mx Ns => MX NS
  - from: swagger-document
    where: $.definitions.RecordSetProperties.properties.MXRecords
    transform: $["x-ms-client-name"] = "MXRecords";
  - from: swagger-document
    where: $.definitions.RecordSetProperties.properties.NSRecords
    transform: $["x-ms-client-name"] = "NSRecords";
```
