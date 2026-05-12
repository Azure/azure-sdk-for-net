# Legacy Resource Detection

This document describes how the mgmt emitter recognizes ARM resources, classifies
their operations, and decides which methods belong on the singular resource,
which belong on its collection, and which stay on the parent
SubscriptionResource / ResourceGroupResource / TenantResource extension class.

It describes the **legacy** detection rules — i.e. the behavior that is active
unless `use-legacy-resource-detection: false` is set in the emitter options.
The forthcoming replacement based on `resolveArmResources` is documented
separately in [`resolve-arm-resources-integration.md`](./resolve-arm-resources-integration.md).

The output of this stage is an `ArmProviderSchema` that the C# generator
consumes. From the generator's point of view, this schema is the source of
truth for "what is a resource here, what are its operations, where do they
live."

---

## What counts as a resource model

A TypeSpec model is treated as an ARM resource if **either** of the following
is true:

- It uses one of the standard ARM resource templates
  (`TrackedResource<T>`, `ProxyResource<T>`, etc.). The
  `typespec-azure-resource-manager` library marks these models for us.
- It (or any model in its inheritance chain) is decorated with
  `@customAzureResource`. This is the escape hatch used by legacy services
  such as TrafficManager that define their own base `Resource` model rather
  than using the standard templates.

Every other model is just data.

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

The scope of a resource (`Tenant`, `Subscription`, `ResourceGroup`,
`Extension`, …) is taken from the **`Read` operation's path**, not from
scope decorators on the model. Scope decorators (`@subscriptionResource`,
`@resourceGroupResource`, …) get inherited implicitly from base templates
like `ProxyResource` and may not reflect the actual scope, especially for
extension resources defined with `Legacy.ExtensionOperations` against a
specific parent type. The `Read` path is the source of truth.

If a resource has no `Read` operation, it falls into the "non-singleton
without Read" case and is removed from the schema (see
[*Resources that get filtered out*](#resources-that-get-filtered-out) below).
Only singletons may legitimately exist without a `Read`.

---

## How a resource's parent is determined

The resource's parent — whether it lives under another resource (`MyChild`
under `MyParent`) or directly under SubscriptionResource /
ResourceGroupResource / TenantResource — is decided in this order:

1. **`@parentResource` decorator on the model.** If the resource model is
   decorated with `@parentResource(SomeOtherModel)`, that other model is the
   parent.
2. **Path-based inference for shared-model interfaces.** When the same model
   is used by both a parent interface and a child interface (a common
   `LegacyOperations` pattern), the model decorator alone cannot tell them
   apart. Instead, whichever resource's instance path is the longest prefix
   of this resource's instance path is its parent.
3. **Dynamic parent expansion.** If a resource's path contains a dynamic
   parent type segment (`{parentType}`), the resource is split into one
   concrete entry per matching parent type before the rules above are
   applied. Each concrete copy then resolves to the appropriate parent.

If no parent is found, the resource sits directly under the scope determined
by its `Read` path (e.g. directly on SubscriptionResource).

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

The schema is pruned after detection. The following resources are removed
entirely:

- A non-singleton resource that has no `Read` operation. These cannot be
  represented as a real Resource class on their own. Their methods are not
  thrown away — they are reattached to the parent resource if there is one,
  otherwise they are demoted to non-resource methods.
- A singleton resource without a `Read` is allowed (its methods stay on it).

Each removal emits a diagnostic so the spec author sees why a model that
looked like a resource did not become one.

---

## Cross-resource list relocation

Some operations are decorated as actions on resource A but actually return a
paged list of resource B (e.g. `BlobContainer.list` declared on the storage
account but returning containers). When the response item type is a known
resource model that differs from the declaring resource's model, the
operation is moved off A and onto B as a `List`. This keeps these list
operations on the right collection.

---

## Reattaching non-resource methods to resources

After the resource list has been finalized, we make one more pass over the
non-resource methods to see if any of them are really resource-bound. A
non-resource method is moved onto a resource when any of these is true:

1. Its operation path **starts with** a resource's full instance path (so the
   method clearly hangs off that specific instance, with extra segments
   describing what action / sub-thing it targets).
2. Its operation path is the **longest prefix** of any resource's instance
   path, when several resources are candidates.
3. Its operation path **ends with** the same resource type segment as a known
   resource (e.g. `/subscriptions/{}/.../containerGroups`). This catches
   list / action operations declared as `ArmProviderActionSync<...>` rather
   than on the resource itself.

For each match, the kind it gets is decided as follows:

- **`List`** if the relocated method is pageable **and** its page item type
  is the target resource's model. The method becomes a real list-of-this-
  resource, surfaced as `GetAll` on the resource's collection.
- **`Action`** in every other case.

This is what keeps, for example, ContainerInstance's
`ContainerGroupsOperationGroup.list` / `listByResourceGroup` (both declared
as `ArmProviderActionSync<Response = ContainerGroupListResult, Scope = …>`)
on `ContainerGroupCollection` as `GetAll`, instead of dropping them onto the
singular `ContainerGroupResource` as bogus actions.

Methods that do not match any resource remain non-resource methods and are
generated as extension methods on SubscriptionResource / ResourceGroupResource
/ TenantResource as appropriate for their scope.

---

## What the C# generator sees

The end result of all of the above is two collections:

- A list of **resources**, each with: model, instance path, resource type,
  scope, parent, name, name constraints, RBAC roles, supported API versions,
  and the methods that belong on it (with their kinds).
- A list of **non-resource methods**, each with operation path and scope, to
  be emitted as extensions on the appropriate scope resource.

This is what gets attached to the root client as the `@armProviderSchema`
decorator and consumed by every later step of the C# generator.
