# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Media
namespace: Azure.ResourceManager.Media
require: https://github.com/Azure/azure-rest-api-specs/blob/aefbcc5fb18a3b33f401394ebeae01df0733c830/specification/mediaservices/resource-manager/readme.md
tag: package-metadata-2022-08
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
  StreamingLocators_ListPaths: GetStreamingPaths
  Locations_CheckNameAvailability: CheckMediaServicesNameAvailability
  Assets_ListContainerSas: GetStorageContainerUris
  
format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'
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

rename-mapping:
  AacAudioProfile.HeAacV1: HEAacV1
  AacAudioProfile.HeAacV2: HEAacV2
  AccessControl: MediaAccessControl
  KeyDelivery: MediaKeyDelivery
  Asset: MediaAsset
  AssetFilter: MediaAssetFilter
  Asset.properties.created: CreatedOn
  Asset.properties.lastModified: LastModifiedOn
  ProvisioningState: MediaProvisioningState
  ContentKeyPolicy.properties.created: CreatedOn
  ContentKeyPolicy.properties.lastModified: LastModifiedOn
  ContentKeyPolicy.properties.options: Option
  Job: MediaJob
  Job.properties.created: CreatedOn
  Job.properties.lastModified: LastModifiedOn
  Job.properties.startTime: StartsOn
  Job.properties.endTime: EndsOn
  Priority: JobPriority
  LiveEvent.properties.created: CreatedOn
  LiveEvent.properties.lastModified: LastModifiedOn
  LiveOutput.properties.created: CreatedOn
  LiveOutput.properties.lastModified: LastModifiedOn
  PublicNetworkAccess: MediaPublicNetworkAccess
  StorageAccount: MediaServicesStorageAccount
  StorageAccount.id: -|arm-id
  StreamingEndpoint.properties.cdnEnabled: IsCdnEnabled
  StreamingEndpoint.properties.created: CreatedOn
  StreamingEndpoint.properties.lastModified: LastModifiedOn
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
  Codec: CodecBase
  Audio: AudioBase
  Overlay: OverlayBase
  Complexity: EncodingComplexity
  ContentKeyPolicyPlayReadyLicense.expirationDate: ExpiresOn
  ContentKeyPolicyProperties.created: CreatedOn
  ContentKeyPolicyProperties.lastModified: LastModifiedOn
  Filters: FilteringOperations 
  Rectangle: RectangularWindowProperties  # can be a single word class. self explanatory
  Deinterlace: DeinterlaceSettings
  Rotation: RotationSetting
  Format: FormatBase
  Image: ImageBase
  Video: VideoBase
  Layer: LayerBase
  ListContainerSasInput: GetStorageContainerUriContent
  ListContainerSasInput.expiryTime: ExpiresOn
  ListEdgePoliciesInput: GetEdgePoliciesContent
  Preset: MediaTransformPreset
  StorageAccountType: MediaServicesStorageAccountType
  Visibility: PlayerVisibility
  AssetCollection: MediaAssetListResult
  AccountFilterCollection: AccountFilterListResult
  AssetFilterCollection: MediaAssetFilterListResult
  AssetTrackCollection: AssetTrackListResult
  ContentKeyPolicyCollection: ContentKeyPolicyListResult
  JobCollection: MediaJobListResult
  MediaServiceCollection: MediaServicesAccountListResult
  StreamingLocatorCollection: StreamingLocatorListResult
  StreamingPolicyCollection: StreamingPolicyListResult
  TransformCollection: MediaTransformListResult
  StorageEncryptedAssetDecryptionData: StorageEncryptedAssetDecryptionInfo
  AssetTrack: MediaAssetTrack
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
  EnabledProtocols.hls: IsHls
  EnabledProtocols.smoothStreaming: IsSmoothStreamingEnabled
  LiveOutput.properties.hls: Hls  # can you double check this one.
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
  DefaultKey: EncryptionSchemeDefaultKey  #?? 
  EncryptionScheme: StreamingPathEncryptionScheme
  EntropyMode: LayerEntropyMode
  TrackSelection: MediaTrackSelection
  TransformOutput: MediaTransformOutput
  H264Layer.crf: ConstantRateFactor
  ImageFormat: OutputImageFileFormat
  InputDefinition: MediaJobInputDefinition
  InputFile: MediaJobInputFile
  IPRange.address: -|ip-address
  JobOutput: MediaJobOutput
  JobOutput.startTime: StartsOn
  JobOutput.endTime: EndsOn
  JobOutputAsset: MediaJobOutputAsset
  JobError: MediaJobError
  JobErrorCode: MediaJobErrorCode
  JobErrorCategory: MediaJobErrorCategory
  JobRetry: MediaJobRetry
  JobErrorDetail: MediaJobErrorDetail
  JobInput: MediaJobInputBasicProperties
  JobInputAsset: MediaJobInputAsset
  JobInputClip: MediaJobInputClip
  JobInputHttp: MediaJobInputHttp
  JobInputs: MediaJobInputs
  JobInputSequence: MediaJobInputSequence
  MediaService: MediaServicesAccount
  MediaService.properties.mediaServiceId: MediaServicesAccountId
  MediaServiceOperationStatus.id: -|arm-id
  MediaServiceOperationStatus.startTime: StartsOn
  MediaServiceOperationStatus.endTime: EndsOn
  MediaServiceOperationStatus: MediaServicesOperationStatus
  OnErrorType: MediaTransformOutputErrorType  # can you check if we can remove this rename?
  OutputFile: MultiBitrateOutputFile  # may be Roy should now better.
  PresetConfigurations: EncoderPresetConfigurations
  StreamingEndpointAccessControl.ip: IPs
  IPAccessControl.allow: AllowedIPs
  StretchMode: InputVideoStretchMode
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
  SecurityLevel: PlayReadySecurityLevel
  
directive:
  - remove-operation: OperationResults_Get
  - remove-operation: MediaServicesOperationResults_Get
  - remove-operation: StreamingEndpoints_OperationLocation
  - remove-operation: LiveOutputs_OperationLocation
  - remove-operation: LiveEvents_OperationLocation
  - remove-operation: LiveEvents_AsyncOperation
  - remove-operation: LiveOutputs_AsyncOperation
  - remove-operation: StreamingEndpoints_AsyncOperation
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
      $.LiveOutputProperties.properties.rewindWindowLength["x-nullable"] = true;
```
