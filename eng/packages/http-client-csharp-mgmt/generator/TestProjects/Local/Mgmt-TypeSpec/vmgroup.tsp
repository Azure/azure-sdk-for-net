using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Test resource for verifying Get and Delete operation naming with custom operation names
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

@armResourceOperations
interface WorkloadNetworkVmGroups {
  /**
   * Get a VM Group by name.
   * This operation has a custom name 'getVmGroup' instead of just 'get'.
   * The generated method should still be named 'Get' or 'GetAsync', not 'GetVmGroup'.
   */
  getVmGroup is ArmResourceRead<WorkloadNetworkVmGroup>;

  /**
   * Create or update a VM Group.
   */
  createOrUpdate is ArmResourceCreateOrReplaceAsync<WorkloadNetworkVmGroup>;

  /**
   * Delete a VM Group.
   * This operation has a custom name 'deleteVmGroup' instead of just 'delete'.
   * The generated method should still be named 'Delete' or 'DeleteAsync', not 'DeleteVmGroup'.
   */
  deleteVmGroup is ArmResourceDeleteWithoutOkAsync<WorkloadNetworkVmGroup>;

  /**
   * List VM Groups.
   */
  list is ArmResourceListByParent<WorkloadNetworkVmGroup>;
}
