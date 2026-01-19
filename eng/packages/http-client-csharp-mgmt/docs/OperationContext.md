# Operation Context and Contextual Path System

## Overview

The **Operation Context** system is a core component of the Azure Management SDK generator that determines which parameters for an operation can be derived contextually from the identifier (Id) of the operation's carrier (resource, resource collection, or mockable resource) and which must be supplied by the caller.

When generating methods for Azure management operations, the generator needs to understand:
- Which parameters can be extracted from the resource's `Id` property (e.g., `subscriptionId`, `resourceGroupName`, parent resource names)
- Which parameters must be provided by the method caller (pass-through parameters)
- How to map operation path parameters to their contextual sources

This document explains how the system works in detail.

## Core Concepts

### 1. Contextual Path

The **contextual path** is the request path pattern that defines the identity of a resource or resource collection. It represents "where you are" in the Azure resource hierarchy.

**Example:**
```
/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
```

This path identifies a specific virtual machine resource. The parameters in this path (`subscriptionId`, `resourceGroupName`, `vmName`) can be derived from the resource's `Id` property.

### 2. Operation Path

The **operation path** is the request path for a specific API operation being invoked on the resource.

**Example:**
```
/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}
```

This operation gets a specific extension for a virtual machine. Some parameters match the contextual path, while `extensionName` is new and must be provided by the caller.

### 3. Contextual Parameter

A **contextual parameter** represents a parameter whose value can be derived contextually, either from:
- The resource's `Id` property (e.g., `subscriptionId`, `resourceGroupName`, parent resource names)
- Private fields in a resource collection class (for tuple resources requiring multiple parent parameters)

It contains:
- **Key**: The constant path segment preceding the parameter (e.g., `virtualMachines`)
- **VariableName**: The parameter name in the path (e.g., `vmName`)
- **ValueExpressionBuilder**: A function that generates code to extract the value from the `Id` (e.g., `Id.Name`, `Id.Parent.Name`, `Id.SubscriptionId`) or from a field

### 4. Parameter Context Mapping

A **parameter context mapping** links an operation parameter name to its contextual source (if available). For each parameter in the operation path, it indicates:
- If the parameter has a contextual source, the mapping points to the `ContextualParameter`
- If the parameter has no contextual source, the mapping's `ContextualParameter` is null (indicating a pass-through parameter)

## How It Works

### Step 1: Building Contextual Parameters

When a resource or resource collection is created, the system analyzes its contextual path and builds a list of `ContextualParameter` objects by walking up the path hierarchy.

**Example for VM Resource:**
```
Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}

Contextual Parameters:
1. Key: "subscriptions", Variable: "subscriptionId" → Id.SubscriptionId
2. Key: "resourceGroups", Variable: "resourceGroupName" → Id.ResourceGroupName
3. Key: "virtualMachines", Variable: "vmName" → Id.Name
```

### Step 2: Creating an Operation Context

An `OperationContext` is created for each resource or resource collection. It encapsulates:
- The primary contextual path
- The list of contextual parameters derived from that path
- (Optional) A secondary contextual path and parameters for tuple resources

### Step 3: Building Parameter Mapping

When generating a method for an operation, the system calls `BuildParameterMapping(operationPath)` to create a `ParameterContextRegistry`. 

**Common Scenario - Parameter Name Mismatch:**

A common use case is when the operation path uses a different parameter name than the contextual path for the same logical parameter.

For example:
- **Contextual Path:** `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/resources/{resourceName}`
- **Operation Path:** `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Example/resources/{name}/childResources`

The operation path uses `{name}` while the contextual path uses `{resourceName}`. A naive name-based matching would fail to recognize these as the same parameter.

**The Solution:**

The parameter mapping process:

1. **Finds the shared segments** between the contextual path and operation path
2. **Walks the operation path** and for each variable segment:
   - If within the shared area, maps it to the corresponding contextual parameter by position (not by name)
   - If beyond the shared area, marks it as a pass-through parameter (no contextual source)

This position-based matching correctly identifies that `{name}` at the same position as `{resourceName}` represents the same logical parameter.

**Example:**

```csharp
Contextual Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}
Operation Path:  /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}/extensions/{extensionName}

Shared segments: 8 (all segments up to and including {vmName})

Parameter Mappings:
- subscriptionId → Contextual (Id.SubscriptionId) [position 1]
- resourceGroupName → Contextual (Id.ResourceGroupName) [position 3]
- vmName → Contextual (Id.Name) [position 7]
- extensionName → Pass-through (must be provided by caller) [position 9, beyond shared area]
```

### Step 4: Generating Method Parameters

The `OperationMethodParameterHelper` uses the parameter mapping to filter out contextual parameters from the method signature:

```csharp
// Without parameter filtering (incorrect):
GetExtensionsAsync(string subscriptionId, string resourceGroupName, string vmName, string extensionName, ...)

// With parameter filtering (correct):
GetExtensionsAsync(string extensionName, CancellationToken cancellationToken = default)
```

The contextual parameters are automatically supplied from `Id` when invoking the REST API.

### Step 5: Populating Arguments

When building the method body, `ParameterContextRegistry.PopulateArguments()` generates the argument list for the REST client call:

```csharp
// Generated code:
_restClient.GetExtensions(
    Id.SubscriptionId,          // from contextual parameter
    Id.ResourceGroupName,        // from contextual parameter
    Id.Name,                     // from contextual parameter (vmName)
    extensionName,               // from method parameter
    context
);
```

## Advanced Scenarios

### Tuple Resources

Some resource collections require multiple parameters from their parent context. For example, a resource might be identified by both a location and a name rather than just a name.

In these cases:
- The **primary contextual path** represents the resource collection's parent
- The **secondary contextual path** represents the full path to list resources in the collection (typically from a `GetAll`/list operation)
- Additional parameters from the secondary path beyond the primary path are stored as private fields in the collection class

The `OperationContext` handles this by building two sets of contextual parameters and merging them appropriately when mapping operation parameters.

### Extension Resources

Extension resources have a flexible scope (can extend any resource). Their contextual path starts with a single variable segment:
```
/{resourceUri}/providers/Microsoft.Example/extensions/{extensionName}
```

The system handles these specially, treating `resourceUri` as a contextual parameter derived from the parent resource's Id.

### Singleton Resources

Singleton resources have a fixed name (e.g., `/placementScores/spot`). The constant name segment increases the parent layer count so that parameters are extracted from the correct level in the Id hierarchy.

## Benefits

1. **Cleaner API Surface**: Method signatures only include parameters the caller must provide
2. **Type Safety**: Ensures all required parameters are accounted for (either contextual or explicit)
3. **Maintainability**: Centralized logic for parameter resolution
4. **Correctness**: Handles complex scenarios like name mismatches, tuple resources, and hierarchical dependencies
5. **Documentation**: Generated XML docs accurately reflect which parameters are needed

## Summary

The Operation Context system is a sophisticated parameter resolution mechanism that:
- Analyzes resource path hierarchies to determine contextual parameters
- Matches operation parameters to their contextual sources using position-based logic
- Generates clean method signatures by filtering contextual parameters
- Automatically populates contextual values from the resource's Id property

This ensures generated SDKs are both ergonomic and correct, handling complex real-world scenarios while maintaining a simple programming model for SDK users.
