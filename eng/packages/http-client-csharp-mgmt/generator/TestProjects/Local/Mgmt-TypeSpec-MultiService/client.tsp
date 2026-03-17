import "@azure-tools/typespec-client-generator-core";
import "./serviceOne.tsp";
import "./serviceTwo.tsp";

using Azure.ClientGenerator.Core;

@@client(ServiceOne,
  {
    name: "MultiServiceClient",
    service: [ServiceOne, ServiceTwo],
  }
);
