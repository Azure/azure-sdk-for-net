# API-version wire defaults

The management emitter supports `@Azure.Core.Legacy.overrideApiVersion("...")` on namespaces and interfaces. Azure Core and TCGC resolve namespace inheritance, interface precedence, source operations, and client relocation. The resolved API-version parameter default is the wire value; it does not change service projection, operation availability, `apiVersions`, or API-version enums.

Wire values are opaque non-empty strings and need not belong to the service version enum. Different operations in one flattened REST client can have different defaults. Generated default-version documentation uses the same parameter default as the request.

## Runtime precedence

For resource-associated operations, precedence is:

1. An explicit `ArmClientOptions.SetApiVersion` override for the **operation's associated resource type**.
2. The operation's resolved wire default (including a legacy decorator when present).
3. The existing client-version fallback when no parameter default is available.

The resource type comes from ARM resource metadata, not from the owning REST client, RP, extension scope, or action path suffix. A resource-type override applies to all operations associated with that type; it is not a public per-operation version-selection API. An override for a different resource type does not replace a legacy wire default.

Resources, collections, resource actions, and resource-associated mockable extension operations use the same targeted lookup. The emitter records override presence separately from its value so that an override equal to the projected service version still participates in this behavior. Undecorated clients with ordinary shared defaults retain their existing request wiring.

Continuation requests use the same operation/resource-type precedence as the first request. Expanded resource types retain their initial request's dynamic type parameters when reinjection or page-size metadata filters the continuation signature. Paging call sites carry those captured values forward solely for the targeted version lookup; the original path is not replayed into the server's next-link URI. Opaque version values are escaped exactly once whether a next link already contains `api-version` or needs it appended. A management-only visitor repairs the pinned base generator's helper replacement branch; the append branch retains its existing escaping behavior, and data-plane generation is unchanged.

Genuinely non-resource operations have no associated resource-type key. Their resolved defaults are honored, but there is no existing public management per-operation runtime API with which to override them. Selections for the extension scope or another resource must not silently change their wire defaults. This does not introduce a new runtime contract for the broader non-resource override limitation tracked by #45049, nor does it completely address #62600 for undecorated mockable clients.

## Separate concerns

- `api-version` in emitter configuration selects the TypeSpec service projection; it does not replace a legacy wire default.
- ARM feature-file `version` controls AutoRest document emission. Direct management emission consumes the Azure Core decorator through TCGC; feature-file document grouping/version selection is not implemented as an additional SDK wire-default mechanism.
- The `skip-api-version-override` emitter option controls LRO polling. This change does not remove that option or change the polling contract.
- No data-plane options or API-version behavior is changed.
