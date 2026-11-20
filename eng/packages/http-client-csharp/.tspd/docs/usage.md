### Prerequisite

- Install [Node.js](https://nodejs.org/download/) 20 or above. (Verify by running `node --version`)
- Install [**.NET 10.0 SDK**](https://dotnet.microsoft.com/download/dotnet/10.0) for your specific platform. (or a higher version within the 10.0.* band)

### Customizing Generated Code

For detailed instructions on how to customize the generated C# code, see the [Customization Guide](https://github.com/microsoft/typespec/blob/main/packages/http-client-csharp/.tspd/docs/customization.md).

### Long-running operation status metadata

TCGC `@lroStatusMetadata` selects properties of an LRO's status-monitor model. By default this adds no public API: the convenience methods keep returning `Operation<T>` or `Operation`, and at runtime they return an internal generated `{Method}Operation` subclass. That subclass has one property per selected field, named and typed like the status model's own property (for example `CreatedOn`, `LastUpdatedOn`, `Statistics`, `Errors` or `Usage`). Values come from the latest status-monitor response, including failed and canceled polls, and refresh on every poll. Each response is deserialized once with the status model's generated deserializer. A response that cannot be deserialized returns null for every property, and the getters never throw. A missing value returns null, except that a required value-type property follows the generated model and returns its default. Metadata is not stored in the rehydration token.

To expose the operation as a public type, add a partial class that renames it with `[CodeGenType]` and declares it public. The convenience methods then return that type:

```csharp
[CodeGenType("StartTranslationOperation")]
public partial class DocumentTranslationOperation
{
}
```

Protocol methods keep their standard return types. Paged LROs with status metadata are not supported.
