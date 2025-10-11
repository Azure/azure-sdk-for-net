# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ServiceLinker
namespace: Azure.ResourceManager.ServiceLinker
require: https://github.com/Azure/azure-rest-api-specs/blob/0e3900b050a2b449ab87d65ccb5413a362489eec/specification/servicelinker/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
deserialize-null-collection-as-null-value: true
use-model-reader-writer: true

rename-mapping:
  TargetServiceBase: TargetServiceBaseInfo
  TargetServiceBase.type: TargetServiceType
  AzureResource: AzureResourceInfo
  AzureResource.id: -|arm-id
  ConfluentBootstrapServer: ConfluentBootstrapServerInfo
  ConfluentSchemaRegistry: ConfluentSchemaRegistryInfo
  AzureResourcePropertiesBase: AzureResourceBaseProperties
  AzureResourcePropertiesBase.type: AzureResourceType
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
  DryrunParameters: ServiceLinkerDryrunParametersContent
  CreateOrUpdateDryrunParameters: ServiceLinkerCreateOrUpdateDryrunParametersContent
  ConfigurationResult: SourceConfigurationResult
  LinkerPatch: LinkerResourcePatch
  ActionType: ConfigurationActionType
  AllowType: FirewallRulesAllowType
  AuthMode: ConfigurationAuthMode
  ConfigurationInfo: LinkerConfigurationInfo
  ConfigurationName: LinkerConfigurationName
  ConfigurationName.required : IsRequired
  FirewallRules: LinkerFirewallRules
  DaprConfigurationResource: DaprConfigurationResourceItem

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
  - /{resourceUri}/providers/Microsoft.ServiceLinker/linkers/{linkerName}

request-path-to-resource-name:
  /{resourceUri}/providers/Microsoft.ServiceLinker/linkers/{linkerName}: LinkerResource
  /{resourceUri}/providers/Microsoft.ServiceLinker/dryruns/{dryrunName}: ServiceLinkerDryrun

```
