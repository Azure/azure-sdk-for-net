# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: LoadTesting
namespace: Azure.ResourceManager.LoadTesting
require: https://github.com/Azure/azure-rest-api-specs/blob/3dae9445631a0e27d743c1355f8cb82391d1634f/specification/loadtestservice/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

irregular-plural-words:
  quota: quota

override-operation-name:
  Quotas_CheckAvailability: CheckLoadTestingQuotaAvailability

rename-mapping:
  Resource: LoadTestingBaseResource
  LoadTestResource: LoadTestingResource
  QuotaResource: LoadTestingQuota
  CheckQuotaAvailabilityResponse: LoadTestingQuotaAvailabilityResult
  EncryptionProperties: LoadTestingCmkEncryptionProperties
  EncryptionPropertiesIdentity: LoadTestingCmkIdentity
  EndpointDependency: LoadTestingEndpointDependency
  EndpointDetail: LoadTestingEndpointDetail
  OutboundEnvironmentEndpointCollection: OutboundEnvironmentEndpointListResult
  QuotaBucketRequest: LoadTestingQuotaBucketContent
  QuotaBucketRequestPropertiesDimensions: LoadTestingQuotaBucketDimensions
  QuotaResourceList: LoadTestingQuotaListResult
  ResourceState: LoadTestingProvisioningState
  Type: LoadTestingCmkIdentityType
  EncryptionPropertiesIdentity.resourceId: -|arm-id
  OutboundEnvironmentEndpoint: LoadTestingOutboundEnvironmentEndpoint

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'dataPlaneUri': 'string'
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

directive:
- from: loadtestservice.json
  where: definitions
  transform: >
    $.EncryptionProperties.properties.identity.properties.type['x-ms-client-name'] = 'identityType';
    $.EncryptionProperties['x-nullable'] = true;

```
