# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of the ASP.NET Core server-side TypeSpec code generator (`@azure-typespec/http-server-csharp-aspnet`), built on the Microsoft.TypeSpec.Generator (MTG) framework.
- Emits one POCO per TypeSpec model under `src/Generated/Models/`, decorated with `[JsonPropertyName]` for `System.Text.Json` interop.
- Emits one abstract `[ApiController]`-annotated `ControllerBase` subclass per TypeSpec interface (and its child clients) under `src/Generated/Controllers/`, with one abstract `Task<ActionResult<T>>` method per operation and `[FromRoute]`/`[FromQuery]`/`[FromHeader]`/`[FromBody]` parameter binding.
- Emits TypeSpec enums and unions as real (extensible) C# enum types, including the required `Argument` helper.
- Preserves wire-level paging envelopes (e.g. `DatabaseListResult`) on operation return types.
- Maps the TypeSpec `unknown` primitive to `System.BinaryData` to preserve non-string payloads.
- Registers ASP.NET Core MVC `MetadataReference`s so Roslyn shortens emitted type names against `using` directives.

### Breaking Changes

### Bugs Fixed

### Other Changes
