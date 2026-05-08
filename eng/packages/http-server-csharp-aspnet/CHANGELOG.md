# Change Log - @azure-typespec/http-server-csharp-aspnet

## 1.0.0-beta.1 (Unreleased)

### Features Added

Initial release of the ASP.NET Core server-side code generator for TypeSpec, built on the
Microsoft.TypeSpec.Generator (MTG) framework.

- TypeSpec emitter (`@azure-typespec/http-server-csharp-aspnet`) that delegates to the upstream
  Microsoft.TypeSpec emitter and forwards configuration to the .NET generator.
- .NET generator (`Microsoft.TypeSpec.Generator.AspNetServer`) exported via MEF as a
  `CodeModelGenerator`, with an `AspNetServerCodeModelGenerator` entry point, an
  `AspNetServerOutputLibrary`, and an `AspNetServerTypeFactory`.
- Model emission: one POCO per TypeSpec model under `src/Generated/Models/`, decorated with
  `[JsonPropertyName(...)]` so ASP.NET Core's built-in `System.Text.Json` serializer preserves
  the wire-format property names. All properties are emitted with `{ get; set; }` so service
  authors can populate response models regardless of the source `@visibility`.
- Controller emission: one abstract `ControllerBase` subclass per TypeSpec interface (and its
  child clients) under `src/Generated/Controllers/`, decorated with `[ApiController]` and one
  abstract `Task<ActionResult<T>>` method per operation. Parameters are bound with
  `[FromRoute]`, `[FromQuery]`, `[FromHeader]`, and `[FromBody]` based on the TypeSpec
  parameter location; content-negotiation headers (`Accept`, `Content-Type`) are skipped.
- Operation return types use the wire-level response body (e.g. `DatabaseListResult`) rather
  than the TCGC-flattened item collection, so paging envelopes are preserved.
- Enum emission: TypeSpec enums and unions are emitted as real (extensible) C# enum types
  under `src/Generated/Models/`, registered alongside models in the output library; the
  required `Argument` helper is also emitted.
- Type mapping: TypeSpec primitives map to the corresponding BCL types; unknown primitive
  kinds fall back to `System.Text.Json.JsonElement` (the idiomatic ASP.NET Core unknown-payload
  type) instead of `string`, preserving non-string payloads such as `ErrorAdditionalInfo.info`.
- Roslyn post-processing: the generator registers `MetadataReference`s for ASP.NET Core MVC
  assemblies so the framework's `Simplifier` shortens emitted type names against the matching
  `using` directives (e.g. `Microsoft.AspNetCore.Mvc.ControllerBase` → `ControllerBase`).
- End-to-end test project under `generator/TestProjects/Local/AzureSql` that exercises the
  emitter and generator against a real ARM TypeSpec sample and is built as part of
  `Generate.ps1`.
