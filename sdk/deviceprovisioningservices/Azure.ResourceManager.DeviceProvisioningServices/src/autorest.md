# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: DeviceProvisioningServices
namespace: Azure.ResourceManager.DeviceProvisioningServices
require: https://github.com/Azure/azure-rest-api-specs/blob/df70965d3a207eb2a628c96aa6ed935edc6b7911/specification/deviceprovisioningservices/resource-manager/readme.md
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

override-operation-name:
  IotDpsResource_ListKeysForKeyName: GetKey
  IotDpsResource_CheckProvisioningServiceNameAvailability: CheckDeviceProvisioningServicesNameAvailability

rename-mapping:
  CertificateResponse: DeviceProvisioningServicesCertificate
  CertificateProperties: DeviceProvisioningServicesCertificateProperties
  CertificateProperties.expiry: ExpireOn
  CertificateProperties.created: CreatedOn
  CertificateProperties.updated: UpdatedOn
  VerificationCodeResponse: CertificateVerificationCodeResult
  VerificationCodeResponse.properties.expiry: ExpireOn
  VerificationCodeResponse.properties.created: CreatedOn
  VerificationCodeResponse.properties.updated: UpdatedOn
  VerificationCodeResponseProperties: CertificateVerificationCodeProperties
  VerificationCodeRequest: CertificateVerificationCodeContent
  PrivateEndpointConnectionProperties: DeviceProvisioningServicesPrivateEndpointConnectionProperties
  GroupIdInformation: DeviceProvisioningServicesPrivateLinkResource
  GroupIdInformationProperties: DeviceProvisioningServicesPrivateLinkResourceProperties
  ProvisioningServiceDescription: DeviceProvisioningService
  IotDpsPropertiesDescription: DeviceProvisioningServiceProperties
  IotDpsPropertiesDescription.enableDataResidency: IsDataResidencyEnabled
  IotDpsSkuInfo: DeviceProvisioningServicesSkuInfo
  IotDpsSku: DeviceProvisioningServicesSku
  IotDpsSkuDefinition: DeviceProvisioningServicesSkuDefinition
  SharedAccessSignatureAuthorizationRule[AccessRightsDescription]: DeviceProvisioningServicesSharedAccessKey
  OperationInputs: DeviceProvisioningServicesNameAvailabilityContent
  NameAvailabilityInfo: DeviceProvisioningServicesNameAvailabilityResult
  NameUnavailabilityReason: DeviceProvisioningServicesNameUnavailableReason
  AccessRightsDescription: DeviceProvisioningServicesAccessKeyRight
  AllocationPolicy: DeviceProvisioningServicesAllocationPolicy
  PrivateLinkServiceConnectionStatus: DeviceProvisioningServicesPrivateLinkServiceConnectionStatus
  IpFilterRule: DeviceProvisioningServicesIPFilterRule
  IpFilterActionType: DeviceProvisioningServicesIPFilterActionType
  IpFilterTargetType: DeviceProvisioningServicesIPFilterTargetType
  PublicNetworkAccess: DeviceProvisioningServicesPublicNetworkAccess
  State: DeviceProvisioningServicesState

directive:
  - from: iotdps.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}'].delete.parameters
    transform: >
      $[5].name = 'certificateCommonName';
      $[9].name = 'certificateCreatedOn';
      $[10].name = 'certificateLastUpdatedOn';
  - from: iotdps.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/generateVerificationCode'].post.parameters
    transform: >
      $[5].name = 'certificateCommonName';
      $[9].name = 'certificateCreatedOn';
      $[10].name = 'certificateLastUpdatedOn';
  - from: iotdps.json
    where: $.paths['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Devices/provisioningServices/{provisioningServiceName}/certificates/{certificateName}/verify'].post.parameters
    transform: >
      $[6].name = 'certificateCommonName';
      $[10].name = 'certificateCreatedOn';
      $[11].name = 'certificateLastUpdatedOn';
  - remove-operation: IotDpsResource_GetOperationResult

```
