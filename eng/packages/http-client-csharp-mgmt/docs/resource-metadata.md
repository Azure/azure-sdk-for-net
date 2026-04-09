# Resource Metadata and Parent Resource Type Resolution

## Overview

The `resource-metadata.ts` module is responsible for processing ARM resource metadata in the emitter. It handles resource type calculation, resource hierarchy resolution, parent ID population, and method sorting. A key part of this module is determining the **expected parent resource type** for collection resources so that `ValidateResourceId` checks can be generated.

## `getExpectedParentResourceType`

The `getExpectedParentResourceType` function extracts the expected parent resource type from a resource's ID pattern. This is used during post-processing to populate the `parentResourceId` for collection resources, enabling the emitter to generate `ValidateResourceId` calls that verify a resource identifier belongs to the correct parent scope.

### Input

A resource ID pattern string, for example:

```
/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Chaos/targets/{targetName}
```

### Algorithm

The function finds the two `/providers/` markers in the pattern — the last one (the resource's own provider) and the second-to-last one (the parent resource's provider) — then examines the segments between them.

#### Simple Case (3 Segments)

When the parent segment between the two `/providers/` markers has exactly 3 segments — `<namespace>/<type>/{name}` — the function directly returns `<namespace>/<type>`.

**Example:**

```
Pattern:  …/providers/Microsoft.Compute/virtualMachines/{vmName}/providers/Microsoft.Chaos/targets/{targetName}
                       ─────────────────────────────────────────
                       Parent segment: Microsoft.Compute/virtualMachines/{vmName}
                       Segments: ["Microsoft.Compute", "virtualMachines", "{vmName}"]
                       Result: "Microsoft.Compute/virtualMachines"
```

Validation rules for the simple case:
- The namespace segment must not contain `{` (must be a constant)
- The type segment must not contain `{` (must be a constant)
- The name segment must start with `{` and end with `}` (must be a variable)

#### Complex Case (More than 3 Segments)

When the parent segment has **more than 3 segments**, the simple extraction does not work because there are additional intermediate path components. This occurs with nested multi-provider scopes such as:

```
/providers/Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/quotaAllocations/{location}
```

Here, the parent segment between the two `/providers/` markers is:

```
Microsoft.Management/managementGroups/{managementGroupId}/subscriptions/{subscriptionId}
```

This has 5 segments, which does not match the simple 3-segment pattern.

**Fallback algorithm:**

1. Remove the last two segments from the full resource ID pattern (the leaf type and name).
2. Find the last `/providers/` marker in the resulting parent path.
3. Extract everything after that marker.
4. Verify the namespace segment (first segment) is a constant.
5. Collect the constant type segments (every other segment starting at index 1).
6. Return `<namespace>/<typeSegment1>/<typeSegment2>/...`.

**Example walkthrough:**

```
Full pattern:  /providers/Microsoft.Management/managementGroups/{mgId}/subscriptions/{subId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}/quotaAllocations/{location}

Step 1 – Remove last two segments (quotaAllocations/{location}):
  /providers/Microsoft.Management/managementGroups/{mgId}/subscriptions/{subId}/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}

Step 2 – Find last /providers/ in parent path:
  …/providers/Microsoft.Quota/groupQuotas/{groupQuotaName}

Step 3 – Extract after /providers/:
  ["Microsoft.Quota", "groupQuotas", "{groupQuotaName}"]

Step 4 – Namespace = "Microsoft.Quota" (constant ✓)

Step 5 – Type segments at odd indices: ["groupQuotas"]

Step 6 – Result: "Microsoft.Quota/groupQuotas"
```

### Return Value

- A string like `"Microsoft.Compute/virtualMachines"` or `"Microsoft.Quota/groupQuotas"` on success
- `undefined` if the pattern does not have two `/providers/` markers or the segments fail validation

## `postProcessArmResources`

The `postProcessArmResources` function is the main post-processing entry point. It performs the following steps:

1. **Separate valid and incomplete resources**: Filters out resources with missing metadata
2. **Populate parent IDs**: Uses `getExpectedParentResourceType` to determine the parent resource type for each collection resource
3. **Relocate methods**: Moves cross-resource list actions to their correct parent resources
4. **Populate resource scope**: Determines whether each resource is tenant-scoped, subscription-scoped, etc.
5. **Sort methods**: Orders methods by kind (CRUD, List, Action)
6. **Filter resources**: Removes resources that don't meet generation criteria

## `calculateResourceTypeFromPath`

Extracts the full resource type from an operation path by parsing the segments after the last `/providers/` marker.

**Example:**

```
Path:   /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachines/{vm}
Result: "Microsoft.Compute/virtualMachines"
```
