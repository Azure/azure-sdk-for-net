import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Rest;
using TypeSpec.Http;
using Azure.ResourceManager;
using Azure.ResourceManager.Foundations;

namespace MgmtTypeSpec;

@doc("Test Action Response")
model TestActionResponse {
  @doc("The action result")
  result?: string;

  @doc("The action status")
  status?: string;
}

/**
 * Performs a test action at subscription scope
 */
@autoRoute
op performTestAction is ArmProviderActionSync<
  Request = TestActionResponse,
  Response = TestActionResponse,
  Scope = SubscriptionActionScope,
  Parameters = {
    @path
    @segment("locations")
    location: Azure.Core.azureLocation;
  }
>;
