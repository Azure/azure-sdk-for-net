import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "./configurationStore.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace ProvisioningTypeSpec;

// A singleton resource has a fixed, non-settable name.

/** A singleton setting under a configuration store. */
@singleton("default")
@parentResource(ConfigurationStore)
model SingletonSetting is ProxyResource<SingletonSettingProperties> {
  ...ResourceNameParameter<
    Resource = SingletonSetting,
    KeyName = "settingName",
    SegmentName = "settings"
  >;
}

/** Properties of a singleton setting. */
model SingletonSettingProperties {
  /** Indicates whether the singleton setting is enabled. */
  enabled?: boolean;
}

@armResourceOperations
interface SingletonSettings {
  get is ArmResourceRead<SingletonSetting>;

  createOrUpdate is ArmResourceCreateOrReplaceSync<SingletonSetting>;
}
