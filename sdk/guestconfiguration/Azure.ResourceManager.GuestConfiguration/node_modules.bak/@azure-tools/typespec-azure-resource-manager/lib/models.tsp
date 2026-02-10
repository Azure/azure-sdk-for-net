using Http;
using Rest;
using Azure.Core;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Private;

namespace Azure.ResourceManager;

/**
 * Spread this model into ARM resource models to specify resource name parameter for its operations. If `Resource` parameter
 * is specified, the resource name will be properly camel cased and pluralized for `@key` and `@segment`
 * automatically. You can also apply explicit override with `KeyName` and `SegmentName` template parameters.
 *
 * For additional decorators such as @minLength, you can use either augment decorator on `[Resource].name` or passing in a scalar string type with decorators.
 *
 * @template Resource The ARM resource this name parameter is applying to.
 * @template KeyName Override default key name of the resource.
 * @template SegmentName Override default segment name of the resource.
 * @template NamePattern The RegEx pattern of the name. Default is `^[a-zA-Z0-9-]{3,24}$`.
 * @template Type The type of the name property. Default type is string. However you can pass an union with string values.
 *
 * @example
 * ```typespec
 * model Employee is TrackedResource<EmployeeProperties> {
 *  ...ResourceNameParameter<
 *    Resource = Employee,
 *    KeyName = "employeeName",
 *    SegmentName = "employees",
 *    NamePattern = "^[^<>%&:?#/\\\\]+$"
 *  >;
 * }
 * ```
 */
model ResourceNameParameter<
  Resource extends Foundations.SimpleResource,
  KeyName extends valueof string = "",
  SegmentName extends valueof string = "",
  NamePattern extends valueof string = "^[a-zA-Z0-9-]{3,24}$",
  Type extends string = string
> {
  @doc("The name of the {name}", Resource)
  @pattern(NamePattern)
  @defaultResourceKeySegmentName(Resource, KeyName, SegmentName)
  @path
  name: Type;
}

//#region Standard Resource Operation Interfaces
/**
 * Concrete tracked resource types can be created by aliasing this type using a specific property type.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template Properties A model containing the provider-specific properties for this resource
 * @template PropertiesOptional A boolean flag indicating whether the resource `Properties` field is marked as optional or required. Default true is optional and recommended.
 *
 * @example
 * ```typespec
 * model Employee is TrackedResource<EmployeeProperties> {
 *  ...ResourceNameParameter<Employee>
 * }
 * ```
 */
@doc("Concrete tracked resource types can be created by aliasing this type using a specific property type.")
@armResourceInternal(Properties)
@Http.Private.includeInapplicableMetadataInPayload(false)
model TrackedResource<Properties extends {}, PropertiesOptional extends valueof boolean = true>
  extends Foundations.TrackedResource {
  @doc("The resource-specific properties for this resource.")
  @armResourcePropertiesOptionality(PropertiesOptional)
  properties?: Properties;
}

/**
 * Concrete proxy resource types can be created by aliasing this type using a specific property type.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template Properties A model containing the provider-specific properties for this resource
 * @template PropertiesOptional A boolean flag indicating whether the resource `Properties` field is marked as optional or required. Default true is optional and recommended.
 *
 * @example
 * ```typespec
 * model Employee is ProxyResource<EmployeeProperties> {
 *  ...ResourceNameParameter<Employee>;
 * }
 * ```
 */
@doc("Concrete proxy resource types can be created by aliasing this type using a specific property type.")
@armResourceInternal(Properties)
@Http.Private.includeInapplicableMetadataInPayload(false)
model ProxyResource<Properties extends {}, PropertiesOptional extends valueof boolean = true>
  extends Foundations.ProxyResource {
  @doc("The resource-specific properties for this resource.")
  @armResourcePropertiesOptionality(PropertiesOptional)
  properties?: Properties;
}

/**
 * Concrete extension resource types can be created by aliasing this type using a specific property type.
 *
 * See more details on [different Azure Resource Manager resource type here.](https://azure.github.io/typespec-azure/docs/howtos/ARM/resource-type)
 * @template Properties A model containing the provider-specific properties for this resource
 * @template PropertiesOptional A boolean flag indicating whether the resource `Properties` field is marked as optional or required. Default true is optional and recommended.
 *
 * @example
 * ```typespec
 * model PetInstance is ExtensionResource<PetProperties> {
 *  @key
 *  @path
 *  @segment("petInstances")
 *  @pattern("^[a-zA-Z0-9-]{3,24}$")
 *  @visibility(Lifecycle.Read)
 *  name: string;
 * }
 * ```
 */
@extensionResource
@doc("Concrete extension resource types can be created by aliasing this type using a specific property type.")
@armResourceInternal(Properties)
@Http.Private.includeInapplicableMetadataInPayload(false)
model ExtensionResource<Properties extends {}, PropertiesOptional extends valueof boolean = true>
  extends Foundations.ExtensionResource {
  @doc("The resource-specific properties for this resource.")
  @armResourcePropertiesOptionality(PropertiesOptional)
  properties?: Properties;
}
//#region

//#region Standard extraction models

/**
 * Extracts the key (path) parameters from a resource and its parents
 * @template Resource The resource to extract properties from
 */
@copyResourceKeyParameters
model KeysOf<Resource> {}

/**
 * Extracts the key (path) parameters from the parent(s) of the given resource
 * @template Resource The resource to extract properties from
 */
@copyResourceKeyParameters("parent")
model ParentKeysOf<Resource> {}

/**
 * Model describing the provider namespace.
 * @template Resource The resource provided by the namespace.
 */
model ProviderNamespace<Resource extends {}> {
  @path
  @segment("providers")
  @assignProviderNameValue(Resource)
  @doc("The provider namespace for the resource.")
  provider: "Microsoft.ThisWillBeReplaced";
}
//#endregion

//#region Common Azure Resource Manager type definitions

/**
 * Use Azure.Core.armResourceIdentifier<AllowedResourceTypes>
 */
#deprecated "Use Azure.Core.armResourceIdentifier<AllowedResourceTypes> instead."
alias ResourceIdentifier<AllowedResourceTypes extends ArmResourceIdentifierAllowedResource[] = never> = Azure.Core.armResourceIdentifier<AllowedResourceTypes>;

#deprecated "Use ArmResourceIdentifierAllowedResource instead."
alias ResourceIdentifierAllowedResource = ArmResourceIdentifierAllowedResource;

/**
 * Standard terminal provisioning state of resource type. You can include in your
 * custom provision state to avoid duplication and ensure consistency
 *
 * @example
 *
 * ```typespec
 * union FooProvisioningState {
 *   ResourceProvisioningState,  // include standard provisioning states
 *   starting: "starting",
 *   started: "started",
 *   stopping: "stopping",
 *   stopped: "stopped",
 * }
 * ```
 */
@doc("The provisioning state of a resource type.")
@Azure.Core.lroStatus
union ResourceProvisioningState {
  @doc("Resource has been created.")
  Succeeded: "Succeeded",

  @doc("Resource creation failed.")
  Failed: "Failed",

  @doc("Resource creation was canceled.")
  Canceled: "Canceled",

  string,
}

/**
 * Standard resource provisioning state model. If you do not have any custom provisioning state,
 * you can spread this model directly into your resource property model.
 *
 * @example
 *
 * ```typespec
 * model FooProperties {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...DefaultProvisioningStateProperty,
 * }
 * ```
 */
@doc("Contains a default provisioningState property to be spread into resource property types")
model DefaultProvisioningStateProperty {
  @doc("The provisioning state of the resource.")
  @visibility(Lifecycle.Read)
  provisioningState?: ResourceProvisioningState;
}

/**
 * Model representing the standard `extendedLocation` envelope property for a resource.
 * Spread this model into a Resource Model, if the resource supports extended locations
 *
 * @example
 * ```typespec
 * model Employee is TrackedResource<EmployeeProperties> {
 * ...ResourceNameParameter<Employee>;
 * ...ExtendedLocationProperty;
 * }
 * ```
 */
model ExtendedLocationProperty {
  @visibility(Lifecycle.Read, Lifecycle.Create)
  extendedLocation?: Foundations.ExtendedLocation;
}

#deprecated "Please change ManagedServiceIdentity to ManagedServiceIdentityProperty."
alias ManagedServiceIdentity = ManagedServiceIdentityProperty;

/**
 * Model representing the standard `ManagedServiceIdentity` envelope property for a resource.
 * Spread this model into a resource model if the resource supports both system-assigned and user-assigned managed identities.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   ...ResourceNameParameter<Foo>;
 *   ...ManagedServiceIdentityProperty;
 * }
 * ```
 */
@doc("The managed service identities envelope.")
model ManagedServiceIdentityProperty {
  @doc("The managed service identities assigned to this resource.")
  identity?: Foundations.ManagedServiceIdentity;
}

#deprecated "Please change ManagedSystemAssignedIdentity to ManagedSystemAssignedIdentityProperty."
alias ManagedSystemAssignedIdentity = ManagedSystemAssignedIdentityProperty;
/**
 * Model representing the standard `SystemAssignedServiceIdentity` envelope property for a resource.
 * Spread this model into a resource model if the resource supports system-assigned managed identities
 * but does not support user-assigned managed identities.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   ...ResourceNameParameter<Foo>;
 *   ...ManagedSystemAssignedIdentityProperty;
 * }
 * ```
 */
@doc("Managed identity for services that are constrained to system-assigned managed identities.")
model ManagedSystemAssignedIdentityProperty {
  @doc("The managed service identities assigned to this resource.")
  identity?: Foundations.SystemAssignedServiceIdentity;
}

#deprecated "`EntityTag` will be deprecated. Please use `EntityTagProperty` instead."
alias EntityTag = EntityTagProperty;
/**
 * Model used only to spread in the standard `eTag` envelope property for a resource
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...EntityTagProperty;
 * }
 * ```
 */
@doc("The eTag property envelope.")
model EntityTagProperty {
  @doc("If eTag is provided in the response body, it may also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields.")
  @visibility(Lifecycle.Read)
  eTag?: string;
}

#deprecated "`ResourceKind` will be deprecated. Please use `ResourceKindProperty` instead."
alias ResourceKind = ResourceKindProperty;
/**
 * Model representing the standard `kind` envelope property for a resource.
 * Spread this model into a resource model if the resource support ARM `kind`.
 * @template Type The type of the kind property. Default is string. However you can pass a union with string values.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...ResourceKindProperty;
 * }
 * ```
 */
@doc("The resource kind property envelope.")
model ResourceKindProperty<Type extends string = string> {
  @doc("Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value.")
  @pattern("^[-\\w\\._,\\(\\\\\\)]+$")
  @visibility(Lifecycle.Read, Lifecycle.Create)
  kind?: Type;
}

/**
 * Paged response containing resources
 * @template Resource The type of the values returned in the paged response (must be a resource)
 *
 * @example
 * ```typespec
 * op list is ArmResourceActionSync<
 *  Resource = Employee,
 *  Request = void,
 *  Response = ResourceListResult<Employee>
 * >;
 * ```
 */
@doc("The response of a {name} list operation.", Resource)
@friendlyName("{name}ListResult", Resource)
model ResourceListResult<Resource extends Foundations.SimpleResource> is Azure.Core.Page<Resource>;

/**
 * Paged response containing results
 * @template Result The type of the values returned in the paged response
 */
@doc("The custom response of a list operation.")
@friendlyName("{name}ListResult", Result)
model ResourceListCustomResult<Result> {
  /** The items on this page */
  @pageItems
  value: Result[];

  /** The link to the next page of items */
  @nextLink
  nextLink?: string;
}

#deprecated "`ResourcePlan` will be deprecated. Please use `ResourcePlanProperty` instead."
alias ResourcePlan = ResourcePlanProperty;
/**
 * Model representing the standard `plan` envelope property for a resource.
 * Spread this model into a resource Model if the resource supports ARM `plan`.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...ResourcePlanProperty;
 * }
 * ```
 */
@doc("The resource plan property envelope.")
model ResourcePlanProperty {
  @doc("Details of the resource plan.")
  plan?: Plan;
}

#deprecated "`ResourceSku` will be deprecated. Please use `ResourceSkuProperty` instead."
alias ResourceSku = ResourceSkuProperty;
/**
 * Model representing the standard `sku` envelope property for a resource.
 * Spread this model into a resource model if the resource supports standard ARM `sku`.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...ResourceSkuProperty;
 * }
 * ```
 */
@doc("The SKU (Stock Keeping Unit) assigned to this resource.")
model ResourceSkuProperty {
  @doc("The SKU (Stock Keeping Unit) assigned to this resource.")
  sku?: Sku;
}

#deprecated "`ManagedBy` will be deprecated. Please use `ManagedByProperty` instead."
alias ManagedBy = ManagedByProperty;
/**
 * Model representing the standard `managedBy` envelope property for a resource.
 * Spread this model into a resource model if the resource is managed by another entity.
 *
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   // Only have standard Succeeded, Failed, Cancelled states
 *   ...ManagedByProperty;
 * }
 * ```
 */
@doc("The managedBy property envelope.")
model ManagedByProperty {
  @doc("The fully qualified resource ID of the resource that manages this resource. Indicates if this resource is managed by another Azure resource. If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource.")
  managedBy?: string;
}

/** Please use the spread model EncryptionProperty */
alias Encryption = EncryptionProperty;
/**
 * Model used only to spread in the `encryption` envelope property for a resource.
 * @example
 *
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *   ...Encryption;
 * }
 * ```
 */
/** All encryption configuration for a resource. */
model EncryptionProperty {
  /** All encryption configuration for a resource. */
  encryption: EncryptionConfiguration;
}

/**
 * Model representing the standard `zones` envelope property for a resource.
 * Spread this model into a resource Model if the resource supports ARM `zones`.
 *
 * @example
 * ```typespec
 * model Foo is TrackedResource<FooProperties> {
 *  ...AvailabilityZonesProperty;
 * }
 * ```
 */
model AvailabilityZonesProperty {
  /** The availability zones. */
  zones?: string[];
}

//#endregion
