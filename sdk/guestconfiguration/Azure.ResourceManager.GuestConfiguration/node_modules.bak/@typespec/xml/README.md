# @typespec/xml

TypeSpec library providing xml bindings

## Install

```bash
npm install @typespec/xml
```

## Decorators

### TypeSpec.Xml

- [`@attribute`](#@attribute)
- [`@name`](#@name)
- [`@ns`](#@ns)
- [`@nsDeclarations`](#@nsdeclarations)
- [`@unwrapped`](#@unwrapped)

#### `@attribute`

Specify that the target property should be encoded as an XML attribute instead of node.

```typespec
@TypeSpec.Xml.attribute
```

##### Target

`ModelProperty`

##### Parameters

None

##### Examples

###### Default

```tsp
model Blob {
  id: string;
}
```

```xml
<Blob>
  <id>abcdef</id>
</Blob>
```

###### With `@attribute`

```tsp
model Blob {
  @attribute id: string;
}
```

```xml
<Blob id="abcdef">
</Blob>
```

#### `@name`

Provide the name of the XML element or attribute. This means the same thing as
`@encodedName("application/xml", value)`

```typespec
@TypeSpec.Xml.name(name: valueof string)
```

##### Target

`unknown`

##### Parameters

| Name | Type             | Description                              |
| ---- | ---------------- | ---------------------------------------- |
| name | `valueof string` | The name of the XML element or attribute |

##### Examples

```tsp
@name("XmlBook")
model Book {
  @name("XmlId") id: string;
  @encodedName("application/xml", "XmlName") name: string;
  content: string;
}
```

```xml
<XmlBook>
  <XmlId>string</XmlId>
  <XmlName>string</XmlName>
  <content>string</content>
</XmlBook>
```

#### `@ns`

Specify the XML namespace for this element. It can be used in 2 different ways:

1. `@ns("http://www.example.com/namespace", "ns1")` - specify both namespace and prefix
2. `@Xml.ns(Namespaces.ns1)` - pass a member of an enum decorated with `@nsDeclaration`

```typespec
@TypeSpec.Xml.ns(ns: string | EnumMember, prefix?: valueof string)
```

##### Target

`unknown`

##### Parameters

| Name   | Type                   | Description                                                                       |
| ------ | ---------------------- | --------------------------------------------------------------------------------- |
| ns     | `string \| EnumMember` | The namespace URI or a member of an enum decorated with `@nsDeclaration`.         |
| prefix | `valueof string`       | The namespace prefix. Required if the namespace parameter was passed as a string. |

##### Examples

###### With strings

```tsp
@ns("https://example.com/ns1", "ns1")
model Foo {
  @ns("https://example.com/ns1", "ns1")
  bar: string;

  @ns("https://example.com/ns2", "ns2")
  bar: string;
}
```

###### With enum

```tsp
@Xml.nsDeclarations
enum Namespaces {
  ns1: "https://example.com/ns1",
  ns2: "https://example.com/ns2",
}

@Xml.ns(Namespaces.ns1)
model Foo {
  @Xml.ns(Namespaces.ns1)
  bar: string;

  @Xml.ns(Namespaces.ns2)
  bar: string;
}
```

#### `@nsDeclarations`

Mark an enum as declaring XML namespaces. See `@ns`

```typespec
@TypeSpec.Xml.nsDeclarations
```

##### Target

`Enum`

##### Parameters

None

#### `@unwrapped`

Specify that the target property shouldn't create a wrapper node. This can be used to flatten list nodes into the model node or to include raw text in the model node.
It cannot be used with `@attribute`.

```typespec
@TypeSpec.Xml.unwrapped
```

##### Target

`ModelProperty`

##### Parameters

None

##### Examples

###### Array property default

```tsp
model Pet {
  tags: Tag[];
}
```

```xml
<XmlPet>
  <ItemsTags>
    <XmlTag>
      <name>string</name>
    </XmlTag>
  </ItemsTags>
</XmlPet>
```

###### Array property with `@unwrapped`

```tsp
model Pet {
  @unwrapped tags: Tag[];
}
```

```xml
<XmlPet>
  <XmlTag>
    <name>string</name>
  </XmlTag>
</XmlPet>
```

###### String property default

```tsp
model BlobName {
  content: string;
}
```

```xml
<BlobName>
  <content>
    abcdef
  </content>
</BlobName>
```

###### Array property with `@unwrapped`

```tsp
model BlobName {
  @unwrapped content: string;
}
```

```xml
<BlobName>
  abcdef
</BlobName>
```
