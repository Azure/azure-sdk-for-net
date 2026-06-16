import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.ClientGenerator.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;

@armProviderNamespace
@service(#{ title: "MgmtCustomBaseReproClient" })
@versioned(Versions)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace MgmtCustomBaseRepro;

enum Versions {
  v2024_04_01: "2024-04-01",
}

model CustomBaseTypeInheritedResourceProperties {
  description?: string;
}

model CustomBaseTypeInheritedResourceTagsPatch {
  tags?: Record<string>;
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
@Azure.ResourceManager.Legacy.customAzureResource(#{ isAzureResource: true })
model ServiceDefinedTrackedResourceWithOptionalLocation {
  @visibility(Lifecycle.Read)
  id?: string;
  @visibility(Lifecycle.Read)
  name?: string;
  @visibility(Lifecycle.Read)
  type?: string;
  location?: string;
  tags?: Record<string>;
}

#suppress "@azure-tools/typespec-azure-core/composition-over-inheritance" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-no-key" "Testing custom resource pattern"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-custom-resource-usage-discourage" "Testing custom resource pattern"
@Http.Private.includeInapplicableMetadataInPayload(false)
model CustomBaseTypeInheritedResource extends ServiceDefinedTrackedResourceWithOptionalLocation {
  properties?: CustomBaseTypeInheritedResourceProperties;
  @visibility(Lifecycle.Read)
  @path
  @key("customBaseTypeInheritedResourceName")
  @segment("customBaseTypeInheritedResources")
  name: string;
  @visibility(Lifecycle.Read)
  etag?: string;
}

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
@armResourceOperations
interface CustomBaseTypeInheritedResources {
  get is ArmResourceRead<CustomBaseTypeInheritedResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<CustomBaseTypeInheritedResource, Error = ErrorResponse>;
  @patch(#{ implicitOptionality: false })
  updateTags is ArmCustomPatchSync<CustomBaseTypeInheritedResource, PatchModel = CustomBaseTypeInheritedResourceTagsPatch, Error = ErrorResponse>;
  delete is ArmResourceDeleteWithoutOkAsync<
    CustomBaseTypeInheritedResource,
    Response = ArmDeletedResponse | ArmDeleteAcceptedLroResponse | ArmDeletedNoContentResponse,
    Error = ErrorResponse
  >;
  listByResourceGroup is ArmResourceListByParent<CustomBaseTypeInheritedResource, Error = ErrorResponse>;
  list is ArmListBySubscription<CustomBaseTypeInheritedResource, Error = ErrorResponse>;
}

@@Azure.ClientGenerator.Core.Legacy.flattenProperty(CustomBaseTypeInheritedResource.properties);
@@alternateType(ServiceDefinedTrackedResourceWithOptionalLocation.id, Azure.Core.armResourceIdentifier, "csharp");
