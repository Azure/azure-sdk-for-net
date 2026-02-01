# Extension Class Generation in Azure Management SDK

## Introduction

This document explains how extension classes are generated in the Azure Management SDK code generator. The extension pattern is a core architectural pattern that provides a clean, mockable API surface for Azure Resource Manager (ARM) operations.

### The Extension Pattern

The Azure Management SDK uses a **two-layer extension pattern**:

1. **Public Static Extensions** (`{ServiceName}Extensions.cs`) - Static extension methods that provide the public API surface
2. **Mockable Providers** (`Mockable{ServiceName}{Scope}Resource.cs`) - Scope-specific classes that implement the actual logic

This pattern enables:
- **Clean API**: Users call extension methods on familiar ARM types (`ArmClient`, `ResourceGroupResource`, etc.)
- **Mockability**: All logic resides in mockable provider classes, not static methods
- **Testability**: Users can mock the mockable providers for unit testing
- **Scope Organization**: Operations are organized by ARM hierarchy level

## Architecture Overview

### Key Components

#### 1. ExtensionProvider
- **File**: `ExtensionProvider.cs`
- **Purpose**: Generates the public static extension class (`{ServiceName}Extensions`)
- **Responsibilities**:
  - Generates `GetCachedClient` methods to instantiate mockable providers
  - Generates forwarding methods that delegate to mockable providers

**Methods Forwarded**: All public methods from mockable providers are forwarded, including:
- Factory methods for resource collections (e.g., `GetFoos()`)
- Convenience Get methods (e.g., `GetFooAsync(string fooName)`)
- Singleton resource factory methods (e.g., `GetFooSettings()`)
- Non-resource methods (e.g., `GetAllPrivateLinkResourcesAsync()`)
- Resource-specific extension methods from categorized resource methods

**Example Output**: See [AzureGeneratorMgmtTypeSpecTestsExtensions.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/generator/TestProjects/Local/Mgmt-TypeSpec/src/Generated/Extensions/AzureGeneratorMgmtTypeSpecTestsExtensions.cs)

#### 2. MockableResourceProvider
- **File**: `MockableResourceProvider.cs`
- **Purpose**: Generates scope-specific mockable provider classes
- **Responsibilities**:
  - Implements actual operation logic for a specific ARM scope
  - Provides factory methods for resource collections
  - Provides convenience methods (Get, List) for resources
  - Hosts non-resource operations that belong to the scope

**Example Output**: See [MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource.cs](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/packages/http-client-csharp-mgmt/generator/TestProjects/Local/Mgmt-TypeSpec/src/Generated/Extensions/MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource.cs)

### Types of Mockable Providers

The generator creates **six types of mockable provider classes**, one for each ARM scope level:

1. **MockableArmClient** (`Mockable{ServiceName}ArmClient`)
   - **Extends**: `ArmClient`
   - **Scope**: Extension resources (resources that can be attached to any ARM resource)
   - **Generated when**: Extension resources or extension-scoped non-resource methods exist
   - **Contains**:
     - `GetResourceIdMethod` for extension resources
     - Factory methods for extension resource collections
     - Non-resource methods scoped to extensions

2. **MockableTenantResource** (`Mockable{ServiceName}TenantResource`)
   - **Extends**: `TenantResource`
   - **Scope**: Tenant level (`/`)
   - **Generated when**: Tenant-scoped resources or operations exist
   - **Contains**:
     - Factory methods for tenant-level resource collections (e.g., `GetFoos()`)
     - Convenience Get methods for tenant-level resources (e.g., `GetFooAsync(string fooName)`)
     - Non-resource methods scoped to tenant level

3. **MockableSubscriptionResource** (`Mockable{ServiceName}SubscriptionResource`)
   - **Extends**: `SubscriptionResource`
   - **Scope**: Subscription level (`/subscriptions/{subscriptionId}`)
   - **Generated when**: Subscription-scoped resources or operations exist
   - **Contains**:
     - Factory methods for subscription-level resource collections
     - Convenience Get methods for subscription-level resources
     - Non-resource methods scoped to subscription level
     - Resource-specific extension methods that operate at subscription scope

4. **MockableResourceGroupResource** (`Mockable{ServiceName}ResourceGroupResource`)
   - **Extends**: `ResourceGroupResource`
   - **Scope**: Resource group level (`/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}`)
   - **Generated when**: Resource group-scoped resources or operations exist
   - **Contains**:
     - Factory methods for resource group-level resource collections
     - Convenience Get methods for resource group-level resources
     - Non-resource methods scoped to resource group level
     - Resource-specific extension methods that operate at resource group scope

5. **MockableManagementGroupResource** (`Mockable{ServiceName}ManagementGroupResource`)
   - **Extends**: `ManagementGroupResource`
   - **Scope**: Management group level (`/providers/Microsoft.Management/managementGroups/{managementGroupId}`)
   - **Generated when**: Management group-scoped resources or operations exist
   - **Contains**:
     - Factory methods for management group-level resource collections
     - Convenience Get methods for management group-level resources
     - Non-resource methods scoped to management group level

### Method Placement Rules

Methods are placed in mockable providers based on these rules:

**For Resource Collections** (when resource has Get operation):
- **Factory method** (e.g., `GetFoos()`) → Placed in the mockable provider for the resource's scope
- **Convenience Get method** (e.g., `GetFooAsync(string name)`) → Placed in the mockable provider for the resource's scope
- **Example**: A resource group-scoped resource `Foo` will have its factory and convenience methods in `MockableResourceGroupResource`

**For Singleton Resources**:
- **Factory method** (e.g., `GetFooSettings()`) → Returns the singleton resource directly, placed in the mockable provider for the resource's scope
- **No convenience Get method** (singleton has a fixed name)

**For Non-Resource Methods** (operations without corresponding resource class):
- Placed in the mockable provider corresponding to their **operation scope** (determined by request path)
- **Example**: `GetAllPrivateLinkResourcesAsync()` is placed in `MockableResourceGroupResource` because its path is `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/...`

**For Resource-Specific Extension Methods**:
- Methods categorized as `MethodsInExtension` are placed in the mockable provider for their **operation scope**
- This allows operations on a resource to be called from parent scopes when appropriate
- **Example**: A list operation for child resources might be accessible from the parent resource's scope

#### 3. ManagementOutputLibrary
- **File**: `ManagementOutputLibrary.cs`
- **Purpose**: Orchestrates the categorization and initialization of resources and methods
- **Responsibilities**:
  - Categorizes operations from TypeSpec into resource vs non-resource methods
  - Groups operations by `ResourceScope` (Tenant, Subscription, ResourceGroup, ManagementGroup, Extension)
  - Builds resource clients, collections, and mockable providers
  - Maintains mappings between resources and their scopes

For detailed information on how resources and operations are categorized, see [Resource and Operation Categorization](./categorization.md).

## TypeSpec to C# Flow

### TypeSpec ARM Templates

ARM operations in TypeSpec are defined using standard ARM templates:

```typespec
// Resource definition
model Foo is TrackedResource<FooProperties> {
  @key("fooName")
  @segment("foos")
  name: string;
}

// Operations interface
@armResourceOperations(Foo)
interface Foos {
  get is ArmResourceRead<Foo>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;
  delete is ArmResourceDeleteAsync<Foo>;
  listByResourceGroup is ArmResourceListByParent<Foo>;
}
```

### Key TypeSpec Decorators

- **`@armResourceOperations(T)`**: Marks an interface as containing ARM resource operations
- **`@parentResource(T)`**: Specifies the parent resource for nested resources
- **`@segment(name)`**: Defines the URL segment for the resource type
- **ARM Templates**:
  - `ArmResourceRead<T>` → GET operation
  - `ArmResourceCreateOrUpdateAsync<T>` → PUT operation (LRO)
  - `ArmResourceDeleteAsync<T>` → DELETE operation (LRO)
  - `ArmResourceListByParent<T>` → GET list operation
  - `ArmResourcePatchAsync<T>` → PATCH operation (LRO)

### Path Construction

Request paths are constructed following this pattern:

```
{scope_prefix}/{providers_segment}/{resource_type_path}
```

Examples:
- ResourceGroup scope: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}`
- Subscription scope: `/subscriptions/{subscriptionId}/providers/MgmtTypeSpec/bars/{barName}`
- Nested resource: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}/bazs/{bazName}`

### InputServiceMethod Metadata

The TypeSpec emitter converts operations to `InputServiceMethod` objects with:
- **Path**: The HTTP request path template
- **HttpMethod**: GET, PUT, POST, DELETE, PATCH
- **Parameters**: Path, query, header, and body parameters
- **Responses**: Expected response types
- **LongRunning**: Whether the operation is a long-running operation

## Code Generation Details

### When Full Resource Classes Are Generated

A **full ARM resource class** (Resource + Collection) is generated when:

1. **Minimum requirement**: The resource has a `Get` operation (`ArmResourceRead<T>`)
2. **Complete CRUD pattern**: Resource has Get, Create/Update, Delete, and List operations

**Example - Full Resource**:
```typespec
@armResourceOperations(Foo)
interface Foos {
  get is ArmResourceRead<Foo>;                        // Required - triggers resource generation
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Foo>;
  delete is ArmResourceDeleteAsync<Foo>;
  listByResourceGroup is ArmResourceListByParent<Foo>;
}
```

Generates:
- `FooResource.cs` - Resource class with instance operations
- `FooCollection.cs` - Collection class with Get, CreateOrUpdate methods
- Extension methods in mockable providers

### When Only Extension Methods Are Generated

**Non-resource methods** are generated when:

1. The operation doesn't have a corresponding resource with a Get operation
2. The operation is a list/query operation without CRUD support

**Example - Non-Resource Method**:
```typespec
model PrivateLink is ProxyResource<PrivateLinkResourceProperties> {
  ...PrivateLinkResourceParameter;
}

@armResourceOperations(PrivateLink)
interface PrivateLinks {
  @clientName("GetAllPrivateLinkResources")
  listByMongoCluster is ArmResourceListByParent<PrivateLink>;  // Only list, no Get
}
```

Generates:
- `GetAllPrivateLinkResourcesAsync` method in `MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource`
- **No** `PrivateLinkResource` class
- **No** `PrivateLinkCollection` class

### ProxyResource vs TrackedResource

#### TrackedResource
- **Definition**: Resources with location and tags (full Azure Resource properties)
- **Characteristics**:
  - Inherits `ArmResource` in C#
  - Has `Location`, `Tags`, `Id`, `Name`, `Type`, `SystemData`
  - Supports regional deployment
- **Example**: Virtual Machines, Storage Accounts

#### ProxyResource
- **Definition**: Resources without location/tags (minimal properties)
- **Characteristics**:
  - Inherits `ArmResource` in C#
  - Only has `Id`, `Name`, `Type`, `SystemData`
  - Often child/nested resources
- **Example**: SubResources, Configurations, Settings

Both follow the same code generation pattern for methods.

### Singleton Resources

**Singleton resources** have a fixed name and don't require a collection:

```typespec
@singleton
model FooSettings is ProxyResource<FooSettingsProperties> {}

@armResourceOperations(FooSettings)
interface FooSettingsOperations {
  get is ArmResourceRead<FooSettings>;
}
```

Generates:
- `FooSettingsResource.cs` - Resource class
- **No collection class** (singleton doesn't need it)
- Factory method in mockable provider: `GetFooSettings()` returns the resource directly

```csharp
public virtual FooSettingsResource GetFooSettings()
{
    return new FooSettingsResource(Client, Id.AppendProviderResource("MgmtTypeSpec", "FooSettings", "default"));
}
```

## Key Files & Classes Reference

### Generator Source Files

| File | Purpose |
|------|---------|
| `ExtensionProvider.cs` | Generates public static extension class with forwarding methods |
| `MockableResourceProvider.cs` | Generates scope-specific mockable provider classes |
| `MockableArmClientProvider.cs` | Generates mockable provider for ArmClient (Extension scope) |
| `ManagementOutputLibrary.cs` | Orchestrates categorization and initialization |
| `ResourceScope.cs` | Defines ARM hierarchy levels enum |
| `ResourceMetadata.cs` | Represents metadata for a resource from TypeSpec |
| `ResourceMethod.cs` | Represents a resource-specific operation |
| `NonResourceMethod.cs` | Represents a non-resource operation |
| `ResourceMethodCategory.cs` | Categorizes methods into Resource/Collection/Extension |
| `RequestPathPattern.cs` | Analyzes and compares request path patterns |
| `ResourceHelpers.cs` | Utility methods for naming and categorization |

### Generated Output Files

| File | Description |
|------|-------------|
| `{ServiceName}Extensions.cs` | Public static extension class |
| `Mockable{ServiceName}ArmClient.cs` | Mockable provider for Extension scope |
| `Mockable{ServiceName}TenantResource.cs` | Mockable provider for Tenant scope |
| `Mockable{ServiceName}SubscriptionResource.cs` | Mockable provider for Subscription scope |
| `Mockable{ServiceName}ResourceGroupResource.cs` | Mockable provider for ResourceGroup scope |
| `Mockable{ServiceName}ManagementGroupResource.cs` | Mockable provider for ManagementGroup scope |
| `{ResourceName}Resource.cs` | ARM resource class with instance operations |
| `{ResourceName}Collection.cs` | Collection class for CRUD operations |
| `{ResourceName}Data.cs` | Data model for the resource |

## Examples

### Example 1: Full Resource with CRUD

**TypeSpec Definition**:
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

**Generated Classes**:
1. `FooResource.cs` - Resource with instance operations
2. `FooCollection.cs` - Collection with Get, CreateOrUpdate, List
3. Extension methods in `MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource`

**Generated Extension Methods**:
```csharp
// In MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource
public virtual FooCollection GetFoos()
{
    return GetCachedClient(client => new FooCollection(client, Id));
}

public virtual async Task<Response<FooResource>> GetFooAsync(string fooName, CancellationToken cancellationToken = default)
{
    return await GetFoos().GetAsync(fooName, cancellationToken).ConfigureAwait(false);
}

// In AzureGeneratorMgmtTypeSpecTestsExtensions (forwarding)
public static FooCollection GetFoos(this ResourceGroupResource resourceGroupResource)
{
    return GetMockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource(resourceGroupResource).GetFoos();
}
```

**Request Path**: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}`
**Scope**: ResourceGroup (determined by path prefix)

### Example 2: Non-Resource Method (GetAllPrivateLinkResourcesAsync)

**TypeSpec Definition**:
```typespec
model PrivateLink is ProxyResource<PrivateLinkResourceProperties> {
  ...PrivateLinkResourceParameter;
}

@armResourceOperations(PrivateLink)
interface PrivateLinks {
  /** list private links on the given resource */
  @clientName("GetAllPrivateLinkResources")
  listByMongoCluster is ArmResourceListByParent<PrivateLink>;
}
```

**Analysis**:
- **Operation**: `ArmResourceListByParent<PrivateLink>` - List operation only
- **Missing**: No `ArmResourceRead<PrivateLink>` (Get operation)
- **Path**: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/privateLinkResources`
- **Scope**: ResourceGroup (based on path pattern)

**Why No Resource Class?**:
The `PrivateLink` model lacks a Get operation (`ArmResourceRead<PrivateLink>`), which is the **minimum requirement** for generating a full resource class. Without Get, the generator cannot create:
- `PrivateLinkResource` class (needs Get for instance retrieval)
- `PrivateLinkCollection` class (needs Get for collection pattern)

**Generated Output**:
Only non-resource methods in `MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource`:

```csharp
// In MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource
private ClientDiagnostics _privateLinksClientDiagnostics;
private PrivateLinks _privateLinksRestClient;

private ClientDiagnostics PrivateLinksClientDiagnostics => 
    _privateLinksClientDiagnostics ??= new ClientDiagnostics(
        "Azure.Generator.MgmtTypeSpec.Tests.Mocking", 
        ProviderConstants.DefaultProviderNamespace, 
        Diagnostics);

private PrivateLinks PrivateLinksRestClient => 
    _privateLinksRestClient ??= new PrivateLinks(
        PrivateLinksClientDiagnostics, 
        Pipeline, 
        Endpoint, 
        "2024-05-01");

public virtual AsyncPageable<PrivateLink> GetAllPrivateLinkResourcesAsync(CancellationToken cancellationToken = default)
{
    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    return new PrivateLinksGetAllPrivateLinkResourcesAsyncCollectionResultOfT(
        PrivateLinksRestClient, 
        Guid.Parse(Id.SubscriptionId), 
        Id.ResourceGroupName, 
        context);
}

public virtual Pageable<PrivateLink> GetAllPrivateLinkResources(CancellationToken cancellationToken = default)
{
    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
    return new PrivateLinksGetAllPrivateLinkResourcesCollectionResultOfT(
        PrivateLinksRestClient, 
        Guid.Parse(Id.SubscriptionId), 
        Id.ResourceGroupName, 
        context);
}

// In AzureGeneratorMgmtTypeSpecTestsExtensions (forwarding)
public static AsyncPageable<PrivateLink> GetAllPrivateLinkResourcesAsync(
    this ResourceGroupResource resourceGroupResource, 
    CancellationToken cancellationToken = default)
{
    return GetMockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource(resourceGroupResource)
        .GetAllPrivateLinkResourcesAsync(cancellationToken);
}
```

**Key Takeaway**: This demonstrates that operations can exist without corresponding resource classes when CRUD requirements aren't met.

### Example 3: Singleton Resource

**TypeSpec Definition**:
```typespec
model FooSettings is ProxyResource<FooSettingsProperties> {}

@armResourceOperations(FooSettings)
interface FooSettingsOperations {
  get is ArmResourceRead<FooSettings>;
  update is ArmResourcePatchAsync<FooSettings>;
}
```

**Generated Output**:
```csharp
// In MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource
public virtual FooSettingsResource GetFooSettings()
{
    return new FooSettingsResource(Client, Id.AppendProviderResource("MgmtTypeSpec", "FooSettings", "default"));
}

// In AzureGeneratorMgmtTypeSpecTestsExtensions
public static FooSettingsResource GetFooSettings(this ResourceGroupResource resourceGroupResource)
{
    return GetMockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource(resourceGroupResource).GetFooSettings();
}
```

**Characteristics**:
- No collection class (singleton has a fixed name)
- Factory method returns resource directly
- Resource path includes hardcoded "default" name
- Still has resource class with instance operations (Get, Update)

### Example 4: Nested Resource

**TypeSpec Definition**:
```typespec
@parentResource(Foo)
model Baz is ProxyResource<BazProperties> {
  @key("bazName")
  @segment("bazs")
  name: string;
}

@armResourceOperations(Baz)
interface Bazs {
  get is ArmResourceRead<Baz>;
  createOrUpdate is ArmResourceCreateOrUpdateAsync<Baz>;
  listByParent is ArmResourceListByParent<Baz>;
}
```

**Generated Output**:
- `BazResource.cs` - Nested resource class
- `BazCollection.cs` - Collection on parent resource (Foo)
- Extension methods in `FooResource` (parent), not in mockable provider

```csharp
// In FooResource.cs
public virtual BazCollection GetBazs()
{
    return GetCachedClient(client => new BazCollection(client, Id));
}
```

**Request Path**: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}/bazs/{bazName}`
**Parent Path**: `/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/MgmtTypeSpec/foos/{fooName}`

## Common Patterns

### Pattern 1: GetCachedClient

**Purpose**: Ensures only one instance of a mockable provider is created per ARM resource instance.

**Implementation**:
```csharp
// In ExtensionProvider
private static MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource 
    GetMockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource(ResourceGroupResource resourceGroupResource)
{
    return resourceGroupResource.GetCachedClient(client => 
        new MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource(client, resourceGroupResource.Id));
}
```

**Benefits**:
- Performance: Avoids creating duplicate provider instances
- State preservation: Same instance is reused across calls
- Memory efficiency: One instance per resource

### Pattern 2: Forwarding Methods

**Purpose**: Delegate from public static extensions to mockable providers.

**Pattern**:
```csharp
// Public static extension (non-mockable)
public static AsyncPageable<Foo> GetAllFoosAsync(this ResourceGroupResource resourceGroupResource, ...)
{
    return GetMockableProvider(resourceGroupResource).GetAllFoosAsync(...);
}

// Mockable provider (testable)
public virtual AsyncPageable<Foo> GetAllFoosAsync(...)
{
    // Actual implementation
}
```

**Benefits**:
- Clean API: Users call extension methods naturally
- Mockability: Tests can mock the provider methods
- Separation: Public API is separate from implementation

### Pattern 3: Factory Methods for Collections

**Purpose**: Provide access to resource collections from parent scopes.

**Pattern**:
```csharp
// In MockableProvider or ParentResource
public virtual FooCollection GetFoos()
{
    return GetCachedClient(client => new FooCollection(client, Id));
}

// Users call
var foos = resourceGroup.GetFoos();
var foo = await foos.GetAsync("myFoo");
```

**Benefits**:
- Consistent navigation: Parent → Collection → Resource
- Lazy instantiation: Collection created only when accessed
- Type safety: Strongly typed collection

### Pattern 4: Convenience Get Methods

**Purpose**: Shortcut to get a resource without going through collection.

**Pattern**:
```csharp
// Convenience method
public virtual async Task<Response<FooResource>> GetFooAsync(string fooName, ...)
{
    return await GetFoos().GetAsync(fooName, ...);
}

// Equivalent to
var foos = resourceGroup.GetFoos();
var foo = await foos.GetAsync("myFoo");

// But cleaner as
var foo = await resourceGroup.GetFooAsync("myFoo");
```

**Benefits**:
- User convenience: Shorter call chain for common scenarios
- Consistency: Same result as going through collection
- Discoverability: Users find the method directly on parent

### Pattern 5: REST Client Initialization

**Purpose**: Lazy initialization of REST clients for operation groups.

**Pattern**:
```csharp
private ClientDiagnostics _fooClientDiagnostics;
private Foos _fooRestClient;

private ClientDiagnostics FooClientDiagnostics => 
    _fooClientDiagnostics ??= new ClientDiagnostics(
        "Namespace", 
        ProviderConstants.DefaultProviderNamespace, 
        Diagnostics);

private Foos FooRestClient => 
    _fooRestClient ??= new Foos(
        FooClientDiagnostics, 
        Pipeline, 
        Endpoint, 
        ApiVersion);
```

**Benefits**:
- Lazy loading: Clients created only when needed
- Memory efficiency: No unused client instances
- Pipeline sharing: Uses parent resource's HTTP pipeline

## Best Practices

### For TypeSpec Authors

1. **Always include Get operation** if you want a full resource class:
   ```typespec
   @armResourceOperations(MyResource)
   interface MyResources {
     get is ArmResourceRead<MyResource>;  // Required for resource class
     // ... other operations
   }
   ```

2. **Use `@clientName` for friendly method names**:
   ```typespec
   @clientName("GetAllPrivateLinkResources")
   listByMongoCluster is ArmResourceListByParent<PrivateLink>;
   ```

3. **Specify parent relationships explicitly**:
   ```typespec
   @parentResource(ParentResource)
   model ChildResource is ProxyResource<ChildProperties> { }
   ```

4. **Use singleton pattern for settings/config resources**:
   ```typespec
   @singleton
   model Settings is ProxyResource<SettingsProperties> {}
   ```

### For Generator Developers

1. **Scope determination is path-based**: Always check `RequestPathPattern` for scope categorization
2. **Resource classes need Get**: Ensure Get operation exists before generating resource classes
3. **Non-resource methods go to mockable providers**: Don't try to create resources for list-only operations
4. **Preserve operation metadata**: Include operation IDs, descriptions, and paths in documentation
5. **Handle edge cases**: Extension resources, singleton resources, nested resources all have special handling

### For SDK Users

1. **Mock the mockable providers**, not the extensions:
   ```csharp
   // Good - mockable
   var mockProvider = new Mock<MockableAzureGeneratorMgmtTypeSpecTestsResourceGroupResource>();
   
   // Bad - static extensions can't be mocked
   // Can't mock static extension methods
   ```

2. **Use collections for iteration**:
   ```csharp
   await foreach (var foo in resourceGroup.GetFoos().GetAllAsync())
   {
       // Process foo
   }
   ```

3. **Use convenience methods for single gets**:
   ```csharp
   var foo = await resourceGroup.GetFooAsync("myFoo");
   ```

## Troubleshooting

### Why is my resource not generating a class?

**Check**:
1. Does the resource have a Get operation (`ArmResourceRead<T>`)?
2. Is the resource model properly defined with `@armResourceOperations`?
3. Check the emitter output for any diagnostic errors

### Why is my method in the wrong scope?

**Check**:
1. Verify the request path matches the expected scope pattern
2. Check if the path starts with the correct scope prefix
3. Look at `ResourceMetadata.ResourceScope` in the generated code model

### Why is my operation not appearing in extensions?

**Check**:
1. Non-resource operations should appear in mockable providers
2. Resource operations appear based on their categorization (Resource/Collection/Extension)
3. Verify the operation is not being filtered out due to missing metadata

### How do I add a new operation to an existing resource?

1. Add the operation to the TypeSpec interface
2. Ensure it follows ARM template patterns
3. Regenerate - the operation will be categorized automatically
4. Check the appropriate class (Resource, Collection, or Mockable Provider)

## Summary

The extension class generation in Azure Management SDK follows a well-defined pattern:

1. **TypeSpec operations** are analyzed for paths and categorized by scope
2. **Resource operations** with Get create full resource classes; others become non-resource methods
3. **Mockable providers** implement all logic for a specific scope
4. **Static extensions** forward calls to mockable providers for testability
5. **Scope hierarchy** (Tenant → Subscription → ResourceGroup → ManagementGroup + Extension) organizes all operations

This architecture provides a clean, testable, and maintainable SDK that aligns with Azure Resource Manager's hierarchical structure.
