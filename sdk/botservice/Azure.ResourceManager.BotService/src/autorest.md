# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: BotService
namespace: Azure.ResourceManager.BotService
# default tag is now a stable version
require: https://github.com/Azure/azure-rest-api-specs/blob/8468620c009664ed91a3148c04cf77b6c8eb7b6f/specification/botservice/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../samples/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

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
  SKU: Sku

override-operation-name:
  Bots_GetCheckNameAvailability: CheckBotServiceNameAvailability
  Email_CreateSignInUrl: CreateEmailSignInUri
  HostSettings_Get: GetBotServiceHostSettings
  Channels_ListWithKeys: GetChannelWithKeys
  QnAMakerEndpointKeys_Get: GetBotServiceQnAMakerEndpointKey
  BotConnection_ListServiceProviders: GetBotConnectionServiceProviders
  DirectLine_RegenerateKeys: GetBotChannelWithRegenerateKeys

rename-mapping:
  ConnectionSetting: BotConnectionSetting
  AlexaChannelProperties.urlFragment: UriFragment
  BotProperties.endpoint: -|uri
  BotProperties.msaAppMSIResourceId: -|arm-id
  BotProperties.disableLocalAuth: IsLocalAuthDisabled
  BotProperties.storageResourceId: -|arm-id
  PrivateLinkResource: BotServicePrivateLinkResourceData
  Channel: BotChannelProperties
  ChannelName: BotChannelName
  ChannelSettings: BotChannelSettings
  CheckNameAvailabilityRequestBody: BotServiceNameAvailabilityContent
  CheckNameAvailabilityRequestBody.type: ResourceType|resource-type
  CheckNameAvailabilityResponseBody: BotServiceNameAvailabilityResult
  CheckNameAvailabilityResponseBody.valid: IsValid
  ConnectionSettingParameter: BotConnectionSettingParameter
  ConnectionSettingProperties: BotConnectionSettingProperties
  CreateEmailSignInUrlResponse: BotCreateEmailSignInUriResult
  CreateEmailSignInUrlResponse.id: -|arm-id
  Site: BotChannelSite
  HostSettingsResponse: BotServiceHostSettingsResult
  Key: BotServiceKey
  ListChannelWithKeysResponse: BotChannelGetWithKeysResult
  MsaAppType: BotMsaAppType
  MsTeamsChannelProperties.enableCalling: IsCallingEnabled
  PublicNetworkAccess: BotServicePublicNetworkAccess
  QnAMakerEndpointKeysRequestBody: GetBotServiceQnAMakerEndpointKeyContent
  QnAMakerEndpointKeysResponse: GetBotServiceQnAMakerEndpointKeyResult
  RegenerateKeysChannelName: RegenerateKeysBotChannelName
  ServiceProvider: BotServiceProvider
  ServiceProviderParameter: BotServiceProviderParameter
  ServiceProviderProperties: BotServiceProviderProperties
  SiteInfo: BotChannelRegenerateKeysContent
  SkypeChannelProperties.enableMessaging: IsMessagingEnabled
  SkypeChannelProperties.enableMediaCards: IsMediaCardsEnabled
  SkypeChannelProperties.enableVideo: IsVideoEnabled
  SkypeChannelProperties.enableCalling: IsCallingEnabled
  SkypeChannelProperties.enableScreenSharing: IsScreenSharingEnabled
  SkypeChannelProperties.enableGroups: IsGroupsEnabled
  ServiceProviderParameterMetadataConstraints.required: IsRequired
  DirectLineSpeechChannelProperties.cognitiveServiceResourceId: -|arm-id
  TelephonyChannelResourceApiConfiguration.cognitiveServiceResourceId: -|arm-id
  TelephonyPhoneNumbers.acsResourceId: -|arm-id
  TelephonyPhoneNumbers.cognitiveServiceResourceId: -|arm-id

directive:
  - remove-operation: OperationResults_Get # remove this because this is a LRO related operations, we should not expose it.
  - from: botservice.json
    where: $.paths..parameters[?(@.name=='channelName')]
    transform: >
      $ = {
            "$ref": "#/parameters/channelNameParameter"
          };
  - from: botservice.json
    where: $.definitions
    transform: >
      $.EmailChannelAuthMethod['type'] = 'integer';
  - from: botservice.json
    where: $.parameters
    transform: >
      $.channelNameParameter['x-ms-enum']['modelAsString'] = true;

```
