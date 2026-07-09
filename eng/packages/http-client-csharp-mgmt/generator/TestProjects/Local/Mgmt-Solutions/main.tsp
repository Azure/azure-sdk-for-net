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

/** Information about managed application definition. */
model ApplicationDefinition is Azure.ResourceManager.ProxyResource<ApplicationDefinitionProperties> {
  ...ResourceNameParameter<
    Resource = ApplicationDefinition,
    KeyName = "applicationDefinitionName",
    SegmentName = "applicationDefinitions"
  >;

  /** Resource tags. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "reduced Solutions conversion repro"
  tags?: Record<string>;
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
    @path
    @segment("solutionNames")
    solutionName: string;
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

@route("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Solutions/solutionNames/{solutionName}/applicationDefinitions/{applicationDefinitionName}")
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
