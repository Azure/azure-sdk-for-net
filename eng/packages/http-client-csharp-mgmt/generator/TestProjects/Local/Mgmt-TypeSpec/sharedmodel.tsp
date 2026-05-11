import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";
import "@typespec/http";
using Azure.ResourceManager;
using TypeSpec.Rest;
using TypeSpec.Http;

namespace MgmtTypeSpec;

// This file tests the scenario where TWO ARM resources at DIFFERENT SCOPES share the SAME model.
// This matches the Maintenance service pattern where:
// - SharedConfig (RG-scoped) has full CRUD
// - PublicSharedConfig (Subscription-scoped) is read-only with list
// Both use the same SharedConfig model and SharedConfigData in the generated code.
// The generator must produce separate Resource/Collection classes for each,
// and the subscription-scoped list must generate a pageable on MockableSubscriptionResource.

/** A shared configuration resource */
model SharedConfigProperties {
  /** Display name */
  displayName?: string;

  /** Description */
  description?: string;

  ...DefaultProvisioningStateProperty;
}

/** Shared configuration - used at both RG and Subscription scope */
model SharedConfig is TrackedResource<SharedConfigProperties> {
  ...ResourceNameParameter<
    Resource = SharedConfig,
    KeyName = "configName",
    SegmentName = "sharedConfigs",
    NamePattern = ""
  >;
}

// ---- Subscription-scoped resource (read-only + list) ----
// Uses ExtensionOperations with OverrideResourceName to create a separate
// resource class (PublicSharedConfigResource) from the same model.
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "For testing"
alias PublicSharedConfigOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
  },
  {
    ...Extension.ExtensionProviderNamespace<SharedConfig>;
    ...ParentKeysOf<SharedConfig>;
  },
  {
    ...Extension.ExtensionProviderNamespace<SharedConfig>;
    ...KeysOf<ResourceNameParameter<
      Resource = SharedConfig,
      KeyName = "configName",
      SegmentName = "publicSharedConfigs",
      NamePattern = ""
    >>;
  },
  "PublicSharedConfig"  // OverrideResourceName - creates separate resource class
>;

/** Read-only interface at subscription scope with different segment */
@armResourceOperations
interface PublicSharedConfigs {
  get is PublicSharedConfigOps.Read<SharedConfig>;
  list is PublicSharedConfigOps.List<SharedConfig>;
}

/** Full CRUD interface at resource group scope */
@armResourceOperations
interface SharedConfigs {
  get is Extension.Read<Extension.ResourceGroup, SharedConfig>;
  createOrUpdate is Extension.CreateOrUpdateAsync<Extension.ResourceGroup, SharedConfig>;
  delete is Extension.DeleteSync<Extension.ResourceGroup, SharedConfig>;
  list is Extension.ListByTarget<Extension.ResourceGroup, SharedConfig>;
}
