import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec {

/**
 * Minimal repro for the inherited flatten case from ComputeGallery:
 *
 *   GrandparentFlattenBase                (base, has @flattenProperty identifier)
 *     -> GrandparentFlattenProxy<T>       (intermediate template, extends base)
 *       -> GrandparentFlattenResource     (ARM resource, is Proxy<Properties>)
 *
 * The model factory for the leaf resource should flatten the base `identifier`
 * bag into a `string uniqueId` parameter instead of exposing the internal
 * `GrandparentFlattenIdentifier` type.
 */
model GrandparentFlattenIdentifier {
  uniqueId?: string;
}

model GrandparentFlattenBase extends Azure.ResourceManager.CommonTypes.Resource {
  identifier?: GrandparentFlattenIdentifier;
}

model GrandparentFlattenProxy<Properties extends {}> extends GrandparentFlattenBase {
  @doc("The resource-specific properties for this resource.")
  properties?: Properties;
}

model GrandparentFlattenLeafProperties {
  disclaimer?: string;
}

@resource("grandparentFlattenResources")
@subscriptionResource
@parentResource(SubscriptionLocationResource)
model GrandparentFlattenResource is GrandparentFlattenProxy<GrandparentFlattenLeafProperties> {
  ...ResourceNameParameter<GrandparentFlattenResource, SegmentName = "grandparentFlattenResources">;
}

@armResourceOperations
interface GrandparentFlattenResources {
  get is ArmResourceRead<GrandparentFlattenResource>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<GrandparentFlattenResource>;
}

#suppress "deprecated"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(GrandparentFlattenBase.identifier);
}
