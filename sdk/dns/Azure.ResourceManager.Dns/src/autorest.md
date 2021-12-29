# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
library-name: Dns
namespace: Azure.ResourceManager.Dns
require: https://github.com/Azure/azure-rest-api-specs/blob/48a49f06399fbdf21f17406b5042f96a5d573bf0/specification/dns/resource-manager/readme.md
clear-output-folder: true
skip-csproj: true
modelerfour:
  lenient-model-deduplication: true

# temp
list-exception:
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}

override-operation-name:
  RecordSets_ListByDnsZone: GetRecordSets
  RecordSets_ListAllByDnsZone: GetAllRecordSets

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/A: RecordSetA
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/AAAA: RecordSetAaaa
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CAA: RecordSetCaa
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/CNAME: RecordSetCname
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/MX: RecordSetMx
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsZones/{zoneName}/{recordType}/{relativeRecordSetName}|Microsoft.Network/dnsZones/NS: RecordSetNs
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
    where: $.definitions.Zone
    transform: >
      $["x-ms-client-name"] = "DnsZone";
  - from: swagger-document
    where: $.definitions.ZoneUpdate
    transform: >
      $["x-ms-client-name"] = "ZoneUpdateOptions";
```
