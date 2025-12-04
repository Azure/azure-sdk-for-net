# Migration Guide for Split Libraries

This document provides guidance on how to migrate your projects to use the newly
split libraries.  For all of the examples we will use an original package `Foo`
which had 3 resources `Resource1`, `Resource2`, and `Resource3`.  `Resource1` will
be moving to a new package `Bar`.

There are 4 main scenarios to consider:
1. You have a direct dependency on only types that moved.
2. You have a direct dependency on types that stayed.
3. You have a transitive dependency on only types that moved
4. You have a transitive dependency on types that stayed.

## Direct Dependency on Types that Stayed

In this scenario if you want to use the latest library for the types you depend
on you can simply update your dependency to the new version of the original package.

```diff
- <PackageReference Include="Foo" Version="1.0.0" />
+ <PackageReference Include="Foo" Version="1.1.0" />
```

After this everything should work exactly as it did before since the moved types
will be backwards compatible.

## Direct Dependency on Only Types that Moved

In this scenario if you want to use the latest library for the types
you depend on you can simply update your dependency to the new package.

```diff
- <PackageReference Include="Foo" Version="1.0.0" />
+ <PackageReference Include="Bar" Version="1.0.0" />
```

After this everything should work exactly as it did before since the moved types
will be backwards compatible.

## Transitive Dependency on Types that Stayed

For example, you depend on a package called `Baz` which depends on `Foo` and you
also use types that stayed in `Foo`.

In this scenario if you want to use the latest library for the types you depend
on you can simply add a direct dependency to the new version of the original
package.  This will automatically upgrade the dependency for `Baz` which will
be backwards compatible.

```diff
  <PackageReference Include="Baz" Version="1.0.0" />
+ <PackageReference Include="Foo" Version="1.1.0" />
```

After this everything should work exactly as it did before since the moved types
will be backwards compatible.

## Transitive Dependency on Only Types that Moved

For example, you depend on a package called `Baz` which depends on `Foo` and you
also use types that moved to `Bar`.

In this scenario the simplest thing to do is to follow [add a direct dependency to Foo v1.1.0](#transitive-dependency-on-types-that-stayed).
The only reason to add a direct dependency to `Bar` instead of `Foo` would
be if the size of your application is a concern and you want to avoid pulling in
`Foo` entirely.

If this is the case there are a few steps to follow.  First we will need to add
a direct dependency to `Bar` with an alias.

```diff
  <PackageReference Include="Baz" Version="1.0.0" />
+ <PackageReference Include="Bar" Version="1.0.0">
+   <Aliases>BarPackage</Aliases>
+ </PackageReference>
```

Next we will need to add an `extern` to use the aliased package. Then a using
alias can be created to reference the moved types.

```csharp
extern alias BarPackage;
using BarResource1 = BarPackage::Namespace.Resource1;
```

Now we can explicitly reference `Resource1` from either the transitive `Foo` v1.0.0
or the direct `Bar` v1.0.0 dependency.

```csharp
extern alias BarPackage;

using Foo;
using BarResource1 = BarPackage::Namespace.Resource1;

var resourceFromFoo = new Resource1(); // From Foo v1.0.0
var resourceFromBar = new BarResource1(); // From Bar v1.0.0
```

## Changes Required in Mocking

When migrating to the split libraries, only the mocking of **extension methods** that have moved to the new package is impacted. Mocking of instance methods and extension methods that remain in the original package will continue to work without changes.

If you are mocking an extension method that has moved, you will notice that the corresponding method on the original mockable resource (e.g. `MockableFooSubscriptionResource`) is now marked as `Obsolete`. The compiler warning will provide a message pointing to the new method location in the new package.

For example, if you were previously mocking an extension method on `SubscriptionResource` that was part of `Foo`, you might have had code like this:

```csharp
using Foo.Mocking;

// ...

var subscriptionMock = new Mock<SubscriptionResource>();
var mockableSubscription = new Mock<MockableFooSubscriptionResource>();
// GetResource1s is now Obsolete and will generate a warning
mockableSubscription.Setup(x => x.GetResource1s(It.IsAny<CancellationToken>()))
    .Returns(resource1CollectionMock.Object);

subscriptionMock.Setup(x => x.GetCachedClient(It.IsAny<Func<ArmClient, MockableFooSubscriptionResource>>()))
    .Returns(mockableSubscription.Object);
```

You might see a warning like this:
> This method is obsolete. Call Bar.Mocking.MockableBarSubscriptionResource.GetResource1s instead.

To fix this, you need to update your mocking code to use the mockable resource from the new package (e.g. `MockableBarSubscriptionResource`). Apart from updating the type name and the namespace, the method signatures remain the same, so no other logic changes are required.

Here is an example of how to update your test code:

```diff
- using Foo.Mocking;
+ using Bar.Mocking;

  // ...

  var subscriptionMock = new Mock<SubscriptionResource>();
- var mockableSubscription = new Mock<MockableFooSubscriptionResource>();
+ var mockableSubscription = new Mock<MockableBarSubscriptionResource>();
  mockableSubscription.Setup(x => x.GetResource1s(It.IsAny<CancellationToken>()))
      .Returns(resource1CollectionMock.Object);

- subscriptionMock.Setup(x => x.GetCachedClient(It.IsAny<Func<ArmClient, MockableFooSubscriptionResource>>()))
+ subscriptionMock.Setup(x => x.GetCachedClient(It.IsAny<Func<ArmClient, MockableBarSubscriptionResource>>()))
      .Returns(mockableSubscription.Object);
```
