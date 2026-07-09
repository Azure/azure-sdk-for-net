import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";
import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";

using Azure.ClientGenerator.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Foundations;
using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;

@armProviderNamespace
@service(#{ title: "SolutionsClient" })
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace Microsoft.Solutions;

enum Versions {
  v2023_12_01_preview: "2023-12-01-preview",
}

/** Resource information. */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "reduced Solutions conversion repro"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "reduced Solutions conversion repro"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "reduced Solutions conversion repro"
@Azure.ResourceManager.Legacy.customAzureResource(#{ isAzureResource: true })
model Resource {
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
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "reduced Solutions conversion repro"
  tags?: Record<string>;
}

/** Resource information. */
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "reduced Solutions conversion repro"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "reduced Solutions conversion repro"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "reduced Solutions conversion repro"
model GenericResource extends Resource {
  /** ID of the resource that manages this resource. */
  managedBy?: string;
}

/** Information about managed application definition. */
#suppress "@azure-tools/typespec-azure-core/no-private-usage" "reduced Solutions conversion repro"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "reduced Solutions conversion repro"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "reduced Solutions conversion repro"
@Http.Private.includeInapplicableMetadataInPayload(false)
model ApplicationDefinition extends GenericResource {
  @visibility(Lifecycle.Read)
  @path
  @key("applicationDefinitionName")
  @minLength(2)
  @maxLength(10)
  @segment("applicationDefinitions")
  name: string;

  /** The managed application definition properties. */
  properties: ApplicationDefinitionProperties;
}

model ApplicationDefinitionProperties {
  /** The managed application definition display name. */
  displayName?: string;
}

/** Information about an application definition request. */
#suppress "@azure-tools/typespec-azure-resource-manager/patch-envelope" "reduced Solutions conversion repro"
model ApplicationDefinitionPatchable {
  /** Application definition tags. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "reduced Solutions conversion repro"
  tags?: Record<string>;
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "reduced Solutions conversion repro"
alias ApplicationDefinitionOps = Azure.ResourceManager.Legacy.RoutedOperations<
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

@route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/applicationDefinitions/{applicationDefinitionName}?disambiguation_dummy")
@armResourceOperations(#{ allowStaticRoutes: true })
interface ApplicationDefinitions {
  /** Gets the managed application definition. */
  @sharedRoute
  get is ApplicationDefinitionOps.Read<
    ApplicationDefinition,
    Response = ArmResponse<ApplicationDefinition> | NotFoundResponse
  >;

  /** Creates or updates a managed application definition. */
  @sharedRoute
  createOrUpdate is ApplicationDefinitionOps.CreateOrUpdateSync<ApplicationDefinition>;

  /** Updates the managed application definition. */
  @sharedRoute
  @patch(#{ implicitOptionality: false })
  update is ApplicationDefinitionOps.CustomPatchSync<
    ApplicationDefinition,
    PatchModel = ApplicationDefinitionPatchable
  >;
}

@@clientName(
  ApplicationDefinitions.createOrUpdate::parameters.resource,
  "parameters"
);
@@clientName(
  ApplicationDefinitions.update::parameters.properties,
  "parameters"
);
