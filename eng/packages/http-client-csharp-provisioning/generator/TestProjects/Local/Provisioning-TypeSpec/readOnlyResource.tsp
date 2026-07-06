import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** A read-only resource. */
@resource("readOnlyWidgets")
model ReadOnlyWidget is ProxyResource<ReadOnlyWidgetProperties> {
  ...ResourceNameParameter<ReadOnlyWidget, SegmentName = "readOnlyWidgets">;
}

/** The properties of a read-only resource. */
model ReadOnlyWidgetProperties {
  /** The read-only widget status. */
  @visibility(Lifecycle.Read)
  status?: string;
}

@armResourceOperations
interface ReadOnlyWidgets {
  get is ArmResourceRead<ReadOnlyWidget>;
}
