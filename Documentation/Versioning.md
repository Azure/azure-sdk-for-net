# Azure SDK .NET - Versioning

This document covers the basic versioning strategy and which properties to use. It is based on the rules outlined in our [Azure SDK Releases doc](https://github.com/Azure/azure-sdk/blob/master/docs/engineering-system/releases.md#net) and it closely matches the [.NET versioning rules](https://github.com/dotnet/arcade/blob/master/Documentation/CorePackages/Versioning.md) but simplified to only include the parts necessary for our libraries.

## Package Versioning

Package version will look like:
```
MAJOR.MINOR.PATCH-PRERELEASE
```

In the project file use the `VersionPrefix` property to define the `MAJOR.MINOR.PATCH` part of the version.

```
<VersionPrefix>1.0.0</VersionPrefix>
```

`PRERELEASE` will be controlled by:

- **BuildNumber:** Should be in the format `yyyyMMdd.<build revision>` and defaults to today's date `yyyyMMdd.1` but can be set by passing in and msbuild property for `OfficialBuildId` with a matching format.
- **PreReleaseLabel:** Defaults to `dev` but can be set by passing in the msbuild property for `PreReleaseVersionLabel`. Some examples might be "preview", "preview.1", etc.
- **VersionKind:** Defaults to "" which results to the default dev build label but can be set by passing in the msbuild property `DotNetFinalVersionKind` to one of the values "", "prerelease", or "release".

Examples:

| VersionKind  | Package version format                  | Example package versions  |
|--------------|-----------------------------------------|---------------------------|
| ""           | `1.2.3-<PreReleaseLabel>.<BuildNumber>` | `1.2.3-dev.20190509.1`    |
| "prerelease" | `1.2.3-<PreReleaseLabel>`               | `1.2.3-preview.1`         |
| "release"    | `1.2.3`                                 | `1.2.3`                   |

## Assembly Versioning

By default the assembly version will be set to the `VersionPrefix` property but if the assembly version needs to be different for some reason then it can be independently set by the `AssemblyVersion` property.

## File Versioning

File version has 4 parts and needs to increase every official build. This is especially important when building MSIs.

They will use the following format which is also used by the .NET team:

```
FILEMAJOR.FILEMINOR.FILEPATCH.FILEREVISION
```
- `FILEMAJOR`: Specified in the first part of `VersionPrefix` property.
- `FILEMINOR`: Set to `MINOR * 100 + PATCH / 100`, where `MINOR` and `PATCH` are the 2nd and 3rd parts of `VersionPrefix` property.
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
| DotNetFinalVersionKind     | Specify the kind of version being generated: `release`, `prerelease` or empty. |
| PreReleaseVersionLabel     | Pre-release label to be used on the string. E.g., `preview`, `preview.1`, etc. |
| VersionPrefix              | Specify the leading part of the version string. If empty it will default to 1.0.0 from the SDK. |
