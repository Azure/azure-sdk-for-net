# Azure SDK Analyzers

Roslyn analyzers that enforce [Azure SDK Design Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) for .NET library authors.

This package is automatically included in all Azure SDK libraries in this repository to ensure consistent code quality and adherence to Azure SDK conventions.

## Implemented Rules

### Unsuppressible (Error severity)

These rules enforce internal implementation correctness and **cannot be suppressed** via `#pragma`, `<NoWarn>`, or `.editorconfig`.

| Rule | Description | Fix |
|------|-------------|-----|
| [**AZC0013**](docs/AZC0013.md) | Use `TaskCreationOptions.RunContinuationsAsynchronously` | ✅ |
| [**AZC0101**](docs/AZC0101.md) | Do not use `ConfigureAwait(true)` | ✅ |
| [**AZC0108**](docs/AZC0108.md) | Incorrect `async` parameter value | ✅* |
| [**AZC0109**](docs/AZC0109.md) | Misuse of `async` parameter | — |
| [**AZC0111**](docs/AZC0111.md) | Do not use `EnsureCompleted` in possibly async scope | — |

\* Fix only offered when containing method has a `bool async` parameter to forward.

### Suppressible (Warning severity)

| Rule | Description | Fix |
|------|-------------|-----|
| [**AZC0012**](docs/list-of-diagnostics.md#azc0012) | Avoid single word type names | ✅ |
| [**AZC0020**](docs/AZC0020.md) | Propagate CancellationToken to RequestContext | ✅ |

## For Library Authors

These analyzers run automatically during build. Unsuppressible rules produce errors that must be fixed — they prevent deadlocks and threading issues that are difficult to diagnose at runtime. Review the [list of diagnostics](docs/list-of-diagnostics.md) for detailed guidance on each rule.
