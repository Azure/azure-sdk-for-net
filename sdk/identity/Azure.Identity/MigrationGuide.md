# Migration guide for `Azure.Identity` type consolidation into `Azure.Core`

Starting with `Azure.Core` 1.53.0, all public types that previously lived in the `Azure.Identity` package have been moved into `Azure.Core`. The `Azure.Identity` package (version 1.21.0 and later) is now a lightweight facade that forwards all types to `Azure.Core` using [`TypeForwardedTo`](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.typeforwardedtoattribute) attributes. This is a non-breaking change for most projects — existing code continues to compile and run transparently.

This guide covers the scenarios where you may need to take action.

## Scenarios

| Scenario | Build result | Remedy |
|---|---|---|
| `Azure.Core` only (no `Azure.Identity` reference) | ✅ Builds | No action needed. Identity types are available directly through `Azure.Core`. |
| `Azure.Core` 1.53+ with `Azure.Identity` 1.21+ | ✅ Builds | No action needed. The facade forwards all types correctly. |
| `Azure.Core` 1.53+ with a **direct** `Azure.Identity` 1.19 or later reference | ❌ CS0433 | [Remove the `Azure.Identity` PackageReference](#direct-reference-to-an-older-azureidentity) |
| `Azure.Core` 1.53+ with a **transitive** `Azure.Identity` 1.19 or later reference (via a third-party library) | ❌ CS0433 | [Add a direct `Azure.Identity` 1.21+ PackageReference](#transitive-reference-to-an-older-azureidentity) |
| `Azure.Identity` 1.21+ with `Azure.Identity.Broker` 1.5.0 or earlier | ❌ TypeLoadException | [Update `Azure.Identity.Broker` to 1.6.0+](#azureidentitybroker-compatibility) |

## Understanding CS0433

[CS0433](https://learn.microsoft.com/dotnet/csharp/language-reference/compiler-messages/cs0433) is a compiler error that occurs when the same type is defined in two different assemblies. After the consolidation, types such as `DefaultAzureCredential` exist in both `Azure.Core` (where they now live) and in older versions of `Azure.Identity` (where they used to live). The compiler cannot determine which definition to use, so it reports the conflict.

## Direct reference to an older `Azure.Identity`

If your project has a direct `PackageReference` to an `Azure.Identity` version older than 1.21.0 alongside `Azure.Core` 1.53.0 or later, you will see CS0433 errors.

**Fix:** Remove the `Azure.Identity` `PackageReference` from your project file. The types are now available through `Azure.Core`.

```diff
 <ItemGroup>
   <PackageReference Include="Azure.Core" Version="1.53.0" />
-  <PackageReference Include="Azure.Identity" Version="1.20.0" />
 </ItemGroup>
```

## Transitive reference to an older `Azure.Identity`

If a third-party library that your project depends on brings in an older version of `Azure.Identity` transitively, you will see the same CS0433 errors even though your project does not directly reference `Azure.Identity`.

**Fix:** Add a direct `PackageReference` to `Azure.Identity` 1.21.0 or later. NuGet's [nearest-wins](https://learn.microsoft.com/nuget/concepts/dependency-resolution#nearest-wins) rule ensures your direct reference takes precedence over the transitive one.

```diff
 <ItemGroup>
   <PackageReference Include="Azure.Core" Version="1.53.0" />
+  <PackageReference Include="Azure.Identity" Version="1.21.0" />
 </ItemGroup>
```

## Frequently asked questions

### Do I need to change any `using` directives?

No. All types remain in the `Azure.Identity` namespace. Only the assembly they are compiled into has changed.

### Do I need to change any code?

No. The public API surface is identical. All classes, methods, properties, and constructors have the same signatures.

### Will my existing NuGet packages still work at runtime?

Yes. The `TypeForwardedTo` attributes in the `Azure.Identity` 1.21.0 facade ensure that types serialized or referenced by the old assembly name resolve correctly at runtime.

### I only depend on `Azure.Core`. Can I use `DefaultAzureCredential` without adding `Azure.Identity`?

Yes. Starting with `Azure.Core` 1.53.0, all credential types including `DefaultAzureCredential` are available without an `Azure.Identity` reference.

### Is `Azure.Identity` obsolete?

No. The `Azure.Identity` package is not obsolete and will continue to exist indefinitely as a type-forwarding library. Projects that depend on `Azure.Identity` will continue to work without any changes.

## `Azure.Identity.Broker` compatibility

If your project uses [`Azure.Identity.Broker`](https://www.nuget.org/packages/Azure.Identity.Broker) for brokered authentication (WAM), you must update to **`Azure.Identity.Broker` 1.6.0 or later** when using `Azure.Identity` 1.21.0+ or `Azure.Core` 1.53.0+.

Older versions of `Azure.Identity.Broker` (1.5.0 and earlier) reference internal types that previously lived in the `Azure.Identity` assembly. After the type consolidation, those internal types moved to `Azure.Core`, and older Broker packages cannot resolve them at runtime.

### Symptoms

When attempting brokered authentication, you will see an error such as:

```
TypeLoadException: Could not load type 'Azure.Identity.IMsalSettablePublicClientInitializerOptions'
from assembly 'Azure.Identity, Version=1.21.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8'.
```

This may surface as a connection failure when using libraries like `Microsoft.Data.SqlClient` with `Authentication=ActiveDirectoryDefault`.

### Fix

Update `Azure.Identity.Broker` to 1.6.0 or later:

```diff
 <ItemGroup>
-  <PackageReference Include="Azure.Identity.Broker" Version="1.5.0" />
+  <PackageReference Include="Azure.Identity.Broker" Version="1.6.0" />
 </ItemGroup>
```
