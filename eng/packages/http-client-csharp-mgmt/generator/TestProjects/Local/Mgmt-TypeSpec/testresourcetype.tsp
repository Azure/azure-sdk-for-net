import "@azure-tools/typespec-client-generator-core";

using TypeSpec.Http;
using TypeSpec.Rest;
using Azure.ResourceManager;
using Azure.ClientGenerator.Core;

namespace MgmtTypeSpec;

@doc("Test resource with nullable ResourceType properties")
model ResourceTypeTestResource is TrackedResource<ResourceTypeTestProperties, false> {
  ...ResourceNameParameter<ResourceTypeTestResource>;
}

@doc("Properties of test resource with nullable armResourceType")
model ResourceTypeTestProperties {
  @doc("Nullable resource type - this tests the fix for nullable value type serialization")
  optionalResourceType?: Azure.Core.armResourceType;
  
  @doc("Status of the resource")
  status?: string;
}

@doc("Model with a constant string type mapped to armResourceType via alternateType")
model ResourceTypeCheckContent {
  @doc("Name to check")
  name: string;

  @doc("Type of resource, constant string mapped to armResourceType via alternateType")
  type: "Microsoft.Storage/storageAccounts";
}

@armResourceOperations
interface ResourceTypeTests {
  @doc("Get a test resource with nullable ResourceType")
  get is ArmResourceRead<ResourceTypeTestResource>;

  @doc("Create or update a test resource")
  createOrUpdate is ArmResourceCreateOrReplaceSync<ResourceTypeTestResource>;

  @doc("Check name availability - repro for alternateType + armResourceType bug")
  @action("checkName")
  checkName is ArmResourceActionSync<ResourceTypeTestResource, ResourceTypeCheckContent, ArmResponse<void>>;
}
