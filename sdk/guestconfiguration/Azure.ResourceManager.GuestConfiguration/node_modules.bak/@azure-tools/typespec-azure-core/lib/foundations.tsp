import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "./traits.tsp";

using Http;
using Rest;
using Versioning;
using Azure.Core.Traits;
using Azure.Core.Traits.Private;

namespace Azure.Core.Foundations;

/**
 * Enum describing allowed operation states.
 */
@lroStatus
union OperationState {
  @doc("The operation has not started.")
  NotStarted: "NotStarted",

  @doc("The operation is in progress.")
  Running: "Running",

  @doc("The operation has completed successfully.")
  Succeeded: "Succeeded",

  @doc("The operation has failed.")
  Failed: "Failed",

  @doc("The operation has been canceled by the user.")
  Canceled: "Canceled",

  string,
}

/**
 * Provides status details for long running operations.
 * @template StatusResult The type of the operation status result.
 * @template StatusError The type of the operation status error. If not provided, the default error is used.
 */
@doc("Provides status details for long running operations.")
model OperationStatus<StatusResult = never, StatusError = Foundations.Error> {
  @key("operationId")
  @doc("The unique ID of the operation.")
  id: string;

  @doc("The status of the operation")
  status: OperationState;

  @doc("Error object that describes the error when status is \"Failed\".")
  error?: StatusError;

  @doc("The result of the operation.")
  result?: StatusResult;
}

/**
 * Conveys the resource instance to an operation as a request body.
 * @template Resource The type of the resource instance.
 */
@doc("Conveys the resource instance to an operation as a request body.")
model ResourceBody<Resource> {
  @doc("The resource instance.")
  @body
  resource: Resource;
}

// TODO: There is a ARM linter rule that verifies that
// there is no response body. However, long running
// operations are allowed to have it.
alias ResourceCreatedResponse<Resource extends TypeSpec.Reflection.Model> = TypeSpec.Http.Response<201> &
  Resource;

alias ResourceOkResponse<Resource> = TypeSpec.Http.Response<200> & Resource;

alias ResourceCreatedOrOkResponse<Resource extends TypeSpec.Reflection.Model> = ResourceCreatedResponse<Resource> | ResourceOkResponse<Resource>;

/**
 * Response describing the location of a created resource.
 * @template T The type of the created resource.
 */
model LocationOfCreatedResourceResponse<Resource extends TypeSpec.Reflection.Model>
  is TypeSpec.Http.CreatedResponse {
  @finalLocation
  @TypeSpec.Http.header("Location")
  location: ResourceLocation<Resource>;
}

/**
 * Response describing the location of a resource created with a service-provided name.
 * @template T The type of the created resource.
 */
model LocationOfCreatedResourceWithServiceProvidedNameResponse<Resource extends TypeSpec.Reflection.Model>
  is TypeSpec.Http.AcceptedResponse {
  @finalLocation
  @TypeSpec.Http.header("Location")
  location: ResourceLocation<Resource>;
}

/**
 * Metadata for long running operation status monitor locations.
 * @template StatusResult The type of the operation status result.
 */
@doc("Metadata for long running operation status monitor locations")
model LongRunningStatusLocation<StatusResult = never> {
  @pollingLocation
  @doc("The location for monitoring the operation state.")
  @TypeSpec.Http.header("Operation-Location")
  operationLocation: ResourceLocation<OperationStatus<StatusResult>>;
}

alias AcceptedResponse<Resource = {}> = TypeSpec.Http.AcceptedResponse & Resource;

/**
 * A response containing error details.
 * @template Error The type of the error object.
 */
@error
@doc("A response containing error details.")
model ErrorResponseBase<Error> {
  @doc("The error object.")
  error: Error;

  @header("x-ms-error-code")
  @doc("String error code indicating what went wrong.")
  errorCode?: string;
}

model ErrorResponse is ErrorResponseBase<Error>;

@doc("The ApiVersion query parameter.")
model ApiVersionParameter {
  @query("api-version")
  @minLength(1)
  @doc("The API version to use for this operation.")
  apiVersion: string;
}

@doc("The retry-after envelope.")
model RetryAfterHeader {
  @doc("The Retry-After header can indicate how long the client should wait before polling the operation status.")
  @header("Retry-After")
  retryAfter?: int32;
}

@doc("The error object.")
model Error {
  @doc("One of a server-defined set of error codes.")
  code: string;

  @doc("A human-readable representation of the error.")
  message: string;

  @doc("The target of the error.")
  target?: string;

  #suppress "@azure-tools/typespec-providerhub/no-identifier-property-in-array-item" "Error items have no unique identifier."
  @doc("An array of details about specific errors that led to this reported error.")
  details?: Error[];

  @doc("An object containing more specific information than the current object about the error.")
  innererror?: InnerError;
}

@doc("An object containing more specific information about the error. As per Azure REST API guidelines - https://aka.ms/AzureRestApiGuidelines#handling-errors.")
model InnerError {
  @doc("One of a server-defined set of error codes.")
  code?: string;

  @doc("Inner error.")
  innererror?: InnerError;
}

/**
 * Version of a model for a create or replace operation which only includes updateable properties.
 * @template Resource The type of the resource.
 */
@omitKeyProperties
model ResourceCreateOrReplaceModel<Resource extends TypeSpec.Reflection.Model>
  is UpdateableProperties<DefaultKeyVisibility<Resource, Lifecycle.Read>>;

/**
 * Collection of properties from a resource that are visible to create or update scopes.
 * @template Resource The type of the resource.
 */
@withVisibility(Lifecycle.Create, Lifecycle.Update)
model CreateableAndUpdateableProperties<Resource> {
  ...Resource;
}

/**
 * Version of a model for a create or update operation which only includes updateable properties.
 * @template Resource The type of the resource.
 */
@omitKeyProperties
model ResourceCreateOrUpdateModel<Resource>
  is OptionalProperties<CreateableAndUpdateableProperties<DefaultKeyVisibility<
    Resource,
    Lifecycle.Read
  >>>;

/**
 * Version of a model for an update operation which only includes updateable properties.
 * @template Resource The type of the resource.
 */
@omitKeyProperties
model ResourceUpdateModel<Resource>
  is OptionalProperties<UpdateableProperties<DefaultKeyVisibility<Resource, Lifecycle.Read>>>;

/**
 * A model containing the keys of the provided resource.
 * @template Resource The type of the resource.
 */
@copyResourceKeyParameters
model ItemKeysOf<Resource> {}

/**
 * A model containing the collection keys of the provided resource's parent resource.
 * @template Resource The type of the resource.
 */
@copyResourceKeyParameters("parent")
model CollectionKeysOf<Resource> {}

/**
 * A model describing a set of custom request parameters.
 * @template Custom An object describing custom request parameters.
 */
@Private.spreadCustomParameters(Custom)
model CustomParameters<Custom extends TypeSpec.Reflection.Model> {}

/**
 * A model describing a set of custom response properties.
 * @template Custom An object describing custom response properties.
 */
@Private.spreadCustomResponseProperties(Custom)
model CustomResponseFields<Custom extends TypeSpec.Reflection.Model> {}

/**
 * A model describing a customized page of resources.
 * @template Resource The type of the resource.
 * @template Traits Traits which apply to the page.
 */
@friendlyName("Paged{name}", Resource)
@doc("Paged collection of {name} items", Resource)
model CustomPage<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {}
> {
  @doc("The {name} items on this page", Resource)
  @pageItems
  value: Resource[];

  @doc("The link to the next page of items")
  @nextLink
  nextLink?: ResourceLocation<Resource>;

  // Include custom response fields
  ...TraitProperties<Traits, TraitLocation.Response, TraitContext.List>;
}

/**
 * The expected shape of model types passed to the Custom parameter of operation signatures.
 */
@doc("The expected shape of model types passed to the Custom parameter of operation signatures.")
model CustomizationFields {
  @doc("An object containing custom parameters that will be included in the operation.")
  parameters?: {};

  @doc("An object containing custom properties that will be included in the response.")
  response?: {};
}

// Basic Operation Shapes

/**
 * The most basic operation.
 * @template Parameters Object describing the request parameters of the operation.
 * @template Response Object describing the response properties of the operation.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
op Operation<
  Parameters extends TypeSpec.Reflection.Model,
  Response,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
>(
  ...TraitProperties<
    Traits & VersionParameterTrait<ApiVersionParameter>,
    TraitLocation.ApiVersionParameter
  >,
  ...Parameters,
): Response | ErrorResponse;

/**
 * Long-running operation.
 * @template Parameters Object describing the request parameters of the operation.
 * @template Response Object describing the response properties of the operation. If not provided, the AcceptedResponse type will be used.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
#suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
op LongRunningOperation<
  Parameters extends TypeSpec.Reflection.Model,
  Response = AcceptedResponse,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is Operation<Parameters, Response & Foundations.LongRunningStatusLocation, Traits, ErrorResponse>;

/**
 * Operation that returns the status of another operation.
 * @template Parameters Object describing the request parameters of the operation.
 * @template StatusResult The type of the operation status result.
 * @template StatusError The type of the operation status error.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
op GetOperationStatus<
  Parameters = {},
  StatusResult = never,
  StatusError = Error,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is Foundations.Operation<
  Parameters & {
    @doc("The unique ID of the operation.")
    @path
    operationId: string;
  },
  OperationStatus<StatusResult, StatusError>,
  Traits,
  ErrorResponse
>;

// Fundamental Resource Operation Shapes

/**
 * The most basic operation that applies to a resource.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters of the operation.
 * @template Response Object describing the response properties of the operation.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
#suppress "@azure-tools/typespec-azure-resource-manager/no-response-body" "This operation must return a status monitor in its response."
@autoRoute
@Private.ensureResourceType(Resource)
op ResourceOperation<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  Response,  // No constraint here on purpose, some responses are unions
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is Operation<Foundations.ItemKeysOf<Resource> & Parameters, Response, Traits, ErrorResponse>;

/**
 * Operation that applies to a collection of resources.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters of the operation.
 * @template Response Object describing the response properties of the operation.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
#suppress "@azure-tools/typespec-azure-resource-manager/no-response-body" "This operation must return a status monitor in its response."
@autoRoute
@Private.ensureResourceType(Resource)
op ResourceCollectionOperation<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  Response extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is Operation<
  Foundations.CollectionKeysOf<Resource> & Parameters,
  Response,
  Traits,
  ErrorResponse
>;

/**
 * Operation that lists resources in a paginated way.
 * @template Resource The type of the resource.
 * @template Parameters Object describing the request parameters of the operation.
 * @template Response Object describing the response properties of the operation.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
@listsResource(Resource)
@list
@Private.ensureResourceType(Resource)
op ResourceList<
  Resource extends TypeSpec.Reflection.Model,
  Parameters extends TypeSpec.Reflection.Model,
  Response extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is ResourceCollectionOperation<Resource, Parameters, Response, Traits, ErrorResponse>;

/**
 * Operation that lists resources in a non-paginated way.
 * @template Resource The type of the resource.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
#suppress "@azure-tools/typespec-providerhub/no-inline-model" "This operation signature is not used in Azure Resource Manager operations (yet)"
@autoRoute
@listsResource(Resource)
@Private.ensureResourceType(Resource)
op NonPagedResourceList<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is ResourceCollectionOperation<
  Resource,
  TraitProperties<Traits, TraitLocation.Parameters, TraitContext.List>,
  Body<Resource[]> & TraitProperties<Traits, TraitLocation.Response, TraitContext.List>,
  Traits,
  ErrorResponse
>;

/**
 * Long-running operation that updates a resource.
 * @template Resource The type of the resource.
 * @template Traits Traits which apply to the operation.
 * @template ErrorResponse The type of the error response. If not provided, the default error response type will be used.
 */
@updatesResource(Resource)
op LongRunningResourceUpdate<
  Resource extends TypeSpec.Reflection.Model,
  Traits extends TypeSpec.Reflection.Model = {},
  ErrorResponse = Azure.Core.Foundations.ErrorResponse
> is Foundations.ResourceOperation<
  Resource,
  {
    @doc("This request has a JSON Merge Patch body.")
    @TypeSpec.Http.header("Content-Type")
    contentType: "application/merge-patch+json";

    ...Foundations.ResourceBody<Resource>;
    ...TraitProperties<Traits, TraitLocation.Parameters, TraitContext.Update>;
  },
  Foundations.ResourceOkResponse<Resource &
    TraitProperties<Traits, TraitLocation.Response, TraitContext.Update> &
    Foundations.LongRunningStatusLocation<Resource>>,
  Traits,
  ErrorResponse
>;
