# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: EdgeOrder
namespace: Azure.ResourceManager.EdgeOrder
require: https://github.com/Azure/azure-rest-api-specs/blob/58891380ba22c3565ca884dee3831445f638b545/specification/edgeorder/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

list-exception:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EdgeOrder/locations/{location}/orders/{orderName}

format-by-name-rules:
  'tenantId': 'uuid'
  'etag': 'etag'
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
  Rp: RP

override-operation-name:
  CancelOrderItem: Cancel
  ReturnOrderItem: Return

rename-mapping:
  AddressResource: EdgeOrderAddress
  AddressValidationStatus: EdgeOrderAddressValidationStatus
  ContactDetails: EdgeOrderAddressContactDetails
  ShippingAddress: EdgeOrderShippingAddress
  OrderItemResource: EdgeOrderItem
  OrderItemResource.properties.orderId: -|arm-id
  CancellationReason: EdgeOrderItemCancellationReason
  ReturnOrderItemDetails: EdgeOrderItemReturnContent
  ReturnOrderItemDetails.shippingBoxRequired: IsShippingBoxRequired
  AddressDetails: EdgeOrderItemAddressDetails
  AddressProperties: EdgeOrderItemAddressProperties
  OrderItemDetails: EdgeOrderItemDetails
  OrderItemDetails.managementRpDetails: FirstOrDefaultManagement
  OrderResource: EdgeOrder
  OrderResource.properties.orderItemIds: -|arm-id
  StageDetails: EdgeOrderStageDetails
  StageName: EdgeOrderStageName
  StageStatus: EdgeOrderStageStatus
  ProductFamiliesMetadata: ProductFamiliesMetadataListResult
  ProductFamiliesMetadataDetails: ProductFamiliesMetadata
  ActionStatusEnum: EdgeOrderActionStatus
  AddressType: EdgeOrderAddressType
  AvailabilityInformation: ProductAvailabilityInformation
  AvailabilityStage: ProductAvailabilityStage
  AvailabilityStage.Signup: SignUp
  DisabledReason: ProductDisabledReason
  DescriptionType: ProductDescriptionType
  DisplayInfo: ProductDisplayInfo
  NotificationPreference.sendNotification: IsNotificationRequired
  OrderItemCancellationEnum: OrderItemCancellationStatus
  OrderItemReturnEnum: OrderItemReturnStatus
  Pav2MeterDetails.meterGuid: -|uuid
  WeightMeasurementUnit.LBS: Lbs
  WeightMeasurementUnit.KGS: Kgs
  CostInformation: EdgeOrderProductCostInformation
  BillingMeterDetails: EdgeOrderProductBillingMeterDetails
  MeterDetails: EdgeOrderProductMeterDetails
  MeteringType: EdgeOrderProductMeteringType
  ChargingType: EdgeOrderProductChargingType
  DeviceDetails: EdgeOrderProductDeviceDetails
  ImageInformation: EdgeOrderProductImageInformation
  ImageType: EdgeOrderProductImageType
  LengthHeightUnit: ProductLengthHeightWidthUnit
  WeightMeasurementUnit: ProductWeightMeasurementUnit
  LinkType: ProductLinkType

directive:
  - remove-operation: ListOperations
  - rename-model:
      from: Configuration
      to: ProductConfiguration
  - rename-model:
      from: Configurations
      to: ProductConfigurations
  - rename-model:
      from: Description
      to: ProductDescription
  - rename-model:
      from: Dimensions
      to: ProductDimensions
  - rename-model:
      from: Link
      to: ProductLink
  - rename-model:
      from: Preferences
      to: OrderItemPreferences
  - rename-model:
      from: Product
      to: EdgeOrderProduct
  - rename-model:
      from: Specification
      to: ProductSpecification

```
