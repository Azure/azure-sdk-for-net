import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

/** A multi-property identifier exposed through explicit flattening. */
@access(Access.public)
model ExplicitGalleryIdentifier {
  uniqueId?: string;
  tenantId?: string;
}

/** Base model carrying the flattened identifier. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Regression coverage for inherited flattened factories"
model ExplicitGalleryBase extends Azure.ResourceManager.CommonTypes.Resource {
  #suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Regression coverage for inherited flattened factories"
  @Azure.ClientGenerator.Core.Legacy.flattenProperty
  identifier?: ExplicitGalleryIdentifier;
}

/** Intermediate model between the flattened base and the leaf. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Regression coverage for inherited flattened factories"
model ExplicitGalleryProxy<Properties extends {}> extends ExplicitGalleryBase {
  properties?: Properties;
}

model ExplicitGalleryLeafProperties {
  disclaimer?: string;
}

#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Regression coverage for inherited flattened factories"
model ExplicitGalleryLeaf extends ExplicitGalleryProxy<ExplicitGalleryLeafProperties> {}

model ExplicitGalleryLeafListResult is Azure.Core.Page<ExplicitGalleryLeaf>;

@armResourceOperations
interface ExplicitGalleryRepro {
  @get
  @action("listExplicitGalleryLeaves")
  listExplicitGalleryLeaves is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<ExplicitGalleryLeafListResult>
  >;
}
