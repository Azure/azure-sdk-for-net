import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Rest;
using TypeSpec.Http;
using Azure.ResourceManager;
using TypeSpec.Versioning;

/**
 * Second service in a multi-service scenario.
 * This service exists to test the multi-service client compilation path where
 * multiple services share the same C# namespace.
 */
#suppress "@azure-tools/typespec-azure-resource-manager/missing-operations-endpoint" "Operations defined in main service"
@armProviderNamespace("Microsoft.MgmtTypeSpec")
@service(#{ title: "MgmtTypeSpec Second Service" })
@versioned(SecondServiceVersions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace MgmtTypeSpecSecond;

/** The available API versions for the second service. */
enum SecondServiceVersions {
  v2024_06_01: "2024-06-01",
}

/** A gadget resource managed by the second service. */
model Gadget is TrackedResource<GadgetProperties> {
  ...ResourceNameParameter<Gadget, SegmentName = "gadgets">;
}

/** Properties of a gadget. */
model GadgetProperties {
  /** Display name */
  displayName?: string;

  /** Description of the gadget */
  description?: string;

  /** The provisioning state. */
  @visibility(Lifecycle.Read)
  provisioningState?: Azure.ResourceManager.ResourceProvisioningState;
}

@armResourceOperations
interface Gadgets {
  get is ArmResourceRead<Gadget>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Gadget>;
  delete is ArmResourceDeleteWithoutOkAsync<Gadget>;
  update is ArmCustomPatchSync<Gadget, Gadget>;
  list is ArmResourceListByParent<Gadget>;
  listBySubscription is ArmListBySubscription<Gadget>;
}
