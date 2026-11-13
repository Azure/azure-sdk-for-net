using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.Core;

namespace MgmtTypeSpec;

/**
 * Repro for the BaseType cycle in FlattenPropertyVisitor.TryGetFlattenPropertyInfo().
 *
 * In AppConfiguration the cycle is triggered by:
 *   1. PrivateEndpointConnectionReference – a plain model (NOT a resource) with
 *      id/name/type string properties and @flattenProperty on `properties`.
 *   2. A Custom/ partial class that forces inheritance:
 *        public partial class AppConfigurationPrivateEndpointConnectionReference : ResourceData { }
 *   3. This causes the ScmModelProvider to have BaseType = ResourceData.
 *   4. When the do-while loop in TryGetFlattenPropertyInfo walks to ResourceData,
 *      CSharpTypeMap resolves it to InheritableSystemObjectModelProvider whose
 *      BaseType is also ResourceData → infinite cycle.
 *
 * This test reproduces the same pattern:
 *   - CycleTestConnectionReference: plain model with id/name/type + @flattenProperty
 *   - Custom partial class: CycleTestConnectionReference : ResourceData
 */

model CycleTestConnectionProperties {
  /** The provisioning status. */
  @visibility(Lifecycle.Read)
  provisioningState?: string;

  /** Description of the connection. */
  description?: string;
}

/** A reference to a related connection. */
model CycleTestConnectionReference {
  /** The resource ID. */
  @visibility(Lifecycle.Read)
  id?: string;

  /** The name of the resource. */
  @visibility(Lifecycle.Read)
  name?: string;

  /** The type of the resource. */
  @visibility(Lifecycle.Read)
  type?: string;

  /** The properties of the connection. */
  properties?: CycleTestConnectionProperties;
}

model CycleTestStoreProperties {
  /** The endpoint for the store. */
  endpoint?: string;

  /** Related connections. */
  connections?: CycleTestConnectionReference[];
}

@resource("cycleTestStores")
model CycleTestStore is TrackedResource<CycleTestStoreProperties> {
  ...ResourceNameParameter<CycleTestStore, SegmentName = "cycleTestStores">;
}

@armResourceOperations
interface CycleTestStores {
  get is ArmResourceRead<CycleTestStore>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<CycleTestStore>;
}
