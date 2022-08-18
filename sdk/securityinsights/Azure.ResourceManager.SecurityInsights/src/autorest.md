# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: SecurityInsights
namespace: Azure.ResourceManager.SecurityInsights
require: https://github.com/Azure/azure-rest-api-specs/blob/53b1affe357b3bfbb53721d0a2002382a046d3b0/specification/securityinsights/resource-manager/readme.md
tag: package-preview-2022-08
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