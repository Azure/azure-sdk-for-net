import "../dist/src/private.decorators.js";

namespace Azure.ResourceManager.Private;

using Reflection;

/**
 * Update the Azure Resource Manager provider namespace for a given entity.
 */
extern dec armUpdateProviderNamespace(target: Reflection.Operation);

/**
 * @param resource Resource model
 */
extern dec assignProviderNameValue(target: ModelProperty, resource: Model);

/**
 * @param resource Resource model
 */
extern dec assignUniqueProviderNameValue(target: ModelProperty, resource: Model);

/**
 * This decorator is used to identify Azure Resource Manager resource types and extract their
 * metadata.  It is *not* meant to be used directly by a spec author, it instead
 * gets implicitly applied when the spec author defines a model type in this form:
 *
 *   `model Server is TrackedResource<ServerProperties>;`
 *
 * The `TrackedResource<Resource>` type (and other associated base types) use the
 * `@armResource` decorator, so it also gets applied to the type which absorbs the
 * `TrackedResource<Resource>` definition by using the `is` keyword.
 *
 * @param properties Azure Resource Manager resource properties
 */
extern dec armResourceInternal(target: Model, properties: Model);

/**
 * This decorator identifies Azure Resource Manager resource types that do not define
 * the name identifier parameter and type
 * @param target Azure Resource Manager resource type
 * @param properties Azure Resource Manager resource properties
 * @param type The resource type name, e.g. "virtualMachines"
 * @param nameParameter The name of the resource name parameter, e.g. "virtualMachineName"
 */
extern dec armResourceWithParameter(
  target: Model,
  properties: Model,
  type: valueof string,
  nameParameter: valueof string
);

/**
 * Omit a property in the target model.
 * @internal
 * @param propertyName Name of the property to omit
 */
extern dec omitIfEmpty(target: Model, propertyName: valueof string);

/**
 * @param propertyName Name of the property to omit
 */
extern dec resourceBaseParametersOf(target: Model, propertyName: Model);
/**
 * @param values Values
 */
extern dec resourceParameterBaseFor(target: ModelProperty, values: unknown[]);

/**
 * Provides default name decoration on resource name property with
 * camelcased and pluralized key and segment name
 */
extern dec defaultResourceKeySegmentName(
  target: ModelProperty,
  armResource: Model,
  keyName: valueof string,
  segment: valueof string
);

/**
 * Provides strict contraint type check.
 *
 * Due to TypeSpec language and all optional properties of `Foundations.Resource`,
 * the `Resource extends Foundations.SimpleResource` on many of the standard ARM templates is
 * essentially equal to `Resource extends {}` and does not enforce the containt.
 *
 * Note, this is intended for internal use only for now.
 */
extern dec enforceConstraint(target: Operation | Model, sourceType: Model, constraintType: Model);

/**
 * This decorator is used to identify Azure Resource Manager resource. In generated
 * swagger definition, it will be marked with `x-ms-azure-resource`.
 *
 * It is *not* meant to be used directly by a spec author,
 */
extern dec azureResourceBase(target: Model);

/**
 * Marks the operation as being a collection action
 * @param resourceType Resource
 * @param parentTypeName: Parent type name.
 * @param parentFriendlyTypeName Friendly name for parent.
 * @param applyOperationRename If true, apply both doc and operation name update
 */
extern dec armRenameListByOperation(
  target: Operation,
  resourceType: Model,
  parentTypeName?: valueof string,
  parentFriendlyTypeName?: valueof string,
  applyOperationRename?: valueof boolean
);

/**
 * Please DO NOT USE in RestAPI specs.
 * This decorator is used to adjust optionality on ARM Resource's `properties` field for brownfield service conversion.
 */
extern dec armResourcePropertiesOptionality(target: ModelProperty, isOptional: valueof boolean);

/** designates a parameter as an explicit bodyRoot and sets the optionality of the parameter */
extern dec armBodyRoot(target: ModelProperty, isOptional: valueof boolean);

/** designates a type as a legacy type and emits a warning diagnostic when used */
extern dec legacyType(target: Model | Operation | Interface | Scalar);

/** Determines the built-in parent of a base resource
 * @param parentType The parent type of the resource (Subscription, ResourceGroup, Tenant, Extension)
 */
extern dec resourceParentType(
  target: Model,
  parentType: valueof "Subscription" | "ResourceGroup" | "Tenant" | "Extension"
);

/**
 * Marks a resource operation with the associated resource, operation type, and name. If no name is provided, the name is calculated by resource type.
 * @param target The operation to associate the resourceType with
 * @param resourceType The resource model
 * @param operationType The type of operation being performed
 * @param resourceName Optional. The name of the resource. If not provided, the resource type will be used
 */
extern dec legacyResourceOperation(
  target: Operation,
  resourceType: Model,
  operationType: valueof
    | "read"
    | "createOrUpdate"
    | "update"
    | "delete"
    | "list"
    | "action"
    | "checkExistence",
  resourceName?: valueof string
);

/**
 * Marks an extension resource operation with the associated resource, operation type, and name. If no name is provided, the name is calculated by resource type.
 * @param target The operation to associate the resourceType with
 * @param targetResourceType The resource model for the target resource
 * @param extensionResourceType The resource model for the extension resource
 * @param operationType The type of operation being performed
 * @param resourceName Optional. The name of the resource. If not provided, the scope and resource name will be used
 */
extern dec extensionResourceOperation(
  target: Operation,
  targetResourceType: Model,
  extensionResourceType: Model,
  operationType: valueof
    | "read"
    | "createOrUpdate"
    | "update"
    | "delete"
    | "list"
    | "action"
    | "checkExistence",
  resourceName?: valueof string
);

/**
 * Marks an extension resource operation with the associated resource, operation type, and name. If no name is provided, the name is calculated by resource type.
 * @param target The operation to associate the resourceType with
 * @param targetResourceType The resource model for the target resource
 * @param extensionResourceType The resource model for the extension resource
 * @param operationType The type of operation being performed
 * @param resourceName Optional. The name of the resource. If not provided, the scope and resource name will be used
 */
extern dec builtInResourceOperation(
  target: Operation,
  parentResourceType: Model,
  builtInResourceType: Model,
  operationType: valueof
    | "read"
    | "createOrUpdate"
    | "update"
    | "delete"
    | "list"
    | "action"
    | "checkExistence",
  resourceName?: valueof string
);

/**
 * Marks a resource operation with the associated resource, operation type, and name. If no name is provided, the name is calculated by resource type.
 * @param target The operation to associate the resourceType with
 * @param resourceType The resource model
 * @param operationType The type of operation being performed
 * @param resourceName Optional. The name of the resource. If not provided, the resource type will be used
 */
extern dec legacyExtensionResourceOperation(
  target: Operation,
  resourceType: Model,
  operationType: valueof
    | "read"
    | "createOrUpdate"
    | "update"
    | "delete"
    | "list"
    | "action"
    | "checkExistence",
  resourceName?: valueof string
);

/**
 * Validates that the specified common-types version is valid for the given resource type.
 * @param target The resource model
 * @param version The common-types version
 * @param resourceName The name of the resource
 */
extern dec validateCommonTypesVersionForResource(
  target: Model,
  version: valueof string,
  resourceName: valueof string
);
