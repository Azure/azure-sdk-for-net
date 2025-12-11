import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";
using Azure.ResourceManager;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

// This file demonstrates the scenario where different models can be used for parent/child resources.
// The emitter now supports generating separate resource metadata for each unique resource path,
// even if they share common properties or base models.

/** A practice resource model */
@tenantResource
model Practice is ProxyResource<PracticeProperties> {
  ...ResourceNameParameter<Practice>;
}

/** Practice properties */
model PracticeProperties {
  /** The description of the practice */
  description?: string;
}

/** Practice operations on /practices/{practiceName} */
@armResourceOperations
interface Practices {
  get is ArmResourceRead<Practice>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Practice>;
  delete is ArmResourceDeleteWithoutOkAsync<Practice>;
}

/** A practice version child resource - shares same properties but different model */
@tenantResource
@parentResource(Practice)
model PracticeVersion is ProxyResource<PracticeProperties> {
  ...ResourceNameParameter<PracticeVersion>;
}

/** Practice version operations on /practices/{practiceName}/practiceVersions/{versionName} */
@armResourceOperations
interface PracticeVersions {
  get is ArmResourceRead<PracticeVersion>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<PracticeVersion>;
  delete is ArmResourceDeleteWithoutOkAsync<PracticeVersion>;
}
