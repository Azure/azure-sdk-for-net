import "@azure-tools/typespec-client-generator-core";
import "../Mgmt-TypeSpec/main.tsp";
import "./secondservice.tsp";

using Azure.ClientGenerator.Core;

/**
 * Combined client for multi-service scenario.
 * This tests that the generator correctly handles multiple TypeSpec services
 * compiled into a single C# namespace.
 */
@client({
  name: "MgmtTypeSpecCombinedClient",
  service: [MgmtTypeSpec, MgmtTypeSpecSecond],
})
namespace MgmtTypeSpecCombined;
