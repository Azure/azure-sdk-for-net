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
  
  createOrUpdate is ArmResourceCreateOrUpdateAsync<
    JobResource,
    Parameters = {
      /**
       * Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value.
       */
      @header("If-Match")
      `If-Match`?: string;
      /**
       * Defines the If-None-Match condition. The patch will be performed only if the ETag of the job on the server matches this value.
       */
      @header("If-None-Match")
      `If-None-Match`?: string;
    }
  >;

  @patch(#{ implicitOptionality: false })
  update is ArmCustomPatchAsync<
    JobResource,
    PatchModel = JobResourceUpdateParameter,
    Parameters = {
      /**
       * Defines the If-Match condition. The patch will be performed only if the ETag of the job on the server matches this value.
       */
      @header("If-Match")
      `If-Match`?: string;
    }
  >;
}

model JobResourceUpdateParameter {
    properties?: JobProperties;
    #suppress "@azure-tools/typespec-azure-resource-manager/arm-no-record" "FIXME: Update justification, follow aka.ms/tsp/conversion-fix for details"
    tags?: Record<string>;
}