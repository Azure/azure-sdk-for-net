import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";
import "@typespec/spector";
import "@typespec/http";
import "@typespec/versioning";

using Azure.ClientGenerator.Core;
using Spector;
using Versioning;

@client({
  service: [Service.MultiService.ServiceA, Service.MultiService.ServiceB],
})
namespace Service.MultiService.Mixed;