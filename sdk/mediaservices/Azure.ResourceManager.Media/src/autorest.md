# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Media
namespace: Azure.ResourceManager.Media
require: https://github.com/Azure/azure-rest-api-specs/blob/daeb320057bd56a88379c377d934150ef48d143f/specification/mediaservices/resource-manager/readme.md
tag: package-2023-01
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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
  AccountFilter: MediaServicesAccountFilter
  AccountFilterCollection: MediaServicesAccountFilterListResult
  AkamaiSignatureHeaderAuthenticationKey.expiration: ExpireOn
  ArmStreamingEndpointCapacity: StreamingEndpointCapacity
  ArmStreamingEndpointCurrentSku: StreamingEndpointCurrentSku
  ArmStreamingEndpointSku: StreamingEndpointSku
  ArmStreamingEndpointSkuInfo: StreamingEndpointSkuInfo
  Asset: MediaAsset
  Asset.properties.created: CreatedOn
  Asset.properties.lastModified: LastModifiedOn
  AssetFilter: MediaAssetFilter
  AssetCollection: MediaAssetListResult
  AssetContainerPermission: MediaAssetContainerPermission
  AssetFileEncryptionMetadata: MediaAssetFileEncryptionMetadata
  AssetFilterCollection: MediaAssetFilterListResult
  AssetStorageEncryptionFormat: MediaAssetStorageEncryptionFormat
  AssetStreamingLocator: MediaAssetStreamingLocator
  AssetStreamingLocator.created: CreatedOn
  AssetStreamingLocator.startTime: StartOn
  AssetStreamingLocator.endTime: EndOn
  AssetTrack: MediaAssetTrack
  AssetTrackCollection: MediaAssetTrackListResult
  AttributeFilter: TrackAttributeFilter
  Audio: MediaAudioBase
  CheckNameAvailabilityInput: MediaServicesNameAvailabilityContent
  Codec: MediaCodecBase
  Complexity: EncodingComplexity
  ContentKeyPolicy.properties.created: CreatedOn
  ContentKeyPolicy.properties.lastModified: LastModifiedOn
  ContentKeyPolicyCollection: ContentKeyPolicyListResult
  ContentKeyPolicyFairPlayConfiguration.ask: ApplicationSecretKey
  ContentKeyPolicyFairPlayOfflineRentalConfiguration.playbackDurationSeconds: PlaybackDurationInSeconds
  ContentKeyPolicyFairPlayOfflineRentalConfiguration.storageDurationSeconds: StorageDurationInSeconds
  ContentKeyPolicyPlayReadyExplicitAnalogTelevisionRestriction.bestEffort: IsBestEffort
  ContentKeyPolicyPlayReadyLicense.expirationDate: ExpireOn
  ContentKeyPolicyPlayReadyPlayRight.analogVideoOpl: AnalogVideoOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.compressedDigitalVideoOpl: CompressedDigitalVideoOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.compressedDigitalAudioOpl: CompressedDigitalAudioOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.digitalVideoOnlyContentRestriction: HasDigitalVideoOnlyContentRestriction
  ContentKeyPolicyPlayReadyPlayRight.imageConstraintForAnalogComponentVideoRestriction: HasImageConstraintForAnalogComponentVideoRestriction
  ContentKeyPolicyPlayReadyPlayRight.imageConstraintForAnalogComputerMonitorRestriction: HasImageConstraintForAnalogComputerMonitorRestriction
  ContentKeyPolicyPlayReadyPlayRight.uncompressedDigitalVideoOpl: UncompressedDigitalVideoOutputProtectionLevel
  ContentKeyPolicyPlayReadyPlayRight.uncompressedDigitalAudioOpl: UncompressedDigitalAudioOutputProtectionLevel
  ContentKeyPolicyProperties.created: CreatedOn
  ContentKeyPolicyProperties.lastModified: LastModifiedOn
  CopyAudio: CodecCopyAudio
  CopyVideo: CodecCopyVideo
  DashSettings: TrackDashSettings
  DefaultAction: IPAccessControlDefaultAction
  DefaultKey: EncryptionSchemeDefaultKey
  Deinterlace: DeinterlaceSettings
  EdgePolicies: MediaServicesEdgePolicies
  EnabledProtocols: MediaEnabledProtocols
  EnabledProtocols.download: IsDownloadEnabled
  EnabledProtocols.dash: IsDashEnabled
  EnabledProtocols.hls: IsHlsEnabled
  EnabledProtocols.smoothStreaming: IsSmoothStreamingEnabled
  EncryptionScheme: StreamingPathEncryptionScheme
  EntropyMode: LayerEntropyMode
  EntityNameAvailabilityCheckOutput: MediaServicesNameAvailabilityResult
  EntityNameAvailabilityCheckOutput.nameAvailable: IsNameAvailable
  Fade: FadeOptions
  Filters: FilteringOperations
  Format: MediaFormatBase
  GetEdgePoliciesContent: EdgePoliciesRequestContent
  H264Layer.crf: ConstantRateFactor
  H264Video.sceneChangeDetection: UseSceneChangeDetection
  H265Video.sceneChangeDetection: UseSceneChangeDetection
  H265VideoLayer.adaptiveBFrame: UseAdaptiveBFrame
  HlsSettings.default: IsDefault
  HlsSettings.forced: IsForced
  Image: MediaImageBase
  ImageFormat: OutputImageFileFormat
  InputDefinition: MediaJobInputDefinition
  InputFile: MediaJobInputFile
  IPAccessControl.allow: AllowedIPs
  IPRange.address: -|ip-address
  Job: MediaJob
  Job.properties.created: CreatedOn
  Job.properties.lastModified: LastModifiedOn
  Job.properties.startTime: StartOn
  Job.properties.endTime: EndOn
  JobCollection: MediaJobListResult
  JobError: MediaJobError
  JobErrorCode: MediaJobErrorCode
  JobErrorCategory: MediaJobErrorCategory
  JobErrorDetail: MediaJobErrorDetail
  JobInput: MediaJobInputBasicProperties
  JobInputAsset: MediaJobInputAsset
  JobInputClip: MediaJobInputClip
  JobInputHttp: MediaJobInputHttp
  JobInputSequence: MediaJobInputSequence
  JobInputs: MediaJobInputs
  JobOutput: MediaJobOutput
  JobOutput.startTime: StartOn
  JobOutput.endTime: EndOn
  JobOutputAsset: MediaJobOutputAsset
  JobRetry: MediaJobRetry
  JobState: MediaJobState
  KeyDelivery: MediaKeyDelivery
  Layer: MediaLayerBase
  ListContainerSasInput: MediaAssetStorageContainerSasContent
  ListContainerSasInput.expiryTime: ExpireOn
  ListEdgePoliciesInput: EdgePoliciesRequestContent
  LiveEvent.properties.created: CreatedOn
  LiveEvent.properties.lastModified: LastModifiedOn
  LiveEvent: MediaLiveEvent
  LiveOutput: MediaLiveOutput
  LiveOutput.properties.created: CreatedOn
  LiveOutput.properties.lastModified: LastModifiedOn
  ListPathsResponse: StreamingPathsResult
  MediaService: MediaServicesAccount
  MediaService.properties.mediaServiceId: MediaServicesAccountId
  MediaServiceCollection: MediaServicesAccountListResult
  OnErrorType: MediaTransformOnErrorType
  OutputFile: MediaOutputFile
  Overlay: MediaOverlayBase
  Preset: MediaTransformPreset
  PresetConfigurations: EncoderPresetConfigurations
  Priority: MediaJobPriority
  PrivateEndpointConnection: MediaServicesPrivateEndpointConnection
  PrivateLinkResource: MediaServicesPrivateLinkResource
  ProvisioningState: MediaServicesProvisioningState
  PublicNetworkAccess: MediaServicesPublicNetworkAccess
  Rectangle: RectangularWindow
  Rotation: RotationSetting
  SecurityLevel: PlayReadySecurityLevel
  StorageAccount: MediaServicesStorageAccount
  StorageAccount.id: -|arm-id
  StorageAccountType: MediaServicesStorageAccountType
  StorageAuthentication: MediaStorageAuthentication
  StorageEncryptedAssetDecryptionData: StorageEncryptedAssetDecryptionInfo
  StreamingEndpoint.properties.cdnEnabled: IsCdnEnabled
  StreamingEndpoint.properties.created: CreatedOn
  StreamingEndpoint.properties.lastModified: LastModifiedOn
  StreamingEndpointAccessControl.ip: IPs
  StreamingLocator.properties.created: CreatedOn
  StreamingLocator.properties.startTime: StartOn
  StreamingLocator.properties.endTime: EndOn
  StreamingLocatorCollection: StreamingLocatorListResult
  StreamingPolicy.properties.created: CreatedOn
  StreamingPolicyCollection: StreamingPolicyListResult
  StretchMode: InputVideoStretchMode
  TrackBase: MediaAssetTrackBase
  TrackSelection: MediaTrackSelection
  Transform: MediaTransform
  Transform.properties.created: CreatedOn
  Transform.properties.lastModified: LastModifiedOn
  TransformCollection: MediaTransformListResult
  TransformOutput: MediaTransformOutput
  Video: MediaVideoBase
  VideoLayer.adaptiveBFrame: UseAdaptiveBFrame
  Visibility: PlayerVisibility
  MinimumTlsVersion: MediaServicesMinimumTlsVersion

directive:
  - remove-operation: OperationResults_Get
  - remove-operation: OperationStatuses_Get
  - remove-operation: MediaServicesOperationStatuses_Get
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
