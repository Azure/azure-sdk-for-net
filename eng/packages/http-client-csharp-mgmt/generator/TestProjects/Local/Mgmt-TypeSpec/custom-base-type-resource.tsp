using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

model CustomBaseTypeResourceProperties {
  description?: string;
}

@resource("customBaseTypeResources")
model CustomBaseTypeResource is TrackedResource<CustomBaseTypeResourceProperties> {
  ...ResourceNameParameter<CustomBaseTypeResource, SegmentName = "customBaseTypeResources">;
}

@armResourceOperations
interface CustomBaseTypeResources {
  get is ArmResourceRead<CustomBaseTypeResource>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<CustomBaseTypeResource>;
}
