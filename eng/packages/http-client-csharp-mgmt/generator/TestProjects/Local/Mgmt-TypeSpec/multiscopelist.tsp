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
 * Test case mirroring the PolicyAssignment shape: an Extension resource with FOUR
 * list operations at different ARM scopes (Subscription, ResourceGroup, ManagementGroup,
 * and any nested resource scope). The generator should produce ONE
 * `MultiScopeWidgetCollection.GetAll(filter, top, ct)` whose body dispatches on
 * `Id.ResourceType` and sources path params from `Id`, NOT four separate raw-path
 * methods. (Regression test for issue #58168.)
 */

@doc("Multi-scope widget extension resource properties")
model MultiScopeWidgetProperties {
  @doc("Display name")
  displayName?: string;
}

@doc("An extension resource attached to any ARM scope")
model MultiScopeWidget
  is Azure.ResourceManager.ExtensionResource<MultiScopeWidgetProperties> {
  ...ResourceNameParameter<
    Resource = MultiScopeWidget,
    KeyName = "widgetName",
    SegmentName = "multiScopeWidgets",
    NamePattern = ""
  >;
}

#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "Test"
@armResourceOperations
interface MultiScopeWidgets {
  @doc("Get a widget at the given scope")
  get is Extension.Read<Extension.ScopeParameter, MultiScopeWidget>;

  @doc("List widgets in a subscription")
  listAtSubscription is Extension.ListByTarget<Extension.Subscription, MultiScopeWidget>;

  @doc("List widgets in a resource group")
  listAtResourceGroup is Extension.ListByTarget<Extension.ResourceGroup, MultiScopeWidget>;

  @doc("List widgets in a management group")
  listAtManagementGroup is Extension.ListByTarget<Extension.ManagementGroup, MultiScopeWidget>;

  @doc("List widgets at any ARM scope")
  listAtScope is Extension.ListByTarget<Extension.ScopeParameter, MultiScopeWidget>;
}
