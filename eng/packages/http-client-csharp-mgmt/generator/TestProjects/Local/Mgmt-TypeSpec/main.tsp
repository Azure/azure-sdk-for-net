import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
import "./PrivateEndpointConnection.tsp";
import "./foo.tsp";
import "./bar.tsp";
import "./baz.tsp";
import "./zoo.tsp";
import "./routes.tsp";
import "./endpoint.tsp";
import "./selfhelp.tsp";
import "./playwright.tsp";
import "./databox.tsp";
using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{
  title: "MgmtTestClient",
})
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace MgmtTypeSpec;

interface Operations extends Azure.ResourceManager.Operations {}

/** The available API versions. */
enum Versions {
  /** Azure Cosmos DB for Mongo vCore clusters api version 2024-03-01-preview. */
  @useDependency(Azure.ResourceManager.Versions.v1_0_Preview_1)
  @useDependency(Azure.Core.Versions.v1_0_Preview_1)
  v2024_05_01: "2024-05-01",
}

@@clientLocation(Bars.get, "Bar");
@@clientLocation(Bars.update, "Bar");

#suppress "deprecated"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(BarSettingsResource.flattenedNestedProperty);