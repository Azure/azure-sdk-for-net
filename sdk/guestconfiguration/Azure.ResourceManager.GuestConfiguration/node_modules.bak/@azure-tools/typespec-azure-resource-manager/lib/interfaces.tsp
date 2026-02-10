using Http;
using Rest;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;

namespace Azure.ResourceManager;

/**
 * This is the interface that implements the standard Azure Resource Manager operation that returns
 * all supported RP operations. You should have exactly one declaration for each
 * Azure Resource Manager service. It implements
 *   GET "/providers/Microsoft.ContosoProviderHub/operations"
 */
interface Operations {
  /**
   * @dev List the operations for the provider.
   */
  @tag("Operations")
  @autoRoute
  @armUpdateProviderNamespace
  @doc("List the operations for the provider")
  @segment("operations")
  @get
  @list
  list(
    ...CommonTypes.ApiVersionParameter,

    @path
    @segment("providers")
    @doc("The provider namespace (this parameter will not show up in operations).")
    provider: "Microsoft.ThisWillBeReplaced",
  ): ArmResponse<OperationListResult> | ErrorResponse;
}

/**
 * @deprecated Use Azure.ResourceManager.TrackedResourceOperations instead
 * A composite interface for resources that include `ResourceInstanceOperations<Resource, Properties>`
 * and `ResourceCollectionOperations<Resource>`. It includes: `GET`, `PUT`, `PATCH`, `DELETE`, ListByParent,
 * ListBySubscription operations. The actual route depends on the resource model.
 * This is the most common API pattern for Tracked Resources to use.
 * @template Resource the ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 * @template BaseParameters The http parameters that are part of the request
 *
 */
#deprecated "Use Azure.ResourceManager.TrackedResourceOperations instead"
interface ResourceOperations<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>
> extends TrackedResourceOperations<Resource, Properties, BaseParameters> {}

/**
 * A composite interface for resources that include `ResourceInstanceOperations<Resource, Properties>`
 * and `ResourceCollectionOperations<Resource>`. It includes: `GET`, `PUT`, `PATCH`, `DELETE`, ListByParent,
 * ListBySubscription operations. The actual route depends on the resource model.
 * This is the most common API pattern for Tracked Resources to use.
 * @template Resource the ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 * @template BaseParameters The http parameters that are part of the request
 *
 */
interface TrackedResourceOperations<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>
>
  extends ResourceInstanceOperations<Resource, Properties, BaseParameters>,
    ResourceCollectionOperations<Resource, BaseParameters> {}

/**
 * A composite interface for Proxy resources that include `ResourceInstanceOperations<Resource, Properties>`
 * and `ResourceListByParent<Resource>`. It includes: `GET`, `PUT`, `PATCH`, `DELETE`, ListByParent operations.
 *
 * The actual route depends on the resource model but would have started with
 *   `/subscriptions/{id}/resourcegroups/{rg}/providers/Microsoft.XXX/...`
 *
 * This is the most common API pattern for Proxy Resources to use.
 * @template Resource the ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
#suppress "deprecated" "This should be deprecated in a future release"
interface ProxyResourceOperations<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
>
  extends ResourceRead<Resource, BaseParameters>,
    ResourceCreate<Resource, BaseParameters>,
    ResourceDelete<Resource, BaseParameters>,
    ResourceListByParent<Resource, BaseParameters> {}

/**
 * A composite interface for Tenant resources that include `ResourceInstanceOperations<Resource, Properties>`
 * and `ResourceListByParent<Resource>`. It includes: `GET`, `PUT`, `PATCH`, `DELETE`, ListByParent operations.
 *
 * The routes are always start at root level:
 *   `/providers/Microsoft.XXX/...`
 *
 * This is the most common API pattern for Tenant Resources to use.
 * @template Resource the ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 */
#suppress "deprecated" "This should be deprecated in a future release"
interface TenantResourceOperations<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model
>
  extends TenantResourceRead<Resource>,
    TenantResourceCreate<Resource>,
    TenantResourceUpdate<Resource, Properties>,
    TenantResourceDelete<Resource>,
    TenantResourceListByParent<Resource> {}

/**
 * A composite interface for resources that have CRUD operations.
 * @template Resource The ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 * @template BaseParameters The http parameters that are part of the request
 * @template PatchModel The model used for PATCH operations
 */
#suppress "deprecated" "This should be deprecated in a future release"
interface ResourceInstanceOperations<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>,
  PatchModel = ResourceUpdateModel<Resource, Properties>
>
  extends ResourceRead<Resource, BaseParameters>,
    ResourceCreate<Resource, BaseParameters>,
    ResourceUpdate<Resource, Properties, BaseParameters>,
    ResourceDelete<Resource, BaseParameters> {}

/**
 * A composite interface for resource collections.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
interface ResourceCollectionOperations<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> extends ResourceListByParent<Resource, BaseParameters>, ResourceListBySubscription<Resource> {}

/**
 * An interface for resources with can be listed by subscription.
 * @template Resource The ArmResource that provides these operations
 */
interface ResourceListBySubscription<Resource extends Foundations.SimpleResource> {
  /**
   * @dev List resources by subscription.
   * @template Resource The ArmResource to list.
   */
  listBySubscription is ArmListBySubscription<Resource>;
}

/**
 * An interface for resources which can be listed by parent.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 * @template ParentName The name of the parent resource
 * @template ParentFriendlyName The friendly name of the parent resource
 */
interface ResourceListByParent<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>,
  ParentName extends valueof string = "",
  ParentFriendlyName extends valueof string = ""
> {
  /**
   * @dev List resources by parent.
   * @template Resource The ArmResource to list.
   * @template BaseParameters The http parameters that are part of the request
   * @template ParentName The name of the parent resource
   * @template ParentFriendlyName The friendly name of the parent resource
   */
  @Private.armRenameListByOperation(Resource, ParentName, ParentFriendlyName, true) // This must come before @armResourceList!
  listByParent is ArmResourceListByParent<Resource, BaseParameters, ParentName, ParentFriendlyName>;
}

/**
 * A composite interface for resources that include a GET operation.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
interface ResourceRead<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Retrieve a resource.
   * @template Resource The ArmResource to retrieve.
   * @template BaseParameters The http parameters that are part of the request
   */
  get is ArmResourceRead<Resource, BaseParameters>;
}

/**
 * A composite interface for resources that include a synchronous create or update operation.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
interface ResourceCreateSync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Create or update a resource using the synchronous call pattern.
   * @template Resource The ArmResource to create or update.
   * @template BaseParameters The http parameters that are part of the request
   */
  createOrUpdate is ArmResourceCreateOrReplaceSync<Resource, BaseParameters>;
}

/**
 * A composite interface for resources that include a long-running create or update operation.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
interface ResourceCreateAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Create or update a resource using the asynchronous call pattern.
   * @template Resource The ArmResource to create or update.
   * @template BaseParameters The http parameters that are part of the request
   */
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Resource, BaseParameters>;
}

/**
 * @dev A composite interface for resources that include a long-running delete operation.
 *      DEPRECATED: Use ResourceDeleteWithoutOkAsync instead
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
#deprecated "This should be deprecated in a future release"
@doc("Delete a resource using the asynchronous call pattern")
interface ResourceDeleteAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Delete a resource using the asynchronous call pattern.
   * @template Resource The ArmResource to delete.
   * @template BaseParameters The http parameters that are part of the request
   */
  delete is ArmResourceDeleteAsync<Resource, BaseParameters>;
}

/**
 * @dev A composite interface for resources that include a synchronous delete operation.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
@doc("Delete a resource using the asynchronous call pattern")
interface ResourceDeleteWithoutOkAsync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Delete a resource using the asynchronous call pattern.
   * @template Resource The ArmResource to delete.
   * @template BaseParameters The http parameters that are part of the request
   */
  delete is ArmResourceDeleteWithoutOkAsync<Resource, BaseParameters>;
}

/**
 * A composite interface for resources that include a synchronous delete operation.
 * @template Resource The ArmResource that provides these operations
 * @template BaseParameters The http parameters that are part of the request
 */
@doc("Delete a resource")
interface ResourceDeleteSync<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Delete a resource using the synchronous call pattern.
   * @template Resource The ArmResource to delete.
   * @template BaseParameters The http parameters that are part of the request
   */
  delete is ArmResourceDeleteSync<Resource, BaseParameters>;
}

/**
 * @dev A composite interface for resources that include a long-running update operation.
 * @template Resource The ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 * @template BaseParameters The http parameters that are part of the request
 */
@doc("Asynchronous resource update")
interface ResourceUpdateAsync<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Update a resource using the asynchronous call pattern.
   * @template Resource The ArmResource to update.
   * @template Properties RP-specific property bag for the resource
   * @template BaseParameters The http parameters that are part of the request
   */
  update is ArmCustomPatchAsync<
    Resource,
    ResourceUpdateModel<Resource, Properties>,
    BaseParameters
  >;
}

/**
 * A composite interface for resources that include a synchronous update operation.
 * @template Resource The ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 * @template BaseParameters The http parameters that are part of the request
 */
@doc("Synchronous resource update")
interface ResourceUpdateSync<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>
> {
  /**
   * @dev Update a resource using the synchronous call pattern.
   * @template Resource The ArmResource to update.
   * @template Properties RP-specific property bag for the resource
   * @template BaseParameters The http parameters that are part of the request
   */
  @patch(#{ implicitOptionality: true })
  update is ArmCustomPatchSync<Resource, ResourceUpdateModel<Resource, Properties>, BaseParameters>;
}

/**
 * A composite interface for resources that includes CRUD operations.
 * @template Resource The ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 */
#suppress "deprecated" "This should be deprecated in a future release"
interface ExtensionResourceInstanceOperations<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model
>
  extends ExtensionResourceRead<Resource>,
    ExtensionResourceCreate<Resource>,
    ExtensionResourceUpdate<Resource, Properties>,
    ExtensionResourceDelete<Resource> {}

/**
 * A composite interface for resource collections that include a paginated list operation.
 * @template Resource The ArmResource that provides these operations
 */
interface ExtensionResourceCollectionOperations<Resource extends Foundations.SimpleResource>
  extends ExtensionResourceList<Resource> {}

/**
 * A composite interface for resources that include CRUD and list operations.
 * @template Resource The ArmResource that provides these operations
 * @template Properties RP-specific property bag for the resource
 */
interface ExtensionResourceOperations<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model
>
  extends ExtensionResourceInstanceOperations<Resource, Properties>,
    ExtensionResourceCollectionOperations<Resource> {}

alias ResourceCreate<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> = ResourceCreateAsync<Resource, BaseParameters>;

alias ResourceUpdate<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model,
  BaseParameters = DefaultBaseParameters<Resource>
> = ResourceUpdateSync<Resource, Properties, BaseParameters>;

#suppress "deprecated" "This should be deprecated in a future release"
alias ResourceDelete<
  Resource extends Foundations.SimpleResource,
  BaseParameters = DefaultBaseParameters<Resource>
> = ResourceDeleteAsync<Resource, BaseParameters>;

alias ProxyResourceUpdate<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model
> = ResourceUpdate<Resource, Properties>;

alias ExtensionResourceRead<Resource extends Foundations.SimpleResource> = ResourceRead<
  Resource,
  ExtensionBaseParameters
>;

alias ExtensionResourceCreate<Resource extends Foundations.SimpleResource> = ResourceCreate<
  Resource,
  ExtensionBaseParameters
>;

alias ExtensionResourceUpdate<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model
> = ResourceUpdate<Resource, Properties, ExtensionBaseParameters>;

#suppress "deprecated" "This should be deprecated in a future release"
alias ExtensionResourceDelete<Resource extends Foundations.SimpleResource> = ResourceDelete<
  Resource,
  ExtensionBaseParameters
>;

alias ExtensionResourceList<Resource extends Foundations.SimpleResource> = ResourceListByParent<
  Resource,
  ExtensionBaseParameters,
  "Extension",
  "parent"
>;

alias TenantResourceRead<Resource extends Foundations.SimpleResource> = ResourceRead<
  Resource,
  TenantBaseParameters
>;

alias TenantResourceCreate<Resource extends Foundations.SimpleResource> = ResourceCreateAsync<
  Resource,
  TenantBaseParameters
>;

#suppress "deprecated" "This should be deprecated in a future release"
alias TenantResourceDelete<Resource extends Foundations.SimpleResource> = ResourceDelete<
  Resource,
  TenantBaseParameters
>;

alias TenantResourceUpdate<
  Resource extends Foundations.SimpleResource,
  Properties extends TypeSpec.Reflection.Model
> = ResourceUpdate<Resource, Properties, TenantBaseParameters>;

alias TenantResourceListByParent<Resource extends Foundations.SimpleResource> = ResourceListByParent<
  Resource,
  TenantBaseParameters,
  "Tenant",
  "tenant"
>;
