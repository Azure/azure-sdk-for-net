# List of diagnostics produced by Azure.SdkAnalyzers

## Unsuppressible Rules (Error severity)

These rules enforce internal implementation correctness and cannot be disabled via `#pragma`, `<NoWarn>`, or `.editorconfig`. They exist to prevent deadlocks, threading issues, and other runtime problems in Azure SDK libraries.

### AZC0013

**Use TaskCreationOptions.RunContinuationsAsynchronously when instantiating TaskCompletionSource**

| Property | Value |
|----------|-------|
| **Severity** | Error |
| **Suppressible** | No |

#### Cause

A `TaskCompletionSource<T>` is created without `TaskCreationOptions.RunContinuationsAsynchronously`, which can cause deadlocks and thread starvation.

#### How to fix violation

```diff
- var tcs = new TaskCompletionSource<string>();
+ var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
```

See [AZC0013 documentation](AZC0013.md) for details.

---

### AZC0101

**Do not use ConfigureAwait(true)**

| Property | Value |
|----------|-------|
| **Severity** | Error |
| **Suppressible** | No |
| **Code fix** | Yes |

#### Cause

An awaitable expression uses `ConfigureAwait(true)` instead of `ConfigureAwait(false)`.

#### How to fix violation

Replace `true` with `false`. A code fix is available:

```diff
- await task.ConfigureAwait(true);
+ await task.ConfigureAwait(false);
```

See [AZC0101 documentation](AZC0101.md) for details.

---

### AZC0108

**Incorrect 'async' parameter value**

| Property | Value |
|----------|-------|
| **Severity** | Error |
| **Suppressible** | No |

#### Cause

A `bool async` method is called with the wrong literal value — `false` in async scope or `true` in sync scope.

#### How to fix violation

Pass the correct literal or forward the `async` parameter:

```diff
  if (async)
  {
-     await BarAsync(false).ConfigureAwait(false);
+     await BarAsync(async).ConfigureAwait(false);
  }
```

See [AZC0108 documentation](AZC0108.md) for details.

---

### AZC0109

**Misuse of 'async' parameter**

| Property | Value |
|----------|-------|
| **Severity** | Error |
| **Suppressible** | No |

#### Cause

The `bool async` parameter is assigned, read into a variable, or combined with other conditions instead of being used as an exclusive branch condition.

#### How to fix violation

Use `async` only as the sole condition in `if`/`else` or `? :`:

```diff
- if (async && someCondition) { ... }
+ if (async) { ... }
```

See [AZC0109 documentation](AZC0109.md) for details.

---

### AZC0111

**Do not use EnsureCompleted in possibly asynchronous scope**

| Property | Value |
|----------|-------|
| **Severity** | Error |
| **Suppressible** | No |

#### Cause

`EnsureCompleted()` is called in a method with `bool async` parameter outside of a guaranteed sync scope (`if (!async) { ... }`).

#### How to fix violation

Move the call inside a sync-guarded block:

```diff
- task.EnsureCompleted();
+ if (!async) { task.EnsureCompleted(); }
+ else { await task.ConfigureAwait(false); }
```

See [AZC0111 documentation](AZC0111.md) for details.

---

## Suppressible Rules (Warning severity)

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
