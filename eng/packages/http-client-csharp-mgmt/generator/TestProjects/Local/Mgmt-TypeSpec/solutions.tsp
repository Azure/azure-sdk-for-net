import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ClientGenerator.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Foundations;
using Azure.ResourceManager.Legacy;

namespace MgmtTypeSpec;

/** Reduced Solutions resource information. */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Reduced Solutions conversion regression test"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Reduced Solutions conversion regression test"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Reduced Solutions conversion regression test"
@customAzureResource(#{ isAzureResource: true })
model SolutionsResource {
  /** Resource ID. */
  @visibility(Lifecycle.Read)
  id?: Azure.Core.armResourceIdentifier;

  /** Resource name. */
  @visibility(Lifecycle.Read)
  name?: string;

  /** Resource type. */
  @visibility(Lifecycle.Read)
  type?: string;

  /** Resource tags. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "Reduced Solutions conversion regression test"
  tags?: Record<string>;
}

/** Reduced Solutions generic resource. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Reduced Solutions conversion regression test"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Reduced Solutions conversion regression test"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Reduced Solutions conversion regression test"
model SolutionsGenericResource extends SolutionsResource {
  /** ID of the resource that manages this resource. */
  managedBy?: string;
}

/** Reduced managed application definition for the invalid query-suffixed route repro. */
#suppress "@azure-tools/typespec-azure-core/no-private-usage" "Reduced Solutions conversion regression test"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Reduced Solutions conversion regression test"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Reduced Solutions conversion regression test"
@Http.Private.includeInapplicableMetadataInPayload(false)
model SolutionsApplicationDefinition extends SolutionsGenericResource {
  @visibility(Lifecycle.Read)
  @path
  @key("applicationDefinitionName")
  @minLength(2)
  @maxLength(10)
  @segment("applicationDefinitions")
  name: string;

  /** The managed application definition properties. */
  properties: SolutionsApplicationDefinitionProperties;
}

model SolutionsApplicationDefinitionProperties {
  /** The managed application definition display name. */
  displayName?: string;
}

/** Information about a query-suffixed application definition request. */
#suppress "@azure-tools/typespec-azure-resource-manager/patch-envelope" "Reduced Solutions conversion regression test"
model SolutionsApplicationDefinitionPatchable {
  /** Application definition tags. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "Reduced Solutions conversion regression test"
  tags?: Record<string>;
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Reduced Solutions conversion regression test"
alias SolutionsApplicationDefinitionOps = Azure.ResourceManager.Legacy.RoutedOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
  },
  {
    /** The name of the managed application definition. */
    @path
    @key
    @minLength(3)
    @maxLength(64)
    @segment("applicationDefinitions")
    applicationDefinitionName: string;
  },
  ResourceRoute = #{ useStaticRoute: true }
>;

@route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/applicationDefinitions/{applicationDefinitionName}?disambiguation_dummy")
@armResourceOperations(#{ allowStaticRoutes: true })
interface SolutionsApplicationDefinitions {
  /** Gets the managed application definition on a disambiguated route. */
  @sharedRoute
  get is SolutionsApplicationDefinitionOps.Read<
    SolutionsApplicationDefinition,
    Response = ArmResponse<SolutionsApplicationDefinition> | NotFoundResponse
  >;

  /** Creates or updates a managed application definition on a disambiguated route. */
  @sharedRoute
  createOrUpdate is SolutionsApplicationDefinitionOps.CreateOrUpdateSync<SolutionsApplicationDefinition>;

  /** Updates the managed application definition on a disambiguated route. */
  @sharedRoute
  @patch(#{ implicitOptionality: false })
  update is SolutionsApplicationDefinitionOps.CustomPatchSync<
    SolutionsApplicationDefinition,
    PatchModel = SolutionsApplicationDefinitionPatchable
  >;
}

@@clientName(
  SolutionsApplicationDefinitions.createOrUpdate::parameters.resource,
  "parameters"
);
@@clientName(
  SolutionsApplicationDefinitions.update::parameters.properties,
  "parameters"
);
