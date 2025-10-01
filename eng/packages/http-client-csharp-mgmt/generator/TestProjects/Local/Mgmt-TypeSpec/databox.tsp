import "@typespec/rest";
import "@typespec/openapi";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

namespace MgmtTypeSpec;

using TypeSpec.Rest;
using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;


model JobResource
  is Azure.ResourceManager.TrackedResource<JobProperties, false> {
  ...ResourceNameParameter<
    Resource = JobResource,
    KeyName = "jobName",
    SegmentName = "jobs",
    NamePattern = "^[-\\w\\.]+$"
  >;
}

model JobProperties {
    jobName: string;
}

@armResourceOperations
interface JobResources {
  /**
   * Gets information about the specified job.
   */
  get is ArmResourceRead<
    JobResource,
    Parameters = {
      /**
       * $expand is supported on details parameter for job, which provides details on the job stages.
       */
      @query("$expand")
      $expand?: string;
    },
  >;

  #suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-patch" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
  @patch(#{ implicitOptionality: false })
  update is ArmCustomPatchAsync<
    JobResource,
    PatchModel = JobResourceUpdateParameter,
  >;
}

model JobResourceUpdateParameter {
    properties?: JobProperties;
    #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
    tags?: Record<string>;
}