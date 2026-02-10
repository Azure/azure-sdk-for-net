# @typespec/openapi

TypeSpec library providing OpenAPI concepts

## Install

```bash
npm install @typespec/openapi
```

## Decorators

### TypeSpec.OpenAPI

- [`@defaultResponse`](#@defaultresponse)
- [`@extension`](#@extension)
- [`@externalDocs`](#@externaldocs)
- [`@info`](#@info)
- [`@operationId`](#@operationid)
- [`@tagMetadata`](#@tagmetadata)

#### `@defaultResponse`

Specify that this model is to be treated as the OpenAPI `default` response.
This differs from the compiler built-in `@error` decorator as this does not necessarily represent an error.

```typespec
@TypeSpec.OpenAPI.defaultResponse
```

##### Target

`Model`

##### Parameters

None

##### Examples

```typespec
@defaultResponse
model PetStoreResponse is object;

op listPets(): Pet[] | PetStoreResponse;
```

#### `@extension`

Attach some custom data to the OpenAPI element generated from this type.

```typespec
@TypeSpec.OpenAPI.extension(key: valueof string, value: valueof unknown)
```

##### Target

`unknown`

##### Parameters

| Name  | Type              | Description      |
| ----- | ----------------- | ---------------- |
| key   | `valueof string`  | Extension key.   |
| value | `valueof unknown` | Extension value. |

##### Examples

```typespec
@extension("x-custom", "My value")
@extension("x-pageable", #{ nextLink: "x-next-link" })
op read(): string;
```

#### `@externalDocs`

Specify the OpenAPI `externalDocs` property for this type.

```typespec
@TypeSpec.OpenAPI.externalDocs(url: valueof string, description?: valueof string)
```

##### Target

`unknown`

##### Parameters

| Name        | Type             | Description             |
| ----------- | ---------------- | ----------------------- |
| url         | `valueof string` | Url to the docs         |
| description | `valueof string` | Description of the docs |

##### Examples

```typespec
@externalDocs(
  "https://example.com/detailed.md",
  "Detailed information on how to use this operation"
)
op listPets(): Pet[];
```

#### `@info`

Specify OpenAPI additional information.
The service `title` is already specified using `@service`.

```typespec
@TypeSpec.OpenAPI.info(additionalInfo: valueof TypeSpec.OpenAPI.AdditionalInfo)
```

##### Target

`Namespace`

##### Parameters

| Name           | Type                                        | Description            |
| -------------- | ------------------------------------------- | ---------------------- |
| additionalInfo | [valueof `AdditionalInfo`](#additionalinfo) | Additional information |

#### `@operationId`

Specify the OpenAPI `operationId` property for this operation.

```typespec
@TypeSpec.OpenAPI.operationId(operationId: valueof string)
```

##### Target

`Operation`

##### Parameters

| Name        | Type             | Description         |
| ----------- | ---------------- | ------------------- |
| operationId | `valueof string` | Operation id value. |

##### Examples

```typespec
@operationId("download")
op read(): string;
```

#### `@tagMetadata`

Specify OpenAPI additional information.

```typespec
@TypeSpec.OpenAPI.tagMetadata(name: valueof string, tagMetadata: valueof TypeSpec.OpenAPI.TagMetadata)
```

##### Target

`Namespace`

##### Parameters

| Name        | Type                                  | Description            |
| ----------- | ------------------------------------- | ---------------------- |
| name        | `valueof string`                      | tag name               |
| tagMetadata | [valueof `TagMetadata`](#tagmetadata) | Additional information |

##### Examples

```typespec
@service
@tagMetadata(
  "Tag Name",
  #{
    description: "Tag description",
    externalDocs: #{ url: "https://example.com", description: "More info.", `x-custom`: "string" },
    `x-custom`: "string",
  }
)
namespace PetStore {

}
```
