import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
import "./configurationStore.tsp";
import "./keyValue.tsp";
import "./backupPolicy.tsp";
import "./item.tsp";
import "./profileRevision.tsp";

using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;
using Azure.ClientGenerator.Core.Legacy;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{
  title: "ProvisioningTestClient",
})
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace ProvisioningTypeSpec {

  interface Operations extends Azure.ResourceManager.Operations {}

  /** The available API versions. */
  enum Versions {
    v2024_01_01_preview: "2024-01-01-preview",
    v2024_04_01: "2024-04-01",
    v2024_05_01: "2024-05-01",
  }

  // Test that SubResource inside a list is correctly resolved to Azure.Provisioning.Resources.SubResource
  @@alternateType(ConfigurationStoreProperties.linkedResources, Azure.ResourceManager.Models.SubResource[], "csharp");

  // Test that @flattenProperty on the properties envelope correctly flattens
  // child properties onto the resource while the standalone model keeps
  // unqualified paths (regression test for double-flatten bug).
  // We apply @flattenProperty to Item.properties (not KeyValue.properties)
  // because ItemProperties is also referenced by ItemCreateOrUpdateParameters,
  // so it survives as a standalone model — exposing the double-flatten bug.
  @@flattenProperty(Item.properties);

  // Test that when the same input model backs multiple resources (Profile +
  // ProfileRevision via LegacyOperations), flattening lands on the canonical
  // resource (Profile, matching the input model's name). See profileRevision.tsp.
  @@flattenProperty(Profile.properties);
}

// Dummy models to test alternateType replacement with SubResource
namespace Azure.ResourceManager.Models {
  model SubResource { }
}

// Define RBAC roles for testing BuiltInRole and CreateRoleAssignment generation
#suppress "@azure-tools/typespec-client-generator-core/client-option" "RBAC roles for provisioning"
@@clientOption(ProvisioningTypeSpec.ConfigurationStore, "resource-rbac-roles", #{
  ConfigStoreContributor: "00000000-0000-0000-0000-000000000001",
  ConfigStoreReader: "00000000-0000-0000-0000-000000000002",
  ConfigStoreDataOperator: "00000000-0000-0000-0000-000000000003",
}, "csharp");
