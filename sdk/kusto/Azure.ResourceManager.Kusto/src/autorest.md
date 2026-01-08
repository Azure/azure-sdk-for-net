# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml

azure-arm: true
csharp: true
library-name: Kusto
namespace: Azure.ResourceManager.Kusto
require: https://github.com/Azure/azure-rest-api-specs/blob/edc6e6a8b4de49a78397162e7eb55b9c696c2d71/specification/azure-kusto/resource-manager/readme.md
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
  output-folder: $(this-folder)/../tests/Generated
  clear-output-folder: true
skip-csproj: true
modelerfour:
  flatten-payloads: false
use-model-reader-writer: true
enable-bicep-serialization: true

override-operation-name:
  AttachedDatabaseConfigurations_CheckNameAvailability: CheckKustoAttachedDatabaseConfigurationNameAvailability
  ClusterPrincipalAssignments_CheckNameAvailability: CheckKustoClusterPrincipalAssignmentNameAvailability
  Databases_CheckNameAvailability: CheckKustoDatabaseNameAvailability
  ManagedPrivateEndpoints_CheckNameAvailability: CheckKustoManagedPrivateEndpointNameAvailability
  Clusters_ListSkusByResource: GetAvailableSkus
  DatabasePrincipalAssignments_CheckNameAvailability: CheckKustoDatabasePrincipalAssignmentNameAvailability
  DataConnections_CheckNameAvailability: CheckKustoDataConnectionNameAvailability
  Scripts_CheckNameAvailability: CheckKustoScriptNameAvailability
  DataConnections_DataConnectionValidation: ValidateDataConnection
  Clusters_CheckNameAvailability: CheckKustoClusterNameAvailability
  Clusters_ListSkus: GetKustoEligibleSkus

rename-mapping:
  EventGridDataFormat.APACHEAVRO: ApacheAvro
  EventHubDataFormat.APACHEAVRO: ApacheAvro
  IotHubDataFormat.APACHEAVRO: ApacheAvro
  AttachedDatabaseConfiguration: KustoAttachedDatabaseConfiguration
  AttachedDatabaseConfiguration.properties.clusterResourceId: -|arm-id
  ProvisioningState: KustoProvisioningState
  Cluster: KustoCluster
  Cluster.properties.uri: ClusterUri
  Cluster.properties.enableAutoStop: IsAutoStopEnabled
  Cluster.properties.enableDiskEncryption: IsDiskEncryptionEnabled
  Cluster.properties.enableDoubleEncryption: IsDoubleEncryptionEnabled
  Cluster.properties.enablePurge: IsPurgeEnabled
  Cluster.properties.enableStreamingIngest: IsStreamingIngestEnabled
  ClusterUpdate.properties.enableAutoStop: IsAutoStopEnabled
  ClusterUpdate.properties.enableDiskEncryption: IsDiskEncryptionEnabled
  ClusterUpdate.properties.enableDoubleEncryption: IsDoubleEncryptionEnabled
  ClusterUpdate.properties.enablePurge: IsPurgeEnabled
  ClusterUpdate.properties.enableStreamingIngest: IsStreamingIngestEnabled
  AzureSku: KustoSku
  AzureResourceSku: KustoAvailableSkuDetails
  AcceptedAudiences: AcceptedAudience
  EngineType: KustoClusterEngineType
  KeyVaultProperties: KustoKeyVaultProperties
  PublicIPType: KustoClusterPublicIPType
  PublicNetworkAccess: KustoClusterPublicNetworkAccess
  ClusterNetworkAccessFlag: KustoClusterNetworkAccessFlag
  State: KustoClusterState
  VnetState: KustoClusterVnetState
  VirtualNetworkConfiguration: KustoClusterVirtualNetworkConfiguration
  ClusterPrincipalAssignment: KustoClusterPrincipalAssignment
  ClusterPrincipalAssignment.properties.aadObjectId: -|uuid
  ClusterPrincipalAssignment.properties.principalId: ClusterPrincipalId
  PrincipalType: KustoPrincipalAssignmentType
  ClusterPrincipalRole: KustoClusterPrincipalRole
  Language: SandboxCustomImageLanguage
  LanguageExtension: KustoLanguageExtension
  LanguageExtensionsList: KustoLanguageExtensionList
  LanguageExtensionName: KustoLanguageExtensionName
  AttachedDatabaseConfigurationsCheckNameRequest: KustoAttachedDatabaseConfigurationNameAvailabilityContent
  ClusterPrincipalAssignmentCheckNameRequest: KustoClusterPrincipalAssignmentNameAvailabilityContent
  ManagedPrivateEndpointsCheckNameRequest: KustoManagedPrivateEndpointNameAvailabilityContent
  CheckNameRequest: KustoDatabaseNameAvailabilityContent
  CheckNameResult: KustoNameAvailabilityResult
  Database: KustoDatabase
  DatabasePrincipalAssignment: KustoDatabasePrincipalAssignment
  DatabasePrincipalAssignmentType: KustoDatabasePrincipalAssignmentType
  DatabasePrincipalAssignment.properties.aadObjectId: -|uuid
  DatabasePrincipalAssignment.properties.principalId: DatabasePrincipalId
  DatabasePrincipalRole: KustoDatabasePrincipalRole
  DatabasePrincipalType: KustoDatabasePrincipalType
  DatabasePrincipal: KustoDatabasePrincipal
  DatabasePrincipalListRequest: DatabasePrincipalList
  DatabasePrincipalAssignmentCheckNameRequest: KustoDatabasePrincipalAssignmentNameAvailabilityContent
  DataConnectionCheckNameRequest: KustoDataConnectionNameAvailabilityContent
  ScriptCheckNameRequest: KustoScriptNameAvailabilityContent
  DataConnectionValidation: DataConnectionValidationContent
  DataConnectionValidationListResult: DataConnectionValidationResults
  DataConnection: KustoDataConnection
  ManagedPrivateEndpoint: KustoManagedPrivateEndpoint
  ManagedPrivateEndpoint.properties.privateLinkResourceId: -|arm-id
  Script: KustoScript
  Script.properties.continueOnErrors: ShouldContinueOnErrors
  Script.properties.scriptUrlSasToken: ScriptUriSasToken
  ClusterCheckNameRequest: KustoClusterNameAvailabilityContent
  Type: KustoDatabaseResourceType
  AzureCapacity: KustoCapacity
  AzureScaleType: KustoScaleType
  AzureSkuName: KustoSkuName
  AzureSkuName.Dev(No SLA)_Standard_D11_v2: DevNoSlaStandardD11V2
  AzureSkuName.Dev(No SLA)_Standard_E2a_v4: DevNoSlaStandardE2aV4
  AzureSkuName.Standard_D32d_v4: StandardD32dV4
  AzureSkuName.Standard_D16d_v5: StandardD16dV5
  AzureSkuName.Standard_D32d_v5: StandardD32dV5
  AzureSkuName.Standard_L4s: StandardL4s
  AzureSkuName.Standard_L8s: StandardL8s
  AzureSkuName.Standard_L16s: StandardL16s
  AzureSkuName.Standard_L8s_v2: StandardL8sV2
  AzureSkuName.Standard_L16s_v2: StandardL16sV2
  AzureSkuName.Standard_E64i_v3: StandardE64iV3
  AzureSkuName.Standard_E80ids_v4: StandardE80idsV4
  AzureSkuName.Standard_E2a_v4: StandardE2aV4
  AzureSkuName.Standard_E4a_v4: StandardE4aV4
  AzureSkuName.Standard_E8a_v4: StandardE8aV4
  AzureSkuName.Standard_E16a_v4: StandardE16aV4
  AzureSkuName.Standard_E8as_v4+1TB_PS: StandardE8asV41TBPS
  AzureSkuName.Standard_E8as_v4+2TB_PS: StandardE8asV42TBPS
  AzureSkuName.Standard_E16as_v4+3TB_PS: StandardE16asV43TBPS
  AzureSkuName.Standard_E16as_v4+4TB_PS: StandardE16asV44TBPS
  AzureSkuName.Standard_E8as_v5+1TB_PS: StandardE8asV51TBPS
  AzureSkuName.Standard_E8as_v5+2TB_PS: StandardE8asV52TBPS
  AzureSkuName.Standard_E16as_v5+3TB_PS: StandardE16asV53TBPS
  AzureSkuName.Standard_E16as_v5+4TB_PS: StandardE16asV54TBPS
  AzureSkuName.Standard_E2ads_v5: StandardE2adsV5
  AzureSkuName.Standard_E4ads_v5: StandardE4adsV5
  AzureSkuName.Standard_E8ads_v5: StandardE8adsV5
  AzureSkuName.Standard_E16ads_v5: StandardE16adsV5
  AzureSkuName.Standard_E8s_v4+1TB_PS: StandardE8sV41TBPS
  AzureSkuName.Standard_E8s_v4+2TB_PS: StandardE8sV42TBPS
  AzureSkuName.Standard_E16s_v4+3TB_PS: StandardE16sV43TBPS
  AzureSkuName.Standard_E16s_v4+4TB_PS: StandardE16sV44TBPS
  AzureSkuName.Standard_E8s_v5+1TB_PS: StandardE8sV51TBPS
  AzureSkuName.Standard_E8s_v5+2TB_PS: StandardE8sV52TBPS
  AzureSkuName.Standard_E16s_v5+3TB_PS: StandardE16sV53TBPS
  AzureSkuName.Standard_E16s_v5+4TB_PS: StandardE16sV54TBPS
  AzureSkuName.Standard_L8s_v3: StandardL8sV3
  AzureSkuName.Standard_L16s_v3: StandardL16sV3
  AzureSkuName.Standard_L32s_v3: StandardL32sV3
  AzureSkuName.Standard_L8as_v3: StandardL8asV3
  AzureSkuName.Standard_L16as_v3: StandardL16asV3
  AzureSkuName.Standard_L32as_v3: StandardL32asV3
  AzureSkuName.Standard_EC8as_v5+1TB_PS: StandardEC8asV51TBPS
  AzureSkuName.Standard_EC8as_v5+2TB_PS: StandardEC8asV52TBPS
  AzureSkuName.Standard_EC16as_v5+3TB_PS: StandardEC16asV53TBPS
  AzureSkuName.Standard_EC16as_v5+4TB_PS: StandardEC16asV54TBPS
  AzureSkuName.Standard_EC8ads_v5: StandardEC8adsV5
  AzureSkuName.Standard_EC16ads_v5: StandardEC16adsV5
  AzureSkuName.Standard_E2d_v4: StandardE2dV4
  AzureSkuName.Standard_E4d_v4: StandardE4dV4
  AzureSkuName.Standard_E8d_v4: StandardE8dV4
  AzureSkuName.Standard_E16d_v4: StandardE16dV4
  AzureSkuName.Standard_E2d_v5: StandardE2dV5
  AzureSkuName.Standard_E4d_v5: StandardE4dV5
  AzureSkuName.Standard_E8d_v5: StandardE8dV5
  AzureSkuName.Standard_E16d_v5: StandardE16dV5
  AzureSkuTier: KustoSkuTier
  Reason: KustoNameUnavailableReason
  ClusterType: KustoClusterType
  PrincipalAssignmentType: KustoClusterPrincipalAssignmentType
  Compression: EventHubMessagesCompressionType
  DatabaseRouting: KustoDatabaseRouting
  DataConnectionType: KustoDataConnectionType
  EventGridDataConnection: KustoEventGridDataConnection
  EventGridDataConnection.properties.eventGridResourceId: -|arm-id
  EventGridDataConnection.properties.eventHubResourceId: -|arm-id
  EventGridDataConnection.properties.managedIdentityResourceId: -|arm-id
  EventGridDataConnection.properties.storageAccountResourceId: -|arm-id
  EventGridDataConnection.properties.ignoreFirstRecord: IsFirstRecordIgnored
  EventGridDataConnection.properties.managedIdentityObjectId: -|uuid
  EventGridDataFormat: KustoEventGridDataFormat
  EventGridDataFormat.MULTIJSON: MultiJson
  EventGridDataFormat.CSV: Csv
  EventGridDataFormat.TSV: Tsv
  EventGridDataFormat.PSV: Psv
  EventGridDataFormat.TXT: Txt
  EventGridDataFormat.RAW: Raw
  EventGridDataFormat.SINGLEJSON: SingleJson
  EventGridDataFormat.ORC: Orc
  EventGridDataFormat.W3CLOGFILE: W3CLogFile
  EventHubDataConnection: KustoEventHubDataConnection
  EventHubDataConnection.properties.eventHubResourceId: -|arm-id
  EventHubDataConnection.properties.managedIdentityResourceId: -|arm-id
  EventHubDataConnection.properties.managedIdentityObjectId: -|uuid
  EventHubDataFormat: KustoEventHubDataFormat
  EventHubDataFormat.MULTIJSON: MultiJson
  EventHubDataFormat.CSV: Csv
  EventHubDataFormat.TSV: Tsv
  EventHubDataFormat.PSV: Psv
  EventHubDataFormat.TXT: Txt
  EventHubDataFormat.RAW: Raw
  EventHubDataFormat.SINGLEJSON: SingleJson
  EventHubDataFormat.ORC: Orc
  EventHubDataFormat.W3CLOGFILE: W3CLogFile
  CosmosDbDataConnection: KustoCosmosDbDataConnection
  CosmosDbDataConnection.properties.managedIdentityResourceId: -|arm-id
  CosmosDbDataConnection.properties.managedIdentityObjectId: -|uuid
  CosmosDbDataConnection.properties.cosmosDbAccountResourceId: -|arm-id
  FollowerDatabaseDefinition: KustoFollowerDatabaseDefinition
  FollowerDatabaseDefinition.clusterResourceId: -|arm-id
  IotHubDataConnection: KustoIotHubDataConnection
  IotHubDataConnection.properties.iotHubResourceId: -|arm-id
  IotHubDataFormat: KustoIotHubDataFormat
  IotHubDataFormat.MULTIJSON: MultiJson
  IotHubDataFormat.CSV: Csv
  IotHubDataFormat.TSV: Tsv
  IotHubDataFormat.PSV: Psv
  IotHubDataFormat.TXT: Txt
  IotHubDataFormat.RAW: Raw
  IotHubDataFormat.SINGLEJSON: SingleJson
  IotHubDataFormat.ORC: Orc
  IotHubDataFormat.W3CLOGFILE: W3CLogFile
  ManagedPrivateEndpointsType: KustoManagedPrivateEndpointsType
  ReadOnlyFollowingDatabase: KustoReadOnlyFollowingDatabase
  ReadWriteDatabase: KustoReadWriteDatabase
  ScriptType: KustoScriptType
  SkuDescription: KustoSkuDescription
  SkuDescription.locations: -|azure-location
  SkuLocationInfoItem: KustoSkuLocationInfoItem
  PrincipalsModificationKind: KustoDatabasePrincipalsModificationKind
  DefaultPrincipalsModificationKind: KustoDatabaseDefaultPrincipalsModificationKind
  TableLevelSharingProperties: KustoDatabaseTableLevelSharingProperties
  TrustedExternalTenant: KustoClusterTrustedExternalTenant
  CallerRole: KustoDatabaseCallerRole
  DatabaseShareOrigin: KustoDatabaseShareOrigin
  LanguageExtensionImageName: KustoLanguageExtensionImageName
  ResourceSkuCapabilities: KustoResourceSkuCapabilities
  ResourceSkuZoneDetails: KustoResourceSkuZoneDetails
  SkuDescriptionList: kustoSkuDescriptionList
  OutboundAccess: KustoCalloutPolicyOutboundAccess
  ZoneStatus: KustoClusterZoneStatus
  ScriptLevel: KustoScriptLevel
  FollowerDatabaseDefinitionGet: KustoFollowerDatabase
  FollowerDatabaseDefinitionGet.properties.clusterResourceId: -|arm-id
  CalloutPolicy: KustoCalloutPolicy
  CalloutType: KustoCalloutPolicyCalloutType





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
  Db: DB

suppress-abstract-base-class:
- KustoDatabaseData
- KustoDataConnectionData

directive:
  - from: kusto.json
    where: $
    transform: >
      delete $['x-ms-paths'];
  - remove-operation: OperationsResults_Get
```
