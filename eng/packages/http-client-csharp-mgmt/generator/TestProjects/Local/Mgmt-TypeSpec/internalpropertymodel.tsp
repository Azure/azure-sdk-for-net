import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/** A resource to test model factory with internal properties type. */
@parentResource(Foo)
model InternalPropertyModel is ProxyResource<InternalPropertyModelProperties> {
  ...ResourceNameParameter<InternalPropertyModel, SegmentName = "internalPropertyModels">;
}

/** Properties of the internal property model - will be made internal via custom code. */
model InternalPropertyModelProperties {
  /** The organization id. */
  organizationId?: string;

  /** The account id. */
  accountId?: string;

  /** The account name. */
  accountName?: string;
}

@armResourceOperations
interface InternalPropertyModels {
  /** Gets the internal property model. */
  get is ArmResourceRead<InternalPropertyModel>;
}
