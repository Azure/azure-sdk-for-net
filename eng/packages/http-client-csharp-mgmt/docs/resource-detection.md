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
a resource graph that conforms to the **.NET management SDK contract**.
That contract imposes constraints absent from the generic ARM definition:

- A resource is represented in the SDK by a `Resource` class whose model
  carries an `id` property — the resource is **identified by id**, and
  every operation that returns a resource must return one with `id`
  populated.
- A resource client must expose a **`Get`** method backed by a service
  `Read` operation. Without it the SDK has no way to materialize a
  `Resource` instance from an id; the resource is therefore unusable.

Consequently the algorithm below uses **Read existence** as the primary
signal. `autorest.bicep`-style "create-only" or "extension-only"
resources (write-only or marked solely by `x-ms-azure-resource` on a
GET-of-something-else) do not apply to us: a model with no `Read` is not
a resource in the .NET mgmt sense, regardless of how it is decorated.

`autorest.bicep` ([bicep-types-az](https://github.com/Azure/bicep-types-az))
remains useful as a sanity-check reference for "what shape is an ARM
resource", and the path-derived facts in [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths)
below are the same ones it relies on. The detection algorithm itself is
TypeSpec-specific.

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
- **Scope.** Determined entirely by the path prefix preceding the
  resource's own `/providers/<namespace>/...` segments. An instance path
  can contain more than one `/providers/<namespace>/` portion (extension
  resources are anchored on another resource which itself starts with a
  `/providers/...`), so the relevant split is the **last** occurrence of
  `/providers/<namespace>/<type>/...` in the path — everything before it
  is the scope:

  | Path prefix (before the last `/providers/`) | Scope |
  | --- | --- |
  | `/` | `Tenant` |
  | `/providers/Microsoft.Management/managementGroups/{}/` | `ManagementGroup` |
  | `/subscriptions/{}/` | `Subscription` |
  | `/subscriptions/{}/resourceGroups/{}/` | `ResourceGroup` |
  | Any other prefix that is itself another resource's instance path | `Extension` |

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

Detection runs in four stages:

1. **Identify resource models** by their TypeSpec annotation.
2. **Identify resource instance paths, scopes, and CRUD operations** by
   finding, for each resource model, the service `Read` that
   materializes it. The `Read` fixes the resource's instance path
   (which also determines its scope); the other CRUD verbs on the same
   path attach to the resource by **verb**, not by decorator.
3. **Resolve parent relationships** among the detected resources by
   matching instance paths against each other.
4. **Assign every remaining operation** to a resource as `List` or
   `Action` — or to the non-resource bucket — by matching path and
   model.

### Resource operation kinds

`ResourceOperationKind` is defined relative to the resource that owns the
method. Each kind describes an operation on the **enclosing resource**, not
just the HTTP shape of the operation:

| Kind | Meaning |
| --- | --- |
| `Read` | Gets the enclosing resource. This operation materializes the SDK resource instance. |
| `Create` | Creates or replaces the enclosing resource. |
| `Update` | Updates the enclosing resource. |
| `Delete` | Deletes the enclosing resource. |
| `List` | Lists all available instances of the enclosing resource under a scope or parent collection. |
| `Action` | Invokes an action on the enclosing resource. This includes operations that are HTTP `GET`/pageable in protocol terms but are not listing the enclosing resource itself. |

For example, an operation on `ParentResource` that returns a collection of
`Sku` models is not `ParentResource.List`; it is an `Action` on
`ParentResource` because it lists something other than parent resources.
Likewise, an operation declared in an `Employees` interface that returns
`Employee[]` is not a `List` unless `Employee` is a detected resource in the
schema. If `Employee` has no `Read`, then `Employee` is not a resource and
that operation attaches to the nearest detected holder as an `Action`.

### Design principles

1. **A resource must have a Read.** A model without a corresponding
   `Read` is not a resource, regardless of annotations. This is dictated
   by the .NET mgmt SDK contract (see the intro). Singletons are no
   exception.
2. **The Read fixes the resource's instance path.** Once we know the
   `Read`'s path, the resource's type, scope, parent chain, name
   parameter, and instance-singletonness all follow from the path under
   [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths).
3. **Verbs determine CRUD kinds, not decorators.** Operation-kind
   decorators (`@armResourceRead`, `@armResourceCreateOrUpdate`,
   `@armResourceUpdate`, `@armResourceDelete`, `@armResourceList`,
   `@armResourceAction`, `@legacyResourceOperation(_, kind)`, etc.) are
   **not consulted** during detection. They are routinely misused; the
   verb and the operation's relationship to the resource's instance
   path/collection path/model are the truth.
4. **Annotations identify; paths and verbs classify.** The resource
   templates (`TrackedResource<T>`, `ProxyResource<T>`,
   `ExtensionResource<T>`) and `@customAzureResource` are trusted in
   **Step 1** to pick out which TypeSpec models are intended to be
   resource entities. Everything from Step 2 onward — what is a
   resource, what the resource's CRUD shape is, what its parent and
   scope are — is decided by paths and verbs.

### Step 1 — Identify resource models

Walk every TypeSpec model. A model is a **candidate resource model** if
either holds:

- It uses one of the standard ARM resource templates —
  `TrackedResource<T>`, `ProxyResource<T>`, `ExtensionResource<T>`. The
  `typespec-azure-resource-manager` library annotates these for us.
- It (or any ancestor in its inheritance chain) is decorated with
  `@customAzureResource`. This is the escape hatch for legacy services
  (e.g. TrafficManager) that define their own base `Resource` model
  rather than using the standard templates.

Every other model is data. A candidate model becomes a resource only if
Step 2 finds a `Read` for it.

### Step 2 — Identify resource paths and CRUD operations

For each candidate resource model `M` from Step 1:

1. **Find the `Read`.** Scan every operation in the service for a `GET`
   whose response is exactly `M` (not a collection-of-`M`, not a
   wrapper). For each such GET, run the path through the validation
   below. The GET is the resource's `Read`; its path is the resource's
   **instance path**. Multiple GETs returning `M` from different
   well-formed paths are not an error — each well-formed path defines a
   separate resource. This is how the same model can legitimately back
   resources at different scopes.

2. **Validate the path.** A resource's instance path must conform to
   the [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths)
   shape. Walk the path and check, in order:

   1. The path contains at least one `/providers/<namespace>/...`
      segment. The split point is the **last** occurrence of
      `/providers/`. Everything before it is the *scope prefix*;
      everything after it (starting with `<namespace>`) is the
      *resource-typed tail*. As a special case, a path that ends in
      `/subscriptions/{}/resourceGroups/{name}` is treated as if it
      were
      `/subscriptions/{}/providers/Microsoft.Resources/resourceGroups/{name}`
      so the resource-group resource fits the same shape as everything
      else.
   2. `<namespace>` must be a **literal** (e.g. `Microsoft.Foo`). A
      parameterized namespace (`/providers/{nsName}/...`) is rejected.
   3. After the namespace, segments must alternate
      `type1/name1/type2/name2/...` and end on a name. The numbers of
      type segments and name segments must match; an unmatched trailing
      `/type` (no name) is rejected.
   4. Each **type** segment is normally a literal. It may instead be a
      `{variable}` parameter, but only when that parameter is a closed
      enum (a sealed/closed `union` of string literals) with at least
      one value. Any other parameterized type segment — including
      `string`-typed `{variable}` type segments — is rejected.
   5. Each **name** segment is either a literal (the resource is a
      singleton; the literal becomes its constant name) or a
      `{variable}` parameter (the resource has a parameterized name).
   6. The scope prefix must match one of the recognized shapes:

      | Scope prefix | Scope |
      | --- | --- |
      | empty / `/` | `Tenant` |
      | `/subscriptions/{}/` | `Subscription` |
      | `/subscriptions/{}/resourceGroups/{}/` | `ResourceGroup` |
      | `/providers/Microsoft.Management/managementGroups/{}/` | `ManagementGroup` |
      | any other prefix that contains at least one `/providers/<namespace>/<type>/<name>` pair (i.e. looks like another resource's instance path) | `Extension` |

      Any prefix that doesn't fit one of these patterns is rejected.
      The `Extension` case is only **provisionally** classified here —
      [Step 3](#step-3--resolve-parent-relationships) verifies the
      prefix is actually a detected resource's instance path and
      identifies which resource the extension is anchored on.

   Any path that fails one of these checks is rejected with a
   diagnostic naming the offending segment, and the corresponding GET
   does **not** make `M` a resource. If every GET returning `M` is
   rejected, `M` has no `Read` and falls through to the
   [no-`Read` diagnostic](#step-2--identify-resource-paths-and-crud-operations)
   in sub-step 6 below.

3. **Expand dynamic resource types.** If any **type** segment of the
   validated path is a closed-enum `{variable}`, expand the path into
   one concrete resource per enum value, substituting the value into
   that segment. If multiple type segments are dynamic, take the
   cross-product. After expansion **every resource has a fully
   constant resource type** (`<namespace>/<type1>/.../<typeN>` with no
   variables in the type positions); all subsequent steps operate on
   the expanded resources.

4. **Derive the path-based facts intrinsic to each (expanded)
   resource.** Apply
   [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths)
   to the instance path to obtain `resourceType`, the trailing `{name}`
   parameter (or the literal singleton name), the `apiVersion`, and
   the `scope` from the prefix as classified in sub-step 2.6 above.
   See [*How a resource is named*](#how-a-resource-is-named). The
   resource's `parent` is resolved in
   [Step 3](#step-3--resolve-parent-relationships) once the full
   resource set is known.

5. **Attach CRUD operations by verb.** For every other operation in
   the service whose path equals the resource's instance path:

   | Verb | Kind |
   | --- | --- |
   | `PUT` | `Create` |
   | `PATCH` | `Update` |
   | `DELETE` | `Delete` |

   Operation-kind decorators are not consulted. If two operations of
   the same kind hit the same path, emit a diagnostic and pick the one
   whose model matches the resource model. When the resource came from
   a dynamic-type expansion, each expanded resource attaches the
   operations that hit *its* concrete path (i.e. with the same enum
   substitution).

6. **Diagnostic if no `Read` exists.** A candidate model with no
   well-formed GET is not a resource. Emit a diagnostic naming the
   model; the spec author either forgot the `Read`, or the model was
   wrongly annotated as a resource.

After Step 2, the resource set is fixed: a list of resources each with
`{ model, instance path, type, name, apiVersion, scope,
Read [, Create] [, Update] [, Delete] }`, where `type` is fully
constant. `parent` is filled in by Step 3.

### Step 3 — Resolve parent relationships

Parent cannot be settled before Step 2 is complete, because it depends
on whether *another* path in the resource set is a resource instance
path: a candidate is a parent only if it matches one of

- a resource detected in Step 2 (defined in the current library), or
- a **predefined** ARM resource — `Microsoft.Resources/resourceGroups`,
  `Microsoft.Resources/subscriptions`,
  `Microsoft.Management/managementGroups`, or the tenant —
  which the .NET mgmt SDK already provides as
  `ResourceGroupResource` / `SubscriptionResource` /
  `ManagementGroupResource` / `TenantResource`.

Call the union of these two sets the **known resource set**. For each
resource `R` from Step 2, walk up the path until either a known
resource is hit or the path is no longer a resource path:

1. Let `path = R.instancePath`.
2. Trim the trailing `/<type>/<name>` pair from `path`.
3. If the result matches some `P` in the known resource set, then `P`
   is `R`'s parent — stop.
4. Otherwise, if the result still contains a `/<type>/<name>` pair
   *after* the last `/providers/<namespace>/` in the path (i.e. there
   is at least one more type/name level we can strip while still
   sitting inside the same provider's resource tree), set
   `path` = result and go to step 2.
5. If we have stripped everything down to (and including) the last
   `/providers/<namespace>/`, stop: `R` has no resource parent. It
   sits directly under its scope (as classified in
   [Step 2](#step-2--identify-resource-paths-and-crud-operations)).

This handles specs that skip intermediate resources in the chain: if
`R`'s instance path is
`/.../providers/Microsoft.Foo/a/{}/b/{}/c/{}` and only `a/{}` is
detected as a resource (no resource defined for `a/{}/b/{}`), then
`R`'s parent is `a/{}`, not nothing.

#### Tuple resources

When the walk above strips **more than one** `/type/{name}` pair
before finding a parent (or before running out of path), `R` is a
**tuple resource**: from its parent/scope's point of view, `R` is
addressed by an ordered tuple of names, not by a single name.

Concretely, if the walk strips `k` pairs
`(typeN/nameN, typeN-1/nameN-1, …, typeN-k+1/nameN-k+1)` before
matching parent `P` (or the scope), then `R`'s identity relative to
`P` is the tuple `(typeN-k+1 = nameN-k+1, …, typeN = nameN)`. All
`k` types are part of `R`'s `resourceType`
(`<namespace>/typeN-k+1/.../typeN`) and all `k` name parameters
belong to `R`'s instance.

Mark such a resource as a tuple resource and record its tuple of name
parameters. A non-tuple resource is just the `k = 1` case.

A consistency check for `Extension`-scoped resources: when `R.scope`
is `Extension`, the prefix before the **last** `/providers/` in `R`'s
instance path must also match some known resource (the resource `R`
extends). If no match is found, emit a diagnostic — `R` was
provisionally classified as `Extension` in Step 2 but isn't actually
anchored on any known resource.

See [*How a resource's parent is determined*](#how-a-resources-parent-is-determined)
for additional rules covering dynamic parent expansion and the
shared-model / `@parentResource` decorator cases.

`@parentResource(P)` and the scope-marker decorators
(`@subscriptionResource`, `@resourceGroupResource`, etc.) are
consulted only as fallback / disambiguation in the cases the
per-aspect sections spell out; the path-derived parent and scope take
precedence.

### Step 4 — Assign remaining operations

Every operation not consumed in Step 2 is now assigned to either a
resource or a known scope, using two passes:

#### Pass 1 — Identify `List`s

For each remaining operation `O`:

1. If `O`'s verb is not `GET`, skip — it cannot be a `List`.
2. If `O`'s response is not a collection of some item model `T`,
   skip — it cannot be a `List`.
3. Otherwise, look for a resource `R` in the **detected resource set** such that
   both:
   - `O.path` is a prefix of `R.instancePath`, and
   - `R.model == T`.

   If at least one such `R` exists, attach `O` to the resource with
   the **shortest** matching `instancePath` as `R.List`. (The shortest
   match is the closest containing resource whose model is `T` — i.e.
   `R` itself, not some deeper resource that happens to also be of
   model `T`.)
4. If no such `R` exists, `O` falls through to Pass 2.

#### Pass 2 — Everything else is an `Action`

Each remaining operation `O` (anything that didn't become a `List` in
Pass 1) is treated as an `Action`. Find the **longest** instance path
that is a prefix of `O.path` among:

- all detected resources from Step 2, and
- the predefined scope resources — `TenantResource`,
  `SubscriptionResource`, `ResourceGroupResource`,
  `ManagementGroupResource`.

`O` attaches as an `Action` on whichever holder owns that longest
prefix. The path tail past the prefix forms the action name. If no
prefix matches at all — the operation lives entirely outside the
known resource hierarchy — emit it as a non-resource method on the
matching `ArmResource` extension or the appropriate scope resource,
according to its scope prefix.

> Notes on what is intentionally **not** considered in Step 4:
>
> - Operation-kind decorators such as `@armResourceList` or
>   `@armResourceAction`. The combination of verb, response shape,
>   and path relationship is what classifies an operation.
> - `@armResourceOperations(R)` as authoritative ownership. The
>   decorator is a useful starting hint (it tells us which operations
>   the spec author meant to associate with `R`'s group), but Step 4
>   does not require the operation to be in `R`'s group to attach it
>   to `R`. A list-of-containers operation declared inside the
>   storage-account group still ends up on the container resource.

---

## How resource scope is determined

The scope of a resource is the path prefix before the **last** `/providers/`
in its instance path, mapped to `Tenant`, `Subscription`, `ResourceGroup`,
`ManagementGroup`, or `Extension` as defined in
[*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths).
The "last `/providers/`" qualifier matters because an instance path may
contain several `/providers/<namespace>/` blocks — for example, an
extension resource on top of another provider's resource — and only the
final block belongs to the resource itself; everything before it is the
scope.

In TypeSpec inputs the scope therefore comes from the **`Read` operation's
path**, not from scope decorators on the model. Scope decorators
(`@subscriptionResource`, `@resourceGroupResource`, …) get inherited
implicitly from base templates like `ProxyResource` and may not reflect the
actual scope, especially for extension resources defined with
`Legacy.ExtensionOperations` against a specific parent type. The `Read` path
is the source of truth.

If a resource has no `Read` operation, it was never detected as a
resource in the first place (see [Step 2](#step-2--identify-resource-paths-and-crud-operations))
— it produces a diagnostic but does not appear in the schema.

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

Under [*Detection algorithm*](#detection-algorithm), a candidate resource
model that has no service `Read` returning it is not detected as a
resource at all — Step 2 emits a diagnostic naming the model. This is
true for singletons as well, because the .NET mgmt SDK contract requires
every resource client to have a `Get` method (see the introduction).

In addition, a detected resource is removed during post-processing if
**all** of the following hold after Step 4 has run:

- It has no `Create`, no `Update`, no `Delete`.
- After [Step 4](#step-4--assign-remaining-operations), no `List` or
  `Action` is attached to it.

Such a resource has only a `Read` and nothing else — it is a path stub
with no behavior. Its `Read` is demoted to a non-resource method (an
extension on the appropriate scope resource).

Each removal emits a diagnostic so the spec author sees why a model that
looked like a resource did not become one.

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
