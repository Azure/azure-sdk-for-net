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
2. **Identify resource instance paths and CRUD operations** by finding,
   for each resource model, the service `Read` that materializes it. The
   `Read` fixes the resource's instance path; the other CRUD verbs on
   the same path attach to the resource by **verb**, not by decorator.
3. **Resolve parent relationships and scopes** among the resources by
   matching instance paths against each other.
4. **Assign every remaining operation** to a resource as `List` or
   `Action` — or to the non-resource bucket — by matching path and
   model.

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
   wrapper). For each such GET:
   - Validate its path under [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths)
     (literal namespace; alternating `type/{name}` segments; recognized
     scope prefix or the `resourceGroups` special case). Reject ill-
     formed paths with a diagnostic.
   - The GET is the resource's `Read`; its path is the resource's
     **instance path**.
   - Multiple GETs returning `M` from different well-formed paths are
     not an error — each path defines a separate resource. This is how
     the same model can legitimately back resources at different
     scopes.
2. **Derive the path-based facts intrinsic to this resource.** Apply
   [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths)
   to the instance path to obtain `resourceType`, the trailing `{name}`
   parameter (or the literal singleton name), and the `apiVersion`. See
   [*How a resource is named*](#how-a-resource-is-named). The resource's
   `parent` and `scope` are resolved in
   [Step 3](#step-3--resolve-parent-relationships-and-scopes) once the
   full resource set is known.
3. **Attach CRUD operations by verb.** For every other operation in the
   service whose path equals the resource's instance path:

   | Verb | Kind |
   | --- | --- |
   | `PUT` | `Create` |
   | `PATCH` | `Update` |
   | `DELETE` | `Delete` |

   Operation-kind decorators are not consulted. If two operations of
   the same kind hit the same path, emit a diagnostic and pick the one
   whose model matches the resource model.

4. **Diagnostic if no `Read` exists.** A candidate model with no
   matching GET is not a resource. Emit a diagnostic naming the model;
   the spec author either forgot the `Read`, or the model was wrongly
   annotated as a resource.

After Step 2, the resource set is fixed: a list of resources each with
`{ model, instance path, type, name, apiVersion,
Read [, Create] [, Update] [, Delete] }`. Parent and scope are filled in
by Step 3.

### Step 3 — Resolve parent relationships and scopes

Parent and scope cannot be settled before Step 2 is complete, because
both depend on whether *another* path in the set is a resource path:

- A resource's **parent** is the resource at the next-shorter
  `/type/{name}` prefix of its instance path. That prefix is a parent
  only if it is itself a detected resource.
- A resource's **scope** is determined by the path segment that
  precedes the **last** `/providers/<namespace>/...` portion of its
  instance path. An instance path can contain more than one
  `/providers/<namespace>/` block — extension resources are anchored
  on another resource whose own path already starts with
  `/providers/...` — so the split point is always the *last*
  `/providers/`. If the prefix before that last `/providers/` is itself
  another resource's instance path, the scope is `Extension` (the
  resource is anchored on whatever resource it extends); otherwise it
  is `Tenant` / `Subscription` / `ResourceGroup` /
  `ManagementGroup` as defined in
  [*Ground truth*](#ground-truth-arm-resources-are-defined-by-their-paths).

For each resource `R` from Step 2:

1. **Parent.** Take `R`'s instance path. Strip the trailing
   `/<typeN>/<nameN>` pair. If the remaining path is the instance path
   of some resource `P` in the set, `P` is `R`'s parent. Otherwise `R`
   has no resource parent (it is top-level under its scope). See
   [*How a resource's parent is determined*](#how-a-resources-parent-is-determined)
   for additional rules covering dynamic parent expansion and the
   shared-model / `@parentResource` decorator cases.
2. **Scope.** Inspect the prefix of `R`'s instance path that precedes
   the **last** `/providers/<namespace>/...` segment in the path (a
   single path can contain more than one `/providers/<namespace>/`
   block when the resource extends another resource):
   - `/` → `Tenant`.
   - `/subscriptions/{}/` → `Subscription`.
   - `/subscriptions/{}/resourceGroups/{}/` → `ResourceGroup`.
   - `/providers/Microsoft.Management/managementGroups/{}/` →
     `ManagementGroup`.
   - Any other prefix that is itself a resource instance path →
     `Extension`, anchored on that resource.

   See [*How resource scope is determined*](#how-resource-scope-is-determined).

`@parentResource(P)` and the scope-marker decorators
(`@subscriptionResource`, `@resourceGroupResource`, etc.) are consulted
only as fallback / disambiguation in the cases the per-aspect sections
spell out; the path-derived parent and scope take precedence.

### Step 4 — Assign remaining operations

Every operation not consumed in Step 2 is now considered for attachment
to one of the resources from Step 2. For each remaining operation, try
the rules below in order. The first rule that matches both attaches the
operation and chooses its kind.

1. **Collection `GET` → `List`.** A `GET` whose response is a paged
   collection whose item type is some resource `R`'s model, and whose
   path equals `R`'s **collection path** (`R`'s instance path with the
   trailing `{name}` removed), attaches to `R` as `List`. This includes
   list-by-parent variants whose paths walk a different ancestor chain
   than `R`'s instance path.
2. **`POST` returning a paged collection of `R`'s model → `List` on
   `R`.** A `POST` whose path is `R`'s collection path and whose
   response is paged-of-`R` is a `List` on `R`. This is the equivalent
   of `autorest.bicep`'s `list*` POST handling. (`POST` ARM
   `list*`-style operations frequently appear instead of `GET` because
   the spec needs a request body to scope the list.)
3. **Cross-resource list relocation.** If a `List`-shaped operation
   (`GET` or `POST` returning paged-of-`R`-model) sits at `R`'s
   collection path but was declared in a TypeSpec operation group bound
   to a different resource `A`, the operation is moved off `A` and
   attached to `R`. See [*Cross-resource list relocation*](#cross-resource-list-relocation).
4. **Longest-prefix path match → `Action` on `R`.** An operation whose
   path starts with some resource `R`'s instance path (plus extra
   segments, typically a `POST` action verb) is an `Action` on `R`. The
   trailing path segment(s) form the action name. When multiple
   resources qualify, the longest match wins.
5. **Model-id match → `List` on `R`.** A `GET` or `POST` whose return
   model is `R`'s resource model and whose path takes `R`'s id-shape
   parameters (but does not match `R`'s instance path) attaches to `R`
   as `List`. This catches list-by-scope endpoints whose path doesn't
   reach `R`'s usual parent — e.g. `listBySubscription` on a
   resource-group-scoped resource.
6. **Type-tail match → `List` on `R`.** A `GET` or `POST` whose path
   ends with `R`'s resource-type tail and whose response is paged-of-
   `R`'s model attaches to `R` as `List`.

Any operation that matches none of the above is a **non-resource
method** and is emitted as an extension on the appropriate scope
resource (`SubscriptionResource` / `ResourceGroupResource` /
`TenantResource` / `ManagementGroupResource` / `ArmResource`).

> Notes on what is intentionally **not** considered in Step 4:
>
> - Operation-kind decorators such as `@armResourceList` or
>   `@armResourceAction`. The combination of verb, path relationship,
>   and response model is what classifies an operation.
> - `@armResourceOperations(R)` as authoritative ownership. The
>   decorator is a useful starting hint (it tells us which operations
>   the spec author meant to associate with `R`'s group), but Step 4
>   does not require the operation to be in `R`'s group to attach it
>   to `R`. A list-of-containers operation declared inside the storage-
>   account group still ends up on the container resource.

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

## Desired output

The end state expected by the C# generator is two collections:

- A list of **resources**, each with: model, instance path, resource type,
  scope, parent, name, name constraints, RBAC roles, supported API versions,
  and the methods that belong on it (with their kinds).
- A list of **non-resource methods**, each with operation path and scope, to
  be emitted as extensions on the appropriate scope resource.

This is attached to the root client as the `@armProviderSchema` decorator
and consumed by every later step of the C# generator.
