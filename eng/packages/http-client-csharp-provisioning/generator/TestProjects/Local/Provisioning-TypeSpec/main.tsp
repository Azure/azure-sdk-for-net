import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
import "./configurationStore.tsp";
import "./keyValue.tsp";
import "./backupPolicy.tsp";

using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;
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
    v2024_05_01: "2024-05-01",
  }
}
