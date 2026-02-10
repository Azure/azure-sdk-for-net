import "@typespec/rest";
import "@typespec/http";

namespace Azure.ResourceManager.Legacy.Extension;

using Http;
using Azure.ResourceManager.Foundations;
using Rest;
using Azure.ResourceManager.Private;

/**
 * DEPRECATED: Use CreateOrReplaceAsync instead.
 * A long-running resource CreateOrUpdate (PUT)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being created or updated
 * @template Request Optional. The request body for the createOrUpdate operation
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. If true, the request body is optional
 * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
 */
alias CreateOrUpdateAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends {} | void = ExtensionResource,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = ExtensionResource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<ExtensionResource> | ArmResourceCreatedResponse<
    ExtensionResource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> = CreateOrReplaceAsync<
  TargetResource,
  ExtensionResource,
  Request,
  LroHeaders,
  Parameters,
  Response,
  Error,
  OptionalRequestBody,
  OverrideResourceName
>;

/** A long-running resource CreateOrUpdate (PUT)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being created or updated
 * @template Request Optional. The request body for the createOrUpdate operation
 * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. If true, the request body is optional
 * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
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
op CreateOrReplaceAsync<
  TargetResource extends Foundations.SimpleResource,
  ExtensionResource extends Foundations.SimpleResource,
  Request extends {} | void = ExtensionResource,
  LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = ExtensionResource> &
    Azure.Core.Foundations.RetryAfterHeader,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<ExtensionResource> | ArmResourceCreatedResponse<
    ExtensionResource,
    LroHeaders
  >,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> is CreateOperation<
  Azure.ResourceManager.Extension.ExtensionInstanceParameters<TargetResource, ExtensionResource> &
    Parameters,
  Request,
  Response,
  Error,
  OptionalRequestBody
>;

/**
 * Synchronous PUT operation for Azure Resource Manager resources
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being created or replaced
 * @template Request Optional. The request body for the createOrUpdate operation
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the createOrUpdate operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. If true, the request body is optional
 * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
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
  Request extends {} | void = ExtensionResource,
  Parameters extends {} = {},
  Response extends {} = ArmResourceUpdatedResponse<ExtensionResource> | ArmResourceCreatedSyncResponse<ExtensionResource>,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> is CreateOperation<
  Azure.ResourceManager.Extension.ExtensionInstanceParameters<TargetResource, ExtensionResource> &
    Parameters,
  Request,
  Response,
  Error,
  OptionalRequestBody
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
 * @template OptionalRequestBody Optional. Whether the request body is optional.
 * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
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
  PatchModel extends TypeSpec.Reflection.Model | void = TagsUpdateModel<ExtensionResource>,
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
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> is UpdateOperation<
  Azure.ResourceManager.Extension.ExtensionInstanceParameters<TargetResource, ExtensionResource> &
    Parameters,
  PatchModel,
  Response,
  Error,
  OptionalRequestBody
>;

/**
 * A resource update using a custom PATCH payload (synchronous)
 * @template TargetResource the target resource, e.g. Extension.Subscription or Extension.ManagementGroup or Extension.ResourceGroup
 * @template ExtensionResource the resource being patched
 * @template PatchModel The input model for the PATCH request
 * @template Parameters Optional. Additional parameters after the path parameters
 * @template Response Optional. The success response for the patch operation
 * @template Error Optional. The error response, if non-standard.
 * @template OptionalRequestBody Optional. Whether the request body is optional.
 * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
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
  PatchModel extends TypeSpec.Reflection.Model | void = TagsUpdateModel<ExtensionResource>,
  Parameters extends {} = {},
  Response extends {} = ArmResponse<ExtensionResource>,
  Error extends {} = ErrorResponse,
  OptionalRequestBody extends valueof boolean = false,
  OverrideResourceName extends valueof string = ""
> is UpdateOperation<
  Azure.ResourceManager.Extension.ExtensionInstanceParameters<TargetResource, ExtensionResource> &
    Parameters,
  PatchModel,
  Response,
  Error,
  OptionalRequestBody
>;
