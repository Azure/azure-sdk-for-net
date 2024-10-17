# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DevHub
namespace: Azure.ResourceManager.DeverloperHub
require: https://github.com/Azure/azure-rest-api-specs/blob/e38a6d8c499aa984447d6c3ed8d686611405bf55/specification/developerhub/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

rename-mapping:
  TargetServiceBase: TargetServiceBaseInfo
  AzureResource: AzureResourceInfo
  ConfluentBootstrapServer: ConfluentBootstrapServerInfo
  ConfluentSchemaRegistry: ConfluentSchemaRegistryInfo
  AzureResourcePropertiesBase: AzureResourceBaseProperties
  SecretInfoBase: SecretBaseInfo
  ValueSecretInfo: RawValueSecretInfo
  AuthInfoBase: AuthBaseInfo
  AuthType: LinkerAuthType
  SecretType: LinkerSecretType
  SecretStore: LinkerSecretStore
  ClientType: LinkerClientType
  ValidateOperationResult: LinkerValidateOperationResult
  ValidateOperationResult.properties.reportStartTimeUtc: reportStartOn
  ValidateOperationResult.properties.reportEndTimeUtc: reportEndOn
  ValidationResultItem: LinkerValidationResultItemInfo
  ValidationResultStatus: LinkerValidationResultStatus
  AzureKeyVaultProperties.connectAsKubernetesCsiDriver: DoesConnectAsKubernetesCsiDriver
  DeleteWorkflowResponse: DeleteWorkflowResult
  GitHubOAuthInfoResponse: GitHubOAuthInfoResult
  PrLinkResponse: PrLinkResult

format-by-name-rules:
  'tenantId': 'uuid'
  'principalId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'keyVaultId': 'arm-id'
  'sourceId': 'arm-id'
  'targetId': 'arm-id'
  'ResourceId': 'arm-id'
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
  VNet: Vnet

generate-arm-resource-extensions:
  - /{resourceUri}/providers/Microsoft.DevHub/iacProfiles/{iacProfileName}

directive:
  - from: DevHub.json
    where: $.definitions
    transform: >
      $.AzureResource.properties.id['x-ms-format'] = 'arm-id';
      $.TargetServiceBase.properties.type['x-ms-client-name'] = 'TargetServiceType';
      $.AzureResourcePropertiesBase.properties.type['x-ms-client-name'] = 'AzureResourceType';

```
