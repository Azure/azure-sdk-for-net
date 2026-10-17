import "@typespec/rest";
import "@typespec/http";
import "@typespec/xml";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-client-generator-core";

using Azure.Core;
using TypeSpec.Http;
using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;

namespace Storage.Blob;

@encode(BytesKnownEncoding.base64)
scalar base64Bytes extends bytes;

/**
 * The error response.
 *
 * This defines the wire format only. Language SDKs wrap this in idiomatic error types.
 */
@error
@mediaTypeHint("application/xml")
model Error {
  /** The error code. */
  @header("x-ms-error-code")
  errorCode?: string;

  /** The error code for the copy source. */
  @header("x-ms-copy-source-error-code")
  xMsCopySourceErrorCode?: string;

  /** The status code for the copy source. */
  @header("x-ms-copy-source-status-code")
  xMsCopySourceStatusCode?: int32;

  /** The error code. */
  @Xml.name("Code") code?: StorageErrorCode;

  /** The error message. */
  @Xml.name("Message") message?: string;

  /** The copy source status code. */
  @Xml.name("CopySourceStatusCode") copySourceStatusCode?: int32;

  /** The copy source error code. */
  @Xml.name("CopySourceErrorCode") copySourceErrorCode?: string;

  /** The copy source error message. */
  @Xml.name("CopySourceErrorMessage") copySourceErrorMessage?: string;
}

/** Error codes returned by the Azure Blob Storage service. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
union StorageErrorCode {
  /** Account already exists. */
  AccountAlreadyExists: "AccountAlreadyExists",

  /** Account is being created. */
  AccountBeingCreated: "AccountBeingCreated",

  /** Account is disabled. */
  AccountIsDisabled: "AccountIsDisabled",

  /** Authentication failed. */
  AuthenticationFailed: "AuthenticationFailed",

  /** Authorization failure. */
  AuthorizationFailure: "AuthorizationFailure",

  /** Condition headers not supported. */
  ConditionHeadersNotSupported: "ConditionHeadersNotSupported",

  /** Condition not met. */
  ConditionNotMet: "ConditionNotMet",

  /** Empty metadata key. */
  EmptyMetadataKey: "EmptyMetadataKey",

  /** Incremental copy of an earlier snapshot is not allowed. */
  @added(Versions.v2026_04_06)
  IncrementalCopyOfEarlierSnapshotNotAllowed: "IncrementalCopyOfEarlierSnapshotNotAllowed",

  /** Insufficient account permissions. */
  InsufficientAccountPermissions: "InsufficientAccountPermissions",

  /** Internal error. */
  InternalError: "InternalError",

  /** Invalid authentication information. */
  InvalidAuthenticationInfo: "InvalidAuthenticationInfo",

  /** Invalid header value. */
  InvalidHeaderValue: "InvalidHeaderValue",

  /** Invalid HTTP verb. */
  InvalidHttpVerb: "InvalidHttpVerb",

  /** Invalid input. */
  InvalidInput: "InvalidInput",

  /** Invalid MD5. */
  InvalidMd5: "InvalidMd5",

  /** Invalid metadata. */
  InvalidMetadata: "InvalidMetadata",

  /** Invalid query parameter value. */
  InvalidQueryParameterValue: "InvalidQueryParameterValue",

  /** Invalid range. */
  InvalidRange: "InvalidRange",

  /** Invalid request URL. */
  InvalidRequestUrl: "InvalidRequestUrl",

  /** Invalid resource name. */
  InvalidResourceName: "InvalidResourceName",

  /** Invalid URI. */
  InvalidUri: "InvalidUri",

  /** Invalid XML document. */
  InvalidXmlDocument: "InvalidXmlDocument",

  /** Invalid XML node value. */
  InvalidXmlNodeValue: "InvalidXmlNodeValue",

  /** MD5 mismatch. */
  Md5Mismatch: "Md5Mismatch",

  /** Metadata too large. */
  MetadataTooLarge: "MetadataTooLarge",

  /** Missing content length header. */
  MissingContentLengthHeader: "MissingContentLengthHeader",

  /** Missing required XML node. */
  MissingRequiredXmlNode: "MissingRequiredXmlNode",

  /** Missing required header. */
  MissingRequiredHeader: "MissingRequiredHeader",

  /** Missing required query parameter. */
  MissingRequiredQueryParameter: "MissingRequiredQueryParameter",

  /** Multiple condition headers not supported. */
  MultipleConditionHeadersNotSupported: "MultipleConditionHeadersNotSupported",

  /** No authentication information. */
  NoAuthenticationInformation: "NoAuthenticationInformation",

  /** Operation timed out. */
  OperationTimedOut: "OperationTimedOut",

  /** Out of range input. */
  OutOfRangeInput: "OutOfRangeInput",

  /** Out of range query parameter value. */
  OutOfRangeQueryParameterValue: "OutOfRangeQueryParameterValue",

  /** Request body too large. */
  RequestBodyTooLarge: "RequestBodyTooLarge",

  /** Resource type mismatch. */
  ResourceTypeMismatch: "ResourceTypeMismatch",

  /** Request URL failed to parse. */
  RequestUrlFailedToParse: "RequestUrlFailedToParse",

  /** Resource already exists. */
  ResourceAlreadyExists: "ResourceAlreadyExists",

  /** Resource not found. */
  ResourceNotFound: "ResourceNotFound",

  /** Server busy. */
  ServerBusy: "ServerBusy",

  /** Unsupported header. */
  UnsupportedHeader: "UnsupportedHeader",

  /** Unsupported XML node. */
  UnsupportedXmlNode: "UnsupportedXmlNode",

  /** Unsupported query parameter. */
  UnsupportedQueryParameter: "UnsupportedQueryParameter",

  /** Unsupported HTTP verb. */
  UnsupportedHttpVerb: "UnsupportedHttpVerb",

  /** Append position condition not met. */
  AppendPositionConditionNotMet: "AppendPositionConditionNotMet",

  /** Blob already exists. */
  BlobAlreadyExists: "BlobAlreadyExists",

  /** Blob is immutable due to policy. */
  BlobImmutableDueToPolicy: "BlobImmutableDueToPolicy",

  /** Blob not found. */
  BlobNotFound: "BlobNotFound",

  /** Blob overwritten. */
  BlobOverwritten: "BlobOverwritten",

  /** Blob tier inadequate for content length. */
  BlobTierInadequateForContentLength: "BlobTierInadequateForContentLength",

  /** Blob uses customer specified encryption. */
  BlobUsesCustomerSpecifiedEncryption: "BlobUsesCustomerSpecifiedEncryption",

  /** Block count exceeds limit. */
  BlockCountExceedsLimit: "BlockCountExceedsLimit",

  /** Block list too long. */
  BlockListTooLong: "BlockListTooLong",

  /** Cannot change to lower tier. */
  CannotChangeToLowerTier: "CannotChangeToLowerTier",

  /** Cannot verify copy source. */
  CannotVerifyCopySource: "CannotVerifyCopySource",

  /** Container already exists. */
  ContainerAlreadyExists: "ContainerAlreadyExists",

  /** Container being deleted. */
  ContainerBeingDeleted: "ContainerBeingDeleted",

  /** Container disabled. */
  ContainerDisabled: "ContainerDisabled",

  /** Container not found. */
  ContainerNotFound: "ContainerNotFound",

  /** Content length larger than tier limit. */
  ContentLengthLargerThanTierLimit: "ContentLengthLargerThanTierLimit",

  /** Copy across accounts not supported. */
  CopyAcrossAccountsNotSupported: "CopyAcrossAccountsNotSupported",

  /** Copy ID mismatch. */
  CopyIdMismatch: "CopyIdMismatch",

  /** Feature version mismatch. */
  FeatureVersionMismatch: "FeatureVersionMismatch",

  /** Incremental copy blob mismatch. */
  IncrementalCopyBlobMismatch: "IncrementalCopyBlobMismatch",

  /** Incremental copy of an earlier version snapshot is not allowed. */
  IncrementalCopyOfEarlierVersionSnapshotNotAllowed: "IncrementalCopyOfEarlierVersionSnapshotNotAllowed",

  /** Incremental copy source must be snapshot. */
  IncrementalCopySourceMustBeSnapshot: "IncrementalCopySourceMustBeSnapshot",

  /** Infinite lease duration required. */
  InfiniteLeaseDurationRequired: "InfiniteLeaseDurationRequired",

  /** Invalid blob or block. */
  InvalidBlobOrBlock: "InvalidBlobOrBlock",

  /** Invalid blob tier. */
  InvalidBlobTier: "InvalidBlobTier",

  /** Invalid blob type. */
  InvalidBlobType: "InvalidBlobType",

  /** Invalid block ID. */
  InvalidBlockId: "InvalidBlockId",

  /** Invalid block list. */
  InvalidBlockList: "InvalidBlockList",

  /** Invalid operation. */
  InvalidOperation: "InvalidOperation",

  /** Invalid page range. */
  InvalidPageRange: "InvalidPageRange",

  /** Invalid source blob type. */
  InvalidSourceBlobType: "InvalidSourceBlobType",

  /** Invalid source blob URL. */
  InvalidSourceBlobUrl: "InvalidSourceBlobUrl",

  /** Invalid version for page blob operation. */
  InvalidVersionForPageBlobOperation: "InvalidVersionForPageBlobOperation",

  /** Lease already present. */
  LeaseAlreadyPresent: "LeaseAlreadyPresent",

  /** Lease already broken. */
  LeaseAlreadyBroken: "LeaseAlreadyBroken",

  /** Lease ID mismatch with blob operation. */
  LeaseIdMismatchWithBlobOperation: "LeaseIdMismatchWithBlobOperation",

  /** Lease ID mismatch with container operation. */
  LeaseIdMismatchWithContainerOperation: "LeaseIdMismatchWithContainerOperation",

  /** Lease ID mismatch with lease operation. */
  LeaseIdMismatchWithLeaseOperation: "LeaseIdMismatchWithLeaseOperation",

  /** Lease ID missing. */
  LeaseIdMissing: "LeaseIdMissing",

  /** Lease is breaking and cannot be acquired. */
  LeaseIsBreakingAndCannotBeAcquired: "LeaseIsBreakingAndCannotBeAcquired",

  /** Lease is breaking and cannot be changed. */
  LeaseIsBreakingAndCannotBeChanged: "LeaseIsBreakingAndCannotBeChanged",

  /** Lease is broken and cannot be renewed. */
  LeaseIsBrokenAndCannotBeRenewed: "LeaseIsBrokenAndCannotBeRenewed",

  /** Lease lost. */
  LeaseLost: "LeaseLost",

  /** Lease not present with blob operation. */
  LeaseNotPresentWithBlobOperation: "LeaseNotPresentWithBlobOperation",

  /** Lease not present with container operation. */
  LeaseNotPresentWithContainerOperation: "LeaseNotPresentWithContainerOperation",

  /** Lease not present with lease operation. */
  LeaseNotPresentWithLeaseOperation: "LeaseNotPresentWithLeaseOperation",

  /** Maximum blob size condition not met. */
  MaxBlobSizeConditionNotMet: "MaxBlobSizeConditionNotMet",

  /** No pending copy operation. */
  NoPendingCopyOperation: "NoPendingCopyOperation",

  /** Operation not allowed on incremental copy blob. */
  OperationNotAllowedOnIncrementalCopyBlob: "OperationNotAllowedOnIncrementalCopyBlob",

  /** Pending copy operation. */
  PendingCopyOperation: "PendingCopyOperation",

  /** Previous snapshot not found. */
  PreviousSnapshotNotFound: "PreviousSnapshotNotFound",

  /** Previous snapshot operation not supported. */
  PreviousSnapshotOperationNotSupported: "PreviousSnapshotOperationNotSupported",

  /** Previous snapshot cannot be newer. */
  PreviousSnapshotCannotBeNewer: "PreviousSnapshotCannotBeNewer",

  /** Sequence number condition not met. */
  SequenceNumberConditionNotMet: "SequenceNumberConditionNotMet",

  /** Sequence number increment too large. */
  SequenceNumberIncrementTooLarge: "SequenceNumberIncrementTooLarge",

  /** Snapshot count exceeded. */
  SnapshotCountExceeded: "SnapshotCountExceeded",

  /** Snapshot operation rate exceeded. */
  SnapshotOperationRateExceeded: "SnapshotOperationRateExceeded",

  /** Snapshots present. */
  SnapshotsPresent: "SnapshotsPresent",

  /** Source condition not met. */
  SourceConditionNotMet: "SourceConditionNotMet",

  /** System in use. */
  SystemInUse: "SystemInUse",

  /** Target condition not met. */
  TargetConditionNotMet: "TargetConditionNotMet",

  /** Unauthorized blob overwrite. */
  UnauthorizedBlobOverwrite: "UnauthorizedBlobOverwrite",

  /** Blob being rehydrated. */
  BlobBeingRehydrated: "BlobBeingRehydrated",

  /** Blob archived. */
  BlobArchived: "BlobArchived",

  /** Blob not archived. */
  BlobNotArchived: "BlobNotArchived",

  /** Authorization source IP mismatch. */
  AuthorizationSourceIPMismatch: "AuthorizationSourceIPMismatch",

  /** Authorization protocol mismatch. */
  AuthorizationProtocolMismatch: "AuthorizationProtocolMismatch",

  /** Authorization permission mismatch. */
  AuthorizationPermissionMismatch: "AuthorizationPermissionMismatch",

  /** Authorization service mismatch. */
  AuthorizationServiceMismatch: "AuthorizationServiceMismatch",

  /** Authorization resource type mismatch. */
  AuthorizationResourceTypeMismatch: "AuthorizationResourceTypeMismatch",

  /** Blob access tier not supported for account type. */
  BlobAccessTierNotSupportedForAccountType: "BlobAccessTierNotSupportedForAccountType",

  /** Extensible. */
  string,
}

/// Models

/** Represents a single block in a block blob. */
model Block {
  /** The base64 encoded block ID. */
  @Xml.name("Name")
  name: base64Bytes;

  /** The block size in bytes. */
  @Xml.name("Size")
  size: int64;
}

/** Contains the committed and uncommitted blocks in a block blob. */
model BlockList {
  /** The list of committed blocks. */
  @Xml.name("CommittedBlocks")
  committedBlocks?: Block[];

  /** The list of uncommitted blocks. */
  @Xml.name("UncommittedBlocks")
  uncommittedBlocks?: Block[];
}

/** The block lookup list. */
@Xml.name("BlockList")
model BlockLookupList {
  /** The committed blocks. */
  @Xml.unwrapped
  @Xml.name("Committed")
  committed?: base64Bytes[];

  /** The uncommitted blocks. */
  @Xml.unwrapped
  @Xml.name("Uncommitted")
  uncommitted?: base64Bytes[];

  /** The latest blocks. */
  @Xml.unwrapped
  @Xml.name("Latest")
  latest?: base64Bytes[];
}

/** List of signed identifiers. */
model SignedIdentifiers {
  /** The list of signed identifiers. */
  @Xml.unwrapped
  @Xml.name("SignedIdentifier")
  items: Array<SignedIdentifier>;
}

/** A signed identifier. */
@Xml.name("SignedIdentifier")
model SignedIdentifier {
  /** The unique ID for the signed identifier. */
  @Xml.name("Id") id: string;

  /** The access policy for the signed identifier. */
  @Xml.name("AccessPolicy") accessPolicy?: AccessPolicy;
}

/** The result of the Find Blobs by Tags API. */
#suppress "@azure-tools/typespec-client-generator-core/csharp-model-suffix" "Name kept for backward compatibility"
@Xml.name("EnumerationResults")
model FilteredBlobResponse {
  /** The service endpoint. */
  @Xml.attribute
  @Xml.name("ServiceEndpoint")
  serviceEndpoint: string;

  /** The filter expression for the blobs. */
  @Xml.name("Where") where: string;

  /** The list of filtered blobs. */
  @pageItems
  @Xml.name("Blobs")
  blobItems: FilterBlobItem[];

  /** An opaque string value that identifies the portion of the result set to be returned with the next operation. Use this value in the next request to continue the listing operation. */
  @continuationToken
  @Xml.name("NextMarker")
  nextMarker?: string;
}

/** The filtered blob item. */
@Xml.name("Blob")
model FilterBlobItem {
  /** The name of the blob. */
  @Xml.name("Name") name: string;

  /** The name of the container. */
  @Xml.name("ContainerName") containerName: string;

  /** The tags of the blob. */
  @Xml.name("Tags") tags?: BlobTags;

  /** The version ID of the blob. */
  @Xml.name("VersionId") versionId?: string;

  /** Whether it is the current version of the blob. */
  @Xml.name("IsCurrentVersion") isCurrentVersion?: boolean;
}

/** Specifies what additional information should be returned as part of the list operation. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum ListContainersIncludeType {
  /** Include metadata. */
  metadata: "metadata",

  /** Include soft-deleted containers. */
  deleted: "deleted",

  /** Include system containers. */
  system: "system",
}

/** Specifies what type of blobs should be returned as part of the filter operation. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum FilterBlobsIncludeItem {
  /** The filter includes no versions. */
  None: "none",

  /** The filter includes versions. */
  Versions: "versions",
}

/** The account kind. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum AccountKind {
  /** A general-purpose account. */
  Storage: "Storage",

  /** A blob storage account. */
  BlobStorage: "BlobStorage",

  /** A storage V2 account. */
  StorageV2: "StorageV2",

  /** A file storage account. */
  FileStorage: "FileStorage",

  /** A block blob storage account. */
  BlockBlobStorage: "BlockBlobStorage",
}

/** The account SKU. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum SkuName {
  /** The standard LRS SKU. */
  StandardLRS: "Standard_LRS",

  /** The standard GRS SKU. */
  StandardGRS: "Standard_GRS",

  /** The standard RAGRS SKU. */
  StandardRAGRS: "Standard_RAGRS",

  /** The standard ZRS SKU. */
  StandardZRS: "Standard_ZRS",

  /** The premium LRS SKU. */
  PremiumLRS: "Premium_LRS",

  /** The standard GZRS SKU. */
  @added(Versions.v2026_04_06)
  StandardGZRS: "Standard_GZRS",

  /** The premium ZRS SKU. */
  @added(Versions.v2026_04_06)
  PremiumZRS: "Premium_ZRS",

  /** The standard RAGZRS SKU. */
  @added(Versions.v2026_04_06)
  StandardRAGZRS: "Standard_RAGZRS",
}

/** The result of the List Containers API. */
#suppress "@azure-tools/typespec-client-generator-core/csharp-model-suffix" "Name kept for backward compatibility"
@Xml.name("EnumerationResults")
model ListContainersResponse {
  /** The service endpoint. */
  @Xml.attribute
  @Xml.name("ServiceEndpoint")
  serviceEndpoint: string;

  /** The prefix of the containers. */
  @Xml.name("Prefix") prefix?: string;

  /** An opaque string value that identifies the portion of the result set returned with this operation. */
  @Xml.name("Marker") marker?: string;

  /** The maximum number of containers to be returned with this operation. */
  @Xml.name("MaxResults") maxResults?: int32;

  /** The list of containers. */
  @pageItems
  @Xml.name("Containers")
  containerItems: ContainerItem[];

  /** An opaque string value that identifies the portion of the result set to be returned with the next operation. Use this value in the next request to continue the listing operation. */
  #suppress "@azure-tools/typespec-azure-core/casing-style" "Existing API. The casing is correct."
  @continuationToken
  @Xml.name("NextMarker")
  NextMarker?: string;
}

/** Represents a container. */
@Xml.name("Container")
model ContainerItem {
  /** The name of the container. */
  @Xml.name("Name") name: string;

  /** Whether the container is soft-deleted. */
  @Xml.name("Deleted") deleted?: boolean;

  /** The version of the container. */
  @Xml.name("Version") version?: string;

  /** The properties of the container. */
  @Xml.name("Properties") properties: ContainerProperties;

  /** The metadata of the container. */
  #suppress "@azure-tools/typespec-autorest/unsupported-param-type" "Existing API"
  @Xml.name("Metadata") metadata?: Record<string>;
}

/** The properties of a container. */
model ContainerProperties {
  /** The date-time that the container was last modified. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("Last-Modified")
  lastModified: utcDateTime;

  /** The ETag of the container. */
  @Xml.name("Etag") eTag: Azure.Core.eTag;

  /** The lease status of the container. */
  @Xml.name("LeaseStatus") leaseStatus?: LeaseStatus;

  /** The lease state of the container. */
  @Xml.name("LeaseState") leaseState?: LeaseState;

  /** The lease duration of the container. */
  @Xml.name("LeaseDuration") leaseDuration?: LeaseDuration;

  /** The public access type of the container. */
  @Xml.name("PublicAccess") publicAccess?: PublicAccessType;

  /** Whether the container has an immutability policy. */
  @Xml.name("HasImmutabilityPolicy") hasImmutabilityPolicy?: boolean;

  /** Whether the container has a legal hold. */
  @Xml.name("HasLegalHold") hasLegalHold?: boolean;

  /** The default encryption scope of the container. */
  @Xml.name("DefaultEncryptionScope") defaultEncryptionScope?: string;

  /** Whether to prevent encryption scope override. */
  @Xml.name("DenyEncryptionScopeOverride")
  preventEncryptionScopeOverride?: boolean;

  /** The date-time the container was deleted. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("DeletedTime")
  deletedTime?: utcDateTime;

  /** The remaining retention days of the container. */
  @Xml.name("RemainingRetentionDays") remainingRetentionDays?: int32;

  /** Whether immutable storage with versioning is enabled. */
  @Xml.name("ImmutableStorageWithVersioningEnabled")
  isImmutableStorageWithVersioningEnabled?: boolean;
}

/** Stats for the storage service. */
model StorageServiceStats {
  /** The geo-replication stats. */
  @Xml.name("GeoReplication") geoReplication?: GeoReplication;
}

/** Geo-replication information for the secondary storage service. */
model GeoReplication {
  /** The status of the secondary location. */
  @Xml.name("Status") status: GeoReplicationStatusType;

  /** A date-time value that indicates where all primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("LastSyncTime")
  lastSyncTime: utcDateTime;
}

/** The geo-replication status. */
union GeoReplicationStatusType {
  /** Geo-replication is live. */
  Live: "live",

  /** Geo-replication is bootstrap. */
  Bootstrap: "bootstrap",

  /** Geo-replication is unavailable. */
  Unavailable: "unavailable",

  /** Extensible. */
  string,
}

/** Key information. */
model KeyInfo {
  /** The date-time the key is active. */
  @Xml.name("Start") start: utcDateTime;

  /** The date-time the key expires. */
  @Xml.name("Expiry") expiry: utcDateTime;

  /** The delegated user tenant ID in Entra ID. */
  @Xml.name("DelegatedUserTid")
  @added(Versions.v2026_04_06)
  delegatedUserTid?: uuid;
}

/** A user delegation key. */
model UserDelegationKey {
  /** The Entra ID object ID in GUID format. */
  @Xml.name("SignedOid") signedOid: uuid;

  /** The Entra ID tenant ID in GUID format. */
  @Xml.name("SignedTid") signedTid: uuid;

  /** The date-time the key is active. */
  @Xml.name("SignedStart")
  signedStart: utcDateTime;

  /** The date-time the key expires. */
  @Xml.name("SignedExpiry")
  signedExpiry: utcDateTime;

  /** Abbreviation of the Azure Storage service that accepts the key. */
  @Xml.name("SignedService") signedService: string;

  /** The service version that created the key. */
  @Xml.name("SignedVersion") signedVersion: string;

  /** The delegated user tenant ID in Entra ID. Returned if DelegatedUserTid is specified. */
  @Xml.name("SignedDelegatedUserTid")
  @added(Versions.v2026_04_06)
  signedDelegatedUserTid?: uuid;

  /** The base64 encoded key value. */
  @Xml.name("Value")
  value: base64Bytes;
}

/** The public access type. */
union PublicAccessType {
  /** Blob access. */
  Blob: "blob",

  /** Container access. */
  Container: "container",

  /** Extensible. */
  string,
}

/** The copy status. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum CopyStatus {
  /** The copy operation is pending. */
  Pending: "pending",

  /** The copy operation succeeded. */
  Success: "success",

  /** The copy operation failed. */
  Failed: "failed",

  /** The copy operation was aborted. */
  Aborted: "aborted",
}

/** The lease duration. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum LeaseDuration {
  /** The lease is of infinite duration. */
  Infinite: "infinite",

  /** The lease is of fixed duration. */
  Fixed: "fixed",
}

/** The lease state. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum LeaseState {
  /** The lease is available. */
  Available: "available",

  /** The lease is currently leased. */
  Leased: "leased",

  /** The lease is expired. */
  Expired: "expired",

  /** The lease is breaking. */
  Breaking: "breaking",

  /** The lease is broken. */
  Broken: "broken",
}

/** The lease status. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum LeaseStatus {
  /** The lease is unlocked. */
  Unlocked: "unlocked",

  /** The lease is locked. */
  Locked: "locked",
}

/** Represents an access policy. */
model AccessPolicy {
  /** The date-time the policy is active. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "rfc3339-fixed-width is required because the Blob service rejects timestamps that do not have exactly 7 fractional-second digits. Without this encoding the Rust time crate drops trailing zeros, producing variable precision (e.g. 6 digits instead of 7) which causes the service to return InvalidXmlDocument (HTTP 400)."
  #suppress "@azure-tools/typespec-autorest/unknown-format" "rfc3339-fixed-width is required because the Blob service rejects timestamps that do not have exactly 7 fractional-second digits. Without this encoding the Rust time crate drops trailing zeros, producing variable precision (e.g. 6 digits instead of 7) which causes the service to return InvalidXmlDocument (HTTP 400)."
  @Xml.name("Start")
  @encode("rfc3339-fixed-width")
  start?: utcDateTime;

  /** The date-time the policy expires. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "rfc3339-fixed-width is required because the Blob service rejects timestamps that do not have exactly 7 fractional-second digits. Without this encoding the Rust time crate drops trailing zeros, producing variable precision (e.g. 6 digits instead of 7) which causes the service to return InvalidXmlDocument (HTTP 400)."
  #suppress "@azure-tools/typespec-autorest/unknown-format" "rfc3339-fixed-width is required because the Blob service rejects timestamps that do not have exactly 7 fractional-second digits. Without this encoding the Rust time crate drops trailing zeros, producing variable precision (e.g. 6 digits instead of 7) which causes the service to return InvalidXmlDocument (HTTP 400)."
  @Xml.name("Expiry")
  @encode("rfc3339-fixed-width")
  expiry?: utcDateTime;

  /** The permissions for the policy. */
  @Xml.name("Permission") permission?: string;
}

/** The access tiers. */
union AccessTier {
  /** The P4 access tier. */
  P4: "P4",

  /** The P6 access tier. */
  P6: "P6",

  /** The P10 access tier. */
  P10: "P10",

  /** The P15 access tier. */
  P15: "P15",

  /** The P20 access tier. */
  P20: "P20",

  /** The P30 access tier. */
  P30: "P30",

  /** The P40 access tier. */
  P40: "P40",

  /** The P50 access tier. */
  P50: "P50",

  /** The P60 access tier. */
  P60: "P60",

  /** The P70 access tier. */
  P70: "P70",

  /** The P80 access tier. */
  P80: "P80",

  /** The Hot access tier. */
  Hot: "Hot",

  /** The Cool access tier. */
  Cool: "Cool",

  /** The Archive access tier. */
  Archive: "Archive",

  /** The Premium access tier. */
  Premium: "Premium",

  /** The Cold access tier. */
  Cold: "Cold",

  /** The Smart access tier. */
  @added(Versions.v2026_06_06)
  Smart: "Smart",

  /** Extensible. */
  string,
}

/** The archive status. */
union ArchiveStatus {
  /** The archive status is rehydrating pending to Hot. */
  RehydratePendingToHot: "rehydrate-pending-to-hot",

  /** The archive status is rehydrating pending to Cool. */
  RehydratePendingToCool: "rehydrate-pending-to-cool",

  /** The archive status is rehydrating pending to Cold. */
  RehydratePendingToCold: "rehydrate-pending-to-cold",

  /** The archive status is rehydrating pending to Smart. */
  @added(Versions.v2026_06_06)
  RehydratePendingToSmart: "rehydrate-pending-to-smart",

  /** Extensible. */
  string,
}

/** Represents a blob. */
@Xml.name("Blob")
model BlobItem {
  /** The name of the blob. */
  @Xml.name("Name") name: BlobName;

  /** Whether the blob is deleted. */
  @Xml.name("Deleted") deleted: boolean;

  /** The snapshot of the blob. */
  @Xml.name("Snapshot") snapshot: string;

  /** The version ID of the blob. */
  @Xml.name("VersionId") versionId?: string;

  /** Whether the blob is the current version. */
  @Xml.name("IsCurrentVersion") isCurrentVersion?: boolean;

  /** The properties of the blob. */
  @Xml.name("Properties") properties: BlobProperties;

  /** The metadata of the blob. */
  @Xml.name("Metadata") metadata?: BlobMetadata;

  /** The tags of the blob. */
  @Xml.name("Tags") blobTags?: BlobTags;

  /** The object replication metadata of the blob. */
  #suppress "@azure-tools/typespec-autorest/unsupported-param-type" "Existing API"
  @Xml.name("OrMetadata")
  objectReplicationMetadata?: ObjectReplicationMetadata;

  /** Whether the blob has versions only. */
  @Xml.name("HasVersionsOnly") hasVersionsOnly?: boolean;
}

/** The properties of a blob. */
@Xml.name("Properties")
model BlobProperties {
  /** The date-time the blob was created. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("Creation-Time")
  creationTime?: utcDateTime;

  /** The date-time the blob was last modified. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("Last-Modified")
  lastModified: utcDateTime;

  /** The blob ETag. */
  @Xml.name("Etag") eTag: Azure.Core.eTag;

  /** The content length of the blob. */
  @Xml.name("Content-Length") contentLength?: int64;

  /** The content type of the blob. */
  @Xml.name("Content-Type") contentType?: string;

  /** The content encoding of the blob. */
  @Xml.name("Content-Encoding") contentEncoding?: string;

  /** The content language of the blob. */
  @Xml.name("Content-Language") contentLanguage?: string;

  /** The content MD5 of the blob. */
  @Xml.name("Content-MD5") contentMd5?: bytes;

  /** The content disposition of the blob. */
  @Xml.name("Content-Disposition") contentDisposition?: string;

  /** The cache control of the blob. */
  @Xml.name("Cache-Control") cacheControl?: string;

  /** The sequence number of the blob. */
  @Xml.name("x-ms-blob-sequence-number") blobSequenceNumber?: int64;

  /** The blob type. */
  @Xml.name("BlobType") blobType?: BlobType;

  /** The lease status of the blob. */
  @Xml.name("LeaseStatus") leaseStatus?: LeaseStatus;

  /** The lease state of the blob. */
  @Xml.name("LeaseState") leaseState?: LeaseState;

  /** The lease duration of the blob. */
  @Xml.name("LeaseDuration") leaseDuration?: LeaseDuration;

  /** The copy ID of the blob. */
  @Xml.name("CopyId") copyId?: string;

  /** The copy status of the blob. */
  @Xml.name("CopyStatus") copyStatus?: CopyStatus;

  /** The copy source of the blob. */
  @Xml.name("CopySource") copySource?: string;

  /** The copy progress of the blob. */
  @Xml.name("CopyProgress") copyProgress?: string;

  /** The copy completion date-time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("CopyCompletionTime")
  copyCompletionTime?: utcDateTime;

  /** The copy status description of the blob. */
  @Xml.name("CopyStatusDescription") copyStatusDescription?: string;

  /** Whether the blob is encrypted on the server. */
  @Xml.name("ServerEncrypted") serverEncrypted?: boolean;

  /** Whether the blob is an incremental copy. */
  @Xml.name("IncrementalCopy") incrementalCopy?: boolean;

  /** The name of the destination snapshot. */
  @Xml.name("DestinationSnapshot") destinationSnapshot?: string;

  /** The date-time the blob was deleted. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("DeletedTime")
  deletedTime?: utcDateTime;

  /** The remaining retention days of the blob. */
  @Xml.name("RemainingRetentionDays") remainingRetentionDays?: int32;

  /** The access tier of the blob. */
  @Xml.name("AccessTier") accessTier?: AccessTier;

  /** Whether the access tier is inferred. */
  @Xml.name("AccessTierInferred") accessTierInferred?: boolean;

  /** The archive status of the blob. */
  @Xml.name("ArchiveStatus") archiveStatus?: ArchiveStatus;

  /** The smart access tier of the blob. */
  @added(Versions.v2026_06_06)
  @Xml.name("SmartAccessTier")
  smartAccessTier?: AccessTier;

  /** The SHA-256 hash of the blob's encryption key, if provided. */
  @Xml.name("CustomerProvidedKeySha256") customerProvidedKeySha256?: string;

  /** The encryption scope of the blob. */
  @Xml.name("EncryptionScope") encryptionScope?: string;

  /** The date-time that the access tier of the blob changed. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("AccessTierChangeTime")
  accessTierChangeTime?: utcDateTime;

  /** The number of tags for the blob. */
  @Xml.name("TagCount") tagCount?: int32;

  /** The expiry time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("Expiry-Time")
  expiresOn?: utcDateTime;

  /** Whether the blob is sealed. */
  @Xml.name("Sealed")
  isSealed?: boolean;

  /** The rehydrate priority of the blob. */
  @Xml.name("RehydratePriority") rehydratePriority?: RehydratePriority;

  /** The date-time the blob was last accessed. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("LastAccessTime")
  lastAccessedOn?: utcDateTime;

  /** The date-time the immutability policy of the blob expires. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("ImmutabilityPolicyUntilDate")
  immutabilityPolicyExpiresOn?: utcDateTime;

  /** The immutability policy mode of the blob. */
  @Xml.name("ImmutabilityPolicyMode")
  immutabilityPolicyMode?: ImmutabilityPolicyMode;

  /** Whether the blob is under legal hold. */
  @Xml.name("LegalHold") legalHold?: boolean;
}

/** The immutability policy mode. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum ImmutabilityPolicyMode {
  /** Response only. The immutability policy is mutable. */
  Mutable: "mutable",

  /** The immutability policy is locked. */
  Locked: "locked",

  /** The immutability policy is unlocked. */
  Unlocked: "unlocked",
}

/** The blob type. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum BlobType {
  /** The blob is a block blob. */
  BlockBlob: "BlockBlob",

  /** The blob is a page blob. */
  PageBlob: "PageBlob",

  /** The blob is an append blob. */
  AppendBlob: "AppendBlob",
}

/** The priority of the rehydrate operation. */
@Xml.name("RehydratePriority")
union RehydratePriority {
  /** The rehydrate priority is high. */
  High: "High",

  /** The rehydrate priority is standard. */
  Standard: "Standard",

  /** Extensible. */
  string,
}

/** The blob metadata. */
#suppress "@azure-tools/typespec-autorest/unsupported-param-type" "Existing API"
#suppress "@azure-tools/typespec-azure-core/bad-record-type" "Existing API"
model BlobMetadata is Record<string> {
  /** Whether the blob metadata is encrypted. */
  @Xml.attribute
  @Xml.name("Encrypted")
  encrypted?: string;
}

/** A key-value pair associated with a blob. */
@Xml.name("Tag")
model BlobTag {
  /** The key of the tag. */
  @Xml.name("Key") key: string;

  /** The value of the tag. */
  @Xml.name("Value") value: string;
}

/** The object replication metadata. */
#suppress "@azure-tools/typespec-autorest/unsupported-param-type" "Existing API"
@Xml.name("OrMetadata")
model ObjectReplicationMetadata is Record<string>;

/// Service Properties

/** The blob service properties. */
@Xml.name("StorageServiceProperties")
model BlobServiceProperties {
  /** The logging properties. */
  @Xml.name("Logging") logging?: Logging;

  /** The hour metrics properties. */
  @Xml.name("HourMetrics") hourMetrics?: Metrics;

  /** The minute metrics properties. */
  @Xml.name("MinuteMetrics") minuteMetrics?: Metrics;

  /** The CORS properties. */
  @Xml.name("Cors") cors?: CorsRule[];

  /** The default service version. */
  @Xml.name("DefaultServiceVersion") defaultServiceVersion?: string;

  /** The delete retention policy. */
  @Xml.name("DeleteRetentionPolicy") deleteRetentionPolicy?: RetentionPolicy;

  /** The static website properties. */
  @Xml.name("StaticWebsite") staticWebsite?: StaticWebsite;
}

/** The properties that enable an account to host a static website. */
model StaticWebsite {
  /** Indicates whether this account is hosting a static website. */
  @Xml.name("Enabled") enabled: boolean;

  /** The index document. */
  @Xml.name("IndexDocument") indexDocument?: string;

  /** The error document. */
  @Xml.name("ErrorDocument404Path") errorDocument404Path?: string;

  /** Absolute path of the default index page. */
  @Xml.name("DefaultIndexDocumentPath") defaultIndexDocumentPath?: string;
}

/** A Cross-Origin Resource Sharing (CORS) rule. */
@Xml.name("CorsRule")
model CorsRule {
  /** The allowed origins. */
  @Xml.name("AllowedOrigins") allowedOrigins: string;

  /** The allowed methods. */
  @Xml.name("AllowedMethods") allowedMethods: string;

  /** The allowed headers. */
  @Xml.name("AllowedHeaders") allowedHeaders: string;

  /** The exposed headers. */
  @Xml.name("ExposedHeaders") exposedHeaders: string;

  /** The maximum age in seconds. */
  @Xml.name("MaxAgeInSeconds")
  @minValue(0)
  maxAgeInSeconds: int32;
}

/** The metrics properties. */
model Metrics {
  /** The version of the metrics properties. */
  @Xml.name("Version") version?: string;

  /** Whether the metrics are enabled. */
  @Xml.name("Enabled") enabled: boolean;

  /** Whether to include API in the metrics. */
  @Xml.name("IncludeAPIs") includeApis?: boolean;

  /** The retention policy of the metrics. */
  @Xml.name("RetentionPolicy") retentionPolicy?: RetentionPolicy;
}

/** Azure Analytics logging settings. */
model Logging {
  /** The version of the logging properties. */
  @Xml.name("Version") version: string;

  /** Whether delete operation is logged. */
  @Xml.name("Delete") delete: boolean;

  /** Whether read operation is logged. */
  @Xml.name("Read") read: boolean;

  /** Whether write operation is logged. */
  @Xml.name("Write") write: boolean;

  /** The retention policy of the logs. */
  @Xml.name("RetentionPolicy") retentionPolicy: RetentionPolicy;
}

/** The retention policy. */
model RetentionPolicy {
  /** Whether the policy is enabled. */
  @Xml.name("Enabled") enabled: boolean;

  /** The number of days to retain the logs. */
  @Xml.name("Days")
  @minValue(1)
  days?: int32;

  /** Whether to allow permanent delete. */
  @Xml.name("AllowPermanentDelete") allowPermanentDelete?: boolean;
}

// List Blobs

/** The result of the List Blobs API. */
#suppress "@azure-tools/typespec-client-generator-core/csharp-model-suffix" "Name kept for backward compatibility"
@Xml.name("EnumerationResults")
model ListBlobsResponse {
  /** The service endpoint. */
  @Xml.attribute
  @Xml.name("ServiceEndpoint")
  serviceEndpoint: string;

  /** The container name. */
  @Xml.attribute
  @Xml.name("ContainerName")
  containerName: string;

  /** The prefix of the list operation. */
  @Xml.name("Prefix") prefix?: string;

  /** An opaque string value that identifies the portion of the result set returned with this operation. */
  @Xml.name("Marker") marker?: string;

  /** The maximum number of blobs to be returned with this operation. */
  @Xml.name("MaxResults") maxResults?: int32;

  /** The list of blobs. */
  @pageItems
  @Xml.name("Blobs")
  blobItems: BlobItem[];

  /** An opaque string value that identifies the portion of the result set to be returned with the next operation. Use this value in the next request to continue the listing operation. */
  @continuationToken
  @Xml.name("NextMarker")
  nextMarker?: string;
}

/** The result of the Get Pages API. */
model PageList {
  /** The page ranges. */
  @pageItems
  @Xml.unwrapped
  @Xml.name("PageRange")
  pageRange?: PageRange[];

  /** The clear ranges. */
  @Xml.unwrapped
  @Xml.name("ClearRange")
  clearRange?: ClearRange[];

  /** An opaque string value that identifies the portion of the result set to be returned with the next operation. Use this value in the next request to continue the listing operation. */
  @continuationToken
  @Xml.name("NextMarker")
  nextMarker?: string;
}

/** A page range. */
model PageRange {
  /** The start of the byte range. */
  @Xml.name("Start") start: int64;

  /** The end of the byte range. */
  @Xml.name("End") end: int64;
}

/** A clear range. */
model ClearRange {
  /** The start of the byte range. */
  @Xml.name("Start") start: int64;

  /** The end of the byte range. */
  @Xml.name("End") end: int64;
}

/** A list of blob tags. */
@Xml.name("Tags")
model BlobTags {
  /** A list of blob tags. */
  @Xml.name("TagSet") blobTagSet: BlobTag[];
}

/** The query request type. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum QueryRequestType {
  /** The SQL request query type. */
  SQL: "SQL",
}

/** Groups the set of query request settings. */
#suppress "@azure-tools/typespec-client-generator-core/csharp-model-suffix" "Name kept for backward compatibility"
model QueryRequest {
  /** Required. The type of the provided query expression. */
  @Xml.name("QueryType") queryType: QueryRequestType;

  /** The query expression. The maximum size of the query expression is 256KiB. */
  @Xml.name("Expression") expression: string;

  /** The input serialization settings. */
  @Xml.name("InputSerialization") inputSerialization?: QuerySerialization;

  /** The output serialization settings. */
  @Xml.name("OutputSerialization") outputSerialization?: QuerySerialization;
}

/** The query serialization settings. */
model QuerySerialization {
  /** The query format. */
  @Xml.name("Format") format: QueryFormat;
}

/** The query format settings. */
model QueryFormat {
  /** The query type. */
  @Xml.name("Type") type: QueryType;

  /** The delimited text configuration. */
  @Xml.name("DelimitedTextConfiguration")
  delimitedTextConfiguration?: DelimitedTextConfiguration;

  /** The JSON text configuration. */
  @Xml.name("JsonTextConfiguration")
  jsonTextConfiguration?: JsonTextConfiguration;

  /** The Apache Arrow configuration. */
  @Xml.name("ArrowConfiguration") arrowConfiguration?: ArrowConfiguration;

  /** The Parquet configuration. */
  #suppress "@azure-tools/typespec-azure-core/bad-record-type" "Existing API"
  @Xml.name("ParquetTextConfiguration")
  parquetTextConfiguration?: ParquetConfiguration;
}

/** Represents the delimited text configuration. */
model DelimitedTextConfiguration {
  /** The string used to separate columns. */
  @Xml.name("ColumnSeparator") columnSeparator?: string;

  /** The string used to quote a specific field. */
  @Xml.name("FieldQuote") fieldQuote?: string;

  /** The string used to separate records. */
  @Xml.name("RecordSeparator") recordSeparator?: string;

  /** The string used to escape a quote character in a field. */
  @Xml.name("EscapeChar") escapeChar?: string;

  /** Represents whether the data has headers. */
  @Xml.name("HasHeaders") headersPresent?: boolean;
}

/** Represents the JSON text configuration. */
model JsonTextConfiguration {
  /** The string used to separate records. */
  @Xml.name("RecordSeparator") recordSeparator?: string;
}

/** Represents the Apache Arrow configuration. */
model ArrowConfiguration {
  /** The Apache Arrow schema. */
  @Xml.name("Schema") schema: ArrowField[];
}

/** Represents an Apache Arrow field. */
@Xml.name("Field")
model ArrowField {
  /** The arrow field type. */
  @Xml.name("Type") type: string;

  /** The arrow field name. */
  @Xml.name("Name") name?: string;

  /** The arrow field precision. */
  @Xml.name("Precision") precision?: int32;

  /** The arrow field scale. */
  @Xml.name("Scale") scale?: int32;
}

/** Represents the Parquet configuration. */
#suppress "@azure-tools/typespec-azure-core/bad-record-type" "Existing API"
model ParquetConfiguration is Record<unknown>;

/** The query format type. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
@Xml.name("Type")
enum QueryType {
  /** The query format type is delimited. */
  Delimited: "delimited",

  /** The query format type is JSON. */
  JSON: "json",

  /** The query format type is Apache Arrow. */
  Arrow: "arrow",

  /** The query format type is Parquet. */
  Parquet: "parquet",
}

/// Parameters

/** The blob append offset response header. */
alias BlobAppendOffsetResponseHeader = {
  /** The offset at which the block was committed, in bytes. */
  @header("x-ms-blob-append-offset")
  blobAppendOffset?: string;
};

/** The blob condition append position parameter. */
alias BlobConditionAppendPosParameter = {
  /** A byte offset where the operation will only succeed if the append position is equal. If not, the request will fail with AppendPositionConditionNotMet. */
  @header("x-ms-blob-condition-appendpos")
  appendPosition?: int64;
};

/** The blob condition max size parameter. */
alias BlobConditionMaxSizeParameter = {
  /** The max length of the blob. If the operation would cause the blob to exceed that limit or if the blob size is already greater than the value specified, the request will fail with MaxBlobSizeConditionNotMet. */
  @header("x-ms-blob-condition-maxsize")
  maxSize?: int64;
};

/** The sequence number action parameter. */
alias SequenceNumberActionParameter = {
  /** Required if the blob sequence number is provided. This property indicates how the service should modify the blob's sequence number. */
  @header("x-ms-sequence-number-action")
  sequenceNumberAction: SequenceNumberActionType;
};

/** The sequence number actions. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum SequenceNumberActionType {
  /** Increment the sequence number. */
  Increment: "increment",

  /** Set the maximum for the sequence number. */
  Max: "max",

  /** Update the sequence number. */
  Update: "update",
}

/** The sequence number parameter. */
alias SequenceNumberParameter = {
  /** A value that can be used to track the request. The value of the sequence number must be between 0 and 2^63 - 1. */
  @header("x-ms-blob-sequence-number")
  blobSequenceNumber?: int64 = 0;
};

/** The blob content length response header. */
alias BlobContentLengthResponseHeader = {
  /** The size of the blob in bytes. */
  @header("x-ms-blob-content-length")
  blobContentLength?: int64;
};

/** The content length required parameter. Use only for page blobs. */
alias BlobContentLengthRequired = {
  /** The maximum size for the page blob. Must be aligned to a 512-byte boundary. */
  @header("x-ms-blob-content-length")
  size: int64;
};

/** The deny encryption scope override parameter. */
alias DenyEncryptionScopeOverrideParameter = {
  /** Whether to prevent encryption scope override. */
  @header("x-ms-deny-encryption-scope-override")
  preventEncryptionScopeOverride?: boolean;
};

/** The deny encryption scope override response header. */
alias DenyEncryptionScopeOverrideResponseHeader = {
  /** Whether to prevent encryption scope override. */
  @header("x-ms-deny-encryption-scope-override")
  preventEncryptionScopeOverride?: boolean;
};

/** The public access settings parameter. */
alias BlobPublicAccessParameter = {
  /** The public access setting for the container. */
  @header("x-ms-blob-public-access")
  access?: PublicAccessType;
};

/** The public access settings response header. */
alias BlobPublicAccessResponseHeader = {
  /** The public access setting for the container. */
  @header("x-ms-blob-public-access")
  access?: PublicAccessType;
};

/** The rehydrate priority parameter. */
alias RehydratePriorityParameter = {
  /** The priority of the rehydration operation. */
  @header("x-ms-rehydrate-priority")
  rehydratePriority?: RehydratePriority;
};

/** The rehydrate priority response header. */
alias RehydratePriorityResponseHeader = {
  /** The priority of the rehydration operation. */
  @header("x-ms-rehydrate-priority")
  rehydratePriority?: RehydratePriority;
};

/** The expiry time parameter. */
alias ExpiryTimeParameter = {
  /** The date-time this blob will expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-expiry-time")
  expiresOn?: utcDateTime;
};

/** The expiry time response header. */
alias ExpiryTimeResponseHeader = {
  /** The date-time this blob will expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-expiry-time")
  expiresOn?: utcDateTime;
};

/** The immutability policy expires on response header. */
alias ImmutabilityPolicyExpiresOnResponseHeader = {
  /** The date-time that indicates the time at which the blob immutability policy will expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-immutability-policy-until-date")
  immutabilityPolicyExpiresOn?: utcDateTime;
};

/** The immutability policy expires on response header. (Internal) */
alias ImmutabilityPolicyExpiresOnResponseHeaderPrivate = {
  /** The date-time that indicates the time at which the blob immutability policy will expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @access(Access.internal)
  @header("x-ms-immutability-policy-until-date")
  immutabilityPolicyExpiresOn?: utcDateTime;
};

/** The last accessed response header. */
alias LastAccessedResponseHeader = {
  /** The date-time value that indicates the time at which the blob was last read or written. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-last-access-time")
  lastAccessed?: utcDateTime;
};

/** The access tier change time response header */
alias AccessTierChangeTimeResponseHeader = {
  /** The time the tier was changed on the blob. This is only returned if the tier on the blob was ever set. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-access-tier-change-time")
  accessTierChangeTime?: utcDateTime;
};

/** The access tier change time response header */
alias AccessTierChangeTimeResponseHeaderV2026_10_06 = {
  /** The time the tier was changed on the blob. This is only returned if the tier on the blob was ever set. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @added(Versions.v2026_10_06)
  @encode("rfc7231")
  @header("x-ms-access-tier-change-time")
  accessTierChangeTime?: utcDateTime;
};

/** The is sealed response header. */
alias IsSealedResponseHeader = {
  /** Whether the blob is sealed. */
  @header("x-ms-blob-sealed")
  isSealed?: boolean;
};

/** The tag count response header. */
alias TagCountResponseHeader = {
  /** The number of tags associated with the blob. */
  @header("x-ms-tag-count")
  tagCount?: int64;
};

/** The blob committed block count response header. */
alias BlobCommittedBlockCountResponseHeader = {
  /** The number of committed blocks present in the blob. */
  @header("x-ms-blob-committed-block-count")
  blobCommittedBlockCount?: int32;
};

/** The accept ranges response header. */
alias AcceptRangesResponseHeader = {
  /** Indicates that the service supports requests for partial blob content. */
  @header("Accept-Ranges") acceptRanges?: string;
};

/** The accept ranges response header. (Internal) */
alias AcceptRangesResponseHeaderPrivate = {
  /** Indicates that the service supports requests for partial blob content. */
  @access(Access.internal)
  @header("Accept-Ranges")
  acceptRanges?: string;
};

/** The is current version response header. */
alias IsCurrentVersionResponseHeader = {
  /** Indicates whether this is the current version of the blob. */
  @header("x-ms-is-current-version")
  isCurrentVersion?: boolean;
};

/** The lease status response header. */
alias LeaseStatusResponseHeader = {
  /** The lease status of the blob. */
  @header("x-ms-lease-status")
  leaseStatus?: LeaseStatus;
};

/** The lease state response header. */
alias LeaseStateResponseHeader = {
  /** The lease state of the blob. */
  @header("x-ms-lease-state")
  leaseState?: LeaseState;
};

/** The copy source response header. */
alias CopySourceResponseHeader = {
  /** If this blob was the destination of a copy, specifies the source URL. */
  @header("x-ms-copy-source")
  copySource?: string;
};

/** The copy progress response header. */
alias CopyProgressResponseHeader = {
  /** If this blob was the destination of a copy, specifies the number of bytes copied and the total bytes in the source. */
  @header("x-ms-copy-progress")
  copyProgress?: string;
};

/** The copy status description response header. */
alias CopyStatusDescriptionResponseHeader = {
  /** If this blob was the destination of a copy, specifies the cause of the copy operation failure. */
  @header("x-ms-copy-status-description")
  copyStatusDescription?: string;
};

/** The copy completion time response header. */
alias CopyCompletionTimeResponseHeader = {
  /** If this blob was the destination of a copy, specifies the completion time of the last attempted copy operation. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-copy-completion-time")
  copyCompletionTime?: utcDateTime;
};

/** The blob type response header. */
alias BlobTypeResponseHeader = {
  /** The type of the blob. */
  @header("x-ms-blob-type")
  blobType?: BlobType;
};

/** The object replication policy ID response header. */
alias ObjectReplicationPolicyIdResponseHeader = {
  /** The object replication policy ID. */
  @header("x-ms-or-policy-id")
  objectReplicationPolicyId?: string;
};

/** The if sequence number equal to parameter. */
alias IfSequenceNumberEqualToParameter = {
  /** Specify this value to operate only on a blob if it has the specified sequence number. */
  @header("x-ms-if-sequence-number-eq")
  ifSequenceNumberEqualTo?: int64;
};

/** The if sequence number less than parameter. */
alias IfSequenceNumberLessThanParameter = {
  /** Specify this value to operate only on a blob if it has a sequence number less than the specified. */
  @header("x-ms-if-sequence-number-lt")
  ifSequenceNumberLessThan?: int64;
};

/** The if sequence number less than or equal to parameter. */
alias IfSequenceNumberLessThanOrEqualToParameter = {
  /** Specify this value to operate only on a blob if it has a sequence number less than or equal to the specified. */
  @header("x-ms-if-sequence-number-le")
  ifSequenceNumberLessThanOrEqualTo?: int64;
};

/** The block list types. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum BlockListType {
  /** Committed blocks. */
  Committed: "committed",

  /** Uncommitted blocks. */
  Uncommitted: "uncommitted",

  /** Both committed and uncommitted blocks. */
  All: "all",
}

/** The source content CRC64 parameter. */
alias SourceContentCrc64Parameter = {
  /** Specifies the CRC64 calculated for the range of bytes that must be read from the source. */
  @header("x-ms-source-content-crc64")
  sourceContentCrc64?: bytes;
};

/** The source range parameter. */
alias SourceRangeParameter = {
  /** Specifies the bytes of the source. */
  @header("x-ms-source-range")
  sourceRange?: string;
};

/** The required source range parameter. */
alias SourceRangeParameterRequired = {
  /** Specifies the bytes of the source. */
  @header("x-ms-source-range")
  sourceRange: string;
};

/** The source URL parameter. */
alias SourceUrlParameter = {
  /** Specifies the URL of the source. */
  #suppress "@azure-tools/typespec-client-generator-core/csharp-no-url-suffix" "Name kept for backward compatibility"
  @header("x-ms-copy-source")
  sourceUrl: string;
};

/** The Block ID parameter. */
alias BlockIdParameter = {
  /** A Base64 value that identifies the block. Prior to encoding, the string must be less than or equal to 64 bytes in size. For a given blob, the length of the value specified for the blockid parameter must be the same size for each block. */
  @query
  @clientName("blockId")
  blockid: base64Bytes;
};

/** The account kind response header. */
alias AccountKindResponseHeader = {
  /** The account kind. */
  @header("x-ms-account-kind")
  accountKind?: AccountKind;
};

/** The SKU name response header. */
alias SkuNameResponseHeader = {
  /** The SKU name of the account. */
  @header("x-ms-sku-name")
  skuName?: SkuName;
};

/** The content CRC64 response header. */
alias ContentCrc64ResponseHeader = {
  /** The CRC64 hash of the content. */
  @header("x-ms-content-crc64")
  contentCrc64?: bytes;
};

/** The content CRC64 response header. */
alias ContentCrc64ResponseHeaderV2026_10_06 = {
  /** The CRC64 hash of the content. */
  @added(Versions.v2026_10_06)
  @header("x-ms-content-crc64")
  contentCrc64?: bytes;
};

/** The copy status response header. */
alias CopyStatusResponseHeader = {
  /** Status of the copy operation. */
  @header("x-ms-copy-status")
  copyStatus?: CopyStatus;
};

/** The copy ID response header. */
alias CopyIdResponseHeader = {
  /** Identifier for this copy operation. */
  @header("x-ms-copy-id")
  copyId?: string;
};

/** The source if unmodified since parameter. */
alias SourceIfUnmodifiedSinceParameter = {
  /** Specify this header value to operate only on a blob if it has not been modified since the specified date-time. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-source-if-unmodified-since")
  sourceIfUnmodifiedSince?: utcDateTime;
};

/** The lease time response header. */
alias LeaseTimeResponseHeader = {
  /** Approximate time remaining in the lease period, in seconds. */
  @header("x-ms-lease-time")
  leaseTime?: int32;
};

/** The lease break period parameter. */
alias LeaseBreakPeriodParameter = {
  /** Proposed duration the lease should continue before it is broken, in seconds, between 0 and 60. This break period is only used if it is shorter than the time remaining on the lease. If longer, the time remaining on the lease is used. */
  @header("x-ms-lease-break-period")
  breakPeriod?: int32;
};

/** The lease ID parameter. */
alias LeaseIdOptionalParameter = {
  /** If specified, the operation only succeeds if the resource's lease is active and matches this ID. */
  @header("x-ms-lease-id") leaseId?: string;
};

/** The lease ID required parameter. */
alias LeaseIdRequiredParameter = {
  /** A lease ID for the resource. The resource must have an active lease and the lease ID must match. */
  @header("x-ms-lease-id")
  leaseId: string;
};

/** The lease ID response header. */
alias LeaseIdResponseHeader = {
  /** Uniquely identifies a blob's lease. */
  @header("x-ms-lease-id")
  leaseId?: string;
};

/** The request server encrypted response header. */
alias RequestServerEncryptedResponseHeader = {
  /** Indicates whether the contents of the request are successfully encrypted. */
  @header("x-ms-request-server-encrypted")
  isServerEncrypted?: boolean;
};

/** The request server encrypted response header. (Internal) */
alias RequestServerEncryptedResponseHeaderPrivate = {
  /** Indicates whether the contents of the request are successfully encrypted. */
  @access(Access.internal)
  @header("x-ms-request-server-encrypted")
  isServerEncrypted?: boolean;
};

/** The server encrypted response header. */
alias ServerEncryptedResponseHeader = {
  /** Indicates whether the contents of the request are successfully encrypted. */
  @header("x-ms-server-encrypted")
  isServerEncrypted?: boolean;
};

/** The server encrypted response header. (Internal) */
alias ServerEncryptedResponseHeaderPrivate = {
  /** Indicates whether the contents of the request are successfully encrypted. */
  @access(Access.internal)
  @header("x-ms-server-encrypted")
  isServerEncrypted?: boolean;
};

/** The legal hold response header. (Optional) */
alias LegalHoldOptionalResponseHeader = {
  /** Indicates whether the blob has a legal hold. */
  @header("x-ms-legal-hold")
  legalHold?: boolean;
};

/** The legal hold response header. */
alias LegalHoldResponseHeader = {
  /** Indicates whether the blob has a legal hold. */
  @header("x-ms-legal-hold")
  legalHold: boolean;
};

/** The legal hold response header. (Internal) */
alias LegalHoldResponseHeaderPrivate = {
  /** Indicates whether the blob has a legal hold. */
  @access(Access.internal)
  @header("x-ms-legal-hold")
  legalHold: boolean;
};

/** The legal hold required parameter. */
alias LegalHoldRequiredParameter = {
  /** Indicates whether the blob has a legal hold. */
  @header("x-ms-legal-hold")
  legalHold: boolean;
};

/** The immutability policy mode response header. */
alias ImmutabilityPolicyModeResponseHeader = {
  /** Indicates the immutability policy mode of the blob. */
  @header("x-ms-immutability-policy-mode")
  immutabilityPolicyMode: ImmutabilityPolicyMode;
};

/** The immutability policy mode response header. (Internal) */
alias ImmutabilityPolicyModeResponseHeaderPrivate = {
  /** Indicates the immutability policy mode of the blob. */
  @access(Access.internal)
  @header("x-ms-immutability-policy-mode")
  immutabilityPolicyMode: ImmutabilityPolicyMode;
};

/** The blob sequence number response header. */
alias BlobSequenceNumberResponseHeader = {
  /** The current sequence number for a page blob. */
  @header("x-ms-blob-sequence-number")
  blobSequenceNumber: int64;
};

/** The blob sequence number response header. (Internal) */
alias BlobSequenceNumberResponseHeaderPrivate = {
  /** The current sequence number for a page blob. */
  @access(Access.internal)
  @header("x-ms-blob-sequence-number")
  blobSequenceNumber: int64;
};

/** The blob expiry options parameter. */
alias BlobExpiryOptionsParameter = {
  /** Indicates the mode of the expiry time. */
  @header("x-ms-expiry-option")
  expiryOptions: BlobExpiryOptions;
};

/** The blob expiry options. */
union BlobExpiryOptions {
  /** Never expire. */
  NeverExpire: "NeverExpire",

  /** Relative to creation time. */
  RelativeToCreation: "RelativeToCreation",

  /** Relative to now. */
  RelativeToNow: "RelativeToNow",

  /** Absolute time. */
  Absolute: "Absolute",

  /** Extensible. */
  string,
}

/** The Content-Language response header. */
alias ContentLanguageResponseHeader = {
  /** The Content-Language of the blob. */
  @header("Content-Language") contentLanguage: string;
};

/** The Content-Disposition response header. */
alias ContentDispositionResponseHeader = {
  /** The Content-Disposition of the blob. */
  @header("Content-Disposition") contentDisposition: string;
};

/** The Cache-Control response header. */
alias CacheControlResponseHeader = {
  /** The Cache-Control of the blob. */
  @header("Cache-Control") cacheControl: string;
};

/** The Content-Encoding response header. */
alias ContentEncodingResponseParameter = {
  /** The Content-Encoding of the blob. */
  @header("Content-Encoding") contentEncoding: string;
};

/** The Content-Range response header. */
alias ContentRangeResponseHeader = {
  /** Indicates the range of bytes returned in this response. */
  @header("Content-Range") contentRange: string;
};

/** The Content-MD5 response header. */
alias ContentMd5ResponseHeader = {
  /** The blob content MD5 hash. Only returned if the full blob is read. */
  @header("Content-MD5") contentMd5: bytes;
};

/** The Content-Length response header. */
alias ContentLengthResponseHeader = {
  /** The number of bytes present in the response body. */
  @header("Content-Length") contentLength: int64;
};

/** The version ID response header. */
alias VersionIdResponseHeader = {
  /** The version ID of the blob. */
  @header("x-ms-version-id")
  versionId: string;
};

/** The version ID response header. (Internal) */
alias VersionIdResponseHeaderPrivate = {
  /** The version ID of the blob. */
  @access(Access.internal)
  @header("x-ms-version-id")
  versionId: string;
};

/** The creation time response header. */
alias CreationTimeResponseHeader = {
  /** The date-time the blob was created. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-creation-time")
  creationTime: utcDateTime;
};

/** The last modified response header. */
alias LastModifiedResponseHeader = {
  /** The date-time that the resource was last modified. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("Last-Modified")
  lastModified: utcDateTime;
};

/** The last modified response header. (Internal) */
alias LastModifiedResponseHeaderPrivate = {
  /** The date-time that the resource was last modified. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @access(Access.internal)
  @header("Last-Modified")
  lastModified: utcDateTime;
};

/** The Date response header. */
alias DateResponseHeader = {
  /** Date-time value generated by the service that indicates the time at which the response was initiated. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("Date")
  date: utcDateTime;
};

/** The Date response header. (Internal) */
alias DateResponseHeaderPrivate = {
  /** Date-time value generated by the service that indicates the time at which the response was initiated. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @access(Access.internal)
  @header("Date")
  date: utcDateTime;
};

/** The ETag response header. */
alias EtagResponseHeader = {
  /** An opaque identifier for the current state of the resource. */
  @header("ETag") eTag: Azure.Core.eTag;
};

/** The ETag response header. (Internal) */
alias EtagResponseHeaderPrivate = {
  /** An opaque identifier for the current state of the resource. */
  @access(Access.internal)
  @header("ETag")
  eTag: Azure.Core.eTag;
};

/** The copy source tags header parameter. */
alias CopySourceTagsParameter = {
  /** Indicates if source tags should be copied or replaced with the tags specified. Default is 'Replace'. */
  @header("x-ms-copy-source-tag-option")
  copySourceTags?: BlobCopySourceTags;
};

/** The blob copy source tags types. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum BlobCopySourceTags {
  /** The blob tags will be replaced. */
  Replace: "REPLACE",

  /** The blob tags will be copied from the source. */
  Copy: "COPY",
}

/** The copy source authorization header parameter. */
alias CopySourceAuthorizationParameter = {
  /** Only the Bearer authorization scheme is supported, and the value must be a valid OAuth access token for the copy source. */
  @header("x-ms-copy-source-authorization")
  copySourceAuthorization?: string;
};

alias SourceEncryptionKeyParameter = {
  /** Specifies the encryption key to use to decrypt the source data provided in the request. */
  @added(Versions.v2026_04_06)
  @header("x-ms-source-encryption-key")
  sourceEncryptionKey?: string;
};

alias SourceEncryptionKeySha256Parameter = {
  /** The SHA-256 hash of the provided source encryption key. Must be provided if the source encryption key is provided. */
  @added(Versions.v2026_04_06)
  @header("x-ms-source-encryption-key-sha256")
  sourceEncryptionKeySha256?: string;
};

alias SourceEncryptionAlgorithmParameter = {
  /** The algorithm used to produce the source encryption key hash. Must be provided if the source encryption key is provided. */
  @added(Versions.v2026_04_06)
  @header("x-ms-source-encryption-algorithm")
  sourceEncryptionAlgorithm?: EncryptionAlgorithmType;
};

/** The copy source blob properties parameter. */
alias CopySourceBlobPropertiesParameter = {
  /** Indicates if properties from the source blob should be copied. Default is true. */
  @header("x-ms-copy-source-blob-properties")
  copySourceBlobProperties?: boolean;
};

/** The copy source header parameter. */
alias CopySourceParameter = {
  /** Specifies the name of the source URL for the copy operation. The value should be URL-encoded as it would appear in a request URI. */
  @header("x-ms-copy-source")
  copySource: string;
};

/** The source content MD5 header parameter. */
alias SourceContentMd5Parameter = {
  /** Specifies the MD5 hash calculated for the range of bytes that must be read from the copy source. */
  @header("x-ms-source-content-md5")
  sourceContentMd5?: bytes;
};

/** The source if tags parameter. */
alias SourceIfTagsParameter = {
  /** Specifies a SQL-like where clause on blob tags to operate only on a source blob with matching tags. */
  @header("x-ms-source-if-tags")
  sourceIfTags?: string;
};

/** The source if match parameter. */
alias SourceIfMatchParameter = {
  /** Specify this value to operate only on a source blob with a matching Etag value. */
  @header("x-ms-source-if-match")
  sourceIfMatch?: Azure.Core.eTag;
};

/** The source if none match parameter. */
alias SourceIfNoneMatchParameter = {
  /** Specify this value to operate only on a source blob with a non-matching Etag value. */
  @header("x-ms-source-if-none-match")
  sourceIfNoneMatch?: Azure.Core.eTag;
};

/** The source if modified since parameter. */
alias SourceIfModifiedSinceParameter = {
  /** Specify this value to operate only on a source blob if it has been modified since the specified date-time. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @header("x-ms-source-if-modified-since")
  @encode("rfc7231")
  sourceIfModifiedSince?: utcDateTime;
};

/** The content CRC64 parameter. */
alias ContentCrc64Parameter = {
  /** Specifies the transactional CRC64 hash for the body. */
  @header("x-ms-content-crc64")
  transactionalContentCrc64?: bytes;
};

/** The access tier optional parameter. */
alias AccessTierHeader = {
  /** The tier to be set on the blob. */
  @header("x-ms-access-tier")
  tier?: AccessTier;
};

/** The content MD5 parameter. */
alias ContentMd5Parameter = {
  /** Specifies the transactional MD5 hash for the body. */
  @header("Content-MD5")
  transactionalContentMd5?: bytes;
};

/** The legal hold optional parameter. */
alias LegalHoldOptionalParameter = {
  /** Indicates whether the blob has a legal hold. */
  @header("x-ms-legal-hold")
  legalHold?: boolean;
};

/** The immutability policy mode parameter. */
alias ImmutabilityPolicyModeParameter = {
  /** Indicates the immutability policy mode of the blob. */
  @header("x-ms-immutability-policy-mode")
  immutabilityPolicyMode?: ImmutabilityPolicyMode;
};

/** The immutability policy expiration parameter. */
alias ImmutabilityPolicyExpiryRequiredParameter = {
  /** The date-time that indicates the time at which the blob immutability policy will expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-immutability-policy-until-date")
  expiry: utcDateTime;
};

/** The immutability policy expiration parameter. */
alias ImmutabilityPolicyExpiryParameter = {
  /** The date-time that indicates the time at which the blob immutability policy will expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-immutability-policy-until-date")
  immutabilityPolicyExpiry?: utcDateTime;
};

/** The blob tags header parameter. */
alias BlobTagsHeaderParameter = {
  /** The blob tags. */
  @clientName("BlobTagsString")
  @header("x-ms-tags")
  blobTags?: string;
};

/** The encryption scope parameter. */
alias EncryptionScopeParameter = {
  /** Specifies the encryption scope used to encrypt the data. */
  @header("x-ms-encryption-scope")
  encryptionScope?: string;
};

/** The encryption scope response header. */
alias EncryptionScopeResponseHeader = {
  /** Specifies the encryption scope used to encrypt the data. */
  @header("x-ms-encryption-scope")
  encryptionScope?: string;
};

/** The encryption scope response header. (Internal) */
alias EncryptionScopeResponseHeaderPrivate = {
  /** Specifies the encryption scope used to encrypt the data. */
  @access(Access.internal)
  @header("x-ms-encryption-scope")
  encryptionScope?: string;
};

/** The blob content disposition parameter. */
alias BlobContentDispositionParameter = {
  /** Specifies the blob's Content-Disposition. If specified, this property is stored with the blob and returned with a read request. */
  @header("x-ms-blob-content-disposition")
  blobContentDisposition?: string;
};

/** The blob cache control parameter. */
alias BlobCacheControlParameter = {
  /** Specifies the blob's Cache-Control. If specified, this property is stored with the blob and returned with a read request. */
  @header("x-ms-blob-cache-control")
  blobCacheControl?: string;
};

/** The blob content MD5 parameter. */
alias BlobContentMd5Parameter = {
  /** The MD5 hash of the blob content that is stored as a property on the blob. Note: This hash is not validated. */
  @header("x-ms-blob-content-md5")
  blobContentMd5?: bytes;
};

/** The blob content MD5 response header. */
alias BlobContentMd5ResponseHeader = {
  /** MD5 hash of the full blob content only returned for ranged reads. This is the hash of the complete blob, not just the requested range. */
  @header("x-ms-blob-content-md5")
  blobContentMd5?: bytes;
};

/** The blob content language parameter. */
alias BlobContentLanguageParameter = {
  /** Specifies the blob's Content-Language. If specified, this property is stored with the blob and returned with a read request. */
  @header("x-ms-blob-content-language")
  blobContentLanguage?: string;
};

/** The blob content encoding parameter. */
alias BlobContentEncodingParameter = {
  /** Specifies the blob's Content-Encoding. If specified, this property is stored with the blob and returned with a read request. */
  @header("x-ms-blob-content-encoding")
  blobContentEncoding?: string;
};

/** The blob content type parameter. */
alias BlobContentTypeParameter = {
  /** Specifies the blob's Content-Type. If specified, this property is stored with the blob and returned with a read request. */
  @header("x-ms-blob-content-type")
  blobContentType?: string;
};

/** The premium page blob access tier types. */
union PremiumPageBlobAccessTier {
  /** The premium page blob access tier is P4. */
  P4: "P4",

  /** The premium page blob access tier is P6. */
  P6: "P6",

  /** The premium page blob access tier is P10. */
  P10: "P10",

  /** The premium page blob access tier is P15. */
  P15: "P15",

  /** The premium page blob access tier is P20. */
  P20: "P20",

  /** The premium page blob access tier is P30. */
  P30: "P30",

  /** The premium page blob access tier is P40. */
  P40: "P40",

  /** The premium page blob access tier is P50. */
  P50: "P50",

  /** The premium page blob access tier is P60. */
  P60: "P60",

  /** The premium page blob access tier is P70. */
  P70: "P70",

  /** The premium page blob access tier is P80. */
  P80: "P80",

  /** Extensible. */
  string,
}

/** The type of blob deletions. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum BlobDeleteType {
  /** Permanently delete the blob. */
  Permanent: "Permanent",
}

/** Specifies the delete behavior of blob snapshots. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum DeleteSnapshotsOptionType {
  /** Only delete the snapshots. */
  Only: "only",

  /** Delete the blob and snapshots. */
  Include: "include",
}

/** The encryption algorithm parameter. */
alias EncryptionAlgorithmParameter = {
  /** The algorithm used to produce the encryption key hash. Must be provided if the encryption key is provided. */
  @header("x-ms-encryption-algorithm")
  encryptionAlgorithm?: EncryptionAlgorithmType;
};

/** The algorithm used to produce the encryption key hash. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum EncryptionAlgorithmType {
  /** The AES256 encryption algorithm. */
  AES256: "AES256",
}

/** The encryption key SHA256 hash parameter. */
alias EncryptionKeySha256Parameter = {
  /** The SHA-256 hash of the provided encryption key. Must be provided if the encryption key is provided. */
  @header("x-ms-encryption-key-sha256")
  encryptionKeySha256?: string;
};

/** The encryption key SHA256 response header. */
alias EncryptionKeySha256ResponseHeader = {
  /** The SHA-256 hash of the provided encryption key. */
  @header("x-ms-encryption-key-sha256")
  encryptionKeySha256?: string;
};

/** The encryption key SHA256 response header. (Internal) */
alias EncryptionKeySha256ResponseHeaderPrivate = {
  /** The SHA-256 hash of the provided encryption key. */
  @access(Access.internal)
  @header("x-ms-encryption-key-sha256")
  encryptionKeySha256?: string;
};

/** The encryption key parameter. */
alias EncryptionKeyParameter = {
  /** Specifies the encryption key to use to encrypt the data provided in the request. */
  @header("x-ms-encryption-key")
  encryptionKey?: string;
};

alias AccessTierIfModifiedSinceParameter = {
  /** Specify this header value to operate only on a blob if the access-tier has been modified since the specified date-time. */
  @added(Versions.v2026_04_06)
  @header("x-ms-access-tier-if-modified-since")
  @encode("rfc7231")
  accessTierIfModifiedSince?: utcDateTime;
};

alias AccessTierIfUnmodifiedSinceParameter = {
  /** Specify this header value to operate only on a blob if the access-tier has not been modified since the specified date-time. */
  @added(Versions.v2026_04_06)
  @header("x-ms-access-tier-if-unmodified-since")
  @encode("rfc7231")
  accessTierIfUnmodifiedSince?: utcDateTime;
};

/** The If-Tags parameter. */
alias IfTagsParameter = {
  /** Specifies a SQL-like where clause on blob tags to operate only on a blob with matching tags. */
  @header("x-ms-if-tags")
  ifTags?: string;
};

/** The If-Match parameter. */
alias IfMatchParameter = {
  /** Specify this value to operate only on a blob with a matching Etag value. */
  @header("If-Match")
  ifMatch?: Azure.Core.eTag;
};

/** The If-None-Match parameter. */
alias IfNoneMatchParameter = {
  /** Specify this value to operate only on a blob with a non-matching Etag value. */
  @header("If-None-Match")
  ifNoneMatch?: Azure.Core.eTag;
};

/** The range parameter. */
alias RangeParameter = {
  /** Specifies the range of the blob to operate on. */
  @header("Range")
  range?: string;
};

/** The required range parameter. */
alias RangeParameterRequired = {
  /** Specifies the range of the blob to operate on. */
  @header("Range")
  range: string;
};

/** The version ID parameter. */
alias VersionIdParameter = {
  /** Specifies the version ID of the blob. */
  @query
  @clientName("versionId")
  versionid?: string;
};

/** The snapshot parameter. */
alias SnapshotParameter = {
  /** Specifies the snapshot of the blob. */
  @query
  snapshot?: string;
};

/** Represents a blob name. */
model BlobName {
  /** Whether the blob name is encoded. */
  @Xml.attribute
  @Xml.name("Encoded")
  encoded?: boolean;

  /** The blob name. */
  @Xml.unwrapped content?: string;
}

/** Represents a blob prefix. */
model BlobPrefix {
  /** The blob name. */
  @Xml.name("Name") name: BlobName;
}

/** Represents an array of blobs. */
model BlobHierarchyList {
  /** The blob items. */
  @pageItems
  @Xml.name("Blob")
  @Xml.unwrapped
  blobItems: BlobItem[];

  /** The blob prefixes. */
  @Xml.name("BlobPrefix")
  @Xml.unwrapped
  blobPrefixes?: BlobPrefix[];
}

/** The result of the List Blobs Hierarchical API. */
#suppress "@azure-tools/typespec-client-generator-core/csharp-model-suffix" "Name kept for backward compatibility"
@Xml.name("EnumerationResults")
model ListBlobsHierarchicalResponse {
  /** The service endpoint. */
  @Xml.attribute
  @Xml.name("ServiceEndpoint")
  serviceEndpoint: string;

  /** The container name. */
  @Xml.attribute
  @Xml.name("ContainerName")
  containerName: string;

  /** The delimiter of the blobs. */
  @Xml.name("Delimiter") delimiter?: string;

  /** The prefix of the blobs. */
  @Xml.name("Prefix") prefix?: string;

  /** An opaque string value that identifies the portion of the result set returned with this operation. */
  @Xml.name("Marker") marker?: string;

  /** The maximum number of blobs to be returned with this operation. */
  @Xml.name("MaxResults") maxResults?: int32;

  /** The list of hierarchical blobs. */
  @Xml.name("Blobs")
  hierarchicalList: BlobHierarchyList;

  /** An opaque string value that identifies the portion of the result set to be returned with the next operation. Use this value in the next request to continue the listing operation. */
  @continuationToken
  @Xml.name("NextMarker")
  nextMarker?: string;
}

/** The list blob includes parameter. */
alias ListBlobsIncludeParameter = {
  /** Specify to include additional, optional information. */
  @query
  include?: ListBlobsIncludeItem[];
};

/** Specifies additional datasets to include when listing blobs in a container. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum ListBlobsIncludeItem {
  /** Include copies. */
  Copy: "copy",

  /** Include deleted blobs. */
  Deleted: "deleted",

  /** Include metadata. */
  Metadata: "metadata",

  /** Include snapshots. */
  Snapshots: "snapshots",

  /** Include uncommitted blobs. */
  UncommittedBlobs: "uncommittedblobs",

  /** Include versions. */
  Versions: "versions",

  /** Include tags. */
  Tags: "tags",

  /** Include immutability policies. */
  ImmutabilityPolicy: "immutabilitypolicy",

  /** Include legal hold. */
  LegalHold: "legalhold",

  /** Include deleted with versions. */
  DeletedWithVersions: "deletedwithversions",
}

/** The lease duration response header. */
alias LeaseDurationResponseHeader = {
  /** Specifies the duration of the lease. */
  @header("x-ms-lease-duration")
  duration?: LeaseDuration;
};

/** The lease duration parameter. */
alias LeaseDurationHeaderParameter = {
  /** Specifies the duration of the lease, in seconds, or negative one (-1) for a lease that never expires. A non-infinite lease can be between 15 and 60 seconds. */
  @header("x-ms-lease-duration")
  duration: int32;
};

// NOTE: This does not explicitly let emitters know that this is a collection header for metadata. Logic should be handwritten to handle this.
alias MetadataHeaders = {
  /** The metadata headers. */
  @alternateType(Record<string>, "rust,javascript,python,csharp,go")
  @header("x-ms-meta")
  metadata?: string;
};

// NOTE: this does not explicitly let emitters know that this is a special type of header used for collection of object replication headers. Logic should be handwritten to handle this.
alias ObjectReplicationHeaders = {
  /** The object replication status headers. */
  @alternateType(Record<string>, "rust,javascript,python,go")
  @header("x-ms-or")
  objectReplicationRules?: string;
};

/** The If-Unmodified-Since header. */
alias IfUnmodifiedSinceParameter = {
  /** Specify this value to operate only on a blob if it has not been modified since the specified date-time. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("If-Unmodified-Since")
  ifUnmodifiedSince?: utcDateTime;
};

/** The If-Modified-Since header. */
alias IfModifiedSinceParameter = {
  /** Specify this value to operate only on a blob if it has been modified since the specified date-time. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("If-Modified-Since")
  ifModifiedSince?: utcDateTime;
};

/** The filter blobs include parameter. */
alias FilterBlobsIncludeParameter = {
  /** Specify to include additional, optional information. */
  @query
  include?: FilterBlobsIncludeItem[];
};

/** The filter blobs where parameter. */
alias FilterBlobsWhereParameter = {
  /** Filters the results to return only blobs whose tags match the specified expression. */
  @query
  @clientName("filterExpression", "!python")
  where: string;
};

/** The Content-Length header. */
alias ContentLengthParameter = {
  /** The length of the request. */
  @header("Content-Length") contentLength: int64;
};

/** The max results parameter. */
alias MaxResultsParameter = {
  /** Specifies the maximum number of resources to return. If the request does not specify maxresults, or specifies a value greater than 5000, the server will return up to 5000 items. */
  @query
  @minValue(1)
  maxresults?: int32;
};

/** The marker parameter. */
alias MarkerParameter = {
  /** An opaque string value that identifies the portion of the result set to return with this operation. */
  @continuationToken
  @query
  marker?: string;
};

/** The prefix parameter. */
alias PrefixParameter = {
  /** Filters the results to return only resources whose name begins with the specified prefix. */
  @query prefix?: string;
};

/** The timeout parameter. */
alias TimeoutParameter = {
  /** The timeout parameter is expressed in seconds. For more information, see <a href=\"https://docs.microsoft.com/en-us/rest/api/storageservices/fileservices/setting-timeouts-for-blob-service-operations\">Setting Timeouts for Blob Service Operations.</a> */
  @query
  @minValue(0)
  timeout?: int32;
};

/** The required proposed lease ID header. */
alias ProposedLeaseIdRequiredParameter = {
  /** The proposed lease ID for the lease. */
  @header("x-ms-proposed-lease-id") proposedLeaseId: string;
};

/** The optional proposed lease ID header. */
alias ProposedLeaseIdOptionalParameter = {
  /** The proposed lease ID for the lease. */
  @header("x-ms-proposed-lease-id") proposedLeaseId?: string;
};

/** The body parameter. */
alias BodyParameter = {
  /** The body of the request. */
  @body
  body: bytes;
};

/** The multipart body parameter. */
alias MultipartBodyParameter = {
  /** The body of the request. */
  @multipartBody body: {
    body: HttpPart<bytes>;
  };
};

alias IsHierarchicalNamespaceEnabled = {
  /** Indicates if the account has a hierarchical namespace enabled. */
  @header("x-ms-is-hns-enabled")
  isHierarchicalNamespaceEnabled?: boolean;
};

alias StructuredBodyTypeResponseHeader = {
  /** Indicates if the response body contains a structured message and specifies the message schema version and properties. */
  @access(Access.internal)
  @header("x-ms-structured-body")
  structuredBodyType?: string;
};

alias StructuredContentLengthParameter = {
  /** Required if the request body is a structured message. Specifies the length of the blob/file content inside the message body. Will always be smaller than Content-Length. */
  @access(Access.internal)
  @header("x-ms-structured-content-length")
  structuredContentLength?: int64;
};

alias StructuredContentLengthResponseHeader = {
  /** The length of the blob/file content inside the message body when the response body is returned as a structured message. Will always be smaller than Content-Length. */
  @access(Access.internal)
  @header("x-ms-structured-content-length")
  structuredContentLength?: int64;
};

alias StructuredBodyParameter = {
  /** Required if the request body is a structured message. Specifies the message schema version and properties. */
  @access(Access.internal)
  @header("x-ms-structured-body")
  structuredBodyType?: string;
};

/** The file share token intent types. */
union FileShareTokenIntent {
  /** The file share token intent is backup. */
  Backup: "backup",

  /** Extensible. */
  string,
}

alias FileRequestIntentParameter = {
  /** Specifies the file request token intent. */
  @header("x-ms-file-request-intent")
  fileRequestIntent?: FileShareTokenIntent;
};

alias ClientRequestIdHeader = {
  /** An opaque, globally-unique, client-generated string identifier for the request. */
  @access(Access.internal)
  @header("x-ms-client-request-id")
  clientRequestId?: uuid;
};

alias RequestIdResponseHeader = {
  /** An opaque, globally-unique, server-generated string identifier for the request. */
  @access(Access.internal)
  @visibility(Lifecycle.Read)
  @header("x-ms-request-id")
  requestId?: uuid;
};

alias LeaseActionParameter<TAction extends string> = {
  /** Specifies what lease action to take. */
  @header("x-ms-lease-action")
  action: TAction;
};

alias PageWriteParameter<TPageWrite extends string> = {
  /**
   * Specifies the page write operation type.
   * - Update: Writes the bytes specified by the request body into the specified range. The Range and Content-Length headers must match.
   * - Clear: Clears the specified range and releases the space used in storage. Set Content-Length to zero and Range to the range to clear.
   */
  @header("x-ms-page-write")
  pageWrite: TPageWrite;
};

alias IfBlobMatchHeader = {
  /** Specify this value to operate only on a blob with a matching Etag value. */
  @added(Versions.v2026_02_06)
  @header("x-ms-blob-if-match")
  ifMatch?: Azure.Core.eTag;
};

alias IfBlobModifiedSinceHeader = {
  /** Specify this value to operate only on a blob if it has been modified since the specified date-time. */
  @added(Versions.v2026_02_06)
  @header("x-ms-blob-if-modified-since")
  @encode("rfc7231")
  ifModifiedSince?: utcDateTime;
};

alias IfBlobNoneMatchHeader = {
  /** Specify this value to operate only on a blob with a non-matching Etag value. */
  @added(Versions.v2026_02_06)
  @header("x-ms-blob-if-none-match")
  ifNoneMatch?: Azure.Core.eTag;
};

alias IfBlobUnmodifiedSinceHeader = {
  /** Specify this value to operate only on a blob if it has not been modified since the specified date-time. */
  @added(Versions.v2026_02_06)
  @header("x-ms-blob-if-unmodified-since")
  @encode("rfc7231")
  ifUnmodifiedSince?: utcDateTime;
};

alias ListBlobsStartFrom = {
  /** Specifies the relative path to list paths from. For non-recursive list, only one entity level is supported; for recursive list, multiple entity levels are supported. (Inclusive) */
  @added(Versions.v2026_02_06)
  @query
  startFrom?: string;
};

alias ListBlobsEndBefore = {
  /** Filters the results to return only names that are ordered before this value. Currently only applies to Apache Arrow scenario. */
  @added(Versions.v2026_12_06)
  @query
  endBefore?: string;
};
