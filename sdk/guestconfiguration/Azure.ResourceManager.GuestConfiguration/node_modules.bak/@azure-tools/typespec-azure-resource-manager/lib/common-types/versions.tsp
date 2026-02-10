import "./commontypes.private.decorators.tsp";

using Versioning;

@versioned(Versions)
namespace Azure.ResourceManager.CommonTypes;

@Azure.ResourceManager.CommonTypes.Private.armCommonTypesVersions
@doc("The Azure Resource Manager common-types versions.")
enum Versions {
  @doc("The Azure Resource Manager v3 common types.")
  v3,

  @doc("The Azure Resource Manager v4 common types.")
  v4,

  @doc("The Azure Resource Manager v5 common types.")
  v5,

  @doc("The Azure Resource Manager v6 common types.")
  v6,
}
