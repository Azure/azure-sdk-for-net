import "@typespec/rest";
import "./foo.tsp";

using TypeSpec.Rest;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtTypeSpec;

@resource("deleteFinalResultTests")
@parentResource(Foo)
model DeleteFinalResultTest is TrackedResource<DeleteFinalResultTestProperties> {
  ...ResourceNameParameter<DeleteFinalResultTest, SegmentName = "deleteFinalResultTests">;
}

model DeleteFinalResultTestProperties {
  marker?: string;
}

model DeleteFinalResultPayload {
  status?: string;
}

@armResourceOperations
interface DeleteFinalResultTests {
  createOrUpdate is ArmResourceCreateOrUpdateAsync<DeleteFinalResultTest>;

  get is ArmResourceRead<DeleteFinalResultTest>;

  delete is ArmResourceDeleteWithoutOkAsync<
    DeleteFinalResultTest,
    LroHeaders = ArmLroLocationHeader<FinalResult = DeleteFinalResultPayload> &
      Azure.Core.Foundations.RetryAfterHeader
  >;
}
