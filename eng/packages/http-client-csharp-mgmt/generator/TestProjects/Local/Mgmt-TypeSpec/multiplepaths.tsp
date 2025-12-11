import "@azure-tools/typespec-azure-resource-manager";
using Azure.ResourceManager;

namespace MgmtTypeSpec;

// TODO: This file demonstrates the scenario where the same model is used by two different
// resource interfaces operating at different paths (similar to the legacy-operations example).
// This scenario is currently not fully supported - both interfaces' methods would be merged
// into a single resource metadata entry.
//
// To properly support this, the emitter needs to:
// 1. Track resource metadata by unique resource path, not just by model ID
// 2. Derive resource names from interface names (e.g., "Practices" -> "Practice", "PracticeVersions" -> "PracticeVersion")
// 3. Generate separate metadata decorators for each unique resource path

/** A practice resource model - used by multiple resource interfaces */
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

// NOTE: To test the multiple-path scenario, we would need a second interface
// that uses the same Practice model but with a different path pattern.
// This would typically be done using operation templates or custom operations
// similar to the legacy-operations example in typespec-azure.
