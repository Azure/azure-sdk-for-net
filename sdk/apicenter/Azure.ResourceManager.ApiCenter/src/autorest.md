# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
csharp: true
library-name: ApiCenter
namespace: Azure.ResourceManager.ApiCenter
require: https://github.com/Azure/azure-rest-api-specs/blob/2d701c73fb5ee44f95b97b6c3eaf8c4aeb051e73/specification/apicenter/resource-manager/readme.md
#tag: package-2024-03
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
  Api: ApiEntity
  ApiProperties: ApiEntityProperties
  ApiDefinition: ApiDefinitionEntity
  ApiDefinitionProperties: ApiDefinitionEntityProperties
  ApiVersion: ApiVersionEntity
  ApiVersionProperties: ApiVersionEntityProperties
  Contact: ApiContact
  Deployment: ApiDeploymentEntity
  DeploymentProperties: ApiDeploymentEntityProperties
  Environment: EnvironmentEntity
  EnvironmentProperties: EnvironmentEntityProperties
  License: ApiLicense
  MetadataSchema: MetadataSchemaEntity
  MetadataSchemaProperties: MetadataSchemaEntityProperties
  Onboarding: EnvironmentOnboarding
  Service: ServiceEntity
  ServiceProperties: ServiceEntityProperties
  Workspace: WorkspaceEntity
  WorkspaceProperties: WorkspaceEntityProperties
  ApiDefinitionPropertiesSpecification: ApiSpecification

prepend-rp-prefix:
  - ProvisioningState

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
  API: Api|api
  AWSAPI: AwsApi

```
