# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Marketplace
namespace: Azure.ResourceManager.Marketplace
require: https://github.com/Azure/azure-rest-api-specs/blob/aa8a23b8f92477d0fdce7af6ccffee1c604b3c56/specification/marketplace/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

rename-mapping:
  AcknowledgeOfferNotificationProperties: AcknowledgeOfferNotificationContent
  AcknowledgeOfferNotificationProperties.properties.acknowledge: IsAcknowledgeActionFlagEnabled
  AcknowledgeOfferNotificationProperties.properties.dismiss: IsDismissActionFlagEnabled
  AcknowledgeOfferNotificationProperties.properties.removeOffer: IsRemoveOfferActionFlagEnabled
  Accessibility: PrivateStorePlanAccessibility
  AdminAction: MarketplaceAdminAction
  AdminRequestApprovalsResource: MarketplaceAdminApprovalRequest
  AdminRequestApprovalsResource.properties.collectionIds: -|uuid
  AdminRequestApprovalsResource.properties.icon: iconUri|uri
  AdminRequestApprovalsList: MarketplaceAdminApprovalRequestList
  AnyExistingOffersInTheCollectionsResponse: AnyExistingOffersInTheCollectionsResult
  Availability: PrivateStoreAvailability
  BillingAccountsResponse: PrivateStoreBillingAccountsResult
  BulkCollectionsPayload: BulkCollectionsActionContent
  BulkCollectionsPayload.properties.collectionIds: -|uuid
  BulkCollectionsResponse: BulkCollectionsActionResult
  Collection: PrivateStoreCollectionInfo    # Add `Info` prefix to make a little better for `CollectionCollection`
  Collection.properties.collectionId: -|uuid
  Collection.properties.allSubscriptions: AreAllSubscriptionsSelected
  Collection.properties.approveAllItems: AreAllItemsApproved
  Collection.properties.enabled: IsEnabled
  CollectionsDetails.collectionId: -|uuid
  CollectionsDetails: PrivateStoreCollectionDetails
  CollectionsToSubscriptionsMappingPayload: CollectionsToSubscriptionsMappingContent
  CollectionsToSubscriptionsMappingResponse: CollectionsToSubscriptionsMappingResult
  MultiContextAndPlansPayload: MultiContextAndPlansContent
  NewNotifications.icon: iconUri|uri
  NewNotifications: NewPlanNotification
  NewPlansNotificationsList: NewPlanNotificationListResult
  Offer: PrivateStoreOffer
  OfferProperties: PrivateStoreOfferResult
  Operation: PrivateStoreOperation
  Plan: PrivateStorePlan
  PlanDetails: PrivateStorePlanDetails
  PrivateStore.properties.collectionIds: -|uuid
  PrivateStore.properties.privateStoreId: -|uuid
  QueryApprovedPlansPayload: QueryApprovedPlansContent
  QueryApprovedPlansResponse: QueryApprovedPlansResult
  QueryRequestApproval: QueryApprovalRequestResult
  QueryRequestApprovalProperties: QueryApprovalRequestContent
  QueryUserOffersProperties:  QueryUserOffersContent
  Recipient: NotificationRecipient
  Recipient.principalId: -|uuid
  RequestApprovalsDetails.icon: iconUri|uri
  RequestApprovalResource: MarketplaceApprovalRequest
  Status: PrivateStorePlanStatus
  StopSellNotifications.icon: iconUri|uri
  StopSellOffersPlansNotificationsListProperties: StopSellOffersPlansNotificationsResult
  StopSellOffersPlansNotificationsListProperties.icon: iconUri|uri
  StopSellOffersPlansNotificationsListProperties.publicContext: hasPublicContext
  StopSellOffersPlansNotificationsListProperties.isEntire: isEntireInStopSell
  Subscription: MarketplaceSubscription
  SubscriptionState: MarketplaceSubscriptionState
  TransferOffersResponse: TransferOffersResult
  TransferOffersProperties: TransferOffersContent
  UserRequestDetails: PlanRequesterInfo
  WithdrawProperties: WithdrawPlanContent

format-by-name-rules:
  'tenantId': 'uuid'
  'ETag': 'etag'
  'location': 'azure-location'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

override-operation-name:
  PrivateStoreCollection_Post: Delete
  PrivateStoreCollectionOffer_Post: Delete
  PrivateStore_FetchAllSubscriptionsInTenant: FetchAllMarketplaceSubscriptions
  PrivateStore_QueryRequestApproval: QueryApprovalRequest
  PrivateStore_BillingAccounts: FetchBillingAccounts
  PrivateStore_BulkCollectionsAction: PerformActionOnBulkCollections
  PrivateStore_CollectionsToSubscriptionsMapping: FetchCollectionsToSubscriptionsMapping

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

directive:
  - from: Marketplace.json
    where: $.parameters
    transform: >
      $.PrivateStoreIdParameter['format'] = 'uuid';
      $.CollectionIdParameter['format'] = 'uuid';
  - from: Marketplace.json
    where: $.definitions
    transform: >
      $.OfferProperties.properties.createdAt['format'] = 'date-time';
      $.OfferProperties.properties.createdAt['x-ms-client-name'] = 'CreatedOn';
      $.OfferProperties.properties.modifiedAt['format'] = 'date-time';
      $.OfferProperties.properties.modifiedAt['x-ms-client-name'] = 'ModifiedOn';
      $.OfferProperties.properties.updateSuppressedDueIdempotence['x-ms-client-name'] = 'IsUpdateSuppressedDueToIdempotence';
      $.OfferProperties.properties.privateStoreId['format'] = 'uuid';
      $.OfferProperties.properties.iconFileUris.additionalProperties['format'] = 'url';
      $.QueryRequestApprovalProperties.properties.properties['x-ms-client-flatten'] = true;

```
