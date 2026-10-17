import "@azure-tools/typespec-azure-core";
import "@typespec/http";
import "./models.tsp";
import "@typespec/versioning";

namespace Storage.Blob;

using TypeSpec.Http;
using Azure.Core;
using Azure.ClientGenerator.Core;
using TypeSpec.Versioning;

alias ApiVersionHeader = {
  /** Specifies the version of the operation to use for this request. */
  @apiVersion
  @access(Access.internal)
  @header("x-ms-version")
  version: string;
};

/** Azure Storage Blob basic operation template */
#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
op StorageOperation<
  TParams extends TypeSpec.Reflection.Model | void,
  TResponse extends TypeSpec.Reflection.Model | void,
  RequestMediaType extends string = "application/xml",
  ResponseMediaType extends string = "application/xml",
  TError = Error
>(
  /** Content-Type header */
  #suppress "@typespec/http/content-type-ignored" "Template for existing API"
  @header("Content-Type")
  contentType: RequestMediaType,

  ...ApiVersionHeader,
  ...ClientRequestIdHeader,
  ...TParams,
):
  | (TResponse & {
      /** Content-Type header */
      #suppress "@typespec/http/content-type-ignored" "Template for existing API"
      @header("Content-Type")
      contentType: ResponseMediaType;

      ...DateResponseHeaderPrivate;
      ...ApiVersionHeader;
      ...RequestIdResponseHeader;
      ...ClientRequestIdHeader;
    })
  | TError;

/** Azure Storage Blob basic operation template */
#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
op StorageOperationNoBody<
  TParams extends TypeSpec.Reflection.Model | void,
  TResponse extends TypeSpec.Reflection.Model | void,
  TError = Error
>(...ApiVersionHeader, ...ClientRequestIdHeader, ...TParams):
  | (TResponse & {
      ...DateResponseHeaderPrivate;
      ...ApiVersionHeader;
      ...RequestIdResponseHeader;
      ...ClientRequestIdHeader;
    })
  | TError;

/** Azure Storage Blob basic operation template */
#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
op StorageOperationResponseBody<
  TParams extends TypeSpec.Reflection.Model | void,
  TResponse extends TypeSpec.Reflection.Model | void,
  ResponseMediaType extends string = "application/xml",
  TError = Error
> is StorageOperationNoBody<
  TParams,
  {
    /** Content-Type header */
    #suppress "@typespec/http/content-type-ignored" "Template for existing API"
    @header("Content-Type")
    contentType: ResponseMediaType;
  } & TResponse,
  TError
>;

/** Azure Storage Blob basic operation template */
#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
op StorageOperationRequestBody<
  TParams extends TypeSpec.Reflection.Model | void,
  TResponse extends TypeSpec.Reflection.Model | void,
  RequestMediaType extends string = "application/xml",
  TError = Error
> is StorageOperationNoBody<
  {
    /** Content-Type header */
    #suppress "@typespec/http/content-type-ignored" "Template for existing API"
    @header("Content-Type")
    contentType: RequestMediaType;
  } & TParams,
  TResponse,
  TError
>;

#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
interface Service {
  /** Sets properties for a storage account's Blob service endpoint, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @route("?restype=service&comp=properties")
  setProperties is StorageOperationRequestBody<
    {
      ...TimeoutParameter;

      /** The storage service properties to set. */
      @body
      storageServiceProperties: BlobServiceProperties;
    },
    {
      @statusCode statusCode: 202;
    }
  >;

  /** Retrieves properties of a storage account's Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @get
  @route("?restype=service&comp=properties")
  getProperties is StorageOperationResponseBody<
    TimeoutParameter,
    BlobServiceProperties
  >;

  /** Retrieves statistics related to replication for the Blob service. It is only available on the secondary location endpoint when read-access geo-redundant replication is enabled for the storage account. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @get
  @route("?restype=service&comp=stats")
  getStatistics is StorageOperationResponseBody<
    TimeoutParameter,
    {
      /** Storage service statistics */
      @body
      storageServiceStats: StorageServiceStats;
    }
  >;

  /** Returns a list of the containers in the specified account. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @list
  @route("?comp=list")
  listContainers is StorageOperationResponseBody<
    {
      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...TimeoutParameter;

      /** Specify to include additional, optional information. */
      @query include?: Array<ListContainersIncludeType>;
    },
    ListContainersResponse
  >;

  /** Retrieves a user delegation key for the Blob service. This is only a valid operation when using bearer token authentication. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @post
  @route("?restype=service&comp=userdelegationkey")
  getUserDelegationKey is StorageOperation<
    {
      /** Key information provided in the request. */
      @body
      keyInfo: KeyInfo;

      ...TimeoutParameter;
    },
    {
      /** The user delegation key. */
      @body
      userDelegationKey: UserDelegationKey;
    }
  >;

  /** Returns information about the storage account. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @get
  @route("?restype=account&comp=properties")
  @sharedRoute
  getAccountInfo is StorageOperationNoBody<
    TimeoutParameter,
    {
      ...SkuNameResponseHeader;
      ...AccountKindResponseHeader;

      /** Indicates if the account has hierarchical namespace enabled. */
      @header("x-ms-is-hns-enabled")
      isHierarchicalNamespaceEnabled?: boolean;
    }
  >;

  /** Allows multiple API calls to be embedded into a single HTTP request. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @post
  @route("?comp=batch")
  submitBatch(
    /** The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_<GUID> */
    @header("Content-Type")
    @alternateType(string, "javascript,csharp,go")
    @clientName("multipartContentType", "go")
    contentType: "multipart/mixed",

    ...ApiVersionHeader,
    ...TimeoutParameter,
    ...ClientRequestIdHeader,
    ...ContentLengthParameter,

    /** The batch request content. */
    ...MultipartBodyParameter,
  ):
    | (MultipartBodyParameter & {
        @statusCode statusCode: 202;

        /** The media type of the body of the response. For batch requests, this is multipart/mixed; boundary=batchresponse_GUID */
        #suppress "@typespec/http/content-type-ignored" "Template for existing API"
        @header("Content-Type")
        @alternateType(string, "go")
        contentType: "multipart/mixed";

        ...ApiVersionHeader;
        ...RequestIdResponseHeader;
        ...ClientRequestIdHeader;
      })
    | Error;

  /** Lists blobs across all containers whose tags match a given search expression. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @list
  @route("?comp=blobs")
  findBlobsByTags is StorageOperationResponseBody<
    {
      ...TimeoutParameter;
      ...FilterBlobsWhereParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...FilterBlobsIncludeParameter;
    },
    {
      /** The filter blobs enumeration results. */
      @body
      enumerationResults: FilteredBlobResponse;
    }
  >;
}

#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
interface Container {
  /** Creates a new container in the specified account. If the container with the same name already exists, the operation fails. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @route("?restype=container")
  create is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...MetadataHeaders;
      ...BlobPublicAccessParameter;

      /** Specifies the default encryption scope to set on the container and use for all future requests. */
      @header("x-ms-default-encryption-scope")
      defaultEncryptionScope?: string;

      ...DenyEncryptionScopeOverrideParameter;
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeaderPrivate;
      ...LastModifiedResponseHeaderPrivate;
    }
  >;

  /** Returns all user-defined metadata and system properties for the specified container. The data returned does not include the container's list of blobs. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @get
  @route("?restype=container")
  getProperties is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
    },
    {
      ...MetadataHeaders;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...LeaseDurationResponseHeader;
      ...LeaseStateResponseHeader;
      ...LeaseStatusResponseHeader;
      ...BlobPublicAccessResponseHeader;

      /** Indicates whether the container has an immutability policy set on it. */
      @header("x-ms-has-immutability-policy")
      hasImmutabilityPolicy?: boolean;

      /** Indicates whether the container has a legal hold. */
      @header("x-ms-has-legal-hold")
      hasLegalHold?: boolean;

      /** The default encryption scope for the container. */
      @header("x-ms-default-encryption-scope")
      defaultEncryptionScope?: string;

      ...DenyEncryptionScopeOverrideResponseHeader;

      /** Indicates whether version level WORM (Write Once, Read Many) is enabled on a container. */
      @header("x-ms-immutable-storage-with-versioning-enabled")
      isImmutableStorageWithVersioningEnabled?: boolean;
    }
  >;

  /** Deletes the specified container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @delete
  @route("?restype=container")
  delete is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
    },
    {
      @statusCode statusCode: 202;
    }
  >;

  /** Sets user-defined metadata for the specified container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?restype=container&comp=metadata")
  setMetadata is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...MetadataHeaders;
      ...IfModifiedSinceParameter;
    },
    {
      ...EtagResponseHeaderPrivate;
      ...LastModifiedResponseHeaderPrivate;
    }
  >;

  /** Gets the permissions for the specified container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @get
  @route("?restype=container&comp=acl")
  getAccessPolicy is StorageOperationResponseBody<
    {
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
    },
    {
      /** Signed identifiers */
      @body body: SignedIdentifiers;

      ...BlobPublicAccessResponseHeader;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Sets the permissions for the specified container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?restype=container&comp=acl")
  setAccessPolicy is StorageOperationNoBody<
    {
      /** The content type of the request. */
      @header("Content-Type")
      contentType?: "application/xml";

      /** The access control list for the container. */
      #suppress "@azure-tools/typespec-azure-core/request-body-problem" "Existing API"
      @body
      containerAcl?: SignedIdentifiers;

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

  /** Restores the specified previously-deleted container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?restype=container&comp=undelete")
  restore is StorageOperationNoBody<
    {
      /** Specifies the name of the deleted container to restore. */
      @header("x-ms-deleted-container-name")
      deletedContainerName?: string;

      /** Specifies the version of the deleted container to restore. */
      @header("x-ms-deleted-container-version")
      deletedContainerVersion?: string;

      ...TimeoutParameter;
    },
    {
      @statusCode statusCode: 201;
    }
  >;

  /** Renames the specified existing container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?restype=container&comp=rename")
  rename is StorageOperationNoBody<
    {
      /** Specifies the name of the container to rename. */
      @header("x-ms-source-container-name")
      sourceContainerName: string;

      /** A lease ID for the source path. If specified, the source path must have an active lease and the lease ID must match. */
      @header("x-ms-source-lease-id")
      sourceLeaseId?: string;

      ...TimeoutParameter;
    },
    {}
  >;

  /** Allows multiple API calls to be embedded into a single HTTP request. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @post
  @route("?restype=container&comp=batch")
  submitBatch(
    /** The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_<GUID> */
    @header("Content-Type")
    @alternateType(string, "javascript,csharp,go")
    @clientName("multipartContentType", "go")
    contentType: "multipart/mixed",

    ...ApiVersionHeader,
    ...TimeoutParameter,
    ...ClientRequestIdHeader,
    ...ContentLengthParameter,

    /** The batch request content. */
    ...MultipartBodyParameter,
  ):
    | ({
        @statusCode statusCode: 202;

        /** The value of this header must be multipart/mixed with a batch boundary. Example header value: multipart/mixed; boundary=batch_<GUID> */
        @header("Content-Type")
        @alternateType(string, "go")
        contentType: "multipart/mixed";

        ...RequestIdResponseHeader;
        ...ApiVersionHeader;
      } & MultipartBodyParameter)
    | Error;

  /** Lists blobs in the specified container whose tags match a given search expression. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @get
  @list
  @route("?restype=container&comp=blobs")
  findBlobsByTags is StorageOperationResponseBody<
    {
      ...TimeoutParameter;
      ...FilterBlobsWhereParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...FilterBlobsIncludeParameter;
    },
    {
      /** The container filter blob enumeration results. */
      @body
      enumerationResults: FilteredBlobResponse;
    }
  >;

  /** Requests a new lease on the specified container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease&restype=container")
  acquireLease is StorageOperationNoBody<
    {
      ...LeaseDurationHeaderParameter;
      ...TimeoutParameter;
      ...ProposedLeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...LeaseActionParameter<"acquire">;
    },
    {
      @statusCode statusCode: 201;
      ...LeaseIdResponseHeader;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Frees the lease if it's no longer needed, so that another client can immediately acquire a lease against the container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease&restype=container")
  releaseLease is StorageOperationNoBody<
    {
      ...LeaseIdRequiredParameter;
      ...TimeoutParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...LeaseActionParameter<"release">;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Renews an existing lease. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease&restype=container")
  renewLease is StorageOperationNoBody<
    {
      ...LeaseIdRequiredParameter;
      ...TimeoutParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...LeaseActionParameter<"renew">;
    },
    {
      ...LeaseIdResponseHeader;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Ends a lease and ensures that another client can't acquire a new lease until the current lease period has expired. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease&restype=container")
  breakLease is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...LeaseBreakPeriodParameter;
      ...LeaseActionParameter<"break">;
    },
    {
      @statusCode statusCode: 202;
      ...LeaseTimeResponseHeader;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Change the ID of an existing lease. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease&restype=container")
  changeLease is StorageOperationNoBody<
    {
      ...LeaseIdRequiredParameter;
      ...ProposedLeaseIdRequiredParameter;
      ...TimeoutParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...LeaseActionParameter<"change">;
    },
    {
      ...LeaseIdResponseHeader;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Returns a list of the blobs in the specified container. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @get
  @list
  @sharedRoute
  @route("?restype=container&comp=list")
  listBlobs is StorageOperationResponseBody<
    {
      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...ListBlobsIncludeParameter;
      ...TimeoutParameter;
      ...ListBlobsStartFrom;
    },
    {
      /** The list of blobs in the container. */
      @body
      enumerationResults: ListBlobsResponse;
    }
  >;

  /** Returns a list of the blobs in Apache Arrow format as raw data, to be deserialized by the client. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Fixed set of content types returned by the service"
  @added(Versions.v2026_12_06)
  @get
  @sharedRoute
  @route("?restype=container&comp=list")
  listBlobFlatSegmentApacheArrow is StorageOperationResponseBody<
    {
      /** The Accept header indicating the response should be returned as an Apache Arrow stream, falling back to XML otherwise. */
      #suppress "@typespec/http/content-type-ignored" "Raw response, deserialized by client"
      @header("accept")
      accept: "application/vnd.apache.arrow.stream,application/xml";

      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...ListBlobsIncludeParameter;
      ...TimeoutParameter;
      ...ListBlobsStartFrom;
      ...ListBlobsEndBefore;
    },
    {
      @body body: bytes;
    },
    "application/vnd.apache.arrow.stream" | "application/xml"
  >;

  /** Returns a list of the blobs as raw data, to be deserialized by the client. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Fixed set of content types returned by the service"
  @added(Versions.v2026_12_06)
  @access(Access.internal)
  @scope("rust")
  @get
  @sharedRoute
  @route("?restype=container&comp=list")
  listBlobsInternal is StorageOperationResponseBody<
    {
      /** The Accept header indicating the requested response media type. */
      #suppress "@typespec/http/content-type-ignored" "Raw response, deserialized by client"
      @header("accept")
      accept: string;

      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...ListBlobsIncludeParameter;
      ...TimeoutParameter;
      ...ListBlobsStartFrom;
      ...ListBlobsEndBefore;
    },
    {
      @body body: bytes;
    },
    "application/vnd.apache.arrow.stream" | "application/xml"
  >;

  /** Returns a list of the blobs in the specified container. A delimiter can be used to traverse a virtual hierarchy of blobs as though it were a file system. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @get
  @list
  @sharedRoute
  @route("?restype=container&comp=list")
  listBlobHierarchySegment is StorageOperationResponseBody<
    {
      /** If specified, the operation returns a BlobPrefix element that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string. */
      @query delimiter: string;

      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...ListBlobsIncludeParameter;
      ...TimeoutParameter;
      ...ListBlobsStartFrom;
    },
    {
      /** The list of blobs in the container. */
      @body
      enumerationResults: ListBlobsHierarchicalResponse;
    }
  >;

  /** Returns a list of the blobs in Apache Arrow format as raw data, to be deserialized by the client. A delimiter can be used to traverse a virtual hierarchy of blobs as though it were a file system. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Fixed set of content types returned by the service"
  @added(Versions.v2026_12_06)
  @get
  @sharedRoute
  @route("?restype=container&comp=list")
  listBlobHierarchySegmentApacheArrow is StorageOperationResponseBody<
    {
      /** The Accept header indicating the response should be returned as an Apache Arrow stream, falling back to XML otherwise. */
      #suppress "@typespec/http/content-type-ignored" "Raw response, deserialized by client"
      @header("accept")
      accept: "application/vnd.apache.arrow.stream,application/xml";

      /** If specified, the operation returns a BlobPrefix element that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string. */
      @query delimiter: string;

      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...ListBlobsIncludeParameter;
      ...TimeoutParameter;
      ...ListBlobsStartFrom;
      ...ListBlobsEndBefore;
    },
    {
      @body body: bytes;
    },
    "application/vnd.apache.arrow.stream" | "application/xml"
  >;

  /** Returns a list of the blobs as raw data, to be deserialized by the client. A delimiter can be used to traverse a virtual hierarchy of blobs as though it were a file system. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Keeping operation shape inline with existing service patterns"
  #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Fixed set of content types returned by the service"
  @added(Versions.v2026_12_06)
  @access(Access.internal)
  @scope("rust")
  @get
  @sharedRoute
  @route("?restype=container&comp=list")
  listBlobsHierarchicalInternal is StorageOperationResponseBody<
    {
      /** The Accept header indicating the requested response media type. */
      #suppress "@typespec/http/content-type-ignored" "Raw response, deserialized by client"
      @header("accept")
      accept: string;

      /** If specified, the operation returns a BlobPrefix element that acts as a placeholder for all blobs whose names begin with the same substring up to the appearance of the delimiter character. The delimiter may be a single character or a string. */
      @query delimiter: string;

      ...PrefixParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
      ...ListBlobsIncludeParameter;
      ...TimeoutParameter;
      ...ListBlobsStartFrom;
      ...ListBlobsEndBefore;
    },
    {
      @body body: bytes;
    },
    "application/vnd.apache.arrow.stream" | "application/xml"
  >;

  /** Returns information about the storage account. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @get
  @route("?restype=account&comp=properties")
  @sharedRoute
  getAccountInfo is StorageOperationNoBody<
    {
      ...TimeoutParameter;
    },
    {
      ...SkuNameResponseHeader;
      ...AccountKindResponseHeader;
      ...IsHierarchicalNamespaceEnabled;
    }
  >;
}

#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
interface Blob {
  /** Downloads the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @get
  download(
    ...ApiVersionHeader,
    ...ClientRequestIdHeader,
    ...SnapshotParameter,
    ...VersionIdParameter,
    ...TimeoutParameter,
    ...RangeParameter,
    ...LeaseIdOptionalParameter,

    /** When set to true and specified together with the `Range` header, the service returns the MD5 hash for the range, as long as the range is less than or equal to 4 MiB in size. */
    @clientName("rangeGetContentMD5", "javascript")
    @header("x-ms-range-get-content-md5")
    rangeGetContentMd5?: boolean,

    /** When set to true and the request includes a Range header, the service returns the CRC64 hash for the range, as long as the range is less than or equal to 4 MiB in size. */
    @header("x-ms-range-get-content-crc64")
    rangeGetContentCrc64?: boolean,

    /** Specifies the response content should be returned as a structured message and specifies the message schema version and properties. */
    @access(Access.internal)
    @header("x-ms-structured-body")
    structuredBodyType?: string,

    ...EncryptionKeyParameter,
    ...EncryptionKeySha256Parameter,
    ...EncryptionAlgorithmParameter,
    ...IfTagsParameter,
    ...IfModifiedSinceParameter,
    ...IfUnmodifiedSinceParameter,
    ...IfNoneMatchParameter,
    ...IfMatchParameter,
  ):
    | (BodyParameter & {
        /** The content type of the body of the response. */
        @header("Content-Type")
        contentType: "application/octet-stream";

        ...RequestIdResponseHeader;
        ...ClientRequestIdHeader;
        ...MetadataHeaders;
        ...ObjectReplicationHeaders;
        ...LastModifiedResponseHeader;
        ...CreationTimeResponseHeader;
        ...ObjectReplicationPolicyIdResponseHeader;
        ...ContentLengthResponseHeader;
        ...ContentRangeResponseHeader;
        ...EtagResponseHeader;
        ...ContentMd5ResponseHeader;
        ...ContentEncodingResponseParameter;
        ...CacheControlResponseHeader;
        ...ContentDispositionResponseHeader;
        ...ContentLanguageResponseHeader;
        ...BlobSequenceNumberResponseHeader;
        ...BlobTypeResponseHeader;

        /** The CRC64 hash of the content. */
        @added(Versions.v2026_10_06)
        @header("x-ms-content-crc64")
        contentCrc64?: bytes;

        ...CopyCompletionTimeResponseHeader;
        ...CopyStatusDescriptionResponseHeader;
        ...CopyIdResponseHeader;
        ...CopyProgressResponseHeader;
        ...CopyStatusResponseHeader;
        ...CopySourceResponseHeader;
        ...LeaseDurationResponseHeader;
        ...LeaseStateResponseHeader;
        ...LeaseStatusResponseHeader;
        ...VersionIdResponseHeader;
        ...IsCurrentVersionResponseHeader;
        ...AcceptRangesResponseHeaderPrivate;
        ...DateResponseHeaderPrivate;
        ...BlobCommittedBlockCountResponseHeader;
        ...ServerEncryptedResponseHeader;
        ...EncryptionKeySha256ResponseHeader;
        ...EncryptionScopeResponseHeader;
        ...BlobContentMd5ResponseHeader;
        ...TagCountResponseHeader;
        ...IsSealedResponseHeader;
        ...LastAccessedResponseHeader;
        ...ImmutabilityPolicyExpiresOnResponseHeader;
        ...ImmutabilityPolicyModeResponseHeader;
        ...LegalHoldOptionalResponseHeader;
        ...StructuredBodyTypeResponseHeader;
        ...StructuredContentLengthResponseHeader;

        /** The access tier of the blob. */
        @added(Versions.v2026_10_06)
        @header("x-ms-access-tier")
        accessTier?: string;

        /** Included if the access tier is inferred. */
        @added(Versions.v2026_10_06)
        @header("x-ms-access-tier-inferred")
        accessTierInferred?: boolean;

        ...AccessTierChangeTimeResponseHeaderV2026_10_06;

        /** The underlying tier of a smart tier blob. Only returned if the blob is in Smart tier. */
        @added(Versions.v2026_10_06)
        @header("x-ms-smart-access-tier")
        smartAccessTier?: string;

        ...ApiVersionHeader;
      })
    | (BodyParameter & {
        #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Following standard pattern"
        @statusCode statusCode: 206;

        /** The content type of the body of the response. */
        @header("Content-Type")
        contentType: "application/octet-stream";

        ...RequestIdResponseHeader;
        ...ClientRequestIdHeader;
        ...MetadataHeaders;
        ...ObjectReplicationHeaders;
        ...LastModifiedResponseHeader;
        ...CreationTimeResponseHeader;
        ...ObjectReplicationPolicyIdResponseHeader;
        ...ContentLengthResponseHeader;
        ...ContentRangeResponseHeader;
        ...EtagResponseHeader;
        ...ContentMd5ResponseHeader;
        ...ContentEncodingResponseParameter;
        ...CacheControlResponseHeader;
        ...ContentDispositionResponseHeader;
        ...ContentLanguageResponseHeader;
        ...BlobSequenceNumberResponseHeader;
        ...BlobTypeResponseHeader;
        ...ContentCrc64ResponseHeader;
        ...CopyCompletionTimeResponseHeader;
        ...CopyStatusDescriptionResponseHeader;
        ...CopyIdResponseHeader;
        ...CopyProgressResponseHeader;
        ...CopyStatusResponseHeader;
        ...CopySourceResponseHeader;
        ...LeaseDurationResponseHeader;
        ...LeaseStateResponseHeader;
        ...LeaseStatusResponseHeader;
        ...VersionIdResponseHeader;
        ...IsCurrentVersionResponseHeader;
        ...AcceptRangesResponseHeaderPrivate;
        ...DateResponseHeaderPrivate;
        ...BlobCommittedBlockCountResponseHeader;
        ...ServerEncryptedResponseHeader;
        ...EncryptionKeySha256ResponseHeader;
        ...EncryptionScopeResponseHeader;
        ...BlobContentMd5ResponseHeader;
        ...TagCountResponseHeader;
        ...IsSealedResponseHeader;
        ...LastAccessedResponseHeader;
        ...ImmutabilityPolicyExpiresOnResponseHeader;
        ...ImmutabilityPolicyModeResponseHeader;
        ...LegalHoldOptionalResponseHeader;
        ...StructuredBodyTypeResponseHeader;
        ...StructuredContentLengthResponseHeader;

        /** The access tier of the blob. */
        @added(Versions.v2026_10_06)
        @header("x-ms-access-tier")
        accessTier?: string;

        /** Included if the access tier is inferred. */
        @added(Versions.v2026_10_06)
        @header("x-ms-access-tier-inferred")
        accessTierInferred?: boolean;

        ...AccessTierChangeTimeResponseHeaderV2026_10_06;

        /** The underlying tier of a smart tier blob. Only returned if the blob is in Smart tier. */
        @added(Versions.v2026_10_06)
        @header("x-ms-smart-access-tier")
        smartAccessTier?: string;

        ...ApiVersionHeader;
      })
    | Error;

  /** Returns all user-defined metadata, standard HTTP properties, and system properties for the specified blob. It does not return the content of the blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @head
  getProperties is StorageOperationNoBody<
    {
      ...SnapshotParameter;
      ...VersionIdParameter;
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
    },
    {
      /** Content-type. */
      #suppress "@typespec/http/content-type-ignored" "This is a HEAD operation, so content-type header can be returned."
      @header("Content-Type")
      contentType?: string;

      ...MetadataHeaders;
      ...ObjectReplicationHeaders;
      ...LastModifiedResponseHeader;
      ...CreationTimeResponseHeader;
      ...ObjectReplicationPolicyIdResponseHeader;
      ...BlobTypeResponseHeader;
      ...CopyCompletionTimeResponseHeader;
      ...CopyStatusDescriptionResponseHeader;
      ...CopyIdResponseHeader;
      ...CopyProgressResponseHeader;
      ...CopyStatusResponseHeader;
      ...CopySourceResponseHeader;

      /** Included if the blob is incremental copy blob. */
      @header("x-ms-incremental-copy")
      isIncrementalCopy?: boolean;

      /** Included if the blob is incremental copy blob or incremental copy snapshot, if x-ms-copy-status is success. */
      @header("x-ms-copy-destination-snapshot")
      destinationSnapshot?: string;

      ...LeaseDurationResponseHeader;
      ...LeaseStateResponseHeader;
      ...LeaseStatusResponseHeader;
      ...ContentLengthResponseHeader;
      ...EtagResponseHeader;
      ...ContentMd5ResponseHeader;
      ...ContentEncodingResponseParameter;
      ...ContentDispositionResponseHeader;
      ...ContentLanguageResponseHeader;
      ...CacheControlResponseHeader;
      ...BlobSequenceNumberResponseHeader;
      ...AcceptRangesResponseHeaderPrivate;
      ...BlobCommittedBlockCountResponseHeader;
      ...ServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;

      /** The access tier of the blob. */
      @header("x-ms-access-tier")
      accessTier?: string;

      /** Included if the access tier is inferred. */
      @header("x-ms-access-tier-inferred")
      accessTierInferred?: boolean;

      /** Included if the blob rehydrate operation is pending. Indicates the destination tier. */
      @header("x-ms-archive-status")
      @alternateType(string, "go")
      archiveStatus?: ArchiveStatus;

      ...AccessTierChangeTimeResponseHeader;

      /** The underlying tier of a smart tier blob. Only returned if the blob is in Smart tier. */
      @added(Versions.v2026_06_06)
      @header("x-ms-smart-access-tier")
      smartAccessTier?: string;

      ...VersionIdResponseHeader;
      ...IsCurrentVersionResponseHeader;
      ...TagCountResponseHeader;
      ...ExpiryTimeResponseHeader;
      ...IsSealedResponseHeader;
      ...RehydratePriorityResponseHeader;
      ...LastAccessedResponseHeader;
      ...ImmutabilityPolicyExpiresOnResponseHeader;
      ...ImmutabilityPolicyModeResponseHeader;
      ...LegalHoldOptionalResponseHeader;
    }
  >;

  /** Deletes the specified blob. If blob soft delete is enabled, the blob is marked for deletion and can be recovered until the retention period expires. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @delete
  delete is StorageOperationNoBody<
    {
      ...SnapshotParameter;
      ...VersionIdParameter;
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;

      /** Required if the blob has associated snapshots. Specifies the delete behavior. */
      @header("x-ms-delete-snapshots")
      deleteSnapshots?: DeleteSnapshotsOptionType;

      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;

      /** The delete type. */
      @query
      @clientName("blobDeleteType")
      deletetype?: BlobDeleteType;

      ...AccessTierIfModifiedSinceParameter;
      ...AccessTierIfUnmodifiedSinceParameter;
    },
    {
      @statusCode statusCode: 202;
    }
  >;

  /** Undelete the specified previously soft deleted blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @route("?comp=undelete")
  undelete is StorageOperationNoBody<
    {
      ...TimeoutParameter;
    },
    {}
  >;

  /** Set the expiration time of the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @route("?comp=expiry")
  setExpiry is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...BlobExpiryOptionsParameter;
      ...ExpiryTimeParameter;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Sets system properties on the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=properties")
  setProperties is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...BlobCacheControlParameter;
      ...BlobContentTypeParameter;
      ...BlobContentMd5Parameter;
      ...BlobContentEncodingParameter;
      ...BlobContentLanguageParameter;
      ...LeaseIdOptionalParameter;
      ...BlobContentDispositionParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
    },
    {
      ...EtagResponseHeaderPrivate;
      ...LastModifiedResponseHeaderPrivate;
      ...BlobSequenceNumberResponseHeaderPrivate;
    }
  >;

  /** Set the immutability policy on the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?comp=immutabilityPolicies")
  setImmutabilityPolicy is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...IfUnmodifiedSinceParameter;
      ...ImmutabilityPolicyExpiryRequiredParameter;
      ...ImmutabilityPolicyModeParameter;
      ...SnapshotParameter;
      ...VersionIdParameter;
    },
    {
      ...ImmutabilityPolicyExpiresOnResponseHeaderPrivate;
      ...ImmutabilityPolicyModeResponseHeaderPrivate;
    }
  >;

  /** Deletes the immutability policy on the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @delete
  @route("?comp=immutabilityPolicies")
  deleteImmutabilityPolicy is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...SnapshotParameter;
      ...VersionIdParameter;
    },
    {}
  >;

  /** Sets a legal hold on the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?comp=legalhold")
  setLegalHold is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LegalHoldRequiredParameter;
      ...SnapshotParameter;
      ...VersionIdParameter;
    },
    {
      ...LegalHoldResponseHeaderPrivate;
    }
  >;

  /** Sets user-defined metadata for the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @route("?comp=metadata")
  setMetadata is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...MetadataHeaders;
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

  /** Requests a new lease on the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease")
  acquireLease is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseDurationHeaderParameter;
      ...ProposedLeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...LeaseActionParameter<"acquire">;
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...LeaseIdResponseHeader;
    }
  >;

  /** Frees the lease if it's no longer needed, so that another client can immediately acquire a lease against the blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease")
  releaseLease is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdRequiredParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...LeaseActionParameter<"release">;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
    }
  >;

  /** Renews an existing lease. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease")
  renewLease is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdRequiredParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...LeaseActionParameter<"renew">;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...LeaseIdResponseHeader;
    }
  >;

  /** Change the ID of an existing lease. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease")
  changeLease is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdRequiredParameter;
      ...ProposedLeaseIdRequiredParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...LeaseActionParameter<"change">;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...LeaseIdResponseHeader;
    }
  >;

  /** Ends a lease and ensures that another client can't acquire a new lease until the current lease period has expired. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  @route("?comp=lease")
  breakLease is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseBreakPeriodParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...LeaseActionParameter<"break">;
    },
    {
      @statusCode statusCode: 202;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...LeaseTimeResponseHeader;
    }
  >;

  /** Creates a read-only snapshot of the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  @route("?comp=snapshot")
  createSnapshot is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...MetadataHeaders;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...LeaseIdOptionalParameter;
    },
    {
      @statusCode statusCode: 201;

      /** Uniquely identifies the snapshot and indicates the snapshot version. */
      @header("x-ms-snapshot")
      snapshot?: string;

      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...VersionIdResponseHeader;
      ...RequestServerEncryptedResponseHeader;
    }
  >;

  /** Starts an asynchronous copy from a source URL to a destination blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  startCopyFromUrl is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...MetadataHeaders;
      ...AccessTierHeader;
      ...RehydratePriorityParameter;
      ...SourceIfModifiedSinceParameter;
      ...SourceIfUnmodifiedSinceParameter;
      ...SourceIfMatchParameter;
      ...SourceIfNoneMatchParameter;
      ...SourceIfTagsParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...CopySourceParameter;
      ...LeaseIdOptionalParameter;
      ...BlobTagsHeaderParameter;

      /** Overrides the sealed state of the destination blob. */
      @header("x-ms-seal-blob")
      sealBlob?: boolean;

      ...ImmutabilityPolicyExpiryParameter;
      ...ImmutabilityPolicyModeParameter;
      ...LegalHoldOptionalParameter;
    },
    {
      @statusCode statusCode: 202;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...VersionIdResponseHeader;
      ...CopyIdResponseHeader;
      ...CopyStatusResponseHeader;
    }
  >;

  /** Synchronously copies a blob from a source URL to the destination blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  copyFromUrl is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...MetadataHeaders;
      ...AccessTierHeader;
      ...SourceIfModifiedSinceParameter;
      ...SourceIfUnmodifiedSinceParameter;
      ...SourceIfMatchParameter;
      ...SourceIfNoneMatchParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...CopySourceParameter;
      ...LeaseIdOptionalParameter;
      ...SourceContentMd5Parameter;
      ...BlobTagsHeaderParameter;
      ...ImmutabilityPolicyExpiryParameter;
      ...ImmutabilityPolicyModeParameter;
      ...LegalHoldOptionalParameter;
      ...CopySourceAuthorizationParameter;
      ...EncryptionScopeParameter;
      ...CopySourceTagsParameter;
      ...FileRequestIntentParameter;

      /** Indicates this is a synchronous copy. */
      @header("x-ms-requires-sync")
      requiresSync: "true";
    },
    {
      @statusCode statusCode: 202;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...VersionIdResponseHeader;
      ...CopyIdResponseHeader;

      /** State of the copy operation. */
      @header("x-ms-copy-status")
      copyStatus?: "success";

      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...EncryptionScopeResponseHeader;
    }
  >;

  /** Aborts a pending asynchronous copy operation and leaves a destination blob with zero length and full metadata. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @put
  @sharedRoute
  @route("?comp=copy")
  abortCopyFromUrl is StorageOperationNoBody<
    {
      ...TimeoutParameter;

      /** The ID of the copy to be aborted. */
      @clientName("copyId")
      @query
      copyid: string;

      ...LeaseIdOptionalParameter;

      /** The copy action to be performed. */
      @header("x-ms-copy-action")
      copyActionAbortConstant: "abort";
    },
    {
      @statusCode statusCode: 204;
    }
  >;

  /** Sets the tier of the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=tier")
  setTier is StorageOperationNoBody<
    {
      ...SnapshotParameter;
      ...VersionIdParameter;
      ...TimeoutParameter;

      /** Indicates the tier to be set on the blob. */
      @header("x-ms-access-tier")
      tier: AccessTier;

      ...RehydratePriorityParameter;
      ...LeaseIdOptionalParameter;
      ...IfTagsParameter;
    },
    {
      #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Following standard pattern"
      @statusCode statusCode: 200 | 202;
    }
  >;

  /** Returns information about the storage account. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @get
  @sharedRoute
  @route("?restype=account&comp=properties")
  getAccountInfo is StorageOperationNoBody<
    {
      ...TimeoutParameter;
    },
    {
      ...AccountKindResponseHeader;
      ...SkuNameResponseHeader;
      ...IsHierarchicalNamespaceEnabled;
    }
  >;

  /** Gets the tags of the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @get
  @sharedRoute
  @route("?comp=tags")
  getTags is StorageOperationResponseBody<
    {
      ...TimeoutParameter;
      ...SnapshotParameter;
      ...VersionIdParameter;
      ...LeaseIdOptionalParameter;
      ...IfTagsParameter;
      ...IfBlobModifiedSinceHeader;
      ...IfBlobUnmodifiedSinceHeader;
      ...IfBlobMatchHeader;
      ...IfBlobNoneMatchHeader;
    },
    {
      /** The blob tags. */
      @body
      tags: BlobTags;
    }
  >;

  /** Sets the tags of the specified blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @put
  @route("?comp=tags")
  setTags is StorageOperationRequestBody<
    {
      ...TimeoutParameter;
      ...VersionIdParameter;
      ...ContentMd5Parameter;
      ...ContentCrc64Parameter;
      ...IfTagsParameter;
      ...LeaseIdOptionalParameter;

      /** The blob tags. */
      @body
      tags: BlobTags;

      ...IfBlobModifiedSinceHeader;
      ...IfBlobUnmodifiedSinceHeader;
      ...IfBlobMatchHeader;
      ...IfBlobNoneMatchHeader;
    },
    {
      @statusCode statusCode: 204;
    }
  >;
}

#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
interface PageBlob {
  /** Creates a new page blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  create is StorageOperationNoBody<
    {
      ...MetadataHeaders;
      ...TimeoutParameter;

      /** Indicates the tier to be set on the page blob. */
      @header("x-ms-access-tier")
      tier?: PremiumPageBlobAccessTier;

      ...BlobContentTypeParameter;
      ...BlobContentEncodingParameter;
      ...BlobContentLanguageParameter;
      ...BlobContentMd5Parameter;
      ...BlobCacheControlParameter;
      ...LeaseIdOptionalParameter;
      ...BlobContentDispositionParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...BlobContentLengthRequired;
      ...SequenceNumberParameter;
      ...BlobTagsHeaderParameter;
      ...ImmutabilityPolicyExpiryParameter;
      ...ImmutabilityPolicyModeParameter;
      ...LegalHoldOptionalParameter;

      /** the initial size of the page blob. */
      @header("Content-Length")
      contentLength: 0;

      /** The type of the blob. */
      @header("x-ms-blob-type")
      blobType: "PageBlob";
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...ContentMd5ResponseHeader;
      ...VersionIdResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
    }
  >;

  /** Writes a range of pages to the specified page blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
  @put
  @sharedRoute
  @route("?comp=page")
  uploadPages is StorageOperationRequestBody<
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
      ...StructuredBodyParameter;
      ...StructuredContentLengthParameter;
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
      ...StructuredBodyTypeResponseHeader;
    },
    "application/octet-stream"
  >;

  /** Clears a range of pages from the specified page blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=page")
  clearPages is StorageOperationNoBody<
    {
      /** Value must be 0 when x-ms-page-write is clear. */
      @header("Content-Length")
      contentLength: 0;

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
      ...PageWriteParameter<"clear">;
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...BlobSequenceNumberResponseHeader;
    }
  >;

  /** Writes a range of pages to the specified page blob where the contents are read from a URL. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  @route("?comp=page")
  uploadPagesFromUrl is StorageOperationNoBody<
    {
      ...SourceUrlParameter;
      ...SourceRangeParameterRequired;
      ...SourceContentMd5Parameter;
      ...SourceContentCrc64Parameter;
      ...ContentLengthParameter;
      ...TimeoutParameter;
      ...RangeParameterRequired;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...LeaseIdOptionalParameter;
      ...IfSequenceNumberLessThanOrEqualToParameter;
      ...IfSequenceNumberLessThanParameter;
      ...IfSequenceNumberEqualToParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...SourceIfModifiedSinceParameter;
      ...SourceIfUnmodifiedSinceParameter;
      ...SourceIfMatchParameter;
      ...SourceIfNoneMatchParameter;
      ...CopySourceAuthorizationParameter;
      ...FileRequestIntentParameter;
      ...PageWriteParameter<"update">;
      ...SourceEncryptionKeyParameter;
      ...SourceEncryptionKeySha256Parameter;
      ...SourceEncryptionAlgorithmParameter;
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
    }
  >;

  /** Returns the list of valid page ranges for the specified page blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @get
  @list
  @sharedRoute
  @route("?comp=pagelist")
  getPageRanges is StorageOperationResponseBody<
    {
      ...SnapshotParameter;
      ...TimeoutParameter;
      ...RangeParameter;
      ...LeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
    },
    PageList & {
      ...LastModifiedResponseHeader;
      ...EtagResponseHeader;
      ...BlobContentLengthResponseHeader;
    }
  >;

  /** Returns the list of page ranges in the diff between the specified page blob and the specified previous snapshot. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @get
  @sharedRoute
  @route("?comp=pagelist")
  getPageRangesDiff is StorageOperationResponseBody<
    {
      ...SnapshotParameter;
      ...TimeoutParameter;

      /** Specifies the previous snapshot to be compared in the diff. */
      @query
      prevsnapshot?: string;

      /** Specifies the previous snapshot URL to be compared in the diff. */
      #suppress "@azure-tools/typespec-client-generator-core/csharp-no-url-suffix" "Name kept for backward compatibility"
      @header("x-ms-previous-snapshot-url")
      prevSnapshotUrl?: string;

      ...RangeParameter;
      ...LeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...MarkerParameter;
      ...MaxResultsParameter;
    },
    PageList & {
      ...LastModifiedResponseHeader;
      ...EtagResponseHeader;
      ...BlobContentLengthResponseHeader;
    }
  >;

  /** Changes the size of the specified page blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=properties")
  resize is StorageOperationNoBody<
    {
      ...TimeoutParameter;
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
      ...BlobContentLengthRequired;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...BlobSequenceNumberResponseHeader;
    }
  >;

  /** Updates the sequence number of the specified page blob. The operation will fail if the specified sequence number is less than the current sequence number of the blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=properties")
  setSequenceNumber is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...SequenceNumberActionParameter;
      ...SequenceNumberParameter;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...BlobSequenceNumberResponseHeader;
    }
  >;

  /** Copies a snapshot of the source page blob to a destination page blob. The snapshot is copied such that only the differential changes between the previously copied snapshot are transferred to the destination. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  @route("?comp=incrementalcopy")
  copyIncremental is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...CopySourceParameter;
    },
    {
      @statusCode statusCode: 202;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...CopyIdResponseHeader;
      ...CopyStatusResponseHeader;
    }
  >;
}

#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
interface AppendBlob {
  /** Creates a new append blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  @put
  @sharedRoute
  create is StorageOperationNoBody<
    {
      ...MetadataHeaders;
      ...TimeoutParameter;
      ...BlobContentTypeParameter;
      ...BlobContentEncodingParameter;
      ...BlobContentLanguageParameter;
      ...BlobContentMd5Parameter;
      ...BlobCacheControlParameter;
      ...LeaseIdOptionalParameter;
      ...BlobContentDispositionParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...BlobTagsHeaderParameter;
      ...ImmutabilityPolicyExpiryParameter;
      ...ImmutabilityPolicyModeParameter;
      ...LegalHoldOptionalParameter;

      /** The initial size of the append blob. */
      @header("Content-Length")
      contentLength: 0;

      /** The type of the blob. */
      @header("x-ms-blob-type")
      blobType: "AppendBlob";
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...ContentMd5ResponseHeader;
      ...VersionIdResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
    }
  >;

  /** Uploads a new block of data to the end of an append blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
  @put
  @sharedRoute
  @route("?comp=appendblock")
  appendBlock is StorageOperationRequestBody<
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
      ...StructuredBodyParameter;
      ...StructuredContentLengthParameter;
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
      ...StructuredBodyTypeResponseHeader;
    },
    "application/octet-stream"
  >;

  /** Uploads a new block of data from the specified URL to the end of an append blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=appendblock")
  appendBlockFromUrl is StorageOperationNoBody<
    {
      ...SourceUrlParameter;
      ...SourceRangeParameter;
      ...SourceContentMd5Parameter;
      ...SourceContentCrc64Parameter;
      ...TimeoutParameter;
      ...ContentLengthParameter;
      ...ContentMd5Parameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...LeaseIdOptionalParameter;
      ...BlobConditionMaxSizeParameter;
      ...BlobConditionAppendPosParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...SourceIfModifiedSinceParameter;
      ...SourceIfUnmodifiedSinceParameter;
      ...SourceIfMatchParameter;
      ...SourceIfNoneMatchParameter;
      ...CopySourceAuthorizationParameter;
      ...FileRequestIntentParameter;
      ...SourceEncryptionKeyParameter;
      ...SourceEncryptionKeySha256Parameter;
      ...SourceEncryptionAlgorithmParameter;
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
    }
  >;

  /** Seals the append blob to make it read-only. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=seal")
  seal is StorageOperationNoBody<
    {
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...BlobConditionAppendPosParameter;
    },
    {
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...IsSealedResponseHeader;
    }
  >;
}

#suppress "@azure-tools/typespec-azure-core/operation-missing-api-version" "Existing API. Storage API version parameter pre-dates current guidance."
interface BlockBlob {
  /** Uploads the content to the specified block blob. If the blob already exists, the data and any existing metadata will be overwritten. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
  @put
  @sharedRoute
  upload is StorageOperationRequestBody<
    {
      ...MetadataHeaders;
      ...BodyParameter;
      ...TimeoutParameter;
      ...ContentMd5Parameter;
      ...ContentLengthParameter;
      ...BlobContentTypeParameter;
      ...BlobContentEncodingParameter;
      ...BlobContentLanguageParameter;
      ...BlobContentMd5Parameter;
      ...BlobCacheControlParameter;
      ...LeaseIdOptionalParameter;
      ...BlobContentDispositionParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...AccessTierHeader;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...BlobTagsHeaderParameter;
      ...ImmutabilityPolicyExpiryParameter;
      ...ImmutabilityPolicyModeParameter;
      ...LegalHoldOptionalParameter;
      ...ContentCrc64Parameter;
      ...StructuredBodyParameter;
      ...StructuredContentLengthParameter;

      /** The type of the blob. */
      @header("x-ms-blob-type")
      blobType: "BlockBlob";
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...VersionIdResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
      ...StructuredBodyTypeResponseHeader;
    },
    "application/octet-stream"
  >;

  /** Uploads the content from the specified URL to the block blob. If the blob already exists, the data and any existing metadata will be overwritten. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  uploadBlobFromUrl is StorageOperationNoBody<
    {
      ...MetadataHeaders;
      ...TimeoutParameter;
      ...ContentMd5Parameter;
      ...BlobContentTypeParameter;
      ...BlobContentEncodingParameter;
      ...BlobContentLanguageParameter;
      ...BlobContentMd5Parameter;
      ...BlobCacheControlParameter;
      ...LeaseIdOptionalParameter;
      ...BlobContentDispositionParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...AccessTierHeader;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
      ...SourceIfModifiedSinceParameter;
      ...SourceIfUnmodifiedSinceParameter;
      ...SourceIfMatchParameter;
      ...SourceIfNoneMatchParameter;
      ...SourceIfTagsParameter;
      ...SourceContentMd5Parameter;
      ...BlobTagsHeaderParameter;
      ...CopySourceParameter;

      /** Required to be 0 for Put Blob from URL operation. */
      @header("Content-Length")
      contentLength: 0;

      ...CopySourceBlobPropertiesParameter;
      ...CopySourceAuthorizationParameter;
      ...CopySourceTagsParameter;

      /** The type of the blob. */
      @header("x-ms-blob-type")
      blobType: "BlockBlob";

      ...FileRequestIntentParameter;
      ...SourceEncryptionKeyParameter;
      ...SourceEncryptionKeySha256Parameter;
      ...SourceEncryptionAlgorithmParameter;
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeaderV2026_10_06;
      ...VersionIdResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
    }
  >;

  /** Creates a new block of data to be committed as part of a blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
  @put
  @sharedRoute
  @route("?comp=block")
  stageBlock is StorageOperationRequestBody<
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
      ...StructuredBodyParameter;
      ...StructuredContentLengthParameter;
    },
    {
      @statusCode statusCode: 201;
      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
      ...StructuredBodyTypeResponseHeader;
    },
    "application/octet-stream"
  >;

  /** Creates a new block of data from the specified URL to be committed as part of a blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=block")
  stageBlockFromUrl is StorageOperationNoBody<
    {
      ...BlockIdParameter;
      ...ContentLengthParameter;
      ...SourceUrlParameter;
      ...SourceRangeParameter;
      ...SourceContentMd5Parameter;
      ...SourceContentCrc64Parameter;
      ...TimeoutParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...LeaseIdOptionalParameter;
      ...SourceIfModifiedSinceParameter;
      ...SourceIfUnmodifiedSinceParameter;
      ...SourceIfMatchParameter;
      ...SourceIfNoneMatchParameter;
      ...CopySourceAuthorizationParameter;
      ...FileRequestIntentParameter;
      ...SourceEncryptionKeyParameter;
      ...SourceEncryptionKeySha256Parameter;
      ...SourceEncryptionAlgorithmParameter;
    },
    {
      @statusCode statusCode: 201;
      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
    }
  >;

  /** Writes to the block blob by specifying the list of block IDs that make up the blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/use-standard-names" "Existing API"
  @put
  @sharedRoute
  @route("?comp=blocklist")
  commitBlockList is StorageOperationRequestBody<
    {
      ...TimeoutParameter;
      ...BlobCacheControlParameter;
      ...BlobContentTypeParameter;
      ...BlobContentEncodingParameter;
      ...BlobContentLanguageParameter;
      ...BlobContentMd5Parameter;
      ...ContentMd5Parameter;
      ...ContentCrc64Parameter;
      ...MetadataHeaders;
      ...LeaseIdOptionalParameter;
      ...BlobContentDispositionParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...EncryptionScopeParameter;
      ...AccessTierHeader;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;

      /** Blob blocks. */
      @body blocks: BlockLookupList;

      ...BlobTagsHeaderParameter;
      ...ImmutabilityPolicyExpiryParameter;
      ...ImmutabilityPolicyModeParameter;
      ...LegalHoldOptionalParameter;
    },
    {
      @statusCode statusCode: 201;
      ...EtagResponseHeader;
      ...LastModifiedResponseHeader;
      ...ContentMd5ResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...VersionIdResponseHeader;
      ...RequestServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
    }
  >;

  /** Retrieves the list of blocks that have been uploaded as part of the block blob. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  @get
  @route("?comp=blocklist")
  getBlockList is StorageOperationResponseBody<
    {
      ...SnapshotParameter;

      /** Specifies whether to return the list of committed blocks, the list of uncommitted blocks, or both lists together. */
      @query
      @clientName("listType")
      blocklisttype: BlockListType;

      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...IfTagsParameter;
    },
    {
      /** The list of blocks. */
      @body
      blockList: BlockList;

      ...LastModifiedResponseHeader;
      ...EtagResponseHeader;
      ...BlobContentLengthResponseHeader;
    }
  >;

  /** Queries the data of the specified blob with the provided query expressions. */
  #suppress "@azure-tools/typespec-azure-core/use-standard-operations" "Existing API"
  #suppress "@azure-tools/typespec-azure-core/byos" "Existing API"
  @post
  @route("?comp=query")
  query is StorageOperation<
    {
      /** The query request. */
      @body
      queryRequest: QueryRequest;

      ...SnapshotParameter;
      ...TimeoutParameter;
      ...LeaseIdOptionalParameter;
      ...EncryptionKeyParameter;
      ...EncryptionKeySha256Parameter;
      ...EncryptionAlgorithmParameter;
      ...IfModifiedSinceParameter;
      ...IfUnmodifiedSinceParameter;
      ...IfNoneMatchParameter;
      ...IfMatchParameter;
      ...IfTagsParameter;
    },
    BodyParameter & {
      #suppress "@azure-tools/typespec-azure-core/no-closed-literal-union" "Following standard pattern"
      @statusCode statusCode: 200 | 206;
      ...MetadataHeaders;
      ...LastModifiedResponseHeader;
      ...ContentLengthResponseHeader;
      ...ContentRangeResponseHeader;
      ...EtagResponseHeader;
      ...ContentMd5ResponseHeader;
      ...ContentEncodingResponseParameter;
      ...CacheControlResponseHeader;
      ...ContentDispositionResponseHeader;
      ...ContentLanguageResponseHeader;
      ...BlobSequenceNumberResponseHeader;
      ...BlobTypeResponseHeader;
      ...ContentCrc64ResponseHeader;
      ...CopyCompletionTimeResponseHeader;
      ...CopyStatusDescriptionResponseHeader;
      ...CopyIdResponseHeader;
      ...CopyProgressResponseHeader;
      ...CopySourceResponseHeader;
      ...CopyStatusResponseHeader;
      ...LeaseDurationResponseHeader;
      ...LeaseStateResponseHeader;
      ...LeaseStatusResponseHeader;
      ...AcceptRangesResponseHeader;
      ...BlobCommittedBlockCountResponseHeader;
      ...ServerEncryptedResponseHeader;
      ...EncryptionKeySha256ResponseHeader;
      ...EncryptionScopeResponseHeader;
      ...BlobContentMd5ResponseHeader;
    },
    "application/xml",
    "application/octet-stream"
  >;
}
