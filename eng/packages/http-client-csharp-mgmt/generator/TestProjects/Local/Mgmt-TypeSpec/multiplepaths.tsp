import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";
import "@typespec/http";
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;
using TypeSpec.Rest;
using TypeSpec.Http;

namespace MgmtTypeSpec;

// This file demonstrates the scenario where the SAME model is used by two different
// resource interfaces operating at different paths, matching the legacy-operations pattern.
// This uses Azure.ResourceManager.Legacy.LegacyOperations to define different path patterns
// for the same resource model.

/** A best practice resource - used by both parent and child operations */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "For sample purpose"
@tenantResource
model BestPractice is ProxyResource<BestPracticeProperties> {
  ...ResourceNameParameter<
    Resource = BestPractice,
    KeyName = "bestPracticeName",
    SegmentName = "bestPractices",
    NamePattern = ""
  >;
  ...Legacy.ExtendedLocationOptionalProperty;
}

/** Best practice properties */
model BestPracticeProperties {
  ...DefaultProvisioningStateProperty;

  /** The description of the best practice */
  description?: string;
}

// Define operation aliases with different path patterns using LegacyOperations
// The 4th parameter (ResourceName) explicitly specifies the resource name to use.
// The emitter prioritizes this explicit ResourceName over deriving names from interface names.
// This ensures consistent and predictable resource naming regardless of interface name variations.
alias BestPracticeOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;
  },
  {
    /** The name of the best practice */
    @segment("bestPractices")
    @key
    @path
    bestPracticeName: string;
  },
  ErrorResponse,
  "BestPractice"  // Explicit resource name - prioritized by the emitter
>;

alias BestPracticesVersionOps = Azure.ResourceManager.Legacy.LegacyOperations<
  {
    ...ApiVersionParameter;
    ...Azure.ResourceManager.Legacy.Provider;

    /** The name of the best practice */
    @segment("bestPractices")
    @key
    @path
    bestPracticeName: string;
  },
  {
    /** The name of the version */
    @segment("versions")
    @key
    @path
    versionName: string;
  },
  ErrorResponse,
  "BestPracticeVersion"  // Explicit resource name - prioritized by the emitter
>;

/** Best practice operations on /bestPractices/{bestPracticeName} */
@armResourceOperations
interface BestPractices {
  get is BestPracticeOps.Read<BestPractice>;
  createOrUpdate is BestPracticeOps.CreateOrUpdateSync<BestPractice>;
  update is BestPracticeOps.CustomPatchSync<
    BestPractice,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<BestPractice, BestPracticeProperties>
  >;
  delete is BestPracticeOps.DeleteSync<BestPractice>;
  list is BestPracticeOps.List<BestPractice>;
}

/** Best practice version operations on /bestPractices/{bestPracticeName}/versions/{versionName} */
/** NOTE: This interface uses the SAME BestPractice model but at a different path */
@armResourceOperations
interface BestPracticeVersions {
  get is BestPracticesVersionOps.Read<BestPractice>;
  createOrUpdate is BestPracticesVersionOps.CreateOrUpdateSync<BestPractice>;
  update is BestPracticesVersionOps.CustomPatchSync<
    BestPractice,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<BestPractice, BestPracticeProperties>
  >;
  delete is BestPracticesVersionOps.DeleteSync<BestPractice>;
  list is BestPracticesVersionOps.List<BestPractice>;
}
