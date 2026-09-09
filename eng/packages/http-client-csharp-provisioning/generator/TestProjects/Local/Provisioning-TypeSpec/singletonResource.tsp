import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;
using Azure.Core;

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

/** A top-level singleton discovered from a legacy fixed route. */
model LegacySingleton is ProxyResource<LegacySingletonProperties> {
  ...ResourceNameParameter<
    Resource = LegacySingleton,
    KeyName = "legacySingletonName",
    SegmentName = "legacySingletons"
  >;
}

/** Properties of a legacy singleton. */
model LegacySingletonProperties {
  /** Indicates whether the legacy singleton is enabled. */
  enabled?: boolean;
}

alias LegacySingletonOperations = LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider;
  },
  {
    /** The fixed singleton resource name. */
    @path
    @segment("legacySingletons")
    @key
    legacySingletonName: "default";
  },
  ErrorResponse,
  ResourceName = "LegacySingleton"
>;

@armResourceOperations(#{ omitTags: true })
interface LegacySingletons {
  get is LegacySingletonOperations.Read<LegacySingleton>;
  createOrUpdate is LegacySingletonOperations.CreateOrUpdateSync<LegacySingleton>;
}

/** A singleton whose parent resource type is not generated. */
model OrphanedSingleton is ProxyResource<OrphanedSingletonProperties> {
  ...ResourceNameParameter<
    Resource = OrphanedSingleton,
    KeyName = "orphanedSingletonName",
    SegmentName = "orphanedSingletons"
  >;
}

/** Properties of a singleton whose parent resource type is not generated. */
model OrphanedSingletonProperties {
  /** Indicates whether the orphaned singleton is enabled. */
  enabled?: boolean;
}

alias OrphanedSingletonOperations = LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider;

    /** The unmodeled parent resource name. */
    @path
    @segment("unmodeledParents")
    @key
    unmodeledParentName: string;
  },
  {
    /** The fixed singleton resource name. */
    @path
    @segment("orphanedSingletons")
    @key
    orphanedSingletonName: "default";
  },
  ErrorResponse,
  ResourceName = "OrphanedSingleton"
>;

@armResourceOperations(#{ omitTags: true })
interface OrphanedSingletons {
  get is OrphanedSingletonOperations.Read<OrphanedSingleton>;
  createOrUpdate is OrphanedSingletonOperations.CreateOrUpdateSync<OrphanedSingleton>;
}
