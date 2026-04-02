import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using Azure.ResourceManager;

namespace MgmtTypeSpec;

/**
 * A polymorphic extension resource that uses DiscriminatedExtensionResource with 'kind' as the discriminator.
 * This tests that the generator correctly handles abstract resource data types in serialization.
 */
model PolyDevice
  is Azure.ResourceManager.Legacy.DiscriminatedExtensionResource {
  ...ResourceNameParameter<
    Resource = PolyDevice,
    KeyName = "deviceName",
    SegmentName = "polyDevices",
    NamePattern = ""
  >;
}

model TypeAPolyDevice extends PolyDevice {
  kind: "TypeA";
  properties: TypeAPolyDeviceProperties;
}

model TypeAPolyDeviceProperties {
  description?: string;
}

#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "Test"
@armResourceOperations
interface PolyDevices {
  get is Extension.Read<Extension.ScopeParameter, PolyDevice>;
  createOrUpdate is Extension.CreateOrUpdateAsync<Extension.ScopeParameter, PolyDevice>;
}
