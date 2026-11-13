import "./foo.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

// Mimics Storage AzureEntityResource: extends Resource, adds etag
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for #57281"
@summary("Entity Resource Like")
model EntityResourceLike extends Azure.ResourceManager.CommonTypes.Resource {
  /** Resource Etag. */
  @visibility(Lifecycle.Read)
  etag?: string;
}

// Mimics Storage ListContainerItem: extends EntityResource, adds properties
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "repro for #57281"
model ContainerItemLike extends EntityResourceLike {
  /** The container properties. */
  properties?: ContainerItemLikeProperties;
}

model ContainerItemLikeProperties {
  /** A simple string property. */
  something?: string;
}

model ContainerItemLikeListResult is Azure.Core.Page<ContainerItemLike>;

// Use the models in an action on the Foo resource so they get generated
@armResourceOperations
interface EntityResourceRepro {
  @get
  @action("listContainerItems")
  listContainerItems is ArmResourceActionSync<
    Foo,
    void,
    ArmResponse<ContainerItemLikeListResult>
  >;
}
