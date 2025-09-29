# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Consumption
namespace: Azure.ResourceManager.Consumption
require: https://github.com/Azure/azure-rest-api-specs/blob/d7de657fac0ab30176979bf490a5f85131ff0a51/specification/consumption/resource-manager/readme.md
# tag: package-2024-08
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
  skipped-operations:
  - AggregatedCost_GetForBillingPeriodByManagementGroup
  - Balances_GetByBillingAccount
  - Balances_GetForBillingPeriodByBillingAccount
  - ReservationsSummaries_ListByReservationOrder
  - ReservationsDetails_ListByReservationOrder
  - ReservationTransactions_List
  - ReservationTransactions_ListByBillingProfile
  - Events_ListByBillingProfile
  - Events_ListByBillingAccount
  - Lots_ListByBillingProfile
  - Lots_ListByBillingAccount
  - Lots_ListByCustomer
  - Credits_Get
  - ReservationsDetails_ListByReservationOrderAndReservation
  - ReservationsSummaries_ListByReservationOrderAndReservation
  - Budgets_CreateOrUpdate
  - PriceSheet_GetByBillingPeriod
  - UsageDetails_List
  - Marketplaces_List
  - Tags_Get
  - Charges_List
  - ReservationsSummaries_List
  - ReservationsDetails_List
  - ReservationRecommendations_List
  - ReservationRecommendationDetails_Get
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true

request-path-is-non-resource:
  - /subscriptions/{subscriptionId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}/providers/Microsoft.Consumption/pricesheets/default
  - /subscriptions/{subscriptionId}/providers/Microsoft.Consumption/pricesheets/default
  - /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/credits/balanceSummary

partial-resources:
  /providers/microsoft.Billing/billingAccounts/{billingAccountId}: BillingAccount
  /providers/microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}: BillingProfile
  /providers/microsoft.Billing/billingAccounts/{billingAccountId}/billingPeriods/{billingPeriodName}: TenantBillingPeriod
  /subscriptions/{subscriptionId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}: SubscriptionBillingPeriod
  /providers/microsoft.Management/managementGroups/{managementGroupId}/providers/microsoft.Billing/billingPeriods/{billingPeriodName}: ManagementGroupBillingPeriod
  /providers/microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}: BillingCustomer
  /providers/microsoft.Capacity/reservationorders/{reservationOrderId}/reservations/{reservationId}: Reservation
  /providers/microsoft.Capacity/reservationorders/{reservationOrderId}: ReservationOrder

override-operation-name:
  Balances_GetByBillingAccount: GetBalance
  Balances_GetForBillingPeriodByBillingAccount: GetBalance
  PriceSheet_GetByBillingPeriod: GetPriceSheet
  AggregatedCost_GetByManagementGroup: GetAggregatedCost
  AggregatedCost_GetForBillingPeriodByManagementGroup: GetAggregatedCost
  Events_ListByBillingAccount: GetEvents
  Events_ListByBillingProfile: GetEvents
  Lots_ListByBillingAccount: GetLots
  Lots_ListByBillingProfile: GetLots
  Lots_ListByCustomer: GetLots
  ReservationsDetails_ListByReservationOrderAndReservation: GetReservationDetails
  ReservationsDetails_ListByReservationOrder: GetReservationDetails
  ReservationsSummaries_ListByReservationOrderAndReservation: GetReservationSummaries
  ReservationsSummaries_ListByReservationOrder: GetReservationSummaries
  ReservationTransactions_ListByBillingProfile: GetReservationTransactions
  Charges_List: GetConsumptionCharges
  Marketplaces_List: GetConsumptionMarketPlaces
  ReservationRecommendationDetails_Get: GetConsumptionReservationRecommendationDetails
  ReservationRecommendations_List: GetConsumptionReservationRecommendations
  ReservationsDetails_List: GetConsumptionReservationsDetails
  ReservationsSummaries_List: GetConsumptionReservationsSummaries
  Tags_Get: GetConsumptionTags
  UsageDetails_List: GetConsumptionUsageDetails

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

models-to-treat-empty-string-as-null:
  - ConsumptionLegacyReservationRecommendation
  - ConsumptionLegacyUsageDetail
  - ConsumptionMarketplace
  - ConsumptionModernReservationRecommendation
  - ConsumptionModernUsageDetail
  - PriceSheetProperties

rename-mapping:
  Budget: ConsumptionBudget
  CategoryType: BudgetCategory
  CurrentSpend: BudgetCurrentSpend
  BudgetFilter: ConsumptionBudgetFilter
  ForecastSpend: BudgetForecastSpend
  Notification: BudgetAssociatedNotification
  Notification.enabled: IsEnabled
  TimeGrainType: BudgetTimeGrainType
  Balance: ConsumptionBalanceResult
  Balance.properties.priceHidden: IsPriceHidden
  CreditSummary: ConsumptionCreditSummary
  EventSummary: ConsumptionEventSummary
  EventSummary.properties.billingProfileId: -|arm-id
  EventSummary.properties.lotId: -|arm-id
  EventSummary.properties.transactionDate: TransactOn
  EventType: ConsumptionEventType
  ManagementGroupAggregatedCostResult: ConsumptionAggregatedCostResult
  ManagementGroupAggregatedCostResult.properties.usageStart: UsageStartOn
  ManagementGroupAggregatedCostResult.properties.usageEnd: UsageEndOn
  LotSummary: ConsumptionLotSummary
  LotSource: ConsumptionLotSource
  Status: ConsumptionLotStatus
  ReservationSummary: ConsumptionReservationSummary
  Datagrain: ReservationSummaryDataGrain
  ReservationTransaction: ConsumptionReservationTransaction
  ReservationTransaction.properties.eventDate: TransactOn
  ModernReservationTransaction: ConsumptionModernReservationTransaction
  ModernReservationTransaction.properties.eventDate: TransactOn
  ModernReservationTransaction.properties.billingProfileId: -|arm-id
  ModernReservationTransaction.properties.invoiceId: -|arm-id
  ModernReservationTransaction.properties.invoiceSectionId: -|arm-id
  Amount: ConsumptionAmount
  AmountWithExchangeRate: ConsumptionAmountWithExchangeRate
  BillingFrequency: ConsumptionBillingFrequency
  BalancePropertiesAdjustmentDetailsItem: ConsumptionBalanceAdjustmentDetail
  BalancePropertiesNewPurchasesDetailsItem: ConsumptionBalanceNewPurchasesDetail
  Reseller: ConsumptionReseller
  Reseller.resellerId: -|arm-id
  CultureCode: RecipientNotificationLanguageCode
  CultureCode.en-us: EnglishUnitedStates
  CultureCode.ja-jp: JapaneseJapan
  CultureCode.zh-cn: ChinesePrc
  CultureCode.de-de: GermanGermany
  CultureCode.es-es: SpanishSpain
  CultureCode.fr-fr: FrenchFrance
  CultureCode.it-it: ItalianItaly
  CultureCode.ko-kr: KoreanKorea
  CultureCode.pt-br: PortugueseBrazil
  CultureCode.ru-ru: RussianRussia
  CultureCode.zh-tw: ChineseTaiwan
  CultureCode.cs-cz: CzechCzechRepublic
  CultureCode.pl-pl: PolishPoland
  CultureCode.tr-tr: TurkishTurkey
  CultureCode.da-dk: DanishDenmark
  CultureCode.en-gb: EnglishUnitedKingdom
  CultureCode.hu-hu: HungarianHungary
  CultureCode.nb-no: NorwegianNorway
  CultureCode.nl-nl: DutchNetherlands
  CultureCode.pt-pt: PortuguesePortugal
  CultureCode.sv-se: SwedishSweden
  MeterDetails: ConsumptionMeterDetails
  OperatorType: NotificationAlertTriggerType
  ThresholdType: NotificationThresholdType
  PriceSheetProperties.billingPeriodId: -|arm-id
  ReservationSummary.properties.usageDate: UseOn
  ChargeSummary: ConsumptionChargeSummary
  Marketplace: ConsumptionMarketplace
  ReservationRecommendationDetailsModel: ConsumptionReservationRecommendationDetails
  Scope: ConsumptionReservationRecommendationScope
  Term: ConsumptionReservationRecommendationTerm
  LookBackPeriod: ConsumptionReservationRecommendationLookBackPeriod
  TagsResult: ConsumptionTagsResult
  UsageDetail: ConsumptionUsageDetail
  LegacyUsageDetail: ConsumptionLegacyUsageDetail
  ModernUsageDetail: ConsumptionModernUsageDetail
  Marketplace.properties.usageStart: UsageStartOn
  Marketplace.properties.usageEnd: UsageEndOn
  ReservationRecommendationDetailsModel.properties.resource: Properties
  LegacyChargeSummary: ConsumptionLegacyChargeSummary
  ReservationRecommendation: ConsumptionReservationRecommendation
  LegacyReservationRecommendation: ConsumptionLegacyReservationRecommendation
  ModernReservationRecommendation: ConsumptionModernReservationRecommendation
  MeterDetailsResponse: ConsumptionMeterDetailsInfo
  Metrictype: ConsumptionMetricType
  ModernChargeSummary: ConsumptionModernChargeSummary
  PricingModelType: ConsumptionPricingModelType
  ReservationRecommendationDetailsCalculatedSavingsProperties: ConsumptionCalculatedSavingsProperties
  ReservationRecommendationDetailsResourceProperties: ConsumptionResourceProperties
  ReservationRecommendationDetailsSavingsProperties: ConsumptionSavingsProperties
  ReservationRecommendationDetailsUsageProperties: ConsumptionUsageProperties
  SkuProperty: ConsumptionSkuProperty
  Tag: ConsumptionTag
  SavingsPlan: ConsumptionSavingsPlan
  OrganizationType: ConsumptionOrganizationType
  OperationStatusType: ConsumptionOperationStatusType
  OperationStatus: ConsumptionOperationStatus
  ModernReservationRecommendationProperties.resourceType: -|resource-type
  ReservationDetail: ConsumptionReservationDetail

directive:
  - from: openapi.json
    where: $.definitions
    transform: >
      const propertiesToClean = [
        'CreditSummaryProperties', 'EventProperties', 'LotProperties'
      ];
      propertiesToClean.forEach(propName => {
        if ($[propName] && $[propName].properties && $[propName].properties.eTag) {
          delete $[propName].properties.eTag;
        }
      });
      const modelsToClean = [
        'Budget', 'CreditSummary', 'Balance', 
        'EventSummary', 'LotSummary', 'ReservationSummary', 'TagsResult',
        'ReservationDetail', 'Marketplace', 'ManagementGroupAggregatedCostResult'
      ];
      modelsToClean.forEach(modelName => {
        if ($[modelName] && $[modelName].properties) {
          if ($[modelName].properties.eTag) {
            delete $[modelName].properties.eTag;
          }
          if ($[modelName].properties.etag) {
            delete $[modelName].properties.etag;
          }
        }
      });
    reason: delete the eTag property in Properties model as the original model already has got an eTag property from allOf keyword.
  - from: openapi.json
    where: $.definitions
    transform: >
      $.ReservationDetailProperties.properties.usageDate['x-ms-client-name'] = 'ConsumptionOccurredOn';
      $.ReservationDetailProperties.properties.instanceId['x-ms-format'] = 'arm-id';
    reason: avoid duplicated schema issue in partial resource generation process.
  - from: openapi.json
    where: $.paths
    transform: >
      $['/{scope}/providers/Microsoft.Consumption/usageDetails'].get.parameters[3]['x-ms-client-name'] = 'skipToken';
      $['/{scope}/providers/Microsoft.Consumption/marketplaces'].get.parameters[2]['x-ms-client-name'] = 'skipToken';
      $['/subscriptions/{subscriptionId}/providers/Microsoft.Consumption/pricesheets/default'].get.parameters[3]['x-ms-client-name'] = 'skipToken';
      $['/subscriptions/{subscriptionId}/providers/Microsoft.Billing/billingPeriods/{billingPeriodName}/providers/Microsoft.Consumption/pricesheets/default'].get.parameters[4]['x-ms-client-name'] = 'skipToken';
    reason: change the query parameter name from skiptoken to skipToken.
  - from: consumption.json
    where: $.parameters.scopeParameter
    transform: $["x-ms-client-name"] = "reservationScope";
  - from: openapi.json
    where: $.definitions
    transform: >
      ['Budget','CreditSummary'].forEach(n => {
        if ($[n] && Array.isArray($[n].allOf) && $[n].allOf.length > 0 && $[n].allOf[0]['$ref'] !== '#/definitions/ProxyResource') {
          $[n].allOf[0]['$ref'] = '#/definitions/ProxyResource';
        }
      });
    reason: Force Budget, CreditSummary to inherit from current definition ProxyResource.
  - from: openapi.json
    where: $.paths['/providers/microsoft.Billing/billingAccounts/{billingAccountId}/billingPeriods/{billingPeriodName}/providers/Microsoft.Consumption/pricesheets/download'].post.responses.default.schema
    transform: >
      $['$ref'] = "#/definitions/ErrorResponse";
    reason: Fix ErrorResponse reference path for PriceSheet_DownloadByBillingAccountPeriod operation.
  - from: openapi.json
    where: $.definitions.PriceSheetResult
    transform: >
      delete $.properties.etag;
      delete $.properties.tags;
      $.allOf[0]['$ref'] = '#/definitions/Resource';
    reason: Fix PriceSheetResult to inherit from Resource and remove duplicated etag/tags properties.
  - from: openapi.json
    where: $.definitions
    transform: >
      ['LegacyReservationRecommendation', 'ModernReservationRecommendation'].forEach(model => {
        if ($[model] && $[model].properties && $[model].properties.properties) {
          $[model].properties.properties['x-ms-client-flatten'] = true;
        }
      });
    reason: Flatten the 'properties' property in both LegacyReservationRecommendation and ModernReservationRecommendation models.

````
