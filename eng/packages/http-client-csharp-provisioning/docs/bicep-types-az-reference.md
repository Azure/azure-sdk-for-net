# Bicep Types Azure Reference

This document summarizes useful information from the `Azure/bicep-types-az`
repository, with emphasis on the `src/autorest.bicep` tool that generates the
official Bicep resource type references from ARM Swagger.

The purpose of this document is to record how the Bicep reference generator
models resources, scopes, bodies, names, property flags, and discriminators so
that provisioning generator design can use the same concepts where they apply.

---

## Source files

The relevant code is concentrated in these files:

| File | Purpose |
| --- | --- |
| `src/autorest.bicep/src/main.ts` | AutoRest plugin entry point. Reads CodeModel, builds provider definitions, and writes `types.json`, `types.md`, and optionally `schema.json`. |
| `src/autorest.bicep/src/resources.ts` | Detects resource definitions from Swagger operations and paths. Produces provider/resource descriptors. |
| `src/autorest.bicep/src/type-generator.ts` | Converts provider/resource definitions into Bicep type definitions. This is the closest analogue to provisioning type generation. |
| `src/autorest.bicep/src/schema-generator.ts` | Converts provider/resource definitions into ARM template JSON schema. Useful for understanding child-resource schema and writable body behavior. |
| `src/bicep-types/src/types.ts` in `Azure/bicep-types` | Defines the serialized Bicep type model: resource types, object types, discriminated object types, scopes, and property flags. |
| `src/TemplateRefGenerator/Generators/CodeSampleGenerator.cs` in `Azure/template-reference-generator` | Renders the public Bicep sample shown on Microsoft Learn. This is where language-level `parent` and `scope` declaration properties are added to examples. |
| `src/TemplateRefGenerator/Generators/MarkdownGenerator.cs` in `Azure/template-reference-generator` | Renders the public property table shown on Microsoft Learn. This is where language-level `parent` and `scope` metadata rows are added. |

The `autorest.bicep` plugin is Swagger/AutoRest based, not TypeSpec based, but
the concepts it emits are the same concepts visible in the official Bicep
reference.

---

## Overall flow

The plugin flow is:

1. AutoRest provides a CodeModel.
2. `resources.ts` groups operations by API version.
3. `resources.ts` identifies resources and list actions for each provider and
   API version.
4. `type-generator.ts` converts each provider definition into Bicep type
   definitions.
5. `main.ts` writes `types.json` and `types.md`.
6. When configured for ARM schema generation, `schema-generator.ts` writes
   `schema.json` instead.

The central boundary is `ProviderDefinition`:

- `namespace`
- `apiVersion`
- `resourcesByType`
- `resourceActions`

Each `ResourceDefinition` contains:

- a `ResourceDescriptor`;
- optional `putOperation`;
- optional `getOperation`;
- optional examples.

This separation is important. Resource identity is carried by the descriptor,
while body shape is carried by the PUT and GET operations.

---

## Resource descriptors

`ResourceDescriptor` records the resource facts needed by the Bicep type
system:

- provider namespace;
- resource type segments;
- API version;
- readable scopes;
- writable scopes;
- optional constant name.

The fully qualified Bicep resource type is:

```text
<namespace>/<typeSegment1>/.../<typeSegmentN>
```

The final emitted resource name includes the API version:

```text
<namespace>/<typeSegment1>/.../<typeSegmentN>@<apiVersion>
```

The descriptor does not contain the resource body. It identifies a resource
type and the scopes where it can be read or written.

---

## Resource path parsing

Resource paths are parsed around the final `/providers/` segment.

Everything before the final `/providers/` is treated as the parent scope.
Everything after it is treated as the provider namespace and alternating
resource type/name segments.

The resource-group path is special-cased. A Swagger path like:

```text
/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
```

is normalized as if it were:

```text
/subscriptions/{subscriptionId}/providers/Microsoft.Resources/resourceGroups/{resourceGroupName}
```

This lets resource groups fit the same provider/type/name pattern as other
resources.

The parser requires:

- a provider namespace;
- matching counts of type segments and name segments;
- literal provider namespace;
- literal type segments, unless a type segment is parameterized by an enum;
- a final name segment that is either a path parameter or a literal singleton
  name.

When a type segment is a parameterized enum, the tool expands it into one
resource descriptor per enum value. After expansion, resource type strings are
constant.

---

## Scope classification

Scopes are derived from the path prefix before the final `/providers/`.

The tool recognizes:

| Path prefix | Scope |
| --- | --- |
| `/` | Tenant |
| `/subscriptions/{...}/` | Subscription |
| `/subscriptions/{...}/resourceGroups/{...}/` | ResourceGroup |
| `/providers/Microsoft.Management/managementGroups/{...}/` | ManagementGroup |
| another resource path ending before the final provider | Extension |

If the prefix is ambiguous, the AutoRest tool can fall back to all scopes. The
newer TypeSpec management resource-detection design is stricter and treats the
read path as the source of truth.

The important Bicep concept is that readability and writability have separate
scope sets:

- `readableScopes`
- `writableScopes`

These are not the same as a single boolean saying whether a resource is
readable or writable. They are sets of deployment scopes where the resource can
be read or written.

For example:

```text
readableScopes = ResourceGroup | Subscription
writableScopes = ResourceGroup
```

means the resource can be read at resource-group or subscription scope, but can
be written only at resource-group scope.

The path prefix determines the scope value. The operation kind determines which
scope set receives that value:

- GET contributes the derived path scope to `readableScopes`;
- PUT contributes the derived path scope to `writableScopes`.

A resource may therefore be readable but not writable, or readable at different
scopes than it is writable.

---

## GET and PUT drive resource definitions

For each API version, `resources.ts` first gathers GET and PUT operations by
path.

A resource definition is created from:

- a PUT operation, if one exists for the path; or
- a GET operation, if it returns a schema marked as an Azure resource.

The descriptor's readable and writable scopes are set independently:

- GET contributes readable scope;
- PUT contributes writable scope.

For the common case where the same resource path has both PUT and GET, the tool
creates one resource definition for that path and API version. The PUT operation
provides the deployable/writable side, while the GET operation provides the
readable/reference side.

The resulting body is synthesized from both shapes:

- PUT says what can be authored in a Bicep declaration;
- GET says what can be read back from the resource;
- the path says the resource identity, type, and scope.

This means Bicep can represent resources such as read-only resources whose
`Writable Scope(s)` are `None`.

The provisioning generator should take the same distinction seriously. A
resource type can be valid for reference/read output even if it is not
deployable through a normal declaration.

The AutoRest Bicep tool therefore determines ARM resources mostly from
operation path and operation shape:

1. If a path has a valid PUT operation, the path is treated as a deployable
   resource path.
2. If a path has no PUT but has a GET whose response schema is marked with
   `x-ms-azure-resource`, the path is treated as a readable resource path.
3. If a GET has no matching PUT and does not return an Azure resource schema,
   it is treated as a collection or utility endpoint and no resource type is
   generated from it.
4. Required parameters outside accepted ARM locations can cause the operation
   to be skipped.

This is different from the TypeSpec management resource-detection design,
which uses Read existence as the primary signal for .NET management resources.
The official Bicep reference can contain PUT-only or GET-only resources because
it models deployability and readability separately.

---

## Resource type determination

The resource type is derived from the resource path, not from the model name.

After the final `/providers/` segment, the first segment is the provider
namespace. The remaining segments are interpreted as alternating
`type/name/type/name` pairs. The resource type is:

```text
<namespace>/<type1>/<type2>/.../<typeN>
```

For example:

```text
/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Web/sites/{site}
```

becomes:

```text
Microsoft.Web/sites
```

and:

```text
/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Web/sites/{site}/slots/{slot}
```

becomes:

```text
Microsoft.Web/sites/slots
```

If a type segment is parameterized, the parameter must be an enum. The tool
expands the resource into one descriptor per enum value. This means the final
resource type emitted by Bicep is always concrete.

The generated Bicep type name adds the API version:

```text
Microsoft.Web/sites@2024-04-01
```

---

## Multiple operations with the same resource type

`resources.ts` groups resource definitions by fully qualified resource type.
Several paths can therefore produce definitions for the same resource type.

The tool has two collapse phases:

1. It groups definitions by resource type and tries to collapse partially
   constant-name resources at the same normalized path.
2. It collapses definitions with the same constant name by merging readable and
   writable scope flags.

The partially constant-name collapse handles a common pattern where several
constant-name resources and one parameterized-name resource share the same
path prefix and comparable request/response schemata. In that case the tool
keeps the parameterized definition and merges the scopes from all variants.

If multiple definitions remain for the same resource type, both
`type-generator.ts` and `schema-generator.ts` require every remaining
definition to have a constant name. When that is true, the resource type is
represented as a name-discriminated resource body. The discriminator is `name`.

Conceptually:

```text
Microsoft.Web/sites/basicPublishingCredentialsPolicies
  name = 'ftp'
  name = 'scm'
```

becomes one Bicep resource type with multiple body variants keyed by `name`.

If multiple definitions remain for the same resource type and any definition
does not have a constant name, the tool skips that resource type and emits a
warning. This protects the Bicep reference from ambiguous resource bodies for a
single type.

This behavior is important for provisioning because "different GET operations
produce the same resource type" does not always mean separate resource
classes. If the resource type is the same and the variants are distinguished
by constant names, Bicep models them as variants of one resource type.

---

## Resource name handling

The resource name is extracted from the final path segment.

If the final segment is a path parameter, the tool finds the corresponding
parameter and uses its schema as the name type. If the final segment is a
literal string, it is treated as a constant singleton name.

There are different details for `types.json`/`types.md` and JSON schema output:

- In `type-generator.ts`, a path name parameter becomes a fixed string literal
  only when it is a constant. A single-value sealed enum is often converted to a
  constant earlier by modelerfour. A single-value extensible enum remains an
  open enum, so the Bicep type is the listed literal plus `string`.
- In `schema-generator.ts`, `tryGetConstantName` treats both `ChoiceSchema` and
  `SealedChoiceSchema` with exactly one string choice as a constant name. This
  behavior applies even when the enum is extensible.
- For a multi-value enum name parameter, the JSON schema `name` property is
  emitted as `type: string` with an `enum` array. The JSON schema generator has
  a TODO for open enums and does not preserve `modelAsString: true` by adding
  arbitrary `string`.

`type-generator.ts` also reconciles PUT and GET name shapes because they can
differ. For example, PUT may restrict names with an enum while GET may return a
plain string. The generated Bicep name type is the union of the useful literal
and schema information from both sides.

This is why singleton or constrained names in the Bicep reference are visible
as literal name types such as:

```text
name: 'default'
name: 'web'
```

---

## Standard resource properties

Every Bicep resource body gets standardized resource properties:

| Property | Bicep flags |
| --- | --- |
| `id` | `ReadOnly`, `DeployTimeConstant` |
| `name` | `Required`, `DeployTimeConstant` |
| `type` | `ReadOnly`, `DeployTimeConstant` |
| `apiVersion` | `ReadOnly`, `DeployTimeConstant` |

The `type` property is a string literal for the fully qualified resource type.
The `apiVersion` property is a string literal for the API version.

These properties are added by the Bicep type generator independently of the
Swagger body model. They are resource metadata, not ordinary model properties.

---

## Parent determination

The AutoRest Bicep type model does not store an explicit parent resource
reference in `ResourceDescriptor`.

Parent information is implicit in the resource type segments and in the path
shape. A resource whose type has multiple type segments is structurally a child
resource type:

```text
Microsoft.Web/sites/slots
```

has the structural parent type:

```text
Microsoft.Web/sites
```

For `types.json` and `types.md`, the generated `ResourceType` records only:

- resource type name;
- body type;
- readable scopes;
- writable scopes;
- resource functions.

It does not record a parent pointer.

The public Microsoft Learn Bicep reference can still show a `parent` property.
For example, `Microsoft.KeyVault/vaults/secrets` is shown as:

```bicep
resource symbolicname 'Microsoft.KeyVault/vaults/secrets@2025-05-01' = {
  parent: resourceSymbolicName
  name: 'string'
  ...
}
```

That `parent` row is not emitted from the provider resource body in
`types.json` or `types.md`. It is added by `Azure/template-reference-generator`
when rendering public documentation. The docs generator checks whether the
unqualified resource type contains `/`. If so, the resource is treated as a
child resource and the Bicep sample/property table receives a language-level
`parent` declaration property.

So:

- `types.json` / `types.md` do not contain a provider body `parent` property;
- public Bicep reference docs show `parent` for structural child resources;
- ARM template reference does not show `parent`, because parentage is expressed
  by resource type/name structure.

For ARM JSON schema generation, `schema-generator.ts` processes resources in
parent-before-child order. When a resource has more than one type segment, it
drops the final type segment to compute the immediate structural parent type.
If that parent schema has already been generated, it adds the child schema
under the parent's `resources` property.

For a nested child-resource schema, the emitted `type` property is only the
final child segment. For a top-level resource schema, the emitted `type`
property is the full resource type.

This parent behavior is structural and immediate. The AutoRest schema
generator does not walk upward through skipped intermediate resource types. If
the immediate structural parent is not generated, the child is still a
resource type, but it is not nested under that missing parent in the generated
JSON schema.

This differs from the TypeSpec management resource-detection design, which
explicitly resolves parent relationships by matching instance paths and can
skip missing intermediate resources.

---

## Scope in generated schemas

There are two different notions of scope in the Bicep outputs.

In `types.json` / `types.md`, scope is represented as readable and writable
scope flags on the resource type:

- `readableScopes`
- `writableScopes`

These flags are displayed in `types.md` as:

```text
Readable Scope(s): ResourceGroup
Writable Scope(s): ResourceGroup
```

In ARM JSON schema output, `schema-generator.ts` does not add a `scope`
property to each generated resource schema. Instead, it classifies resource
definitions into top-level schema buckets according to writable scope:

| Writable scope | JSON schema bucket |
| --- | --- |
| ResourceGroup | `resourceDefinitions` |
| Subscription | `subscription_resourceDefinitions` |
| ManagementGroup | `managementGroup_resourceDefinitions` |
| Tenant | `tenant_resourceDefinitions` |
| Extension | `extension_resourceDefinitions` |
| None | `unknown_resourceDefinitions` |

So, in the AutoRest Bicep schema generator, a resource does not gain a
provider-specific `scope` property because it is an extension resource. It is
placed in the extension-resource bucket. Any language-level `scope` property
used by Bicep source is handled outside these provider-specific schemas.

Child resource schemas are also not scoped by a `scope` property. They are
nested under a parent's `resources` array when the immediate parent schema is
available.

The public Microsoft Learn Bicep reference can still show a `scope` property.
This is also added by `Azure/template-reference-generator`, not by the
provider-specific resource body in `types.json` or `types.md`.

The docs generator uses this rule for the Bicep sample and property table:

1. If the unqualified resource type is a child resource, show `parent`.
2. Otherwise, if `writableScopes` contains `ScopeType.Extension`, show `scope`.

The generated sample value is:

```bicep
scope: resourceSymbolicName or scope
```

and the property table text says to use it when creating a resource at a scope
different than the deployment scope, especially for extension resources.

This means the `scope` declaration property in the public Bicep reference is
specifically tied to writable extension-resource scope. It is not shown merely
because a resource has multiple writable deployment scopes. The deployment
target list at the top of the page uses all writable scopes, but the actual
`scope:` property row follows the extension-resource rule above.

---

## Property flags

The Bicep type system has these object property flags:

- `Required`
- `ReadOnly`
- `WriteOnly`
- `DeployTimeConstant`
- `Identifier`

`type-generator.ts` computes property flags from PUT and GET property
presence, requiredness, `readOnly`, and `x-ms-mutability`.

The core rules are:

- property required in PUT means `Required`;
- property missing from PUT, or marked read-only in PUT, means `ReadOnly`;
- property missing from GET means `WriteOnly`;
- `x-ms-mutability` can override read/write interpretation;
- standard resource metadata gets `DeployTimeConstant`.

This is more precise than using only a read response model. A property can be
writable, read-only, or write-only depending on how it appears across request
and response shapes.

---

## Body model synthesis

`type-generator.ts` synthesizes the resource body from PUT and GET schemas.

The generator starts with standardized resource properties, then adds
properties from the union of PUT and GET object properties. Each property's
type is parsed from the available schema. Each property's flags are computed
from the PUT/GET comparison.

When only one schema is available, that schema is used for both sides unless
the object is synthetic or is being generated as a discriminator subtype. This
prevents reused shared models from accidentally becoming read-only or
write-only simply because one resource uses only one side of the shape.

This is a useful distinction for provisioning:

- resource bodies need request/response semantics;
- reusable supporting models should not inherit incorrect read/write semantics
  from one usage.

---

## Object and primitive type conversion

The Bicep type generator maps Swagger schemas into Bicep type references:

| Swagger schema | Bicep type concept |
| --- | --- |
| object | object type |
| dictionary | object type with additional properties |
| array | array type |
| choice / sealed choice | union of string literals, with open enum adding `string` |
| constant | string literal |
| string / uri / date / uuid / arm-id | string type with constraints where available |
| integer / number | integer type with min/max where possible |
| boolean | boolean type |
| any | any type |

String constraints such as minimum length, maximum length, pattern, and secret
metadata are preserved when available. Integer bounds are preserved where
possible.

This is relevant because official Bicep references are richer than a plain
C#-type projection. They carry literal values, unions, string constraints, and
array length constraints.

---

## Discriminated object types

The Bicep type model has an explicit `DiscriminatedObjectType`:

- name;
- discriminator property name;
- base properties;
- map from discriminator value to subtype body.

`type-generator.ts` handles polymorphic object schemas by flattening all
discriminator subtypes. Nested discriminators are flattened only when they use
the same discriminator property. If a subtype has a discriminator value, the
generator adds the discriminator property to that subtype as a required string
literal.

This means a discriminator value is represented as part of the serialized
object body, not just as a C# inheritance detail.

For resource bodies, this can produce Bicep reference sections where the
resource type is discriminated by a property such as `name`.

---

## Multiple definitions for the same resource type

The AutoRest tool can produce multiple `ResourceDefinition` entries for the
same fully qualified resource type.

This happens most visibly for singleton variants that share the same resource
type but have different constant names or different bodies.

When all definitions for the same resource type have constant names, the Bicep
generator represents them as a discriminated body keyed by `name`. The
generated reference then shows a single resource type with a discriminator and
multiple variant bodies.

This is useful for provisioning because a resource variant may be a body
variant of one detected resource type rather than a separate ARM resource type.

---

## Child resource schema

`schema-generator.ts` contains logic that is useful for understanding how
Bicep ARM schema represents child resources.

Resources are processed in parent-before-child order. When a resource type has
more than one type segment, the schema generator looks for the parent resource
type by dropping the final type segment. If the parent has already been
generated, the child is added under the parent's `resources` property as a
nested child-resource schema definition.

For nested child definitions, the emitted child `type` property uses only the
final child type segment. For top-level definitions, the emitted `type`
property uses the full resource type.

This distinction is schema-specific, but it reinforces the Bicep concept that
resource type and parent relationship are path-derived.

---

## Resource actions

`resources.ts` recognizes POST operations whose final path segment starts with
`list` as resource list actions.

These are emitted as Bicep resource functions by `type-generator.ts` through
`factory.addResourceFunctionType`. A resource function has:

- action name;
- resource type;
- API version;
- output type;
- optional input type.

This is not the same as a deployable resource property. Actions are callable
functions associated with resource types.

The current provisioning resource design may not need to expose all Bicep
resource functions immediately, but the distinction is important when deciding
whether a method contributes to body shape, resource identity, or auxiliary
resource functionality.

---

## Generated reference shape

The generated `types.md` reference shows resource information in this shape:

```text
## Resource Microsoft.Web/sites@2024-04-01
* Readable Scope(s): ResourceGroup
* Writable Scope(s): ResourceGroup
### Properties
* apiVersion: '2024-04-01' (ReadOnly, DeployTimeConstant)
* id: string (ReadOnly, DeployTimeConstant)
* name: string (Required, DeployTimeConstant)
* type: 'Microsoft.Web/sites' (ReadOnly, DeployTimeConstant)
```

For read-only resources, writable scopes can be `None`.

For singleton resources, `name` can be a string literal.

For discriminated resource bodies, the reference shows a discriminator section
and one body per discriminator value.

These are the visible outcomes that provisioning generation should align with
where the C# provisioning model has equivalent concepts.

---

## Useful concepts for provisioning

The most useful concepts to carry into provisioning design are:

1. Resource identity is descriptor-based: provider namespace, type segments,
   API version, scope, and name.
2. Resource body shape is operation-based: PUT and GET shapes are compared.
3. Readable and writable scopes are separate capabilities.
4. Standard resource metadata has fixed semantics independent of body models.
5. Property flags require more information than `readOnly` on one model.
6. Constant names should become fixed identity values; single-value enum
   handling differs between Bicep type output and JSON schema output.
7. Discriminators are serialized body semantics, not just type inheritance.
8. Multiple definitions for one resource type can become a name-discriminated
   resource body.
9. Child resources and extension resources are path-derived.
10. Resource actions are separate from resource bodies.

The provisioning generator does not need to copy the AutoRest implementation,
but these concepts explain why the official Bicep reference differs from a
simple management-model projection.
