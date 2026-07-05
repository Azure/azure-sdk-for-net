import "@azure-tools/typespec-azure-resource-manager";
import "@azure-tools/typespec-client-generator-core";

using Azure.ResourceManager;
using Azure.ClientGenerator.Core;
using TypeSpec.Rest;
using TypeSpec.Http;

namespace MgmtTypeSpec;

/**
 * Base properties model - similar to DatabaseProperties in the original issue.
 * Contains a property that will be redefined in derived models.
 */
model PropertyOverrideBaseProperties {
  /**
   * A base property that won't be redefined.
   */
  baseOnlyProperty?: string;
  
  /**
   * This property will be redefined in derived models with a default value.
   * Similar to accessKeysAuthentication in the original RedisEnterprise issue.
   */
  overridableProperty?: string;
}

/**
 * Derived properties model - similar to DatabaseCreateProperties in the original issue.
 * Redefines overridableProperty with a default value, which previously caused
 * duplicate property generation when used with property flattening.
 */
model PropertyOverrideCreateProperties extends PropertyOverrideBaseProperties {
  /**
   * Redefined property with a default value. This is the pattern that caused
   * the original issue - a derived model redefining a base property.
   */
  overridableProperty?: string = "DefaultValue";
}

/**
 * Test resource that uses the DERIVED properties model (PropertyOverrideCreateProperties)
 * instead of the base model. This is the key pattern from the original issue where
 * RedisEnterpriseDatabaseData used DatabaseCreateProperties.
 * 
 * With property flattening applied, this previously generated duplicate properties:
 * - public virtual string OverridableProperty (from base)
 * - public override string OverridableProperty (from derived)
 */
@resource("duplicatePropertyTests")
model DuplicatePropertyTest is TrackedResource<PropertyOverrideCreateProperties> {
  ...ResourceNameParameter<DuplicatePropertyTest>;
}

@armResourceOperations
interface DuplicatePropertyTests {
  get is ArmResourceRead<DuplicatePropertyTest>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<DuplicatePropertyTest>;
  delete is ArmResourceDeleteWithoutOkAsync<DuplicatePropertyTest>;
  list is ArmResourceListByParent<DuplicatePropertyTest>;
}

// Apply property flattening to reproduce the original issue
@@Azure.ClientGenerator.Core.Legacy.flattenProperty(DuplicatePropertyTest.properties);
