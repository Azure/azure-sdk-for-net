import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/rest";
import "@typespec/http";
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;
using TypeSpec.Rest;
using TypeSpec.Http;

namespace MgmtTypeSpec;

// This file demonstrates the scenario where multiple resources share the same properties model
// but operate at different paths with proper parent-child hierarchy using @parentResource.
// This uses Azure.ResourceManager.Legacy.LegacyOperations to define different path patterns.

/** A best practice resource - parent resource */
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

/** A best practice version resource - child resource that shares the same properties as BestPractice */
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "For sample purpose"
@parentResource(BestPractice)
model BestPracticeVersion is ProxyResource<BestPracticeProperties> {
  ...ResourceNameParameter<
    Resource = BestPracticeVersion,
    KeyName = "versionName",
    SegmentName = "versions",
    NamePattern = ""
  >;
  ...Legacy.ExtendedLocationOptionalProperty;
}

/** Best practice properties - shared by both BestPractice and BestPracticeVersion */
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
}

/** Best practice version operations on /bestPractices/{bestPracticeName}/versions/{versionName} */
/** NOTE: This interface uses BestPracticeVersion model which shares properties with BestPractice */
@armResourceOperations
interface BestPracticeVersions {
  get is BestPracticesVersionOps.Read<BestPracticeVersion>;
  createOrUpdate is BestPracticesVersionOps.CreateOrUpdateSync<BestPracticeVersion>;
  update is BestPracticesVersionOps.CustomPatchSync<
    BestPracticeVersion,
    Azure.ResourceManager.Foundations.ResourceUpdateModel<BestPracticeVersion, BestPracticeProperties>
  >;
  delete is BestPracticesVersionOps.DeleteSync<BestPracticeVersion>;
}
