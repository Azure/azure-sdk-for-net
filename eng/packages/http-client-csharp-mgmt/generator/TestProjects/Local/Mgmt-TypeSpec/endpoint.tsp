import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";
import "@typespec/openapi";
import "@typespec/rest";

using Azure.ResourceManager;
using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace MgmtTypeSpec;

model EndpointResource
  is Azure.ResourceManager.ExtensionResource<EndpointProperties> {
  ...ResourceNameParameter<
    Resource = EndpointResource,
    KeyName = "endpointName",
    SegmentName = "endpoints",
    NamePattern = ""
  >;
}

model EndpointProperties {
  prop: string;
}

@armResourceOperations
interface EndpointResources {
  /**
   * Gets the endpoint to the resource.
   */
  #suppress "@azure-tools/typespec-azure-core/no-openapi" "non-standard operations"
  @operationId("Endpoints_Get")
  get is ArmResourceRead<
    EndpointResource,
    Azure.ResourceManager.Foundations.ExtensionBaseParameters
  >;

  /**
   * Create or update the endpoint to the target resource.
   */
  #suppress "@azure-tools/typespec-azure-core/no-openapi" "non-standard operations"
  #suppress "@azure-tools/typespec-azure-resource-manager/arm-put-operation-response-codes"
  @operationId("Endpoints_CreateOrUpdate")
  createOrUpdate is ArmResourceCreateOrReplaceSync<
    EndpointResource,
    Azure.ResourceManager.Foundations.ExtensionBaseParameters,
    Response = ArmResourceUpdatedResponse<EndpointResource>
  >;

  /**
   * Update the endpoint to the target resource.
   */
  #suppress "@azure-tools/typespec-azure-core/no-openapi" "non-standard operations"
  @patch(#{ implicitOptionality: false })
  @operationId("Endpoints_Update")
  update is ArmCustomPatchSync<
    EndpointResource,
    EndpointResource,
    Azure.ResourceManager.Foundations.ExtensionBaseParameters
  >;

  /**
   * Deletes the endpoint access to the target resource.
   */
  #suppress "@azure-tools/typespec-azure-core/no-openapi" "non-standard operations"
  #suppress "@azure-tools/typespec-azure-core/no-response-body" "For backward compatibility"
  @operationId("Endpoints_Delete")
  delete is ArmResourceDeleteSync<
    EndpointResource,
    Azure.ResourceManager.Foundations.ExtensionBaseParameters
  >;
}
