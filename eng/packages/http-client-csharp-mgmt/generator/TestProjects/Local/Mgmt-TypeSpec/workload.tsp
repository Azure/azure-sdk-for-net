using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;
using Azure.ResourceManager.Foundations;

namespace MgmtTypeSpec;
/**
 * Define the Virtual Instance for SAP solutions resource.
 */
#suppress "@azure-tools/typespec-azure-core/casing-style" "SAP is used for representing the company product."
model SAPVirtualInstance is Azure.ResourceManager.TrackedResource<SAPVirtualInstanceProperties> {
  ...ResourceNameParameter<
    Resource = SAPVirtualInstance,
    KeyName = "sapVirtualInstanceName",
    SegmentName = "sapVirtualInstances",
    NamePattern = "^[a-zA-Z][a-zA-Z0-9]{2}$"
  >;
}

model SAPVirtualInstanceProperties {
  name: string;
}

#suppress "@azure-tools/typespec-azure-core/casing-style" "SAP is used for representing the company product."
@armResourceOperations
interface SAPVirtualInstances {
  /**
   * Gets a Virtual Instance for SAP solutions resource
   */
  get is ArmResourceRead<SAPVirtualInstance>;

  /**
   * Creates a Virtual Instance for SAP solutions (VIS) resource
   */
  create is ArmResourceCreateOrReplaceAsync<SAPVirtualInstance>;

  /**
   * Get the recommended SAP Availability Zone Pair Details for your region.
   */
  getAvailabilityZoneDetails is ArmResourceActionSync<
    SubscriptionLocationResource,
    SAPAvailabilityZoneDetailsRequest,
    SAPAvailabilityZoneDetailsResult,
    Parameters = {
      @path
      @segment("sapVirtualInstanceMetadata")
      @key
      name: "default";
    }
  >;
}

model SAPAvailabilityZoneDetailsRequest {
  /** The preferred availability zone */
  preferredAvailabilityZone: string;
}

model SAPAvailabilityZoneDetailsResult {
  /** The recommended availability zone pair */
  recommendedAvailabilityZonePair: string;
}