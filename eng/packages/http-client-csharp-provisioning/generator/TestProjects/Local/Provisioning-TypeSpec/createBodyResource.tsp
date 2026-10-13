import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Foundations;
using Azure.Core;

namespace ProvisioningTypeSpec;

// Model inheritance is preserved in the generated provisioning models.

/** Base attributes for items. */
model BaseItemAttributes {
  /** Whether the item is enabled. */
  enabled?: boolean;

  /** The optional name inherited by item attributes. */
  displayName?: string;

  /** The creation date. */
  @visibility(Lifecycle.Read)
  created?: utcDateTime;

  /** The last updated date. */
  @visibility(Lifecycle.Read)
  updated?: utcDateTime;
}

/** Item-specific attributes that inherit all base properties. */
model ItemAttributes extends BaseItemAttributes {
  /** The expiry date. */
  expires?: utcDateTime;

  /** The required item attribute name. */
  displayName: string;
}

// The resource response and create operation use different visibility for tags.

/** An item in a configuration store. */
@parentResource(ConfigurationStore)
@resource("items")
model Item is Azure.ResourceManager.ProxyResource<ItemProperties> {
  ...ResourceNameParameter<Item, SegmentName = "items">;

  /** Tags assigned to the item. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-invalid-envelope-property" "Test: separate create body pattern"
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "Test: separate create body pattern"
  @visibility(Lifecycle.Read)
  tags?: Record<string>;
}

/** Properties of an item. */
model ItemProperties {
  /** The value of the item. */
  value?: string;

  /** The content type of the item. */
  contentType?: string;

  /** Nullable value used to verify provisioning primitive wrapping. */
  nullableValue?: string | null;

  /** The attributes of the item. */
  attributes?: ItemAttributes;
}

/** Parameters to create or update an item. */
model ItemCreateOrUpdateParameters {
  /** Tags assigned to the item. */
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "Test: separate create body pattern"
  tags?: Record<string>;

  /** Properties of the item. */
  properties: ItemProperties;
}

#suppress "@azure-tools/typespec-azure-resource-manager/no-resource-delete-operation" "Test resource"
@armResourceOperations
interface Items {
  get is ArmResourceRead<Item>;

  @armResourceCreateOrUpdate(Item)
  createOrUpdate is ArmCreateOperation<
    ResourceInstanceParameters<Item>,
    ItemCreateOrUpdateParameters,
    Response = ArmResponse<Item> | ArmResourceCreatedSyncResponse<Item>,
    ErrorResponse = ErrorResponse
  >;

  list is ArmResourceListByParent<Item>;
}
