# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
generate-model-factory: false
csharp: true
library-name: BotService
namespace: Azure.ResourceManager.BotService
# default tag is a preview version
require: https://github.com/Azure/azure-rest-api-specs/blob/af1be2677e619e483210064ff658e62ec25053aa/specification/botservice/resource-manager/readme.md
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
  Bots_GetCheckNameAvailability: CheckBotServiceNameAvailability
  Email_CreateSignInUrl: CreateEmailSignInUri
  HostSettings_Get: GetBotServiceHostSettings
  Channels_ListWithKeys: GetChannelWithKeys
  QnAMakerEndpointKeys_Get: GetBotServiceQnAMakerEndpointKey
  BotConnection_ListServiceProviders: GetBotConnectionServiceProviders
  DirectLine_RegenerateKeys: RegenerateKeys

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
