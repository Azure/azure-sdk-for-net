# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
require: https://github.com/Azure/azure-rest-api-specs/blob/1e7684349abdacee94cbf89200f319cd49e323f2/specification/storage/resource-manager/readme.md
#tag: package-2025-06
output-folder: $(this-folder)/Generated
clear-output-folder: true
sample-gen:
    output-folder: $(this-folder)/../tests/Generated
    clear-output-folder: true
skip-csproj: true
modelerfour:
    flatten-payloads: false
    lenient-model-deduplication: true
use-model-reader-writer: true
enable-bicep-serialization: true

#mgmt-debug:
#  show-serialized-names: true

list-exception:
    - /subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}
    - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/accountMigrations/{migrationName}

override-operation-name:
    StorageAccounts_CheckNameAvailability: CheckStorageAccountNameAvailability
    StorageAccounts_HierarchicalNamespaceMigration: EnableHierarchicalNamespace
    BlobContainers_ObjectLevelWorm: EnableVersionLevelImmutability

request-path-to-singleton-resource:
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/managementPolicies/{managementPolicyName}: managementPolicies/default
    /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/inventoryPolicies/{blobInventoryPolicyName}: inventoryPolicies/default

format-by-name-rules:
    "tenantId": "uuid"
    "ETag": "etag"
    "location": "azure-location"
    "*Uri": "Uri"
    "*Uris": "Uri"
    "*Guid": "uuid"
    "ifMatch": "etag"

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
    SAS: Sas
    SKU: Sku
    SMB: Smb
    NFS: Nfs
    LRS: Lrs
    ZRS: Zrs
    GRS: Grs
    TLS: Tls
    AAD: Aad
    GET: Get
    PUT: Put

prepend-rp-prefix:
    - CorsRule
    - CorsRules
    - CustomDomain
    - DnsEndpointType
    - ListKeyExpand
    - MinimumTlsVersion
    - PermissionScope
    - PublicNetworkAccess
    - RoutingChoice
    - RoutingPreference
    - SshPublicKey
    - UsageName
    - UsageUnit

rename-mapping:
    AccessPolicy: StorageServiceAccessPolicy
    AccessPolicy.expiryTime: expireOn
    AccessTier: StorageAccountAccessTier
    AccountImmutabilityPolicyProperties: AccountImmutabilityPolicy
    AccountLimits: FileServiceAccountLimits
    AccountSasParameters.signedExpiry: SharedAccessExpireOn
    AccountStatus: StorageAccountStatus
    AccountType: ActiveDirectoryAccountType
    AccountUsage: FileServiceAccountUsage
    AccountUsageElements: FileServiceAccountUsageElements
    Action: StorageAccountNetworkRuleAction
    ActiveDirectoryProperties: StorageActiveDirectoryProperties
    ActiveDirectoryProperties.domainGuid: ActiveDirectoryDomainGuid
    AllowedMethods: CorsRuleAllowedMethod
    AzureFilesIdentityBasedAuthentication: FilesIdentityBasedAuthentication
    BlobContainer.properties.deleted: IsDeleted
    BlobContainer.properties.denyEncryptionScopeOverride: PreventEncryptionScopeOverride
    BlobContainer.properties.leaseDuration: LeaseDuration
    BlobInventoryPolicy.properties.policy: PolicySchema
    BlobInventoryPolicyFilter.prefixMatch: IncludePrefix
    BlobInventoryPolicyRule.enabled: IsEnabled
    BlobInventoryPolicySchema.enabled: IsEnabled
    BlobServiceProperties: BlobService
    BlobServiceProperties.properties.automaticSnapshotPolicyEnabled: IsAutomaticSnapshotPolicyEnabled
    Bypass: StorageNetworkBypass
    ChangeFeed: BlobServiceChangeFeed
    ChangeFeed.enabled: IsEnabled
    CheckNameAvailabilityResult: StorageAccountNameAvailabilityResult
    CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
    CustomDomain.useSubDomainName: IsUseSubDomainNameEnabled
    DefaultAction: StorageNetworkDefaultAction
    DefaultSharePermission.StorageFileDataSmbShareContributor: Contributor
    DefaultSharePermission.StorageFileDataSmbShareElevatedContributor: ElevatedContributor
    DefaultSharePermission.StorageFileDataSmbShareReader: Reader
    DeleteRetentionPolicy.enabled: IsEnabled
    DualStackEndpointPreference.publishIpv6Endpoint: IsIPv6EndpointToBePublished
    EnabledProtocols: FileShareEnabledProtocol
    Encryption: StorageAccountEncryption
    EncryptionIdentity: StorageAccountEncryptionIdentity
    EncryptionInTransit.required: IsRequired
    EncryptionScopeSource.Microsoft.KeyVault: KeyVault
    EncryptionScopeSource.Microsoft.Storage: Storage
    EncryptionService: StorageEncryptionService
    EncryptionService.enabled: IsEnabled
    EncryptionServices: StorageAccountEncryptionServices
    Endpoints: StorageAccountEndpoints
    Endpoints.blob: BlobUri
    Endpoints.dfs: DfsUri
    Endpoints.file: FileUri
    Endpoints.queue: QueueUri
    Endpoints.table: TableUri
    Endpoints.web: WebUri
    ExecutionTrigger.type: TaskExecutionTriggerType
    ExecutionTriggerUpdate.type: TaskExecutionTriggerType
    FailoverType: StorageAccountFailoverType
    FileServiceProperties: FileService
    FileShare.properties.deleted: IsDeleted
    FileShare.properties.enabledProtocols: enabledProtocol
    FileShare.properties.leaseDuration: LeaseDuration
    Format: BlobInventoryPolicyFormat
    GeoReplicationStats: GeoReplicationStatistics
    HttpProtocol: StorageAccountHttpProtocol
    ImmutabilityPolicyProperties: BlobContainerImmutabilityPolicy
    ImmutableStorageAccount.enabled: IsEnabled
    ImmutableStorageWithVersioning.enabled: IsEnabled
    IntervalUnit: ExecutionIntervalUnit
    InventoryRuleType: BlobInventoryRuleType
    IPRule: StorageAccountIPRule
    IssueType: NetworkSecurityPerimeterProvisioningIssueType
    KeyCreationTime: StorageAccountKeyCreationTime
    KeyPermission: StorageAccountKeyPermission
    KeyPolicy: StorageAccountKeyPolicy
    KeySource: StorageAccountKeySource
    KeySource.Microsoft.Keyvault: KeyVault
    KeySource.Microsoft.Storage: Storage
    KeyType: StorageEncryptionKeyType
    KeyVaultProperties: StorageAccountKeyVaultProperties
    LastAccessTimeTrackingPolicy.enable: IsEnabled
    LeaseDuration: StorageLeaseDurationType
    LeaseContainerRequestAction: LeaseContainerAction
    LeaseState: StorageLeaseState
    LeaseStatus: StorageLeaseStatus
    ListAccountSasResponse: GetAccountSasResult
    ListContainersInclude: BlobContainerState
    ListEncryptionScopesInclude: EncryptionScopesIncludeType
    ListServiceSasResponse: GetServiceSasResult
    LocalUser: StorageAccountLocalUser
    LocalUser.properties.allowAclAuthorization: IsAclAuthorizationAllowed
    LocalUser.properties.isNFSv3Enabled: IsNfsV3Enabled
    ManagementPolicy: StorageAccountManagementPolicy
    ManagementPolicyRule.enabled: IsEnabled
    MigrationName: StorageAccountMigrationName
    MigrationState: ImmutableStorageWithVersioningMigrationState
    MigrationStatus: StorageAccountMigrationStatus
    Multichannel.enabled: IsMultiChannelEnabled
    Name: LastAccessTimeTrackingPolicyName
    NetworkRuleSet: StorageAccountNetworkRuleSet
    ObjectReplicationPolicyPropertiesMetrics.enabled: IsMetricsEnabled
    ObjectReplicationPolicyPropertiesPriorityReplication.enabled: IsPriorityReplicationEnabled
    ObjectType: BlobInventoryPolicyObjectType
    Permissions: StorageAccountSasPermission
    PrivateLinkResource: StoragePrivateLinkResourceData
    ProtocolSettings: FileServiceProtocolSettings
    ProtocolSettings.smb: SmbSetting
    ProvisioningIssue: NetworkSecurityPerimeterProvisioningIssue
    ProvisioningIssueProperties: NetworkSecurityPerimeterProvisioningIssueProperties
    PublicAccess: StoragePublicAccessType
    QueueServiceProperties: QueueService
    Reason: StorageAccountNameUnavailableReason
    ReasonCode: StorageRestrictionReasonCode
    ResourceAccessRule: StorageAccountResourceAccessRule
    RestorePolicyProperties: RestorePolicy
    RestorePolicyProperties.enabled: IsEnabled
    RoutingPreference.publishInternetEndpoints: IsInternetEndpointsPublished
    RoutingPreference.publishMicrosoftEndpoints: IsMicrosoftEndpointsPublished
    RuleType: ManagementPolicyRuleType
    RunResult: StorageTaskRunResult
    RunStatusEnum: StorageTaskRunStatus
    SasPolicy: StorageAccountSasPolicy
    Schedule: BlobInventoryPolicySchedule
    Services: StorageAccountSasSignedService
    Severity: NetworkSecurityPerimeterProvisioningIssueSeverity
    ShareAccessTier: FileShareAccessTier
    SignedIdentifier: StorageSignedIdentifier
    SignedResource: ServiceSasSignedResourceType
    SignedResource.b: Blob
    SignedResource.c: Container
    SignedResource.f: File
    SignedResource.s: Share
    SignedResourceTypes: StorageAccountSasSignedResourceType
    SkuConversionStatus: StorageAccountSkuConversionState
    SkuInformationLocationInfoItem: StorageSkuLocationInfo
    SKUCapability: StorageSkuCapability
    State: StorageAccountNetworkRuleState
    StorageAccount.properties.accountMigrationInProgress: IsAccountMigrationInProgress
    StorageAccount.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
    StorageAccount.properties.enableExtendedGroups: IsExtendedGroupEnabled
    StorageAccount.properties.failoverInProgress: IsFailoverInProgress
    StorageAccount.properties.isNfsV3Enabled: IsNfsV3Enabled
    StorageAccount.properties.provisioningState: StorageAccountProvisioningState
    StorageAccountCheckNameAvailabilityParameters: StorageAccountNameAvailabilityContent
    StorageAccountCreateParameters.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
    StorageAccountCreateParameters.properties.enableExtendedGroups: IsExtendedGroupEnabled
    StorageAccountCreateParameters.properties.isNfsV3Enabled: IsNfsV3Enabled
    StorageAccountInternetEndpoints.blob: BlobUri
    StorageAccountInternetEndpoints.dfs: DfsUri
    StorageAccountInternetEndpoints.file: FileUri
    StorageAccountInternetEndpoints.web: WebUri
    StorageAccountListKeysResult: StorageAccountGetKeysResult
    StorageAccountMicrosoftEndpoints.blob: BlobUri
    StorageAccountMicrosoftEndpoints.dfs: DfsUri
    StorageAccountMicrosoftEndpoints.file: FileUri
    StorageAccountMicrosoftEndpoints.queue: QueueUri
    StorageAccountMicrosoftEndpoints.table: TableUri
    StorageAccountMicrosoftEndpoints.web: WebUri
    StorageAccountMigration.type: ResourceType|resource-type
    StorageAccountSkuConversionStatus.endTime: EndOn
    StorageAccountSkuConversionStatus.startTime: StartOn
    StorageAccountUpdateParameters.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
    StorageAccountUpdateParameters.properties.enableExtendedGroups: IsExtendedGroupEnabled
    StorageTaskAssignmentProperties.enabled: IsEnabled
    StorageTaskAssignmentProperties.provisioningState: StorageTaskAssignmentProvisioningState?
    StorageTaskAssignmentUpdateProperties: StorageTaskAssignmentPatchProperties
    StorageTaskAssignmentUpdateProperties.enabled: IsEnabled
    StorageTaskAssignmentUpdateProperties.provisioningState: StorageTaskAssignmentProvisioningState?
    StorageTaskReportProperties.finishTime: FinishedOn|date-time
    StorageTaskReportProperties.startTime: StartedOn|date-time
    Restriction: StorageSkuRestriction
    TableAccessPolicy: StorageTableAccessPolicy
    TableAccessPolicy.expiryTime: ExpireOn
    TableServiceProperties: TableService
    TableSignedIdentifier: StorageTableSignedIdentifier
    TagFilter: ManagementPolicyTagFilter
    TagFilter.op: Operator
    TagProperty: LegalHoldTag
    TriggerParameters: ExecutionTriggerParameters
    TriggerParametersUpdate: ExecutionTriggerParametersUpdate
    TriggerType: TaskExecutionTriggerType
    UpdateHistoryProperty: UpdateHistoryEntry
    UpdateHistoryProperty.update: UpdateType
    VirtualNetworkRule: StorageAccountVirtualNetworkRule
    ZonePlacementPolicy: StorageAccountZonePlacementPolicy

directive:
    - from: swagger-document
      where: $.definitions.FileShareItems.properties.value.items["$ref"]
      transform: return "#/definitions/FileShare"
    - from: swagger-document
      where: $.definitions.ListContainerItems.properties.value.items["$ref"]
      transform: return "#/definitions/BlobContainer"
    - from: swagger-document
      where: $.definitions.ListQueueResource.properties.value.items["$ref"]
      transform: return "#/definitions/StorageQueue"
    - from: swagger-document
      where: $.definitions.BlobRestoreParameters
      transform: >
          $.required = ["timetoRestore", "blobRanges"];
          for (var key in $.properties) {
              var property = $.properties[key];
              delete $.properties[key];
              if (key === 'timeToRestore') {
                  $.properties['timetoRestore'] = property;
                  $.properties['timetoRestore']['x-ms-client-name'] = 'timeToRestore';
              }
              else{
                  $.properties[key] = property;
              }
          }
    # assigning formats
    - from: swagger-document
      where: $.definitions.StorageAccountCheckNameAvailabilityParameters.properties.type
      transform: $["x-ms-format"] = "resource-type";
    - from: swagger-document
      where: $.definitions.DeletedAccountProperties.properties.storageAccountResourceId
      transform: $["x-ms-format"] = "arm-id";
    - from: swagger-document
      where: $.definitions.DeletedAccountProperties.properties.creationTime
      transform: $["format"] = "date-time";
    - from: swagger-document
      where: $.definitions.DeletedAccountProperties.properties.deletionTime
      transform: $["format"] = "date-time";
    - from: swagger-document
      where: $.definitions.StorageAccountProperties.properties.primaryLocation
      transform: $["x-ms-format"] = "azure-location";
    - from: swagger-document
      where: $.definitions.StorageAccountProperties.properties.secondaryLocation
      transform: $["x-ms-format"] = "azure-location";
    - from: swagger-document
      where: $.definitions.StorageAccountSkuConversionStatus.properties.startTime
      transform: $["format"] = "date-time";
    - from: swagger-document
      where: $.definitions.StorageAccountSkuConversionStatus.properties.endTime
      transform: $["format"] = "date-time";
    - from: swagger-document
      where: $.definitions.PrivateLinkResourceProperties.properties.groupId
      transform: $["x-ms-format"] = "arm-id";
    - from: swagger-document
      where: $.definitions.ResourceAccessRule.properties.resourceId
      transform: $["x-ms-format"] = "arm-id";
    - from: swagger-document
      where: $.definitions.VirtualNetworkRule.properties.id
      transform: $["x-ms-format"] = "arm-id";
    - from: swagger-document
      where: $.definitions.Encryption
      transform: $.required = undefined; # this is a fix for swagger issue, and it should be resolved in azure-rest-api-specs/pull/19357
    # this is a temporary fix
    - from: swagger-document
      where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/tableServices/default/tables/{tableName}"].put.parameters
      transform: $[2].required = true
    # convenience change: expand the array result out
    - from: swagger-document
      where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/listKeys"].post
      transform: >
          $["x-ms-pageable"] = {
            "itemName": "keys",
            "nextLinkName": null
          };
    - from: swagger-document
      where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/regenerateKey"].post
      transform: >
          $["x-ms-pageable"] = {
            "itemName": "keys",
            "nextLinkName": null
          };
    - from: swagger-document
      where: $.definitions.StorageAccountCheckNameAvailabilityParameters.properties.type
      transform: $["x-ms-constant"] = true;
    # maxpagesize should be int
    - from: blob.json
      where: $.paths..parameters[?(@.name === "$maxpagesize")]
      transform: >
          $['type'] = "integer";
          $['format'] = "int32";
    - from: file.json
      where: $.paths..parameters[?(@.name === "$maxpagesize")]
      transform: >
          $['type'] = "integer";
          $['format'] = "int32";
    - from: queue.json
      where: $.paths..parameters[?(@.name === "$maxpagesize")]
      transform: >
          $['type'] = "integer";
          $['format'] = "int32";
    # Fix ProvisioningState
    - from: storage.json
      where: $.definitions
      transform: >
          $.StorageAccountProperties.properties.provisioningState['x-ms-enum'] = {
              "name": "StorageAccountProvisioningState",
              "modelAsString": true
            }
    - from: storageTaskAssignments.json
      where: $.definitions
      transform: >
          $.StorageTaskAssignmentProperties.properties.provisioningState['x-ms-enum'] = {
              "name": "StorageTaskAssignmentProvisioningState",
              "modelAsString": true
            };
          $.StorageTaskAssignmentUpdateProperties.properties.provisioningState['x-ms-enum'] = {
              "name": "StorageTaskAssignmentProvisioningState",
              "modelAsString": true
            };
```
