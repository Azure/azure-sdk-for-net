// Test case for custom Azure resource pattern (like TrafficManager)
// This tests support for @customAzureResource decorator per issue #53208

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;

namespace MgmtTypeSpec;

// Custom base Resource model with @customAzureResource decorator
// This pattern is used by legacy services like TrafficManager
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
@customAzureResource
model TrafficResource {
  id?: Azure.Core.armResourceIdentifier;
  name?: string;
  type?: string;
}

// Custom ProxyResource extending the custom Resource
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/no-empty-model" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
model TrafficProxyResource extends TrafficResource {}

// Custom TrackedResource with location and tags (should map to TrackedResourceData)
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
model TrafficTrackedResource extends TrafficResource {
  @visibility(Lifecycle.Create, Lifecycle.Read, Lifecycle.Update)
  tags?: Record<string>;
  @visibility(Lifecycle.Create, Lifecycle.Read)
  location?: string;
}

// Traffic Profile - a tracked resource (parent)
model TrafficProfileProperties {
  profileStatus?: TrafficProfileStatus;
  trafficRoutingMethod?: TrafficRoutingMethod;
}

@doc("Traffic profile status")
union TrafficProfileStatus {
  string,
  Enabled: "Enabled",
  Disabled: "Disabled",
}

@doc("Traffic routing method")
union TrafficRoutingMethod {
  string,
  Performance: "Performance",
  Priority: "Priority",
  Weighted: "Weighted",
  Geographic: "Geographic",
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
model TrafficProfile extends TrafficTrackedResource {
  properties?: TrafficProfileProperties;
}

// Traffic Endpoint - a proxy resource (child under TrafficProfile)
model TrafficEndpointProperties {
  targetResourceId?: string;
  target?: string;
  endpointStatus?: TrafficEndpointStatus;
  weight?: int32;
  priority?: int32;
  endpointLocation?: string;
}

@doc("Traffic endpoint status")
union TrafficEndpointStatus {
  string,
  Enabled: "Enabled",
  Disabled: "Disabled",
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
@parentResource(TrafficProfile)
model TrafficEndpoint extends TrafficProxyResource {
  properties?: TrafficEndpointProperties;
}

// Operations using LegacyOperations pattern
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
alias TrafficProfileOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider<TrafficProfile>;
  },
  {
    @path
    @segment("trafficProfiles")
    profileName: string;
  },
  ErrorResponse,
  "TrafficProfile"
>;

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
@armResourceOperations
interface TrafficProfiles {
  get is TrafficProfileOps.Read<TrafficProfile>;
  createOrUpdate is TrafficProfileOps.CreateOrUpdateSync<TrafficProfile>;
  delete is TrafficProfileOps.DeleteSync<TrafficProfile>;
  list is TrafficProfileOps.List<TrafficProfile>;
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
alias TrafficEndpointOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Azure.ResourceManager.Legacy.Provider<TrafficProfile>;

    @path
    @segment("trafficProfiles")
    profileName: string;
  },
  {
    @path
    @segment("endpoints")
    endpointName: string;
  },
  ErrorResponse,
  "TrafficEndpoint"
>;

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "Testing LegacyOperations pattern"
interface TrafficEndpoints {
  get is TrafficEndpointOps.Read<TrafficEndpoint>;
  createOrUpdate is TrafficEndpointOps.CreateOrUpdateSync<TrafficEndpoint>;
  delete is TrafficEndpointOps.DeleteSync<TrafficEndpoint>;
}
