# Guidelines: Target Frameworks in Azure SDK for .NET

This document describes how this repository implements the
[Target Frameworks](https://azure.github.io/azure-sdk/dotnet_introduction.html#target-frameworks)
section of the .NET Azure SDK design guidelines: which frameworks packages and
tests target, when they change, and what to update when they do. Where the
timing here differs from
[Target Framework Retirement](https://azure.github.io/azure-sdk/dotnet_introduction.html#target-framework-retirement),
this document takes precedence for this repository.

## Background

.NET ships a new major version every November as either a long-term support
(LTS) or a standard-term support (STS) release. The
[.NET support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-core)
lists each release's type and end-of-support date. End of support is also
called end of life (EOL).

## Package targets

| Packages | Required targets |
|----------|------------------|
| Libraries (`SupportsNetStandard20`, on by default for `Azure.*` projects) | `netstandard2.0` and the current LTS |
| Core packages: Azure.Core, System.ClientModel, and Azure.Core.Experimental | `netstandard2.0` and every supported LTS, each until 6 months after it reaches end of support |
| Packages that must target a runnable framework, such as ASP.NET Core extensions and the Azure.AI.AgentServer hosts | Every supported LTS, each until 6 months after it reaches end of support |
| Analyzers and source generators | `netstandard2.0` only |
| Code generator projects (`IsGeneratorLibrary`) | The current LTS only |

- ✅ **DO** adopt a new LTS as soon as it ships and the CI agent images include
  its SDK (see [CI agent images](#ci-agent-images)). It becomes the current LTS
  for every package, and packages that target every supported LTS also keep the
  outgoing LTS. For example, when .NET 12 ships, libraries move from `net10.0` to
  `net12.0`, and Core packages move from `net10.0` to `net12.0` and `net10.0`.
- ✅ **YOU MAY** add another supported framework, LTS or STS, to a package when
  the benefit justifies it, such as using an API from that release or opting in
  to runtime performance improvements that only apply to code targeting it. For
  example, System.ClientModel targets `net9.0` so `JsonPatch` can look up keys
  by `ReadOnlySpan<byte>` with `Dictionary<TKey, TValue>.GetAlternateLookup`.
- ✅ **DO** remove a framework from package targets 6 months after it reaches
  end of support. For example, .NET 8 and .NET 9 reach end of support in
  November 2026, so Core packages drop `net8.0` and System.ClientModel drops
  `net9.0` in May 2027.
- ❌ **DO NOT** add repository-wide package targets when an STS ships.
- ❌ **DO NOT** use `AllActiveCurrentTargetFrameworks` in a packable project. It
  holds the test targets, which include STS versions that packages don't
  target. Use `RequiredTargetFrameworks` or `RequiredRunnableTargetFrameworks`.

## Test targets

Every framework a package targets is tested. Test, sample, perf, and stress
projects under `sdk/` run on every .NET version that is still in support or
still in a package's targets, plus `NetFxTargetFramework` on Windows: the
earliest .NET Framework version that is still in support or still in a
package's targets. Every CI test matrix covers the same set.

- ✅ **DO** add each new .NET version, LTS or STS, to the test targets when it
  ships.
- ✅ **DO** keep a framework in the test targets until it is out of support and
  no package targets it. Remove it in the change that removes its last package
  target, or, if no package targets it, in the change that adds the next .NET
  version.
- ✅ **DO** keep `AllActiveCurrentTargetFrameworks` built on
  `$(RequiredRunnableTargetFrameworks)` so repository-wide package targets are
  always tested. List any other framework a package still targets, such as
  System.ClientModel's `net9.0` until May 2027, explicitly.
- ✅ **DO** move `NetFxTargetFramework` to the next .NET Framework version once
  the current one is out of support and no package targets it.
- ✅ **DO** target only the current LTS in standalone samples under `/samples`.
  They don't import the repository's build properties, so they name the
  framework directly.

Known gap: Azure.Core targets `net472`, but CI runs .NET Framework tests only on
`NetFxTargetFramework`. See
[#64956](https://github.com/Azure/azure-sdk-for-net/issues/64956).

### When tests fail on a new framework

- ✅ **DO** fix the failure in the same change: in the product code when
  customers on that framework would hit it, or in the test when the behavior
  correctly differs by framework.
- ✅ **DO** file an issue when a failure can't be fixed in the change, and skip
  the test on that framework only, with the issue in the skip reason:

  ```csharp
  #if NET11_0
      Assert.Ignore("https://github.com/Azure/azure-sdk-for-net/issues/<number>");
  #endif
  ```

- ❌ **DO NOT** skip a test on every framework, delete it, or remove the
  framework from a test project to get the change passing.

## Timeline

How targets change over the next four releases:

| Release | Libraries | Core packages | Tests |
|---------|-----------|---------------|-------|
| .NET 11 (STS), Nov 2026 | `net10.0`, `net8.0` until May 2027 | `net10.0`, `net8.0` until May 2027 | `net10.0`, `net11.0`, `net8.0` until May 2027 |
| .NET 12 (LTS), Nov 2027 | `net12.0` | `net12.0`, `net10.0` | `net10.0`, `net11.0`, `net12.0` |
| .NET 13 (STS), Nov 2028 | `net12.0` | `net12.0`, `net10.0` until May 2029 | `net12.0`, `net13.0`, `net10.0` until May 2029 |
| .NET 14 (LTS), Nov 2029 | `net14.0` | `net14.0`, `net12.0` | `net12.0`, `net13.0`, `net14.0` |

Libraries and Core packages also target `netstandard2.0`, and tests also run on
.NET Framework on Windows. Package-specific targets are not shown; tests cover
them for as long as they ship.

## global.json

- ✅ **DO** move `sdk.version` in `global.json` to the new version's SDK in the
  same change that adds a framework to package or test targets. An SDK can't
  build a framework newer than itself, so this happens for every release, STS
  included.
- ✅ **DO** update the SDK version in `CONTRIBUTING.md` and `AGENTS.md` in the
  same change.
- ❌ **DO NOT** restate the SDK version that builds this repository in other
  docs. Link to `global.json` instead.

## CI agent images

- ❌ **DO NOT** merge a change that adds a framework or moves `global.json` to a
  new SDK until the CI agent images include that SDK. These are the
  `azsdk-pool` Ubuntu and Windows images and the hosted macOS image, set in
  `eng/pipelines/templates/variables/image.yml`.
- ✅ **DO** merge the change promptly once the images include the SDK.
- ✅ **DO** open the pull request as a draft when an agent prepares the change,
  and note in the description that a person still needs to confirm the images.

## Checklist

When a new .NET version ships:

1. `global.json`: move `sdk.version` to the new SDK, and update the SDK version
   in `CONTRIBUTING.md` and `AGENTS.md`.
2. `eng/Directory.Build.Common.props`: add the new version to
   `AllActiveCurrentTargetFrameworks`, and remove versions that leave the test
   targets. For an LTS, also update `LtsTargetFramework`, keep the outgoing LTS
   for packages that target every supported LTS, and update
   `ApiCompatRunnableTargetFramework`, which must be a framework that
   already-released packages contain.
3. Check each project that uses a property you changed. For each packable one,
   confirm that `dotnet msbuild <project> -getProperty:TargetFrameworks` still
   matches [Package targets](#package-targets).

   ```
   git grep -n -E 'AllActiveCurrentTargetFrameworks|RequiredRunnableTargetFrameworks|LtsTargetFramework|NetFxTargetFramework' -- '*.csproj' '*.props' '*.targets'
   ```

4. `eng/pipelines/templates/stages/platform-matrix.json`: add a
   `TestTargetFramework` entry for the new version on every OS, and remove
   entries for versions that leave the test targets. For an LTS, move the
   `Coverage_Record` entry to it. Update the service-specific matrices
   (`git grep -l TestTargetFramework -- sdk`) the same way, unless a matrix
   deliberately runs fewer frameworks, such as the LTS-only
   `sdk/tools/platform-generator-matrix.json`.
5. `eng/pipelines/templates/steps/install-dotnet.yml`: install an SDK for each
   test framework older than the `global.json` SDK.
6. `eng/centralpackagemanagement/`: add and remove versions conditioned on a
   test framework, such as `Microsoft.AspNetCore.Mvc.Testing`. Leave versions
   conditioned on a package target, such as
   `Microsoft.AspNetCore.DataProtection` for `net8.0`, until that target is
   removed.
7. For each framework that leaves the test targets, find what else hard-codes
   it (see [Finding hard-coded frameworks](#finding-hard-coded-frameworks)).
8. Update API listings (`api/<Package>.<framework>.cs`) for packages whose
   targets changed. `eng/scripts/Export-API.ps1` generates listings for added
   frameworks but leaves listings for removed frameworks in place, so delete
   those. For .NET 10, the new listings were added in follow-up PRs:
   [#54412](https://github.com/Azure/azure-sdk-for-net/pull/54412) for Core and
   [#54952](https://github.com/Azure/azure-sdk-for-net/pull/54952) for all
   libraries.
9. When the BCL package versions move to the new major, move the framework in
   the built-in package removal in `eng/Directory.Build.Common.targets` to
   match.
10. Run the tests on the new framework, and handle failures as described in
    [When tests fail on a new framework](#when-tests-fail-on-a-new-framework).

Six months after a version reaches end of support:

1. Remove its package targets: the retired LTS in
   `eng/Directory.Build.Common.props`, and package-specific targets such as
   System.ClientModel's `net9.0`.
2. In the same change, remove it from the test targets by following steps 2
   through 6 above. For a .NET Framework version, move `NetFxTargetFramework`.
3. Delete the API listings for the removed framework.
4. Find what else hard-codes it (see
   [Finding hard-coded frameworks](#finding-hard-coded-frameworks)).

## Finding hard-coded frameworks

Search for the framework and its SDK, replacing `8` with the version. For a
.NET Framework version, search for its moniker, such as `net462`.

```
git grep -n -E 'net8\.0|8\.0\.x|/(sdk|aspnet|runtime):8\.0|\.NET 8(\.0)? SDK' -- . ':!**/api/*.cs' ':!**/CHANGELOG.md' ':!**/SessionRecords/**'
```

For each hit:

- Leave package targets, and conditions on a framework that packages still
  target.
- Update test, sample, perf, and stress projects, CI matrices, scripts,
  Dockerfiles, and docs. Scripts and tools that need a single framework use the
  current LTS.
- Reword comments that list frameworks so they don't name versions, for example
  "the LTS framework", instead of updating the numbers.
- Make changes to files under `eng/common` in
  [Azure/azure-sdk-tools](https://github.com/Azure/azure-sdk-tools), which that
  directory is synced from.
