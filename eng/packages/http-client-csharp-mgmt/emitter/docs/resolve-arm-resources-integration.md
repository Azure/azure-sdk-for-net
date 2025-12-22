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

### Step 1: Create Conversion Function (Current)

- Created `resolve-arm-resources-converter.ts` that converts `Provider` (from `resolveArmResources`) to our `ArmProviderSchema` format
- Added comprehensive test cases in `resolve-arm-resources.test.ts` to verify the conversion produces correct results
- The converter maintains compatibility with existing code while using the new API internally

### Step 2: Gradual Switchover (Future)

- Once the converter is proven stable, we can start switching `buildArmProviderSchema` to use the converter
- This can be done for one category of resources at a time (e.g., start with simple tracked resources)
- Each switchover should be accompanied by thorough testing

### Step 3: Direct Usage (Final)

- Eventually, downstream code can be updated to directly use the `Provider` format
- The `ArmProviderSchema` format can be deprecated in favor of using `resolveArmResources` directly
- Legacy compatibility layers can be removed

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

The test suite in `resolve-arm-resources.test.ts` validates that the converter produces results consistent with the current `buildArmProviderSchema` implementation for various scenarios:

1. **Simple resource group resources** - Basic tracked resources with CRUD operations
2. **Singleton resources** - Resources with fixed names using @singleton decorator
3. **Hierarchical resources** - Parent-child-grandchild resource relationships
4. **Action-only resources** - Resources with only action operations, no CRUD
5. **Different scopes** - Tenant, Subscription, ResourceGroup, ManagementGroup scopes
6. **Non-resource methods** - Operations that aren't tied to specific resources

## Known Differences

The `resolveArmResources` API may categorize some edge cases differently than our current implementation:

1. **Single-operation resources**: Resources with only a GET operation may not appear as full resources
2. **Action categorization**: Action operations might be categorized as associated operations vs. resource methods
3. **Parent detection**: The algorithm for detecting parent resources is more sophisticated in `resolveArmResources`

These differences are acceptable and expected. The tests have been designed to be flexible in these areas while still validating the core functionality.

## Files

- `src/resolve-arm-resources-converter.ts` - The conversion function
- `test/resolve-arm-resources.test.ts` - Comprehensive test cases
- `src/resource-detection.ts` - Current implementation (to be gradually replaced)
- `src/resource-metadata.ts` - Shared data structures

## Next Steps

1. Monitor the converter in practice to identify any edge cases
2. Add more test cases as needed for specific scenarios
3. Create a plan for switching over specific resource categories
4. Update documentation as the migration progresses
5. Eventually deprecate and remove the old resource detection logic
