# @azure-typespec/http-server-csharp-aspnet

TypeSpec library for emitting ASP.NET Core server-side code for C#.

> **Status:** experimental / pre-alpha. This package is the initial scaffold of the
> server-side code generator built on the
> [Microsoft.TypeSpec.Generator (MTG)](https://github.com/microsoft/typespec/tree/main/packages/http-client-csharp)
> framework. The current version emits a single hello-world C# file; real outputs
> (controllers, models, version registry) will be added in subsequent PRs.

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

## Layout

- `emitter/` — TypeScript shim that runs inside `tsp compile`. It serializes the
  TypeSpec program to a code model and hands it to the .NET generator subprocess.
- `generator/` — The C# generator (`Microsoft.TypeSpec.Generator.AspNetServer`).
  Subclasses `CodeModelGenerator` directly and produces `.cs` files via the
  Roslyn-based code writer.

## Building

```bash
npm install
npm run build
```
