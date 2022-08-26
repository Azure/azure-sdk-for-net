# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DataBox
namespace: Azure.ResourceManager.DataBox
require: https://github.com/Azure/azure-rest-api-specs/blob/df70965d3a207eb2a628c96aa6ed935edc6b7911/specification/databox/resource-manager/readme.md
tag: package-2022-02
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  'storageLocation': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*AccountId': 'arm-id'

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

prepend-rp-prefix:
  - CopyStatus
rename-mapping:
  JobResource: DataBoxJob
  JobResourceUpdateParameter: DataBoxJobPatch
  JobResourceList: DataBoxJobListResult
  CreateJobValidations: CreateJobValidationContent
  CreateOrderLimitForSubscriptionValidationRequest: CreateOrderLimitForSubscriptionValidationContent
  CreateOrderLimitForSubscriptionValidationResponseProperties: CreateOrderLimitForSubscriptionValidationResult
  DataTransferDetailsValidationResponseProperties: DataTransferDetailsValidationResult
  PreferencesValidationResponseProperties: PreferencesValidationResult
  SkuAvailabilityValidationResponseProperties: SkuAvailabilityValidationResult
  SubscriptionIsAllowedToCreateJobValidationResponseProperties: SubscriptionIsAllowedToCreateJobValidationResult
  AddressValidationProperties: AddressValidationResult
  ValidationInputResponse: ValidationInputResult
  DataBoxCustomerDiskJobDetails.deliverToDcPackageDetails: DeliverToDataCenterPackageDetails
  DataBoxCustomerDiskJobDetails.exportDiskDetailsCollection: ExportDiskDetails
  DataBoxCustomerDiskJobDetails.importDiskDetailsCollection: ImportDiskDetails
  DataBoxDiskJobSecrets.passKey: Passkey
  DataBoxScheduleAvailabilityRequest: DataBoxScheduleAvailabilityContent
  DiskScheduleAvailabilityRequest: DiskScheduleAvailabilityContent
  HeavyScheduleAvailabilityRequest: HeavyScheduleAvailabilityContent
  ScheduleAvailabilityRequest: ScheduleAvailabilityContent
  DataBoxSkuInformation.properties.enabled: IsEnabled
  DatacenterAddressInstructionResponse: DataCenterAddressInstructionResult
  DatacenterAddressLocationResponse: DataCenterAddressLocationResult
  DatacenterAddressResponse: DataCenterAddressResult
  DatacenterAddressRequest: DataCenterAddressContent

override-operation-name:
  Service_ListAvailableSkusByResourceGroup: GetAvailableSkus
  Service_RegionConfigurationByResourceGroup: GetRegionConfiguration
  Service_RegionConfiguration: GetRegionConfiguration
  Service_ValidateAddress: ValidateAddress
  Service_ValidateInputs: ValidateInputs
  Service_ValidateInputsByResourceGroup: ValidateInputs
```
