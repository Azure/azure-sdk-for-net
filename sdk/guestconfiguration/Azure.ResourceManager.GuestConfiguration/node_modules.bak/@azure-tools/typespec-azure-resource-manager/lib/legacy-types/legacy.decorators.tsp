using Reflection;

namespace Azure.ResourceManager.Legacy;

/**
 * Route options for an operation
 */
model ArmOperationOptions {
  /** Should a static route be used */
  useStaticRoute?: boolean;

  /** The status route for operations to use */
  route?: string;
}

/** Options for customizing the behavior of a custom azure resource */
model CustomResourceOptions {
  /** Should the resource be marked as an Azure resource */
  isAzureResource?: boolean;
}

/**
 * This decorator is used on resources that do not satisfy the definition of a resource
 * but need to be identified as such.
 * @param options Options for customizing the behavior of the resource
 */
extern dec customAzureResource(target: Model, options?: valueof CustomResourceOptions);

/**
 * Specify an external reference that should be used when emitting this type.
 * @param jsonRef - External reference(e.g. "../../common.json#/definitions/Foo")
 */
extern dec externalTypeRef(entity: Model | ModelProperty, jsonRef: valueof string);

/**
 * Signifies that an operation is an Azure Resource Manager operation
 * and optionally associates the operation with a route template.
 * @param target The operation to associate the model with
 * @param route Optional route to associate with the operation
 */
extern dec armOperationRoute(target: Operation, route?: valueof ArmOperationOptions);

/**
 * Signifies that a Resource is represented using a library type in generated SDKs.
 * @param target The model to that is an external resource
 */
extern dec armExternalType(target: Model);

/**
 * Renames a path parameter in an Azure Resource Manager operation.
 * @param target The operation or interface to modify
 * @param sourceParameterName The name of the parameter to rename
 * @param targetParameterName The new name for the parameter
 */
extern dec renamePathParameter(
  target: Operation,
  sourceParameterName: valueof string,
  targetParameterName: valueof string
);

/**
 * Options for defining a feature and the associated file
 */
model ArmFeatureOptions {
  /** The feature name */
  featureName: string;

  /** The associated file name for the features */
  fileName: string;

  /** The feature description in Swagger */
  description: string;

  /** The feature title in Swagger */
  title?: string;

  /** The feature terms of service in Swagger */
  termsOfService?: string;
}

/**
 * Decorator to define a set of features
 * @param target The service namespace
 * @param features The enum that contains the features
 */
extern dec features(target: Namespace, features: Enum);

/**
 * Decorator to define options for a specific feature
 * @param target The enum member that represents the feature
 * @param options The options for the feature
 */
extern dec featureOptions(target: EnumMember, options: valueof ArmFeatureOptions);

/**
 * Decorator to associate a feature with a model, interface, or namespace
 * @param target The target to associate the feature with
 * @param featureName The feature to associate with the target
 */
extern dec feature(target: Model | Operation | Interface | Namespace, featureName: EnumMember);
