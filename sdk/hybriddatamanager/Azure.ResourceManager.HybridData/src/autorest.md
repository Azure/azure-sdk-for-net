# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: HybridData
namespace: Azure.ResourceManager.HybridData
require: https://github.com/Azure/azure-rest-api-specs/blob/8d9e22058eb70f4d20baf1f0594b22f76f957c96/specification/hybriddatamanager/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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
  RSA: Rsa

rename-mapping:
  JobDefinition: HybridDataJobDefinition
  Job: HybridDataJob
  JobDetails: HybridDataJobDetails
  JobStages: HybridDataJobStage
  State: HybridDataState
  DataStore.properties.repositoryId: -|arm-id
  DataStore.properties.dataStoreTypeId: -|arm-id
  CustomerSecret: HybridDataCustomerSecret
  DataStoreType.properties.repositoryType: -|resource-type
  Error: HybridDataJobTopLevelError
  ErrorDetails: HybridDataJobErrorDetails
  JobStatus: HybridDataJobStatus
  IsJobCancellable: JobCancellationSetting
  RunLocation: HybridDataJobRunLocation
  RunLocation.australiaeast: AustraliaEast
  RunLocation.australiasoutheast: AustraliaSoutheast
  RunLocation.brazilsouth: BrazilSouth
  RunLocation.canadacentral: CanadaCentral
  RunLocation.canadaeast: CanadaEast
  RunLocation.centralindia: CentralIndia
  RunLocation.centralus: CentralUS
  RunLocation.eastasia: EastAsia
  RunLocation.eastus: EastUS
  RunLocation.eastus2: EastUS2
  RunLocation.japaneast: JapanEast
  RunLocation.japanwest: JapanWest
  RunLocation.koreacentral: KoreaCentral
  RunLocation.koreasouth: KoreaSouth
  RunLocation.southeastasia: SoutheastAsia
  RunLocation.southcentralus: SouthCentralUS
  RunLocation.southindia: SouthIndia
  RunLocation.northcentralus: NorthCentralUS
  RunLocation.northeurope: NorthEurope
  RunLocation.uksouth: UKSouth
  RunLocation.ukwest: UKWest
  RunLocation.westcentralus: WestCentralUS
  RunLocation.westeurope: WestEurope
  RunLocation.westindia: WestIndia
  RunLocation.westus: WestUS
  RunLocation.westus2: WestUS2
  Schedule: HybridDataJobRunSchedule
  UserConfirmation: UserConfirmationSetting
  RunParameters: HybridDataJobRunContent
  PublicKey: HybridDataPublicKey
  Key: HybridDataEncryptionKey
  SupportedAlgorithm: SupportedEncryptionAlgorithm
  DataManager: HybridDataManager
  DataService: HybridDataService
  DataStore: HybridDataStore
  DataStoreType: HybridDataStoreType

```
