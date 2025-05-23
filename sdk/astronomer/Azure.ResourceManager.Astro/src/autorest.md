# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: Astro
namespace: Azure.ResourceManager.Astro
require: https://github.com/Azure/azure-rest-api-specs/blob/ceb1849d35534ccb6c2dfc3772bb2426dd37df6a/specification/liftrastronomer/resource-manager/readme.md
#tag: package-2023-08-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  LiftrBaseDataOrganizationProperties: AstroOrganizationProperties
  LiftrBaseDataPartnerOrganizationProperties: AstroPartnerOrganizationProperties
  LiftrBaseDataPartnerOrganizationPropertiesUpdate: AstroPartnerOrganizationUpdateProperties
  LiftrBaseMarketplaceDetails: AstroMarketplaceDetails
  LiftrBaseOfferDetails: AstroOfferDetails
  LiftrBaseSingleSignOnProperties: AstroSingleSignOnProperties
  LiftrBaseUserDetails: AstroUserDetails
  LiftrBaseUserDetailsUpdate: AstroUserUpdateDetails
  OrganizationResource: AstroOrganization
  OrganizationResourceUpdateProperties: AstroOrganizationUpdateProperties
  SingleSignOnStates: AstroSingleSignOnState
  ResourceProvisioningState: AstroResourceProvisioningState

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
