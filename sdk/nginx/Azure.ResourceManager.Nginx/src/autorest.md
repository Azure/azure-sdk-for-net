# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Nginx
namespace: Azure.ResourceManager.Nginx
require: https://github.com/Azure/azure-rest-api-specs/blob/d1f4d6fcf1bbb2e71a32bb2079de12f17fedf56a/specification/nginx/resource-manager/readme.md
tag: package-2024-01-01-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  NginxNetworkInterfaceConfiguration.subnetId: -|arm-id
  NginxPrivateIPAddress.privateIPAddress: -|ip-address
  NginxPrivateIPAddress.subnetId: -|arm-id
  AnalysisCreate : NginxAnalysisContent
  AnalysisCreateConfig: NginxAnalysisConfig
  NginxCertificateErrorResponseBody: NginxCertificateError

prepend-rp-prefix:
  - ProvisioningState
  - ResourceSku
  - AnalysisDiagnostic
  - AnalysisResult
  - ScaleProfile
  - ScaleProfileCapacity

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
