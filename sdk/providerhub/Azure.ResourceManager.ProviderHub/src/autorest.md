# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: ProviderHub
namespace: Azure.ResourceManager.ProviderHub
require: https://github.com/Azure/azure-rest-api-specs/blob/34ba022add0034e30462b76e1548ce5a7e053e33/specification/providerhub/resource-manager/readme.md
tag: package-2020-11-20
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

# mgmt-debug: 
#  show-serialized-names: true

rename-mapping:
  ResourceTypeSku: ResourceTypeSkuProperties
  SkuResource: ResourceTypeSku
  CheckinManifestParams: CheckinManifestContent
  CustomRolloutArrayResponseWithContinuation: CustomRolloutListResult
  DefaultRolloutArrayResponseWithContinuation: DefaultRolloutListResult
  ExtensionCategory: ResourceTypeExtensionCategory
  LoggingHiddenPropertyPath: LoggingHiddenPropertyPaths
  NotificationRegistrationArrayResponseWithContinuation: NotificationRegistrationListResult
  ProviderRegistrationArrayResponseWithContinuation: ProviderRegistrationListResult
  Regionality: ResourceTypeRegistrationRegionality
  ResourceType: ProviderResourceType
  ResourceTypeRegistrationArrayResponseWithContinuation: ResourceTypeRegistrationListResult
  RoutingType: ResourceRoutingType
  SkuCapability: ResourceSkuCapability
  SkuCapacity: ResourceTypeSkuCapacity
  SkuCost: ResourceTypeSkuCost
  SkuLocationInfo: ResourceTypeSkuLocationInfo
  SkuScaleType: ResourceTypeSkuScaleType
  SkuSetting: ResourceTypeSkuSetting
  SkuZoneDetail: ResourceTypeSkuZoneDetail
  SkuResourceArrayResponseWithContinuation: ResourceTypeSkuListResult
  SubscriptionState: ProviderSubscriptionState
  SubscriptionStateRule: ProviderSubscriptionStateRule
  CanaryTrafficRegionRolloutConfiguration.skipRegions: -|azure-location
  CanaryTrafficRegionRolloutConfiguration.regions: -|azure-location
  CheckinManifestParams.baselineArmManifestLocation: -|azure-location
  CheckNameAvailabilitySpecifications.enableDefaultValidation: IsDefaultValidationEnabled
  CustomRolloutStatus.completedRegions: -|azure-location
  NotificationEndpoint.notificationDestination: -|arm-id
  NotificationEndpoint.locations: -|azure-location
  TrafficRegions.regions: -|azure-location
  ReRegisterSubscriptionMetadata.enabled: IsEnabled
  ResourceProviderEndpoint.enabled: IsEnabled
  ResourceProviderEndpoint.locations: -|azure-location
  ResourceTypeEndpoint.enabled: IsEnabled
  ResourceTypeEndpoint.locations: -|azure-location
  RolloutStatusBase.completedRegions: -|azure-location
  ResourceMovePolicy.validationRequired: IsValidationRequired
  ResourceMovePolicy.crossResourceGroupMoveEnabled: IsCrossResourceGroupMoveEnabled
  ResourceMovePolicy.crossSubscriptionMoveEnabled: IsCrossSubscriptionMoveEnabled
  ResourceTypeRegistrationProperties.enableAsyncOperation: IsAsyncOperationEnabled
  ResourceTypeRegistrationProperties.enableThirdPartyS2S: IsThirdPartyS2SEnabled
  TemplateDeploymentOptions.preflightSupported: IsPreflightSupported
  SkuLocationInfo.type: ExtendedLocationType

prepend-rp-prefix:
  - ExtendedLocationOptions
  - ExtendedLocationType
  - ProvisioningState

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
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
  TTL: Ttl

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/skus/{sku}: ResourceTypeSku
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/resourcetypeRegistrations/{nestedResourceTypeFirst}/skus/{sku}: NestedResourceTypeFirstSku
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/resourcetypeRegistrations/{nestedResourceTypeFirst}/resourcetypeRegistrations/{nestedResourceTypeSecond}/skus/{sku}: NestedResourceTypeSecondSku
  /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/resourcetypeRegistrations/{resourceType}/resourcetypeRegistrations/{nestedResourceTypeFirst}/resourcetypeRegistrations/{nestedResourceTypeSecond}/resourcetypeRegistrations/{nestedResourceTypeThird}/skus/{sku}: NestedResourceTypeThirdSku

directive:
  - remove-operation: Operations_List
  - remove-operation: Operations_ListByProviderRegistration
  - remove-operation: Operations_CreateOrUpdate
  - remove-operation: ProviderRegistrations_GenerateOperations
  # It generates a new model if the property is `allOf`, that will cause dup model error.
  # So the normal solution is changing `allOf` to `$ref`.
  - from: providerhub.json
    where: $.definitions
    transform: >
      delete $.CustomRollout.properties.properties['allOf'];
      $.CustomRollout.properties.properties['$ref'] = '#/definitions/CustomRolloutProperties';
      delete $.ProviderRegistration.properties.properties['allOf'];
      $.ProviderRegistration.properties.properties['$ref'] = '#/definitions/ProviderRegistrationProperties';
      delete $.ResourceTypeRegistration.properties.properties['allOf'];
      $.ResourceTypeRegistration.properties.properties['$ref'] = '#/definitions/ResourceTypeRegistrationProperties';
      delete $.DefaultRollout.properties.properties['allOf'];
      $.DefaultRollout.properties.properties['$ref'] = '#/definitions/DefaultRolloutProperties';
      delete $.NotificationRegistration.properties.properties['allOf'];
      $.NotificationRegistration.properties.properties['$ref'] = '#/definitions/NotificationRegistrationProperties';
      delete $.SkuResource.properties.properties['allOf'];
      $.SkuResource.properties.properties['$ref'] = '#/definitions/ResourceTypeSku';
      delete $.CustomRolloutSpecification.properties.canary['allOf'];
      $.CustomRolloutSpecification.properties.canary['$ref'] = '#/definitions/TrafficRegions';
      delete $.CustomRolloutSpecification.properties.providerRegistration['allOf'];
      $.CustomRolloutSpecification.properties.providerRegistration['$ref'] = '#/definitions/ProviderRegistration';
      delete $.CustomRolloutProperties.properties.specification['allOf'];
      $.CustomRolloutProperties.properties.specification['$ref'] = '#/definitions/CustomRolloutSpecification';
      delete $.CustomRolloutProperties.properties.status['allOf'];
      $.CustomRolloutProperties.properties.status['$ref'] = '#/definitions/CustomRolloutStatus';
      delete $.DefaultRolloutProperties.properties.specification['allOf'];
      $.DefaultRolloutProperties.properties.specification['$ref'] = '#/definitions/DefaultRolloutSpecification';
      delete $.DefaultRolloutProperties.properties.status['allOf'];
      $.DefaultRolloutProperties.properties.status['$ref'] = '#/definitions/DefaultRolloutStatus';
      delete $.DefaultRolloutSpecification.properties.canary['allOf'];
      $.DefaultRolloutSpecification.properties.canary['$ref'] = '#/definitions/CanaryTrafficRegionRolloutConfiguration';
      delete $.DefaultRolloutSpecification.properties.lowTraffic['allOf'];
      $.DefaultRolloutSpecification.properties.lowTraffic['$ref'] = '#/definitions/TrafficRegionRolloutConfiguration';
      delete $.DefaultRolloutSpecification.properties.mediumTraffic['allOf'];
      $.DefaultRolloutSpecification.properties.mediumTraffic['$ref'] = '#/definitions/TrafficRegionRolloutConfiguration';
      delete $.DefaultRolloutSpecification.properties.highTraffic['allOf'];
      $.DefaultRolloutSpecification.properties.highTraffic['$ref'] = '#/definitions/TrafficRegionRolloutConfiguration';
      delete $.DefaultRolloutSpecification.properties.restOfTheWorldGroupOne['allOf'];
      $.DefaultRolloutSpecification.properties.restOfTheWorldGroupOne['$ref'] = '#/definitions/TrafficRegionRolloutConfiguration';
      delete $.DefaultRolloutSpecification.properties.restOfTheWorldGroupTwo['allOf'];
      $.DefaultRolloutSpecification.properties.restOfTheWorldGroupTwo['$ref'] = '#/definitions/TrafficRegionRolloutConfiguration';
      delete $.DefaultRolloutSpecification.properties.providerRegistration['allOf'];
      $.DefaultRolloutSpecification.properties.providerRegistration['$ref'] = '#/definitions/ProviderRegistration';
      delete $.ResourceTypeExtensionOptions.properties.resourceCreationBegin['allOf'];
      $.ResourceTypeExtensionOptions.properties.resourceCreationBegin['$ref'] = '#/definitions/ExtensionOptions';
      delete $.LoggingRule.properties.hiddenPropertyPaths['allOf'];
      $.LoggingRule.properties.hiddenPropertyPaths['$ref'] = '#/definitions/LoggingHiddenPropertyPath';
      delete $.ProviderHubMetadata.properties.providerAuthentication['allOf'];
      $.ProviderHubMetadata.properties.providerAuthentication['$ref'] = '#/definitions/ResourceProviderAuthentication';
      delete $.ProviderHubMetadata.properties.thirdPartyProviderAuthorization['allOf'];
      $.ProviderHubMetadata.properties.thirdPartyProviderAuthorization['$ref'] = '#/definitions/ThirdPartyProviderAuthorization';
      delete $.ProviderRegistrationProperties.properties.providerHubMetadata['allOf'];
      $.ProviderRegistrationProperties.properties.providerHubMetadata['$ref'] = '#/definitions/ProviderHubMetadata';
      delete $.ProviderRegistrationProperties.properties.subscriptionLifecycleNotificationSpecifications['allOf'];
      $.ProviderRegistrationProperties.properties.subscriptionLifecycleNotificationSpecifications['$ref'] = '#/definitions/SubscriptionLifecycleNotificationSpecifications';
      delete $.ResourceProviderEndpoint.properties.featuresRule['allOf'];
      $.ResourceProviderEndpoint.properties.featuresRule['$ref'] = '#/definitions/FeaturesRule';
      delete $.ResourceProviderManifest.properties.providerAuthentication['allOf'];
      $.ResourceProviderManifest.properties.providerAuthentication['$ref'] = '#/definitions/ResourceProviderAuthentication';
      delete $.ResourceProviderManifest.properties.featuresRule['allOf'];
      $.ResourceProviderManifest.properties.featuresRule['$ref'] = '#/definitions/FeaturesRule';
      delete $.ResourceProviderManifest.properties.requestHeaderOptions['allOf'];
      $.ResourceProviderManifest.properties.requestHeaderOptions['$ref'] = '#/definitions/RequestHeaderOptions';
      delete $.ResourceProviderManifest.properties.management['allOf'];
      $.ResourceProviderManifest.properties.management['$ref'] = '#/definitions/ResourceProviderManagement';
      delete $.ResourceProviderManifest.properties.reRegisterSubscriptionMetadata['allOf'];
      $.ResourceProviderManifest.properties.reRegisterSubscriptionMetadata['$ref'] = '#/definitions/ReRegisterSubscriptionMetadata';
      delete $.ResourceProviderManifestProperties.properties.providerAuthentication['allOf'];
      $.ResourceProviderManifestProperties.properties.providerAuthentication['$ref'] = '#/definitions/ResourceProviderAuthentication';
      delete $.ResourceProviderManifestProperties.properties.featuresRule['allOf'];
      $.ResourceProviderManifestProperties.properties.featuresRule['$ref'] = '#/definitions/FeaturesRule';
      delete $.ResourceProviderManifestProperties.properties.requestHeaderOptions['allOf'];
      $.ResourceProviderManifestProperties.properties.requestHeaderOptions['$ref'] = '#/definitions/RequestHeaderOptions';
      delete $.ResourceProviderManifestProperties.properties.management['allOf'];
      $.ResourceProviderManifestProperties.properties.management['$ref'] = '#/definitions/ResourceProviderManagement';
      delete $.ResourceProviderManifestProperties.properties.templateDeploymentOptions['allOf'];
      $.ResourceProviderManifestProperties.properties.templateDeploymentOptions['$ref'] = '#/definitions/TemplateDeploymentOptions';
      delete $.ResourceType.properties.identityManagement['allOf'];
      $.ResourceType.properties.identityManagement['$ref'] = '#/definitions/IdentityManagement';
      delete $.ResourceType.properties.featuresRule['allOf'];
      $.ResourceType.properties.featuresRule['$ref'] = '#/definitions/FeaturesRule';
      delete $.ResourceType.properties.requestHeaderOptions['allOf'];
      $.ResourceType.properties.requestHeaderOptions['$ref'] = '#/definitions/RequestHeaderOptions';
      delete $.ResourceType.properties.templateDeploymentPolicy['allOf'];
      $.ResourceType.properties.templateDeploymentPolicy['$ref'] = '#/definitions/TemplateDeploymentPolicy';
      delete $.ResourceTypeEndpoint.properties.featuresRule['allOf'];
      $.ResourceTypeEndpoint.properties.featuresRule['$ref'] = '#/definitions/FeaturesRule';
      delete $.ResourceTypeRegistrationProperties.properties.extensionOptions['allOf'];
      $.ResourceTypeRegistrationProperties.properties.extensionOptions['$ref'] = '#/definitions/ResourceTypeExtensionOptions';
      delete $.ResourceTypeRegistrationProperties.properties.featuresRule['allOf'];
      $.ResourceTypeRegistrationProperties.properties.featuresRule['$ref'] = '#/definitions/FeaturesRule';
      delete $.ResourceTypeRegistrationProperties.properties.subscriptionLifecycleNotificationSpecifications['allOf'];
      $.ResourceTypeRegistrationProperties.properties.subscriptionLifecycleNotificationSpecifications['$ref'] = '#/definitions/SubscriptionLifecycleNotificationSpecifications';
      delete $.ResourceTypeRegistrationProperties.properties.identityManagement['allOf'];
      $.ResourceTypeRegistrationProperties.properties.identityManagement['$ref'] = '#/definitions/IdentityManagementProperties';
      delete $.ResourceTypeRegistrationProperties.properties.checkNameAvailabilitySpecifications['allOf'];
      $.ResourceTypeRegistrationProperties.properties.checkNameAvailabilitySpecifications['$ref'] = '#/definitions/CheckNameAvailabilitySpecifications';
      delete $.ResourceTypeRegistrationProperties.properties.requestHeaderOptions['allOf'];
      $.ResourceTypeRegistrationProperties.properties.requestHeaderOptions['$ref'] = '#/definitions/RequestHeaderOptions';
      delete $.ResourceTypeRegistrationProperties.properties.templateDeploymentOptions['allOf'];
      $.ResourceTypeRegistrationProperties.properties.templateDeploymentOptions['$ref'] = '#/definitions/TemplateDeploymentOptions';
      delete $.ResourceTypeRegistrationProperties.properties.resourceMovePolicy['allOf'];
      $.ResourceTypeRegistrationProperties.properties.resourceMovePolicy['$ref'] = '#/definitions/ResourceMovePolicy';
      delete $.SkuSetting.properties.capacity['allOf'];
      $.SkuSetting.properties.capacity['$ref'] = '#/definitions/SkuCapacity';

```
