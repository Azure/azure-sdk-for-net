# Provisioning Resource Detection — Design

This document defines how the provisioning generator should decide which ARM
resources to project into provisioning resource types, and how those resource
types should align with the official Bicep reference.

It is a design document, not an implementation plan. It describes desired
behavior and invariants. Any implementation that satisfies these invariants is a
correct implementation.

---

## Goal

The provisioning generator should produce resources that are valid Bicep
resources with aligned Bicep schemas.

The design intentionally favors precision over coverage:

- It is acceptable to miss an ARM resource that exists in Bicep.
- It is not acceptable to generate a provisioning resource that does not
  correspond to a Bicep resource.
- It is not acceptable for a generated provisioning resource to emit a body
  shape that disagrees with the Bicep resource schema for the same resource type
  and API version.

This means provisioning resource detection is conservative. A resource candidate
is generated only when its identity and deployable shape can be tied to the same
resource concept used by Bicep.

---

## Sources of truth

Provisioning generation should generate resources from the TypeSpec management
resource-detection result. The semantic target is Bicep.

The TypeSpec management resource-detection result is the authoritative local
input for:

- resource type;
- resource path;
- resource scope;
- parent relationship;
- resource operations;
- API versions;
- request and response models.

The official Bicep reference is the semantic compatibility target for generated
provisioning resources:

- resource type identity;
- resource name shape;
- parent and scope declaration behavior;
- writable body shape;
- readable output shape;
- required, read-only, and write-only property semantics.

The provisioning generator should not infer resource identity directly from
model names, model inheritance, or the presence of common ARM properties such as
`id`, `name`, and `type`. Those details may help describe a body, but they are
not sufficient to prove that a model is a deployable resource.

---

## Detection boundary

Provisioning resource generation should start from resource entries already
detected by management resource detection.

A detected resource entry can become a generated provisioning resource only if
the entry has enough information to define a concrete Bicep resource identity:

- a concrete resource type string;
- a concrete API version;
- a resource path with a known name position;
- a known deployment scope or extension scope;
- a deployable or referenceable body associated with the resource path.

If any of these facts are missing or ambiguous, the implementation should skip
the resource. Skipping preserves the main guarantee: generated resources should
be Bicep resources.

This differs from management SDK generation. Management libraries may expose
resource-like client objects for operational convenience. Provisioning libraries
should expose resource declarations and references that correspond to template
authoring concepts.

---

## Resource identity

Each generated provisioning resource represents one concrete ARM resource type
at one concrete resource path shape.

The identity is path based:

- the final provider segment determines the provider namespace and resource
  type segments;
- the path prefix before that provider segment determines scope;
- the alternating type/name segments determine the resource name tuple;
- literal name segments determine singleton identity values;
- parent relationships are derived from path structure.

The identity is not model based. If the same model appears at multiple resource
paths, those paths are distinct resource identities. If multiple models
contribute to the same path and resource type, they are body-shape inputs for
the same resource identity.

Generated resource type strings must be concrete. A provisioning resource should
not expose a variable resource type segment in its emitted Bicep `type`.
Parameterized type segments must be resolved into concrete resource types before
they can be generated.

---

## Relationship to Bicep resource identity

The generated provisioning resource should match Bicep by resource type and API
version.

For a resource candidate:

- if Bicep has no resource type with the same type string and API version, the
  candidate should not be generated;
- if Bicep models the resource type as multiple name-discriminated variants, the
  provisioning surface should preserve that name distinction;
- if Bicep treats several paths as one resource type with fixed-name body
  variants, provisioning should not invent unrelated resource identities for
  those variants.

Different operations producing the same resource type do not automatically imply
different provisioning resource classes. The deciding concept is the Bicep
resource type. Distinct fixed-name variants may be represented as variants of
that resource type; ambiguous same-type candidates should be skipped rather than
projected as conflicting resources.

The same resource type can also be discovered at different scopes. Bicep treats
readable and writable scopes as capabilities of the resource type, not as
separate resource types. Provisioning should collapse multiple detected resource
entries only when their resource type is the same and their resource model is
the same. The collapsed resource concept should preserve the union of confirmed
readable and writable scopes. If the resource type is the same but the resource
models differ, the implementation should not collapse them merely because the
Bicep type string matches.

---

## Resource body

A provisioning resource's public properties represent the Bicep body for that
resource.

The writable body comes from create and update request shapes. The readable body
comes from read response shapes. The generated body is the union of these
perspectives, with property semantics that preserve whether each value can be
authored, read back, or both.

For the common case where a resource has both PUT and GET:

- PUT defines what can be declared;
- GET defines what can be observed;
- the path defines resource identity, name, parent, and scope.

The generated provisioning schema should not be a direct copy of the management
read model. Management SDK models are optimized for service clients. Bicep
schemas are optimized for template declarations and references.

---

## Property semantics

Each generated property has independent concepts of:

- Bicep path;
- CLR type;
- requiredness;
- writability;
- output-ness;
- fixed value, if any.

The Bicep path is the serialized location in the emitted template. It may be a
top-level resource property such as `location`, or a nested path such as
`properties.sku`.

A property is writable when it is accepted by a create or update request shape
and is not read-only in that request shape. A property is output-only when it is
present only in read responses, is marked read-only, or is resource metadata
that Bicep treats as computed.

A property is required when the deployable Bicep body requires it. A resource
identity value can be required even if the service response model marks it as
read-only.

The standard resource metadata properties have fixed provisioning semantics:

| ARM property | Provisioning meaning |
| --- | --- |
| `name` | Required identity value, or a fixed singleton value. |
| `id` | Output-only resource identifier. |
| `type` | Resource type metadata implied by the generated resource class. |
| `apiVersion` | Resource version metadata controlled by the resource version surface. |
| `systemData` | Output-only service metadata. |

The `properties` object is not a separate resource boundary. It is part of the
Bicep body. The C# surface may flatten or project nested values, but the emitted
Bicep path must remain aligned with the Bicep schema.

---

## Name semantics

Resource names are identity values, not ordinary body properties.

The generated resource should preserve the name shape used by Bicep:

- a path parameter name is customer supplied unless constrained by the path
  schema;
- a literal final path segment is a fixed singleton name;
- a constant name schema is a fixed name;
- a constrained enum name should preserve its allowed values where Bicep exposes
  those values;
- a multi-segment relative name should remain a tuple of identity values rather
  than being collapsed into an opaque string when the parent path requires
  multiple names.

Single-value enum handling should follow the Bicep-visible shape. Bicep type
output and JSON schema output differ in how they treat extensible single-value
enums, so provisioning should align with the Bicep reference shape that users
observe for the resource rather than assuming every single-value enum is a
closed singleton.

---

## Parent and scope

Parentage and scope are path-derived.

Scope detection comes from the resource path prefix before the final provider
segment. The prefix identifies whether the resource is tenant, management-group,
subscription, resource-group, or extension scoped. The operation then determines
which capability set receives that detected scope: read operations contribute to
readable scopes, and write operations contribute to writable scopes.

Provisioning should preserve this distinction. Scope is part of resource
capability and declaration context; it is not an ordinary model property and
should not be inferred from CLR model hierarchy.

A child resource is identified by structural resource type segments and path
position. The public Bicep reference shows a language-level `parent` property
for structural child resources, but that property is not part of the provider
body. Provisioning should model parent as a resource relationship, not as an
ordinary serialized body property.

Some ARM paths skip intermediate resources. Therefore, a child resource may be
addressed by a relative name tuple instead of a single relative name. The design
must allow that identity shape.

Extension resources are scoped by the path prefix before the final provider
segment. The public Bicep reference shows a language-level `scope` property for
writable extension resources, unless the resource is already treated as a
structural child resource. Provisioning should model this as a scope
relationship, not as a provider body property.

Readable and writable scopes are sets of deployment scopes, not simple
read/write booleans. GET contributes the path-derived scope to readable scopes.
PUT contributes the path-derived scope to writable scopes. A resource may be
readable at scopes where it is not writable.

---

## Readable and writable resources

Readable and writable capabilities are separate.

A resource with create or update support is deployable. It may expose normal
construction paths for declarations.

A resource with read support but no create or update support is referenceable,
but not deployable through a normal declaration. If such a resource is generated
at all, the surface should make the distinction clear.

A resource with no reliable read or write resource operation should not be
generated from model shape alone.

Bicep can contain resources whose writable scope is `None`. Provisioning may
choose not to generate those resources, or may represent them only as existing
resource references. It should not accidentally expose them as normal deployable
resources.

---

## Supporting models

Supporting model types represent reusable Bicep object shapes that are reachable
from accepted resources.

A model should be generated as a supporting construct when it is used by an
accepted resource body and is not itself an accepted resource identity. Model
classification therefore follows role in the accepted resource graph, not only
TypeSpec inheritance.

Shared models may be used by multiple resources or by both input and output
shapes. Their generated semantics should preserve usage context. A property
should not become globally writable or globally read-only simply because the
same model appears in one request or one response.

Known provisioning framework types, such as common identity and system metadata
constructs, should remain framework types when they accurately represent the
Bicep shape.

---

## Discriminators and variants

Discriminators describe serialized body variants.

A discriminated data model should be represented as a discriminated construct
shape when the discriminator is part of the Bicep body. The discriminator value
selects the body variant and should be emitted when Bicep requires it.

A discriminated resource body should create provisioning variants only when
Bicep models the resource body as variants for the same resource type. Fixed
discriminator values should be generated as fixed emitted values, not ordinary
customer-settable properties.

Variants do not create new ARM resource identities unless the detected resource
identity differs. A variant is a body shape for a resource identity.

---

## API versions

API version is a resource identity dimension.

Generated resource version surfaces should come from accepted resource metadata
and should match the Bicep resource versions that exist for that resource type.
The default version should follow the provisioning library's version policy,
including preview filtering when a stable default is available.

If a candidate's body shape cannot be matched to the Bicep shape for its API
version, the safer result is to skip that candidate or that version.

---

## Alignment invariants

The provisioning generator should satisfy these invariants for every generated
resource:

1. The emitted resource type and API version exist in the Bicep reference.
2. The emitted name shape matches Bicep identity semantics.
3. Parent and scope are represented as provisioning relationships, not provider
   body properties.
4. Detected scopes are derived from resource paths and preserved as readable and
   writable scope capabilities.
5. Detected entries are collapsed only when both resource type and resource model
   are the same; compatible scopes are then unioned on that resource concept.
6. Writable properties correspond to Bicep-authorable properties.
7. Output-only properties correspond to Bicep-readable or computed properties.
8. Required properties match the deployable request shape and identity
   requirements.
9. Fixed names and discriminator values are emitted as fixed values.
10. Same-type fixed-name variants preserve Bicep's variant semantics.
11. Read-only/reference-only resources are not exposed as ordinary deployable
   resources.
12. If confidence is insufficient, the resource is skipped.

These invariants intentionally allow incomplete resource coverage. The
provisioning generator should first be correct for the resources it produces.
Broader coverage can be added only when it preserves the same Bicep-alignment
guarantees.
