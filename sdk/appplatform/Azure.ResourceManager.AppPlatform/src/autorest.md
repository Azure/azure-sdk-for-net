# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: AppPlatform
namespace: Azure.ResourceManager.AppPlatform
require: /mnt/vss/_work/1/s/azure-rest-api-specs/specification/appplatform/resource-manager/readme.md
tag: package-preview-2022-03
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

format-by-name-rules:
  'etag': 'etag'
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
  JFR: Jfr
  TLS: Tls
  APM: Apm
  NETCore: NetCore
  Url: Uri
  Urls: Uris

override-operation-name:
  Services_CheckNameAvailability: CheckServiceNameAvailability

prepend-rp-prefix:
- ResourceSkuCapabilities
- ResourceSkuZoneDetails
- ResourceSkuRestrictionsReasonCode
- ResourceSkuRestrictionsType

rename-mapping:
  Type: UnderlyingResourceType
  DiagnosticParameters.duration: DurationValue
  DeploymentResource: AppDeploymentResource
  Build: AppBuild
  BuildProperties: AppBuildProperties
  BuildProvisioningState: AppBuildProvisioningState
  BuildResult: AppBuildResult
  BuildService: AppBuildService
  BuildServiceAgentPoolResource: AppBuildServiceAgentPoolResource
  BuilderResource: AppBuilderResource
  BuilderProperties: AppBuilderProperties
  BuilderProvisioningState: AppBuilderProvisioningState
  NameAvailabilityParameters: ServiceNameAvailabilityParameters
  NameAvailability: ServiceNameAvailabilityResult
  GatewayRouteConfigResourceCollection: GatewayRouteConfigResourceList
  GatewayCustomDomainResourceCollection: GatewayCustomDomainResourceList
  ApiPortalResourceCollection: ApiPortalResourceList
  ApiPortalCustomDomainResourceCollection: ApiPortalCustomDomainResourceList
  BuildServiceCollection: AppBuildServiceList
  BuildCollection: AppBuildList
  BuildResultCollection: AppBuildResultList
  BuilderResourceCollection: AppBuilderResourceList
  SupportedBuildpacksCollection: SupportedBuildpacksList
  SupportedStacksCollection: SupportedStacksList
  BuildServiceAgentPoolResourceCollection: BuildServiceAgentPoolResourceList
  ConfigurationServiceResourceCollection: ConfigurationServiceResourceList
  ServiceRegistryResourceCollection: ServiceRegistryResourceList
  LoadedCertificateCollection: LoadedCertificateList
  AppResourceCollection: AppResourceList
  ActiveDeploymentCollection: ActiveDeploymentList
  BindingResourceCollection: BindingResourceList
  CertificateResourceCollection: CertificateResourceList
  StorageResourceCollection: StorageResourceList
  CustomPersistentDiskCollection: CustomPersistentDiskList
  CustomDomainResourceCollection: CustomDomainResourceList
  DeploymentResourceCollection: DeploymentResourceList
  AvailableOperations: AvailableOperationsInfo
  ResourceSkuCollection: ResourceSkuList
  BuildpackBindingResourceCollection: BuildpackBindingResourceList
  GatewayResourceCollection: GatewayResourceList
  ResourceSku: AvailableAppPlatformSku
  CustomDomainResource: AppPlatformCustomDomainResource
  ServiceResource: AppPlatformServiceResource
  AppResource: AppPlatformAppResource
  ResourceUploadDefinition: ResourceUploadResult
  DiagnosticParameters: DiagnosticContent
  LogFileUrlResponse: LogFileUriResult
  CustomPersistentDiskResource: CustomPersistentDiskData
  Error: AppPlatformErrorInfo

directive:
  - from: swagger-document
    where: $.definitions..location
    transform: >
      $['x-ms-format'] = 'azure-location';
  - from: swagger-document
    where: $.definitions..resourceType
    transform: >
      $['x-ms-format'] = 'resource-type';
  - from: swagger-document
    where: $.paths..parameters[?(@.name === 'location')]
    transform: >
      $['x-ms-format'] = 'azure-location';
  - from: swagger-document
    where: $.definitions
    transform: >
      $.LoadedCertificate.properties.resourceId['x-ms-format'] = 'arm-id';
      $.BindingResourceProperties.properties.resourceId['x-ms-format'] = 'arm-id';
      $.NetworkProfile.properties.serviceRuntimeSubnetId['x-ms-format'] = 'arm-id';
      $.NetworkProfile.properties.appSubnetId['x-ms-format'] = 'arm-id';
      $.ResourceSku.properties.locations.items['x-ms-format'] = 'azure-location';
      $.ResourceSkuRestrictionInfo.properties.locations.items['x-ms-format'] = 'azure-location';
```
