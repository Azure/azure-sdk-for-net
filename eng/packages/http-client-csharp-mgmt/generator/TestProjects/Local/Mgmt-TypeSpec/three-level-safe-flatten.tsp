using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Reproduces https://github.com/microsoft/typespec/issues/7380.
 *
 * When safe-flatten chains across three or more levels of single-property models,
 * the previous emitter generated a setter `Outer = new InnerModel(value)` for the
 * flattened property, but `InnerModel`'s only constructor takes the *next* inner
 * model — not the deeply-flattened scalar. The fix in `BuildSetterForSafeFlatten`
 * detects the chained case (innerProperty is itself a FlattenedPropertyProvider)
 * and emits the safe `if (Outer == null) Outer = new InnerModel(); Outer.X = value;`
 * pattern that delegates through the inner flattened setter.
 *
 * Model shape: `ThreeLevelOuter (single prop) -> ThreeLevelMiddle (single prop) -> ThreeLevelInner.value`
 */

/** Leaf model with a single required scalar property. */
model ThreeLevelInner {
  /** The deeply-flattened scalar value. */
  value: string;
}

/** Middle model with a single required reference to the leaf. Triggers safe-flatten. */
model ThreeLevelMiddle {
  inner: ThreeLevelInner;
}

/** Properties bag with a single required reference to the middle. Triggers chained safe-flatten. */
model ThreeLevelOuterProperties {
  middle: ThreeLevelMiddle;
}

@resource("threeLevelFlattens")
@parentResource(Foo)
model ThreeLevelFlattenTest is ProxyResource<ThreeLevelOuterProperties> {
  ...ResourceNameParameter<ThreeLevelFlattenTest, SegmentName = "threeLevelFlattens">;
}

@armResourceOperations
interface ThreeLevelFlattenOps {
  get is ArmResourceRead<ThreeLevelFlattenTest>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<ThreeLevelFlattenTest>;
}
