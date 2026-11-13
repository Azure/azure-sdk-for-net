import "@typespec/rest";
import "@typespec/http";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Rest;
using TypeSpec.Http;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

@doc("Scheduled action properties")
model ScheduledActionsExtensionProperties {
  @doc("The scheduled action identifier")
  actionId?: string;

  @doc("The scheduled action status")
  status?: string;
}

@doc("The scheduled action extension")
model ScheduledActionResources
  is Azure.ResourceManager.ExtensionResource<ScheduledActionsExtensionProperties> {
  ...ResourceNameParameter<
    ScheduledActionResources,
    SegmentName = "associatedScheduledActions"
  >;
}

// Scheduled action extension routes
@armResourceOperations
interface ScheduledActionExtension {
  listByVms is ArmResourceListByParent<ScheduledActionResources>;
}
