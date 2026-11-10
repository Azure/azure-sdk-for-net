# Guidelines: Target Frameworks in Azure SDK for .NET

This document describes how this repository implements the
[Target Frameworks](https://azure.github.io/azure-sdk/dotnet_introduction.html#target-frameworks)
section of the .NET Azure SDK design guidelines: which frameworks packages and
tests target, when they change, and what to update when they do. Where the
timing here differs from
[Target Framework Retirement](https://azure.github.io/azure-sdk/dotnet_introduction.html#target-framework-retirement),
this document takes precedence for this repository.

## Background

.NET ships a major version every November. Even-numbered versions are long-term
support (LTS, 3 years) and odd-numbered versions are standard-term support (STS,
2 years), per the
[.NET support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core).
As a result, older versions reach end of support only when an STS ships: .NET 8
and .NET 9 both reach end of support as .NET 11 ships.

## Package targets

| Packages | Targets |
|----------|---------|
| Libraries (`SupportsNetStandard20`, on by default for `Azure.*` projects) | `netstandard2.0` and the current LTS |
| Core packages: Azure.Core, System.ClientModel, and Azure.Core.Experimental | `netstandard2.0`, the current LTS, and the previous LTS |
| Analyzers and source generators | `netstandard2.0` only |
| Code generator projects (`IsGeneratorLibrary`) | The current LTS only |

- ✅ **DO** adopt a new LTS as soon as it ships and the CI agent images include
  its SDK (see [CI agent images](#ci-agent-images)). Add it as a target, and
  drop every `netX.0` target older than the oldest LTS the package keeps. For
  example, when .NET 12 ships, libraries move from `net10.0` to `net12.0`. Core
  packages move from `net10.0` and `net8.0` to `net12.0` and `net10.0`, and
  System.ClientModel drops its `net9.0` target.
- ❌ **DO NOT** change repository-wide package targets when an STS ships.

### STS targets

- ✅ **YOU MAY** add an STS target to a package whose code uses an API that
  first shipped in that release. For example, System.ClientModel targets
  `net9.0` so `JsonPatch` can look up keys by `ReadOnlySpan<byte>` with
  `Dictionary<TKey, TValue>.GetAlternateLookup`.
- ❌ **DO NOT** add an STS target only for runtime performance. Apps get runtime
  improvements from the runtime they run on, whatever framework a package
  targets.

An STS target is dropped by the LTS rule above, like any other `netX.0` target.

## Test targets

Test, sample, perf, and stress projects run on every .NET version still in
support, plus .NET Framework (`NetFxTargetFramework`) on Windows. The CI test
matrix covers the same set.

- ✅ **DO** add each new .NET version, LTS or STS, to the test targets when it
  ships.
- ✅ **DO** remove versions that have reached end of support in the same change.

Core packages keep shipping the previous LTS, and any older STS targets, for a
year after those versions leave the test targets. That gap is expected.

## Timeline

How targets change over the next four releases:

| Release | Libraries | Core packages | Tests |
|---------|-----------|---------------|-------|
| .NET 11 (STS), Nov 2026 | `net10.0` | `net10.0`, `net8.0` | `net10.0`, `net11.0` |
| .NET 12 (LTS), Nov 2027 | `net12.0` | `net12.0`, `net10.0` | `net10.0`, `net11.0`, `net12.0` |
| .NET 13 (STS), Nov 2028 | `net12.0` | `net12.0`, `net10.0` | `net12.0`, `net13.0` |
| .NET 14 (LTS), Nov 2029 | `net14.0` | `net14.0`, `net12.0` | `net12.0`, `net13.0`, `net14.0` |

All packages also target `netstandard2.0`, and tests also run on .NET Framework
on Windows. Package-specific STS targets are not shown.

## global.json

- ✅ **DO** move `sdk.version` in `global.json` to the new version's SDK in the
  same change that adds a framework to package or test targets. An SDK can't
  build a framework newer than itself, so this happens for every release, STS
  included.

## CI agent images

- ❌ **DO NOT** merge a change that adds a framework or moves `global.json` to a
  new SDK until the CI agent images include that SDK. These are the
  `azsdk-pool` Ubuntu and Windows images and the hosted macOS image, set in
  `eng/pipelines/templates/variables/image.yml`.
- ✅ **DO** make the change promptly once the images include the SDK.

## Checklist

Once the agent images include the new SDK:

1. `global.json`: move `sdk.version` to the new SDK.
2. `eng/Directory.Build.Common.props`: update `AllActiveCurrentTargetFrameworks`
   for the test targets. For an LTS, also update `LtsTargetFramework`, the
   previous LTS that Core packages target, and `ApiCompatRunnableTargetFramework`,
   which must be a framework that already-released packages contain.
3. `eng/pipelines/templates/stages/platform-matrix.json`: add and remove
   `TestTargetFramework` entries for every OS. For an LTS, move the
   `Coverage_Record` entry to it.
4. `eng/pipelines/templates/steps/install-dotnet.yml`: install an SDK for each
   test framework older than the `global.json` SDK.
5. `eng/centralpackagemanagement/`: update package versions conditioned on a
   framework, such as `Microsoft.AspNetCore.Mvc.Testing`.
6. Search the repo for the old framework and SDK (for example `net8.0` and
   `8.0.x`) to catch scripts, samples, and tools that hard-code them.
7. For an LTS, regenerate API listings (`api/<Package>.<framework>.cs`) with
   `eng/scripts/Export-API.ps1`. For .NET 10 this was done in follow-up PRs:
   [#54412](https://github.com/Azure/azure-sdk-for-net/pull/54412) for Core and
   [#54952](https://github.com/Azure/azure-sdk-for-net/pull/54952) for all
   libraries.
8. When the BCL package versions move to the new major, move the framework in
   the built-in package removal in `eng/Directory.Build.Common.targets` to
   match.
