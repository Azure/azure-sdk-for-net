import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec {

@resource("zoos")
model Zoo is TrackedResource<ZooProperties> {
  ...ResourceNameParameter<Zoo, SegmentName = "zoos">;

  ...ExtendedLocationProperty;
}

@useSystemTextJsonConverter("csharp")
model ZooProperties {
  /** something */
  something?: string;
}

@armResourceOperations
interface Zoos {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Zoo>;

  get is ArmResourceRead<Zoo>;

  delete is ArmResourceDeleteWithoutOkAsync<Zoo>;

  update is ArmCustomPatchAsync<Zoo, Azure.ResourceManager.Foundations.ResourceUpdateModel<Zoo, ZooProperties>>;

  list is ArmResourceListByParent<Zoo>;

  listBySubscription is ArmListBySubscription<Zoo>;

  @get
  @action("recommend")
  recommend is ArmResourceActionSync<
    Zoo,
    void,
    ArmResponse<ZooRecommendation>>;

  @get
  @action("ZooAddressList")
  zooAddressList is ArmResourceActionSync<
    Zoo,
    void,
    ArmResponse<ZooAddressListListResult>,
    Parameters = {
      @query("$maxpagesize")
      $maxpagesize?: int32;
    }
  >;
}

model ZooAddressListListResult is Azure.Core.Page<ZooAddress>;

model ZooAddress {
  @visibility(Lifecycle.Read)
  id?: Azure.Core.armResourceIdentifier;
}

model ZooRecommendation {
  /** The recommended value */
  recommendedValue: string;

  /** The reason for the recommendation */
  reason: string;
}

@@clientLocation(Zoos.recommend, "ZooRecommendation");

/**
 * Test resource to reproduce issue #55436 - Missing constructor parameters in factory methods.
 * This uses a patch model with properties that extend a base type with nested complex objects.
 */
@resource("issueTests")
model IssueTestResource is TrackedResource<IssueTestBaseProperties> {
  ...ResourceNameParameter<IssueTestResource, SegmentName = "issueTests">;
}

@armResourceOperations
interface IssueTestResources {
  get is ArmResourceRead<IssueTestResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<IssueTestResource>;
  
  // Use custom patch with a properties model that extends a base type
  update is ArmCustomPatchAsync<IssueTestResource, IssueTestPatch>;
  
  listByResourceGroup is ArmResourceListByParent<IssueTestResource>;
}

/**
 * The patch model with flattened properties.
 * Without the fix, the factory method would skip the nested config parameters.
 */
model IssueTestPatch {
  /** Resource tags. */
  tags?: Record<string>;
  
  /** The properties to update - extends base properties with nested objects */
  properties?: IssueTestUpdateProperties;
}

/**
 * Update properties that extend base properties - this is the key pattern.
 * The base type has a nested complex object (nestedConfig) that gets flattened.
 */
model IssueTestUpdateProperties extends IssueTestBaseProperties {
  /** Property specific to updates */
  updateOnlyValue?: string;
}

/**
 * Base properties with a nested complex object.
 * The nestedConfig property has inner flattening, so the factory needs to construct it.
 */
model IssueTestBaseProperties {
  /** Simple property */
  displayName?: string;
  
  /**
   * Nested complex object - its inner properties are flattened.
   * The factory method needs to construct this even when there are no flattened properties for it.
   */
  nestedConfig?: IssueTestNestedConfig;
  
  /** Read-only property */
  @visibility(Lifecycle.Read)
  status?: string;
}

/**
 * Nested configuration model - its properties get flattened.
 */
model IssueTestNestedConfig {
  /** Inner value that gets flattened */
  innerValue?: string;
  
  /** Inner flag that gets flattened */
  innerFlag?: boolean;
}

// Apply flattening to the patch model's properties
#suppress "deprecated"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(IssueTestPatch.properties);

// Also flatten the nested config within the base properties
#suppress "deprecated"
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(IssueTestBaseProperties.nestedConfig);
}
