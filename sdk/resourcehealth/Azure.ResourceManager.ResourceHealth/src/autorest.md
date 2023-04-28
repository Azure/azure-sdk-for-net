# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
generate-model-factory: false
csharp: true
library-name: ResourceHealth
namespace: Azure.ResourceManager.ResourceHealth
require: https://github.com/Azure/azure-rest-api-specs/blob/56b585b014e28a73a0a7831e27b93fa803effead/specification/resourcehealth/resource-manager/readme.md
# tag: package-2022-10
output-folder: $(this-folder)/Generated
clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false

#mgmt-debug:
#  show-serialized-names: true

rename-mapping:
  Link.type: LinkType
  EmergingIssuesGetResult: ServiceEmergingIssue
  AvailabilityStatusPropertiesRecentlyResolved: AvailabilityStateRecentlyResolved
  EventPropertiesArticle: EventArticle
  EventPropertiesRecommendedActions: EventRecommendedActions
  EventPropertiesRecommendedActionsItem: EventRecommendedActionsItem
  Events: ResourceHealthEventListResult
  LevelValues: EventInsightLevelValues
  Faq: EventFaq
  Impact: EventImpact
  IssueNameParameter: IssueNameContent
  Link: EventLink
  LinkDisplayText: EventLinkDisplayText
  LinkTypeValues: EventLinkTypeValues
  Scenario: MetadataEntityScenario
  SeverityValues: EventSeverityLevel
  StageValues: EventStageValues
  StatusActiveEvent: EmergingIssueActiveEventType
  StatusBanner: EmergingIssueBannerType
  Update: EventUpdate
  Event.properties.isHIR: IsHirEvent
  Event.properties.platformInitiated: IsPlatformInitiated
  StatusActiveEvent.published: IsPublished
  EventTypeValues.RCA: Rca
  MetadataSupportedValueDetail.resourceTypes: -|resource-type
  AvailabilityStatusProperties.resolutionETA: ResolutionEta
  EventImpactedResource.properties.targetResourceType: -|resource-type
  EventImpactedResource.properties.targetResourceId: -|arm-id
  EmergingIssuesGetResult.properties.refreshTimestamp: RefreshedOn
  Update.updateDateTime: UpdatedOn

prepend-rp-prefix:
  - AvailabilityStatus
  - AvailabilityStatusProperties
  - Event
  - MetadataEntity
  - EventImpactedResource
  - KeyValueItem

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

override-operation-name:
  Events_ListBySingleResource: GetHealthEventsOfSingleResource
  ChildResources_List: GetHealthStatusOfChildResources

request-path-to-resource-name:
  /subscriptions/{subscriptionId}/providers/Microsoft.ResourceHealth/events/{eventTrackingId}/impactedResources/{impactedResourceName}: ResourceHealthEventImpactedResource
  /subscriptions/{subscriptionId}/providers/Microsoft.ResourceHealth/events/{eventTrackingId}: ResourceHealthEvent
  /providers/Microsoft.ResourceHealth/events/{eventTrackingId}/impactedResources/{impactedResourceName}: TenantResourceHealthEventImpactedResource
  /providers/Microsoft.ResourceHealth/events/{eventTrackingId}: TenantResourceHealthEvent
  /{resourceUri}/providers/Microsoft.ResourceHealth/availabilityStatuses/current: ResourceHealthAvailabilityStatus
  /{resourceUri}/providers/Microsoft.ResourceHealth/childAvailabilityStatuses/current: ResourceHealthChildAvailabilityStatus

```