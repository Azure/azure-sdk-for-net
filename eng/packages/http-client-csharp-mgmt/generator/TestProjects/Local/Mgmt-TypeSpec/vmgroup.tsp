using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Test resource for verifying Get and Delete operation naming with @@clientName decorator
 */
model WorkloadNetworkVmGroup is Azure.ResourceManager.TrackedResource<WorkloadNetworkVmGroupProperties> {
  ...ResourceNameParameter<
    Resource = WorkloadNetworkVmGroup,
    KeyName = "vmGroupId",
    SegmentName = "vmGroups",
    NamePattern = "^[a-zA-Z0-9-]{3,24}$"
  >;
}

model WorkloadNetworkVmGroupProperties {
  /** Display name of the VM group. */
  displayName?: string;
  
  /** Virtual machine members of this group. */
  members?: string[];
  
  /** Provisioning state of the resource. */
  @visibility(Lifecycle.Read)
  provisioningState?: string;
}

/**
 * Test resource for verifying Get and Delete operation naming with @@clientName decorator
 */
model WorkloadNetworkSegment is Azure.ResourceManager.TrackedResource<WorkloadNetworkSegmentProperties> {
  ...ResourceNameParameter<
    Resource = WorkloadNetworkSegment,
    KeyName = "segmentId",
    SegmentName = "segments",
    NamePattern = "^[a-zA-Z0-9-]{3,24}$"
  >;
}

model WorkloadNetworkSegmentProperties {
  /** Display name of the segment. */
  displayName?: string;
  
  /** Connected gateway. */
  connectedGateway?: string;
  
  /** Subnet for the segment. */
  subnet?: string;
  
  /** Provisioning state of the resource. */
  @visibility(Lifecycle.Read)
  provisioningState?: string;
}

/**
 * Parent resource for workload networks
 */
model WorkloadNetworks is Azure.ResourceManager.TrackedResource<WorkloadNetworksProperties> {
  ...ResourceNameParameter<
    Resource = WorkloadNetworks,
    KeyName = "workloadNetworkName",
    SegmentName = "workloadNetworks",
    NamePattern = "^[a-zA-Z0-9-]{3,24}$"
  >;
}

model WorkloadNetworksProperties {
  /** Display name of the workload network. */
  displayName?: string;
  
  /** Provisioning state of the resource. */
  @visibility(Lifecycle.Read)
  provisioningState?: string;
}

@armResourceOperations
interface WorkloadNetworksOps {
  get is ArmResourceRead<WorkloadNetworks>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<WorkloadNetworks>;
  delete is ArmResourceDeleteWithoutOkAsync<WorkloadNetworks>;
  list is ArmResourceListByParent<WorkloadNetworks>;
}

@armResourceOperations
interface WorkloadNetworkVmGroups {
  /**
   * Get a VM Group by name.
   * Uses @@clientName to rename to 'GetVmGroup', but should still generate as 'Get'/'GetAsync'.
   */
  get is ArmResourceRead<WorkloadNetworkVmGroup>;

  /**
   * Create or update a VM Group.
   */
  createOrUpdate is ArmResourceCreateOrReplaceAsync<WorkloadNetworkVmGroup>;

  /**
   * Update a VM Group.
   * Uses @@clientName to rename to 'UpdateVmGroup', but should still generate as 'Update'/'UpdateAsync'.
   */
  update is ArmCustomPatchAsync<WorkloadNetworkVmGroup, WorkloadNetworkVmGroup>;

  /**
   * Delete a VM Group.
   * Uses @@clientName to rename to 'DeleteVmGroup', but should still generate as 'Delete'/'DeleteAsync'.
   */
  delete is ArmResourceDeleteWithoutOkAsync<WorkloadNetworkVmGroup>;

  /**
   * List VM Groups.
   */
  list is ArmResourceListByParent<WorkloadNetworkVmGroup>;
}

@armResourceOperations
interface WorkloadNetworkSegments {
  /**
   * Get a Segment by name.
   * Uses @@clientName to rename to 'GetSegment', but should still generate as 'Get'/'GetAsync'.
   */
  get is ArmResourceRead<WorkloadNetworkSegment>;

  /**
   * Create or update a Segment.
   */
  createOrUpdate is ArmResourceCreateOrReplaceAsync<WorkloadNetworkSegment>;

  /**
   * Update a Segment.
   * Uses @@clientName to rename to 'UpdateSegment', but should still generate as 'Update'/'UpdateAsync'.
   */
  update is ArmCustomPatchAsync<WorkloadNetworkSegment, WorkloadNetworkSegment>;

  /**
   * Delete a Segment.
   * Uses @@clientName to rename to 'DeleteSegment', but should still generate as 'Delete'/'DeleteAsync'.
   */
  delete is ArmResourceDeleteWithoutOkAsync<WorkloadNetworkSegment>;

  /**
   * List Segments.
   */
  list is ArmResourceListByParent<WorkloadNetworkSegment>;
}
