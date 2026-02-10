using Http;
using Rest;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;

namespace Azure.ResourceManager;

/**
 * A private link resource.
 * Resource providers must declare a private link resource type in their provider namespace if
 * they support private link resources
 * @template Description Optional. The documentary description of the private link resource name parameter.
 * @template KeyName Optional. The name of the private link resource name parameter.
 * @example
 * ```ts
 * namespace Microsoft.Contoso;
 * model PrivateLink is PrivateLinkResource {}
 * alias EmployeeConnectionOps is PrivateLinks<PrivateLink>;
 * @armResourceOperations
 * interface Employees {
 *  @doc("get a private endpoint connection for resource employee")
 *  getPrivateEndpointConnection is EmployeeConnectionOps.Read<Employee>;
 * }
 * ```
 */
@doc(Description)
@armResourceWithParameter(
  CommonTypes.PrivateLinkResourceProperties,
  "privateLinkResources",
  "privateLinkResourceName"
)
@Http.Private.includeInapplicableMetadataInPayload(false)
model PrivateLink<Description extends valueof string = "A private link resource.">
  is CommonTypes.PrivateLinkResource;

/**
 * Operations over private link resources.
 * @template PrivateLinkResourceModel The type of the private link resource. You must declare a private link resource type in your provider namespace.
 * @template ResourceName Optional. The name of the private link resource in this context, by default, this is `{targetResourceName}PrivateLink`.
 *
 * @example
 * ```ts
 * namespace Microsoft.Contoso;
 * model PrivateLink is PrivateLinkResource {}
 * alias EmployeeConnectionOps is PrivateLinks<PrivateLink>;
 * @armResourceOperations
 * interface Employees {
 *  @doc("get a private link for resource employee")
 *  getPrivateLink is EmployeeConnectionOps.Read<Employee>;
 * }
 * ```
 */
interface PrivateLinks<
  PrivateLinkResourceModel extends PrivateLink,
  ResourceName extends valueof string = string("")
> {
  /**
   * @dev List the private links to a resource
   * @template ParentResource the parent resource of the PrivateLink
   * @template Resource Optional. The PrivateLink resource being listed
   * @template BaseParameters Optional. Allows overriding the operation parameters
   * @template ParentName Optional. The name of the parent resource
   * @template ParentFriendlyName Optional. The friendly name of the parent resource
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response for the list operation
   * @template Error Optional. The error response, if non-standard.
   * @template OverrideResourceName Optional. The name of the private link resource being operated on.
   */
  @doc("List {name} PrivateLinks", ParentResource)
  @get
  @autoRoute
  @list
  @listsResource(Resource)
  @segmentOf(PrivateLinkResourceParameter)
  @builtInResourceOperation(ParentResource, Resource, "list", OverrideResourceName)
  @Private.enforceConstraint(ParentResource, Foundations.Resource)
  ListByParent<
    ParentResource extends Foundations.SimpleResource,
    Resource extends PrivateLink = PrivateLinkResourceModel,
    BaseParameters = DefaultBaseParameters<ParentResource>,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<ResourceListResult<Resource>>,
    Error extends {} = ErrorResponse,
    OverrideResourceName extends valueof string = "${ResourceName}"
  > is ArmReadOperation<
    ResourceInstanceParameters<ParentResource, BaseParameters> & Parameters,
    Response,
    Error
  >;

  /**
   * @dev List the private links to a resource - this should only be used for legacy operations
   * @template ParentResource the parent resource of the PrivateLink
   * @template Resource Optional. The PrivateLink resource being listed
   * @template BaseParameters Optional. Allows overriding the operation parameters
   * @template ParentName Optional. The name of the parent resource
   * @template ParentFriendlyName Optional. The friendly name of the parent resource
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response for the list operation
   * @template Error Optional. The error response, if non-standard.
   * @template OverrideResourceName Optional. The name of the private link resource being operated on.
   */
  @Private.legacyType
  @doc("List {name} PrivateLinks", ParentResource)
  @get
  @autoRoute
  @listsResource(Resource)
  @segmentOf(PrivateLinkResourceParameter)
  @builtInResourceOperation(ParentResource, Resource, "list", OverrideResourceName)
  @Private.enforceConstraint(ParentResource, Foundations.Resource)
  ListSinglePageByParent<
    ParentResource extends Foundations.SimpleResource,
    Resource extends PrivateLink = PrivateLinkResourceModel,
    BaseParameters = DefaultBaseParameters<ParentResource>,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<ResourceListResult<Resource>>,
    Error extends {} = ErrorResponse,
    OverrideResourceName extends valueof string = "${ResourceName}"
  > is ArmReadOperation<
    ResourceInstanceParameters<ParentResource, BaseParameters> & Parameters,
    Response,
    Error
  >;

  /**
   * @dev GET the a private link to a particular resource
   * @template ParentResource the parent resource of the PrivateLink
   * @template Resource the PrivateLink resource being read
   * @template BaseParameters Optional. Allows overriding the operation parameters
   * @template Parameters Optional. Additional parameters after the path parameters
   * @template Response Optional. The success response for the read operation
   * @template Error Optional. The error response, if non-standard.
   * @template OverrideResourceName Optional. The name of the private link resource being operated on.
   */
  @autoRoute
  @doc("Get a {name} PrivateLink", ParentResource)
  @get
  @builtInResourceOperation(ParentResource, Resource, "read", OverrideResourceName)
  Read<
    ParentResource extends Foundations.SimpleResource,
    Resource extends PrivateLink = PrivateLinkResourceModel,
    BaseParameters = DefaultBaseParameters<ParentResource>,
    Parameters extends {} = {},
    Response extends {} = ArmResponse<Resource>,
    Error extends {} = ErrorResponse,
    OverrideResourceName extends valueof string = "${ResourceName}"
  > is ArmReadOperation<
    ResourceInstanceParameters<ParentResource, BaseParameters> &
      KeysOf<PrivateLinkResourceParameter> &
      Parameters,
    Response,
    Error
  >;
}
