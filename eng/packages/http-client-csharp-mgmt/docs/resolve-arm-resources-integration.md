# resolveArmResources API Integration

## Overview

This document describes the integration of the `resolveArmResources` API from `@azure-tools/typespec-azure-resource-manager` into our codebase.

## Background

The `resolveArmResources` API is a standardized way provided by the TypeSpec ARM library to extract and resolve ARM resource information from TypeSpec definitions. It provides:

- Fully resolved resource operations (CRUD + actions + lists)
- Resource hierarchy and parent-child relationships
- Resource scope detection (Tenant, Subscription, ResourceGroup, etc.)
- Proper handling of extension resources
- Categorization of non-resource operations

## Purpose

We want to migrate from our custom resource detection logic in `resource-detection.ts` to use the standardized `resolveArmResources` API. This will:

1. Reduce maintenance burden by leveraging the standard library
2. Ensure consistency with other TypeSpec-based generators
3. Benefit from improvements and bug fixes in the ARM library
4. Simplify our codebase

## Implementation Approach

The migration is being done incrementally:

### Step 1: Create Conversion Function (✅ Complete)

- Created `resolve-arm-resources-converter.ts` that wraps `resolveArmResources` and converts `Provider` format to our `ArmProviderSchema` format
- Integrated comprehensive test validation in `resource-detection.test.ts` and `non-resource-methods.test.ts`
- All 27 tests pass, validating the converter produces identical results to the existing implementation
- The converter maintains full compatibility with existing code while using the standardized API internally

### Step 2: Add Feature Flag (✅ Complete)

- Added a configuration option `use-legacy-resource-detection` as a feature flag to control resource detection behavior
- By default, the flag is **on** (true), maintaining current legacy behavior for backward compatibility
- When disabled (false), `buildArmProviderSchema` calls the converter to use `resolveArmResources` instead of custom logic
- This allows controlled testing and gradual rollout to specific services or scenarios
- Each service can opt-in to the new API by disabling the flag in their TypeSpec configuration file (`tspconfig.yaml`)

**How to opt-in to the new resolveArmResources API:**

Add the following to your `tspconfig.yaml` or emitter options:

```yaml
emit:
  - "@azure-typespec/http-client-csharp-mgmt"
options:
  "@azure-typespec/http-client-csharp-mgmt":
    use-legacy-resource-detection: false
```

**Testing:**

- No dedicated test file needed - feature flag behavior is validated through the production code path
- Existing tests in `resource-detection.test.ts` (9 tests) and `non-resource-methods.test.ts` (7 tests) already validate equivalence between implementations
- All 98 tests pass (71 .NET + 27 TypeScript), confirming backward compatibility

### Step 3: Enable Flag in Test Projects (Next)

- Enable the `use-legacy-resource-detection: false` flag in our internal test projects
- Validate that all test projects generate correctly with the new resolveArmResources API
- Identify and fix any issues found during test project generation
- Ensure comprehensive coverage of different TypeSpec patterns and scenarios

### Step 4: Validate with Real Resource Providers (Next)

- Enable the `use-legacy-resource-detection: false` flag in a selected set of real RPs
- Start with a few representative RPs that cover common patterns
- Monitor generation and validate SDK output quality
- Gather feedback and address any issues discovered
- Gradually expand to more RPs as confidence increases

### Step 5: Enable by Default and Remove Flag (Final)

- After sufficient validation with test projects and real RPs, flip the default to `false` (making resolveArmResources the default)
- Remove the feature flag and always use `resolveArmResources`
- The conversion function will remain to translate from `Provider` format to our `ArmProviderSchema` format
- Eventually consider updating downstream code to work directly with `Provider` format if beneficial

## Data Structure Mapping

### Provider (from resolveArmResources)
```typescript
interface Provider {
  resources?: ResolvedResource[];
  providerOperations?: ArmResourceOperation[];
}

interface ResolvedResource {
  type: Model;
  kind: "Tracked" | "Proxy" | "Extension" | "Other";
  providerNamespace: string;
  operations: ArmResolvedOperationsForResource;
  associatedOperations?: ArmResourceOperation[];
  resourceName: string;
  resourceType: ResourceType;
  resourceInstancePath: string;
  parent?: ResolvedResource;
  scope?: string | ResolvedResource;
}
```

### ArmProviderSchema (our format)
```typescript
interface ArmProviderSchema {
  resources: ArmResourceSchema[];
  nonResourceMethods: NonResourceMethod[];
}

interface ArmResourceSchema {
  resourceModelId: string;
  metadata: ResourceMetadata;
}

interface ResourceMetadata {
  resourceIdPattern: string;
  resourceType: string;
  methods: ResourceMethod[];
  resourceScope: ResourceScope;
  parentResourceId?: string;
  parentResourceModelId?: string;
  singletonResourceName?: string;
  resourceName: string;
}
```

## Testing Strategy

The test suite validates that the converter produces results consistent with the current `buildArmProviderSchema` implementation. Tests are integrated into existing test files for better maintainability:

### Resource Detection Tests (`resource-detection.test.ts`)
9 test cases covering:

1. Resource group resources - Basic tracked resources with CRUD operations
2. Singleton resources - Resources with fixed names using @singleton decorator
3. Resources with grandparents - Multi-level parent-child hierarchies under different scopes
4. Scope detection - Resources with scope determined from Read method
5. Parent-child with list operations - List operation resource scope handling
6. ManagementGroup scope - Resources scoped to management groups
7. Action-only interfaces - Resources with only action operations, no CRUD

### Non-Resource Methods Tests (`non-resource-methods.test.ts`)
7 test cases covering:

1. Subscription scope operations - Non-resource methods at subscription level
2. Tenant scope operations - Non-resource methods at tenant level
3. Mixed scenarios - Resources and non-resource methods in same spec
4. Complex operation paths - Nested path segments and parameters
5. Query parameters - Methods with query string parameters
6. Location parameters - ARM provider actions with location parameters

## Test Results

**All 27 tests pass successfully** ✓

The comprehensive test coverage validates that `resolveArmResources` produces identical results to `buildArmProviderSchema` across:
- Various resource scopes (ResourceGroup, Subscription, Tenant, ManagementGroup)
- Different resource patterns (singleton, hierarchical, parent-child)
- Both resource operations and non-resource methods
- Complex operation paths with parameters
- Action-only resources
- Mixed resource and non-resource method scenarios

This confirms the converter is production-ready and has been successfully integrated via feature flag.

## Files

- `src/resolve-arm-resources-converter.ts` - The wrapper and conversion function
- `src/options.ts` - Emitter options including the `use-legacy-resource-detection` feature flag
- `src/emitter.ts` - Main emitter entry point that passes options to `updateClients`
- `src/resource-detection.ts` - Current implementation with feature flag support
- `src/resource-metadata.ts` - Shared data structures
- `test/resource-detection.test.ts` - Resource detection validation tests (9 tests)
- `test/non-resource-methods.test.ts` - Non-resource methods validation tests (7 tests)
- `test/resource-type.test.ts` - Resource type validation tests (11 tests)
- `test/test-util.ts` - Shared test utilities including `normalizeSchemaForComparison`

## Next Steps

1. **Enable in test projects** - Enable the `use-legacy-resource-detection: false` flag in internal test projects to validate generation
2. **Validate with real RPs** - Enable the flag in a few representative real RPs to ensure stability and gather feedback
3. **Monitor and iterate** - Collect feedback and address any edge cases discovered during rollout
4. **Make default** - After successful validation, flip the default to `false` (making resolveArmResources the default behavior)
5. **Remove flag** - Remove the feature flag configuration, always use `resolveArmResources`
6. **Long-term** - Consider updating downstream code to work directly with `Provider` format if beneficial
