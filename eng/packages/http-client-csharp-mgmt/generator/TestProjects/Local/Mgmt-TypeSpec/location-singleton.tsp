import "@typespec/rest";
import "@azure-tools/typespec-azure-resource-manager";

namespace MgmtTypeSpec;

using Azure.ResourceManager;
using TypeSpec.Rest;

@doc("A fixed singleton under a variable subscription location.")
@singleton("current")
@parentResource(SubscriptionLocationResource)
model LocationSingleton is ProxyResource<PlaywrightQuotaProperties> {
  ...ResourceNameParameter<LocationSingleton, SegmentName = "locationSingletons">;
}

@armResourceOperations
interface LocationSingletonOperations {
  @doc("Get a singleton under a subscription location.")
  get is ArmResourceRead<LocationSingleton>;
}
