using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

model CustomBaseTypeResourceProperties {
  description?: string;

  children?: CustomBaseTypeChildResource[];
}

@resource("customBaseTypeResources")
model CustomBaseTypeResource is TrackedResource<CustomBaseTypeResourceProperties> {
  ...ResourceNameParameter<CustomBaseTypeResource, SegmentName = "customBaseTypeResources">;
}

model CustomBaseTypeChildResourceProperties {
  value?: string;
}

@parentResource(CustomBaseTypeResource)
model CustomBaseTypeChildResource is ProxyResource<CustomBaseTypeChildResourceProperties> {
  ...ResourceNameParameter<CustomBaseTypeChildResource, SegmentName = "children">;

  @visibility(Lifecycle.Read)
  etag?: string;
}

@armResourceOperations
interface CustomBaseTypeResources {
  get is ArmResourceRead<CustomBaseTypeResource>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<CustomBaseTypeResource>;
}

@armResourceOperations
interface CustomBaseTypeChildResources {
  get is ArmResourceRead<CustomBaseTypeChildResource>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<CustomBaseTypeChildResource>;
}
