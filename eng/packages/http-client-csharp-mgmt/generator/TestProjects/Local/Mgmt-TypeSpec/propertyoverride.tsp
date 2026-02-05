import "@azure-tools/typespec-azure-resource-manager";

using Azure.ResourceManager;
using TypeSpec.Rest;
using TypeSpec.Http;

namespace MgmtTypeSpec;

/**
 * Test resource to validate property override inheritance fix.
 * This test spec creates a scenario where derived models redefine base model properties
 * with default values or different descriptions, which previously caused duplicate
 * property generation in C# code.
 */
@resource("testPropertyOverrides")
model TestPropertyOverride is TrackedResource<TestPropertyOverrideProperties> {
  ...ResourceNameParameter<TestPropertyOverride>;
}

/**
 * Base properties model
 */
model TestPropertyOverrideProperties {
  /**
   * A property that exists in the base model.
   */
  baseProperty?: string;
  
  /**
   * A property that will be redefined in derived models.
   */
  sharedProperty?: string;
}

/**
 * Derived properties model for create - redefines sharedProperty with a default value.
 * This model is used in createOrUpdate operations to test that property override
 * inheritance is correctly handled without generating duplicate properties.
 */
model TestPropertyOverrideCreateProperties extends TestPropertyOverrideProperties {
  /**
   * Redefined property with a default value.
   */
  sharedProperty?: string = "DefaultValue";
}

/**
 * Derived properties model for update - redefines sharedProperty with different description.
 * This model is used in patch operations to test that property override
 * inheritance is correctly handled without generating duplicate properties.
 */
model TestPropertyOverrideUpdateProperties extends TestPropertyOverrideProperties {
  /**
   * Redefined property for update operations.
   */
  sharedProperty?: string;
}

/**
 * Request body for create operation using derived properties model
 */
model TestPropertyOverrideCreateRequest {
  /**
   * Properties for the create operation using derived model with property override
   */
  properties?: TestPropertyOverrideCreateProperties;
}

/**
 * Request body for update operation using derived properties model
 */
model TestPropertyOverrideUpdateRequest {
  /**
   * Properties for the update operation using derived model with property override
   */
  properties?: TestPropertyOverrideUpdateProperties;
}

@armResourceOperations
interface TestPropertyOverrides {
  get is ArmResourceRead<TestPropertyOverride>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<TestPropertyOverride>;
  update is ArmCustomPatchAsync<TestPropertyOverride, TestPropertyOverride>;
  delete is ArmResourceDeleteWithoutOkAsync<TestPropertyOverride>;
  list is ArmResourceListByParent<TestPropertyOverride>;
  
  /**
   * Custom action that uses derived create properties model to ensure it appears in generated code
   */
  @post
  @armResourceAction(TestPropertyOverride)
  createCustom(
    ...ResourceInstanceParameters<TestPropertyOverride>,
    @body body: TestPropertyOverrideCreateRequest
  ): ArmResponse<TestPropertyOverride> | ErrorResponse;
  
  /**
   * Custom action that uses derived update properties model to ensure it appears in generated code
   */
  @post
  @armResourceAction(TestPropertyOverride)
  updateCustom(
    ...ResourceInstanceParameters<TestPropertyOverride>,
    @body body: TestPropertyOverrideUpdateRequest
  ): ArmResponse<TestPropertyOverride> | ErrorResponse;
}
