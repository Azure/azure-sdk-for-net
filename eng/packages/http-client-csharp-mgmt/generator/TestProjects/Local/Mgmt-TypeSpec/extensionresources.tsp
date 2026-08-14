import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

/**
 * Test case for extension resources targeting different parent types.
 * This simulates the pattern where the same resource model is used with
 * multiple external parent resources, which should generate disambiguated
 * method names to avoid CS0111 duplicate member errors.
 */

// Define an extension resource that can be applied to different scopes
@doc("Configuration assignment for VM scope")
model VmConfigurationAssignment
  is Azure.ResourceManager.ExtensionResource<VmConfigurationAssignmentProperties> {
  ...ResourceNameParameter<
    Resource = VmConfigurationAssignment,
    KeyName = "vmConfigAssignmentName",
    SegmentName = "vmConfigurationAssignments",
    NamePattern = ""
  >;
}

@doc("Configuration assignment properties")
model VmConfigurationAssignmentProperties {
  @doc("The configuration name")
  configurationName?: string;

  @doc("The compliance status")
  complianceStatus?: "Compliant" | "NonCompliant" | "Pending";
}

// Define another extension resource for a different scope
@doc("Configuration assignment for hybrid machine scope")
model HcrpConfigurationAssignment
  is Azure.ResourceManager.ExtensionResource<HcrpConfigurationAssignmentProperties> {
  ...ResourceNameParameter<
    Resource = HcrpConfigurationAssignment,
    KeyName = "hcrpConfigAssignmentName",
    SegmentName = "hcrpConfigurationAssignments",
    NamePattern = ""
  >;
}

@doc("HCRP Configuration assignment properties")
model HcrpConfigurationAssignmentProperties {
  @doc("The configuration name")
  configurationName?: string;

  @doc("Machine compliance status")
  machineComplianceStatus?: "Compliant" | "NonCompliant" | "Unknown";
}

// Operations for VM configuration assignments
#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "Test"
@armResourceOperations
interface VmConfigurationAssignments {
  @doc("Get a VM configuration assignment")
  get is Extension.Read<Extension.ScopeParameter, VmConfigurationAssignment>;
}

// Operations for HCRP configuration assignments
#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "Test"
@armResourceOperations
interface HcrpConfigurationAssignments {
  @doc("Get an HCRP configuration assignment")
  get is Extension.Read<Extension.ScopeParameter, HcrpConfigurationAssignment>;
}

