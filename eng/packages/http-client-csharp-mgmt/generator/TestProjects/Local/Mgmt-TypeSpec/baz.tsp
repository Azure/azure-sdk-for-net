import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

// shows a way of mitigating breaking changes for tracked resource with optional location when migrated into new generator
@Azure.ClientGenerator.Core.Legacy.hierarchyBuilding(Azure.ResourceManager.Foundations.TrackedResource, "csharp")
@resource("bazs")
model Baz is ProxyResource<BazProperties> {
  ...ResourceNameParameter<Baz, SegmentName = "bazs">;

  location?: azureLocation;

  tags?: Record<string>;
}

model BazProperties {
  /** something */
  something?: string;

  /** boolean value */
  boolValue?: boolean;
}

@armResourceOperations
interface Bazs {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Baz>;

  get is ArmResourceRead<Baz>;

  delete is ArmResourceDeleteWithoutOkAsync<Baz>;

  update is ArmCustomPatchAsync<Baz, Baz>;

  list is ArmResourceListByParent<Baz>;

  listBySubscription is ArmListBySubscription<
    Baz,
    Parameters = {
      @query("$top")
      $top?: int32;
    }>;
}
