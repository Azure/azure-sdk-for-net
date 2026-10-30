# Model Factory API Investigation

## Status

We investigated the existing generated .NET model factory API and the viable
alternatives described in this document. Each alternative has significant API,
compatibility, usability, or runtime tradeoffs, and none is sufficiently better to
replace the existing API at this time. We will therefore keep the existing public,
model-specific factory API for now.

This is not a conclusion that the current API or its implementation is ideal. Two
known flattening issues should still be addressed to reduce generator complexity
while leaving the customer-facing API unchanged. The work is tracked by:

- [microsoft/typespec#12414](https://github.com/microsoft/typespec/issues/12414),
  which moves explicit and safe property flattening into the upstream TypeSpec C#
  generator (MTG).
- [Azure/azure-sdk-for-net#64277](https://github.com/Azure/azure-sdk-for-net/issues/64277),
  which adopts upstream flattening in the management-plane generator (MPG) and
  removes the superseded downstream flattening and factory repair logic.

## Background

Model factories let customers construct output models and intentionally incomplete
models for tests and mocks. The current API generates a strongly typed factory entry
for each model, plus compatibility overloads when required by shipped contracts. A
simplified factory shape is:

```csharp
public static VirtualMachineData VirtualMachineData(
    ResourceIdentifier id,
    string name,
    // Other strongly typed model properties.
    string provisioningState);
```

This API provides compile-time property names and types, IntelliSense, and access to
models that do not have a usable public constructor. Its public signature is coupled
to the model shape, so it also participates in the SDK's compatibility contract.

The investigation began because maintaining these methods became increasingly
complex for management-plane models with flattened properties. The full customer
scenario and API comparison are captured in the
[Model Factory API Review](https://gist.github.com/pshao25/59c20f79f930a72ffbb7ed3edc415246).

## Requirements

Any replacement design must:

- Let tests construct output and incomplete models without service validation.
- Preserve strong typing, IntelliSense, and compile-time validation.
- Preserve shipped GA factory signatures and the values passed through them.
- Support nested models, collections, and large resource models.
- Preserve serialization and deserialization behavior.
- Avoid imposing a per-access runtime cost on normal SDK model usage.
- Remain compatible with customization and historical API handling.

Reducing the number of generated methods or parameters is useful only if it does not
weaken these requirements.

## Why Flattening Is the Root Problem

This document uses the terminology from the two implementation issues:

- **Explicit flattening** is requested by `@flattenProperty`. It projects the
  eligible leaves of the decorated wrapper onto its parent.
- **Safe flattening** is MPG's automatic projection of an eligible wrapper that has
  one effective public model property, and that property must itself be flattenable.
  Independent public custom properties count when determining eligibility even when
  they have no wire metadata. MTG will keep this behavior disabled by default, while
  MPG will explicitly enable it.

Both forms can participate in recursive or chained flattening when a projected
property is itself wrapped.

The upstream generator initially creates models, constructors, serialization code,
and model factories from an unflattened model graph. MPG then runs
`FlattenPropertyVisitor`, which changes the public model shape after those artifacts
already exist.

For example, an upstream model may initially contain a wrapper:

```csharp
internal VirtualMachineProperties Properties { get; set; }
```

MPG later projects leaves from that wrapper onto the parent:

```csharp
public string ProvisioningState
{
    get => Properties is null ? default : Properties.ProvisioningState;
    set
    {
        if (Properties is null)
        {
            Properties = new VirtualMachineProperties();
        }
        Properties.ProvisioningState = value;
    }
}
```

After this transformation, factory parameters no longer map directly to the
constructors and nested objects originally produced upstream. MPG must reconstruct
wrapper objects, reorder arguments, convert collection interfaces, account for
nullability changes, and repair both current and historical factory overloads.

This is visible in the current pipeline:

- `FlattenPropertyVisitor` rewrites model and factory shapes downstream.
- `ModelFactoryVisitor` restores historical methods and invokes compatibility
  repairs.
- `ModelFactoryBackwardCompatHelper` repairs constructor calls and historical
  overload bodies after visitors have finalized the model shape.
- Additional repair passes run at write time so they observe the final constructor
  shape and order after every visitor, including compatibility overloads synthesized
  during the visitor pipeline.

The complexity is therefore not inherent to the existing public API. It comes from
performing flattening after upstream model, constructor, compatibility, and factory
generation.

## Alternatives Investigated

### Existing Model-specific Factory

The existing design generates a strongly typed factory entry for each model and
retains historical overloads when compatibility requires them. Callers get named,
typed parameters for every property in the model's factory contract.

Advantages:

- Excellent IntelliSense and compile-time validation.
- No accessible model constructor is required.
- Supports incomplete models for tests.
- Already shipped and familiar to customers.

Costs:

- Large models produce long parameter lists.
- Factory signatures evolve with model APIs.
- Historical overloads must be retained safely.
- The current downstream flattening architecture makes implementation and
  compatibility repair difficult.

The current decision is to keep this public API for now and independently simplify
the flattening architecture.

### Virtual Properties

The virtual-property prototype made eligible generated properties virtual so a
mocking framework could override them. The experiment is in
[pshao25/azure-sdk-for-net#3](https://github.com/pshao25/azure-sdk-for-net/pull/3).

Advantages:

- Familiar subclass/proxy-based mocking model.
- Does not add factory parameters.
- Retains compile-time property types.

Limitations:

- It primarily helps proxy-based mocking and does not provide a general way to
  construct arbitrary incomplete model graphs.
- It changes the inheritance contract of model properties.
- Every normal access to an eligible property becomes a virtual call site.

The prototype measured a direct `VirtualMachineData.ETag` read at 1.770 ns for the
original property and 2.763 ns for the virtual property. JIT disassembly showed an
exact-type guard and virtual fallback that were absent from the original field load.
Across two VM serialization runs, wire-format serialization was approximately
5.8-6.9% slower for the virtual copy. Allocations were unchanged. These are focused
microbenchmarks on one virtualized host, but they demonstrate that virtual dispatch
is not free and can accumulate when serializers read many properties.

This option was not adopted at this time because it changes all model consumers to
optimize a narrower mocking scenario and does not replace the full model factory
capability.

### Init-only Properties

The init-only prototype changed output-only properties to public `init` accessors so
customers could use object initializers. The experiment is in
[pshao25/azure-sdk-for-net#4](https://github.com/pshao25/azure-sdk-for-net/pull/4).

```csharp
VirtualMachineData vm = new(AzureLocation.EastUS)
{
    ProvisioningState = "Succeeded"
};
```

Advantages:

- Natural C# syntax with property-name and property-type IntelliSense.
- No separate factory method is needed for models with usable constructors.
- Existing construction, serialization, and deserialization paths showed no added
  allocation in the prototype.

Limitations:

- Every model, including nested models, needs an accessible usable constructor.
- Required constructor arguments must still be supplied even when irrelevant to a
  test.
- `init` does not provide copy-with-modification for existing class instances.
- It changes public model APIs rather than containing test construction in a factory.
- Flattened init accessors still need to create and populate internal wrapper models.

There is also a compatibility constraint. A property can be writable in an older
service/API version and become response-only later. A GA SDK must retain the old
ordinary setter even if it is now a compatibility no-op. For example,
`PublicIPPrefixData.LoadBalancerFrontendIPConfigurationId` in the Network SDK has a
customized `{ get; set; }` API whose setter is intentionally empty, while current
wire serialization excludes the response-only backing property from requests.

Changing an existing `set` accessor to `init` is a source and metadata breaking
change, and C# cannot expose both on one property. A broad init-only policy would
therefore require historical API awareness and compatibility exceptions. Init-only
properties may still be useful in a future experimental design, but they do not
replace the existing factory safely today.

The prototype measured unchanged default VM construction allocation (240 B). An
object initializer that set output properties measured 592 B because flattened
assignments created the internal properties wrapper. Serialization allocations
matched the original assembly.

### Generic Model Factory

The generic prototype used one reflection-based API with an anonymous object
property bag. The experiment is in
[pshao25/azure-sdk-for-net#5](https://github.com/pshao25/azure-sdk-for-net/pull/5).

```csharp
VirtualMachineData vm = ModelFactory.Create<VirtualMachineData>(new
{
    Name = "vm1",
    ProvisioningState = "Succeeded"
});
```

The prototype also supported a `current` template for copy-with-modification:

```csharp
VirtualMachineData failed = ModelFactory.Create(
    new { ProvisioningState = "Failed" },
    current: baseline);
```

Advantages:

- One API works across model types.
- No accessible constructor is required.
- Callers specify only relevant properties.
- A template can reduce repetition across a large test suite.

Limitations:

- Property names and value types are validated at runtime rather than compile time.
- IntelliSense cannot validate the anonymous object against `T`.
- Reflection introduces trimming, AOT, caching, and diagnostics questions.
- Copy behavior for nested objects and collections requires a new public semantic
  contract.
- Flattened properties require special copy-on-write handling to avoid mutating the
  source model indirectly.

The direct, uncached prototype measured 5.700 us and 2,681 B for generic VM creation
with five properties. Creating a shallow copy from `current` with one flattened
override measured 726 ns and 736 B. A normal VM constructor, which performs less
work and is only a lower-bound reference, measured 50.85 ns and 240 B.

This option was not adopted at this time because it trades the current API's
strongest customer properties, compile-time validation and IntelliSense, for runtime
machinery and a new copy contract. It remains useful evidence that changing the
public API is not necessary to solve the generator problem.

## Comparison

| Area | Existing factory | Virtual properties | Init-only properties | Generic factory |
| --- | --- | --- | --- | --- |
| IntelliSense | Excellent | Excellent | Excellent | Limited |
| Compile-time validation | Excellent | Excellent | Excellent | Limited |
| Accessible constructor required | No | No | Yes | No |
| Incomplete model construction | Yes | Limited | Difficult | Yes |
| Existing API unchanged | Yes | No | No | Adds a new paradigm |
| Baseline copy workflow | Via helpers/reconstruction | No | No | Yes |
| Normal model runtime impact | None | Virtual dispatch | None when unused | None when unused |
| Generator impact | Existing complexity | Broad model changes | Broad model changes | New runtime infrastructure |

## Decision

Keep the existing public model-specific factory API unchanged for now.

The investigation did not identify a clearly better replacement. Virtual properties,
init-only properties, and a generic factory each improve part of the experience, but
each also introduces substantial capability, compatibility, usability, or runtime
tradeoffs. The existing API has its own drawbacks, including large signatures and
compatibility overhead, but replacing it now would exchange those known problems for
a different set of unresolved problems.

Separately, address two known flattening issues that make the current generator more
complex than necessary. Make flattening a first-class upstream model transformation
so MTG knows the final flattened property and constructor shape before it generates
current and historical model factory methods. Factory generation should then consume
that final shape directly rather than relying on MPG to rewrite generated factories
and repair their bodies afterward.

This decision does not require any customer migration. Existing model-specific calls
such as `ArmComputeModelFactory.VirtualMachineData(...)`, including retained
compatibility overloads, remain the supported experience.

## Implementation Plan

### 1. Implement Flattening Upstream

[microsoft/typespec#12414](https://github.com/microsoft/typespec/issues/12414)
owns shared flattening behavior in MTG:

- Support explicit `@flattenProperty` independently of safe flattening.
- Support recursive safe flattening of eligible wrappers.
- Keep safe flattening disabled by default for existing MTG consumers.
- Provide a protected generator extension hook, currently proposed as
  `EnableSafeFlatten`, that defaults to disabled and that MPG overrides to enable.
  Do not add a public emitter configuration option for this generator policy.
- Preserve generated accessors, constructors, serialization, wire paths,
  customization, nullability, and collection state.
- Make the final flattened shape available to compatibility and model factory
  generation.
- Preserve historical factory signatures and argument values. A retained signature
  that silently discards an old argument is not compatible behavior.

### 2. Adopt Upstream Flattening in MPG

[Azure/azure-sdk-for-net#64277](https://github.com/Azure/azure-sdk-for-net/issues/64277)
is blocked on the upstream implementation and owns downstream adoption:

- Consume an MTG version with upstream flattening support.
- Explicitly enable safe flattening to retain MPG's current default behavior.
- Preserve the existing per-model `disable-safe-flatten` option and its scope and
  boolean semantics.
- Remove `FlattenPropertyVisitor` after upstream behavior is proven equivalent.
- Remove only the flatten-specific portions of model factory repair logic that are
  made redundant upstream.
- Retain general historical factory compatibility and ARM-specific behavior.

MPG must not remove its current implementation before the required MTG support is
available and validated.

## Compatibility and Regression Requirements

Moving code upstream must not weaken existing behavior. The migration must account
for every case currently covered by `FlattenPropertyVisitorTests`,
`FlattenedCompatibilityTests`, and the local management TypeSpec generated fixtures.

The required coverage includes:

- Explicit, safe, recursive, inherited, and chained flattening.
- Optional and required wrappers and leaves, including value and reference
  nullability.
- Null-safe getters and setters and lazy wrapper construction.
- Mutable getter-only collections and undefined, empty, and null wire states.
- Customized, renamed, obsolete, discriminator, base, and derived model properties.
- Wire paths and serialization round trips.
- Historical property names, types, accessors, and constructor signatures.
- Historical factory overload identity, argument order, nested wrapper
  reconstruction, collection conversion, and null handling.
- Avoidance of ambiguous optional overloads and duplicate C# signatures.
- Diagnostics for historical factories that cannot be reconstructed safely.
- MTG default-off safe flattening, MPG explicit opt-in, and per-model opt-out.

Tests should verify compiled and runtime behavior, not only generated text. An
explicit mapping from each old MPG regression case to upstream or downstream
coverage is required so moving ownership does not silently drop a scenario. Before
removing downstream behavior, run the official unfiltered local MPG regeneration,
the relevant generator and compatibility tests, and generated-project compile and
runtime checks.

## Consequences

### Positive

- Customers keep the existing strongly typed API and compatibility contract.
- Flattening, constructors, serialization, compatibility, and factory generation
  operate on one coherent model shape.
- MPG can remove a duplicate flatten engine and flatten-specific repair passes.
- Other MTG consumers do not inherit management safe-flattening defaults.
- Future factory compatibility work can focus on genuine historical differences
  rather than downstream transformation order.

### Costs and Risks

- Upstream flattening must support the complete MPG behavior matrix before adoption.
- The migration crosses repository and ownership boundaries.
- Historical contracts include subtle nullability, collection, naming, and overload
  cases that require behavior-level regression tests.
- Some ARM-specific projection and compatibility policy will correctly remain in
  MPG; the migration does not eliminate all downstream model factory logic.

## References

- [Model Factory API Review](https://gist.github.com/pshao25/59c20f79f930a72ffbb7ed3edc415246)
- [Virtual property prototype](https://github.com/pshao25/azure-sdk-for-net/pull/3)
- [Init-only property prototype](https://github.com/pshao25/azure-sdk-for-net/pull/4)
- [Generic model factory prototype](https://github.com/pshao25/azure-sdk-for-net/pull/5)
- [Upstream flattening issue](https://github.com/microsoft/typespec/issues/12414)
- [MPG adoption issue](https://github.com/Azure/azure-sdk-for-net/issues/64277)
- [Projected date-time name ownership](https://github.com/microsoft/typespec/issues/11783)
- [Mixed historical constructor nullability](https://github.com/microsoft/typespec/issues/12407)
