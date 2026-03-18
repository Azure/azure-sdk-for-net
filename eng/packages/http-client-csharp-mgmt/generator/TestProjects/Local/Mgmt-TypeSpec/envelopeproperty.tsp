import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

// Test: TrackedResource with direct identity envelope property (using #suppress)
// This is the pattern that triggers the wrong base class bug described in issue #57148.
model EnvelopePropertyTest
  is Azure.ResourceManager.TrackedResource<EnvelopePropertyTestProperties> {
  ...ResourceNameParameter<
    Resource = EnvelopePropertyTest,
    KeyName = "envelopePropertyTestName",
    SegmentName = "envelopePropertyTests"
  >;

  /** The managed service identities assigned to this resource. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-invalid-envelope-property"
  identity?: Azure.ResourceManager.CommonTypes.ManagedServiceIdentity;
}

model EnvelopePropertyTestProperties {
  provisioningState?: string;
  displayName?: string;
}

@armResourceOperations
interface EnvelopePropertyTests {
  get is ArmResourceRead<EnvelopePropertyTest>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<EnvelopePropertyTest>;
  delete is ArmResourceDeleteWithoutOkAsync<EnvelopePropertyTest>;
  listByResourceGroup is ArmResourceListByParent<EnvelopePropertyTest>;
  listBySubscription is ArmListBySubscription<EnvelopePropertyTest>;
}
