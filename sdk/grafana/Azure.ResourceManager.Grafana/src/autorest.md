# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Grafana
namespace: Azure.ResourceManager.Grafana
require: https://github.com/Azure/azure-rest-api-specs/blob/6080b0126065467abbb3e096b25ed4ad6c22fa1f/specification/dashboard/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  AzureMonitorWorkspaceIntegration: MonitorWorkspaceIntegration
  AzureMonitorWorkspaceIntegration.azureMonitorWorkspaceResourceId: MonitorWorkspaceResourceId|arm-id
  GrafanaIntegrations.azureMonitorWorkspaceIntegrations: MonitorWorkspaceIntegrations
  ManagedGrafanaPropertiesUpdateParameters: ManagedGrafanaPatchProperties

  ResourceSku: ManagedGrafanaSku

prepend-rp-prefix:
  - ApiKey
  - PublicNetworkAccess
  - ProvisioningState
  - ZoneRedundancy

format-by-name-rules:
  'etag': 'etag'
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

```
