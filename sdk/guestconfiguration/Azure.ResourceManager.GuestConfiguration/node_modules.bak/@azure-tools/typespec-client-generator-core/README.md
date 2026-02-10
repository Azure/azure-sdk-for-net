# @azure-tools/typespec-client-generator-core

TypeSpec Data Plane Generation library

## Install

```bash
npm install @azure-tools/typespec-client-generator-core
```

## Emitter usage

1. Via the command line

```bash
tsp compile . --emit=@azure-tools/typespec-client-generator-core
```

2. Via the config

```yaml
emit:
  - "@azure-tools/typespec-client-generator-core"
```

The config can be extended with options as follows:

```yaml
emit:
  - "@azure-tools/typespec-client-generator-core"
options:
  "@azure-tools/typespec-client-generator-core":
    option: value
```

## Emitter options

### `emitter-output-dir`

**Type:** `absolutePath`

Defines the emitter output directory. Defaults to `{output-dir}/@azure-tools/typespec-client-generator-core`
See [Configuring output directory for more info](https://typespec.io/docs/handbook/configuration/configuration/#configuring-output-directory)

### `emitter-name`

**Type:** `string`

Set `emitter-name` to output TCGC code models for specific language's emitter.

### `generate-protocol-methods`

**Type:** `boolean`

When set to `true`, the emitter will generate low-level protocol methods for each service operation if `@protocolAPI` is not set for an operation. Default value is `true`.

### `generate-convenience-methods`

**Type:** `boolean`

When set to `true`, the emitter will generate convenience methods for each service operation if `@convenientAPI` is not set for an operation. Default value is `true`.

### `api-version`

**Type:** `string`

Use this flag if you would like to generate the sdk only for a specific version. Default value is the latest version. Also accepts values `latest` and `all`.

### `license`

**Type:** `object`

License information for the generated client code.

### `examples-dir`

**Type:** `string`

Specifies the directory where the emitter will look for example files. If the flag isn’t set, the emitter defaults to using an `examples` directory located at the project root.

### `namespace`

**Type:** `string`

Specifies the namespace you want to override for namespaces set in the spec. With this config, all namespace for the spec types will default to it.

## Usage

Add the following in `tspconfig.yaml`:

```yaml
linter:
  extends:
    - "@azure-tools/typespec-client-generator-core/all"
```

## RuleSets

Available ruleSets:

- `@azure-tools/typespec-client-generator-core/all`
- `@azure-tools/typespec-client-generator-core/best-practices:csharp`

## Rules

| Name                                                                                                                                                                                      | Description                                                             |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| [`@azure-tools/typespec-client-generator-core/require-client-suffix`](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/rules/require-client-suffix)   | Client names should end with 'Client'.                                  |
| [`@azure-tools/typespec-client-generator-core/property-name-conflict`](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/rules/property-name-conflict) | Avoid naming conflicts between a property and a model of the same name. |
| [`@azure-tools/typespec-client-generator-core/no-unnamed-types`](https://azure.github.io/typespec-azure/docs/libraries/typespec-client-generator-core/rules/no-unnamed-types)             | Requires types to be named rather than defined anonymously or inline.   |

## Decorators

### Azure.ClientGenerator.Core

- [`@access`](#@access)
- [`@alternateType`](#@alternatetype)
- [`@apiVersion`](#@apiversion)
- [`@client`](#@client)
- [`@clientApiVersions`](#@clientapiversions)
- [`@clientDoc`](#@clientdoc)
- [`@clientInitialization`](#@clientinitialization)
- [`@clientLocation`](#@clientlocation)
- [`@clientName`](#@clientname)
- [`@clientNamespace`](#@clientnamespace)
- [`@convenientAPI`](#@convenientapi)
- [`@deserializeEmptyStringAsNull`](#@deserializeemptystringasnull)
- [`@operationGroup`](#@operationgroup)
- [`@override`](#@override)
- [`@paramAlias`](#@paramalias)
- [`@protocolAPI`](#@protocolapi)
- [`@responseAsBool`](#@responseasbool)
- [`@scope`](#@scope)
- [`@usage`](#@usage)
- [`@useSystemTextJsonConverter`](#@usesystemtextjsonconverter)

#### `@access`

Override access for operations, models, enums and model properties.
When setting access for namespaces,
the access info will be propagated to the models and operations defined in the namespace.
If the model has an access override, the model override takes precedence.
When setting access for an operation,
it will influence the access info for models/enums that are used by this operation.
Models/enums that are used in any operations with `@access(Access.public)` will be set to access "public"
Models/enums that are only used in operations with `@access(Access.internal)` will be set to access "internal".
The access info for models will be propagated to models' properties,
parent models, discriminated sub models.
The override access should not be narrower than the access calculated by operation,
and different override access should not conflict with each other,
otherwise a warning will be added to the diagnostics list.
Model property's access will default to public unless there is an override.

```typespec
@Azure.ClientGenerator.Core.access(value: EnumMember, scope?: valueof string)
```

##### Target

The target type you want to override access info.
`ModelProperty | Model | Operation | Enum | Union | Namespace`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| value | `EnumMember`     | The access info you want to set for this model or operation. It should be one of the `Access` enum values, either `Access.public` or `Access.internal`.                                                                                                    |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Set access

```typespec
// Access.internal
@access(Access.internal)
model ModelToHide {
  prop: string;
}
// Access.internal
@access(Access.internal)
op test: void;
```

###### Access propagation

```typespec
// Access.internal
@discriminator("kind")
model Fish {
  age: int32;
}

// Access.internal
@discriminator("sharktype")
model Shark extends Fish {
  kind: "shark";
  origin: Origin;
}

// Access.internal
model Salmon extends Fish {
  kind: "salmon";
}

// Access.internal
model SawShark extends Shark {
  sharktype: "saw";
}

// Access.internal
model Origin {
  country: string;
  city: string;
  manufacture: string;
}

// Access.internal
@get
@access(Access.internal)
op getModel(): Fish;
```

###### Access influence from operation

```typespec
// Access.internal
model Test1 {}

// Access.internal
@access(Access.internal)
@route("/func1")
op func1(@body body: Test1): void;

// Access.public
model Test2 {}

// Access.public
@route("/func2")
op func2(@body body: Test2): void;

// Access.public
model Test3 {}

// Access.public
@access(Access.public)
@route("/func3")
op func3(@body body: Test3): void;

// Access.public
model Test4 {}

// Access.internal
@access(Access.internal)
@route("/func4")
op func4(@body body: Test4): void;

// Access.public
@route("/func5")
op func5(@body body: Test4): void;

// Access.public
model Test5 {}

// Access.internal
@access(Access.internal)
@route("/func6")
op func6(@body body: Test5): void;

// Access.public
@route("/func7")
op func7(@body body: Test5): void;

// Access.public
@access(Access.public)
@route("/func8")
op func8(@body body: Test5): void;
```

#### `@alternateType`

Set an alternate type for a model property, Scalar, Model, Enum, Union, or function parameter. Note that `@encode` will be overridden by the one defined in the alternate type.
When the source type is `Scalar`, the alternate type must be `Scalar`.
The replaced type could be a type defined in the TypeSpec or an external type declared by type identity, package that export the type and package version.

```typespec
@Azure.ClientGenerator.Core.alternateType(alternate: unknown | Azure.ClientGenerator.Core.ExternalType, scope?: valueof string)
```

##### Target

The source type to which the alternate type will be applied.
`ModelProperty | Scalar | Model | Enum | Union`

##### Parameters

| Name      | Type                                           | Description                                                                                                                                                                                                                                                |
| --------- | ---------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| alternate | `unknown \| ClientGenerator.Core.ExternalType` | The alternate type to apply to the target. Can be a TypeSpec type or an ExternalType.                                                                                                                                                                      |
| scope     | `valueof string`                               | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Change a model property to a different type

```typespec
model Foo {
  date: utcDateTime;
}
@@alternateType(Foo.date, string);
```

###### Change a Scalar type to a different type

```typespec
scalar storageDateTime extends utcDateTime;
@@alternateType(storageDateTime, string, "python");
```

###### Change a function parameter to a different type

```typespec
op test(@param @alternateType(string) date: utcDateTime): void;
```

###### Change a model property to a different type with language specific alternate type

```typespec
model Test {
  @alternateType(unknown)
  thumbprint?: string;

  @alternateType(AzureLocation[], "csharp")
  locations: string[];
}
```

###### Use external type for DFE case

```typespec
@alternateType(
  {
    identity: "Azure.Core.Expressions.DataFactoryExpression",
  },
  "csharp"
)
union Dfe<T> {
  T,
  DfeExpression,
}
```

###### Use external type with package information

```typespec
@alternateType(
  {
    identity: "pystac.Collection",
    package: "pystac",
    minVersion: "1.13.0",
  },
  "python"
)
model ItemCollection {
  // ... properties
}
```

#### `@apiVersion`

Specify whether a parameter is an API version parameter or not.
By default, we detect an API version parameter by matching the parameter name with `api-version` or `apiversion`, or if the type is referenced by the `@versioned` decorator.
Since API versions are a client parameter, we will also elevate this parameter up onto the client.
This decorator allows you to explicitly specify whether a parameter should be treated as an API version parameter or not.

```typespec
@Azure.ClientGenerator.Core.apiVersion(value?: valueof boolean, scope?: valueof string)
```

##### Target

The target parameter that you want to mark as an API version parameter.
`ModelProperty`

##### Parameters

| Name  | Type              | Description                                                                                                                                                                                                                                                |
| ----- | ----------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| value | `valueof boolean` | If true, we will treat this parameter as an api-version parameter. If false, we will not. Default is true.                                                                                                                                                 |
| scope | `valueof string`  | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Mark a parameter as an API version parameter

```typespec
namespace Contoso;

op test(
  @apiVersion
  @header("x-ms-version")
  version: string,
): void;
```

###### Mark a parameter as not presenting an API version parameter

```typespec
namespace Contoso;
op test(
  @apiVersion(false)
  @query
  api-version: string
): void;
```

#### `@client`

Define the client generated in the client SDK.
If there is any `@client` definition or `@operationGroup` definition, then each `@client` is a root client and each `@operationGroup` is a sub client with hierarchy.
This decorator cannot be used along with `@clientLocation`. This decorator cannot be used as augmentation.

```typespec
@Azure.ClientGenerator.Core.client(options?: Azure.ClientGenerator.Core.ClientOptions, scope?: valueof string)
```

##### Target

The target namespace or interface that you want to define as a client.
`Namespace | Interface`

##### Parameters

| Name    | Type                              | Description                                                                                                                                                                                                                                                |
| ------- | --------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| options | [`ClientOptions`](#clientoptions) | Optional configuration for the service.                                                                                                                                                                                                                    |
| scope   | `valueof string`                  | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Basic client definition

```typespec
namespace MyService {

}

@client({
  service: MyService,
})
interface MyInterface {}
```

###### Changing client name

```typespec
namespace MyService {

}

@client({
  service: MyService,
  name: "MySpecialClient",
})
interface MyInterface {}
```

#### `@clientApiVersions`

Specify additional API versions that the client can support. These versions should include those defined by the service's versioning configuration.
This decorator is useful for extending the API version enum exposed by the client.
It is particularly beneficial when generating a complete API version enum without requiring the entire specification to be annotated with versioning decorators, as the generation process does not depend on versioning details.

```typespec
@Azure.ClientGenerator.Core.clientApiVersions(value: Enum, scope?: valueof string)
```

##### Target

The target client for which you want to define additional API versions.
`Namespace`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| value | `Enum`           | If true, we will treat this parameter as an api-version parameter. If false, we will not. Default is true.                                                                                                                                                 |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Add additional API versions to a client

```typespec
// main.tsp
@versioned(Versions)
namespace Contoso {
  enum Versions {
    v4,
    v5,
  }
}

// client.tsp

enum ClientApiVersions {
  v1,
  v2,
  v3,
  ...Contoso.Versions,
}

@@clientApiVersions(Contoso, ClientApiVersions);
```

#### `@clientDoc`

Override documentation for a type in client libraries. This allows you to
provide client-specific documentation that differs from the original documentation.

```typespec
@Azure.ClientGenerator.Core.clientDoc(documentation: valueof string, mode: EnumMember, scope?: valueof string)
```

##### Target

The target type (operation, model, enum, etc.) for which you want to apply client-specific documentation.
`unknown`

##### Parameters

| Name          | Type             | Description                                                                                                                                                                                                                                                |
| ------------- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| documentation | `valueof string` | The client-specific documentation to apply                                                                                                                                                                                                                 |
| mode          | `EnumMember`     | Specifies how to apply the documentation (append or replace)                                                                                                                                                                                               |
| scope         | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Replacing documentation

```typespec
@doc("This is service documentation")
@clientDoc("This is client-specific documentation", DocumentationMode.replace)
op myOperation(): void;
```

###### Appending documentation

```typespec
@doc("This is service documentation.")
@clientDoc("This additional note is for client libraries only.", DocumentationMode.append)
model MyModel {
  prop: string;
}
```

###### Language-specific documentation

```typespec
@doc("This is service documentation")
@clientDoc("Python-specific documentation", DocumentationMode.replace, "python")
@clientDoc("JavaScript-specific documentation", DocumentationMode.replace, "javascript")
op myOperation(): void;
```

#### `@clientInitialization`

Allows customization of how clients are initialized in the generated SDK.
By default, the root client is initialized independently, while sub clients are initialized through their parent client.
Initialization parameters typically include endpoint, credential, and API version.
With `@clientInitialization` decorator, you can elevate operation level parameters to client level, and set how the client is initialized.
This decorator can be combined with `@paramAlias` decorator to change the parameter name in client initialization.

```typespec
@Azure.ClientGenerator.Core.clientInitialization(options: Azure.ClientGenerator.Core.ClientInitializationOptions, scope?: valueof string)
```

##### Target

The target client that you want to customize client initialization for.
`Namespace | Interface`

##### Parameters

| Name    | Type                                                          | Description                                                                                                                                                                                                                                                |
| ------- | ------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| options | [`ClientInitializationOptions`](#clientinitializationoptions) | The options for client initialization. You can use `ClientInitializationOptions` model to set the options.                                                                                                                                                 |
| scope   | `valueof string`                                              | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Add client initialization parameters

```typespec
// main.tsp
namespace MyService;

op upload(blobName: string): void;
op download(blobName: string): void;

// client.tsp
namespace MyCustomizations;
model MyServiceClientOptions {
  blobName: string;
}

@@clientInitialization(MyService, {parameters: MyServiceClientOptions})
// The generated client will have `blobName` in its initialization method. We will also
// elevate the existing `blobName` parameter from method level to client level.
```

#### `@clientLocation`

Change the operation location in the client. If the target client is not defined, use `string` to indicate a new client name. For this usage, the decorator cannot be used along with `@client` or `@operationGroup` decorators.
Change the parameter location to operation or client. For this usage, the decorator cannot be used in the parameter defined in `@clientInitialization` decorator.

```typespec
@Azure.ClientGenerator.Core.clientLocation(target: Interface | Namespace | Operation | valueof string, scope?: valueof string)
```

##### Target

The operation to change location for.
`Operation | ModelProperty`

##### Parameters

| Name   | Type                                                      | Description                                                                                                                                                                                                                                                |
| ------ | --------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| target | `Interface \| Namespace \| Operation` \| `valueof string` | The target `Namespace`, `Interface` or a string which can indicate the client.                                                                                                                                                                             |
| scope  | `valueof string`                                          | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Move to existing sub client

```typespec
@service
namespace MoveToExistingSubClient;

interface UserOperations {
  @route("/user")
  @get
  getUser(): void;

  @route("/user")
  @delete
  @clientLocation(AdminOperations)
  deleteUser(): void; // This operation will be moved to AdminOperations sub client.
}

interface AdminOperations {
  @route("/admin")
  @get
  getAdminInfo(): void;
}
```

###### Move to new sub client

```typespec
@service
namespace MoveToNewSubClient;

interface ProductOperations {
  @route("/products")
  @get
  listProducts(): void;

  @route("/products/archive")
  @post
  @clientLocation("ArchiveOperations")
  archiveProduct(): void; // This operation will be moved to a new sub client named ArchiveOperations.
}
```

###### Move operation to root client

```typespec
@service
namespace MoveToRootClient;

interface ResourceOperations {
  @route("/resource")
  @get
  getResource(): void;

  @route("/health")
  @get
  @clientLocation(MoveToRootClient)
  getHealthStatus(): void; // This operation will be moved to the root client of MoveToRootClient namespace.
}
```

###### Move parameter from operation to client

```typespec
@service
namespace MyClient;

getHealthStatus(
  @clientLocation(MyClient) // This parameter will be moved to the `.clientInitialization` parameters of `MyClient`. It will not appear on the operation-level.
  clientId: string
): void;
```

###### Move parameter from client to operation

```typespec
// client.tsp

@@clientLocation(CommonTypes.SubscriptionIdParameter.subscriptionId, get); // This will keep the `subscriptionId` parameter on the operation level instead of applying TCGC's default logic of elevating `subscriptionId` to client.
```

#### `@clientName`

Overrides the generated name for client SDK elements including clients, methods, parameters,
unions, models, enums, and model properties.

This decorator takes precedence over all other naming mechanisms, including the `name`
property in `@client` decorator and default naming conventions.

```typespec
@Azure.ClientGenerator.Core.clientName(rename: valueof string, scope?: valueof string)
```

##### Target

The type you want to rename.
`unknown`

##### Parameters

| Name   | Type             | Description                                                                                                                                                                                                                                                |
| ------ | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| rename | `valueof string` | The rename you want applied to the object.                                                                                                                                                                                                                 |
| scope  | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Rename a model

```typespec
@clientName("RenamedModel")
model TestModel {
  prop: string;
}
```

###### Rename a model property

```typespec
model TestModel {
  @clientName("renamedProp")
  prop: string;
}
```

###### Rename a parameter

```typespec
op example(@clientName("renamedParameter") parameter: string): void;
```

###### Rename an operation

```typespec
@clientName("nameInClient")
op example(): void;
```

###### Rename an operation for different language emitters

```typespec
@clientName("nameForJava", "java")
@clientName("name_for_python", "python")
@clientName("nameForCsharp", "csharp")
@clientName("nameForJavascript", "javascript")
op example(): void;
```

#### `@clientNamespace`

Changes the namespace of a client, model, enum or union generated in the client SDK.
By default, the client namespace for them will follow the TypeSpec namespace.

```typespec
@Azure.ClientGenerator.Core.clientNamespace(rename: valueof string, scope?: valueof string)
```

##### Target

The type you want to change the namespace for.
`Namespace | Interface | Model | Enum | Union`

##### Parameters

| Name   | Type             | Description                                                                                                                                                                                                                                                |
| ------ | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| rename | `valueof string` | The rename you want applied to the object                                                                                                                                                                                                                  |
| scope  | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Change a namespace to a different name

```typespec
@clientNamespace("ContosoClient")
namespace Contoso;
```

###### Move a model to a different namespace

```typespec
@clientNamespace("ContosoClient.Models")
model Test {
  prop: string;
}
```

#### `@convenientAPI`

Whether you want to generate an operation as a convenient method.
When applied to a namespace or interface, it affects all operations within that scope unless explicitly overridden.

```typespec
@Azure.ClientGenerator.Core.convenientAPI(flag?: valueof boolean, scope?: valueof string)
```

##### Target

The target operation, namespace, or interface.
`Operation | Namespace | Interface`

##### Parameters

| Name  | Type              | Description                                                                                                                                                                                                                                                |
| ----- | ----------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| flag  | `valueof boolean` | Whether to generate the operation as a convenience method or not.                                                                                                                                                                                          |
| scope | `valueof string`  | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Apply to a single operation

```typespec
@convenientAPI(false)
op test: void;
```

###### Apply to all operations in an interface

```typespec
@convenientAPI(false)
interface MyOperations {
  test1(): void;
  test2(): void;
}
```

###### Apply to all operations in a namespace

```typespec
@convenientAPI(false)
namespace MyService {
  op test1(): void;
  op test2(): void;
}
```

#### `@deserializeEmptyStringAsNull`

Indicates that a model property of type `string` or a `Scalar` type derived from `string` should be deserialized as `null` when its value is an empty string (`""`).

```typespec
@Azure.ClientGenerator.Core.deserializeEmptyStringAsNull(scope?: valueof string)
```

##### Target

The target type that you want to apply this deserialization behavior to.
`ModelProperty`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

```typespec

model MyModel {
  scalar stringlike extends string;

  @deserializeEmptyStringAsNull
  prop: string;

  @deserializeEmptyStringAsNull
  prop: stringlike;
}
```

#### `@operationGroup`

Define the sub client generated in the client SDK.
If there is any `@client` definition or `@operationGroup` definition, then each `@client` is a root client and each `@operationGroup` is a sub client with hierarchy.
This decorator cannot be used along with `@clientLocation`. This decorator cannot be used as augmentation.

```typespec
@Azure.ClientGenerator.Core.operationGroup(scope?: valueof string)
```

##### Target

The target namespace or interface that you want to define as a sub client.
`Namespace | Interface`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

```typespec
@operationGroup
interface MyInterface {}
```

#### `@override`

Customize a method's signature in the generated client SDK.
Currently, only parameter signature customization is supported.
This decorator allows you to specify a different method signature for the client SDK than the original definition.

```typespec
@Azure.ClientGenerator.Core.override(override: Operation, scope?: valueof string)
```

##### Target

: The target operation that you want to override.
`Operation`

##### Parameters

| Name     | Type             | Description                                                                                                                                                                                                                                                |
| -------- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| override | `Operation`      | : The override method definition that specifies the exact client method you want                                                                                                                                                                           |
| scope    | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Customize parameters into an option bag

```typespec
// main.tsp
@service
namespace MyService;

op myOperation(foo: string, bar: string): void; // by default, we generate the method signature as `op myOperation(foo: string, bar: string)`;

// client.tsp
namespace MyCustomizations;

model Params {
 foo: string;
 bar: string;
}

op myOperationCustomization(params: MyService.Params): void;

@@override(MyService.myOperation, myOperationCustomization); // method signature is now `op myOperation(params: Params)`
```

###### Customize a parameter to be required

```typespec
// main.tsp
@service
namespace MyService;

op myOperation(foo: string, bar?: string): void; // by default, we generate the method signature as `op myOperation(foo: string, bar?: string)`;

// client.tsp
namespace MyCustomizations;

op myOperationCustomization(foo: string, bar: string): void;

@@override(MyService.myOperation, myOperationCustomization)

// method signature is now `op myOperation(params: Params)` just for csharp // method signature is now `op myOperation(foo: string, bar: string)`
```

#### `@paramAlias`

Alias the name of a client parameter to a different name. This permits you to have a different name for the parameter in client initialization and the original parameter in the operation.

```typespec
@Azure.ClientGenerator.Core.paramAlias(paramAlias: valueof string, scope?: valueof string)
```

##### Target

The target model property that you want to alias.
`ModelProperty`

##### Parameters

| Name       | Type             | Description                                                                                                                                                                                                                                                |
| ---------- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| paramAlias | `valueof string` | The alias name you want to apply to the target model property.                                                                                                                                                                                             |
| scope      | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Elevate an operation parameter to client level and alias it to a different name

```typespec
// main.tsp
namespace MyService;

op upload(blobName: string): void;

// client.tsp
namespace MyCustomizations;
model MyServiceClientOptions {
  blob: string;
}

@@clientInitialization(MyService, MyServiceClientOptions)
@@paramAlias(MyServiceClientOptions.blob, "blobName")

// The generated client will have `blobName` in it. We will also
// elevate the existing `blob` parameter to the client level.
```

#### `@protocolAPI`

Whether you want to generate an operation as a protocol method.
When applied to a namespace or interface, it affects all operations within that scope unless explicitly overridden.

```typespec
@Azure.ClientGenerator.Core.protocolAPI(flag?: valueof boolean, scope?: valueof string)
```

##### Target

The target operation, namespace, or interface.
`Operation | Namespace | Interface`

##### Parameters

| Name  | Type              | Description                                                                                                                                                                                                                                                |
| ----- | ----------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| flag  | `valueof boolean` | Whether to generate the operation as a protocol method or not.                                                                                                                                                                                             |
| scope | `valueof string`  | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Apply to a single operation

```typespec
@protocolAPI(false)
op test: void;
```

###### Apply to all operations in an interface

```typespec
@protocolAPI(false)
interface MyOperations {
  test1(): void;
  test2(): void;
}
```

###### Apply to all operations in a namespace

```typespec
@protocolAPI(false)
namespace MyService {
  op test1(): void;
  op test2(): void;
}
```

#### `@responseAsBool`

Indicates that a HEAD operation should be modeled as Response<bool>.
404 will not raise an error, instead the service method will return `false`.
2xx will return `true`. Everything else will still raise an error.

```typespec
@Azure.ClientGenerator.Core.responseAsBool(scope?: valueof string)
```

##### Target

The target operation that you want to apply this behavior to.
`Operation`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

```typespec
@responseAsBool
@head
op headOperation(): void;
```

#### `@scope`

Define the scope of an operation or model property.
By default, the element will be applied to all language emitters.
This decorator allows you to omit the element from certain languages or apply it to specific languages.

```typespec
@Azure.ClientGenerator.Core.scope(scope?: valueof string)
```

##### Target

The target operation or model property that you want to scope.
`Operation | ModelProperty`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Omit an operation from a specific language

```typespec
@scope("!csharp")
op test: void;
```

###### Apply an operation to specific languages

```typespec
@scope("go")
op test: void;
```

###### Apply a model property to specific languages

```typespec
model TestModel {
  @scope("csharp")
  csharpOnlyProp: string;
}
```

#### `@usage`

Add usage for models/enums.
A model/enum's default usage info is always calculated by the operations that use it.
You can use this decorator to add additional usage info.
When setting usage for namespaces,
the usage info will be propagated to the models defined in the namespace.
If the model has a usage override, the model override takes precedence.
For example, with operation definition `op test(): OutputModel`,
the model `OutputModel` has default usage `Usage.output`.
After adding decorator `@@usage(OutputModel, Usage.input | Usage.json)`,
the final usage result for `OutputModel` is `Usage.input | Usage.output | Usage.json`.
The usage info for models will be propagated to models' properties,
parent models, discriminated sub models.

```typespec
@Azure.ClientGenerator.Core.usage(value: EnumMember | Union, scope?: valueof string)
```

##### Target

The target type you want to extend usage.
`Model | Enum | Union | Namespace`

##### Parameters

| Name  | Type                  | Description                                                                                                                                                                                                                                                |
| ----- | --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| value | `EnumMember \| Union` | The usage info you want to add for this model. It can be a single value of `Usage` enum value or a combination of `Usage` enum values using bitwise OR.<br />For example, `Usage.input \| Usage.output \| Usage.json`.                                     |
| scope | `valueof string`      | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Add usage for model

```typespec
op test(): OutputModel;

// The resolved usage  for `OutputModel` is `Usage.input | Usage.output | Usage.json`
@usage(Usage.input | Usage.json)
model OutputModel {
  prop: string;
}
```

###### Propagation of usage, all usage will be propagated to the parent model, discriminated sub models, and model properties.

```typespec
// The resolved usage  for `Fish` is `Usage.input | Usage.output | Usage.json`
@discriminator("kind")
model Fish {
  age: int32;
}

// The resolved usage  for `Shark` is `Usage.input | Usage.output | Usage.json`
@discriminator("sharktype")
@usage(Usage.input | Usage.json)
model Shark extends Fish {
  kind: "shark";
  origin: Origin;
}

// The resolved usage  for `Salmon` is `Usage.output | Usage.json`
model Salmon extends Fish {
  kind: "salmon";
}

// The resolved usage  for `SawShark` is `Usage.input | Usage.output | Usage.json`
model SawShark extends Shark {
  sharktype: "saw";
}

// The resolved usage  for `Origin` is `Usage.input | Usage.output | Usage.json`
model Origin {
  country: string;
  city: string;
  manufacture: string;
}

@get
op getModel(): Fish;
```

#### `@useSystemTextJsonConverter`

Whether a model needs the custom JSON converter, this is only used for backward compatibility for csharp.

```typespec
@Azure.ClientGenerator.Core.useSystemTextJsonConverter(scope?: valueof string)
```

##### Target

The target model that you want to set the custom JSON converter.
`Model`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

```typespec
@useSystemTextJsonConverter
model MyModel {
  prop: string;
}
```

### Azure.ClientGenerator.Core.Legacy

- [`@clientDefaultValue`](#@clientdefaultvalue)
- [`@disablePageable`](#@disablepageable)
- [`@flattenProperty`](#@flattenproperty)
- [`@hierarchyBuilding`](#@hierarchybuilding)
- [`@markAsLro`](#@markaslro)
- [`@markAsPageable`](#@markaspageable)
- [`@nextLinkVerb`](#@nextlinkverb)

#### `@clientDefaultValue`

Sets a client-level default value for a model property or operation parameter.

This decorator allows brownfield services to specify default values that will be
used by SDK generators, maintaining backward compatibility with existing SDK users
who may rely on default values that were previously generated from Swagger definitions.

This decorator is considered legacy functionality and should only be used for
maintaining backward compatibility in existing services. New services should use
standard TypeSpec patterns for default values.

```typespec
@Azure.ClientGenerator.Core.Legacy.clientDefaultValue(value: valueof string | boolean | numeric, scope?: valueof string)
```

##### Target

The model property or operation parameter that should have a client-level default value
`ModelProperty`

##### Parameters

| Name  | Type                                   | Description                                                                                                                                                                                                                                                     |
| ----- | -------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| value | `valueof string \| boolean \| numeric` | The default value to be used by SDK generators (must be a string, number, or boolean literal)                                                                                                                                                                   |
| scope | `valueof string`                       | Specifies the target language emitters that the decorator should apply.<br />If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Set a default value for a model property

```typespec
model RequestOptions {
  @Azure.ClientGenerator.Core.Legacy.clientDefaultValue(30)
  timeout?: int32;

  @Azure.ClientGenerator.Core.Legacy.clientDefaultValue("standard")
  tier?: string;
}
```

###### Set a default value for an operation parameter

```typespec
op getItems(
  @Azure.ClientGenerator.Core.Legacy.clientDefaultValue(10)
  @query
  pageSize?: int32,
): Item[];
```

###### Apply default value only for specific languages

```typespec
model Config {
  @Azure.ClientGenerator.Core.Legacy.clientDefaultValue(false, "python")
  enableCache?: boolean;
}
```

#### `@disablePageable`

Prevents an operation from being treated as a pageable operation by the SDK generators,
even when the operation follows standard paging patterns (e.g., decorated with `@list`).

When applied, the operation will be treated as a basic method:

- The response will be the paged model itself (not the list of items)
- The paged model will not be marked with paged result usage
- No paging mechanisms (iterators/async iterators) will be generated

This decorator is considered legacy functionality and should only be used when
you need to override the default paging behavior for specific operations.

```typespec
@Azure.ClientGenerator.Core.Legacy.disablePageable(scope?: valueof string)
```

##### Target

The operation that should NOT be treated as a pageable operation
`Operation`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                     |
| ----- | ---------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply.<br />If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Prevent a paging operation from being treated as pageable

```typespec
@Azure.ClientGenerator.Core.Legacy.disablePageable
@list
@route("/items")
@get
op listItems(): ItemListResult;
```

#### `@flattenProperty`

Set whether a model property should be flattened or not.
This decorator is not recommended to use for green field services.

```typespec
@Azure.ClientGenerator.Core.Legacy.flattenProperty(scope?: valueof string)
```

##### Target

The target model property that you want to flatten.
`ModelProperty`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                |
| ----- | ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply. If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

```typespec
model Foo {
  @flattenProperty
  prop: Bar;
}
model Bar {}
```

#### `@hierarchyBuilding`

Adds support for client-level multiple levels of inheritance.

This decorator will update the models returned from TCGC to include the multi-level inheritance information.

It could be used in the scenario where the discriminated models have multiple levels of inheritance, which is not supported by pure TypeSpec.

This decorator is considered legacy functionality and may be deprecated in future releases.

```typespec
@Azure.ClientGenerator.Core.Legacy.hierarchyBuilding(value: Model, scope?: valueof string)
```

##### Target

The target model that will gain legacy inheritance behavior
`Model`

##### Parameters

| Name  | Type             | Description                                                           |
| ----- | ---------------- | --------------------------------------------------------------------- |
| value | `Model`          | The model whose properties should be inherited from                   |
| scope | `valueof string` | Optional parameter to specify which language emitters this applies to |

##### Examples

###### Build multiple levels inheritance for discriminated models.

```typespec
@discriminator("type")
model Vehicle {
  type: string;
}

alias CarProperties = {
 make: string;
 model: string;
 year: int32;
}

model Car extends Vehicle {
  type: "car";
  ...CarProperties;
}

@Azure.ClientGenerator.Core.Legacy.hierarchyBuilding(Car)
model SportsCar extends Vehicle {
  type: "sports";
  ...CarProperties;
  topSpeed: int32;
}

```

#### `@markAsLro`

Forces an operation to be treated as a Long Running Operation (LRO) by the SDK generators,
even when the operation is not long-running on the service side.

NOTE: When used, you will need to verify the operatio and add tests for the generated code
to make sure the end-to-end works for library users, since there is a risk that forcing
this operation to be LRO will result in errors.

When applied, TCGC will treat the operation as an LRO and SDK generators should:

- Generate polling mechanisms (pollers)
- Return appropriate LRO-specific return types
- Handle the operation as an asynchronous long-running process

This decorator is considered legacy functionality and should only be used when
standard TypeSpec LRO patterns are not feasible.

```typespec
@Azure.ClientGenerator.Core.Legacy.markAsLro(scope?: valueof string)
```

##### Target

The operation that should be treated as a Long Running Operation
`Operation`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                     |
| ----- | ---------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply.<br />If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Force a regular operation to be treated as LRO for backward compatibility

```typespec
@Azure.ClientGenerator.Core.Legacy.markAsLro
@route("/deployments/{deploymentId}")
@post
op startDeployment(@path deploymentId: string): DeploymentResult | ErrorResponse;
```

#### `@markAsPageable`

Forces an operation to be treated as a pageable operation by the SDK generators,
even when the operation does not follow standard paging patterns on the service side.

NOTE: When used, you will need to verify the operation and add tests for the generated code
to make sure the end-to-end works for library users, since there is a risk that forcing
this operation to be pageable will result in errors.

When applied, TCGC will treat the operation as pageable and SDK generators should:

- Generate paging mechanisms (iterators/async iterators)
- Return appropriate pageable-specific return types
- Handle the operation as a collection that may require multiple requests

This decorator is considered legacy functionality and should only be used when
standard TypeSpec paging patterns are not feasible.

```typespec
@Azure.ClientGenerator.Core.Legacy.markAsPageable(scope?: valueof string)
```

##### Target

The operation that should be treated as a pageable operation
`Operation`

##### Parameters

| Name  | Type             | Description                                                                                                                                                                                                                                                     |
| ----- | ---------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| scope | `valueof string` | Specifies the target language emitters that the decorator should apply.<br />If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Force a regular operation to be treated as pageable for backward compatibility

```typespec
@Azure.ClientGenerator.Core.Legacy.markAsPageable
@route("/items")
@get
op listItems(): ItemListResult;
```

#### `@nextLinkVerb`

Specifies the HTTP verb for the next link operation in a paging scenario.

This decorator allows you to override the HTTP method used for fetching the next page
when the default GET method is not appropriate. Only "POST" and "GET" are supported.

This decorator is considered legacy functionality and should only be used when
standard TypeSpec paging patterns are not sufficient.

```typespec
@Azure.ClientGenerator.Core.Legacy.nextLinkVerb(verb: "GET" | "POST", scope?: valueof string)
```

##### Target

The paging operation to specify next link operation behavior for
`Operation`

##### Parameters

| Name  | Type              | Description                                                                                                                                                                                                                                                     |
| ----- | ----------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| verb  | `"GET" \| "POST"` | The HTTP verb to use for next link operations. Must be "POST" or "GET".                                                                                                                                                                                         |
| scope | `valueof string`  | Specifies the target language emitters that the decorator should apply.<br />If not set, the decorator will be applied to all language emitters by default.<br />You can use "!" to exclude specific languages, for example: !(java, python) or !java, !python. |

##### Examples

###### Specify POST for next link operations

```typespec
@Azure.ClientGenerator.Core.Legacy.nextLinkVerb("POST")
@post
op listItems(): PageResult;
```
