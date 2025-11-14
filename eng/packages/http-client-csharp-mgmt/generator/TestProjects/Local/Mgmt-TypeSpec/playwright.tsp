import "@typespec/rest";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

namespace MgmtTypeSpec;

using Azure.Core;
using Azure.ResourceManager;
using TypeSpec.Rest;

@doc("Subscription-level location-based Playwright quota resource.")
@parentResource(SubscriptionLocationResource)
model PlaywrightQuota is ProxyResource<PlaywrightQuotaProperties> {
  ...ResourceNameParameter<PlaywrightQuota, Type = PlaywrightQuotaName>;
}

@doc("Playwright quota names.")
union PlaywrightQuotaName {
  string,

  @doc("Quota for execution duration in minutes.")
  ExecutionMinutes: "ExecutionMinutes",
}

@doc("Subscription-level location-based Playwright quota resource properties.")
model PlaywrightQuotaProperties {
  @visibility(Lifecycle.Read)
  @doc("The subscription-level location-based Playwright quota resource free-trial properties.")
  freeTrial?: string;

  @visibility(Lifecycle.Read)
  @doc("The status of the last resource operation.")
  provisioningState?: string;
}


@armResourceOperations
interface PlaywrightQuotas {
  @doc("Get subscription-level location-based Playwright quota resource by name.")
  get is ArmResourceRead<PlaywrightQuota>;

  @doc("List Playwright quota resources for a given subscription Id.")
  listBySubscription is ArmListBySubscription<PlaywrightQuota>;

  createOrUpdate is ArmResourceCreateOrReplaceSync<PlaywrightQuota>;
}