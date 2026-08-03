import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

/** An assignment applied to another Azure resource as an extension resource. */
model ExtensionAssignment
  is Azure.ResourceManager.ExtensionResource<ExtensionAssignmentProperties> {
  ...ResourceNameParameter<
    Resource = ExtensionAssignment,
    KeyName = "extensionAssignmentName",
    SegmentName = "extensionAssignments",
    NamePattern = ""
  >;
}

/** The properties of an extension assignment. */
model ExtensionAssignmentProperties {
  /** The display name of the assignment. */
  displayName?: string;
}

@armResourceOperations
interface ExtensionAssignments {
  get is Extension.Read<Extension.ScopeParameter, ExtensionAssignment>;

  createOrUpdate is Extension.CreateOrUpdateAsync<
    Extension.ScopeParameter,
    ExtensionAssignment
  >;
}
