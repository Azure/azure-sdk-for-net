import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/** A resource with reserved characters in its legacy wire version. */
model EscapedWireVersionTest is ProxyResource<WireVersionTestProperties> {
  ...ResourceNameParameter<EscapedWireVersionTest>;
}

@Azure.Core.Legacy.overrideApiVersion("opaque-read&channel=legacy%2Fplus+#hash")
interface EscapedWireVersionReads {
  get is ArmResourceRead<EscapedWireVersionTest>;
  listBySubscription is ArmListBySubscription<EscapedWireVersionTest>;
  listByResourceGroup is ArmResourceListByParent<EscapedWireVersionTest>;
}
