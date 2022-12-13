# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: LoadTesting
namespace: Azure.ResourceManager.LoadTesting
require: https://github.com/Azure/azure-rest-api-specs/blob/ec278eb936001b993e0413d66d8cc88e73540331/specification/loadtestservice/resource-manager/readme.md
tag: package-2022-12-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

irregular-plural-words:
  quota: quota

rename-mapping:
  Resource: LoadTestingBaseResource
  LoadTestResource: LoadTestingResource
  QuotaResource: LoadTestingQuota
  CheckQuotaAvailabilityResponse: LoadTestingQuotaAvailabilityResponse
  EncryptionProperties: CustomerManagedKeyEncryptionProperties
  EncryptionPropertiesIdentity: CustomerManagedKeyIdentity
  EndpointDependency: LoadTestingEndpointDependency
  EndpointDetail: LoadTestingEndpointDetail
  OutboundEnvironmentEndpointCollection: OutboundEnvironmentEndpointListResult
  QuotaBucketRequest: LoadTestingQuotaBucketContent
  QuotaBucketRequestPropertiesDimensions: LoadTestingQuotaBucketDimensions
  QuotaResourceList: LoadTestingQuotaListResult
  ResourceState: LoadTestingProvisioningState
  Type: CustomerManagedKeyIdentityType
  EncryptionPropertiesIdentity.resourceId: -|arm-id

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'dataPlaneUri': 'string'
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
- from: loadtestservice.json
  where: definitions
  transform: >
    $.EncryptionProperties.properties.identity.properties.type['x-ms-client-name'] = 'identityType';
    $.EncryptionProperties['x-nullable'] = true;

```