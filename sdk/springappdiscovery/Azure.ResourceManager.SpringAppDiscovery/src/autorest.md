# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: SpringAppDiscovery
namespace: Azure.ResourceManager.SpringAppDiscovery
require: https://github.com/Azure/azure-rest-api-specs/blob/c1ba9df47907f9012ae14ca4616aed9e5665f9e5/specification/offazurespringboot/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

mgmt-debug:
 show-serialized-names: true

rename-mapping:
    SpringbootsitesModel: SpringBootSite
    SpringbootsitesPatch: SpringBootSitePatch
    SpringbootsitesProperties: SpringBootSiteProperties
    SpringbootsitesListResult: SpringBootSiteList
    SpringbootserversModel: SpringBootServer
    SpringbootserversPatch: SpringBootServerPatch
    SpringbootserversProperties: SpringBootServerProperties
    SpringbootserversProperties.machineArmId: -|arm-id
    SpringbootserversProperties.fqdnAndIpAddressList: -|ip-address
    SpringbootserversListResult: SpringBootServerList
    SpringbootappsModel: SpringBootApp
    SpringbootappsPatch: SpringBootAppPatch
    SpringbootappsProperties: SpringBootAppProperties
    SpringbootappsProperties.machineArmIds: -|arm-id
    SpringbootappsListResult: SpringBootAppList
    ProvisioningState: SpringAppDiscoveryProvisioningState
    Error: SpringBootSiteError
    ErrorSummary: SpringBootSiteErrorSummary
    ErrorSummariesProperties: SpringBootSiteErrorSummariesProperties
    ErrorSummaryModel: SpringBootSiteErrorSummaryModel
    Summary: SpringBootSiteSummary
    SummariesProperties: SpringBootSiteSummariesProperties
    SpringbootsitesModelExtendedLocation: SpringBootSiteModelExtendedLocation
    SpringbootappsPropertiesMiscsItem: SpringBootAppMiscsItem
    SpringbootappsPropertiesApplicationConfigurationsItem: SpringBootAppApplicationConfigurationsItem
    SpringbootappsPropertiesInstancesItem: SpringBootAppInstancesItem
    SpringbootappsPropertiesInstancesItem.machineArmId: -|arm-id

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

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

```
