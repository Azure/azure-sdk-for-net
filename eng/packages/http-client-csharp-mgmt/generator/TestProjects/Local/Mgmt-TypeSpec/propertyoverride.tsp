import "@azure-tools/typespec-azure-resource-manager";

using Azure.ResourceManager;
using TypeSpec.Rest;

namespace MgmtTypeSpec;

/**
 * Test resource to reproduce property override issue
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
 * Derived properties model for create - redefines sharedProperty with a default value
 */
model TestPropertyOverrideCreateProperties extends TestPropertyOverrideProperties {
  /**
   * Redefined property with a default value.
   */
  sharedProperty?: string = "DefaultValue";
}

/**
 * Derived properties model for update - redefines sharedProperty with different description
 */
model TestPropertyOverrideUpdateProperties extends TestPropertyOverrideProperties {
  /**
   * Redefined property for update operations.
   */
  sharedProperty?: string;
}

@armResourceOperations
interface TestPropertyOverrides {
  get is ArmResourceRead<TestPropertyOverride>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<TestPropertyOverride>;
  update is ArmCustomPatchAsync<TestPropertyOverride, TestPropertyOverride>;
  delete is ArmResourceDeleteWithoutOkAsync<TestPropertyOverride>;
  list is ArmResourceListByParent<TestPropertyOverride>;
}
