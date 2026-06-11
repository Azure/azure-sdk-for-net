# List of diagnostics produced by Azure.SdkAnalyzers

## AZC0101

### Cause

An awaitable expression uses `ConfigureAwait(true)` instead of `ConfigureAwait(false)`.

### How to fix violation

Replace `true` with `false`. A code fix is available:

```diff
- await task.ConfigureAwait(true);
+ await task.ConfigureAwait(false);
```

See AZC0101 documentation for details.

## AZC0012

### Cause

Public types (classes, interfaces, or structs) in Azure SDK namespaces use single-word names, which are too generic and have a high chance of collision with BCL types or types from other libraries.

### How to fix violation

Use descriptive multi-word names for public types. Add a prefix or suffix that describes the purpose or domain of the type.

### Example of a violation

#### Description

The following code defines a public class with a single-word name `Format`, which causes a violation of AZC0012.

#### Code

```c#
namespace Azure.Data.Tables
{
    public class Format { } // This will cause AZC0012
}
```

### Example of how to fix

#### Description

Add a descriptive prefix to make the type name more specific and avoid collisions. Common patterns include adding the service name (e.g., `TableFormat`, `BlobFormat`) or functionality (e.g., `TableDataFormat`).

#### Code

```diff
namespace Azure.Data.Tables
{
-   public class Format { } // This will cause AZC0012
+   public class TableDataFormat { }
}
```

### Additional examples

```c#
// ❌ Avoid single-word names
public class Manager { }
public interface IService { }
public struct Options { }

// ✅ Use descriptive multi-word names
public class TableManager { }
public interface ITableService { }
public struct TableClientOptions { }
```

### Notes

- This analyzer only checks public types in Azure SDK namespaces (namespaces starting with `Azure.` except `Azure.Core.*`)
- Interface names starting with 'I' have the prefix ignored when counting words (e.g., `IClient` is considered single-word)
- Nested types are not analyzed

## AZC0020

### Cause

A method that accepts a `CancellationToken` parameter calls an Azure SDK API with a `RequestContext` parameter, but does not propagate the cancellation token to the `RequestContext`.

### How to fix violation

Set the `CancellationToken` property on the `RequestContext` object to the incoming cancellation token.

### Example of a violation

#### Description

The following code defines a method that accepts a `CancellationToken` but does not propagate it to the `RequestContext` when calling an Azure SDK API.

#### Code

```c#
public async Task UpdateAsync(CancellationToken cancellationToken)
{
    // ❌ CancellationToken is accepted but not propagated
    await client.UpdateAsync(
        content,
        new RequestContext()); // cancellationToken is dropped
}
```

### Example of how to fix

#### Description

Set the `CancellationToken` property on the `RequestContext` to ensure proper cancellation support.

#### Code

```diff
public async Task UpdateAsync(CancellationToken cancellationToken)
{
-   await client.UpdateAsync(
-       content,
-       new RequestContext()); // cancellationToken is dropped
+   await client.UpdateAsync(
+       content,
+       new RequestContext
+       {
+           CancellationToken = cancellationToken
+       });
}
```

### Additional examples

```c#
// ❌ Avoid dropping cancellation tokens
public async Task BadAsync(CancellationToken token)
{
    await client.UpdateAsync(content, new RequestContext());
    await client.DeleteAsync(id, new RequestContext { ErrorOptions = ErrorOptions.Default });
}

// ✅ Propagate cancellation tokens
public async Task GoodAsync(CancellationToken token)
{
    await client.UpdateAsync(content, new RequestContext { CancellationToken = token });
    await client.DeleteAsync(id, new RequestContext 
    { 
        CancellationToken = token,
        ErrorOptions = ErrorOptions.Default 
    });
}
```

### Notes

- This analyzer only reports diagnostics when calling Azure SDK APIs (methods in the `Azure` namespace)
- The analyzer does not report diagnostics when a `RequestContext` is passed from a parameter or local variable
- The analyzer works with lambda expressions and anonymous functions
- Setting `CancellationToken` to `CancellationToken.None` or `default` when a cancellation token parameter is available will still trigger a warning

## AZC0040

### Cause

A public or protected API member in an Azure SDK namespace exposes a type from the `Apache.Arrow` library (a type in the `Apache.Arrow` namespace or one of its child namespaces).

### How to fix violation

Keep `Apache.Arrow` types internal and expose abstractions owned by the SDK instead, converting to and from `Apache.Arrow` types behind the scenes.

### Example of a violation

#### Description

The following code exposes `Apache.Arrow.Table` as the return type of a public method, which causes a violation of AZC0040.

#### Code

```c#
using Apache.Arrow;

namespace Azure.Data.Analytics
{
    public class AnalyticsClient
    {
        public Table GetTable() => null; // This will cause AZC0040
    }
}
```

### Example of how to fix

#### Description

Replace the `Apache.Arrow` type with a type owned by the SDK.

#### Code

```diff
namespace Azure.Data.Analytics
{
    public class AnalyticsClient
    {
-       public Apache.Arrow.Table GetTable() => null; // This will cause AZC0040
+       public BinaryData GetTable() => null;
    }
}
```

### Notes

- This analyzer only checks public and protected members of public types in Azure SDK namespaces (namespaces starting with `Azure.` except `Azure.Core.*`). `protected internal` members are included; `private protected` and `internal` members are not
- A type is treated as an `Apache.Arrow` type when its containing namespace is `Apache.Arrow` or begins with `Apache.Arrow.`
- Return types, parameter types, property types, field types, event types, base types, implemented interfaces, generic type arguments, array element types, and generic type parameter constraints are all analyzed
