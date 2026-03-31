import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;

namespace MgmtTypeSpec;

/**
 * Minimal repro for https://github.com/Azure/azure-sdk-for-net/issues/57613
 *
 * When a resource uses DiscriminatedExtensionResource (abstract/polymorphic data),
 * the generated Resource.Serialization.cs creates `new AbstractData()` for
 * DataDeserializationInstance, which fails with CS0144 because the data type is abstract.
 */
@extensionResource
model PolyDevice
  is Azure.ResourceManager.Legacy.DiscriminatedExtensionResource<PolyDeviceKind> {
  ...ResourceNameParameter<
    Resource = PolyDevice,
    KeyName = "deviceName",
    SegmentName = "polyDevices",
    NamePattern = ""
  >;
}

/** Device kind discriminator. */
union PolyDeviceKind {
  string,

  /** Type A device. */
  TypeA: "TypeA",
}

/** Concrete device subtype. */
model TypeAPolyDevice extends PolyDevice {
  kind: PolyDeviceKind.TypeA;
  properties: TypeAPolyDeviceProperties;
}

/** Properties for TypeA device. */
model TypeAPolyDeviceProperties {
  /** Example property. */
  description?: string;
}

#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "Test"
@armResourceOperations
interface PolyDevices {
  @doc("Get a polymorphic device")
  get is Extension.Read<Extension.ScopeParameter, PolyDevice>;
}
