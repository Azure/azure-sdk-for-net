import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

@resource("bazs")
model Baz is TrackedResource<BazProperties> {
  ...ResourceNameParameter<Baz, SegmentName = "bazs">;
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

  listBySubscription is ArmListBySubscription<Baz>;
}
