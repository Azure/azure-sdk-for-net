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
models that do not have a usable public constructor. However, it also has several
API design costs:

- The public factory API is coupled to the shape of each model.
- As a model gains properties, its factory method gains parameters.
- Factory methods for large ARM resource models may contain dozens of parameters.
- Adding, removing, renaming, or changing properties may require compatibility
  handling in the generated factory API.

These API costs motivated the investigation of alternative construction and mocking
experiences.

Property flattening is a separate implementation concern. It amplifies the generator
complexity required to produce and preserve the current factory API, but it is not
the underlying API design drawback that prompted this investigation.

## Investigation History

### Initial Builder-based Prototypes

The investigation started with the alternatives documented in
[New Model Factory](https://gist.github.com/pshao25/c4fbd02968c525f71ae591cdae1703f2)
and prototyped in
[Azure/azure-sdk-for-net#61448](https://github.com/Azure/azure-sdk-for-net/pull/61448):

- Reading prebuilt wire JSON with `ModelReaderWriter`.
- Building wire JSON incrementally with a `ModelJsonBuilder`.
- Setting CLR properties through a generic typed `ArmModelBuilder<T>`.
- Starting from a normally constructed model and applying read-only property
  overrides through a seeded `ArmModelBuilder<T>`.

Wire JSON was the simplest and fastest path, and `ModelJsonBuilder` made JSON easier
to author. Neither provided an appropriate replacement API, however, because callers
still had to know serialized property names, wrapper nesting, and flattened wire
paths. Those paths were strings, were not discoverable from the CLR model through
IntelliSense, and were validated only at runtime.

The typed builders restored CLR property IntelliSense and compile-time value types,
but required generated per-model metadata such as `AvailabilitySetDataDefinition` to
map each CLR property to its wire path and serialization behavior. Shipping that
metadata would introduce another broad set of generated APIs with its own ownership,
generation, compatibility, trimming, and AOT questions. The seeded builder also
required a serialize-modify-deserialize round trip and corresponding state-preservation
semantics.

In practice, making the typed builder discoverable would require exposing a
definition for every supported model. That would replace the current per-model
factory methods with a similarly broad per-model metadata API surface rather than
eliminating generated public API growth.

We did not pursue these builders further as the replacement public API. The wire
approaches did not provide the required discoverability, while the typed approaches
moved the API-growth problem into generated model-definition metadata and introduced
additional runtime and platform concerns. Wire JSON remains useful for recorded
responses and existing fixtures, but it serves a different scenario from a
discoverable model factory.

### API-focused Investigation

After the initial prototypes, we continued the investigation at the customer API
level rather than starting from wire serialization. The resulting shortlist and
representative customer scenarios are documented in the
[Model Factory API Review](https://gist.github.com/pshao25/59c20f79f930a72ffbb7ed3edc415246).

The APIs on the table were:

- Keep the existing strongly typed, model-specific factory API.
- Make output properties init-only and construct models through object initializers.
- Introduce one generic model factory using dictionary or anonymous-object property
  bags, optionally with a current model as a template.

We compared these APIs across single-property construction, nested models,
collections, large models, shared test baselines, and invalid property names or
types. We also prototyped virtual properties as a related proxy-based mocking option.
The linked review contains the detailed customer experience, prototype code, and
performance results from that longer investigation.

## Conclusion

None of the investigated alternatives provides a clearly better replacement for the
existing model factory API. Each improves part of the experience but introduces
significant discoverability, API-surface, compatibility, capability, or performance
tradeoffs. We will therefore keep the existing strongly typed, model-specific
factory API for now.

The existing API and implementation are not ideal. We will still address the two
known flattening issues linked in the Status section to reduce generator complexity
without changing the customer-facing API.

For the TL;DR and complete investigation, including customer experience examples,
prototype code, and performance results, see:

- [Initial builder investigation](https://gist.github.com/pshao25/c4fbd02968c525f71ae591cdae1703f2)
- [Model Factory API Review](https://gist.github.com/pshao25/59c20f79f930a72ffbb7ed3edc415246)
