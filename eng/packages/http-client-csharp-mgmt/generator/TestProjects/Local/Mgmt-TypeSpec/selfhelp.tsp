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