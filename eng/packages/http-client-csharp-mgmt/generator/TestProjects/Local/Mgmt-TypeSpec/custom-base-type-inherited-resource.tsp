using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ResourceManager.Legacy;

namespace MgmtTypeSpec;

model CustomBaseTypeInheritedResourceProperties {
  description?: string;
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
  tags?: Record<string>;
  location?: string;
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
alias CustomBaseTypeInheritedResourceOps = LegacyOperations<
  {
    ...ApiVersionParameter;
    ...SubscriptionIdParameter;
    ...ResourceGroupParameter;
    ...Provider<CustomBaseTypeInheritedResource>;
  },
  {
    @path
    @segment("customBaseTypeInheritedResources")
    customBaseTypeInheritedResourceName: string;
  },
  ErrorResponse,
  "CustomBaseTypeInheritedResource"
>;

#suppress "@azure-tools/typespec-azure-core/no-legacy-usage" "Testing custom resource pattern"
@armResourceOperations
interface CustomBaseTypeInheritedResources {
  get is CustomBaseTypeInheritedResourceOps.Read<CustomBaseTypeInheritedResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<
    CustomBaseTypeInheritedResource,
    BaseParameters = {
      ...ApiVersionParameter;
      ...SubscriptionIdParameter;
      ...ResourceGroupParameter;
    },
    Error = ErrorResponse
  >;
  @action("customBaseTypeInheritedResources")
  list is ArmResourceListByParent<
    CustomBaseTypeInheritedResource,
    BaseParameters = {
      ...ApiVersionParameter;
      ...SubscriptionIdParameter;
      ...ResourceGroupParameter;
    },
    Error = ErrorResponse
  >;
}

@@Azure.ClientGenerator.Core.Legacy.flattenProperty(CustomBaseTypeInheritedResource.properties);
