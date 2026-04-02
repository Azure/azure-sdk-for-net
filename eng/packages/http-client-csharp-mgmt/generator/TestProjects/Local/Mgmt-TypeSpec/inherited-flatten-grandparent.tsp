import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec {

/**
 * Minimal repro for the inherited flatten case from ComputeGallery:
 *
 *   GrandparentFlattenBase                (base, has @flattenProperty identifier)
 *     -> GrandparentFlattenProxy<T>       (intermediate template, extends base)
 *       -> GrandparentFlattenResource     (ARM resource, is Proxy<Properties>)
 *
 * The model factory for the leaf resource should flatten the base `identifier`
 * bag into a `string uniqueId` parameter instead of exposing the internal
 * `GrandparentFlattenIdentifier` type.
 */
model GrandparentFlattenIdentifier {
  uniqueId?: string;
}

#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for inherited flatten model factory updates"
model GrandparentFlattenBase extends Azure.ResourceManager.CommonTypes.Resource {
  identifier?: GrandparentFlattenIdentifier;
}

#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for inherited flatten model factory updates"
model GrandparentFlattenProxy<Properties extends {}> extends GrandparentFlattenBase {
  @doc("The resource-specific properties for this resource.")
  properties?: Properties;
}

model GrandparentFlattenLeafProperties {
  disclaimer?: string;
}

#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for inherited flatten model factory updates"
model GrandparentFlattenLeaf extends GrandparentFlattenProxy<GrandparentFlattenLeafProperties> {
}

model GrandparentFlattenLeafListResult is Azure.Core.Page<GrandparentFlattenLeaf>;

@armResourceOperations
interface GrandparentFlattenRepro {
  @get
  @action("listGrandparentFlattenLeaves")
  listGrandparentFlattenLeaves is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<GrandparentFlattenLeafListResult>
  >;
}

#suppress "deprecated"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(GrandparentFlattenBase.identifier);
}
