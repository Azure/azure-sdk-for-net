# Resource Detection — Design

This document defines, at a design level, the rules for turning a TypeSpec
ARM specification into a resource graph: which TypeSpec models are ARM
resources, how each operation is classified, which resource an operation
belongs to, and the desired shape of the resulting schema consumed by the
C# generator.

It is written as a specification of behavior rather than a description of
any particular implementation. Anything compliant with these rules —
regardless of how the code is organized — is a correct implementation. The
C# generator only sees the final `ArmProviderSchema` described in
[*Desired output*](#desired-output) below, and treats it as the source of
truth for "what is a resource, what are its operations, where do they live."

The goal of this design is to produce, from a TypeSpec ARM specification,
the **same set of resources** that the `autorest.bicep` generator
([bicep-types-az](https://github.com/Azure/bicep-types-az)) produces from
the equivalent Swagger specification. `autorest.bicep` is the authoritative
reference for "what is a resource in ARM" because it powers the Bicep type
catalog. The rules below are TypeSpec-specific mechanisms for recovering
the same path-based truth that `autorest.bicep` reads directly off the
URLs.

---

## Ground truth: ARM resources are defined by their paths

ARM defines a resource as an entity addressable by a URL of the form:

```
/<scope>/providers/<namespace>/<type1>/<name1>/<type2>/<name2>/.../<typeN>/<nameN>
```

Everything else about the resource graph follows mechanically from this
shape. The rest of this document is, in effect, instructions for
reconstructing this picture from the TypeSpec model. The path-derived facts
are:

- **Resource identity.** A resource corresponds to one such instance path.
  Two paths that differ in any segment are two different resources.
- **Resource type.** `<namespace>/<type1>/.../<typeN>`. Type segments occupy
  the even positions after `/providers/`; name segments occupy the odd
  positions.
- **Scope.** Determined entirely by the path prefix preceding the final
  `/providers/`:

  | Path prefix | Scope |
  | --- | --- |
  | `/` | `Tenant` |
  | `/providers/Microsoft.Management/managementGroups/{}/` | `ManagementGroup` |
  | `/subscriptions/{}/` | `Subscription` |
  | `/subscriptions/{}/resourceGroups/{}/` | `ResourceGroup` |
  | Any other path ending in another resource instance | `Extension` |

- **Parent chain.** Each `type/{name}` pair after the namespace is one level.
  The parent of `.../typeN-1/{nameN-1}/typeN/{nameN}` is the resource at
  `.../typeN-1/{nameN-1}`. The top-level resource (only one `type/{name}`
  pair after `/providers/`) has no resource parent and sits directly under
  its scope.
- **Singleton.** A trailing name segment that is a literal (constant), not a
  `{variable}`, marks the resource as a singleton with that literal as its
  instance name.
- **Dynamic resource type.** A type segment that is itself a `{variable}`
  whose schema is a closed enum expands into one concrete resource per enum
  value, each inheriting the rest of the path.

In addition, the special case `/subscriptions/{}/resourceGroups/{}` is
treated as if it were `/subscriptions/{}/providers/Microsoft.Resources/resourceGroups/{}`,
so resource groups participate in the same model as every other resource.

The remaining sections describe how each piece of the picture is recovered
from TypeSpec inputs.

---

## Detection algorithm

This section specifies the full procedure end-to-end. The per-aspect
sections that follow give the detail of each step; this one fixes the order
in which they apply and the design principles they all obey.

### Design principles

1. **The path is the source of truth.** The set of ARM resources, their
   types, names, parents, and scopes are derived from operation paths — the
   same way `autorest.bicep` derives them from Swagger URLs. The TypeSpec
   detection algorithm exists to recover that path-based picture; it must
   not invent a different one.
2. **Decorators are hints, not facts.** `Azure.ResourceManager` decorators
   such as `@armResourceOperations`, `@parentResource`, `@singleton`,
   `@customAzureResource` and the operation-kind decorators are convenient
   but routinely misused (wrong target model, copy-pasted parent, singleton
   put on a non-singleton path, kind decorator that disagrees with the
   verb). When a decorator and the path disagree, **the path wins** and a
   diagnostic is emitted. Decorators are useful in three roles only:
   - to discover which TypeSpec model is intended to back a path
     (operation grouping);
   - to choose between candidates when the path alone is ambiguous;
   - to permit the rare case the path cannot express (e.g.
     `@customAzureResource` for legacy base classes).
3. **Identity is synthesized from the path.** Every resource exposes
   `id`, `name`, `type`, and `apiVersion` derived from its path
   descriptor. The body model contributes additional properties only; if
   the body declares one of those four, the synthesized version overrides
   it. (This is exactly what `autorest.bicep` does and is what makes the
   two outputs comparable.)
4. **TypeSpec features are used where they are reliable.** The standard
   ARM templates (`TrackedResource<T>`, `ProxyResource<T>`,
   `ExtensionResource<T>`) and `@armResourceOperations` reliably tell us
   *which model holds the resource's data* and *which operations belong
   together*. They are used for **binding** (path → model, operation →
   group), not for the resource decision itself.

### Steps

The algorithm is a single pass over the TypeSpec service definition,
followed by post-processing.

**Step 1 — Bucket every operation by path and verb.** For each operation
in the service, record its `(lower-cased path, verb, operation-group,
parameters, body model, response model)`. Operations whose required
parameters are not in `path`, `body`, the limited allow-listed `header`
set, or the `api-version` `query` are dropped (they cannot be expressed
as a clean ARM call).

**Step 2 — Decide which paths are resource paths.** A path is a resource
path iff:

1. it is well-formed under the *Ground truth* rules (literal namespace,
   alternating `type/{name}` segments under a recognized scope prefix, or
   the `resourceGroups` special case), **and**
2. **either** the path has a PUT, **or** the path has a GET whose response
   model is recognizable as a resource model (extends one of the standard
   ARM templates, or carries `@customAzureResource` somewhere on its
   inheritance chain).

The PUT branch mirrors `autorest.bicep`'s primary signal. The GET branch
is the TypeSpec equivalent of `autorest.bicep`'s
`x-ms-azure-resource: true` fallback for read-only resources.

If `@armResourceOperations(R)` exists on a group whose path is not a
resource path, emit a diagnostic — the decorator misclassifies a
non-resource path as a resource — and treat the group's operations as
non-resource operations.

**Step 3 — Validate and expand each resource path.** Apply the path
checks from *Ground truth*: the namespace must be a literal; parameterized
type segments (e.g. `/{kind}/{name}`) are accepted only when the
parameter is a closed enum, and each enum value expands into a separate
concrete resource path; non-parameter trailing name segments mark the
path as a singleton.

**Step 4 — Synthesize the resource descriptor.** From the (possibly
expanded) path, build the resource:

- **`resourceType`** — concatenation of the literal type segments after
  the namespace.
- **`scope`** — derived from the path prefix per the
  [scope](#how-resource-scope-is-determined) rules.
- **`parent`** — the resource at the next-shorter `/type/{name}`
  prefix; if that prefix is not itself a resource path, the resource is
  top-level under the scope.
- **`name`** — the schema of the trailing `{name}` parameter (or the
  literal value, for singletons; default `"default"` if `@singleton`
  carries no key).
- **`apiVersion`** — from the operation's API version.
- **`id`/`name`/`type`/`apiVersion` properties** — synthesized from the
  descriptor; always present.

**Step 5 — Bind the resource model.** Choose the TypeSpec model that
contributes the resource's additional properties:

1. The body model of the PUT, if present.
2. Otherwise, the response model of the GET.
3. Otherwise, an empty model — the resource still exists, with only the
   four synthesized properties.

`@parentResource`, `@singleton`, and `@customAzureResource` on the
selected model are consulted as **confirmations** of the path-derived
descriptor. A disagreement is a diagnostic, not an override:

- `@parentResource(P)` whose `P` is not the path-derived parent: warn,
  keep the path-derived parent. The single exception is when the
  path-derived parent was rejected as a non-resource (rare legacy edge
  case); then `@parentResource` may stand in.
- `@singleton(name)` on a path whose trailing segment is a `{variable}`:
  warn, ignore the decorator.
- `@customAzureResource` on a model not used as a PUT body or GET
  response of any resource path: warn, ignore.

**Step 6 — Classify each operation against its owning resource.** For
each operation under a resource path:

- `PUT` → `Create`.
- `PATCH` → `Update`.
- `GET` on the resource path → `Read`.
- `GET` on the parent's collection path (instance path with the trailing
  `{name}` removed) → `List`.
- `DELETE` → `Delete`.
- `POST` whose last path segment starts with `list` → `List` (resource-
  bound list function), unless the [cross-resource list relocation](#cross-resource-list-relocation)
  rule moves it to a different owner.
- Any other `POST` (and any `GET` not covered above) → `Action`.

The operation-kind decorators (`@armResourceCreateOrUpdate`,
`@armResourceRead`, `@armResourceAction`, `@legacyResourceOperation`,
etc.) are honored when they agree with the verb and the path. When they
disagree, the verb wins and the decorator is reduced to a hint for
[reclassification of legacy actions](#reclassification-of-legacy-actions)
— which is the one case where the verb-derived kind is intentionally
overridden because the spec author needed a CRUD-style template that
`RoutedOperations` does not provide.

**Step 7 — Reattach non-resource operations.** Operations whose path is
not a resource path can still be resource-bound. For each such operation,
try in order:

1. **Longest-prefix match** under a resource's instance path → attach as
   `Action` on that resource (path remainder becomes the action name).
2. **Model-id match**: same return model as some resource `R`, and takes
   `R`'s id parameter → attach as `List` on `R`.
3. **Type-tail match**: type tail equals some resource `R`'s type →
   attach as `List` on `R`.

Anything that still does not match is a non-resource (provider) method.

**Step 8 — Filter and merge.**

- Remove any non-singleton resource that has no `Read`. Its operations
  move to the parent (reclassified as `Action`s) or, if it has no parent,
  become non-resource methods. Singletons without a `Read` are kept.
- Collapse duplicate resource entries: when two paths produce the same
  type after enum expansion (e.g. one per `kind` value), union their
  scopes and api versions; when a singleton path and a parameterized
  path share the same parent and type, the parameterized one wins and
  the singleton becomes one of its instances.
- Run [cross-resource list relocation](#cross-resource-list-relocation)
  to move misdeclared list actions onto the correct collection.

**Step 9 — Emit.** Produce the [`ArmProviderSchema`](#desired-output)
the C# generator consumes.

### When TypeSpec features are trusted

| Feature | Trusted for | Verified against | Outcome on conflict |
| --- | --- | --- | --- |
| `TrackedResource<T>` / `ProxyResource<T>` / `ExtensionResource<T>` | "this model represents a resource entity" | The path it backs must be a resource path | Model is not used as a resource binding; warn |
| `@customAzureResource` | Same as above, for legacy base classes | Same | Same |
| `@armResourceOperations(R)` | Operation grouping; the resource's PUT/GET model | `R`'s declared model must equal the binding chosen by the path | Path wins; warn |
| `@parentResource(P)` | Disambiguating parent when path-nesting parent is not a resource | The path-derived parent | Path-derived parent wins; warn |
| `@singleton(name)` | Supplying the singleton instance name | Trailing path segment is a literal | Decorator ignored; warn |
| `@armResourceRead` / `@armResourceCreateOrUpdate` / etc. | Operation-kind hint | Verb + path | Verb wins; warn |
| `@legacyResourceOperation(R, "action")` | Marking an `Action`-by-default template | Verb + body shape | Verb-and-shape rederivation may override (see [reclassification](#reclassification-of-legacy-actions)) |

The principle is uniform: **TypeSpec annotations choose between
otherwise-equal candidates and supply names; they never override the
path**.

---

## What counts as a resource model

A TypeSpec model is the **resource model** for some resource path if it
is bound to that path by Step 5 of the [algorithm](#detection-algorithm).
In practice this is one of:

- The body of a PUT under the path (the most common case, and the only
  one needed for writable resources).
- The response of the GET under the path, when there is no PUT (the
  read-only fallback).

For a model to be eligible as the GET-only fallback, it must be
recognizable as a resource entity:

- It uses one of the standard ARM resource templates
  (`TrackedResource<T>`, `ProxyResource<T>`, `ExtensionResource<T>`). The
  `typespec-azure-resource-manager` library marks these for us.
- Or it (or any model in its inheritance chain) is decorated with
  `@customAzureResource`. This is the escape hatch for legacy services
  such as TrafficManager that define their own base `Resource` model
  rather than using the standard templates.

Note: extending an ARM template **does not by itself make a model a
resource**. A model that extends `TrackedResource<T>` but has no
corresponding well-formed PUT or GET path is just data; conversely, the
PUT body model of a resource path is bound to its path even if it is a
plain object that does not extend any template. This mirrors
`autorest.bicep`: the path decides, the model is the data carrier.

A resource path whose trailing segment is a literal (or whose binding
model is decorated with `@singleton`) is a **singleton resource**. The
`@singleton` decorator may carry a key value used as the resource's
instance name; if none is provided, the name defaults to `"default"`.
Singletons differ from regular resources in only one place: they are
allowed to exist without a `Read` operation (see
[*Resources that get filtered out*](#resources-that-get-filtered-out)).

---

## How an operation is classified

Each operation is mapped to one **operation kind**: `Read`, `Create`,
`Update`, `Delete`, `List`, or `Action`. The classification is decoration-
driven:

| Decorator | Kind |
| --- | --- |
| `@armResourceRead`, `@readsResource` | `Read` |
| `@armResourceCreateOrUpdate` with `PUT` | `Create` |
| `@armResourceCreateOrUpdate` with `PATCH` | `Update` (handles templates such as `Legacy.CreateOrReplaceAsync` overridden with `@patch`) |
| `@armResourceUpdate` | `Update` |
| `@armResourceDelete` | `Delete` |
| `@armResourceList` | `List` |
| `@armResourceAction` | `Action`, **unless** the operation is pageable and its page item is a known resource model — then it is reclassified as `List` (this is what makes templates like `ArmResourceActionSync` that really enumerate children show up correctly) |
| `@extensionResourceOperation(Parent, Resource, kind)` | the explicit `kind` |
| `@legacyResourceOperation(Resource, kind)` / `@legacyExtensionResourceOperation` | the explicit `kind`, with a special case for `"action"` (see below) |
| `@builtInResourceOperation(Parent, BuiltInResource, kind)` | the explicit `kind`. If `kind` is `read` but the operation also has `@action(...)` from `@typespec/rest`, it becomes `Action` — supports patterns like a Read template reused with `@post @action("reconcile")`. |

If no decorator applies, the operation has no kind and is treated as a
**non-resource (provider) method**.

### Reclassification of legacy actions

`RoutedOperations.ActionSync` / `ActionAsync` always carry
`@legacyResourceOperation(Resource, "action")` even when the underlying HTTP
verb is overridden. Because `RoutedOperations` does not provide Read / Get
templates, services sometimes overload these to express true CRUD. We
re-derive the kind from the verb plus the response shape:

| Verb | Response / body shape | Resulting kind |
| --- | --- | --- |
| `GET` | pageable, page item is a resource model | `List` |
| `GET` | response is the resource model | `Read` |
| `PUT` | response or non-path body parameter is the resource model | `Create` |
| `PATCH` | response or non-path body parameter is the resource model | `Update` |
| `DELETE` | response is the resource model, void, or LRO envelope | `Delete` |
| Anything else | — | stays `Action` |

---

## Which resource an operation belongs to

CRUD operations identify their resource directly: the operation's path is the
resource's instance path, and the operation's resource model becomes the
resource's model.

Non-CRUD operations (`List`, `Action`, decorator-less) are not on the
instance path, so we have to attach them. For each non-CRUD operation we look
for an existing resource (built from a CRUD operation in this same pass)
whose model matches, using these rules in order:

1. **Longest-prefix match.** If the operation path is a continuation of an
   existing resource's instance path (after stripping the trailing key
   segment), it belongs to that resource. When several resources qualify, the
   longest match wins. This is what handles multi-scope resources cleanly.
2. **Single type-segment match.** If no prefix matches but exactly one
   resource has the same resource type segment (e.g. the operation is
   `listBySubscription` and there is exactly one resource-group-scoped
   resource of that type), the operation is attached to it. This rule does
   not apply when the operation explicitly named a different resource via the
   template's `ResourceName` parameter — those operations belong to a
   different interface that happens to share the model.
3. **Otherwise, no match.** The operation falls into one of:
   - A standalone entry keyed on its own path, if it is a `List`. Post-
     processing will later try to fold it into a parent.
   - The non-resource (provider) bucket, if it is an `Action` whose path does
     not contain the resource type segment at all (these are really provider
     operations, not resource actions).
   - The non-resource bucket, if there is no decorator and no other signal.

Note: this matching is per-model. An operation is only attached to a resource
whose model matches the operation's resource model.

---

## How resource scope is determined

The scope of a resource is the path prefix before the final `/providers/` in
its instance path, mapped to `Tenant`, `Subscription`, `ResourceGroup`,
`ManagementGroup`, or `Extension` as defined in
[*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths).

In TypeSpec inputs the scope therefore comes from the **`Read` operation's
path**, not from scope decorators on the model. Scope decorators
(`@subscriptionResource`, `@resourceGroupResource`, …) get inherited
implicitly from base templates like `ProxyResource` and may not reflect the
actual scope, especially for extension resources defined with
`Legacy.ExtensionOperations` against a specific parent type. The `Read` path
is the source of truth.

If a resource has no `Read` operation, it falls into the "non-singleton
without Read" case and is removed from the schema (see
[*Resources that get filtered out*](#resources-that-get-filtered-out) below).
Only singletons may legitimately exist without a `Read`.

---

## How a resource's parent is determined

The desired parent relationship is the one defined by the resource's
instance path: each `type/{name}` pair after the namespace is one level of
the chain, and the parent is the resource at the next-shorter prefix. The
following TypeSpec-specific rules exist only to recover that chain when the
spec doesn't write it down explicitly. They are evaluated in order of
precedence (highest first):

1. **Dynamic parent expansion.** If a resource's path contains a dynamic
   parent type segment (e.g. `{parentType}`), the resource is first split
   into one concrete entry per matching parent type. Each concrete copy then
   resolves to its specific parent under the remaining rules.
2. **Path-based inference for shared-model interfaces.** When the same model
   is used by both a parent interface and a child interface (a common
   `LegacyOperations` pattern), the model decorator alone cannot tell them
   apart. In that case the parent is the resource whose instance path is the
   longest prefix of this resource's instance path — i.e. the path-defined
   parent. This rule takes precedence over the `@parentResource` decorator,
   because the decorator is ambiguous when several resources share the same
   model.
3. **`@parentResource` decorator on the model.** If the resource model is
   decorated with `@parentResource(SomeOtherModel)`, that other model is the
   parent. This is normally consistent with the path-based parent; the
   decorator is just an explicit annotation that lets us identify the parent
   resource by model when paths alone would be ambiguous.

If none of the above produces a parent, the resource sits directly under the
scope determined by its `Read` path (e.g. directly on SubscriptionResource).

---

## How a resource is named

The resource's display name — the C# class name root — is chosen as follows:

1. If only one resource uses the model in the entire schema, use the model
   name.
2. Otherwise (multiple interfaces share the model):
   1. Use the explicit `ResourceName` parameter passed to the
      `LegacyOperations` template, if the spec author provided one.
   2. Otherwise, use the singular form of the interface (client) name. For
      example `PublicSharedConfigs` becomes `PublicSharedConfig`.

Resource **name constraints** (`pattern`, `minLength`, `maxLength`) are read
from the `name` property of the resource model and may be overridden via the
`@@clientOption` decorator. **RBAC roles** are likewise extracted from
`@@clientOption`.

---

## Resources that get filtered out

After detection, the resource list is pruned:

- A **non-singleton** resource with no `Read` operation is removed. It cannot
  be represented as a standalone Resource class. Its methods are not thrown
  away:
  - If it has a parent resource, all of its methods move to the parent and
    are **reclassified as `Action`** (regardless of their original kind).
    This avoids name collisions with the parent's own Read / Delete / List
    methods.
  - Otherwise, the methods are demoted to non-resource methods.
- A **singleton** resource without a `Read` is allowed; its methods stay on
  it.

Each removal emits a diagnostic so the spec author sees why a model that
looked like a resource did not become one.

---

## Cross-resource list relocation

Some operations are decorated as actions on resource A but actually return a
paged list of resource B (e.g. `BlobContainer.list` declared on the storage
account but returning containers). The relocation rule:

- The operation's path must be exactly resource B's **collection path** —
  i.e. B's instance path with the trailing `{name}` variable segment removed.
- The page item type must be B's model (a known resource model) and differ
  from A's model.

When both conditions hold, the operation is moved off A and onto B as a
`List`. This keeps list-of-B operations on B's collection regardless of
where the spec chose to declare them.

---

## Reattaching non-resource methods to resources

Once the resource list has been finalized, each remaining non-resource method
is re-examined to see whether it is really resource-bound. A method is
attached to a resource according to the **first** rule below that matches.
The rule that matches also determines the kind the method gets on the
resource:

1. **Longest-prefix path match → `Action`.** If the method's path starts
   with the full instance path of one or more resources (so the method
   clearly hangs off a specific instance, with extra segments describing
   what action or sub-thing it targets), it attaches to the resource with
   the longest matching instance path.
2. **Resource model id match → `List`.** If no prefix matches but the method
   carries a resource model id and a resource with that same model exists,
   the method attaches to that resource as a `List`. This handles extension
   resources whose list path has a different parent structure from the
   resource's instance path.
3. **Trailing resource type segment match → `List`.** If neither of the
   above applies, the method attaches as a `List` to a resource whose
   resource type matches the method's path and whose scope nesting matches,
   provided the method's path ends with the same resource type segment as
   the resource (e.g. `/subscriptions/{}/.../containerGroups`). This is what
   keeps, for example, ContainerInstance's `ContainerGroupsOperationGroup.list`
   / `listByResourceGroup` (declared as `ArmProviderActionSync<...>`) on
   `ContainerGroupCollection` instead of as bogus actions on the singular
   `ContainerGroupResource`.

Methods that match none of the above remain non-resource methods and are
generated as extension methods on SubscriptionResource /
ResourceGroupResource / TenantResource according to their scope.

---

## Desired output

The end state expected by the C# generator is two collections:

- A list of **resources**, each with: model, instance path, resource type,
  scope, parent, name, name constraints, RBAC roles, supported API versions,
  and the methods that belong on it (with their kinds).
- A list of **non-resource methods**, each with operation path and scope, to
  be emitted as extensions on the appropriate scope resource.

This is attached to the root client as the `@armProviderSchema` decorator
and consumed by every later step of the C# generator.
