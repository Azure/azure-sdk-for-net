import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";

using Azure.ResourceManager;
using TypeSpec.Rest;

namespace ProvisioningTypeSpec;

/** A parent resource defined outside this provisioning library. */
@armVirtualResource
model ExternalStore {
  ...ResourceNameParameter<
    Resource = ExternalStore,
    KeyName = "externalStoreName",
    SegmentName = "externalStores"
  >;
}

/** A singleton setting beneath an external parent resource. */
@singleton("default")
@parentResource(ExternalStore)
model VirtualParentSingletonSetting is ProxyResource<VirtualParentSingletonSettingProperties> {
  ...ResourceNameParameter<
    Resource = VirtualParentSingletonSetting,
    KeyName = "settingName",
    SegmentName = "settings"
  >;
}

/** Properties of a singleton setting beneath an external parent. */
model VirtualParentSingletonSettingProperties {
  /** Indicates whether the singleton setting is enabled. */
  enabled?: boolean;
}

@armResourceOperations
interface VirtualParentSingletonSettings {
  get is ArmResourceRead<VirtualParentSingletonSetting>;

  createOrUpdate is ArmResourceCreateOrReplaceSync<VirtualParentSingletonSetting>;
}
