import "./foo.tsp";

using Azure.ResourceManager;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

/** Request content with an explicitly flattened properties model. */
model NestedFlattenedCollectionContent {
  /** Request properties. */
  properties: NestedFlattenedCollectionProperties;
}

/** Properties containing a single model property that is safe-flattened. */
model NestedFlattenedCollectionProperties {
  /** Nested collection wrapper. */
  resource: NestedFlattenedCollectionResource;
}

/** Collection wrapper. */
model NestedFlattenedCollectionResource {
  /** Required collection values. */
  values: NestedFlattenedCollectionItem[];
}

/** Collection item. */
model NestedFlattenedCollectionItem {
  /** Item identifier. */
  id: string;
}

#suppress "deprecated"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(NestedFlattenedCollectionContent.properties);

/** Operations that make the regression models reachable by the emitter. */
@armResourceOperations
interface NestedFlattenedCollectionOperations {
  /** Exercises nested collection constructor generation. */
  @action("nestedFlattenedCollection")
  create is ArmResourceActionSync<
    Foo,
    NestedFlattenedCollectionContent,
    ArmResponse<FooActionResult>
  >;
}
