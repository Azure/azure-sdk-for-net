# Azure SDK .NET - Versioning

This document covers the basic versioning strategy and which properties to use. It is based on the rules outlined in our [Azure SDK Releases doc](https://github.com/Azure/azure-sdk/blob/main/docs/policies/releases.md#net) and it closely matches the [.NET versioning rules](https://github.com/dotnet/arcade/blob/master/Documentation/CorePackages/Versioning.md) but simplified to only include the parts necessary for our libraries.

## Package Versioning

Package version will look like:
```
MAJOR.MINOR.PATCH-PRERELEASE
```

In the project file use the `Version` property to define the `MAJOR.MINOR.PATCH-beta.X` part of the version.

```
<Version>1.0.0-beta.1</Version>
```

By default builds will replace any prerelease identifier with a `alpha.yyyyMMdd.r` to ensure we have unique package versions for dev builds. The date will come from either
today's date or a property named `OfficialBuildId` which we will pass as part of our build pipelines.

If we need to produce a package that is not a dev package with an alpha version and has the version in the project (i.e. stable or beta) then the `SkipDevBuildNumber` should
be passed as `true` to the packaging command.

## Incrementing the version

See [Incrementing after release](https://github.com/Azure/azure-sdk/blob/main/docs/policies/releases.md#incrementing-after-release) for general guidance but at a
high level we will do the following versioning changes:

- After a beta release we bump the number after the beta. `1.0.0-beta.1` -> `1.0.0-beta.2`
- After a GA release we bump the minor version and switch to beta 1. `1.0.0` -> `1.1.0-beta.1`
- Prior to a hot-fix release we bump the patch version. `1.0.0` -> `1.0.1`

Versions are automatically bumped up in package project `.csproj` files as well as package changelog `CHANGELOG.md` as part of the release process. To increment a version locally make use of the `eng\scripts\Update-PkgVersion.ps1` script.

## Assembly Versioning

By default the assembly version will be set to the `Version` property but if the assembly version needs to be different for some reason then it can be independently set by the `AssemblyVersion` property.

## File Versioning

File version has 4 parts and needs to increase every official build. This is especially important when building MSIs.

They will use the following format which is also used by the .NET team:

```
FILEMAJOR.FILEMINOR.FILEPATCH.FILEREVISION
```
- `FILEMAJOR`: Specified in the first part of `Version` property.
- `FILEMINOR`: Set to `MINOR * 100 + PATCH / 100`, where `MINOR` and `PATCH` are the 2nd and 3rd parts of `Version` property.
- `FILEPATCH`: Set to `(PATCH % 100) * 100 + yy`.
- `FILEREVISION`: Set to `(50 * mm + dd) * 100 + r`. This algorithm makes it easy to parse the month and date from `FILEREVISION` while staying in the range of a short which is what a version element uses.

The versioning scheme imposes the following limits on these version parts:
- `MAJOR` version is in range [0-65535]
- `MINOR` version is in range [0-654]
- `PATCH` version is in range [0-9999]


## Build Parameters

| Parameter                  | Description                                                  |
| -------------------------- | ------------------------------------------------------------ |
| OfficialBuildId            | ID of current build. The accepted format is `yyyyMMdd.r`. Should be passed to build in YAML official build defintion. |
