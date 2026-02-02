import "@azure-tools/typespec-azure-resource-manager";

using Azure.ResourceManager;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

/**
 * Test case for verifying issue #55409 fix - duplicate parameter key in flatten property visitor.
 * This simulates a pattern where multiple flattened properties could share the same underlying parameter.
 */

@resource("testClusters")
model TestCluster is TrackedResource<TestClusterProperties, false> {
  ...ResourceNameParameter<TestCluster, SegmentName = "testClusters">;

  /** The SKU to create. */
  sku: TestClusterSku;
}

model TestClusterSku {
  /** SKU name */
  name: string;
  /** SKU capacity */
  capacity?: int32;
}

/** Properties for test clusters */
model TestClusterProperties {
  /** High availability setting */
  highAvailability?: string;

  /** Minimum TLS version */
  minimumTlsVersion?: string;

  /** DNS name of the cluster endpoint */
  @visibility(Lifecycle.Read)
  hostName?: string;

  /** Current provisioning status */
  @visibility(Lifecycle.Read)
  provisioningState?: string;
}

@armResourceOperations
interface TestClusters {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<TestCluster>;
  get is ArmResourceRead<TestCluster>;
  delete is ArmResourceDeleteWithoutOkAsync<TestCluster>;
  list is ArmResourceListByParent<TestCluster>;
}
