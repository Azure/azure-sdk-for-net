import "@azure-tools/typespec-azure-resource-manager";
import "./api-version-override.tsp";
import "./api-version-escaping.tsp";
using TypeSpec.Versioning;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{ title: "API-version wire-default tests" })
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace MgmtTypeSpec;

/** Projected service versions, independent of the opaque wire defaults. */
enum Versions {
  previous: "2024-04-01",
  current: "2024-05-01",
}
