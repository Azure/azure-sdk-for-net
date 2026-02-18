# Central Package Management (CPM)

This directory contains the central NuGet package version definitions for the
azure-sdk-for-net repository. Every project in the repo resolves its
`PackageReference` versions from these files — individual `.csproj` files should
**not** specify `Version` attributes.

## Per-Package Overrides

Override files serve two purposes:

- **Library-specific dependencies** — packages conditionally approved by a
  .NET architect for a single library, not for repo-wide use. Dependencies
  intended for broad use should instead be added to the appropriate central
  file (e.g. `Directory.Packages.props`, `Directory.Support.Packages.props`).

  > **⚠ Library-specific dependencies require explicit approval from a .NET architect.**

- **Version overrides of standard dependencies** — a different version of a
  package already in the central files. Packages should use the standard
  central version whenever possible. Version overrides are short-lived and must
  have a corresponding GitHub issue tracking their removal.

When approved, follow these steps to add an override for your package:

1. **Create the override file** in the `overrides/` subdirectory. The filename
   **must** follow the convention `<PackageName>.Packages.props` (case sensitive):

   ```
   eng/centralpackagemanagement/overrides/Azure.MyService.Packages.props
   ```

2. **Add your `PackageVersion` items** inside the file:

   ```xml
   <Project>
     <ItemGroup>
       <PackageVersion Include="Some.Dependency" Version="3.1.0" />
     </ItemGroup>
   </Project>
   ```

   Scope dependencies to tests, samples, or perf projects with a condition so
   they don't leak into the main library:

   ```xml
   <Project>
     <ItemGroup Condition="'$(IsTestProject)' == 'true'">
       <PackageVersion Include="Some.TestOnly.Dependency" Version="2.0.0" />
     </ItemGroup>
   </Project>
   ```

   Available conditions: `IsTestProject`, `IsSamplesProject`, `IsPerfProject`,
   `IsStressProject`, `IsTestSupportProject`, `IsToolProject`. You can combine them:

   ```xml
   <ItemGroup Condition="'$(IsTestProject)' == 'true' or '$(IsSamplesProject)' == 'true'">
   ```

3. **That's it.** The build system auto-imports override files by matching on
   `$(MSBuildProjectName)`. If your project is `Azure.MyService`, the file
   `Azure.MyService.Packages.props` is imported automatically — no changes to
   your `.csproj` or `Directory.Build.props` are needed.

   For test, perf, and sample projects (`Azure.MyService.Tests`,
   `Azure.MyService.Perf`, `Azure.MyService.Samples`), the build system strips
   the suffix and falls back to the base package's override file, so a single
   override file covers the whole project family.

---

## CPM Compliance Checks

The repository enforces CPM policy at two levels:

- **Build-time** — an MSBuild target (`EnforceCentralPackageManagement`) in
  `Directory.Build.targets` that emits `AZSDK0001` errors.
- **CI static analysis** — a PowerShell script
  (`eng/scripts/Validate-CpmCompliance.ps1`) that scans for policy violations
  before build.

### Error Reference

#### AZSDK0001 — `CentralPackageVersionOverrideEnabled='true'`

```
error AZSDK0001: Package version overrides are disabled in this repository.
Do not set CentralPackageVersionOverrideEnabled='true'.
```

**Cause:** A project or props file sets `CentralPackageVersionOverrideEnabled`
to `true`, which re-enables the NuGet `VersionOverride` attribute repo-wide.

**Fix:** Remove the property. If your package needs a specific version of a
dependency, create a per-package override file in `overrides/` (see above).

---

#### AZSDK0001 — `ManagePackageVersionsCentrally='false'`

```
error AZSDK0001: Central Package Management is required in this repository.
Do not set ManagePackageVersionsCentrally='false'.
```

**Cause:** A project or props file disables CPM entirely.

**Fix:** Remove the `ManagePackageVersionsCentrally` property from your project
or `Directory.Build.props`. All package versions should come from the central
`Directory.Packages.props` (or a per-package override file).

---

#### CPM-001 — `ManagePackageVersionsCentrally='false'` outside allowlist

Same root cause as AZSDK0001 above, but caught by the CI script rather than
MSBuild. Same fix applies.

---

#### CPM-002 — `CentralPackageVersionOverrideEnabled='true'`

Same root cause as AZSDK0001 above, caught by the CI script. Same fix applies.

---

#### CPM-003 — `VersionOverride` attribute found

**Cause:** A `PackageReference` item uses the `VersionOverride` attribute to
bypass the centrally managed version.

**Fix:** Remove the `VersionOverride` attribute. Move the version into a
per-package override file in `overrides/` instead.

---

#### CPM-004 — Unapproved `Directory.Packages.props`

**Cause:** A `Directory.Packages.props` file exists outside the approved
locations (`eng/centralpackagemanagement/` and `samples/`).

**Fix:** Delete the rogue file. NuGet's CPM walks up the directory tree and
finds `Directory.Packages.props` files automatically — extra copies can shadow
the central file and cause unexpected version resolution. Move any needed
`PackageVersion` items into the central file or a per-package override.

---

#### CPM-005 — `DirectoryPackagesPropsPath` redirect

**Cause:** A project or props file redirects `DirectoryPackagesPropsPath` to a
non-standard location. Only the root `Directory.Build.props` should set this.

**Fix:** Remove the `DirectoryPackagesPropsPath` property from your file. The
root `Directory.Build.props` already redirects all projects to the central
`eng/centralpackagemanagement/Directory.Packages.props`.

---

#### CPM-006 — Override file casing violation

**Cause:** An override file in `overrides/` doesn't follow the required
`*.Packages.props` casing convention (e.g. `*.packages.props` or
`*.Packages.Props`).

**Fix:** Rename the file so it ends with exactly `.Packages.props`. Casing
matters because CI runs on Linux (case-sensitive filesystem). Use `git mv` for
a two-step rename if only the casing differs:

```bash
git mv MyPackage.packages.props MyPackage.packages.props.tmp
git mv MyPackage.packages.props.tmp MyPackage.Packages.props
```
