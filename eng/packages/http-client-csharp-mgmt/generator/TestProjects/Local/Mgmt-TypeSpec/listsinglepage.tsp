import "@azure-tools/typespec-client-generator-core";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;
using Azure.Core;

namespace MgmtTypeSpec;

// Test resource for single-page list operations
@resource("singlePageItems")
model SinglePageItem is TrackedResource<SinglePageItemProperties> {
  ...ResourceNameParameter<SinglePageItem, SegmentName = "singlePageItems">;
}

model SinglePageItemProperties {
  /** Item description */
  description: string;

  /** Item status */
  status: string;
}

@armResourceOperations
interface SinglePageItems {
  get is ArmResourceRead<SinglePageItem>;

  createOrUpdate is ArmResourceCreateOrUpdateSync<SinglePageItem>;

  delete is ArmResourceDeleteSync<SinglePageItem>;

  // This operation returns a list but is not pageable (no nextLink)
  // It should still be generated as a Pageable<T> for consistency
  @armResourceList(SinglePageItem)
  @get
  list(
    ...ResourceGroupParameter,
    ...SubscriptionIdParameter,
    ...ApiVersionParameter
  ): ArmResponse<SinglePageItemListResult>;
}

// Custom list result without nextLink (non-pageable)
model SinglePageItemListResult {
  @doc("List of items")
  value: SinglePageItem[];
}
