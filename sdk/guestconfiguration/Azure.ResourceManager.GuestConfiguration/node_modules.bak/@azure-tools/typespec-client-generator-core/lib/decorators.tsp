using Reflection;

namespace Azure.ClientGenerator.Core;

/**
 * Overrides the generated name for client SDK elements including clients, methods, parameters,
 * unions, models, enums, and model properties.
 *
 * This decorator takes precedence over all other naming mechanisms, including the `name`
 * property in `@client` decorator and default naming conventions.
 *
 * @param target The type you want to rename.
 * @param rename The rename you want applied to the object.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Rename a model
 * ```typespec
 * @clientName("RenamedModel")
 * model TestModel {
 *  prop: string;
 * }
 * ```
 *
 * @example Rename a model property
 * ```typespec
 * model TestModel {
 *  @clientName("renamedProp")
 *  prop: string;
 * }
 * ```
 *
 * @example Rename a parameter
 * ```typespec
 * op example(@clientName("renamedParameter") parameter: string): void;
 * ```
 *
 * @example Rename an operation
 * ```typespec
 * @clientName("nameInClient")
 * op example(): void;
 * ```
 *
 * @example Rename an operation for different language emitters
 * ```typespec
 * @clientName("nameForJava", "java")
 * @clientName("name_for_python", "python")
 * @clientName("nameForCsharp", "csharp")
 * @clientName("nameForJavascript", "javascript")
 * op example(): void;
 * ```
 *
 */
extern dec clientName(target: unknown, rename: valueof string, scope?: valueof string);

/**
 * Whether you want to generate an operation as a convenient method.
 * When applied to a namespace or interface, it affects all operations within that scope unless explicitly overridden.
 * @param target The target operation, namespace, or interface.
 * @param flag Whether to generate the operation as a convenience method or not.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Apply to a single operation
 * ```typespec
 * @convenientAPI(false)
 * op test: void;
 * ```
 *
 * @example Apply to all operations in an interface
 * ```typespec
 * @convenientAPI(false)
 * interface MyOperations {
 *   op test1(): void;
 *   op test2(): void;
 * }
 * ```
 *
 * @example Apply to all operations in a namespace
 * ```typespec
 * @convenientAPI(false)
 * namespace MyService {
 *   op test1(): void;
 *   op test2(): void;
 * }
 * ```
 */
extern dec convenientAPI(
  target: Operation | Namespace | Interface,
  flag?: valueof boolean,
  scope?: valueof string
);

/**
 * Whether you want to generate an operation as a protocol method.
 * When applied to a namespace or interface, it affects all operations within that scope unless explicitly overridden.
 * @param target The target operation, namespace, or interface.
 * @param flag Whether to generate the operation as a protocol method or not.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Apply to a single operation
 * ```typespec
 * @protocolAPI(false)
 * op test: void;
 * ```
 *
 * @example Apply to all operations in an interface
 * ```typespec
 * @protocolAPI(false)
 * interface MyOperations {
 *   op test1(): void;
 *   op test2(): void;
 * }
 * ```
 *
 * @example Apply to all operations in a namespace
 * ```typespec
 * @protocolAPI(false)
 * namespace MyService {
 *   op test1(): void;
 *   op test2(): void;
 * }
 * ```
 */
extern dec protocolAPI(
  target: Operation | Namespace | Interface,
  flag?: valueof boolean,
  scope?: valueof string
);

/**
 * Define the client generated in the client SDK.
 * If there is any `@client` definition or `@operationGroup` definition, then each `@client` is a root client and each `@operationGroup` is a sub client with hierarchy.
 * This decorator cannot be used along with `@clientLocation`. This decorator cannot be used as augmentation.
 * @param target The target namespace or interface that you want to define as a client.
 * @param options Optional configuration for the service.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Basic client definition
 * ```typespec
 * namespace MyService {}
 *
 * @client({service: MyService})
 * interface MyInterface {}
 * ```
 *
 * @example Changing client name
 * ```typespec
 * namespace MyService {}
 *
 * @client({service: MyService, name: "MySpecialClient"})
 * interface MyInterface {}
 * ```
 *
 * @example
 */
extern dec client(target: Namespace | Interface, options?: ClientOptions, scope?: valueof string);

/**
 * Client customization options.
 */
model ClientOptions {
  /**
   * The services that this client is generated for. If not specified, TCGC will look up the first parent namespace decorated with `@service` for the target.
   * The namespace should be decorated with `@service`.
   */
  service?: Namespace | Namespace[];

  /**
   * The name of the client. If not specified, the default name will be `<Name of the target>Client`.
   */
  name?: string;
}

/**
 * Define the sub client generated in the client SDK.
 * If there is any `@client` definition or `@operationGroup` definition, then each `@client` is a root client and each `@operationGroup` is a sub client with hierarchy.
 * This decorator cannot be used along with `@clientLocation`. This decorator cannot be used as augmentation.
 * @param target The target namespace or interface that you want to define as a sub client.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example
 * ```typespec
 * @operationGroup
 * interface MyInterface{}
 * ```
 */
extern dec operationGroup(target: Namespace | Interface, scope?: valueof string);

/**
 * Usage value.
 */
enum Usage {
  /**
   * Used in request
   */
  input: 2,

  /**
   * Used in response
   */
  output: 4,

  /**
   * Used with JSON content type
   */
  json: 256,

  /**
   * Used with XML content type
   */
  xml: 512,
}

/**
 * Add usage for models/enums.
 * A model/enum's default usage info is always calculated by the operations that use it.
 * You can use this decorator to add additional usage info.
 * When setting usage for namespaces,
 * the usage info will be propagated to the models defined in the namespace.
 * If the model has a usage override, the model override takes precedence.
 * For example, with operation definition `op test(): OutputModel`,
 * the model `OutputModel` has default usage `Usage.output`.
 * After adding decorator `@@usage(OutputModel, Usage.input | Usage.json)`,
 * the final usage result for `OutputModel` is `Usage.input | Usage.output | Usage.json`.
 * The usage info for models will be propagated to models' properties,
 * parent models, discriminated sub models.
 * @param target The target type you want to extend usage.
 * @param value The usage info you want to add for this model. It can be a single value of `Usage` enum value or a combination of `Usage` enum values using bitwise OR.
 * For example, `Usage.input | Usage.output | Usage.json`.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Add usage for model
 * ```typespec
 * op test(): OutputModel;
 *
 * // The resolved usage  for `OutputModel` is `Usage.input | Usage.output | Usage.json`
 * @usage(Usage.input | Usage.json)
 * model OutputModel {
 *   prop: string
 * }
 * ```
 *
 * @example Propagation of usage, all usage will be propagated to the parent model, discriminated sub models, and model properties.
 * ```typespec
 * // The resolved usage  for `Fish` is `Usage.input | Usage.output | Usage.json`
 * @discriminator("kind")
 * model Fish {
 *   age: int32;
 * }
 *
 * // The resolved usage  for `Shark` is `Usage.input | Usage.output | Usage.json`
 * @discriminator("sharktype")
 * @usage(Usage.input | Usage.json)
 * model Shark extends Fish {
 *   kind: "shark";
 *   origin: Origin;
 * }
 *
 * // The resolved usage  for `Salmon` is `Usage.output | Usage.json`
 * model Salmon extends Fish {
 *   kind: "salmon";
 * }
 *
 * // The resolved usage  for `SawShark` is `Usage.input | Usage.output | Usage.json`
 * model SawShark extends Shark {
 *   sharktype: "saw";
 * }
 *
 * // The resolved usage  for `Origin` is `Usage.input | Usage.output | Usage.json`
 * model Origin {
 *   country: string;
 *   city: string;
 *   manufacture: string;
 * }
 *
 * @get
 * op getModel(): Fish;
 * ```
 */
extern dec usage(
  target: Model | Enum | Union | Namespace,
  value: EnumMember | Union,
  scope?: valueof string
);

/**
 * Access value.
 */
enum Access {
  /**
   * Open to user
   */
  public: "public",

  /**
   * Hide from user
   */
  internal: "internal",
}

/**
 * Override access for operations, models, enums and model properties.
 * When setting access for namespaces,
 * the access info will be propagated to the models and operations defined in the namespace.
 * If the model has an access override, the model override takes precedence.
 * When setting access for an operation,
 * it will influence the access info for models/enums that are used by this operation.
 * Models/enums that are used in any operations with `@access(Access.public)` will be set to access "public"
 * Models/enums that are only used in operations with `@access(Access.internal)` will be set to access "internal".
 * The access info for models will be propagated to models' properties,
 * parent models, discriminated sub models.
 * The override access should not be narrower than the access calculated by operation,
 * and different override access should not conflict with each other,
 * otherwise a warning will be added to the diagnostics list.
 * Model property's access will default to public unless there is an override.
 * @param target The target type you want to override access info.
 * @param value The access info you want to set for this model or operation. It should be one of the `Access` enum values, either `Access.public` or `Access.internal`.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Set access
 * ```typespec
 * // Access.internal
 * @access(Access.internal)
 * model ModelToHide {
 *   prop: string;
 * }
 * // Access.internal
 * @access(Access.internal)
 * op test: void;
 * ```
 * @example Access propagation
 * ```typespec
 * // Access.internal
 * @discriminator("kind")
 * model Fish {
 *   age: int32;
 * }
 *
 * // Access.internal
 * @discriminator("sharktype")
 * model Shark extends Fish {
 *   kind: "shark";
 *   origin: Origin;
 * }
 *
 * // Access.internal
 * model Salmon extends Fish {
 *   kind: "salmon";
 * }
 *
 * // Access.internal
 * model SawShark extends Shark {
 *   sharktype: "saw";
 * }
 *
 * // Access.internal
 * model Origin {
 *   country: string;
 *   city: string;
 *   manufacture: string;
 * }
 *
 * // Access.internal
 * @get
 * @access(Access.internal)
 * op getModel(): Fish;
 * ```
 * @example Access influence from operation
 * ```typespec
 * // Access.internal
 * model Test1 {
 * }
 *
 * // Access.internal
 * @access(Access.internal)
 * @route("/func1")
 * op func1(
 *   @body body: Test1
 * ): void;
 *
 * // Access.public
 * model Test2 {
 * }
 *
 * // Access.public
 * @route("/func2")
 * op func2(
 *   @body body: Test2
 * ): void;
 *
 * // Access.public
 * model Test3 {
 * }
 *
 * // Access.public
 * @access(Access.public)
 * @route("/func3")
 * op func3(
 *   @body body: Test3
 * ): void;
 *
 * // Access.public
 * model Test4 {
 * }
 *
 * // Access.internal
 * @access(Access.internal)
 * @route("/func4")
 * op func4(
 *   @body body: Test4
 * ): void;
 *
 * // Access.public
 * @route("/func5")
 * op func5(
 *   @body body: Test4
 * ): void;
 *
 * // Access.public
 * model Test5 {
 * }
 *
 * // Access.internal
 * @access(Access.internal)
 * @route("/func6")
 * op func6(
 *   @body body: Test5
 * ): void;
 *
 * // Access.public
 * @route("/func7")
 * op func7(
 *   @body body: Test5
 * ): void;
 *
 * // Access.public
 * @access(Access.public)
 * @route("/func8")
 * op func8(
 *   @body body: Test5
 * ): void;
 * ```
 */
extern dec access(
  target: ModelProperty | Model | Operation | Enum | Union | Namespace,
  value: EnumMember,
  scope?: valueof string
);

/**
 * Customize a method's signature in the generated client SDK.
 * Currently, only parameter signature customization is supported.
 * This decorator allows you to specify a different method signature for the client SDK than the original definition.
 * @param target: The target operation that you want to override.
 * @param override: The override method definition that specifies the exact client method you want
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Customize parameters into an option bag
 * ```typespec
 * // main.tsp
 * @service
 * namespace MyService;
 *
 * op myOperation(foo: string, bar: string): void; // by default, we generate the method signature as `op myOperation(foo: string, bar: string)`;
 *
 * // client.tsp
 * namespace MyCustomizations;
 *
 * model Params {
 *  foo: string;
 *  bar: string;
 * }
 *
 * op myOperationCustomization(params: MyService.Params): void;
 *
 * @@override(MyService.myOperation, myOperationCustomization); // method signature is now `op myOperation(params: Params)`
 * ```
 *
 * @example Customize a parameter to be required
 * ```typespec
 * // main.tsp
 * @service
 * namespace MyService;
 *
 * op myOperation(foo: string, bar?: string): void; // by default, we generate the method signature as `op myOperation(foo: string, bar?: string)`;
 *
 * // client.tsp
 * namespace MyCustomizations;
 *
 * op myOperationCustomization(foo: string, bar: string): void;
 *
 * @@override(MyService.myOperation, myOperationCustomization)
 *
 * // method signature is now `op myOperation(params: Params)` just for csharp // method signature is now `op myOperation(foo: string, bar: string)`
 * ```
 */
extern dec override(target: Operation, override: Operation, scope?: valueof string);

/**
 * Whether a model needs the custom JSON converter, this is only used for backward compatibility for csharp.
 * @param target The target model that you want to set the custom JSON converter.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example
 * ```typespec
 * @useSystemTextJsonConverter
 * model MyModel {
 *   prop: string;
 * }
 * ```
 */
extern dec useSystemTextJsonConverter(target: Model, scope?: valueof string);

/**
 * InitializedBy value.
 */
enum InitializedBy {
  /**
   * The client could be initialized individually.
   */
  individually: 1,

  /**
   * The client could be initialized by parent client.
   */
  parent: 2,
}

/**
 * Allows customization of how clients are initialized in the generated SDK.
 * By default, the root client is initialized independently, while sub clients are initialized through their parent client.
 * Initialization parameters typically include endpoint, credential, and API version.
 * With `@clientInitialization` decorator, you can elevate operation level parameters to client level, and set how the client is initialized.
 * This decorator can be combined with `@paramAlias` decorator to change the parameter name in client initialization.
 * @param target The target client that you want to customize client initialization for.
 * @param options The options for client initialization. You can use `ClientInitializationOptions` model to set the options.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Add client initialization parameters
 * ```typespec
 * // main.tsp
 * namespace MyService;
 *
 * op upload(blobName: string): void;
 * op download(blobName: string): void;
 *
 * // client.tsp
 * namespace MyCustomizations;
 * model MyServiceClientOptions {
 *   blobName: string;
 * }
 *
 * @@clientInitialization(MyService, {parameters: MyServiceClientOptions})
 * // The generated client will have `blobName` in its initialization method. We will also
 * // elevate the existing `blobName` parameter from method level to client level.
 * ```
 */
extern dec clientInitialization(
  target: Namespace | Interface,
  options: ClientInitializationOptions,
  scope?: valueof string
);

/**
 * Client initialization customization options.
 */
model ClientInitializationOptions {
  /**
   * Redefine the client initialization parameters you would like to add to the client. All the model properties should have corresponding operation level parameters.
   * By default, we apply endpoint, credential, and API version parameters. If you specify a parameters model, we will append the properties of the model to the parameters list of the client initialization.
   */
  parameters?: Model;

  /**
   * Determines how the client can be initialized. Use `InitializedBy` enum to set the value. The value can be `InitializedBy.individually`, `InitializedBy.parent` or `InitializedBy.individually | InitializedBy.parent`.
   */
  initializedBy?: EnumMember | Union;
}

/**
 * Alias the name of a client parameter to a different name. This permits you to have a different name for the parameter in client initialization and the original parameter in the operation.
 * @param target The target model property that you want to alias.
 * @param paramAlias The alias name you want to apply to the target model property.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Elevate an operation parameter to client level and alias it to a different name
 * ```typespec
 * // main.tsp
 * namespace MyService;
 *
 * op upload(blobName: string): void;
 *
 * // client.tsp
 * namespace MyCustomizations;
 * model MyServiceClientOptions {
 *   blob: string;
 * }
 *
 * @@clientInitialization(MyService, MyServiceClientOptions)
 * @@paramAlias(MyServiceClientOptions.blob, "blobName")
 *
 * // The generated client will have `blobName` in it. We will also
 * // elevate the existing `blob` parameter to the client level.
 * ```
 */
extern dec paramAlias(target: ModelProperty, paramAlias: valueof string, scope?: valueof string);

/**
 * Changes the namespace of a client, model, enum or union generated in the client SDK.
 * By default, the client namespace for them will follow the TypeSpec namespace.
 * @param target The type you want to change the namespace for.
 * @param rename The rename you want applied to the object
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Change a namespace to a different name
 * ```typespec
 * @clientNamespace("ContosoClient")
 * namespace Contoso;
 * ```
 *
 * @example Move a model to a different namespace
 * ```typespec
 * @clientNamespace("ContosoClient.Models")
 * model Test {
 *  prop: string;
 * }
 * ```
 */
extern dec clientNamespace(
  target: Namespace | Interface | Model | Enum | Union,
  rename: valueof string,
  scope?: valueof string
);

/**
 * Represents an external type that can be used in alternate type definitions.
 */
model ExternalType {
  /**
   * The identity of the external type. For example, `pystac.Collection`
   */
  identity: string;

  /**
   * The package that exports the external type. For example, `pystac`
   */
  package?: string;

  /**
   * The minimum version of the package to use for your external type. For example, `1.13.0`
   */
  minVersion?: string;
}

/**
 * Set an alternate type for a model property, Scalar, Model, Enum, Union, or function parameter. Note that `@encode` will be overridden by the one defined in the alternate type.
 * When the source type is `Scalar`, the alternate type must be `Scalar`.
 * The replaced type could be a type defined in the TypeSpec or an external type declared by type identity, package that export the type and package version.
 * @param target The source type to which the alternate type will be applied.
 * @param alternate The alternate type to apply to the target. Can be a TypeSpec type or an ExternalType.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 * @example Change a model property to a different type
 * ```typespec
 * model Foo {
 *    date: utcDateTime;
 * }
 * @@alternateType(Foo.date, string);
 * ```
 *
 * @example Change a Scalar type to a different type
 * ```typespec
 * scalar storageDateTime extends utcDateTime;
 * @@alternateType(storageDateTime, string, "python");
 * ```
 *
 * @example Change a function parameter to a different type
 * ```typespec
 * op test(@param @alternateType(string) date: utcDateTime): void;
 * ```
 *
 * @example Change a model property to a different type with language specific alternate type
 * ```typespec
 * model Test {
 *   @alternateType(unknown)
 *   thumbprint?: string;
 *
 *   @alternateType(AzureLocation[], "csharp")
 *   locations: string[];
 * }
 * ```
 *
 * @example Use external type for DFE case
 * ```typespec
 * @alternateType({
 *   identity: "Azure.Core.Expressions.DataFactoryExpression",
 * }, "csharp")
 * union Dfe<T> {
 *   T,
 *   DfeExpression
 * }
 * ```
 *
 * @example Use external type with package information
 * ```typespec
 * @alternateType({
 *   identity: "pystac.Collection",
 *   package: "pystac",
 *   minVersion: "1.13.0",
 * }, "python")
 * model ItemCollection {
 *   // ... properties
 * }
 * ```
 */
extern dec alternateType(
  target: ModelProperty | Scalar | Model | Enum | Union,
  alternate: unknown | ExternalType,
  scope?: valueof string
);

/**
 * Define the scope of an operation or model property.
 * By default, the element will be applied to all language emitters.
 * This decorator allows you to omit the element from certain languages or apply it to specific languages.
 * @param target The target operation or model property that you want to scope.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Omit an operation from a specific language
 * ```typespec
 * @scope("!csharp")
 * op test: void;
 * ```
 *
 * @example Apply an operation to specific languages
 * ```typespec
 * @scope("go")
 * op test: void;
 * ```
 *
 * @example Apply a model property to specific languages
 * ```typespec
 * model TestModel {
 *   @scope("csharp")
 *   csharpOnlyProp: string;
 * }
 * ```
 */
extern dec scope(target: Operation | ModelProperty, scope?: valueof string);

/**
 * Specify whether a parameter is an API version parameter or not.
 * By default, we detect an API version parameter by matching the parameter name with `api-version` or `apiversion`, or if the type is referenced by the `@versioned` decorator.
 * Since API versions are a client parameter, we will also elevate this parameter up onto the client.
 * This decorator allows you to explicitly specify whether a parameter should be treated as an API version parameter or not.
 * @param target The target parameter that you want to mark as an API version parameter.
 * @param value If true, we will treat this parameter as an api-version parameter. If false, we will not. Default is true.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Mark a parameter as an API version parameter
 * ```typespec
 * namespace Contoso;
 *
 * op test(
 *   @apiVersion
 *   @header("x-ms-version")
 *   version: string
 * ): void;
 * ```
 *
 * @example Mark a parameter as not presenting an API version parameter
 * ```typespec
 * namespace Contoso;
 * op test(
 *   @apiVersion(false)
 *   @query
 *   api-version: string
 * ): void;
 * ```
 */
extern dec apiVersion(target: ModelProperty, value?: valueof boolean, scope?: valueof string);

/**
 * Specify additional API versions that the client can support. These versions should include those defined by the service's versioning configuration.
 * This decorator is useful for extending the API version enum exposed by the client.
 * It is particularly beneficial when generating a complete API version enum without requiring the entire specification to be annotated with versioning decorators, as the generation process does not depend on versioning details.
 * @param target The target client for which you want to define additional API versions.
 * @param value If true, we will treat this parameter as an api-version parameter. If false, we will not. Default is true.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Add additional API versions to a client
 * ```typespec
 * // main.tsp
 * @versioned(Versions)
 * namespace Contoso {
 *  enum Versions { v4, v5 }
 * }
 *
 * // client.tsp
 *
 * enum ClientApiVersions { v1, v2, v3, ...Contoso.Versions }
 *
 * @@clientApiVersions(Contoso, ClientApiVersions)
 * ```
 */
extern dec clientApiVersions(target: Namespace, value: Enum, scope?: valueof string);

/**
 * Indicates that a model property of type `string` or a `Scalar` type derived from `string` should be deserialized as `null` when its value is an empty string (`""`).
 * @param target The target type that you want to apply this deserialization behavior to.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example
 * ```typespec
 *
 * model MyModel {
 *   scalar stringlike extends string;
 *
 *   @deserializeEmptyStringAsNull
 *   prop: string;
 *
 *   @deserializeEmptyStringAsNull
 *   prop: stringlike;
 * }
 * ```
 */
extern dec deserializeEmptyStringAsNull(target: ModelProperty, scope?: valueof string);

/**
 * Indicates that a HEAD operation should be modeled as Response<bool>.
 * 404 will not raise an error, instead the service method will return `false`.
 * 2xx will return `true`. Everything else will still raise an error.
 * @param target The target operation that you want to apply this behavior to.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example
 * ```typespec
 * @responseAsBool
 * @head
 * op headOperation(): void;
 * ```
 */
extern dec responseAsBool(target: Operation, scope?: valueof string);

/**
 * Change the operation location in the client. If the target client is not defined, use `string` to indicate a new client name. For this usage, the decorator cannot be used along with `@client` or `@operationGroup` decorators.
 * Change the parameter location to operation or client. For this usage, the decorator cannot be used in the parameter defined in  `@clientInitialization` decorator.
 * @param source The operation to change location for.
 * @param target The target `Namespace`, `Interface` or a string which can indicate the client.
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 * 
 * @example Move to existing sub client
 * ```typespec
 * @service
 * namespace MoveToExistingSubClient;
 * 
 * interface UserOperations {
 *   @route("/user")
 *   @get
 *   getUser(): void;

 *   @route("/user")
 *   @delete
 *   @clientLocation(AdminOperations)
 *   deleteUser(): void; // This operation will be moved to AdminOperations sub client.
 * }

 * interface AdminOperations {
 *   @route("/admin")
 *   @get
 *   getAdminInfo(): void;
 * }
 * ```
 * 
 * @example Move to new sub client
 * ```typespec
 * @service
 * namespace MoveToNewSubClient;
 * 
 * interface ProductOperations {
 *   @route("/products")
 *   @get
 *   listProducts(): void;
 *
 *   @route("/products/archive")
 *   @post
 *   @clientLocation("ArchiveOperations")
 *   archiveProduct(): void; // This operation will be moved to a new sub client named ArchiveOperations.
 * }
 * ```
 * 
 * @example Move operation to root client
 * ```typespec
 * @service
 * namespace MoveToRootClient;
 * 
 * interface ResourceOperations {
 *   @route("/resource")
 *   @get
 *   getResource(): void;
 * 
 *   @route("/health")
 *   @get
 *   @clientLocation(MoveToRootClient)
 *   getHealthStatus(): void; // This operation will be moved to the root client of MoveToRootClient namespace.
 * }
 *
 * ```
 *
 * @example Move parameter from operation to client
 * ```typespec
 * @service
 * namespace MyClient;
 * 
 * getHealthStatus(
 *   @clientLocation(MyClient) // This parameter will be moved to the `.clientInitialization` parameters of `MyClient`. It will not appear on the operation-level.
 *   clientId: string
 * ): void;
 * ```
 * 
 * @example Move parameter from client to operation
 * ```typespec
 * // client.tsp
 * 
 * @@clientLocation(CommonTypes.SubscriptionIdParameter.subscriptionId, get); // This will keep the `subscriptionId` parameter on the operation level instead of applying TCGC's default logic of elevating `subscriptionId` to client.
 * ```
 */
extern dec clientLocation(
  source: Operation | ModelProperty,
  target: Interface | Namespace | Operation | (valueof string),
  scope?: valueof string
);

/**
 * Defines how client documentation should be applied
 */
enum DocumentationMode {
  /**
   * Append client documentation to the existing doc
   */
  append: "append",

  /**
   * Replace the existing doc with client documentation
   */
  replace: "replace",
}

/**
 * Override documentation for a type in client libraries. This allows you to
 * provide client-specific documentation that differs from the original documentation.
 * @param target The target type (operation, model, enum, etc.) for which you want to apply client-specific documentation.
 * @param documentation The client-specific documentation to apply
 * @param mode Specifies how to apply the documentation (append or replace)
 * @param scope Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.
 * You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python.
 *
 * @example Replacing documentation
 * ```typespec
 * @doc("This is service documentation")
 * @clientDoc("This is client-specific documentation", DocumentationMode.replace)
 * op myOperation(): void;
 * ```
 *
 * @example Appending documentation
 * ```typespec
 * @doc("This is service documentation.")
 * @clientDoc("This additional note is for client libraries only.", DocumentationMode.append)
 * model MyModel {
 *   prop: string;
 * }
 * ```
 *
 * @example Language-specific documentation
 * ```typespec
 * @doc("This is service documentation")
 * @clientDoc("Python-specific documentation", DocumentationMode.replace, "python")
 * @clientDoc("JavaScript-specific documentation", DocumentationMode.replace, "javascript")
 * op myOperation(): void;
 * ```
 */
extern dec clientDoc(
  target: unknown,
  documentation: valueof string,
  mode: EnumMember,
  scope?: valueof string
);
