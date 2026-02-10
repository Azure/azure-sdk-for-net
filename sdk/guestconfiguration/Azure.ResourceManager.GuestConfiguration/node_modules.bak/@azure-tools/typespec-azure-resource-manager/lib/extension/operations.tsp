namespace Azure.ResourceManager.Extension;

using Http;
using Rest;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;

// OPERATION TEMPLATES

/**
 * List an extension resource at the given target scope
 * @template TargetResource The target to list at, e.g. Extension.Subscription or Extension>ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being listed
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the list operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("List {name} resources by scope", ExtensionResource)
@list
@listsResource(ExtensionResource)
@segmentOf(ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "list", OverrideResourceName)
@get
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
op ListByTarget<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ResourceListResult<ExtensionResource>>,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmReadOperation<
  ExtensionParentParameters<TargetResource, ExtensionResource> & Parameters,
  Response,
  Error
>;

/**
 * A resource GET operation
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being rea
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the read operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Get a {name}", ExtensionResource)
@get
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@extensionResourceOperation(TargetResource, ExtensionResource, "read", OverrideResourceName)
op Read<
  TargetResource extends SimpleResource,
  ExtensionResource extends SimpleResource,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ExtensionResource>,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmReadOperation<
  ExtensionInstanceParameters<TargetResource, ExtensionResource> & Parameters,
  Response,
  Error
>;

/**
 * Check a resource's existence via HEAD operation
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the extension resource being checked
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the read operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Check for the existence of a {name}", ExtensionResource)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@extensionResourceOperation(
  TargetResource,
  ExtensionResource,
  "checkExistence",
  OverrideResourceName
)
@head
op CheckExistence<
  TargetResource extends SimpleResource,
  ExtensionResource extends SimpleResource,
  Parameters extends {} = {},
  Response extends {} = ArmResourceExistsResponse | ArmResourceNotFoundResponse,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmReadOperation<
  ExtensionInstanceParameters<TargetResource, ExtensionResource> & Parameters,
  Response,
  Error
>;

/**
 * A long-running resource CreateOrUpdate (PUT)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being created or updated
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients
 */
@autoRoute
@doc("Create a {name}", ExtensionResource)
@extensionResourceOperation(
  TargetResource,
  ExtensionResource,
  "createOrUpdate",
  OverrideResourceName
)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@Azure.Core.Foundations.Private.defaultFinalStateVia(#["location", "azure-async-operation"])
@put
op CreateOrUpdateAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = ExtensionResource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<ExtensionResource> | ArmResourceCreatedResponse<
    ExtensionResource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmCreateOperation<
  ExtensionInstanceParameters<TargetResource, ExtensionResource> & Parameters,
  ExtensionResource,
  Response,
  Error
>;

/**
 * Synchronous PUT operation for Azure Resource Manager resources
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being created or replaced
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Create a {name}", ExtensionResource)
@extensionResourceOperation(
  TargetResource,
  ExtensionResource,
  "createOrUpdate",
  OverrideResourceName
)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@put
op CreateOrReplaceSync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<ExtensionResource> | ArmResourceCreatedSyncResponse<ExtensionResource>,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmCreateOperation<
  ExtensionInstanceParameters<TargetResource, ExtensionResource> & Parameters,
  ExtensionResource,
  Response,
  Error
>;

/**
 * @dev A long-running resource CreateOrUpdate (PUT)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being created or replaced
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrReplace operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients
 */
@autoRoute
@doc("Create a {name}", ExtensionResource)
@extensionResourceOperation(
  TargetResource,
  ExtensionResource,
  "createOrUpdate",
  OverrideResourceName
)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
op CreateOrReplaceAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = ExtensionResource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<ExtensionResource> | ArmResourceCreatedResponse<
    ExtensionResource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is CreateOrUpdateAsync<
  TargetResource,
  ExtensionResource,
  LroHeaders,
  Parameters,
  Response,
  Error,
  OverrideResourceName
>;

/**
 * A long-running resource update using a custom PATCH payload (Asynchronous)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being patched
 * @template PatchModel The input model for the PATCH request
 * @template LroHeaders Optional.  Allows overriding the lro headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients
 */
@autoRoute
@doc("Update a {name}", ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "update", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@patch(#{ implicitOptionality: false })
op CustomPatchAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  PatchModel extends TypeSpec.Reflection.Model = TagsUpdateModel<ExtensionResource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    ExtensionResource,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ExtensionResource> | ArmAcceptedLroResponse<
    "Resource update request accepted.",
    LroHeaders
  >,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmUpdateOperation<
  ExtensionInstanceParameters<TargetResource, ExtensionResource> & Parameters,
  PatchModel,
  Response,
  Error
>;

/**
 * A resource update using a custom PATCH payload (synchronous)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being patched
 * @template PatchModel The input model for the PATCH request
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Update a {name}", ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "update", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@patch(#{ implicitOptionality: false })
op CustomPatchSync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  PatchModel extends TypeSpec.Reflection.Model = TagsUpdateModel<ExtensionResource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ExtensionResource>,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is ArmUpdateOperation<
  ExtensionInstanceParameters<TargetResource, ExtensionResource> & Parameters,
  PatchModel,
  Response,
  Error
>;

/**
 * @dev Delete a resource asynchronously
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being deleted
 * @template Response The response type for the operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Delete a {name}", ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "delete", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@delete
op DeleteAsyncBase<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Response,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
>(
  ...ExtensionInstanceParameters<TargetResource, ExtensionResource>,
  ...Parameters,
): Response | Error;

/**
 * @dev Delete a resource asynchronously.
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being deleted
 * @template LroHeaders Optional. Allows overriding the headers in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response(s) for the delete operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
#deprecated "Use 'DeleteWithoutOkAsync' instead"
@autoRoute
@doc("Delete a {name}", ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "delete", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
op DeleteAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmDeletedResponse | ArmDeleteAcceptedLroResponse<LroHeaders> | ArmDeletedNoContentResponse,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is DeleteAsyncBase<
  TargetResource,
  ExtensionResource,
  Response,
  Parameters,
  Error,
  OverrideResourceName
>;

/**
 * @dev Delete a resource asynchronously
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being deleted
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response(s) for the delete operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Delete a {name}", ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "delete", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
op DeleteWithoutOkAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmDeleteAcceptedLroResponse<LroHeaders> | ArmDeletedNoContentResponse,
  Error extends {} = ErrorResponse,
  OverrideResourceName extends valueof string = ""
> is DeleteAsyncBase<
  TargetResource,
  ExtensionResource,
  Response,
  Parameters,
  Error,
  OverrideResourceName
>;

/**
 * Delete a resource synchronously
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being deleted
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response(s) for the delete operation
 * @template Error Optional. The error response, if non-standard.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@doc("Delete a {name}", ExtensionResource)
@extensionResourceOperation(TargetResource, ExtensionResource, "delete", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@delete
op DeleteSync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Parameters extends {} = {},
  Response extends {} = ArmDeletedResponse | ArmDeletedNoContentResponse,
  Error = ErrorResponse,
  OverrideResourceName extends valueof string = ""
>(
  ...ExtensionInstanceParameters<TargetResource, ExtensionResource>,
  ...Parameters,
): Response | Error;

/**
 * A long-running resource action.
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response type for the action
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@extensionResourceOperation(TargetResource, ExtensionResource, "action", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@post
op ActionAsyncBase<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends TypeSpec.Reflection.Model | void,
  Response extends TypeSpec.Reflection.Model | void,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
>(
  ...ExtensionInstanceParameters<TargetResource, ExtensionResource>,
  ...Parameters,

  @doc("The content of the action request")
  @armBodyRoot(OptionalRequestBody)
  body: Request,
): Response | Error;

/**
 * @dev A long-running resource action.
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response model for the action
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@extensionResourceOperation(TargetResource, ExtensionResource, "action", OverrideResourceName)
@returnsDoc("Azure operation completed successfully.")
@enforceConstraint(ExtensionResource, Foundations.Resource)
op ActionAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends TypeSpec.Reflection.Model | void,
  Response extends TypeSpec.Reflection.Model | void,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    Response,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> is ActionAsyncBase<
  TargetResource,
  ExtensionResource,
  Request,
  ArmAcceptedLroResponse<"Resource operation accepted.", LroHeaders> | Response,
  Parameters,
  Error,
  OptionalRequestBody
>;

/**
 * A synchronous resource action.
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being acted upon
 * @template Request The request model for the action
 * @template Response The response model for the action
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@extensionResourceOperation(TargetResource, ExtensionResource, "action", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@post
@returnsDoc("Azure operation completed successfully.")
op ActionSync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends TypeSpec.Reflection.Model | void,
  Response extends TypeSpec.Reflection.Model | void,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
>(
  ...ExtensionInstanceParameters<TargetResource, ExtensionResource>,
  ...Parameters,

  @doc("The content of the action request")
  @armBodyRoot(OptionalRequestBody)
  body: Request,
): Response | Error;

/**
 * @dev A long-running resource action that returns no content.
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being acted upon
 * @template Request The request model for the action
 * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the body parameter is optional.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 */
@autoRoute
@extensionResourceOperation(TargetResource, ExtensionResource, "action", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@post
op ActionNoResponseContentAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends TypeSpec.Reflection.Model | void,
  LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
    Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
    void,
    string
  > &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> is ActionAsyncBase<
  TargetResource,
  ExtensionResource,
  Request,
  ArmAcceptedLroResponse<"Resource operation accepted.", LroHeaders>,
  Parameters,
  Error,
  OptionalRequestBody
>;

/**
 * A synchronous resource action that returns no content.
 * @template TargetResource The target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource The resource being acted upon
 * @template Request The request model for the action
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 * @template OverrideResourceName Optional. Allows overriding the resource name for this scope in generated clients.
 *
 */
@autoRoute
@extensionResourceOperation(TargetResource, ExtensionResource, "action", OverrideResourceName)
@enforceConstraint(TargetResource, Foundations.Resource)
@enforceConstraint(ExtensionResource, Foundations.Resource)
@post
op ActionNoContentSync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends TypeSpec.Reflection.Model | void,
  Parameters extends {} = {},
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
>(
  ...ExtensionInstanceParameters<TargetResource, ExtensionResource>,
  ...Parameters,

  @doc("The content of the action request")
  @armBodyRoot(OptionalRequestBody)
  body: Request,
): ArmNoContentResponse<"Action completed successfully."> | Error;
