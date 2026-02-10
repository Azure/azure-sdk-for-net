import "@typespec/rest";
import "@typespec/http";

namespace Azure.ResourceManager.Legacy.PrivateEndpoints;

using Http;
using Azure.ResourceManager.Foundations;
using Rest;

/**
 * @dev List the private endpoint connections over a resource
 * @template ParentResource the parent resource of the PrivateEndpointConnection
 * @template Resource Optional. The PrivateEndpointConnection resource being listed
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template ParentName Optional. The name of the parent resource
 * @template ParentFriendlyName Optional. The friendly name of the parent resource
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the list operation
 * @template Error Optional. The error response, if non-standard.
 */
@doc("List {name} PrivateEndpointConnections", ParentResource)
@get
@autoRoute
@listsResource(Resource)
@segmentOf(PrivateEndpointConnectionParameter)
@armResourceList(Resource)
@Private.enforceConstraint(ParentResource, Foundations.Resource)
op ListSinglePageByParent<
  ParentResource extends Foundations.SimpleResource,
  Resource extends PrivateEndpointConnectionResource,
  BaseParameters = DefaultBaseParameters<ParentResource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ResourceListResult<Resource>>,
  Error extends {} = ErrorResponse
> is ArmReadOperation<
  ResourceInstanceParameters<ParentResource, BaseParameters> & Parameters,
  Response,
  Error
>;

/**
 * @dev Synchronous PUT operation for a Private endpoint connection to a resource
 * @template ParentResource the parent resource of the PrivateEndpointConnection
 * @template Resource the PrivateEndpointConnection resource being created or updated
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 * @template Request Optional. The request body for the operation.
 */
@autoRoute
@doc("Create a {name} PrivateEndpointConnection", ParentResource)
@armResourceCreateOrUpdate(Resource)
@Private.enforceConstraint(ParentResource, Foundations.Resource)
@put
op CreateOrReplaceSync<
  ParentResource extends Foundations.SimpleResource,
  Resource extends PrivateEndpointConnectionResource,
  BaseParameters = DefaultBaseParameters<ParentResource>,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedSyncResponse<Resource>,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  Request extends {} | void = Resource
> is Azure.ResourceManager.Legacy.CreateOperation<
  ResourceInstanceParameters<ParentResource, BaseParameters> &
    KeysOf<PrivateEndpointConnectionParameter> &
    Parameters,
  Request,
  Response,
  Error,
  OptionalRequestBody
>;

/**
 * @dev A long-running resource CreateOrUpdate (PUT) for a PrivateEndpointConnection to a resource
 * @template ParentResource the parent resource of the PrivateEndpointConnection
 * @template Resource the PrivateEndpointConnection resource being created or updated
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrReplace operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 * @template Request Optional. The request body for the operation.
 */
@autoRoute
@doc("Create a {name} PrivateEndpointConnection", ParentResource)
@armResourceCreateOrUpdate(Resource)
@Private.enforceConstraint(ParentResource, Foundations.Resource)
@Azure.Core.Foundations.Private.defaultFinalStateVia(#["location", "azure-async-operation"])
@put
op CreateOrReplaceAsync<
  ParentResource extends Foundations.SimpleResource,
  Resource extends PrivateEndpointConnectionResource,
  BaseParameters = DefaultBaseParameters<ParentResource>,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = Resource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedResponse<
    Resource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  Request extends {} | void = Resource
> is Azure.ResourceManager.Legacy.CreateOperation<
  ResourceInstanceParameters<ParentResource, BaseParameters> &
    KeysOf<PrivateEndpointConnectionParameter> &
    Parameters,
  Request,
  Response,
  Error,
  OptionalRequestBody
>;

/**
 * A long-running resource update using a custom PATCH payload (Asynchronous) to update a PrivateEndpointConnection to a resource.
 * @template ParentResource the parent resource of the PrivateEndpointConnection
 * @template Resource the PrivateEndpointConnection resource being updated
 * @template PatchModel The input model for the PATCH request
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template LroHeaders Optional.  Allows overriding the lro headers returned in the Accepted response
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 */
@autoRoute
@doc("Update a {name} PrivateEndpointConnection", ParentResource)
@armResourceUpdate(Resource)
@Private.enforceConstraint(ParentResource, Foundations.Resource)
@patch(#{ implicitOptionality: false })
op CustomPatchAsync<
  ParentResource extends Foundations.SimpleResource,
  Resource extends PrivateEndpointConnectionResource,
  PatchModel extends {} | void = PrivateEndpointConnectionUpdate,
  BaseParameters = DefaultBaseParameters<ParentResource>,
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
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
> is Azure.ResourceManager.Legacy.UpdateOperation<
  ResourceInstanceParameters<ParentResource, BaseParameters> &
    KeysOf<PrivateEndpointConnectionParameter> &
    Parameters,
  PatchModel,
  Response,
  Error,
  OptionalRequestBody
>;

/**
 * @dev A resource update using a custom PATCH payload (synchronous) to update a PrivateEndpointConnection to a resource
 * @template ParentResource The parent resource of the PrivateEndpointConnection
 * @template Resource Optional. The PrivateEndpointConnection resource being patched
 * @template PatchModel The input model for the PATCH request
 * @template BaseParameters Optional. Allows overriding the operation parameters
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Indicates whether the request body is optional.
 */
@autoRoute
@doc("Update a {name PrivateEndpointConnection}", ParentResource)
@armResourceUpdate(Resource)
@Private.enforceConstraint(ParentResource, Foundations.Resource)
@patch(#{ implicitOptionality: false })
op CustomPatchSync<
  ParentResource extends Foundations.SimpleResource,
  Resource extends PrivateEndpointConnectionResource,
  PatchModel extends {} | void = PrivateEndpointConnectionUpdate,
  BaseParameters = DefaultBaseParameters<ParentResource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<Resource>,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false
> is Azure.ResourceManager.Legacy.UpdateOperation<
  ResourceInstanceParameters<ParentResource, BaseParameters> &
    KeysOf<PrivateEndpointConnectionParameter> &
    Parameters,
  PatchModel,
  Response,
  Error,
  OptionalRequestBody
>;
