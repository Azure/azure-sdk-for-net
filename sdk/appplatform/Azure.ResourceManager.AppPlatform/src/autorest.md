# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: AppPlatform
namespace: Azure.ResourceManager.AppPlatform
require: https://github.com/Azure/azure-rest-api-specs/blob/688cfd36391115f70ea9276a8e526caea6a5c8ad/specification/appplatform/resource-manager/readme.md
output-folder: $(this-folder)/Generated
tag: package-preview-2022-03
clear-output-folder: true
skip-csproj: true
flatten-payloads: false

rename-rules:
  CPU: Cpu
  CPUs: Cpus
  Os: OS
  Ip: IP
  Ips: IPs
  ID: Id
  IDs: Ids
  VM: Vm
  VMs: Vms
  VMScaleSet: VmScaleSet
  DNS: Dns
  VPN: Vpn
  NAT: Nat
  WAN: Wan
  Ipv4: IPv4
  Ipv6: IPv6
  Ipsec: IPsec
  SSO: Sso
  URI: Uri
  JFR: Jfr
  TLS: Tls
  APM: Apm
  NETCore: NetCore
  Url: Uri
  Urls: Uris
override-operation-name:
  Services_CheckNameAvailability: CheckServiceNameAvailability

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
      $.CustomPersistentDiskProperties.properties.type['x-ms-enum']['name'] = 'UnderlyingResourceType';
      $.DiagnosticParameters.properties.duration['x-ms-client-name'] = 'DurationValue';
      $.DeploymentResource['x-ms-client-name'] = 'AppDeploymentResource';
      $.Build['x-ms-client-name'] = 'AppBuild';
      $.BuildProperties['x-ms-client-name'] = 'AppBuildProperties';
      $.BuildProperties.properties.provisioningState['x-ms-enum']['name'] = 'AppBuildProvisioningState';
      $.BuildResult['x-ms-client-name'] = 'AppBuildResult';
      $.BuildService['x-ms-client-name'] = 'AppBuildService';
      $.BuildServiceAgentPoolResource['x-ms-client-name'] = 'AppBuildBuildServiceAgentPoolResource';
      $.BuilderResource['x-ms-client-name'] = 'AppBuilderResource';
      $.BuilderProperties['x-ms-client-name'] = 'AppBuilderProperties';
      $.BuilderProperties.properties.provisioningState['x-ms-enum']['name'] = 'AppBuilderProvisioningState';
      $.LoadedCertificate.properties.resourceId['x-ms-format'] = 'arm-id';
      $.BindingResourceProperties.properties.resourceId['x-ms-format'] = 'arm-id';
      $.NetworkProfile.properties.serviceRuntimeSubnetId['x-ms-format'] = 'arm-id';
      $.NetworkProfile.properties.appSubnetId['x-ms-format'] = 'arm-id';
      $.NameAvailabilityParameters['x-ms-client-name'] = 'ServiceNameAvailabilityParameters';
      $.NameAvailability['x-ms-client-name'] = 'ServiceNameAvailabilityResult';
      $.GatewayRouteConfigResourceCollection['x-ms-client-name'] = 'GatewayRouteConfigResourceList';
      $.GatewayCustomDomainResourceCollection['x-ms-client-name'] = 'GatewayCustomDomainResourceList';
      $.ApiPortalResourceCollection['x-ms-client-name'] = 'ApiPortalResourceList';
      $.ApiPortalCustomDomainResourceCollection['x-ms-client-name'] = 'ApiPortalCustomDomainResourceList';
      $.BuildServiceCollection['x-ms-client-name'] = 'AppBuildServiceList';
      $.BuildCollection['x-ms-client-name'] = 'AppBuildList';
      $.BuildResultCollection['x-ms-client-name'] = 'AppBuildResultList';
      $.BuilderResourceCollection['x-ms-client-name'] = 'AppBuilderResourceList';
      $.SupportedBuildpacksCollection['x-ms-client-name'] = 'SupportedBuildpacksList';
      $.SupportedStacksCollection['x-ms-client-name'] = 'SupportedStacksList';
      $.BuildServiceAgentPoolResourceCollection['x-ms-client-name'] = 'BuildServiceAgentPoolResourceList';
      $.ConfigurationServiceResourceCollection['x-ms-client-name'] = 'ConfigurationServiceResourceList';
      $.ServiceRegistryResourceCollection['x-ms-client-name'] = 'ServiceRegistryResourceList';
      $.LoadedCertificateCollection['x-ms-client-name'] = 'LoadedCertificateList';
      $.AppResourceCollection['x-ms-client-name'] = 'AppResourceList';
      $.ActiveDeploymentCollection['x-ms-client-name'] = 'ActiveDeploymentList';
      $.BindingResourceCollection['x-ms-client-name'] = 'BindingResourceList';
      $.CertificateResourceCollection['x-ms-client-name'] = 'CertificateResourceList';
      $.StorageResourceCollection['x-ms-client-name'] = 'StorageResourceList';
      $.CustomPersistentDiskCollection['x-ms-client-name'] = 'CustomPersistentDiskList';
      $.CustomDomainResourceCollection['x-ms-client-name'] = 'CustomDomainResourceList';
      $.DeploymentResourceCollection['x-ms-client-name'] = 'DeploymentResourceList';
      $.AvailableOperations['x-ms-client-name'] = 'AvailableOperationsInfo';
      $.ResourceSkuCollection['x-ms-client-name'] = 'ResourceSkuList';
      $.BuildpackBindingResourceCollection['x-ms-client-name'] = 'BuildpackBindingResourceList';
      $.GatewayResourceCollection['x-ms-client-name'] = 'GatewayResourceList';
      $.ResourceSku.properties.locations.items['x-ms-format'] = 'azure-location';
      $.ResourceSku['x-ms-client-name'] = 'AvailableAppPlatformSku';
      $.ResourceSkuRestrictionInfo.properties.locations.items['x-ms-format'] = 'azure-location';
      $.CustomDomainResource['x-ms-client-name'] = 'AppPlatformCustomDomainResource';
      $.ServiceResource['x-ms-client-name'] = 'AppPlatformServiceResource';
      $.AppResource['x-ms-client-name'] = 'AppPlatformAppResource';
      $.ResourceUploadDefinition['x-ms-client-name'] = 'ResourceUploadResult';
      $.DiagnosticParameters['x-ms-client-name'] = 'DiagnosticContent';
      $.LogFileUrlResponse['x-ms-client-name'] = 'LogFileUriResult';
      $.CustomPersistentDiskResource['x-ms-client-name'] = 'CustomPersistentDiskData';
      $.Error['x-ms-client-name'] = 'AppPlatformErrorInfo';
```