# Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

```yaml
azure-arm: true
csharp: true
namespace: Azure.ResourceManager.Storage
require: https://github.com/Azure/azure-rest-api-specs/blob/438b4eb669efc1e30db9f858e8ec47b2185fc294/specification/storage/resource-manager/readme.md
#tag: package-2025-01
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

# mgmt-debug:
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
    - CorsRules
    - CorsRule
    - CustomDomain
    - DnsEndpointType
    - ListKeyExpand
    - MinimumTlsVersion
    - PermissionScope
    - SshPublicKey
    - PublicNetworkAccess
    - RoutingPreference
    - RoutingChoice
    - UsageName
    - UsageUnit

rename-mapping:
    BlobServiceProperties: BlobService
    QueueServiceProperties: QueueService
    FileServiceProperties: FileService
    TableServiceProperties: TableService
    StorageAccountCheckNameAvailabilityParameters: StorageAccountNameAvailabilityContent
    Multichannel.enabled: IsMultiChannelEnabled
    AccessPolicy.expiryTime: expireOn
    AccountStatus: StorageAccountStatus
    ResourceAccessRule: StorageAccountResourceAccessRule
    NetworkRuleSet: StorageAccountNetworkRuleSet
    VirtualNetworkRule: StorageAccountVirtualNetworkRule
    IPRule: StorageAccountIPRule
    Action: StorageAccountNetworkRuleAction
    State: StorageAccountNetworkRuleState
    Bypass: StorageNetworkBypass
    DefaultAction: StorageNetworkDefaultAction
    EnabledProtocols: FileShareEnabledProtocol
    FileShare.properties.enabledProtocols: enabledProtocol
    Encryption: StorageAccountEncryption
    EncryptionIdentity: StorageAccountEncryptionIdentity
    EncryptionServices: StorageAccountEncryptionServices
    EncryptionService: StorageEncryptionService
    EncryptionService.enabled: IsEnabled
    Endpoints: StorageAccountEndpoints
    KeySource: StorageAccountKeySource
    KeyType: StorageEncryptionKeyType
    KeyPolicy: StorageAccountKeyPolicy
    KeyPermission: StorageAccountKeyPermission
    KeyCreationTime: StorageAccountKeyCreationTime
    KeyVaultProperties: StorageAccountKeyVaultProperties
    Format: BlobInventoryPolicyFormat
    Schedule: BlobInventoryPolicySchedule
    ObjectType: BlobInventoryPolicyObjectType
    LastAccessTimeTrackingPolicy.enable: IsEnabled
    HttpProtocol: StorageAccountHttpProtocol
    Name: LastAccessTimeTrackingPolicyName
    LeaseDuration: StorageLeaseDurationType
    BlobContainer.properties.leaseDuration: LeaseDuration
    FileShare.properties.leaseDuration: LeaseDuration
    ManagementPolicyRule.enabled: IsEnabled
    RuleType: ManagementPolicyRuleType
    Permissions: StorageAccountSasPermission
    Services: StorageAccountSasSignedService
    AccountSasParameters.signedExpiry: SharedAccessExpireOn
    SignedResourceTypes: StorageAccountSasSignedResourceType
    SignedResource: ServiceSasSignedResourceType
    Reason: StorageAccountNameUnavailableReason
    Restriction: StorageSkuRestriction
    ReasonCode: StorageRestrictionReasonCode
    SKUCapability: StorageSkuCapability
    RestorePolicyProperties.enabled: IsEnabled
    SasPolicy: StorageAccountSasPolicy
    ShareAccessTier: FileShareAccessTier
    TagFilter: ManagementPolicyTagFilter
    TagFilter.op: Operator
    TagProperty: LegalHoldTag
    AccessTier: StorageAccountAccessTier
    StorageAccountSkuConversionStatus.startTime: StartOn|date-time
    StorageAccountSkuConversionStatus.endTime: EndOn|date-time
    SkuConversionStatus: StorageAccountSkuConversionState
    PrivateLinkResource: StoragePrivateLinkResourceData
    MigrationState: ImmutableStorageWithVersioningMigrationState
    AccessPolicy: StorageServiceAccessPolicy
    ChangeFeed: BlobServiceChangeFeed
    ChangeFeed.enabled: IsEnabled
    CheckNameAvailabilityResult: StorageAccountNameAvailabilityResult
    CheckNameAvailabilityResult.nameAvailable: IsNameAvailable
    BlobContainer.properties.deleted: IsDeleted
    BlobServiceProperties.properties.automaticSnapshotPolicyEnabled: IsAutomaticSnapshotPolicyEnabled
    FileShare.properties.deleted: IsDeleted
    DeleteRetentionPolicy.enabled: IsEnabled
    ImmutableStorageAccount.enabled: IsEnabled
    ImmutableStorageWithVersioning.enabled: IsEnabled
    BlobInventoryPolicyRule.enabled: IsEnabled
    BlobInventoryPolicySchema.enabled: IsEnabled
    ActiveDirectoryProperties: StorageActiveDirectoryProperties
    AccountType: ActiveDirectoryAccountType
    StorageAccount.properties.failoverInProgress: IsFailoverInProgress
    StorageAccount.properties.isNfsV3Enabled: IsNfsV3Enabled
    StorageAccountCreateParameters.properties.isNfsV3Enabled: IsNfsV3Enabled
    StorageAccount.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
    StorageAccountCreateParameters.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
    StorageAccountUpdateParameters.properties.defaultToOAuthAuthentication: IsDefaultToOAuthAuthentication
    CustomDomain.useSubDomainName: IsUseSubDomainNameEnabled
    RoutingPreference.publishMicrosoftEndpoints: IsMicrosoftEndpointsPublished
    RoutingPreference.publishInternetEndpoints: IsInternetEndpointsPublished
    BlobContainer.properties.denyEncryptionScopeOverride: PreventEncryptionScopeOverride
    BlobInventoryPolicy.properties.policy: PolicySchema
    ProtocolSettings.smb: SmbSetting
    LocalUser: StorageAccountLocalUser
    ManagementPolicy: StorageAccountManagementPolicy
    AzureFilesIdentityBasedAuthentication: FilesIdentityBasedAuthentication
    BlobInventoryPolicyFilter.prefixMatch: IncludePrefix
    AllowedMethods: CorsRuleAllowedMethod
    DefaultSharePermission.StorageFileDataSmbShareReader: Reader
    DefaultSharePermission.StorageFileDataSmbShareContributor: Contributor
    DefaultSharePermission.StorageFileDataSmbShareElevatedContributor: ElevatedContributor
    EncryptionScopeSource.Microsoft.Storage: Storage
    EncryptionScopeSource.Microsoft.KeyVault: KeyVault
    GeoReplicationStats: GeoReplicationStatistics
    InventoryRuleType: BlobInventoryRuleType
    LeaseContainerRequestAction: LeaseContainerAction
    LeaseState: StorageLeaseState
    LeaseStatus: StorageLeaseStatus
    ListAccountSasResponse: GetAccountSasResult
    ListServiceSasResponse: GetServiceSasResult
    ListContainersInclude: BlobContainerState
    RestorePolicyProperties: RestorePolicy
    AccountImmutabilityPolicyProperties: AccountImmutabilityPolicy
    ImmutabilityPolicyProperties: BlobContainerImmutabilityPolicy
    SignedResource.b: Blob
    SignedResource.c: Container
    SignedResource.f: File
    SignedResource.s: Share
    SignedIdentifier: StorageSignedIdentifier
    KeySource.Microsoft.Storage: Storage
    KeySource.Microsoft.Keyvault: KeyVault
    StorageAccountListKeysResult: StorageAccountGetKeysResult
    TableAccessPolicy: StorageTableAccessPolicy
    TableAccessPolicy.expiryTime: ExpireOn
    TableSignedIdentifier: StorageTableSignedIdentifier
    UpdateHistoryProperty: UpdateHistoryEntry
    UpdateHistoryProperty.update: UpdateType
    PublicAccess: StoragePublicAccessType
    Endpoints.blob: BlobUri
    Endpoints.queue: QueueUri
    Endpoints.table: TableUri
    Endpoints.file: FileUri
    Endpoints.web: WebUri
    Endpoints.dfs: DfsUri
    StorageAccountMicrosoftEndpoints.blob: BlobUri
    StorageAccountMicrosoftEndpoints.queue: QueueUri
    StorageAccountMicrosoftEndpoints.table: TableUri
    StorageAccountMicrosoftEndpoints.file: FileUri
    StorageAccountMicrosoftEndpoints.web: WebUri
    StorageAccountMicrosoftEndpoints.dfs: DfsUri
    StorageAccountInternetEndpoints.blob: BlobUri
    StorageAccountInternetEndpoints.file: FileUri
    StorageAccountInternetEndpoints.web: WebUri
    StorageAccountInternetEndpoints.dfs: DfsUri
    FailoverType: StorageAccountFailoverType
    ListEncryptionScopesInclude: EncryptionScopesIncludeType
    StorageAccount.properties.accountMigrationInProgress: IsAccountMigrationInProgress
    StorageAccount.properties.enableExtendedGroups: IsExtendedGroupEnabled
    StorageAccount.properties.provisioningState: StorageAccountProvisioningState
    StorageAccountCreateParameters.properties.enableExtendedGroups: IsExtendedGroupEnabled
    StorageAccountUpdateParameters.properties.enableExtendedGroups: IsExtendedGroupEnabled
    LocalUser.properties.allowAclAuthorization: IsAclAuthorizationAllowed
    LocalUser.properties.isNFSv3Enabled: IsNfsV3Enabled
    StorageAccountMigration.type: ResourceType|resource-type
    IntervalUnit: ExecutionIntervalUnit
    IssueType: NetworkSecurityPerimeterProvisioningIssueType
    MigrationName: StorageAccountMigrationName
    MigrationStatus: StorageAccountMigrationStatus
    ProvisioningIssue: NetworkSecurityPerimeterProvisioningIssue
    ProvisioningIssueProperties: NetworkSecurityPerimeterProvisioningIssueProperties
    RunResult: StorageTaskRunResult
    RunStatusEnum: StorageTaskRunStatus
    Severity: NetworkSecurityPerimeterProvisioningIssueSeverity
    StorageTaskAssignmentUpdateProperties: StorageTaskAssignmentPatchProperties
    StorageTaskAssignmentUpdateProperties.enabled: IsEnabled
    StorageTaskAssignmentUpdateProperties.provisioningState: StorageTaskAssignmentProvisioningState?
    StorageTaskAssignmentProperties.enabled: IsEnabled
    StorageTaskAssignmentProperties.provisioningState: StorageTaskAssignmentProvisioningState?
    StorageTaskReportProperties.startTime: StartedOn|date-time
    StorageTaskReportProperties.finishTime: FinishedOn|date-time
    TriggerParameters: ExecutionTriggerParameters
    TriggerParametersUpdate: ExecutionTriggerParametersUpdate
    TriggerType: TaskExecutionTriggerType
    ExecutionTrigger.type: TaskExecutionTriggerType
    ExecutionTriggerUpdate.type: TaskExecutionTriggerType
    ObjectReplicationPolicyPropertiesMetrics.enabled: IsMetricsEnabled
    AccountLimits: FileServiceAccountLimits
    AccountUsage: FileServiceAccountUsage
    AccountUsageElements: FileServiceAccountUsageElements
    ActiveDirectoryProperties.domainGuid: ActiveDirectoryDomainGuid
    StorageAccountCheckNameAvailabilityParameters.type: -|resource-type
    DeletedAccount.properties.storageAccountResourceId: -|arm-id
    DeletedAccount.properties.creationTime: -|date-time
    DeletedAccount.properties.deletionTime: -|date-time
    StorageAccount.properties.primaryLocation: -|azure-location
    StorageAccount.properties.secondaryLocation: -|azure-location
    PrivateLinkResource.properties.groupId: -|arm-id
    ResourceAccessRule.resourceId: -|arm-id
    VirtualNetworkRule.id: -|arm-id
    EncryptionInTransit.required: IsRequired

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
    - from: swagger-document
      where: $.definitions.Encryption
      transform: $.required = undefined; # this is a fix for swagger issue, and it should be resolved in azure-rest-api-specs/pull/19357
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
    - from: swagger-document
      where: $.paths..parameters[?(@.name === "$maxpagesize")]
      transform: >
          $['type'] = "integer";
          $['format'] = "int32";
    - from: swagger-document
      where: $.paths..parameters[?(@.name === "$maxpagesize")]
      transform: >
          $['type'] = "integer";
          $['format'] = "int32";
    - from: swagger-document
      where: $.paths..parameters[?(@.name === "$maxpagesize")]
      transform: >
          $['type'] = "integer";
          $['format'] = "int32";

    # Fix ProvisioningState
    - from: swagger-document
      where: $.definitions.ProvisioningState
      transform: >
          $['x-ms-enum'] = {
                "name": "StorageAccountProvisioningState",
                "modelAsString": true,
                "values": [
                  {
                    "name": "Creating",
                    "value": "Creating"
                  },
                  {
                    "name": "ResolvingDNS",
                    "value": "ResolvingDNS"
                  },
                  {
                    "name": "Succeeded",
                    "value": "Succeeded"
                  }
                ]
              };
    - from: swagger-document
      where: $.definitions.StorageAccountMigration
      transform: >
          delete $['allOf'];
          $['properties'] = {
            "id": {
              "type": "string",
              "readOnly": true,
              "description": "Migration Resource Id"
            },
            "name": {
              "type": "string",
              "description": "current value is 'default' for customer initiated migration"
            },
            "type": {
              "type": "string",
              "description": "SrpAccountMigrationType in ARM contract which is 'accountMigrations'"
            },
            "properties": {
              "$ref": "#/definitions/StorageAccountMigrationProperties",
              "description": "The properties of a storage account’s ongoing or enqueued migration.",
              "x-ms-client-flatten": true,
              "x-ms-client-name": "StorageAccountMigrationDetails"
            }
          };
```
