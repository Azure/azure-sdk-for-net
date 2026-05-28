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
  Contact: ApiContactInformation
  License: ApiLicenseInformation
  Onboarding: EnvironmentOnboardingInformation
  ApiDefinitionPropertiesSpecification: ApiSpecificationDetails
  ExternalDocumentation: ApiExternalDocumentation
  LifecycleStage: ApiLifecycleStage
  DeploymentProperties.environmentId: -|arm-id
  DeploymentProperties.definitionId: -|arm-id

prepend-rp-prefix:
  - ProvisioningState
  - Service
  - ServiceProperties
  - Workspace
  - WorkspaceProperties
  - Environment
  - EnvironmentProperties
  - EnvironmentKind
  - EnvironmentServer
  - Deployment
  - DeploymentProperties
  - DeploymentServer
  - DeploymentState
  - Api
  - ApiProperties
  - ApiDefinition
  - ApiDefinitionProperties
  - ApiVersion
  - ApiVersionProperties
  - MetadataSchema
  - MetadataSchemaProperties
  - MetadataAssignment

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
