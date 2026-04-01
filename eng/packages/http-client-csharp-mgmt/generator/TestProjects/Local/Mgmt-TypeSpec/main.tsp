import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.Core;
using Azure.ResourceManager;

@armProviderNamespace
@service(#{ title: "Microsoft.BillingTrust" })
@versioned(Versions)
namespace Microsoft.BillingTrust;

enum Versions {
  @armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
  @previewVersion
  `2026-03-17-preview`,
}

@doc("An assessment resource.")
model Assessment is ExtensionResource<AssessmentProperties> {
  ...ResourceNameParameter<Assessment>
}

@doc("The provisioning state of a resource.")
@lroStatus
union ProvisioningState {
  string,
  Succeeded: "Succeeded",
  Failed: "Failed",
  Cancelled: "Cancelled",
  Accepted: "Accepted",
}

@doc("The properties of an Assessment resource.")
model AssessmentProperties {
  @doc("The provisioning state of the resource")
  @visibility(Lifecycle.Read)
  provisioningState?: ProvisioningState;

  @doc("The template from which the rules of this assessment are instantiated.")
  ruleTemplateId: string;
}

interface Operations extends Azure.ResourceManager.Operations {}

interface AssessmentsOps<Scope extends Azure.ResourceManager.Foundations.SimpleResource> {
  get is Extension.Read<Scope, Assessment>;
  createOrUpdate is Extension.CreateOrReplaceAsync<Scope, Assessment>;
  delete is Extension.DeleteWithoutOkAsync<Scope, Assessment>;
  list is Extension.ListByTarget<Scope, Assessment>;
}

@armResourceOperations
interface Assessments extends AssessmentsOps<Extension.ScopeParameter> {}