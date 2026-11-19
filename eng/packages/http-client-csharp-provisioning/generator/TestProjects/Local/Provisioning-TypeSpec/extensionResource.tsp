import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace ProvisioningTypeSpec;

alias BillingAccount = Extension.ExternalResource<
  "Microsoft.Billing",
  "billingAccounts",
  "billingAccountName",
  ParentType = "Tenant"
>;

alias BillingProfile = Extension.ExternalChildResource<
  BillingAccount,
  "billingProfiles",
  "billingProfileName"
>;

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
  get is Extension.Read<BillingProfile, ExtensionAssignment>;

  createOrUpdate is Extension.CreateOrUpdateAsync<
    BillingProfile,
    ExtensionAssignment
  >;
}

/** An existing-only assignment at an external resource scope. */
@singleton("default")
model ReadOnlyExtension
  is Azure.ResourceManager.ExtensionResource<ExtensionAssignmentProperties> {
  ...ResourceNameParameter<
    Resource = ReadOnlyExtension,
    KeyName = "readOnlyExtensionName",
    SegmentName = "readOnlyExtensions"
  >;
}

@armResourceOperations
interface ReadOnlyExtensions {
  get is Extension.Read<BillingProfile, ReadOnlyExtension>;
}

/** A structural child that inherits its assignment's external scope. */
@parentResource(ExtensionAssignment)
model ExtensionChild is ProxyResource<ExtensionAssignmentProperties> {
  ...ResourceNameParameter<
    Resource = ExtensionChild,
    KeyName = "extensionChildName",
    SegmentName = "children"
  >;
}

@armResourceOperations
interface ExtensionChildren {
  get is Extension.Read<BillingProfile, ExtensionChild>;
  createOrUpdate is Extension.CreateOrUpdateAsync<
    BillingProfile,
    ExtensionChild
  >;
}

/** An assignment available at both resource-group and external scopes. */
model MultiScopeAssignment
  is Azure.ResourceManager.ExtensionResource<ExtensionAssignmentProperties> {
  ...ResourceNameParameter<
    Resource = MultiScopeAssignment,
    KeyName = "multiScopeAssignmentName",
    SegmentName = "multiScopeAssignments"
  >;
}

@armResourceOperations
interface MultiScopeAssignments {
  get is Extension.Read<Extension.ScopeParameter, MultiScopeAssignment>;
  createOrUpdate is Extension.CreateOrUpdateAsync<
    Extension.ScopeParameter,
    MultiScopeAssignment
  >;
}

@armResourceOperations
interface ResourceGroupAssignments {
  get is Extension.Read<Extension.ResourceGroup, MultiScopeAssignment>;
  createOrUpdate is Extension.CreateOrUpdateAsync<
    Extension.ResourceGroup,
    MultiScopeAssignment
  >;
}
