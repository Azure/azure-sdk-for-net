# List of diagnostics produced by Azure.SdkAnalyzers

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
