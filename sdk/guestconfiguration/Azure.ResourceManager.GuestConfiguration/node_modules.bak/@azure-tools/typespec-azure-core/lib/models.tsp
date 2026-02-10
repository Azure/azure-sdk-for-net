import "@typespec/http";
import "@typespec/rest";
import "./traits.tsp";

using Http;
using Rest;

namespace Azure.Core;

/**
 * Describes a page of resource object.
 * @template Resource The resource type.
 */
@friendlyName("Paged{name}", Resource)
@doc("Paged collection of {name} items", Resource)
model Page<Resource extends TypeSpec.Reflection.Model> {
  @doc("The {name} items on this page", Resource)
  @pageItems
  value: Resource[];

  @doc("The link to the next page of items")
  @nextLink
  nextLink?: ResourceLocation<Resource>;
}

/**
 * Defines a property as a request parameter.
 * @template Name The parameter name.
 */
@Foundations.requestParameter(Name)
model RequestParameter<Name extends valueof string> {}

/**
 * Defines a property as a response header.
 * @template Name The header name.
 */
@Foundations.responseProperty(Name)
model ResponseProperty<Name extends valueof string> {}

/**
 * @dev Provides the status of a resource operation.
 * @template Resource The resource type.
 * @template StatusResult Model describing the status result object. If not specified, the default is the resource type.
 * @template StatusError Model describing the status error object. If not specified, the default is the Foundations.Error.
 */
@resource("operations")
@parentResource(Resource)
model ResourceOperationStatus<
  Resource extends TypeSpec.Reflection.Model,
  StatusResult = Resource,
  StatusError = Foundations.Error
> is Azure.Core.Foundations.OperationStatus<StatusResult, StatusError>;

#suppress "@azure-tools/typespec-providerhub/no-inline-model" "This is acceptable in Azure.Core."
alias ResourceOperationStatusResponse<
  Resource extends TypeSpec.Reflection.Model,
  StatusResult,
  StatusError
> = ResourceOperationStatus<Resource, StatusResult, StatusError>;

@doc("Provides the standard 'top' query parameter for list operations.")
model TopQueryParameter {
  @query
  @doc("The number of result items to return.")
  top?: int32;
}

@doc("Provides the standard 'skip' query parameter for list operations.")
model SkipQueryParameter {
  @query
  @offset
  @doc("The number of result items to skip.")
  skip?: int32 = 0;
}

@doc("Provides the standard 'maxpagesize' query parameter for list operations.")
model MaxPageSizeQueryParameter {
  @query
  @pageSize
  @doc("The maximum number of result items per page.")
  maxpagesize?: int32;
}

@doc("Provides the standard 'filter' query parameter for list operations")
model FilterParameter {
  @query
  @doc("The maximum number of result items per page.")
  filter?: string;
}

@doc("Provides the standard 'orderby' query parameter for list operations.")
model OrderByQueryParameter {
  @query(#{ explode: true })
  @doc("Expressions that specify the order of returned results.")
  orderby?: string[];
}

@doc("Provides the standard 'filter' query parameter for list operations.")
model FilterQueryParameter {
  @query
  @doc("Filter the result list using the given expression.")
  filter?: string;
}

@doc("Provides the standard 'select' query parameter for list operations.")
model SelectQueryParameter {
  @query(#{ explode: true })
  @doc("Select the specified fields to be included in the response.")
  select?: string[];
}

@doc("Provides the standard 'expand' query parameter for list operations.")
model ExpandQueryParameter {
  @query(#{ explode: true })
  @doc("Expand the indicated resources into the response.")
  expand?: string[];
}

@doc("Provides the most common query parameters for list operations.")
model StandardListQueryParameters {
  ...TopQueryParameter;
  ...SkipQueryParameter;
  ...MaxPageSizeQueryParameter;
}

// https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#conditional-requests

@doc("Provides the 'If-*' headers to enable conditional (cached) responses")
model ConditionalRequestHeaders {
  @visibility(Lifecycle.Read, Lifecycle.Query, Lifecycle.Create, Lifecycle.Update, Lifecycle.Delete)
  @header("If-Match")
  @doc("The request should only proceed if an entity matches this string.")
  ifMatch?: string;

  @visibility(Lifecycle.Read, Lifecycle.Query, Lifecycle.Create, Lifecycle.Update, Lifecycle.Delete)
  @header("If-None-Match")
  @doc("The request should only proceed if no entity matches this string.")
  ifNoneMatch?: string;

  @visibility(Lifecycle.Read, Lifecycle.Query, Lifecycle.Create, Lifecycle.Update, Lifecycle.Delete)
  @header("If-Unmodified-Since")
  @doc("The request should only proceed if the entity was not modified after this time.")
  ifUnmodifiedSince?: utcDateTime;

  @visibility(Lifecycle.Read, Lifecycle.Query, Lifecycle.Create, Lifecycle.Update, Lifecycle.Delete)
  @header("If-Modified-Since")
  @doc("The request should only proceed if the entity was modified after this time.")
  ifModifiedSince?: utcDateTime;
}

@doc("""
  Provides the 'ETag' field to enable conditional (cached) requests.  This model can be spread
  into responses and item models to convey the ETag when it cannot simply conveyed in a header.
  """)
model EtagProperty {
  @visibility(Lifecycle.Read)
  @doc("The entity tag for this resource.")
  etag: eTag;
}

@doc("Provides the 'ETag' header to enable conditional (cached) requests")
model EtagResponseEnvelope {
  @header("ETag")
  @visibility(Lifecycle.Read)
  @doc("The entity tag for the response.")
  etagHeader?: string;
}

// https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#repeatability-of-requests

@doc("Provides the 'Repeatability-*' headers to enable repeatable requests.")
model RepeatabilityRequestHeaders {
  @visibility(Lifecycle.Create, Lifecycle.Update, Lifecycle.Delete)
  @header("Repeatability-Request-ID")
  @doc("An opaque, globally-unique, client-generated string identifier for the request.")
  repeatabilityRequestId?: string;

  @visibility(Lifecycle.Create, Lifecycle.Update, Lifecycle.Delete)
  @doc("Specifies the date and time at which the request was first created.")
  @header("Repeatability-First-Sent")
  repeatabilityFirstSent?: utcDateTime;
}

@doc("Provides the 'Repeatability-*' headers to enable repeatable requests.")
model RepeatabilityResponseHeaders {
  @visibility(Lifecycle.Read)
  @header("Repeatability-Result")
  @doc("Indicates whether the repeatable request was accepted or rejected.")
  repeatabilityResult?: RepeatabilityResult;
}

/** Repeatability Result header options */
union RepeatabilityResult {
  /** If the request was accepted and the server guarantees that the server state reflects a single execution of the operation. */
  "accepted",

  /**
   * If the request was rejected because the combination of Repeatability-First-Sent and Repeatability-Request-ID were invalid
   *  or because the Repeatability-First-Sent value was outside the range of values held by the server.
   */
  "rejected",
}

// https://github.com/microsoft/api-guidelines/blob/vNext/azure/Guidelines.md#distributed-tracing--telemetry

@doc("Provides the 'x-ms-client-request-id' header to enable request correlation in requests and responses.")
model ClientRequestIdHeader {
  @header("x-ms-client-request-id")
  @doc("An opaque, globally-unique, client-generated string identifier for the request.")
  clientRequestId?: uuid;
}

@doc("Provides the 'x-ms-request-id' header to enable request correlation in responses.")
model RequestIdResponseHeader {
  @visibility(Lifecycle.Read)
  @header("x-ms-request-id")
  @doc("An opaque, globally-unique, server-generated string identifier for the request.")
  requestId?: uuid;
}

/**
 * A vector embedding frequently used in similarity search.
 * @template Element The element type of the embedding vector.
 */
@Foundations.Private.embeddingVector(Element)
model EmbeddingVector<Element extends numeric = float32> is Array<Element>;

/**
 * Options for overriding a polling endpoint that uses a StatusMonitor
 * @template PollingModel The model that is returned when polling should continue.
 * @template FinalResult The model that is returned when polling terminates successfully.
 * @template FinalProperty The property of the status monitor that contains results.
 */
model StatusMonitorPollingOptions<
  PollingModel extends TypeSpec.Reflection.Model | void = never,
  FinalResult extends TypeSpec.Reflection.Model | unknown | void = never,
  FinalProperty extends TypeSpec.Reflection.ModelProperty | string = never
> extends StatusMonitorOptions {
  /** The kind of polling options */
  kind: PollingOptionKind.statusMonitor;

  /** The model that is returned when polling should continue */
  pollingModel: PollingModel;

  /** The model that is returned when polling terminates successfully */
  finalResult: FinalResult;

  /** The property of the status monitor that contains results */
  finalProperty: FinalProperty;
}

/** Options for Lro status monitors. */
model StatusMonitorOptions extends PollingOptions {
  /** The kind of polling options */
  kind: PollingOptionKind.statusMonitor;

  /** A reference to or name of the property of the status monitor that contains the response */
  finalProperty?: TypeSpec.Reflection.ModelProperty | string;
}

/** Generic polling options for LRO operations. */
model PollingOptions {
  /** The kind of polling options */
  kind: PollingOptionKind;

  /** The model that is returned when polling should continue. */
  pollingModel?: TypeSpec.Reflection.Model | void;

  /** The type that is returned when polling terminates successfully. */
  finalResult?: TypeSpec.Reflection.Model | unknown | void;
}

/** The available kinds of polling options */
union PollingOptionKind {
  /** Polling options for a status monitor */
  statusMonitor: "statusMonitor",

  string,
}

/**
 * Universally Unique Identifier
 *
 * @example
 *
 * ```
 * 123e4567-e89b-12d3-a456-426614174000
 * ```
 */
@format("uuid")
scalar uuid extends string;

/**
 * Represent an IP V4 address serialized as a string.
 *
 * It is formatted as four 8-bit fields separated by periods.
 *
 * @example
 *
 * ```
 * 129.144.50.56
 * ```
 */
#suppress "@azure-tools/typespec-autorest/unknown-format" "Foundation."
@format("ipV4Address")
scalar ipV4Address extends string;

/**
 * Represent an IP V6 address serialized as a string.
 *
 * It is formatted as eight hex decimal values(16-bit) between 0 and FFFF separated by colon. (i.e. `y:y:y:y:y:y:y:y`)
 *
 * @example
 *
 * ```
 * 2001:db8:3333:4444:CCCC:DDDD:EEEE:FFFF
 * ```
 */
#suppress "@azure-tools/typespec-autorest/unknown-format" "Foundation."
@format("ipV6Address")
scalar ipV6Address extends string;

/**
 * The ETag (or entity tag) HTTP response header is an identifier for a specific version of a resource.
 * It lets caches be more efficient and save bandwidth, as a web server does not need to resend a full response if the content was not changed.
 *
 * It is a string of ASCII characters placed between double quotes, like "675af34563dc-tr34".
 *
 * @example In `ETag` header
 *
 * ```
 * ETag: "675af34563dc-tr34"
 * ```
 */
#suppress "@azure-tools/typespec-autorest/unknown-format" "Foundation."
@format("eTag")
scalar eTag extends string;

/**
 * Represents an Azure geography region where supported resource providers live.
 *
 * @example
 *
 * ```
 * WestUS
 * ```
 */
scalar azureLocation extends string;

/**
 * Represents an Azure Resource Type.
 *
 * @example
 *
 * ```
 * Microsoft.Network/virtualNetworks/subnets
 * ```
 */
scalar armResourceType extends string;

/**
 * A type definition that refers the id to an Azure Resource Manager resource.
 *
 * @template AllowedResourceTypes An array of allowed resource types for the resource reference
 *
 * @example
 *
 * ```tsp
 * model MyModel {
 *   otherArmId: armResourceIdentifier;
 *   networkId: armResourceIdentifier<[{type:"Microsoft.Network/vnet"}]>
 *   vmIds: armResourceIdentifier<[{type:"Microsoft.Compute/vm", scopes: ["*"]}]>
 *   scoped: armResourceIdentifier<[{type:"Microsoft.Compute/vm", scopes: ["Tenant", "ResourceGroup"]}]>
 * }
 * ```
 */
@doc("A type definition that refers the id to an Azure Resource Manager resource.")
@format("arm-id")
@Azure.Core.Foundations.Private.armResourceIdentifierConfig({
  allowedResources: AllowedResourceTypes,
})
scalar armResourceIdentifier<AllowedResourceTypes extends ArmResourceIdentifierAllowedResource[] = never>
  extends string;

// Consider replacing `*`
union ArmResourceDeploymentScope {
  "Tenant",
  "Subscription",
  "ResourceGroup",
  "ManagementGroup",
  "Extension",
}

alias AllArmResourceDeploymentScopes = [
  "Tenant",
  "Subscription",
  "ResourceGroup",
  "ManagementGroup",
  "Extension"
];

model ArmResourceIdentifierAllowedResource {
  /** The type of resource that is being referred to. For example Microsoft.Network/virtualNetworks or Microsoft.Network/virtualNetworks/subnets. See Example Types for more examples. */
  type: armResourceType;

  /**
   * An array of scopes. If not specified, the default scope is ["ResourceGroup"].
   * See [Allowed Scopes](https://github.com/Azure/autorest/tree/main/docs/extensions#allowed-scopes).
   */
  scopes?: ArmResourceDeploymentScope[];
}
