# Reproduction Sample for Issue #58093

**[BUG] Azure.ResourceManager.Sql 1.4.0 GA has breaking dependency jump from 1.4.0-beta.3**

- Issue: https://github.com/Azure/azure-sdk-for-net/issues/58093

## Problem Summary

Azure.ResourceManager.Sql 1.4.0 GA requires `Azure.Core >= 1.52.0` (up from `>= 1.47.1` in 1.4.0-beta.3). This causes a **runtime** `MissingMethodException` on **.NET Framework 4.7.2** when the application's assembly binding redirects are not updated for `System.Diagnostics.DiagnosticSource`.

### The Error

```
System.MissingMethodException: Method not found:
  'Void System.Diagnostics.ActivitySource..ctor(System.String)'.
  at Azure.Core.Pipeline.DiagnosticScopeFactory.<>c.b__11_0(String n)
  at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2)
  at Azure.Core.Pipeline.DiagnosticScopeFactory.CreateScope(String name, ActivityKind kind)
  at Azure.ResourceManager.Resources.ResourceGroupResource.d__18.MoveNext()
```

## Root Cause

The exception originates in [`Azure.Core/src/Shared/DiagnosticScopeFactory.cs`](../../../core/Azure.Core/src/Shared/DiagnosticScopeFactory.cs), line 101:

```csharp
return ActivitySources.GetOrAdd(clientName, static n => new ActivitySource(n));
```

`ActivitySource(string)` was introduced in `System.Diagnostics.DiagnosticSource` 5.0.0. On .NET Framework 4.7.2, this type comes from the NuGet package (not the BCL). If an application's binding redirects point to an older DiagnosticSource version (pre-5.0), the runtime loads an assembly that lacks this constructor, causing `MissingMethodException`.

### Why It Happens After Upgrading

| Package | beta.3 | 1.4.0 GA |
|---------|--------|----------|
| Azure.Core | >= 1.47.1 | >= 1.52.0 |
| Azure.ResourceManager | >= 1.13.2 | >= 1.14.0 |
| DiagnosticSource (transitive) | ~6.x | ~9.x/10.x |

When users upgrade from beta.3 → GA:
1. NuGet resolves the new dependencies at **compile time** → ✅ Build succeeds
2. On .NET Framework, the old binding redirects (from the beta era) still load the old DiagnosticSource assembly at **runtime** → ❌ `MissingMethodException`

**On .NET Core/5+**, `ActivitySource` is part of the BCL, so this issue does **not** occur.

## How to Reproduce

### Prerequisites
- Windows with .NET Framework 4.7.2 installed
- .NET SDK (for building)

### Steps

1. Create a .NET Framework 4.7.2 console app referencing Azure.ResourceManager.Sql 1.4.0:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net472</TargetFramework>
    <AutoGenerateBindingRedirects>false</AutoGenerateBindingRedirects>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Azure.ResourceManager.Sql" Version="1.4.0" />
    <PackageReference Include="Azure.Identity" Version="1.13.2" />
  </ItemGroup>
</Project>
```

2. Add an `App.config` with a **stale** DiagnosticSource binding redirect (simulating what an app built against beta.3 would have):

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Diagnostics.DiagnosticSource"
                          publicKeyToken="cc7b13ffcd2ddd51" culture="neutral" />
        <!-- This version is from the beta.3 era — too old for 1.4.0 GA -->
        <bindingRedirect oldVersion="0.0.0.0-6.0.1.0" newVersion="6.0.1.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>
```

3. Write sample code:

```csharp
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Sql;

var credential = new DefaultAzureCredential();
var armClient = new ArmClient(credential);
var subscription = armClient.GetDefaultSubscription(); // <-- MissingMethodException HERE
```

4. Build → ✅ Succeeds
5. Run → ❌ `MissingMethodException: Method not found: 'Void System.Diagnostics.ActivitySource..ctor(System.String)'`

## Workaround

Update your `App.config` or `Web.config` binding redirect for `System.Diagnostics.DiagnosticSource` to the version required by Azure.Core 1.52.0:

```xml
<dependentAssembly>
  <assemblyIdentity name="System.Diagnostics.DiagnosticSource"
                    publicKeyToken="cc7b13ffcd2ddd51" culture="neutral" />
  <bindingRedirect oldVersion="0.0.0.0-10.0.0.3" newVersion="10.0.0.3" />
</dependentAssembly>
```

If your project uses `<AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>`, do a clean rebuild after upgrading to regenerate the correct redirects.

## Notes

- This issue is **specific to .NET Framework 4.7.2** (and similar legacy frameworks)
- On .NET Core/5/6/7/8+, `ActivitySource` is built into the runtime — no binding redirects are needed
- The build always succeeds — the failure is **runtime-only**, making it hard to catch
