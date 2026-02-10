# @azure-tools/typespec-azure-core

TypeSpec Azure Core library

## Install

```bash
npm install @azure-tools/typespec-azure-core
```

## Usage

Add the following in `tspconfig.yaml`:

```yaml
linter:
  extends:
    - "@azure-tools/typespec-azure-core/all"
```

## RuleSets

Available ruleSets:

- `@azure-tools/typespec-azure-core/all`
- `@azure-tools/typespec-azure-core/canonical-versioning`

## Rules

| Name                                                                                                                                                                     | Description                                                                                                                                          |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------- |
| [`@azure-tools/typespec-azure-core/operation-missing-api-version`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/operation-missing-api-version) | Operations need an api version parameter.                                                                                                            |
| [`@azure-tools/typespec-azure-core/auth-required`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/auth-required)                                 | Enforce service authentication.                                                                                                                      |
| `@azure-tools/typespec-azure-core/request-body-problem`                                                                                                                  | Request body should not be of raw array type.                                                                                                        |
| `@azure-tools/typespec-azure-core/byos`                                                                                                                                  | Use the BYOS pattern recommended for Azure Services.                                                                                                 |
| [`@azure-tools/typespec-azure-core/casing-style`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/casing-style)                                   | Ensure proper casing style.                                                                                                                          |
| `@azure-tools/typespec-azure-core/composition-over-inheritance`                                                                                                          | Check that if a model is used in an operation and has derived models that it has a discriminator or recommend to use composition via spread or `is`. |
| `@azure-tools/typespec-azure-core/known-encoding`                                                                                                                        | Check for supported encodings.                                                                                                                       |
| `@azure-tools/typespec-azure-core/long-running-polling-operation-required`                                                                                               | Long-running operations should have a linked polling operation.                                                                                      |
| [`@azure-tools/typespec-azure-core/no-case-mismatch`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-case-mismatch)                           | Validate that no two types have the same name with different casing.                                                                                 |
| [`@azure-tools/typespec-azure-core/no-closed-literal-union`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-closed-literal-union)             | Unions of literals should include the base scalar type to mark them as open enum.                                                                    |
| [`@azure-tools/typespec-azure-core/no-enum`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-enum)                                             | Azure services should not use enums.                                                                                                                 |
| `@azure-tools/typespec-azure-core/no-error-status-codes`                                                                                                                 | Recommend using the error response defined by Azure REST API guidelines.                                                                             |
| `@azure-tools/typespec-azure-core/no-explicit-routes-resource-ops`                                                                                                       | The @route decorator should not be used on standard resource operation signatures.                                                                   |
| [`@azure-tools/typespec-azure-core/non-breaking-versioning`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/non-breaking-versioning)             | Check that only backward compatible versioning change are done to a service.                                                                         |
| [`@azure-tools/typespec-azure-core/no-generic-numeric`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-generic-numeric)                       | Don't use generic types. Use more specific types instead.                                                                                            |
| [`@azure-tools/typespec-azure-core/no-nullable`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-nullable)                                     | Use `?` for optional properties.                                                                                                                     |
| `@azure-tools/typespec-azure-core/no-offsetdatetime`                                                                                                                     | Prefer using `utcDateTime` when representing a datetime unless an offset is necessary.                                                               |
| `@azure-tools/typespec-azure-core/no-response-body`                                                                                                                      | Ensure that the body is set correctly for the response type.                                                                                         |
| `@azure-tools/typespec-azure-core/no-rpc-path-params`                                                                                                                    | Operations defined using RpcOperation should not have path parameters.                                                                               |
| `@azure-tools/typespec-azure-core/no-openapi`                                                                                                                            | Azure specs should not be using decorators from @typespec/openapi or @azure-tools/typespec-autorest                                                  |
| [`@azure-tools/typespec-azure-core/no-unnamed-union`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-unnamed-union)                           | Azure services should not define a union expression but create a declaration.                                                                        |
| [`@azure-tools/typespec-azure-core/no-header-explode`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-header-explode)                         | It is recommended to serialize header parameter without explode: true                                                                                |
| [`@azure-tools/typespec-azure-core/no-format`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/prevent-format)                                    | Azure services should not use the `@format` decorator.                                                                                               |
| `@azure-tools/typespec-azure-core/no-multiple-discriminator`                                                                                                             | Classes should have at most one discriminator.                                                                                                       |
| `@azure-tools/typespec-azure-core/no-rest-library-interfaces`                                                                                                            | Resource interfaces from the TypeSpec.Rest.Resource library are incompatible with Azure.Core.                                                        |
| `@azure-tools/typespec-azure-core/no-unknown`                                                                                                                            | Azure services must not have properties of type `unknown`.                                                                                           |
| [`@azure-tools/typespec-azure-core/bad-record-type`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/bad-record-type)                             | Identify bad record definitions.                                                                                                                     |
| `@azure-tools/typespec-azure-core/documentation-required`                                                                                                                | Require documentation over enums, models, and operations.                                                                                            |
| `@azure-tools/typespec-azure-core/key-visibility-required`                                                                                                               | Key properties need to have a Lifecycle visibility setting.                                                                                          |
| `@azure-tools/typespec-azure-core/response-schema-problem`                                                                                                               | Warn about operations having multiple non-error response schemas.                                                                                    |
| `@azure-tools/typespec-azure-core/rpc-operation-request-body`                                                                                                            | Warning for RPC body problems.                                                                                                                       |
| [`@azure-tools/typespec-azure-core/spread-discriminated-model`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/spread-discriminated-model)       | Check a model with a discriminator has not been used in composition.                                                                                 |
| `@azure-tools/typespec-azure-core/use-standard-names`                                                                                                                    | Use recommended names for operations.                                                                                                                |
| [`@azure-tools/typespec-azure-core/use-standard-operations`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/use-standard-operations)             | Operations should be defined using a signature from the Azure.Core namespace.                                                                        |
| [`@azure-tools/typespec-azure-core/no-string-discriminator`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-string-discriminator)             | Azure services discriminated models should define the discriminated property as an extensible union.                                                 |
| [`@azure-tools/typespec-azure-core/require-versioned`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/require-versioned)                         | Azure services should use the versioning library.                                                                                                    |
| `@azure-tools/typespec-azure-core/friendly-name`                                                                                                                         | Ensures that @friendlyName is used as intended.                                                                                                      |
| [`@azure-tools/typespec-azure-core/no-private-usage`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-private-usage)                           | Verify that elements inside Private namespace are not referenced.                                                                                    |
| [`@azure-tools/typespec-azure-core/no-legacy-usage`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-legacy-usage)                             | Linter warning against using elements from the Legacy namespace                                                                                      |
| [`@azure-tools/typespec-azure-core/no-query-explode`](https://azure.github.io/typespec-azure/docs/libraries/azure-core/rules/no-query-explode)                           | It is recommended to serialize query parameter without explode: true                                                                                 |

## Decorators

### Azure.Core

- [`@finalLocation`](#@finallocation)
- [`@finalOperation`](#@finaloperation)
- [`@lroCanceled`](#@lrocanceled)
- [`@lroErrorResult`](#@lroerrorresult)
- [`@lroFailed`](#@lrofailed)
- [`@lroResult`](#@lroresult)
- [`@lroStatus`](#@lrostatus)
- [`@lroSucceeded`](#@lrosucceeded)
- [`@operationLink`](#@operationlink)
- [`@pollingLocation`](#@pollinglocation)
- [`@pollingOperation`](#@pollingoperation)
- [`@pollingOperationParameter`](#@pollingoperationparameter)
- [`@previewVersion`](#@previewversion)
- [`@uniqueItems`](#@uniqueitems)
- [`@useFinalStateVia`](#@usefinalstatevia)

#### `@finalLocation`

Identifies a ModelProperty as containing the final location for the operation result.

```typespec
@Azure.Core.finalLocation(finalResult?: Model | unknown | void)
```

##### Target

`ModelProperty`

##### Parameters

| Name        | Type                       | Description                                                                                                                                                        |
| ----------- | -------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| finalResult | `Model \| unknown \| void` | Sets the expected return value for the final result. Overrides<br />any value provided in the decorated property, if the property uses ResourceLocation<Resource>. |

#### `@finalOperation`

Identifies that an operation is the final operation for an LRO.

```typespec
@Azure.Core.finalOperation(linkedOperation: Operation, parameters?: {})
```

##### Target

`Operation`

##### Parameters

| Name            | Type        | Description                                                                                                               |
| --------------- | ----------- | ------------------------------------------------------------------------------------------------------------------------- |
| linkedOperation | `Operation` | The linked Operation                                                                                                      |
| parameters      | `{}`        | Map of `RequestParameter<Name>` and/or `ResponseProperty<Name>` that will<br />be passed to the linked operation request. |

#### `@lroCanceled`

Used for custom StatusMonitor implementation.
Identifies an EnumMember as a long-running "Canceled" terminal state.

```typespec
@Azure.Core.lroCanceled
```

##### Target

`EnumMember | UnionVariant`

##### Parameters

None

#### `@lroErrorResult`

Used for custom StatusMonitor implementation.
Identifies a model property of a StatusMonitor as containing the result
of a long-running operation that terminates unsuccessfully (Failed).

```typespec
@Azure.Core.lroErrorResult
```

##### Target

`ModelProperty`

##### Parameters

None

#### `@lroFailed`

Used for custom StatusMonitor implementation.
Identifies an enum member as a long-running "Failed" terminal state.

```typespec
@Azure.Core.lroFailed
```

##### Target

`EnumMember | UnionVariant`

##### Parameters

None

#### `@lroResult`

Used for custom StatusMonitor implementation.
Identifies a model property of a StatusMonitor as containing the result
of a long-running operation that terminates successfully (Succeeded).

```typespec
@Azure.Core.lroResult
```

##### Target

`ModelProperty`

##### Parameters

None

#### `@lroStatus`

Used for custom StatusMonitor implementation.
Identifies an Enum or ModelProperty as containing long-running operation
status.

```typespec
@Azure.Core.lroStatus
```

##### Target

`Enum | Union | ModelProperty`

##### Parameters

None

#### `@lroSucceeded`

Used for custom StatusMonitor implementation.
Identifies an EnumMember as a long-running "Succeeded" terminal state.

```typespec
@Azure.Core.lroSucceeded
```

##### Target

`EnumMember | UnionVariant`

##### Parameters

None

#### `@operationLink`

Identifies an operation that is linked to the target operation.

```typespec
@Azure.Core.operationLink(linkedOperation: Operation, linkType: valueof string, parameters?: {})
```

##### Target

`Operation`

##### Parameters

| Name            | Type             | Description                                                                                                               |
| --------------- | ---------------- | ------------------------------------------------------------------------------------------------------------------------- |
| linkedOperation | `Operation`      | The linked Operation                                                                                                      |
| linkType        | `valueof string` | A string indicating the role of the linked operation                                                                      |
| parameters      | `{}`             | Map of `RequestParameter<Name>` and/or `ResponseProperty<Name>` that will<br />be passed to the linked operation request. |

#### `@pollingLocation`

Identifies a model property as containing the location to poll for operation state.

```typespec
@Azure.Core.pollingLocation(options?: Azure.Core.PollingOptions)
```

##### Target

`ModelProperty`

##### Parameters

| Name    | Type                                | Description                                                                                                                                                                                  |
| ------- | ----------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| options | [`PollingOptions`](#pollingoptions) | PollingOptions for the poller pointed to by this link. Overrides<br />settings derived from property value it is decorating, if the value of the<br />property is ResourceLocation<Resource> |

#### `@pollingOperation`

Identifies that an operation is a polling operation for an LRO.

```typespec
@Azure.Core.pollingOperation(linkedOperation: Operation, parameters?: {})
```

##### Target

`Operation`

##### Parameters

| Name            | Type        | Description                                                                                                               |
| --------------- | ----------- | ------------------------------------------------------------------------------------------------------------------------- |
| linkedOperation | `Operation` | The linked Operation                                                                                                      |
| parameters      | `{}`        | Map of `RequestParameter<Name>` and/or `ResponseProperty<Name>` that will<br />be passed to the linked operation request. |

#### `@pollingOperationParameter`

Used to define how to call custom polling operations for long-running operations.

```typespec
@Azure.Core.pollingOperationParameter(targetParameter?: ModelProperty | string)
```

##### Target

`ModelProperty`

##### Parameters

| Name            | Type                      | Description                                                                                                                                                                                        |
| --------------- | ------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| targetParameter | `ModelProperty \| string` | A reference to the polling operation parameter this parameter<br />provides a value for, or the name of that parameter. The default value is the name of<br />the decorated parameter or property. |

#### `@previewVersion`

Decorator that marks a Version EnumMember as a preview version.
This is used to indicate that the version is not yet stable and may change in future releases.

```typespec
@Azure.Core.previewVersion
```

##### Target

The EnumMember that represents the preview version.
`EnumMember`

##### Parameters

None

##### Examples

```typespec
@versioned(Versions)
@service(#{ title: "Widget Service" })
namespace DemoService;

enum Versions {
  v1,
  v2,

  @previewVersion
  v3Preview,
}
```

#### `@uniqueItems`

Specifies that an array model or array-typed property should contain only unique items.

```typespec
@Azure.Core.uniqueItems
```

##### Target

`ModelProperty | Model`

##### Parameters

None

#### `@useFinalStateVia`

Overrides the final state value for an operation

```typespec
@Azure.Core.useFinalStateVia(finalState: valueof "original-uri" | "operation-location" | "location" | "azure-async-operation")
```

##### Target

`Operation`

##### Parameters

| Name       | Type                                                                                      | Description                   |
| ---------- | ----------------------------------------------------------------------------------------- | ----------------------------- |
| finalState | `valueof "original-uri" \| "operation-location" \| "location" \| "azure-async-operation"` | The desired final state value |

### Azure.Core.Foundations

- [`@omitKeyProperties`](#@omitkeyproperties)
- [`@requestParameter`](#@requestparameter)
- [`@responseProperty`](#@responseproperty)

#### `@omitKeyProperties`

Deletes any key properties from the model.

```typespec
@Azure.Core.Foundations.omitKeyProperties
```

##### Target

`Model`

##### Parameters

None

#### `@requestParameter`

Identifies a property on a request model that serves as a linked operation parameter.

```typespec
@Azure.Core.Foundations.requestParameter(name: valueof string)
```

##### Target

`Model`

##### Parameters

| Name | Type             | Description                 |
| ---- | ---------------- | --------------------------- |
| name | `valueof string` | Property name on the target |

#### `@responseProperty`

Identifies a property on _all_ non-error response models that serve as a linked operation parameter.

```typespec
@Azure.Core.Foundations.responseProperty(name: valueof string)
```

##### Target

`Model`

##### Parameters

| Name | Type             | Description                 |
| ---- | ---------------- | --------------------------- |
| name | `valueof string` | Property name on the target |

### Azure.Core.Traits

- [`@trait`](#@trait)
- [`@traitAdded`](#@traitadded)
- [`@traitContext`](#@traitcontext)
- [`@traitLocation`](#@traitlocation)

#### `@trait`

`@trait` marks a model type as representing a 'trait' and performs basic validation
checks.

```typespec
@Azure.Core.Traits.trait(traitName?: valueof string)
```

##### Target

The model type to mark as a trait.
`Model`

##### Parameters

| Name      | Type             | Description                                                                                        |
| --------- | ---------------- | -------------------------------------------------------------------------------------------------- |
| traitName | `valueof string` | An optional name to uniquely identify the trait. If unspecified,<br />the model type name is used. |

#### `@traitAdded`

Sets the version for when the trait was added to the specification. Can be applied
to either a trait model type or its envelope property.

```typespec
@Azure.Core.Traits.traitAdded(addedVersion: EnumMember | null)
```

##### Target

`Model | ModelProperty`

##### Parameters

| Name         | Type                 | Description                                       |
| ------------ | -------------------- | ------------------------------------------------- |
| addedVersion | `EnumMember \| null` | The enum member representing the service version. |

#### `@traitContext`

`@traitContext` sets the applicable context for a trait on its envelope property.

```typespec
@Azure.Core.Traits.traitContext(contexts: EnumMember | Union | unknown)
```

##### Target

The trait envelope property where the context will be applied.
`ModelProperty`

##### Parameters

| Name     | Type                             | Description                                                                                |
| -------- | -------------------------------- | ------------------------------------------------------------------------------------------ |
| contexts | `EnumMember \| Union \| unknown` | An enum member or union of enum members representing the trait's<br />applicable contexts. |

#### `@traitLocation`

`@traitLocation` sets the applicable location for a trait on its envelope property.

```typespec
@Azure.Core.Traits.traitLocation(contexts: EnumMember)
```

##### Target

The trait envelope property where the context will be applied.
`ModelProperty`

##### Parameters

| Name     | Type         | Description                                                                                |
| -------- | ------------ | ------------------------------------------------------------------------------------------ |
| contexts | `EnumMember` | An enum member or union of enum members representing the trait's<br />applicable contexts. |
