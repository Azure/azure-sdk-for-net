# Splitting an Existing Azure Management Plane Library

This guide describes concrete steps for splitting an existing
(Azure management plane) library into multiple focused packages while
maintaining backwards compatibility. This guide doesn't focus on data plane
splits, however if that use case arises most of the concepts apply.

For documentation on how to migrate to the new packages see
[MigrationGuideForSplit.md](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/LibrarySplit/MigrationGuideForSplit.md).

## High-Level Goals
- Preserve backwards compatibility between the original Package v1.0.0 and the new Package v1.1.0
- Move all related types:
    - Resource
    - ResourceData
    - ResourceCollection
    - Any other models used by those types
    - Extension methods
    - Mocking helpers

---
## High-Level Scenario

For all sections in this doc we will use the same scenario where we start with
a single package called Foo v1.0.0 containing three resources: Resource1,
Resource2, and Resource3.  We want to split the package into two by moving
Resource1 into a new package Bar v1.0.0.  Foo will bump to v1.1.0 and still have
Resource2 and Resource3 inside it but will have a dependency on Bar v1.0.0 and
type forward Resource1 into Bar.

## Dependency

The  new package Foo v1.1.0 will need to depend on Bar v1.0.0 in order to support
type forwarding.  This does introduce a release dependency but will minimize the
impact on our library consumers.

Bar will be able to release independently of Foo as either beta or GA for future
versions.

Foo will also be able to release independently of Bar as either beta or GA for
future versions.  Whenever Foo wants to ship a new version it should bump its
dependency on Bar according to which support model it is shipping under.  If Foo
is shipping as beta it should ship with a dependency on the latest version of Bar
regardless of support model.  If Foo is shipping as GA it should ship with a
dependency on the latest GA version of Bar.

## Types Being Moved

Each type that is moved **MUST** have an identical public API surface in the new
package.  This includes any hidden EBN members that were put in place for
backwards compatibility in the original package.

## TypeForwardedTo

To maintain binary compatibility, Foo v1.1.0 will need to use `TypeForwardedTo`.
For organization we will create a new file called `TypesForwardedTo[NewPackage].cs`
for each new package that Foo is splitting into.

In our example a new file called `TypesForwardedToBar.cs` should be added to
Foo v1.1.0 and this will contain a list of all types that have been moved to Bar
v1.0.0.  This is the only package we are splitting into so it's the only file we
need to add.

`TypesForwardedToBar.cs` (in Foo v1.1.0):
```csharp
using System.Runtime.CompilerServices;
using Foo;

[assembly: TypeForwardedTo(typeof(Resource1))]
[assembly: TypeForwardedTo(typeof(ResourceData1))]
[assembly: TypeForwardedTo(typeof(Resource1Collection))]
// Add additional forwarded dependent property-only types if they moved
```

## TypeForwardedFrom

For some tooling and serializers it is helpful to know where a type was
originally defined.  To help with this we will add the `TypeForwardedFrom`
attribute on each type that is being moved to a new package.

`Resource1.cs` (in Bar v1.0.0):
```csharp
using System.Runtime.CompilerServices;

namespace Bar
{
    [TypeForwardedFrom("Foo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=[key]")]
    public class Resource1 { /* identical body */ }
    [TypeForwardedFrom("Foo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=[key]")]
    public class ResourceData1 { /* identical body */ }
    [TypeForwardedFrom("Foo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=[key]")]
    public class Resource1Collection { /* identical body */ }
}
```

The PublicKeyToken should match the public key token of the original assembly.

## Extension Methods

In management plane most resources have extension methods on ResourceGroupResource,
SubscriptionResource, or other common types in Azure.ResourceManager.  When a
resource is moved to a new package we must also move the extension methods to the
new package.  To maintain backwards compatibility we will need to change the
extension methods in the original package by removing the `this` keyword and making
it a static method that forwards to the new package.  We will also add EBN
attributes to hide the forwarding methods from IntelliSense.  It's also a requirement
that we keep the same namespace between the new and old extension classes.

`FooExtensions.cs` (in Foo v1.0.0):
```csharp
namespace Foo;

public static class FooExtensions
{
    public static Resource1 GetResource1(this ResourceGroupResource group) { ... }
    public static Resource2 GetResource2(this ResourceGroupResource group) { ... }
    public static Resource3 GetResource3(this ResourceGroupResource group) { ... }
}
```

`FooExtensions.cs` (in Foo v1.1.0):
```csharp
namespace Foo;

public static class FooExtensions
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Resource1 GetResource1(ResourceGroupResource group)
        => BarExtensions.GetResource1(group);
    public static Resource2 GetResource2(this ResourceGroupResource group) { ... }
    public static Resource3 GetResource3(this ResourceGroupResource group) { ... }
}
```

`BarExtensions.cs` (in Bar v1.0.0):
```csharp
namespace Foo;

public static class BarExtensions
{
    public static Resource1 GetResource1(this ResourceGroupResource group) { ... }
}
```

## Mocking Helpers

**TODO:** Define mocking patterns for split resources. (Pending design decision.)

## Model Factory

When a resource is moved to a new package we must also move its model factory.
Initially we will maintain backwards compatibility by adding forwarding methods
in the original package that call into the new package.  We will also add EBN
attributes to hide the forwarding methods from IntelliSense.

`FooModelFactory.cs` (in Foo v1.0.0):
```csharp
namespace Foo;

public static class FooModelFactory
{
    public static ResourceData1 ResourceData1(/* parameters */) { ... }
    public static ResourceData2 ResourceData2(/* parameters */) { ... }
    public static ResourceData3 ResourceData3(/* parameters */) { ... }
}
```

`FooModelFactory.cs` (in Foo v1.1.0):
```csharp
namespace Foo;

public static class FooModelFactory
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static ResourceData1 ResourceData1(/* parameters */)
        => BarModelFactory.ResourceData1(/* parameters */);
    public static ResourceData2 ResourceData2(/* parameters */) { ... }
    public static ResourceData3 ResourceData3(/* parameters */) { ... }
}
```

`BarModelFactory.cs` (in Bar v1.0.0):
```csharp
namespace Bar;

public static class BarModelFactory
{
    public static ResourceData1 ResourceData1(/* parameters */) { ... }
}
```

## Common Models

If two models have a property of the same model type and one of those models is
moving to the new package we need to move that shared model to the new package.
The original package will have a dependency on the new package so it can reference
the same model type.

For example if ResourceData1 and ResourceData2 has a property of type SharedModel
and Resource1 is moving to Bar then SharedModel must also move to Bar.

`ResourceData1.cs` (in Foo v1.0.0):
```csharp
public class ResourceData1
{
    public SharedModel SharedProperty { get; set; }
}
```

`ResourceData2.cs` (in Foo v1.0.0):
```csharp
public class ResourceData2
{
    public SharedModel SharedProperty { get; set; }
}
```

`SharedModel.cs` (in Foo v1.0.0):
```csharp
public class SharedModel { }
```

`TypesForwardedToBar.cs` (in Foo v1.1.0):
```csharp
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(ResourceData1))]
[assembly: TypeForwardedTo(typeof(SharedModel))]
```