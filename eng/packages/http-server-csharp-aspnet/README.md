# @azure-typespec/http-server-csharp-aspnet

TypeSpec emitter that generates ASP.NET Core server-side code (POCO models and
abstract controller bases) from a TypeSpec service definition.

> **Status:** experimental / pre-alpha. The package currently emits POCO models
> and abstract controller base classes. Versioning, polymorphic discriminators,
> paging helpers, and validation attributes are not yet implemented.

## Install

```bash
npm install @azure-typespec/http-server-csharp-aspnet
```

## Emitter usage

```bash
tsp compile . --emit=@azure-typespec/http-server-csharp-aspnet
```

Or via `tspconfig.yaml`:

```yaml
emit:
  - "@azure-typespec/http-server-csharp-aspnet"
```

## What gets generated

For each TypeSpec model: a POCO under `src/Generated/Models/`. For each TypeSpec
interface (client): an abstract `<Name>ControllerBase : ControllerBase` under
`src/Generated/Controllers/` decorated with `[ApiController]` and one abstract
`Task<ActionResult<T>> <Name>Async(...)` method per operation. Method parameters
carry `[FromRoute]`/`[FromQuery]`/`[FromHeader]`/`[FromBody]` binding attributes
that mirror the TypeSpec `@path`/`@query`/`@header`/`@body` decorators.

Service authors derive a concrete controller from the generated base and provide
the implementation. The generated files are owned by the emitter and overwritten
on regeneration; hand-written controllers live in separate files and are never
touched.

## Layout

- `emitter/` — TypeScript shim that runs inside `tsp compile`. Serializes the
  TypeSpec program to `tspCodeModel.json` and launches the .NET generator.
- `generator/` — The .NET generator
  (`Microsoft.TypeSpec.Generator.AspNetServer`). Subclasses
  `CodeModelGenerator` and produces `.cs` files via the Microsoft.TypeSpec.Generator
  Roslyn-based code writer. Includes a `Microsoft.TypeSpec.Generator.runtimeconfig.json`
  that loads both `Microsoft.NETCore.App` and `Microsoft.AspNetCore.App` so the
  generator can reference `[ApiController]`, `ControllerBase`, `[Http*]`, and
  `[From*]` types directly.
- `docs/` — Design rationale: how the generated code is structured and why
  the generated/hand-written split looks the way it does.

## Building

```bash
npm install
npm run build
```

## Regenerating the test project

```bash
./eng/scripts/Generate.ps1
```

Drives `tsp compile` against `generator/TestProjects/Local/AzureSql/main.tsp` and
then builds the generated output, end to end.

