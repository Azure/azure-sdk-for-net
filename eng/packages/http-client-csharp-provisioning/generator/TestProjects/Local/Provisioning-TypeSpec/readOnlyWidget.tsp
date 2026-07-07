import "@azure-tools/typespec-azure-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace ProvisioningTypeSpec;

// ---- Read-only resource model propagation test ----
// The provisioning generator should carry read-only resource context into
// nested models. Because ReadOnlyWidget has no writable operation, properties
// on ReadOnlyWidgetProperties should be generated without setters.

/** A read-only widget. */
@resource("readOnlyWidgets")
model ReadOnlyWidget is ProxyResource<ReadOnlyWidgetProperties> {
  ...ResourceNameParameter<ReadOnlyWidget, SegmentName = "readOnlyWidgets">;
}

/** Properties for a read-only widget. */
model ReadOnlyWidgetProperties {
  /** Value that is required in service output but not settable by provisioning. */
  requiredValue: string;
}

@armResourceOperations
interface ReadOnlyWidgets {
  get is ArmResourceRead<ReadOnlyWidget>;

  list is ArmResourceListByParent<ReadOnlyWidget>;
}
