import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

model SelfHelpResource
  is Azure.ResourceManager.ExtensionResource<SelfHelpResourceProperties> {
  ...ResourceNameParameter<
    Resource = SelfHelpResource,
    KeyName = "selfHelpName",
    SegmentName = "selfHelps",
    NamePattern = ""
  >;
}

model SelfHelpResourceProperties {
  selfHelpId: string;
}

#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
@armResourceOperations
interface SolutionResources {
  get is Extension.Read<Extension.ScopeParameter, SelfHelpResource>;
}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
@autoRoute
interface CheckNameAvailabilityOperationGroup {
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-operation" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  checkNameAvailability is ArmProviderActionSync<
    CommonTypes.CheckNameAvailabilityRequest,
    CheckNameAvailabilityResponse,
    ExtensionActionScope,
    OptionalRequestBody = true
  >;
}

model CheckNameAvailabilityResponse {
  nameAvailable: boolean;
  reason?: string;
  message?: string;
}

/**
 * Reproducer for issue #58484: extension-scoped non-resource operation that exposes a
 * `@query("scope")` parameter. This collides with the synthetic `scope` ResourceIdentifier
 * parameter that the mgmt generator adds for extension-scoped methods on ArmClient, and
 * previously caused ParameterContextRegistry.FindParameter to throw
 * "Sequence contains more than one matching element".
 */
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-interface-requires-decorator" "Reproducer for #58484"
@autoRoute
interface SelfHelpScopeQueryOperationGroup {
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-operation" "Reproducer for #58484"
  @get
  @action("selfHelpDetails")
  getDetails(
    ...ApiVersionParameter,

    @path(#{ allowReserved: true })
    @segment("")
    resourceScope: string,

    ...Azure.ResourceManager.Legacy.Provider,

    @query("scope")
    scopeFilter: string,
  ): CheckNameAvailabilityResponse | ErrorResponse;
}