import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

// Test: TrackedResource with direct identity envelope property (using #suppress)
// and flattenProperty — matching the NewRelic pattern that triggers a wrong base
// class (ArmResource instead of TrackedResourceData) in the published npm package.
// See issue #57148.
model EnvelopePropertyTest
  is Azure.ResourceManager.TrackedResource<EnvelopePropertyTestProperties, false> {
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

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Back compatibility"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(EnvelopePropertyTest.properties);
