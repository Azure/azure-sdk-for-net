import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

/** A resource whose operations have independent legacy wire versions. */
model WireVersionTest is TrackedResource<WireVersionTestProperties> {
  ...ResourceNameParameter<WireVersionTest>;
}

/** Resource properties. */
model WireVersionTestProperties {
  /** A test value. */
  value?: string;
}

@Azure.Core.Legacy.overrideApiVersion("opaque-read")
interface WireVersionReads {
  get is ArmResourceRead<WireVersionTest>;
  listBySubscription is ArmListBySubscription<WireVersionTest>;
  listByResourceGroup is ArmResourceListByParent<WireVersionTest>;
}

@Azure.Core.Legacy.overrideApiVersion("opaque-write")
interface WireVersionWrites {
  createOrUpdate is ArmResourceCreateOrReplaceSync<WireVersionTest>;
  update is ArmResourcePatchSync<WireVersionTest, WireVersionTestProperties>;
}

interface WireVersionActions {
  ping is ArmResourceActionSync<WireVersionTest, Request = void, Response = WireVersionTest>;
}

@Azure.Core.Legacy.overrideApiVersion("opaque-non-resource")
interface WireVersionProviderActions {
  @autoRoute
  checkWireVersion is ArmProviderActionSync<Request = void, Response = string, Scope = SubscriptionActionScope>;
}

@@clientLocation(WireVersionReads.get, "WireVersionOperations");
@@clientLocation(WireVersionReads.listBySubscription, "WireVersionOperations");
@@clientLocation(WireVersionReads.listByResourceGroup, "WireVersionOperations");
@@clientLocation(WireVersionWrites.createOrUpdate, "WireVersionOperations");
@@clientLocation(WireVersionWrites.update, "WireVersionOperations");
@@clientLocation(WireVersionActions.ping, "WireVersionOperations");
@@clientLocation(WireVersionProviderActions.checkWireVersion, "WireVersionOperations");
