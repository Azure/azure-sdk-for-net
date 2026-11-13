import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Rest;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

@resource("sampleDatas")
model SampleData is TrackedResource<SampleDataProperties> {
  ...ResourceNameParameter<SampleData, SegmentName = "sampleDatas">;
}

model SampleDataProperties {
  /** the sample value */
  sampleValue?: string;

  /** another value */
  anotherValue?: int32;
}

@armResourceOperations
interface SampleDatas {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<SampleData>;

  get is ArmResourceRead<SampleData>;

  delete is ArmResourceDeleteWithoutOkAsync<SampleData>;

  list is ArmResourceListByParent<SampleData>;
}
