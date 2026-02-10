using Http;
using Rest;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;

namespace Azure.ResourceManager;

// OPERATION TEMPLATES

/**
 * A resource list operation, at the subscription scope
 * @template Resource the resource being patched
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the list operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("List {name} resources by subscription ID", Resource)
@list
@listsResource(Resource)
@segmentOf(Resource)
@armResourceList(Resource)
@get
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmListBySubscription<
  Resource extends Foundations.SimpleResource,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ResourceListResult<Resource>>,
  Error extends {} = ErrorResponse
> is ArmReadOperation<SubscriptionScope<Resource> & Parameters, Response, Error>;

/**
 * A resource list operation, at the scope of the resource's parent
 * @template Resource the resource being patched
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template ParentName Optional. The name of the parent resource
 * @template ParentFriendlyName Optional. The friendly name of the parent resource
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the list operation
 * @template Error Optional. The error response, if non-standard.
 */
@get
@autoRoute
@list
@listsResource(Resource)
@segmentOf(Resource)
@Private.armRenameListByOperation(Resource, ParentName, ParentFriendlyName, false) // This must come before @armResourceList!
@armResourceList(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceListByParent<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  ParentName extends valueof string = "",
  ParentFriendlyName extends valueof string = "",
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ResourceListResult<Resource>>,
  Error extends {} = ErrorResponse
> is ArmReadOperation<
  ResourceParentParameters<Resource, BaseParameters> & Parameters,
  Response,
  Error
>;

/**
 * A resource list operation, with scope determined by BaseParameters
 * @template Resource the resource being patched
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the list operation
 * @template Error Optional. The error response, if non-standard.
 */
@get
@autoRoute
@list
@listsResource(Resource)
@segmentOf(Resource)
@Private.armRenameListByOperation(Resource) // This must come before @armResourceList!
@armResourceList(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceListAtScope<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ResourceListResult<Resource>>,
  Error extends {} = ErrorResponse
> is ArmReadOperation<
  ResourceParentParameters<Resource, BaseParameters> & Parameters,
  Response,
  Error
>;

/**
 * A resource GET operation
 * @template Resource the resource being read
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the read operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Get a {name}", Resource)
@get
@armResourceRead(Resource)
op ArmResourceRead<
  Resource extends {},
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<Resource>,
  Error extends {} = ErrorResponse
> is ArmReadOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  Response,
  Error
>;

/**
 * Check a resource's existence via HEAD operation
 * @template Resource the resource being checked
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the read operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Check for the existence of a {name}", Resource)
@armResourceCheckExistence(Resource)
@head
op ArmResourceCheckExistence<
  Resource extends {},
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmResourceExistsResponse | ArmResourceNotFoundResponse,
  Error extends {} = ErrorResponse
> is ArmReadOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  Response,
  Error
>;

/**
 * A long-running resource CreateOrUpdate (PUT)
 * @template Resource the resource being created or updated
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Create a {name}", Resource)
@armResourceCreateOrUpdate(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@Azure.Core.Foundations.Private.defaultFinalStateVia(#["location", "azure-async-operation"])
@put
op ArmResourceCreateOrUpdateAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = Resource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedResponse<
    Resource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse
> is ArmCreateOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  Resource,
  Response,
  Error
>;

/**
 * DEPRECATED: Please use ArmResourceCreateOrReplaceSync instead
 * @template Resource the resource being created or updated
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 */
#deprecated "Please use ArmResourceCreateOrReplaceSync instead"
@autoRoute
@doc("Create a {name}", Resource)
@armResourceCreateOrUpdate(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@put
op ArmResourceCreateOrUpdateSync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<Resource>,
  Error extends {} = ErrorResponse
> is ArmCreateOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  Resource,
  Response,
  Error
>;

/**
 * Synchronous PUT operation for Azure Resource Manager resources
 * @template Resource the resource being created or replaced
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Create a {name}", Resource)
@armResourceCreateOrUpdate(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@put
op ArmResourceCreateOrReplaceSync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedSyncResponse<Resource>,
  Error extends {} = ErrorResponse
> is ArmCreateOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  Resource,
  Response,
  Error
>;

/**
 * @dev A long-running resource CreateOrUpdate (PUT)
 * @template Resource the resource being created or replaced
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrReplace operation
 * @template Error Optional. The error response, if non-standard.
 */
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceCreateOrReplaceAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = Resource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedResponse<
    Resource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse
> is ArmResourceCreateOrUpdateAsync<
  Resource,
  BaseParameters,
  LroHeaders,
  Parameters,
  Response,
  Error
>;

/**
 * @dev A long-running resource update that only allows updating resource tags (the minimum)
 * @template Resource the resource being patched
 * @template Properties Optional. Exists for parallelism with ArmResourcePatch.
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers that appear in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 */
@patch(#{ implicitOptionality: true })
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmTagsPatchAsync<
  Resource extends Foundations.SimpleResource,
  Properties extends {} = TagsUpdateModel<Resource>,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Resource,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {}
> is ArmCustomPatchAsync<
  Resource,
  TagsUpdateModel<Resource>,
  BaseParameters,
  LroHeaders,
  Parameters
>;

/**
 * @dev A long-running resource update using the items from the resource marked with Lifecycle.Update visibility
 * @template Resource the resource being patched
 * @template Properties The model type of the resource properties
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 */
@patch(#{ implicitOptionality: true })
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourcePatchAsync<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Resource,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {}
> is ArmCustomPatchAsync<Resource, Resource, BaseParameters, LroHeaders, Parameters>;

/**
 * A long-running resource update using a custom PATCH payload (Asynchronous)
 * @template Resource the resource being patched
 * @template PatchModel The input model for the PATCH request
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Update a {name}", Resource)
@armResourceUpdate(Resource)
@patch(#{ implicitOptionality: false })
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmCustomPatchAsync<
  Resource extends Foundations.SimpleResource,
  PatchModel extends TypeSpec.Reflection.Model = TagsUpdateModel<Resource>,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Resource,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<Resource> | ArmAcceptedLroResponse<
    "Resource update request accepted.",
    LroHeaders
  >,
  Error extends {} = ErrorResponse
> is ArmUpdateOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  PatchModel,
  Response,
  Error
>;

/**
 * @dev A resource update that only allows updating resource tags (the minimum)
 * @template Resource the resource being patched
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 */
@patch(#{ implicitOptionality: true })
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmTagsPatchSync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {}
> is ArmCustomPatchSync<Resource, TagsUpdateModel<Resource>, BaseParameters, Parameters>;

/**
 * @dev A resource update using the items from the resource marked with Lifecycle.Update visibility
 * @template Resource the resource being patched
 * @template Properties The model type of the resource properties
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 */
@patch(#{ implicitOptionality: true })
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourcePatchSync<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {}
> is ArmCustomPatchSync<Resource, Resource, BaseParameters, Parameters>;

/**
 * A resource update using a custom PATCH payload (synchronous)
 * @template Resource the resource being patched
 * @template PatchModel The input model for the PATCH request
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Update a {name}", Resource)
@armResourceUpdate(Resource)
@patch(#{ implicitOptionality: false })
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmCustomPatchSync<
  Resource extends Foundations.SimpleResource,
  PatchModel extends TypeSpec.Reflection.Model = TagsUpdateModel<Resource>,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<Resource>,
  Error extends {} = ErrorResponse
> is ArmUpdateOperation<
  ResourceInstanceParameters<Resource, BaseParameters> & Parameters,
  PatchModel,
  Response,
  Error
>;

/**
 * @dev Delete a resource asynchronously
 * @template Resource The resource being deleted
 * @template Response The response type for the operation
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Delete a {name}", Resource)
@armResourceDelete(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@delete
op ArmResourceDeleteAsyncBase<
  Resource extends Foundations.SimpleResource,
  Response,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse
>(...ResourceInstanceParameters<Resource, BaseParameters>, ...Parameters): Response | Error;

/**
 * @dev Delete a resource asynchronously.  DEPRECATED: Use ArmResourceDeleteWithoutOkAsync instead
 * @template Resource The resource being deleted
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template LroHeaders Optional. Allows overriding the headers in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response(s) for the delete operation
 * @template Error Optional. The error response, if non-standard.
 */
#deprecated "Use 'ArmResourceDeleteWithoutOkAsync' instead"
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceDeleteAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmDeletedResponse | ArmDeleteAcceptedLroResponse<LroHeaders> | ArmDeletedNoContentResponse,
  Error extends {} = ErrorResponse
> is ArmResourceDeleteAsyncBase<Resource, Response, BaseParameters, Parameters, Error>;

/**
 * @dev Delete a resource asynchronously
 * @template Resource The resource being deleted
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response(s) for the delete operation
 * @template Error Optional. The error response, if non-standard.
 */
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceDeleteWithoutOkAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<FinalResult = void> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmDeleteAcceptedLroResponse<LroHeaders> | ArmDeletedNoContentResponse,
  Error extends {} = ErrorResponse
> is ArmResourceDeleteAsyncBase<Resource, Response, BaseParameters, Parameters, Error>;

/**
 * Delete a resource synchronously
 * @template Resource The resource being deleted
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response(s) for the delete operation
 * @template Error Optional. The error response, if non-standard.
 */
@autoRoute
@doc("Delete a {name}", Resource)
@armResourceDelete(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@delete
op ArmResourceDeleteSync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Response extends {} = ArmDeletedResponse | ArmDeletedNoContentResponse,
  Error = ErrorResponse
>(...ResourceInstanceParameters<Resource, BaseParameters>, ...Parameters): Response | Error;

/**
 * A long-running resource action.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response type for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 */
@autoRoute
@armResourceAction(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@post
op ArmResourceActionAsyncBase<
  Resource extends Foundations.SimpleResource,
  Request,
  Response extends TypeSpec.Reflection.Model | unknown | void,
  BaseParameters extends TypeSpec.Reflection.Model,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
>(
  ...ResourceInstanceParameters<Resource, BaseParameters>,
  ...Parameters,

  @doc("The content of the action request")
  @armBodyRoot(OptionalRequestBody)
  body: Request,
): Response | Error;

/**
 * @dev A long-running resource action.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 */
@returnsDoc("Azure operation completed successfully.")
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceActionAsync<
  Resource extends Foundations.SimpleResource,
  Request,
  Response extends TypeSpec.Reflection.Model | unknown | void,
  BaseParameters extends TypeSpec.Reflection.Model = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Response,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
> is ArmResourceActionAsyncBase<
  Resource,
  Request,
  ArmAcceptedLroResponse<"Resource operation accepted.", LroHeaders> | Response,
  BaseParameters,
  Parameters,
  Error,
  OptionalRequestBody
>;

/**
 * A synchronous resource action.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 */
@autoRoute
@armResourceAction(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@post
@returnsDoc("Azure operation completed successfully.")
op ArmResourceActionSync<
  Resource extends Foundations.SimpleResource,
  Request,
  Response,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
>(
  ...ResourceInstanceParameters<Resource, BaseParameters>,
  ...Parameters,

  @doc("The content of the action request")
  @armBodyRoot(OptionalRequestBody)
  body: Request,
): Response | Error;

/**
 * @dev A long-running resource action that returns no content. DEPRECATED: Use 'ArmResourceActionNoResponseContentAsync' instead
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 */
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceActionNoContentAsync<
  Resource extends Foundations.SimpleResource,
  Request extends TypeSpec.Reflection.Model | void,
  BaseParameters extends TypeSpec.Reflection.Model = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
> is ArmResourceActionAsyncBase<
  Resource,
  Request,
  ArmAcceptedLroResponse<
    "Resource operation accepted.",
    LroHeaders
  > | ArmNoContentResponse<"Action completed successfully.">,
  BaseParameters,
  Parameters,
  Error,
  OptionalRequestBody
>;

/**
 * @dev A long-running resource action that returns no content.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 */
@Private.enforceConstraint(Resource, Foundations.Resource)
op ArmResourceActionNoResponseContentAsync<
  Resource extends Foundations.SimpleResource,
  Request,
  BaseParameters extends TypeSpec.Reflection.Model = DefaultBaseParameters<Resource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    void,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
> is ArmResourceActionAsyncBase<
  Resource,
  Request,
  ArmAcceptedLroResponse<"Resource operation accepted.", LroHeaders>,
  BaseParameters,
  Parameters,
  Error,
  OptionalRequestBody
>;

/**
 * A synchronous resource action that returns no content.
 * @template Resource The resource being acted upon
 * @template Request The request model for the action
 * @template BaseParameters Optional. Allows overriding the parameters for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 */
@autoRoute
@armResourceAction(Resource)
@Private.enforceConstraint(Resource, Foundations.Resource)
@post
op ArmResourceActionNoContentSync<
  Resource extends Foundations.SimpleResource,
  Request,
  BaseParameters = DefaultBaseParameters<Resource>,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
>(
  ...ResourceInstanceParameters<Resource, BaseParameters>,
  ...Parameters,

  @doc("The content of the action request")
  @armBodyRoot(OptionalRequestBody)
  body: Request,
): ArmNoContentResponse<"Action completed successfully."> | Error;

/**
 * @dev Adds check global name availability operation, normally used if
 * a resource name must be globally unique (for example, if the resource
 * exposes and endpoint that uses the resource name in the url)
 * @template Request the availability request, defaults to the standard request, containing name and resource type
 * @template Response the availability response, default to the standard response
 * @template AdditionalParams A model specifying additional non-path parameters to the availability request
 */
@doc("Implements global CheckNameAvailability operations")
op checkGlobalNameAvailability<
  Request extends TypeSpec.Reflection.Model = Azure.ResourceManager.Foundations.CheckNameAvailabilityRequest,
  Response extends TypeSpec.Reflection.Model = CheckNameAvailabilityResponse,
  AdditionalParams extends TypeSpec.Reflection.Model = {}
> is checkNameAvailability<
  CommonTypes.SubscriptionIdParameter & DefaultProviderNamespace,
  Request,
  Response,
  AdditionalParams
>;

/**
 * @dev Adds check location-specific name availability operation, normally used if
 * a resource name must be globally unique (for example, if the resource
 * exposes and endpoint that uses the resource name in the url)
 * @template Request the availability request, defaults to the standard request, containing name and resource type
 * @template Response the availability response, default to the standard response
 * @template AdditionalParams A model specifying additional non-path parameters to the availability request
 */
@doc("Implements local CheckNameAvailability operations")
op checkLocalNameAvailability<
  Request extends TypeSpec.Reflection.Model = Azure.ResourceManager.Foundations.CheckNameAvailabilityRequest,
  Response extends TypeSpec.Reflection.Model = CheckNameAvailabilityResponse,
  AdditionalParams extends TypeSpec.Reflection.Model = {}
> is checkNameAvailability<
  CommonTypes.SubscriptionIdParameter & DefaultProviderNamespace & LocationResourceParameter,
  Request,
  Response,
  AdditionalParams
>;

/**
 * @dev A provider action performed over a tenant
 * @template Request The request model for the action
 * @template Response The response type for the action
 * @template Scope The scope of the action (SubscriptionActionScope, TenantActionScope, or ExtensionResourceActionScope)
 * @template Parameters Optional. Additional parameters after the path parameters (e.g. Location)
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 */
@post
@action
@armResourceCollectionAction
@Private.armUpdateProviderNamespace
op ArmProviderActionSync<
  Request extends {} | void = void,
  Response extends {} | void = void,
  Scope extends {} = TenantActionScope,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
>(
  ...Azure.ResourceManager.Foundations.DefaultBaseParameters<Scope>,
  ...Scope,
  ...ProviderNamespace<Scope>,
  ...Parameters,

  /** The request body */
  @armBodyRoot(OptionalRequestBody) body: Request,
): Response | Error;

/**
 * @dev A long-running provider action.
 * @template Request The request model for the action
 * @template Response The response type for the action
 * @template Scope The scope of the action (SubscriptionActionScope, TenantActionScope, or ExtensionResourceActionScope)
 * @template Parameters Optional. Additional parameters after the path parameters (e.g. Location)
 * @template LroHeaders Optional.  Allows overriding the lro headers returned in the Accepted response
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 */
@post
@action
@armResourceCollectionAction
@Private.armUpdateProviderNamespace
op ArmProviderActionAsync<
  Request extends {} | void = void,
  Response extends TypeSpec.Reflection.Model | unknown | void = void,
  Scope extends {} = TenantActionScope,
  Parameters extends {} = {},
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Response,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
>(
  ...Azure.ResourceManager.Foundations.DefaultBaseParameters<Scope>,
  ...Scope,
  ...ProviderNamespace<Scope>,
  ...Parameters,

  /** The request body */
  @armBodyRoot(OptionalRequestBody) body: Request,
): ArmAcceptedLroResponse<"Resource operation accepted.", LroHeaders> | Response | Error;
