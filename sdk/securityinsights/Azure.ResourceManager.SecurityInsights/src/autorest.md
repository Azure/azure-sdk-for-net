# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SecurityInsights
namespace: Azure.ResourceManager.SecurityInsights
# default tag is a preview version
require: /mnt/vss/_work/1/s/azure-rest-api-specs/specification/securityinsights/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-parent:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}

request-path-to-resource-data:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}: ThreatIntelligenceIndicatorModel

operation-positions:
  ThreatIntelligenceIndicators_List: collection

rename-mapping:
  Bookmark.properties.updated: UpdatedOn
  EnrichmentDomainWhois.expires: ExpireOn
  EnrichmentDomainWhois.updated: UpdatedOn
  HuntingBookmark.properties.updated: UpdatedOn
  Watchlist.properties.updated: UpdatedOn
  WatchlistItem.properties.updated: UpdatedOn
  AlertRule: SecurityInsightsAlertRule
  ThreatIntelligenceIndicatorModel: ThreatIntelligenceIndicator

override-operation-name:
  DomainWhois_Get: GetDomainWhoisInformation

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
  - rename-operation:
      from: ThreatIntelligenceIndicator_Get
      to: ThreatIntelligenceIndicators_Get
  - rename-operation:
      from: ThreatIntelligenceIndicator_Create
      to: ThreatIntelligenceIndicators_Update
  - rename-operation:
      from: ThreatIntelligenceIndicator_Delete
      to: ThreatIntelligenceIndicators_Delete
  - rename-operation:
      from: ThreatIntelligenceIndicator_AppendTags
      to: ThreatIntelligenceIndicators_AppendTags
  - rename-operation:
      from: ThreatIntelligenceIndicator_ReplaceTags
      to: ThreatIntelligenceIndicators_ReplaceTags
  - rename-operation:
      from: ThreatIntelligenceIndicator_CreateIndicator
      to: ThreatIntelligenceIndicators_Create
  - rename-operation:
      from: ThreatIntelligenceIndicatorMetrics_List
      to: ThreatIntelligenceIndicators_ListMetrics
  - rename-operation:
      from: ThreatIntelligenceIndicator_QueryIndicators
      to: ThreatIntelligenceIndicators_Query
  - rename-operation:
      from: Bookmark_Expand
      to: Bookmarks_Expand
  - from: dataConnectors.json
    where: $.definitions
    transform: >
      $.DataConnectorWithAlertsProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.MTPDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.AwsCloudTrailDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.MSTIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.AwsS3DataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.MCASDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.Dynamics365DataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.Office365ProjectDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.OfficePowerBIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.OfficeDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.TIDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.TiTaxiiDataConnectorProperties.properties.dataTypes["x-ms-client-flatten"] = true;
      $.CodelessUiConnectorConfigProperties.properties.dataTypes["x-ms-client-flatten"] = true;
```
