# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ManagedServiceIdentities
namespace: Azure.ResourceManager.ManagedServiceIdentities
require: https://github.com/Azure/azure-rest-api-specs/blob/1e790cfc5ee4e7ff98f99dd19a3174c4dd58432b/specification/msi/resource-manager/readme.md
tag: package-2023-01-31
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
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

rename-mapping:
  Identity: UserAssignedIdentity
  AzureResource: IdentityAssociatedResourceData
  FederatedIdentityCredential.properties.issuer: IssuerUri

generate-arm-resource-extensions:
  - /{scope}/providers/Microsoft.ManagedIdentity/identities/default
```
