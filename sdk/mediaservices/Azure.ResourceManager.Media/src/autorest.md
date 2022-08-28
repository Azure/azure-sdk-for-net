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
  /subscriptions/{subscriptionId}/providers/Microsoft.Media/locations/{locationName}/mediaServicesOperationResults/{operationId}: MediaServicesOperationResult
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/tracks/{trackName}/operationResults/{operationId}: MediaAssetTrackOperationResult
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaservices/{accountName}: MediaServicesAccount
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Media/mediaServices/{accountName}/assets/{assetName}/tracks/{trackName}: MediaAssetTrack

override-operation-name:
  StreamingEndpoints_Skus: GetSupportedSkus
  StreamingLocators_ListPaths: GetSupportedPaths
  Locations_CheckNameAvailability: CheckMediaNameAvailability
  Assets_ListContainerSas: GetStorageContainerUris
  
format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
  '*UriTemplate': 'Uri'
  'ResponseCustomData': 'any'
  'locationName': 'azure-location'

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
  AacAudioProfile.HeAacV1: HEAacV1
  AacAudioProfile.HeAacV2: HEAacV2
  AccessControl: MediaAccessControl
  KeyDelivery: MediaKeyDelivery
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
  Job.properties.startTime: StartsOn
  Job.properties.endTime: EndsOn
  Priority: TransformOutputsPriority
  LiveEvent.properties.created: CreatedOn
  LiveEvent.properties.lastModified: LastModifiedOn
  LiveOutput.properties.created: CreatedOn
  LiveOutput.properties.lastModified: LastModifiedOn
  PublicNetworkAccess: MediaPublicNetworkAccessStatus
  StorageAccount: MediaServicesStorageAccount
  StorageAccount.id: -|arm-id
  StreamingEndpoint.properties.cdnEnabled: IsCdnEnabled
  StreamingEndpoint.properties.created: CreatedOn
  StreamingEndpoint.properties.lastModified: LastModifiedOn
  StreamingEndpoint.properties.scaleUnits: ScaleUnitsNumber
  StreamingLocator.properties.created: CreatedOn
  StreamingLocator.properties.startTime: StartsOn
  StreamingLocator.properties.endTime: EndsOn
  StreamingPolicy.properties.created: CreatedOn
  Transform: MediaTransform
  Transform.properties.created: CreatedOn
  Transform.properties.lastModified: LastModifiedOn
  CheckNameAvailabilityInput: MediaNameAvailabilityContent
  EntityNameAvailabilityCheckOutput: MediaNameAvailabilityResult
  EntityNameAvailabilityCheckOutput.nameAvailable: IsNameAvailable
  AssetStreamingLocator.created: CreatedOn
  AssetStreamingLocator.startTime: StartsOn
  AssetStreamingLocator.endTime: EndsOn
  Codec: CodecBasicProperties
  Audio: AudioCommonProperties
  Overlay: OverlayBasicProperties
  Complexity: EncoderComplexitySetting
  ContentKeyPolicyPlayReadyLicense.expirationDate: ExpiresOn
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
  Layer: VideoOrImageLayerProperties
  ListContainerSasInput: GetContainerSasContent
  ListContainerSasInput.expiryTime: ExpiresOn
  ListEdgePoliciesInput: GetEdgePoliciesContent
  Preset: MediaPreset
  StorageAccountType: MediaServicesStorageAccountType
  Visibility: PlayerVisibility
  AssetCollection: AssetListResult
  AccountFilterCollection: AccountFilterListResult
  AssetFilterCollection: AssetFilterListResult
  AssetTrackCollection: AssetTrackListResult
  ContentKeyPolicyCollection: ContentKeyPolicyListResult
  JobCollection: MediaTransformJobListResult
  MediaServiceCollection: MediaServicesAccountListResult
  StreamingLocatorCollection: StreamingLocatorListResult
  StreamingPolicyCollection: StreamingPolicyListResult
  TransformCollection: TransformListResult
  StorageEncryptedAssetDecryptionData: StorageEncryptedAssetDecryptionInfo
  AssetTrack: MediaAssetTrack
  TrackBase: AssetTrackInfo
  PrivateEndpointConnection: MediaServicesPrivateEndpointConnection
  PrivateLinkResource: MediaServicesPrivateLinkResource
  ListPathsResponse: GetPathsResult
  AkamaiSignatureHeaderAuthenticationKey.expiration: ExpiresOn
  ContentKeyPolicyFairPlayOfflineRentalConfiguration.playbackDurationSeconds: PlaybackDurationInSeconds
  ContentKeyPolicyFairPlayOfflineRentalConfiguration.storageDurationSeconds: StorageDurationInSeconds
  ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction.bestEffort: IsBestEffort
  EnabledProtocols: MediaEnabledProtocols
  EnabledProtocols.download: IsDownloadEnabled
  EnabledProtocols.dash: IsDashEnabled
  EnabledProtocols.hls: IsHttpLiveStreamingEnabled
  EnabledProtocols.smoothStreaming: IsSmoothStreamingEnabled
  LiveOutput.properties.hls: HttpLiveStreaming
  StorageAuthentication: MediaStorageAuthentication
  ArmStreamingEndpointCapacity: StreamingEndpointCapacity
  ArmStreamingEndpointCurrentSku: StreamingEndpointCurrentSku
  ArmStreamingEndpointSku: StreamingEndpointSku
  ArmStreamingEndpointSkuInfo: StreamingEndpointSkuInfo
  DefaultAction: IPAccessControlDefaultAction
  AssetTrackOperationStatus.startTime: StartsOn
  AssetTrackOperationStatus.endTime: EndsOn
  ContentKeyPolicyFairPlayConfiguration.ask: FairPlayApplicationSecretKey
  ContentKeyPolicyPlayReadyPlayRight.uncompressedDigitalVideoOpl: UncompressedDigitalVideoOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.uncompressedDigitalAudioOpl: UncompressedDigitalAudioOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.compressedDigitalVideoOpl: CompressedDigitalVideoOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.compressedDigitalAudioOpl: CompressedDigitalAudioOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.analogVideoOpl: AnalogVideoOutputProtectionLevel
  DefaultKey: EncryptionSchemeDefaultKey
  EncryptionScheme: StreamingPathEncryptionScheme
  EntropyMode: LayerEntropyMode
  EntropyMode.Cabac: ContextAdaptiveBinaryArithmeticCoder
  EntropyMode.Cavlc: ContextAdaptiveVariableLengthCoder
  TrackSelection: MediaTrackSelection
  TransformOutput: MediaTransformOutput
  H264Layer.crf: ConstantRateFactor
  ImageFormat: OutputImageFileFormat
  InputDefinition: MediaTransformJobInputDefinition
  InputFile: MediaTransformJobInputFile
  IPRange.address: -|ip-address
  JobOutput: MediaTransformJobOutput
  JobOutput.startTime: StartsOn
  JobOutput.endTime: EndsOn
  JobOutputAsset: MediaTransformJobOutputAsset
  JobError: MediaTransformJobError
  JobErrorCode: MediaTransformJobErrorCode
  JobErrorCategory: MediaTransformJobErrorCategory
  JobRetry: MediaTransformJobRetry
  JobErrorDetail: MediaTransformJobErrorDetail
  JobInput: MediaTransformJobInputBasicProperties
  JobInputAsset: MediaTransformJobInputAsset
  JobInputClip: MediaTransformJobInputClip
  JobInputHttp: MediaTransformJobInputHttp
  JobInputs: MediaTransformJobInputs
  JobInputSequence: MediaTransformJobInputSequence
  MediaService: MediaServicesAccount
  MediaService.properties.mediaServiceId: MediaServicesAccountId
  MediaServiceOperationStatus.id: -|arm-id
  MediaServiceOperationStatus.startTime: StartsOn
  MediaServiceOperationStatus.endTime: EndsOn
  MediaServiceOperationStatus: MediaServicesOperationStatus
  OnErrorType: MediaTransformOutputErrorAction
  OutputFile: MultiBitrateOutputFile
  PresetConfigurations: EncoderPresetConfigurations
  StreamingEndpointAccessControl.ip: IPs
  IPAccessControl.allow: AllowedIPs
  StretchMode: InputVideoStretchMode
  TrackPropertyType.FourCC: FourCharacterCode
  FilterTrackPropertyType.FourCC: FourCharacterCode
  AssetTrackOperationStatus.id: -|arm-id
  ContentKeyPolicyPlayReadyPlayRight.digitalVideoOnlyContentRestriction: HasDigitalVideoOnlyContentRestriction
  ContentKeyPolicyPlayReadyPlayRight.imageConstraintForAnalogComponentVideoRestriction: HasImageConstraintForAnalogComponentVideoRestriction
  ContentKeyPolicyPlayReadyPlayRight.imageConstraintForAnalogComputerMonitorRestriction: HasImageConstraintForAnalogComputerMonitorRestriction
  H264Video.sceneChangeDetection: UseSceneChangeDetection
  H265Video.sceneChangeDetection: UseSceneChangeDetection
  H265VideoLayer.adaptiveBFrame: UseAdaptiveBFrame
  HlsSettings.default: IsDefault
  HlsSettings.forced: IsForced
  VideoLayer.adaptiveBFrame: UseAdaptiveBFrame
  
directive:
  - from: Accounts.json
    where: $.definitions
    transform: >
      $.EdgeUsageDataCollectionPolicy.properties.maxAllowedUnreportedUsageDuration['format'] = 'duration';
      $.AccessControl.properties.ipAllowList.items['x-ms-format'] = 'ip-address';
  - from: streamingservice.json
    where: $.definitions
    transform: >
      $.LiveEventInput.properties.keyFrameIntervalDuration["format"] = 'duration';
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
  # Service team is on the path to fast deprecate this feature in 12 months, so remove it
  - from: Encoding.json
    where: $.definitions
    transform: >
      delete $.FaceDetectorPreset;
  - from: streamingservice.json
    where: $.definitions
    transform: >
      $.StreamingEndpointProperties.properties.maxCacheAge["x-nullable"] = true;
      $.StreamingEndpointProperties.properties.crossSiteAccessPolicies["x-nullable"] = true;
      $.StreamingEndpointProperties.properties.accessControl["x-nullable"] = true;
      $.LiveEventEncoding.properties.stretchMode["x-nullable"] = true;
      $.LiveEventEncoding.properties.keyFrameInterval["x-nullable"] = true;
      $.LiveEventPreview.properties.accessControl["x-nullable"] = true;
      $.LiveEventInput.properties.accessControl["x-nullable"] = true;
```
