import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{
  title: "ServiceOne",
})
@versioned(ServiceOne.Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace ServiceOne;

enum Versions {
  v2024_01_01: "2024-01-01",
}

model Foo is TrackedResource<FooProperties> {
  ...ResourceNameParameter<Foo>;
}

model FooProperties {
  displayName?: string;
  provisioningState?: ResourceProvisioningState;
}

@armResourceOperations
interface Foos {
  get is ArmResourceRead<Foo>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;
  delete is ArmResourceDeleteWithoutOkAsync<Foo>;
  list is ArmResourceListByParent<Foo>;
}

interface Operations extends Azure.ResourceManager.Operations {}

/**
 * A namespace-level operation (not inside an interface).
 * Tests that the generator handles operations defined directly on the namespace.
 */
@autoRoute
op checkAvailability is ArmProviderActionSync<
  Request = CheckAvailabilityRequest,
  Response = CheckAvailabilityResponse,
  Scope = SubscriptionActionScope,
  Parameters = {
    @path
    @segment("locations")
    location: Azure.Core.azureLocation;
  }
>;

model CheckAvailabilityRequest {
  /** The name to check availability for. */
  name: string;
}

model CheckAvailabilityResponse {
  /** Whether the name is available. */
  isAvailable: boolean;

  /** Reason the name is not available. */
  @visibility(Lifecycle.Read)
  reason?: string;
}
