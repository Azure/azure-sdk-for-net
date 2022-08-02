# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Media
namespace: Azure.ResourceManager.Media
require: https://github.com/Azure/azure-rest-api-specs/blob/0f9df940977c680c39938c8b8bd5baf893737ed0/specification/mediaservices/resource-manager/readme.md
tag: package-account-2021-11
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.Media/locations/{locationName}/mediaServicesOperationResults/{operationId}: MediaServiceOperationResult
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/tracks/{trackName}/operationResults/{operationId}: MediaAssetTrackOperationResult
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaservices/{accountName}: MediaService
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/tracks/{trackName}: MediaAssetTrack

override-operation-name:
  StreamingEndpoints_Skus: GetSupportedSkus
  StreamingLocators_ListPaths: GetSupportedPaths
  Locations_CheckNameAvailability: CheckMediaNameAvailability
  
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
  Url: Uri
  Urls: Uris
  AAC: Aac
  ABR: Abr
  CBR: Cbr
  CRF: Crf
  MP4: Mp4

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.Media/locations/{locationName}/mediaServicesOperationResults/{operationId}
- /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/tracks/{trackName}/operationResults/{operationId}

rename-mapping:
  Asset: MediaAsset
  Asset.properties.created: CreatedOn
  Asset.properties.lastModified: LastModifiedOn
  ProvisioningState: MediaProvisioningState
  ContentKeyPolicy.properties.created: CreatedOn
  ContentKeyPolicy.properties.lastModified: LastModifiedOn
  ContentKeyPolicy.properties.options: Preferences
  ContentKeyPolicyOption: ContentKeyPolicyPreference
  Job: MediaTransformJob
  Job.properties.created: CreatedOn
  Job.properties.lastModified: LastModifiedOn
  Priority: TransformOutputsPriority
  LiveEvent.properties.created: CreatedOn
  LiveEvent.properties.lastModified: LastModifiedOn
  LiveOutput.properties.created: CreatedOn
  LiveOutput.properties.lastModified: LastModifiedOn
  PublicNetworkAccess: IsMediaServicePublicNetworkAccessEnabled
  StorageAccount: MediaServiceStorageAccount
  StreamingEndpoint.properties.cdnEnabled: IsCdnEnabled
  StreamingEndpoint.properties.created: CreatedOn
  StreamingEndpoint.properties.lastModified: LastModifiedOn
  StreamingLocator.properties.created: CreatedOn
  StreamingPolicy.properties.created: CreatedOn
  Transform: MediaTransform
  Transform.properties.created: CreatedOn
  Transform.properties.lastModified: LastModifiedOn
  CheckNameAvailabilityInput: MediaNameAvailabilityContent
  EntityNameAvailabilityCheckOutput: MediaNameAvailabilityResult
  EntityNameAvailabilityCheckOutput.nameAvailable: IsNameAvailable
  AssetStreamingLocator.created: CreatedOn
  Codec: CodecBasicProperties
  Audio: AudioCommonProperties
  Overlay: OverlayBasicProperties
  Complexity: EncoderComplexitySetting
  ContentKeyPolicyPlayReadyLicense.expirationDate: ExpireOn
  ContentKeyPolicyPlayReadyUnknownOutputPassingOption: ContentKeyPolicyPlayReadyUnknownOutputPassingSetting
  ContentKeyPolicyProperties.created: CreatedOn
  ContentKeyPolicyProperties.lastModified: LastModifiedOn
  ContentKeyPolicyProperties.options: Preferences
  Filters: FilteringOperations
  Rectangle: RectangularWindowProperties
  Deinterlace: DeinterlaceSettings
  Rotation: RotationSetting
  Format: FormatBasicProperties
  Image: ImageBasicProperties
  Video: InputVideoEncodingProperties
  Layer: LayerProperties
  ListContainerSasInput: GetContainerSasContent
  ListContainerSasInput.expiryTime: ExpireOn
  ListEdgePoliciesInput: GetEdgePoliciesContent
  Preset: MediaPreset
  StorageAccountType: MediaServiceStorageAccountType
  Visibility: PlayerVisibility
  AssetCollection: AssetListResult
  AccountFilterCollection: AccountFilterListResult
  AssetFilterCollection: AssetFilterListResult
  AssetTrackCollection: AssetTrackListResult
  ContentKeyPolicyCollection: ContentKeyPolicyListResult
  JobCollection: JobListResult
  MediaServiceCollection: MediaServiceListResult
  StreamingLocatorCollection: StreamingLocatorListResult
  StreamingPolicyCollection: StreamingPolicyListResult
  TransformCollection: TransformListResult
  StorageEncryptedAssetDecryptionData: StorageEncryptedAssetDecryptionInfo
  AssetTrack: MediaAssetTrack
  TrackBase: AssetTrackInfo
  PrivateLinkResource: MediaPrivateLink
  ListPathsResponse: GetPathsResult
  AkamaiSignatureHeaderAuthenticationKey.expiration: ExpireOn
  ContentKeyPolicyFairPlayOfflineRentalConfiguration.playbackDurationSeconds: PlaybackDurationInSeconds
  ContentKeyPolicyFairPlayOfflineRentalConfiguration.storageDurationSeconds: StorageDurationInSeconds
  
directive:
  - from: Accounts.json
    where: $.definitions
    transform: >
      $.EdgeUsageDataCollectionPolicy.properties.maxAllowedUnreportedUsageDuration['format'] = 'duration';
  - from: streamingservice.json
    where: $.definitions
    transform: >
      $.LiveEventInput.properties.keyFrameIntervalDuration['format'] = 'duration';
      $.ArmStreamingEndpointSkuInfo.properties.resourceType['x-ms-format'] = 'resource-type';
  - from: Encoding.json
    where: $.definitions
    transform: >
      $.Overlay.properties.fadeInDuration['format'] = 'duration';
      $.Overlay.properties.fadeOutDuration['format'] = 'duration';
  - from: AssetsAndAssetFilters.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/listContainerSas'].post['x-ms-pageable'] = {
          "itemName": "assetContainerSasUrls",
          "nextLinkName": null
        };
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/listStreamingLocators'].post['x-ms-pageable'] = {
          "itemName": "streamingLocators",
          "nextLinkName": null
        };
  - from: StreamingPoliciesAndStreamingLocators.json
    where: $.paths
    transform: >
      $['/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/streamingLocators/{streamingLocatorName}/listContentKeys'].post['x-ms-pageable'] = {
          "itemName": "contentKeys",
          "nextLinkName": null
        };
```
