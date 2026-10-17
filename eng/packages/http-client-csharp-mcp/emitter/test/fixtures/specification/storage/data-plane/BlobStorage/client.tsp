import "@azure-tools/typespec-client-generator-core";
import "./main.tsp";

using TypeSpec.Http;
using Azure.ClientGenerator.Core;
using Storage.Blob;
using Azure.Core;
using TypeSpec.Versioning;

namespace Customizations;

// Cross-language modifications: python,csharp,javascript,go
@@alternateType(KeyInfo.start, string, "python,csharp,javascript,go");
@@alternateType(KeyInfo.expiry, string, "python,csharp,javascript,go");

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Existing SDKs didn't output pageable operations format"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Service.listContainers,
  "python,csharp,javascript,go"
);
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Existing SDKs didn't output pageable operations format"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Service.findBlobsByTags,
  "python,csharp,javascript,go"
);
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Existing SDKs didn't output pageable operations format"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Container.findBlobsByTags,
  "python,csharp,javascript,go"
);
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Existing SDKs didn't output pageable operations format"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Container.listBlobs,
  "python,csharp,javascript,go"
);

@@clientName(
  FilteredBlobResponse,
  "FilterBlobSegment",
  "python,csharp,javascript,go"
);
@@clientName(FilteredBlobResponse.blobItems, "blobs", "javascript,go");
@@clientName(
  ListContainersResponse,
  "ListContainersSegmentResponse",
  "python,csharp,javascript,go"
);

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
@client(
  {
    service: Storage.Blob,
  },
  "rust,go"
)
interface BlobServiceClient extends Storage.Blob.Service {}

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
@client(
  {
    service: Storage.Blob,
  },
  "rust,go"
)
interface BlobContainerClient extends Storage.Blob.Container {}

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
@client(
  {
    service: Storage.Blob,
  },
  "rust,go"
)
interface BlobClient extends Storage.Blob.Blob {}

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
@client(
  {
    service: Storage.Blob,
  },
  "rust,go"
)
interface AppendBlobClient extends Storage.Blob.AppendBlob {}

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
@client(
  {
    service: Storage.Blob,
  },
  "rust,go"
)
interface BlockBlobClient extends Storage.Blob.BlockBlob {}

#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
@client(
  {
    service: Storage.Blob,
  },
  "rust,go"
)
interface PageBlobClient extends Storage.Blob.PageBlob {}

@@clientInitialization(
  BlobServiceClient,
  {
    initializedBy: InitializedBy.customizeCode,
  },
  "rust"
);

@@clientInitialization(
  BlobContainerClient,
  {
    initializedBy: InitializedBy.customizeCode,
  },
  "rust"
);

@@clientInitialization(
  BlobClient,
  {
    initializedBy: InitializedBy.customizeCode,
  },
  "rust"
);

@@clientInitialization(
  AppendBlobClient,
  {
    initializedBy: InitializedBy.customizeCode,
  },
  "rust"
);

@@clientInitialization(
  BlockBlobClient,
  {
    initializedBy: InitializedBy.customizeCode,
  },
  "rust"
);

@@clientInitialization(
  PageBlobClient,
  {
    initializedBy: InitializedBy.customizeCode,
  },
  "rust"
);

#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(BlobServiceClient, "omitEndpointMethod", true, "rust");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(BlobContainerClient, "omitEndpointMethod", true, "rust");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(BlobClient, "omitEndpointMethod", true, "rust");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(AppendBlobClient, "omitEndpointMethod", true, "rust");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(BlockBlobClient, "omitEndpointMethod", true, "rust");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(PageBlobClient, "omitEndpointMethod", true, "rust");

@@usage(BlobName, Usage.output, "rust");

@@alternateType(BlobItem.name, string, "rust");
@@alternateType(BlobPrefix.name, string, "rust");

#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  BlobItem.name,
  "deserialize_with",
  "crate::models::blob_name::option::deserialize",
  "rust"
);
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  BlobPrefix.name,
  "deserialize_with",
  "crate::models::blob_name::option::deserialize",
  "rust"
);

#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  KeyInfo.start,
  "serialize_with",
  "azure_storage_common::rfc3339::seconds_only::option::serialize",
  "rust"
);
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  KeyInfo.expiry,
  "serialize_with",
  "azure_storage_common::rfc3339::seconds_only::option::serialize",
  "rust"
);

@@clientNamespace(Storage.Blob, "Azure.Storage.Blobs", "rust,go");
@@clientNamespace(Storage.Blob.Container, "Azure.Storage.Blobs", "rust,go");
@@clientNamespace(Storage.Blob.Blob, "Azure.Storage.Blobs", "rust,go");
@@clientNamespace(Storage.Blob.AppendBlob, "Azure.Storage.Blobs", "rust,go");
@@clientNamespace(Storage.Blob.BlockBlob, "Azure.Storage.Blobs", "rust,go");
@@clientNamespace(Storage.Blob.PageBlob, "Azure.Storage.Blobs", "rust,go");

@@clientName(Storage.Blob.BlockBlob.upload, "upload_internal", "rust");
@@access(Storage.Blob.BlockBlob.upload, Access.internal, "rust");
@@clientName(Storage.Blob.Blob.download, "download_internal", "rust");
@@access(Storage.Blob.Blob.download, Access.internal, "rust");

@@clientName(Storage.Blob.Container.listBlobs, "listBlobsXml", "rust");
@@access(Storage.Blob.Container.listBlobs, Access.internal, "rust");
@@access(Storage.Blob.ListBlobsResponse, Access.public, "rust");

@@clientName(
  Storage.Blob.Container.listBlobHierarchySegment,
  "listBlobsHierarchicalXml",
  "rust"
);
@@access(
  Storage.Blob.Container.listBlobHierarchySegment,
  Access.internal,
  "rust"
);
@@access(Storage.Blob.ListBlobsHierarchicalResponse, Access.public, "rust");
@@access(Storage.Blob.ListBlobsIncludeItem, Access.public, "rust");

@@clientName(Storage.Blob.Blob.abortCopyFromUrl, "abortCopy", "rust");
@@clientName(Storage.Blob.Service.findBlobsByTags, "findBlobsByTags", "rust");
@@clientName(Storage.Blob.Container.findBlobsByTags, "findBlobsByTags", "rust");
#suppress "@azure-tools/typespec-client-generator-core/client-option" ""
@@clientOption(
  Storage.Blob.PageBlob.getPageRanges,
  "forcePageIterator",
  true,
  "rust"
);
@@clientName(Storage.Blob.PageBlob.getPageRanges, "listPageRanges", "rust");
@@clientName(PageList.pageRange, "pageRanges", "rust");
@@clientName(PageList.clearRange, "clearRanges", "rust");
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Existing SDKs didn't output pageable operations format"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Storage.Blob.PageBlob.getPageRanges,
  "python,csharp,javascript,go"
);

@@clientName(
  BlobProperties.customerProvidedKeySha256,
  "encryptionKeySha256",
  "rust"
);
@@clientName(MetadataHeaders.metadata, "metadata", "rust");
@@clientName(
  ObjectReplicationHeaders.objectReplicationRules,
  "objectReplicationRules",
  "rust"
);
@@clientName(
  ImmutabilityPolicyExpiryRequiredParameter.expiry,
  "immutabilityPolicyExpiry",
  "python, csharp, javascript"
);

@@alternateType(AccessPolicy.start, string, "javascript, python");
@@alternateType(AccessPolicy.expiry, string, "javascript, python");
@@alternateType(UserDelegationKey.signedStart, string, "javascript");
@@alternateType(UserDelegationKey.signedExpiry, string, "javascript");
@@alternateType(MultipartBodyParameter.body, string, "javascript");

@@clientName(AccessPolicy.start, "startsOn", "javascript");
@@clientName(AccessPolicy.expiry, "expiresOn", "javascript");
@@clientName(AccessPolicy.permission, "permissions", "javascript");
@@clientName(
  BlobProperties.accessTierChangeTime,
  "accessTierChangedOn",
  "javascript"
);
@@clientName(
  AccessTierChangeTimeResponseHeader.accessTierChangeTime,
  "accessTierChangedOn",
  "javascript"
);
@@clientName(
  AccessTierChangeTimeResponseHeaderV2026_10_06.accessTierChangeTime,
  "accessTierChangedOn",
  "javascript"
);
@@clientName(BlobProperties.creationTime, "createdOn", "javascript");
@@clientName(
  CreationTimeResponseHeader.creationTime,
  "createdOn",
  "javascript"
);
@@clientName(
  BlobProperties.copyCompletionTime,
  "copyCompletedOn",
  "javascript"
);
@@clientName(BlobProperties.deletedTime, "deletedOn", "javascript");
@@clientName(BlobProperties.eTag, "etag", "javascript,python");
@@clientName(ContainerProperties.deletedTime, "deletedOn", "javascript");
@@clientName(ContainerProperties.eTag, "etag", "javascript,python");
@@clientName(EtagResponseHeader.eTag, "etag", "javascript,python");
@@clientName(EtagResponseHeaderPrivate.eTag, "etag", "javascript,python");
@@clientName(GeoReplication.lastSyncTime, "lastSyncOn", "javascript");
@@clientName(KeyInfo.start, "startsOn", "javascript");
@@clientName(KeyInfo.expiry, "expiresOn", "javascript");
@@clientName(
  BlobServiceProperties.logging,
  "blobAnalyticsLogging",
  "javascript"
);
@@clientName(Logging.delete, "deleteProperty", "javascript");
@@clientName(Metrics.includeApis, "includeAPIs", "javascript");
@@clientName(UserDelegationKey.signedOid, "signedObjectId", "javascript");
@@clientName(UserDelegationKey.signedTid, "signedTenantId", "javascript");
@@clientName(UserDelegationKey.signedStart, "signedStartsOn", "javascript");
@@clientName(UserDelegationKey.signedExpiry, "signedExpiresOn", "javascript");
@@clientName(
  FilteredBlobResponse.nextMarker,
  "continuationToken",
  "javascript"
);
@@clientName(
  ListContainersResponse.NextMarker,
  "continuationToken",
  "javascript"
);
@@clientName(MaxResultsParameter.maxresults, "maxPageSize", "javascript");
@@clientName(ListContainersResponse.maxResults, "maxPageSize", "javascript");
@@clientName(ListBlobsResponse.nextMarker, "continuationToken", "javascript");
@@clientName(ListBlobsResponse.maxResults, "maxPageSize", "javascript");
@@clientName(PageList.nextMarker, "continuationToken", "javascript");
@@clientName(
  ListBlobsHierarchicalResponse.nextMarker,
  "continuationToken",
  "javascript"
);
@@clientName(
  ListBlobsHierarchicalResponse.maxResults,
  "maxPageSize",
  "javascript"
);
@@clientName(
  LeaseDurationResponseHeader.duration,
  "leaseDuration",
  "javascript"
);
@@clientName(
  BlobContentMd5Parameter.blobContentMd5,
  "blobContentMD5",
  "javascript"
);
@@clientName(
  BlobContentMd5ResponseHeader.blobContentMd5,
  "blobContentMD5",
  "javascript"
);
@@clientName(
  SourceContentMd5Parameter.sourceContentMd5,
  "sourceContentMD5",
  "javascript"
);
@@clientName(
  ContentMd5Parameter.transactionalContentMd5,
  "transactionalContentMD5",
  "javascript"
);
@@clientName(
  BlobPublicAccessResponseHeader.access,
  "blobPublicAccess",
  "javascript"
);

@@clientName(ContentMd5ResponseHeader.contentMd5, "contentMD5", "javascript");
@@clientName(
  ContentCrc64ResponseHeader.contentCrc64,
  "xMsContentCrc64",
  "javascript"
);
@@clientName(
  ContentCrc64ResponseHeaderV2026_10_06.contentCrc64,
  "xMsContentCrc64",
  "javascript"
);

@@alternateType(BlobProperties.contentLength, uint64, "rust");
@@alternateType(BlobContentLengthRequired.size, uint64, "rust");
@@alternateType(
  BlobMetadata,
  {
    identity: "crate::models::BlobMetadata",
  },
  "rust"
);
@@alternateType(
  UserDelegationKey,
  {
    identity: "azure_storage_common::models::UserDelegationKey",
  },
  "rust"
);
@@alternateType(ContentLengthResponseHeader.contentLength, uint64, "rust");
@@alternateType(ContentLengthParameter.contentLength, uint64, "rust");
@@alternateType(
  StructuredContentLengthParameter.structuredContentLength,
  uint64,
  "rust"
);
@@alternateType(
  StructuredContentLengthResponseHeader.structuredContentLength,
  uint64,
  "rust"
);
// Range/source-range string parameters → HttpRange for Rust
@@alternateType(Blob.download::parameters.range, HttpRange, "rust");
@@alternateType(RangeParameter.range, HttpRange, "rust");
@@alternateType(RangeParameterRequired.range, HttpRange, "rust");
@@alternateType(SourceRangeParameter.sourceRange, HttpRange, "rust");
@@alternateType(SourceRangeParameterRequired.sourceRange, HttpRange, "rust");

@@scope(Storage.Blob.Container.submitBatch, "!rust");
@@scope(Storage.Blob.Service.submitBatch, "!rust");

// GO SPECIFICATION

/** The blob flat list segment. */
model BlobFlatListSegment {
  /** The blob items. */
  @pageItems
  @Xml.name("Blob")
  @Xml.unwrapped
  blobItems: BlobItem[];
}

/** The type of blob deletions. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum BlobDeleteTypeCustom {
  /** None. */
  None: "None",

  /** Permanently delete the blob. */
  Permanent: "Permanent",
}
/** Represents a blob prefix. */
@Xml.name("BlobPrefix")
@clientName("BlobPrefix", "go")
model BlobPrefixGo {
  /** The blob name. */
  @Xml.name("Name") name: string;

  #suppress "@azure-tools/typespec-azure-core/documentation-required" "Client library owners should add relevant documentation"
  @Xml.name("Properties") properties: BlobProperties;
}
/** The properties of a blob. */
#suppress "@azure-tools/typespec-azure-core/documentation-required" "Client library owners should add relevant documentation"
@Xml.name("Properties")
@clientName("BlobProperties", "go")
model BlobPropertiesGo {
  /** The date-time the blob was created in RFC1123 format. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("Creation-Time")
  creationTime?: utcDateTime;

  /** The date-time the blob was last modified in RFC1123 format. */
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

  /** The copy completion time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("CopyCompletionTime")
  copyCompletionTime?: utcDateTime;

  /** The copy status description of the blob. */
  @Xml.name("CopyStatusDescription") copyStatusDescription?: string;

  /** Whether the blob is encrypted on the server. */
  @Xml.name("ServerEncrypted") serverEncrypted?: boolean;

  /** Whether the blob is incremental copy. */
  @Xml.name("IncrementalCopy") incrementalCopy?: boolean;

  /** The name of the destination snapshot. */
  @Xml.name("DestinationSnapshot") destinationSnapshot?: string;

  /** The time the blob was deleted. */
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

  /** Customer provided key sha256 */
  @Xml.name("CustomerProvidedKeySha256") customerProvidedKeySha256?: string;

  /** The encryption scope of the blob. */
  @Xml.name("EncryptionScope") encryptionScope?: string;

  /** The access tier change time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("AccessTierChangeTime")
  accessTierChangeTime?: utcDateTime;

  /** The number of tags for the blob. */
  @Xml.name("TagCount") tagCount?: int32;

  /** The expire time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("Expiry-Time")
  expiresOn?: utcDateTime;

  /** Whether the blob is sealed. */
  @Xml.name("Sealed")
  isSealed?: boolean;

  /** The rehydrate priority of the blob. */
  @Xml.name("RehydratePriority") rehydratePriority?: RehydratePriority;

  /** The last access time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("LastAccessTime")
  lastAccessedOn?: utcDateTime;

  /** The immutability policy until time of the blob. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @Xml.name("ImmutabilityPolicyUntilDate")
  immutabilityPolicyExpiresOn?: utcDateTime;

  /** The immutability policy mode of the blob. */
  @Xml.name("ImmutabilityPolicyMode")
  immutabilityPolicyMode?: ImmutabilityPolicyMode;

  /** Whether the blob is under legal hold. */
  @Xml.name("LegalHold") legalHold?: boolean;

  @Xml.name("Acl") acl?: string;
  @Xml.name("Group") group?: string;
  @Xml.name("Owner") owner?: string;
  @Xml.name("Permissions") permissions?: string;
  @Xml.name("ResourceType") resourceType?: string;
}
/** The algorithm used to produce the encryption key hash. Currently, the only accepted value is \"AES256\". Must be provided if the x-ms-encryption-key header is provided. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum EncryptionAlgorithmTypeCustom {
  /** Deprecated */
  None: "None",

  /** AES256 */
  AES256: "AES256",
}
/** The list blob includes parameter values. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum ListBlobsIncludeItemGo {
  /** The include copies. */
  Copy: "copy",

  /** The include deleted blobs. */
  Deleted: "deleted",

  /** The include metadata. */
  Metadata: "metadata",

  /** The include snapshots. */
  Snapshots: "snapshots",

  /** The include uncommitted blobs. */
  UncommittedBlobs: "uncommittedblobs",

  /** The include versions. */
  Versions: "versions",

  /** The include tags. */
  Tags: "tags",

  /** The include immutable policy. */
  ImmutabilityPolicy: "immutabilitypolicy",

  /** The include legal hold. */
  LegalHold: "legalhold",

  /** The include deleted with versions. */
  DeletedWithVersions: "deletedwithversions",

  /** Deprecated */
  Permissions: "permissions",
}
/** The immutability policy mode used in requests and responses. */
#suppress "@azure-tools/typespec-azure-core/no-enum" "Existing API"
enum ImmutabilityPolicySetting {
  /** The immutability policy is locked. */
  Locked: "Locked",

  /** The immutability policy is unlocked. */
  Unlocked: "Unlocked",
}
/** The multipart body parameter. */
alias MultipartBodyParameterGo = {
  /** The body of the request. */
  @body
  @encode("bytes")
  body: bytes;
};
/** Represents an array of signed identifiers */
@clientName("SignedIdentifiers", "go")
model SignedIdentifiersGo is Array<SignedIdentifier>;
@@access(StorageErrorCode, Access.public, "go");
@@usage(StorageErrorCode, Usage.output, "go");
@@alternateType(AccessPolicy.start, utcDateTime, "go");
@@alternateType(AccessPolicy.expiry, utcDateTime, "go");
@@alternateType(BlobDeleteType, BlobDeleteTypeCustom, "go");
@@alternateType(BlobItem.name, string, "go");
@@alternateType(BlobItem.metadata, Record<string>, "go");
@@alternateType(BlobItem.objectReplicationMetadata, Record<string>, "go");
@@alternateType(BlobPrefix, BlobPrefixGo, "go");
@@alternateType(BlobProperties, BlobPropertiesGo, "go");
@@alternateType(Block.name, string, "go");
@@alternateType(BlockIdParameter.blockid, string, "go");
@@alternateType(BlockLookupList.committed, string[], "go");
@@alternateType(BlockLookupList.latest, string[], "go");
@@alternateType(BlockLookupList.uncommitted, string[], "go");
@@alternateType(ConditionalRequestHeaders.ifMatch, Azure.Core.eTag, "go");
@@alternateType(ConditionalRequestHeaders.ifNoneMatch, Azure.Core.eTag, "go");
@@alternateType(
  EncryptionAlgorithmParameter.encryptionAlgorithm,
  EncryptionAlgorithmTypeCustom,
  "go"
);
@@alternateType(ExpiryTimeParameter.expiresOn, string, "go");
@@alternateType(
  ImmutabilityPolicyModeParameter.immutabilityPolicyMode,
  ImmutabilityPolicySetting,
  "go"
);
@@alternateType(
  MultipartBodyParameter.body,
  MultipartBodyParameterGo.body,
  "go"
);
@@alternateType(
  RehydratePriorityResponseHeader.rehydratePriority,
  string,
  "go"
);
@@alternateType(
  SourceEncryptionAlgorithmParameter.sourceEncryptionAlgorithm,
  EncryptionAlgorithmTypeCustom,
  "go"
);
@@alternateType(
  ListBlobsIncludeParameter.include,
  ListBlobsIncludeItemGo[],
  "go"
);
@@alternateType(ListBlobsResponse.blobItems, BlobFlatListSegment, "go");
@@alternateType(UserDelegationKey.signedExpiry, utcDateTime, "go");
@@alternateType(UserDelegationKey.signedStart, utcDateTime, "go");
@@alternateType(UserDelegationKey.value, string, "go");
@@alternateType(SignedIdentifiers, SignedIdentifiersGo, "go");
@@clientName(BlobContainerClient, "ContainerClient", "go");
@@clientName(BlobCopySourceTags.Copy, "COPY", "go");
@@clientName(BlobCopySourceTags.Replace, "REPLACE", "go");
@@clientName(BlobServiceClient, "ServiceClient", "go");
@@clientName(BlobDeleteTypeCustom, "DeleteType", "go");
@@clientName(BlobExpiryOptions, "ExpiryOptions", "go");
@@clientName(BlobHierarchyList, "BlobHierarchyListSegment", "go");
@@clientName(BlobItem.objectReplicationMetadata, "OrMetadata", "go");
@@clientName(BlobPublicAccessResponseHeader.access, "BlobPublicAccess", "go");
@@clientName(BlobServiceProperties, "StorageServiceProperties", "go");
@@clientName(BlobServiceProperties.cors, "CORS", "go");
@@clientName(CopyStatus, "CopyStatusType", "go");
@@clientName(CorsRule, "CORSRule", "go");
@@clientName(
  DenyEncryptionScopeOverrideResponseHeader.preventEncryptionScopeOverride,
  "DenyEncryptionScopeOverride",
  "go"
);
@@clientName(Error, "StorageError", "go");
@@clientName(EncryptionAlgorithmTypeCustom, "EncryptionAlgorithmType", "go");
@@clientName(GeoReplicationStatusType, "BlobGeoReplicationStatus", "go");
@@clientName(
  ImmutabilityPolicyExpiresOnResponseHeaderPrivate.immutabilityPolicyExpiresOn,
  "ImmutabilityPolicyExpiry",
  "go"
);
@@clientName(KeyInfo.delegatedUserTid, "DelegatedUserTenantID", "go");
@@clientName(LeaseDuration, "LeaseDurationType", "go");
@@clientName(LeaseDurationResponseHeader.duration, "LeaseDuration", "go");
@@clientName(LeaseState, "LeaseStateType", "go");
@@clientName(LeaseStatus, "LeaseStatusType", "go");
@@clientName(ListBlobsIncludeItemGo, "ListBlobsIncludeItem", "go");
@@clientName(ListBlobsResponse, "ListBlobsFlatSegmentResponse", "go");
@@clientName(
  ListBlobsHierarchicalResponse,
  "ListBlobsHierarchySegmentResponse",
  "go"
);
@@clientName(ListBlobsHierarchicalResponse.hierarchicalList, "segment", "go");
@@clientName(ListBlobsResponse.blobItems, "segment", "go");
@@clientName(Metrics.includeApis, "IncludeAPIs", "go");
@@clientName(QueryType, "QueryFormatType", "go");
@@clientName(Storage.Blob.Blob.setProperties, "SetHTTPHeaders", "go");
@@clientName(Storage.Blob.Container.findBlobsByTags, "FilterBlobs", "go");
@@clientName(Storage.Blob.Container.listBlobs, "ListBlobFlatSegment", "go");
@@clientName(
  Storage.Blob.Service.listContainers,
  "ListContainersSegment",
  "go"
);
@@clientName(
  Storage.Blob.PageBlob.setSequenceNumber,
  "UpdateSequenceNumber",
  "go"
);
@@clientName(Storage.Blob.Service.findBlobsByTags, "FilterBlobs", "go");
@@clientName(
  UserDelegationKey.signedDelegatedUserTid,
  "SignedDelegatedUserTenantID",
  "go"
);
@@clientName(UserDelegationKey.signedOid, "SignedOID", "go");
@@clientName(UserDelegationKey.signedTid, "SignedTID", "go");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(BlobItem, "omitSerdeMethods", "all", "go");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  Storage.Blob.Blob.download,
  "responseEnvelopeName",
  "BlobClientDownloadResponseInternal",
  "go"
);

@@clientName(QueryType, "QueryFormatType", "python");
@@clientName(
  Storage.Blob.BlockBlob.uploadBlobFromUrl,
  "putBlobFromUrl",
  "python"
);
@@clientName(BlobServiceProperties, "StorageServiceProperties", "python");
@@clientName(Storage.Blob.Blob.setProperties, "setHttpHeaders", "python");
@@clientName(
  Storage.Blob.PageBlob.setSequenceNumber,
  "updateSequenceNumber",
  "python"
);
@@clientName(Storage.Blob.Service.findBlobsByTags, "filterBlobs", "python");
@@clientName(Storage.Blob.Container.findBlobsByTags, "filterBlobs", "python");

@@alternateType(BlockIdParameter.blockid, string, "python");

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "This is to support legacy SDKs"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Storage.Blob.Container.listBlobs,
  "python,javascript,csharp"
);
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "This is to support legacy SDKs"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Storage.Blob.Container.listBlobHierarchySegment,
  "python,javascript,csharp"
);
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "This is to support legacy SDKs"
@@Azure.ClientGenerator.Core.Legacy.disablePageable(
  Storage.Blob.Service.listContainers,
  "python,javascript,csharp"
);

@@clientName(Storage.Blob.Container.listBlobs, "listBlobFlatSegment", "python");
@@clientName(
  Storage.Blob.Service.listContainers,
  "listContainersSegment",
  "python"
);

#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(Storage.Blob, "includeRootSlash", false, "javascript");

#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(Error, "header", "x-ms-error-code:errorCode", "javascript");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(Error, "restErrorCodeHeader", "x-ms-error-code", "javascript");
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  MetadataHeaders.metadata,
  "headerCollectionPrefix",
  "x-ms-meta",
  "javascript"
);

@@scope(Storage.Blob.RetentionPolicy.allowPermanentDelete, "!javascript");

@@scope(Storage.Blob.Container.listBlobFlatSegmentApacheArrow, "!rust");
@@scope(Storage.Blob.Container.listBlobHierarchySegmentApacheArrow, "!rust");
@@scope(Storage.Blob.Container.rename, "!rust");
@@scope(Storage.Blob.Container.restore, "!rust");
@@scope(Storage.Blob.Blob.copyFromUrl, "!rust");
@@scope(Storage.Blob.Blob.setExpiry, "!rust");
@@scope(Storage.Blob.BlockBlob.query, "!rust");
@@scope(Storage.Blob.PageBlob.copyIncremental, "!rust");
@@scope(Storage.Blob.PageBlob.getPageRangesDiff, "!rust");

@@alternateType(Storage.Blob.UserDelegationKey.signedStart, string, "python");
@@alternateType(Storage.Blob.UserDelegationKey.signedExpiry, string, "python");
@@alternateType(Storage.Blob.UserDelegationKey.value, string, "python");
@@alternateType(Storage.Blob.Block.name, string, "python");

/** The immutability policy expiration parameter. */
alias ImmutabilityPolicyExpiryOptionalParameter = {
  /** Specifies the date time when the blobs immutability policy is set to expire. */
  #suppress "@azure-tools/typespec-azure-core/known-encoding" "Existing API"
  @encode("rfc7231")
  @header("x-ms-immutability-policy-until-date")
  @clientName("immutabilityPolicyExpiry")
  expiry?: utcDateTime;
};

/** Defining an override for backward compatibility for existing sdks since the expiry
 * parameter was originally defined as optional in the swagger
 **/
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
@put
@route("?comp=immutabilityPolicies")
op setImmutabilityPolicyOptionalExpiry is StorageOperationNoBody<
  {
    ...TimeoutParameter;
    ...IfUnmodifiedSinceParameter;
    ...ImmutabilityPolicyExpiryOptionalParameter;
    ...ImmutabilityPolicyModeParameter;
    ...SnapshotParameter;
    ...VersionIdParameter;
  },
  {
    ...ImmutabilityPolicyExpiresOnResponseHeaderPrivate;
    ...ImmutabilityPolicyModeResponseHeaderPrivate;
  }
>;

@@override(
  Storage.Blob.Blob.setImmutabilityPolicy,
  setImmutabilityPolicyOptionalExpiry,
  "csharp,javascript"
);

// C# customizations

// Defining an override for backward compatibility for C# since the XML payload was serialized with the
// elements/properties in a different order than defined in the swagger.

/** The service properties. */
@Xml.name("StorageServiceProperties")
model BlobServicePropertiesCsharp {
  /** The logging properties. */
  @Xml.name("Logging") logging?: BlobServiceProperties.logging;

  /** The hour metrics properties. */
  @Xml.name("HourMetrics") hourMetrics?: BlobServiceProperties.hourMetrics;

  /** The minute metrics properties. */
  @Xml.name("MinuteMetrics")
  minuteMetrics?: BlobServiceProperties.minuteMetrics;

  /** The default service version. */
  @Xml.name("DefaultServiceVersion")
  defaultServiceVersion?: BlobServiceProperties.defaultServiceVersion;

  /** The delete retention policy. */
  @Xml.name("DeleteRetentionPolicy")
  deleteRetentionPolicy?: BlobServiceProperties.deleteRetentionPolicy;

  /** The static website properties. */
  @Xml.name("StaticWebsite")
  staticWebsite?: BlobServiceProperties.staticWebsite;

  /** The CORS properties. */
  @Xml.name("Cors") cors?: CorsRule[];
}

@@alternateType(BlobDeleteType, BlobDeleteTypeCustom, "csharp");
@@alternateType(BlobServiceProperties, BlobServicePropertiesCsharp, "csharp");
@@alternateType(AccessPolicy.start, utcDateTime, "csharp");
@@alternateType(AccessPolicy.expiry, utcDateTime, "csharp");
@@alternateType(LeaseBreakPeriodParameter.breakPeriod, int64, "csharp");
@@alternateType(LeaseDurationHeaderParameter.duration, int64, "csharp");
@@alternateType(BlobItem.metadata, Record<string>, "csharp");
@@alternateType(BlobItem.objectReplicationMetadata, Record<string>, "csharp");
@@alternateType(KeyInfo.delegatedUserTid, string, "csharp");
@@alternateType(IfMatchParameter.ifMatch, string, "csharp");
@@alternateType(IfNoneMatchParameter.ifNoneMatch, string, "csharp");
@@alternateType(ContainerProperties.eTag, string, "csharp");
@@alternateType(BlobProperties.eTag, string, "csharp");
@@alternateType(SourceIfMatchParameter.sourceIfMatch, string, "csharp");
@@alternateType(SourceIfNoneMatchParameter.sourceIfNoneMatch, string, "csharp");
@@alternateType(IfBlobMatchHeader.ifMatch, string, "csharp");
@@alternateType(IfBlobNoneMatchHeader.ifNoneMatch, string, "csharp");
@@alternateType(BlockIdParameter.blockid, string, "csharp");
@@alternateType(
  EncryptionAlgorithmType,
  EncryptionAlgorithmTypeCustom,
  "csharp"
);
@@clientName(BlobServicePropertiesCsharp, "BlobServiceProperties", "csharp");
@@clientName(GeoReplicationStatusType, "BlobGeoReplicationStatus", "csharp");
@@clientName(StorageErrorCode, "BlobErrorCode", "csharp");
@@clientName(Blob, "BlobRestClient", "csharp");
@@clientName(BlobItem, "BlobItemInternal", "csharp,python");
@@clientName(Container, "ContainerRestClient", "csharp");
@@clientName(Container.listBlobs, "ListBlobFlatSegment", "csharp");
@@clientName(Service, "ServiceRestClient", "csharp");
@@clientName(BlockBlob, "BlockBlobRestClient", "csharp");
@@clientName(PageBlob, "PageBlobRestClient", "csharp");
@@clientName(AppendBlob, "AppendBlobRestClient", "csharp");
@@clientName(BlobProperties, "BlobPropertiesInternal", "csharp");
@@clientName(ImmutabilityPolicyMode, "BlobImmutabilityPolicyMode", "csharp");
@@clientName(SignedIdentifiers, "BlobSignedIdentifiers", "csharp");
@@clientName(LeaseDuration, "LeaseDurationType", "csharp");
@@clientName(BlobItem.objectReplicationMetadata, "OrMetadata", "csharp");
@@clientName(Blob.setProperties, "SetHttpHeaders", "csharp");
@@clientName(ListBlobsResponse, "ListBlobsFlatSegmentResponse", "csharp");
@@clientName(
  ListBlobsHierarchicalResponse,
  "ListBlobsHierarchySegmentResponse",
  "csharp"
);
@@clientName(Container.findBlobsByTags, "FilterBlobs", "csharp");
@@clientName(Service.findBlobsByTags, "FilterBlobs", "csharp");
@@clientName(Service.listContainers, "ListContainersSegment", "csharp");
@@clientName(QueryType, "QueryFormatType", "csharp");
@@clientName(QueryType.JSON, "Json", "csharp");
@@clientName(ArrowField, "ArrowFieldInternal", "csharp");
@@clientName(ArrowConfiguration, "ArrowTextConfigurationInternal", "csharp");
@@clientName(ContainerItem, "ContainerItemInternal", "csharp");
@@clientName(ContainerProperties, "ContainerPropertiesInternal", "csharp");
@@clientName(
  DelimitedTextConfiguration,
  "DelimitedTextConfigurationInternal",
  "csharp"
);
@@clientName(JsonTextConfiguration, "JsonTextConfigurationInternal", "csharp");
@@clientName(StorageServiceStats, "BlobServiceStatistics", "csharp");
@@clientName(AccessPolicy.start, "PolicyStartsOn", "csharp");
@@clientName(AccessPolicy.expiry, "PolicyExpiresOn", "csharp");
@@clientName(AccessPolicy.permission, "Permissions", "csharp");
@@clientName(Metrics.includeApis, "IncludeApis", "csharp");
@@clientName(BlobType.BlockBlob, "Block", "csharp");
@@clientName(BlobType.PageBlob, "Page", "csharp");
@@clientName(BlobType.AppendBlob, "Append", "csharp");
@@clientName(SkuName.StandardLRS, "StandardLrs", "csharp");
@@clientName(SkuName.StandardGRS, "StandardGrs", "csharp");
@@clientName(SkuName.StandardRAGRS, "StandardRagrs", "csharp");
@@clientName(SkuName.StandardZRS, "StandardZrs", "csharp");
@@clientName(SkuName.PremiumLRS, "PremiumLrs", "csharp");
@@clientName(SkuName.StandardGZRS, "StandardGzrs", "csharp");
@@clientName(SkuName.PremiumZRS, "PremiumZrs", "csharp");
@@clientName(SkuName.StandardRAGZRS, "StandardRagzrs", "csharp");
@@clientName(
  ContentMd5Parameter.transactionalContentMd5,
  "transactionalContentMD5",
  "csharp"
);
@@clientName(BlobDeleteTypeCustom, "BlobDeleteType", "csharp");
@@clientName(
  EncryptionAlgorithmTypeCustom,
  "EncryptionAlgorithmType",
  "csharp"
);

@@access(BlobProperties, Access.internal, "csharp");
@@access(BlobItem, Access.internal, "csharp");
@@access(ArrowField, Access.internal, "csharp");
@@access(ArrowConfiguration, Access.internal, "csharp");
@@access(ContainerItem, Access.internal, "csharp");
@@access(ContainerProperties, Access.internal, "csharp");
@@access(DelimitedTextConfiguration, Access.internal, "csharp");
@@access(JsonTextConfiguration, Access.internal, "csharp");
@@access(BlobDeleteTypeCustom, Access.internal, "csharp");

@@convenientAPI(Storage.Blob.Service.submitBatch, false, "csharp");
@@convenientAPI(Storage.Blob.Container.submitBatch, false, "csharp");

#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(
  MetadataHeaders.metadata,
  "collectionHeaderPrefix",
  "x-ms-meta-",
  "csharp"
);
#suppress "@azure-tools/typespec-client-generator-core/client-option"
@@clientOption(Storage.Blob, "omitSlashFromEmptyRoute", true, "csharp,python");

/** ----- This section overrides the setMetadata operations for Rust to require the metadata headers ----- */
alias MetadataHeadersRequired = {
  /** The metadata headers. */
  @alternateType(Record<string>, "rust")
  @header("x-ms-meta")
  metadata: string;
};

/** operation sets one or more user-defined name-value pairs for the specified container. */
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
@put
@sharedRoute
@route("?restype=container&comp=metadata")
op setMetadataRequiredMetadataContainer is StorageOperationNoBody<
  {
    ...TimeoutParameter;
    ...LeaseIdOptionalParameter;
    ...MetadataHeadersRequired;
    ...IfModifiedSinceParameter;
  },
  {
    ...EtagResponseHeaderPrivate;
    ...LastModifiedResponseHeaderPrivate;
  }
>;

@@override(Container.setMetadata, setMetadataRequiredMetadataContainer, "rust");

/** The Set Metadata operation sets user-defined metadata for the specified blob as one or more name-value pairs. */
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
@put
@route("?comp=metadata")
op setMetadataRequiredMetadataBlob is StorageOperationNoBody<
  {
    ...TimeoutParameter;
    ...MetadataHeadersRequired;
    ...LeaseIdOptionalParameter;
    ...EncryptionKeyParameter;
    ...EncryptionKeySha256Parameter;
    ...EncryptionAlgorithmParameter;
    ...EncryptionScopeParameter;
    ...IfModifiedSinceParameter;
    ...IfUnmodifiedSinceParameter;
    ...IfNoneMatchParameter;
    ...IfMatchParameter;
    ...IfTagsParameter;
  },
  {
    ...EtagResponseHeaderPrivate;
    ...LastModifiedResponseHeaderPrivate;
    ...VersionIdResponseHeaderPrivate;
    ...RequestServerEncryptedResponseHeaderPrivate;
    ...EncryptionKeySha256ResponseHeaderPrivate;
    ...EncryptionScopeResponseHeaderPrivate;
  }
>;

@@override(Blob.setMetadata, setMetadataRequiredMetadataBlob, "rust");

/** ----- This section overrides the setAccessPolicy operation for Rust to require the containerAcl body ----- */
/** Sets the permissions for the specified container. The permissions indicate whether blobs in a container may be accessed publicly. */
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
@put
@route("?restype=container&comp=acl")
op setAccessPolicyRequiredContainerAcl is StorageOperationNoBody<
  {
    /** The media type of the requestbody */
    @header("Content-Type")
    contentType?: "application/xml";

    /** The access control list for the container. */
    #suppress "@azure-tools/typespec-azure-core/request-body-problem" "Existing API"
    @body
    containerAcl: SignedIdentifiers;

    ...TimeoutParameter;
    ...LeaseIdOptionalParameter;
    ...BlobPublicAccessParameter;
    ...IfModifiedSinceParameter;
    ...IfUnmodifiedSinceParameter;
  },
  {
    ...EtagResponseHeaderPrivate;
    ...LastModifiedResponseHeaderPrivate;
  }
>;

@@override(
  Container.setAccessPolicy,
  setAccessPolicyRequiredContainerAcl,
  "rust"
);

/** ----- This section overrides operations for Rust to omit structured message parameters ----- */
/** The Append Block operation commits a new block of data to the end of an append blob. */
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
#suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
@put
@sharedRoute
@route("?comp=appendblock")
op appendBlockNoStructuredMessage is StorageOperationRequestBody<
  {
    /** The data to upload. */
    ...BodyParameter;

    ...TimeoutParameter;
    ...ContentLengthParameter;
    ...ContentMd5Parameter;
    ...ContentCrc64Parameter;
    ...LeaseIdOptionalParameter;
    ...BlobConditionMaxSizeParameter;
    ...BlobConditionAppendPosParameter;
    ...EncryptionKeyParameter;
    ...EncryptionKeySha256Parameter;
    ...EncryptionAlgorithmParameter;
    ...EncryptionScopeParameter;
    ...IfModifiedSinceParameter;
    ...IfUnmodifiedSinceParameter;
    ...IfNoneMatchParameter;
    ...IfMatchParameter;
    ...IfTagsParameter;
  },
  {
    @statusCode statusCode: 201;
    ...EtagResponseHeader;
    ...LastModifiedResponseHeader;
    ...ContentMd5ResponseHeader;
    ...ContentCrc64ResponseHeader;
    ...BlobAppendOffsetResponseHeader;
    ...BlobCommittedBlockCountResponseHeader;
    ...RequestServerEncryptedResponseHeader;
    ...EncryptionKeySha256ResponseHeader;
    ...EncryptionScopeResponseHeader;
  },
  "application/octet-stream"
>;

@@override(AppendBlob.appendBlock, appendBlockNoStructuredMessage, "rust");

/** The Stage Block operation creates a new block to be committed as part of a blob. */
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
#suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
@put
@sharedRoute
@route("?comp=block")
op stageBlockNoStructuredMessage is StorageOperationRequestBody<
  {
    ...BlockIdParameter;
    ...ContentLengthParameter;
    ...ContentMd5Parameter;
    ...ContentCrc64Parameter;
    ...BodyParameter;
    ...TimeoutParameter;
    ...LeaseIdOptionalParameter;
    ...EncryptionKeyParameter;
    ...EncryptionKeySha256Parameter;
    ...EncryptionAlgorithmParameter;
    ...EncryptionScopeParameter;
  },
  {
    @statusCode statusCode: 201;
    ...ContentMd5ResponseHeader;
    ...ContentCrc64ResponseHeader;
    ...RequestServerEncryptedResponseHeader;
    ...EncryptionKeySha256ResponseHeader;
    ...EncryptionScopeResponseHeader;
  },
  "application/octet-stream"
>;

@@override(BlockBlob.stageBlock, stageBlockNoStructuredMessage, "rust");

/** The Upload Pages operation writes a range of pages to a page blob. */
#suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
#suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
#suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
#suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
@put
@sharedRoute
@route("?comp=page")
op uploadPagesNoStructuredMessage is StorageOperationRequestBody<
  {
    /** The data to upload. */
    ...BodyParameter;

    ...ContentLengthParameter;
    ...ContentMd5Parameter;
    ...ContentCrc64Parameter;
    ...TimeoutParameter;
    ...RangeParameterRequired;
    ...LeaseIdOptionalParameter;
    ...EncryptionKeyParameter;
    ...EncryptionKeySha256Parameter;
    ...EncryptionAlgorithmParameter;
    ...EncryptionScopeParameter;
    ...IfSequenceNumberLessThanOrEqualToParameter;
    ...IfSequenceNumberLessThanParameter;
    ...IfSequenceNumberEqualToParameter;
    ...IfModifiedSinceParameter;
    ...IfUnmodifiedSinceParameter;
    ...IfNoneMatchParameter;
    ...IfMatchParameter;
    ...IfTagsParameter;
    ...PageWriteParameter<"update">;
  },
  {
    @statusCode statusCode: 201;
    ...EtagResponseHeader;
    ...LastModifiedResponseHeader;
    ...ContentMd5ResponseHeader;
    ...ContentCrc64ResponseHeader;
    ...BlobSequenceNumberResponseHeader;
    ...RequestServerEncryptedResponseHeader;
    ...EncryptionKeySha256ResponseHeader;
    ...EncryptionScopeResponseHeader;
  },
  "application/octet-stream"
>;

@@override(PageBlob.uploadPages, uploadPagesNoStructuredMessage, "rust");

/** An HTTP byte range, e.g. "bytes=0-1023". */
@alternateType(
  {
    identity: "crate::models::HttpRange",
  },
  "rust"
)
scalar HttpRange extends string;
