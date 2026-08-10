import "@azure-tools/typespec-client-generator-core";
import "./ServiceOne/main.tsp";
import "./ServiceTwo/main.tsp";

using Azure.ClientGenerator.Core;

@client({
  name: "MultiServiceClient",
  service: [ServiceOne, ServiceTwo],
  autoMergeService: true,
})
namespace MultiServiceCombine;
