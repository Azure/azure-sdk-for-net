import "@typespec/rest";
import "@typespec/http";

namespace Azure.ResourceManager.Legacy;

using Http;
using Azure.ResourceManager.Private;
using Rest;

/**
 * An operation template used to build extension resource operations using non-standard paths.
 * @template TargetParameters The path parameters for the target resource
 * @template ExtensionParentParameters Parent parameters of the extension resource
 * @template ExtensionInstanceParameters The instance parameters of the extension resource
 * @template ResourceName Optional. The name of the resource type at this scope in clients.
 */
@doc("")
interface ExtensionOperations<
  TargetParameters extends {},
  ExtensionParentParameters extends {},
  ExtensionInstanceParameters extends {},
  ResourceName extends valueof string = string("")
> {
  /**
   * A long-running resource CreateOrUpdate (PUT)
   * @template Resource the resource being created or updated
   * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response(s) for the PUT operation
   * @template OptionalRequestBody Optional. Indicates whether the request body is optional
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template Request Optional. The request body for the createOrUpdate operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("Create a {name}", Resource)
  @legacyExtensionResourceOperation(Resource, "createOrUpdate", OverrideResourceName)
  @Azure.Core.Foundations.Private.defaultFinalStateVia(#["location", "azure-async-operation"])
  @put
  CreateOrUpdateAsync<
    Resource extends Foundations.SimpleResource,
    LroHeaders extends TypeSpec.Reflection.Model = ArmAsyncOperationHeader<FinalResult = Resource> &
      Azure.Core.Foundations.RetryAfterHeader,
    Parameters extends {} = {},
    Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedResponse<
      Resource,
      LroHeaders
    >,
    OptionalRequestBody extends valueof boolean = false,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    Request extends {} | void = Resource,
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(
    ...TargetParameters,
    ...ExtensionInstanceParameters,
    ...Parameters,
    @doc("Resource create parameters.") @armBodyRoot(OptionalRequestBody) resource: Request,
  ): Response | ErrorType;

  /**
   * A synchronous resource CreateOrUpdate (PUT)
   * @template Resource the resource being created or updated
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response(s) for the PUT operation
   * @template OptionalRequestBody Optional. Indicates whether the request body is optional
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template Request Optional. The request body for the createOrUpdate operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  #suppress "@azure-tools/typespec-azure-core/no-private-usage"
  @armOperationRoute(OperationOptions)
  @doc("Create a {name}", Resource)
  @legacyExtensionResourceOperation(Resource, "createOrUpdate", OverrideResourceName)
  @put
  CreateOrUpdateSync<
    Resource extends Foundations.SimpleResource,
    Parameters extends {} = {},
    Response extends {} = ArmResourceUpdatedResponse<Resource> | ArmResourceCreatedSyncResponse<Resource>,
    OptionalRequestBody extends valueof boolean = false,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    Request extends {} | void = Resource,
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(
    ...TargetParameters,
    ...ExtensionInstanceParameters,
    ...Parameters,
    @doc("Resource create parameters.") @armBodyRoot(OptionalRequestBody) resource: Request,
  ): Response | ErrorType;

  /**
   * A long-running resource Update (PATCH)
   * @template Resource the resource being created or updated
   * @template PatchModel the PATCH request model
   * @template LroHeaders Optional.  Allows overriding the lro headers returned on resource create
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response(s) for the PATCH operation
   * @template OptionalRequestBody Optional. Indicates whether the request body is optional
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("Update a {name}", Resource)
  @legacyExtensionResourceOperation(Resource, "update", OverrideResourceName)
  @patch(#{ implicitOptionality: false })
  CustomPatchAsync<
    Resource extends Foundations.SimpleResource,
    PatchModel extends {} | void = Azure.ResourceManager.Foundations.TagsUpdateModel<Resource>,
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
    OptionalRequestBody extends valueof boolean = false,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(
    ...TargetParameters,
    ...ExtensionInstanceParameters,
    ...Parameters,
    @doc("Resource create parameters.") @armBodyRoot(OptionalRequestBody) properties: PatchModel,
  ): Response | ErrorType;

  /**
   * A synchronous resource Update (PATCH)
   * @template Resource the resource being created or updated
   * @template PatchModel the PATCH request model
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response(s) for the PATCH operation
   * @template OptionalRequestBody Optional. Indicates whether the request body is optional
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("Update a {name}", Resource)
  @legacyExtensionResourceOperation(Resource, "update", OverrideResourceName)
  @patch(#{ implicitOptionality: false })
  CustomPatchSync<
    Resource extends Foundations.SimpleResource,
    PatchModel extends {} | void = Azure.ResourceManager.Foundations.TagsUpdateModel<Resource>,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<Resource>,
    OptionalRequestBody extends valueof boolean = false,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(
    ...TargetParameters,
    ...ExtensionInstanceParameters,
    ...Parameters,
    @doc("Resource create parameters.") @armBodyRoot(OptionalRequestBody) properties: PatchModel,
  ): Response | ErrorType;

  /**
   * Delete a resource asynchronously
   * @template Resource The resource being deleted
   * @template LroHeaders The lro headers for the operation
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response(s) for the delete operation
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Valid"
  @armOperationRoute(OperationOptions)
  @doc("Delete a {name}", Resource)
  @delete
  @deletesResource(Resource)
  @legacyExtensionResourceOperation(Resource, "delete", OverrideResourceName)
  DeleteWithoutOkAsync<
    Resource extends Foundations.SimpleResource,
    LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader &
      Azure.Core.Foundations.RetryAfterHeader,
    Parameters extends {} = {},
    Response extends {} = ArmDeleteAcceptedLroResponse<LroHeaders> | ArmDeletedNoContentResponse,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(...TargetParameters, ...ExtensionInstanceParameters, ...Parameters): Response | ErrorType;

  /**
   * Delete a resource synchronously
   * @template Resource The resource being deleted
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response(s) for the delete operation
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "Valid"
  @armOperationRoute(OperationOptions)
  @doc("Delete a {name}", Resource)
  @delete
  @deletesResource(Resource)
  @legacyExtensionResourceOperation(Resource, "delete", OverrideResourceName)
  DeleteSync<
    Resource extends Foundations.SimpleResource,
    Parameters extends {} = {},
    Response extends {} = ArmDeletedResponse | ArmDeletedNoContentResponse,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(...TargetParameters, ...ExtensionInstanceParameters, ...Parameters): Response | ErrorType;

  /**
   * @dev Get a resource
   * @template Resource The resource being read
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response for a get operation.
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("Get a {name}", Resource)
  @get
  @readsResource(Resource)
  @legacyExtensionResourceOperation(Resource, "read", OverrideResourceName)
  Read<
    Resource extends Foundations.SimpleResource,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<Resource>,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(...TargetParameters, ...ExtensionInstanceParameters, ...Parameters): Response | ErrorType;

  /**
   * Check a resource's existence via HEAD operation
   * @template Resource The resource being checked
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response for a head operation (by default NoContent or NotFound response).
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("Check for the existence of a {name}", Resource)
  @legacyExtensionResourceOperation(Resource, "checkExistence", OverrideResourceName)
  @head
  CheckExistence<
    Resource extends Foundations.SimpleResource,
    Parameters extends {} = {},
    Response extends {} = ArmResourceExistsResponse | ArmResourceNotFoundResponse,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  > is Foundations.ArmReadOperation<
    TargetParameters & ExtensionInstanceParameters & Parameters,
    Response,
    ErrorType
  >;
  /**
   * List a resource
   * @template Resource The resource being listed
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The response returned by the list
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("List a {name}", Resource)
  @get
  @list
  @listsResource(Resource)
  @legacyExtensionResourceOperation(Resource, "list", OverrideResourceName)
  List<
    Resource extends Foundations.SimpleResource,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<ResourceListResult<Resource>>,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(...TargetParameters, ...ExtensionParentParameters, ...Parameters): Response | ErrorType;

  /**
   * List a resource, without pagination
   * @template Resource The resource being listed
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The response returned by the list
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @armOperationRoute(OperationOptions)
  @doc("List a {name}", Resource)
  @get
  @listsResource(Resource)
  @legacyExtensionResourceOperation(Resource, "list", OverrideResourceName)
  ListSinglePage<
    Resource extends Foundations.SimpleResource,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<ResourceListResult<Resource>>,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(...TargetParameters, ...ExtensionParentParameters, ...Parameters): Response | ErrorType;

  /**
   * A synchronous resource action.
   * @template Resource The resource being acted upon
   * @template Request The request model for the action
   * @template Response The response model for the action
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template OptionalRequestBody Optional. Indicates whether the request body is optional
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  @doc("")
  @armOperationRoute(OperationOptions)
  @legacyExtensionResourceOperation(Resource, "action", OverrideResourceName)
  @Private.enforceConstraint(Resource, Foundations.Resource)
  @post
  @returnsDoc("Azure operation completed successfully.")
  ActionSync<
    Resource extends Foundations.SimpleResource,
    Request,
    Response extends TypeSpec.Reflection.Model | void,
    Parameters extends {} = {},
    OptionalRequestBody extends valueof boolean = false,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(
    ...TargetParameters,
    ...ExtensionInstanceParameters,
    ...Parameters,

    @doc("The content of the action request")
    @armBodyRoot(OptionalRequestBody)
    body: Request,
  ): Response | ErrorType;

  /**
   * A long-running resource action.
   * @template Resource The resource being acted upon
   * @template Request The request model for the action
   * @template Result The result model for the action
   * @template LroHeaders Optional. Allows overriding the headers returned in the Accepted response
   * @template Response The full response union of the action
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template OptionalRequestBody Optional. Indicates whether the request body is optional
   * @template ErrorType Optional. The error response, if non-standard.
   * @template OperationOptions Optional. The route options for the operation.
   * @template OverrideResourceName Optional. The name of the resource type at this scope in clients.
   */
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "ARM"
  @doc("")
  @armOperationRoute(OperationOptions)
  @legacyExtensionResourceOperation(Resource, "action", OverrideResourceName)
  @Private.enforceConstraint(Resource, Foundations.Resource)
  @post
  @returnsDoc("Azure operation completed successfully.")
  ActionAsync<
    Resource extends Foundations.SimpleResource,
    Request,
    Result extends TypeSpec.Reflection.Model | void,
    LroHeaders extends TypeSpec.Reflection.Model = ArmLroLocationHeader<
      Azure.Core.StatusMonitorPollingOptions<ArmOperationStatus>,
      Result,
      string
    > &
      Azure.Core.Foundations.RetryAfterHeader,
    Parameters extends {} = {},
    Response extends {} | void = ArmAcceptedLroResponse<
      "Resource operation accepted.",
      LroHeaders
    > | Result,
    OptionalRequestBody extends valueof boolean = false,
    ErrorType extends {} = ErrorResponse,
    OperationOptions extends valueof ArmOperationOptions = #{ useStaticRoute: false },
    OverrideResourceName extends valueof string = "${ResourceName}"
  >(
    ...TargetParameters,
    ...ExtensionInstanceParameters,
    ...Parameters,

    @doc("The content of the action request")
    @armBodyRoot(OptionalRequestBody)
    body: Request,
  ): Response | ErrorType;
}
