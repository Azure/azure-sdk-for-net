import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

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

  @get
  @action("recommend")
  recommend is ArmResourceActionSync<
    Zoo, 
    void,
    ArmResponse<ZooRecommendation>>;
}

model ZooRecommendation {
  /** The recommended value */
  recommendedValue: string;

  /** The reason for the recommendation */
  reason: string;
}

@@clientLocation(Zoos.recommend, "ZooRecommendation");
