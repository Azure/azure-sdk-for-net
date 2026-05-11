import "./foo.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

// Repro for shared ParameterProvider mutation in FixRawDataFieldReference.
// The inheritance chain is:
//   Resource (system) → CustomPatchBase → DerivedPatch
// When FixRawDataFieldReference runs on DerivedPatch, it mutates the shared
// additionalBinaryDataProperties ParameterProvider object, which then corrupts
// the deserialization of SiblingPatch (another model extending Resource that
// shares the same parameter object via BuildConstructorParameters).

/** A custom patch base model extending Resource directly. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for shared-param mutation"
model CustomPatchBase extends Azure.ResourceManager.CommonTypes.Resource {
  /** Resource tags. */
  tags?: Record<string>;
}

/** A derived patch model extending the custom base — triggers FixRawDataFieldReference. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for shared-param mutation"
model DerivedPatch extends CustomPatchBase {
  /** Update properties. */
  derivedProp?: string;
}

/** A sibling model that also extends Resource — affected by the shared mutation. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for shared-param mutation"
model SiblingPatch extends Azure.ResourceManager.CommonTypes.Resource {
  /** Sibling properties. */
  siblingProp?: string;
}

model SharedParamReproListResult is Azure.Core.Page<DerivedPatch>;
model SiblingPatchListResult is Azure.Core.Page<SiblingPatch>;

// Use the models in actions on the Foo resource so they get generated
@armResourceOperations
interface SharedParamRepro {
  @get
  @action("listDerivedPatches")
  listDerivedPatches is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<SharedParamReproListResult>
  >;

  @get
  @action("listSiblingPatches")
  listSiblingPatches is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<SiblingPatchListResult>
  >;
}
