import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;

namespace MgmtTypeSpec;

/**
 * Test resource for verifying explicit ResourceName on ExtensionOperations.
 * Same model used by two different extension interfaces with different parent paths.
 * Each interface specifies an explicit ResourceName to control generated class names.
 */
model PolicyAssignment is ProxyResource<PolicyAssignmentProperties> {
  @key("policyAssignmentName")
  @segment("policyAssignments")
  @path
  @visibility(Lifecycle.Read)
  name: string;
}

model PolicyAssignmentProperties {
  @doc("Display name of the policy assignment")
  displayName?: string;

  @doc("Description of the policy assignment")
  description?: string;
}

// Interface 1: Policy assignments on VMs
alias PolicyAssignmentVmOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;

    @path
    @segment("providers")
    @key
    providerNamespace: "Microsoft.Compute";

    @segment("virtualMachines")
    @key
    @path
    vmName: string;
  },
  {
    ...Extension.ExtensionProviderNamespace<PolicyAssignment>;
  },
  {
    ...Extension.ExtensionProviderNamespace<PolicyAssignment>;

    @path
    @key
    @segment("policyAssignments")
    policyAssignmentName: string;
  },
  "PolicyVmAssignment"
>;

@armResourceOperations
interface PolicyVmAssignments {
  get is PolicyAssignmentVmOps.Read<PolicyAssignment, ErrorType = ErrorResponse>;

  createOrUpdate is PolicyAssignmentVmOps.CreateOrUpdateSync<
    PolicyAssignment,
    ErrorType = ErrorResponse
  >;

  delete is PolicyAssignmentVmOps.DeleteSync<
    PolicyAssignment,
    Response = ArmDeletedResponse,
    ErrorType = ErrorResponse
  >;

  list is PolicyAssignmentVmOps.List<PolicyAssignment, ErrorType = ErrorResponse>;
}

// Interface 2: Policy assignments on ARC machines
alias PolicyAssignmentArcOps = Azure.ResourceManager.Legacy.ExtensionOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;

    @path
    @segment("providers")
    @key
    providerNamespace: "Microsoft.HybridCompute";

    @segment("machines")
    @key
    @path
    machineName: string;
  },
  {
    ...Extension.ExtensionProviderNamespace<PolicyAssignment>;
  },
  {
    ...Extension.ExtensionProviderNamespace<PolicyAssignment>;

    @path
    @key
    @segment("policyAssignments")
    policyAssignmentName: string;
  },
  "PolicyArcAssignment"
>;

@armResourceOperations
interface PolicyArcAssignments {
  get is PolicyAssignmentArcOps.Read<PolicyAssignment, ErrorType = ErrorResponse>;

  createOrUpdate is PolicyAssignmentArcOps.CreateOrUpdateSync<
    PolicyAssignment,
    ErrorType = ErrorResponse
  >;

  delete is PolicyAssignmentArcOps.DeleteSync<
    PolicyAssignment,
    Response = ArmDeletedResponse,
    ErrorType = ErrorResponse
  >;

  list is PolicyAssignmentArcOps.List<PolicyAssignment, ErrorType = ErrorResponse>;
}
