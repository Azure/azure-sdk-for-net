# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: EventGrid
namespace: Azure.ResourceManager.EventGrid
require: https://github.com/Azure/azure-rest-api-specs/blob/79c3ab8586bd78947815ebf39b66584f67095c2f/specification/eventgrid/resource-manager/readme.md
#tag: package-2025-04-preview
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - Topics_ListEventTypes # because we use customized code to rewrite this operation
  - EventSubscriptions_ListGlobalBySubscriptionForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListGlobalByResourceGroupForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalByResourceGroupForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalBySubscriptionForTopicType # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalByResourceGroup # because we use customized code to rewrite this operation
  - EventSubscriptions_ListRegionalBySubscription # because we use customized code to rewrite this operation
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}|Microsoft.EventGrid/topics/privateEndpointConnections: EventGridTopicPrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}|Microsoft.EventGrid/domains/privateEndpointConnections: EventGridDomainPrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateEndpointConnections/{privateEndpointConnectionName}|Microsoft.EventGrid/partnerNamespaces/privateEndpointConnections: EventGridPartnerNamespacePrivateEndpointConnection
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateLinkResources/{privateLinkResourceName}|Microsoft.EventGrid/topics/privateLinkResources: EventGridTopicPrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateLinkResources/{privateLinkResourceName}|Microsoft.EventGrid/domains/privateLinkResources: EventGridDomainPrivateLinkResource
  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}/privateLinkResources/{privateLinkResourceName}|Microsoft.EventGrid/partnerNamespaces/privateLinkResources: PartnerNamespacePrivateLinkResource

override-operation-name:
  EventSubscriptions_ListGlobalByResourceGroupForTopicType: GetGlobalEventSubscriptionsDataForTopicType
  EventSubscriptions_ListRegionalByResourceGroup: GetRegionalEventSubscriptionsData
  EventSubscriptions_ListRegionalByResourceGroupForTopicType: GetRegionalEventSubscriptionsDataForTopicType
  EventSubscriptions_ListGlobalBySubscriptionForTopicType: GetGlobalEventSubscriptionsDataForTopicType
  EventSubscriptions_ListRegionalBySubscription: GetRegionalEventSubscriptionsData
  EventSubscriptions_ListRegionalBySubscriptionForTopicType: GetRegionalEventSubscriptionsDataForTopicType
  Topics_ListEventTypes: GetEventTypes

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
  Url: Uri

rename-mapping:
  Channel: PartnerNamespaceChannel
  Channel.properties.expirationTimeIfNotActivatedUtc: ExpireOnIfNotActivated
  ChannelUpdateParameters.properties.expirationTimeIfNotActivatedUtc: ExpireOnIfNotActivated
  ChannelType: PartnerNamespaceChannelType
  ChannelProvisioningState: PartnerNamespaceChannelProvisioningState
  ReadinessState: PartnerTopicReadinessState
  Domain: EventGridDomain
  Domain.properties.disableLocalAuth: IsLocalAuthDisabled
  Domain.properties.endpoint: Endpoint|Uri
  DomainUpdateParameters.properties.disableLocalAuth: IsLocalAuthDisabled
  EventSubscription: EventGridSubscription
  EventSubscriptionUpdateParameters: EventGridSubscriptionPatch
  EventSubscriptionUpdateParameters.expirationTimeUtc: ExpireOn
  DomainRegenerateKeyRequest: EventGridDomainRegenerateKeyContent
  ConnectionState: EventGridPrivateEndpointConnectionState
  PersistedConnectionStatus: EventGridPrivateEndpointPersistedConnectionStatus
  EventSubscription.properties.expirationTimeUtc: ExpireOn
  RetryPolicy: EventSubscriptionRetryPolicy
  InboundIpRule: EventGridInboundIPRule
  IpActionType: EventGridIPActionType
  InputSchema: EventGridInputSchema
  InputSchemaMapping: EventGridInputSchemaMapping
  JsonInputSchemaMapping: EventGridJsonInputSchemaMapping
  DomainProvisioningState: EventGridDomainProvisioningState
  PublicNetworkAccess: EventGridPublicNetworkAccess
  DomainSharedAccessKeys: EventGridDomainSharedAccessKeys
  ResourceProvisioningState: EventGridResourceProvisioningState
  Partner: EventGridPartnerContent
  Partner.authorizationExpirationTimeInUtc: AuthorizationExpireOn
  PartnerNamespace.properties.disableLocalAuth: IsLocalAuthDisabled
  PartnerNamespace.properties.endpoint: Endpoint|Uri
  PartnerNamespace.properties.partnerRegistrationFullyQualifiedId: -|arm-id
  PartnerTopic.properties.expirationTimeIfNotActivatedUtc: ExpireOnIfNotActivated
  SystemTopic.properties.source: -|arm-id
  SystemTopic.properties.metricResourceId: -|uuid
  Topic: EventGridTopic
  TopicRegenerateKeyRequest: TopicRegenerateKeyContent
  Subscription: NamespaceTopicEventSubscription
  Client: EventGridNamespaceClient
  ClientGroup: EventGridNamespaceClientGroup
  Namespace: EventGridNamespace
  PermissionBinding: EventGridNamespacePermissionBinding
  ClientProvisioningState: EventGridNamespaceClientProvisioningState
  ClientState: EventGridNamespaceClientState
  Filter: EventGridFilter
  Topic.properties.disableLocalAuth: IsLocalAuthDisabled
  Topic.properties.endpoint: Endpoint|Uri
  TopicUpdateParameters.properties.disableLocalAuth: IsLocalAuthDisabled
  TopicProvisioningState: EventGridTopicProvisioningState
  TopicTypeInfo: TopicType
  ResourceRegionType: EventGridResourceRegionType
  EventTypeInfo: PartnerTopicEventTypeInfo
  EventHubEventSubscriptionDestination.properties.resourceId: -|arm-id
  AzureFunctionEventSubscriptionDestination.properties.resourceId: -|arm-id
  HybridConnectionEventSubscriptionDestination.properties.resourceId: -|arm-id
  ServiceBusQueueEventSubscriptionDestination.properties.resourceId: -|arm-id
  ServiceBusTopicEventSubscriptionDestination.properties.resourceId: -|arm-id
  StorageBlobDeadLetterDestination.properties.resourceId: -|arm-id
  StorageQueueEventSubscriptionDestination.properties.resourceId: -|arm-id
  EventSubscriptionFilter.enableAdvancedFilteringOnArrays: IsAdvancedFilteringOnArraysEnabled
  EventType: EventTypeUnderTopic
  PartnerNamespaceUpdateParameters.properties.disableLocalAuth: IsLocalAuthDisabled
  PartnerTopicInfo.azureSubscriptionId: -|uuid
  WebHookEventSubscriptionDestination.properties.azureActiveDirectoryApplicationIdOrUri: UriOrAzureActiveDirectoryApplicationId
  WebHookEventSubscriptionDestination.properties.azureActiveDirectoryTenantId: -|uuid
  WebHookEventSubscriptionDestination.properties.endpointUrl: Endpoint|Uri
  WebHookEventSubscriptionDestination.properties.endpointBaseUrl: BaseEndpoint|Uri
  EventSubscriptionFullUrl.endpointUrl: Endpoint|Uri
  Subscription.properties.expirationTimeUtc: ExpireOn
  SubscriptionUpdateParameters.properties.expirationTimeUtc: ExpireOn

directive:
  - from: EventGrid.json
    where: $.paths..parameters[?(@.name=='scope')]
    transform: >
      $['x-ms-skip-url-encoding'] = true;
  # PrivateEndpointConnection defines enum type but PrivateLinkResources not, should fix it in swagger
  - from: EventGrid.json
    where: $.paths..parameters[?(@.name=='parentType')]
    transform: >
      $['enum'] = [
              'topics',
              'domains',
              'partnerNamespaces'
            ];
      $['x-ms-enum'] = {
              'name': 'ParentType',
              'modelAsString': true
            };
  - from: EventGrid.json
    where: $.definitions.IdentityInfo
    transform: >
      $.properties.principalId.readOnly = true;
      $.properties.tenantId.readOnly = true;
    reason: Remove the setter to ensure this type can be replaced by the common type.

```
