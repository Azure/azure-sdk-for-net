import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

/** A resource that supports private link capabilities. */
@parentResource(Foo)
model PrivateLinkResourceForFoo
  is Azure.ResourceManager.ProxyResource<PrivateLinkResourceForFooProperties> {
  ...ResourceNameParameter<
    Resource = PrivateLinkResourceForFoo,
    KeyName = "privateLinkResourceName",
    SegmentName = "privateLinkResources",
    NamePattern = ""
  >;
}

@armResourceOperations
interface PrivateLinkResourcesForFoos {
  /** Gets a private link resource. */
  get is ArmResourceRead<PrivateLinkResourceForFoo>;

  /** Lists the private link resources. */
  list is Azure.ResourceManager.Legacy.ArmListSinglePageByParent<
    PrivateLinkResourceForFoo,
    Response = ArmResponse<PrivateLinkResourceForFooListResult>
  >;
}

/** Properties of PrivateLinkResource */
model PrivateLinkResourceForFooProperties {
  /** The private link resource group id. */
  groupId?: string;

  /** The private link resource required member names. */
  requiredMembers?: string[];

  /** The private link resource Private link DNS zone name. */
  requiredZoneNames?: string[];
}

/** Result of the List private link resources operation. */
model PrivateLinkResourceForFooListResult {
  /** A collection of private link resources */
  value: PrivateLinkResourceForFoo[];

  /** A link for the next page of private link resources. */
  nextLink?: ResourceLocation<PrivateLinkResourceForFoo>;
}
