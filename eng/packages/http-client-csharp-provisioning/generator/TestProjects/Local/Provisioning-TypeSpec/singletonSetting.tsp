import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "./configurationStore.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace ProvisioningTypeSpec;

// ---- Singleton resource test ----
// SingletonSetting has one fixed instance named "default". The provisioning
// generator should emit a non-settable Name with the default singleton value.

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
