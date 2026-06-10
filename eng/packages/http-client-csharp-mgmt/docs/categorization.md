# Resource and Operation Categorization in Azure Management SDK

## Introduction

This document explains how operations and resources are categorized in the Azure Management SDK code generator. The categorization system determines how TypeSpec operations are organized into C# classes based on ARM (Azure Resource Manager) hierarchy and operation characteristics.

## ResourceScope Enum

Operations are categorized into five ARM hierarchy levels:

```csharp
internal enum ResourceScope
{
    Tenant,              // Root level (/)
    Subscription,        // /subscriptions/{subscriptionId}
    ResourceGroup,       // /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}
    ManagementGroup,     // /providers/Microsoft.Management/managementGroups/{managementGroupId}
    Extension,           // Extension resources (/{resourceUri}/providers/...)
}
```

## Path Pattern Analysis

The generator determines scope by analyzing the operation's request path:

### Path Patterns for Each Scope

| Scope | Path Pattern | Example |
|-------|--------------|---------|
| Tenant | `/` (empty) or starts with `/providers/` | `/providers/Microsoft.Authorization/...` |
| Subscription | `/subscriptions/{subscriptionId}` | `/subscriptions/{subscriptionId}/providers/Microsoft.Features/...` |
| ResourceGroup | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}` | `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos` |
| ManagementGroup | `/providers/Microsoft.Management/managementGroups/{managementGroupId}` | `/providers/Microsoft.Management/managementGroups/{managementGroupId}/...` |
| Extension | Starts with `/{resourceUri}/` or `/{scope}/` | `/{resourceUri}/providers/Microsoft.CustomProvider/...` |

### Categorization Logic

The categorization happens in `ManagementOutputLibrary.InitializeResourceClients`:

```csharp
// 1. Categorize resource methods for each resource
var resourceMethodCategories = new Dictionary<ResourceMetadata, ResourceMethodCategory>();
foreach (var resourceMetadata in resourceMetadatas)
{
    var categorizedMethods = resourceMetadata.CategorizeMethods();
    resourceMethodCategories.Add(resourceMetadata, categorizedMethods);
}

// 2. Group resources by their scope
foreach (var (metadata, resourceClient) in resourceDict)
{
    if (metadata.ParentResourceId is null)
    {
        // Top-level resources go into their designated scope
        resourcesAndMethodsPerScope[metadata.ResourceScope].ResourceClients.Add(resourceClient);
    }
}

// 3. Group resource methods by operation scope
foreach (var (metadata, category) in resourceMethods)
{
    foreach (var resourceMethod in category.MethodsInExtension)
    {
        var scope = resourceMethod.OperationScope;
        resourcesAndMethodsPerScope[scope].ResourceMethods[resource].Add(resourceMethod);
    }
}

// 4. Add non-resource methods to their scope
foreach (var nonResourceMethod in nonResourceMethods)
{
    resourcesAndMethodsPerScope[nonResourceMethod.OperationScope].NonResourceMethods.Add(nonResourceMethod);
}
```

## Resource vs Non-Resource Methods

### Resource Methods
- **Definition**: Operations that belong to a specific ARM resource type
- **Characteristics**:
  - Have a corresponding `ResourceMetadata` and resource model
  - May be placed in Resource class, Collection class, or Extension class based on operation kind
  - Path includes the resource type segment
- **Examples**: `Get`, `CreateOrUpdate`, `Delete`, `List` operations on a resource

### Non-Resource Methods
- **Definition**: Operations that don't correspond to a specific resource type
- **Characteristics**:
  - No corresponding resource class is generated
  - Always placed in the mockable provider for their scope
  - Often represent list operations that return resource types without CRUD operations
- **Examples**: 
  - `GetAllPrivateLinkResources` - Lists `PrivateLink` objects, but no `PrivateLinkResource` class exists
  - Operations that validate, check availability, or perform other non-CRUD actions

## Method Categorization

Resource methods are categorized into three groups by `ResourceMethodCategory`:

1. **MethodsInResource**: Operations on resource instances (Update, Delete, custom actions)
2. **MethodsInCollection**: Operations for getting/creating resources (Get, CreateOrUpdate, List)
3. **MethodsInExtension**: Operations that appear as convenience methods in parent scope extensions

### Decision Logic

```csharp
// Simplified categorization logic
foreach (var method in resourceMetadata.Methods)
{
    if (method.Kind == ResourceOperationKind.Get || 
        method.Kind == ResourceOperationKind.Create ||
        method.Kind == ResourceOperationKind.List)
    {
        methodsInCollection.Add(method);
    }
    else if (method.Kind == ResourceOperationKind.Delete ||
             method.Kind == ResourceOperationKind.Update ||
             IsCustomAction(method))
    {
        methodsInResource.Add(method);
    }
    
    // Some operations also appear in extensions for convenience
    if (ShouldAppearInExtension(method))
    {
        methodsInExtension.Add(method);
    }
}
```

## Decision Trees

### Operation Categorization Decision Tree

```
┌─────────────────────────────────────────┐
│ TypeSpec Operation (InputServiceMethod) │
└──────────────┬──────────────────────────┘
               │
               ▼
       ┌───────────────────┐
       │ Analyze Path      │
       │ Determine Scope   │
       └────────┬──────────┘
                │
                ├─── Starts with /{resourceUri}/ or /{scope}/ → Extension
                ├─── /providers/Microsoft.Management/managementGroups/ → ManagementGroup
                ├─── /subscriptions/{id}/resourceGroups/{name}/... → ResourceGroup
                ├─── /subscriptions/{id}/... → Subscription
                └─── / or /providers/... → Tenant
                │
                ▼
       ┌────────────────────┐
       │ Has Resource Model?│
       └────┬───────────┬───┘
            │           │
          YES           NO
            │           │
            ▼           ▼
    ┌──────────────┐  ┌──────────────────────┐
    │ Has Get Op?  │  │ Non-Resource Method  │
    └──┬───────┬───┘  │ → Mockable Provider  │
       │       │      └──────────────────────┘
      YES      NO
       │       │
       │       └──────────────────────┐
       │                              │
       ▼                              ▼
┌──────────────────┐      ┌────────────────────────┐
│ Full Resource    │      │ No Resource Class      │
│ Generate:        │      │ Method in Mockable     │
│ - Resource Class │      │ Provider for Scope     │
│ - Collection     │      └────────────────────────┘
│ - Extensions     │
└────────┬─────────┘
         │
         ▼
    ┌────────────────────┐
    │ Is Singleton?      │
    └──┬──────────┬──────┘
       │          │
      YES         NO
       │          │
       ▼          ▼
┌──────────────┐ ┌─────────────────┐
│ Factory      │ │ Collection +    │
│ Method Only  │ │ Convenience Get │
└──────────────┘ └─────────────────┘
```

### Method Placement Decision Tree

```
┌───────────────────────┐
│ Resource Operation    │
└──────────┬────────────┘
           │
           ▼
    ┌──────────────┐
    │ Operation    │
    │ Kind?        │
    └──┬───────────┘
       │
       ├─── Get / Create / List
       │    │
       │    ▼
       │    ┌──────────────────────┐
       │    │ Collection Class     │
       │    │ + Extension Methods  │
       │    └──────────────────────┘
       │
       ├─── Update / Delete / Custom Action
       │    │
       │    ▼
       │    ┌──────────────────┐
       │    │ Resource Class   │
       │    └──────────────────┘
       │
       └─── Convenience (List on parent, Get shortcut)
            │
            ▼
            ┌───────────────────────────┐
            │ Mockable Provider         │
            │ for Parent Scope          │
            └───────────────────────────┘
```

## Examples

### Example 1: Resource with Full CRUD Operations

**TypeSpec**:
```typespec
model Foo is TrackedResource<FooProperties> {
  @key("fooName")
  @segment("foos")
  name: string;
}

@armResourceOperations(Foo)
interface Foos {
  get is ArmResourceRead<Foo>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;
  delete is ArmResourceDeleteAsync<Foo>;
  listByResourceGroup is ArmResourceListByParent<Foo>;
}
```

**Path**: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}`

**Categorization**:
- **Scope**: ResourceGroup (based on path pattern)
- **Has Resource Model**: Yes (Foo model)
- **Has Get Operation**: Yes → Full resource class generated
- **Methods Categorized**:
  - `Get` → MethodsInCollection
  - `CreateOrUpdate` → MethodsInCollection
  - `Delete` → MethodsInResource
  - `ListByResourceGroup` → MethodsInCollection

**Generated Classes**:
- `FooResource.cs` - Resource with Delete and other instance operations
- `FooCollection.cs` - Collection with Get, CreateOrUpdate, List
- Extension methods in `MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource`

### Example 2: Non-Resource Method (List Only)

**TypeSpec**:
```typespec
model PrivateLink is ProxyResource<PrivateLinkResourceProperties> {
  ...PrivateLinkResourceParameter;
}

@armResourceOperations(PrivateLink)
interface PrivateLinks {
  @clientName("GetAllPrivateLinkResources")
  listByMongoCluster is ArmResourceListByParent<PrivateLink>;
}
```

**Path**: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/privateLinkResources`

**Categorization**:
- **Scope**: ResourceGroup (based on path pattern)
- **Has Resource Model**: Yes (PrivateLink model)
- **Has Get Operation**: No → No resource class generated
- **Classification**: Non-Resource Method

**Generated Output**:
- `GetAllPrivateLinkResourcesAsync` method in `MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource`
- **No** `PrivateLinkResource` class
- **No** `PrivateLinkCollection` class

**Reason**: Without a Get operation, the generator cannot create a full resource class. The operation becomes a standalone method in the mockable provider.

## Key Points

### Scope Determination
- **Path-based**: Scope is determined by analyzing the request path pattern
- **Hierarchical**: Follows ARM hierarchy (Tenant → Subscription → ResourceGroup → ManagementGroup + Extension)
- **Automatic**: No manual configuration needed; derived from path structure

### Resource Classification
- **Get operation is critical**: Presence of Get operation determines if full resource classes are generated
- **CRUD pattern**: Complete CRUD operations result in full resource/collection classes
- **List-only operations**: Become non-resource methods in mockable providers

### Method Placement
- **Collection methods**: Get, Create, List go to collection class
- **Resource methods**: Update, Delete, custom actions go to resource class
- **Extension methods**: Convenience methods for parent scope access
- **Non-resource methods**: Always in mockable provider for their scope

## Related Documentation

- [Extension Class Generation](./extension.md) - Learn about the extension pattern and how methods are exposed
- [Code Generation](../README.md) - General code generation overview

## Troubleshooting

### Why is my operation in the wrong scope?

**Check**:
1. Verify the request path matches the expected scope pattern
2. Check if the path starts with the correct scope prefix
3. Look at `ResourceMetadata.ResourceScope` in the generated code model

### Why is my resource not generating a full class?

**Check**:
1. Does the resource have a Get operation (`ArmResourceRead<T>`)?
2. Is the resource model properly defined with `@armResourceOperations`?
3. Check the emitter output for any diagnostic errors

### Why is my method appearing as a non-resource method?

**Check**:
1. The operation likely lacks a Get operation on the resource
2. The resource model may not be recognized by the generator
3. Verify the operation is correctly associated with the resource via `@armResourceOperations`
