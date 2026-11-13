import "@azure-tools/typespec-azure-core";
import "@typespec/rest";
import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Rest;
using TypeSpec.Http;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/**
 * Runs the input conditions against input object metadata properties and designates matched objects in response.
 */
@autoRoute
op previewActions is ArmProviderActionSync<
  Request = FooPreviewAction,
  Response = FooPreviewAction,
  Scope = SubscriptionActionScope,
  Parameters = {
    @path
    @segment("locations")
    location: Azure.Core.azureLocation;
  }
>;

model FooPreviewAction {
  /** The action to be performed. */
  action: string;

  @visibility(Lifecycle.Read)
  result?: string;
}