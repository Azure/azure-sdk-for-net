# Change Log - autorest

This log was last generated on Tue, 20 May 2025 18:08:56 GMT and should not be manually modified.

## 3.7.2
Tue, 20 May 2025 18:08:56 GMT

### Patches

- Update dependencies

## 3.7.1
Tue, 28 Nov 2023 19:02:52 GMT

### Patches

- Resolve latest installed instead of first

## 3.7.0
Thu, 16 Nov 2023 16:00:04 GMT

### Minor changes

- Update dependencies

## 3.6.3
Wed, 07 Dec 2022 22:24:34 GMT

### Patches

- Update dependencies

## 3.6.2
Tue, 19 Jul 2022 15:09:55 GMT

_Version update only_

## 3.6.1
Tue, 22 Mar 2022 00:17:01 GMT

### Patches

- Fix progress Bar crashing autorest when stdout redirected to file

## 3.6.0
Tue, 15 Mar 2022 16:00:38 GMT

### Minor changes

- Improve resolution of available core packages.

### Patches

- **Fix** Library logging not configured

## 3.5.1
Tue, 30 Nov 2021 15:50:35 GMT

_Version update only_

## 3.5.0
Fri, 19 Nov 2021 04:23:43 GMT

### Minor changes

- **Remove** legacy code
- Add installation status of extension with a progress bar.
- Improve error reporting when extension fails to install.

### Patches

- **Fix** Sourcemap library fails to load when packed with webpack
- Render progress bar when installing core

## 3.4.2
Tue, 15 Oct 2021 17:00:00 GMT

### Patches

- **fix** issue with extension method causing conflict when loading autorest core v2

## 3.4.1
Tue, 05 Oct 2021 17:04:21 GMT

### Patches

- **fix** Respect `message-format` option

## 3.4.0
Wed, 08 Sep 2021 15:39:22 GMT

### Minor changes

- *Uptake** New logger

### Patches

- **Fix** If an error occures in the config loading, ignore and try to load a version of @autorest/core

## 3.3.2
Tue, 20 Jul 2021 16:57:32 GMT

### Patches

- **Fix** `--memory` flag not working

## 3.3.0
Mon, 19 Jul 2021 15:15:42 GMT

### Minor changes

- **Added** Support for new `--memory` flag to configure core max memory
- Drop support for node 10

## 3.2.3
Thu, 03 Jun 2021 22:37:55 GMT

_Version update only_

## 3.2.2
Wed, 26 May 2021 18:31:17 GMT

### Patches

- **Bump** @autorest/configuration with fix with yarn/cli.js not found

## 3.2.1
Thu, 20 May 2021 16:41:13 GMT

_Version update only_

## 3.2.0
Tue, 27 Apr 2021 17:48:43 GMT

### Minor changes

- **Update** minimum node version from `10.12` to `10.16`

### Patches

- **Updated** CLI Parsing to uptake logic moved to @autorest/configuration

## 3.1.5
Fri, 09 Apr 2021 19:53:22 GMT

_Version update only_

## 3.1.4
Thu, 01 Apr 2021 15:46:42 GMT

### Patches

- Bump @azure-tools/uri version to ~3.1.1
- **Cleanup** Migrated use of require -> es6 imports
- **Fix** Load default configuration when resolving core version
- **Update** @autorest/core version resolving in configuration file doesn't shell out to @autorest/core anymore

## 3.1.3
Tue, 16 Mar 2021 15:52:56 GMT

### Patches

- Bump dependencies versions

## 3.1.2
Fri, 26 Feb 2021 21:50:13 GMT

### Patches

- **Removed** isConfigurationDocument, use @autorest/configuration package to get this function
- Always load sourcemaps

## 3.1.1
Sun, 21 Feb 2021 05:37:47 GMT

### Patches

- **Fix**: Loosen default version requirement for @autorest/core to only be the same major version as the cli.

## 3.1.0
Fri, 19 Feb 2021 21:42:09 GMT

### Minor changes

- **Migrate** to using webpack for bundling.

## 3.0.6339
Thu, 11 Feb 2021 18:03:07 GMT

### Patches

- **Update** @azure-tools/extension to ~3.1.272 
- **Internals** Update chalk dependency to ^4.1.0

## 3.0.6338
Tue, 09 Feb 2021 00:00:00 GMT

### Patches

- **Update** @azure-tools/extension to newer version that will log errors when installing packages.

## 3.0.6337
Mon, 08 Feb 2021 23:06:15 GMT

### Patches

- Fix build not generating types

## 3.0.6336
Thu, 04 Feb 2021 19:05:18 GMT

### Patches

- Consolidate tsconfig settings with other projects
- Internal code linting fixes

## 3.0.x
Mon, 10 Feb 2020 00:00:00 GMT

### Patches

- detects when to fall back to autorest v2 core (no `--profile`, no `--api-version`)
- made nodejs sandbox reusable. Much faster.
- rebuild to pick up perks change to fix multibyte utf8 over byte boundary problem
- rebuild to pick up a perks change to support turning underscore in semver to dash on gh releases
- on secondary swagger files, schema schema validation is relaxed to be warnings.
- drop unreferenced requestBodies during merge
- supports v2 generators (and will by default, fall back to a v2 core unless overriden with `--version:`
- if a v3 generator is loaded via `--use:` , it should not attempt to load v2 generator  even if `--[generator]` is specified (ie, `--python` `--use:./python` ) should be perfectly fine
- the v3 generator name in `package.json` should be `@autorest/[name]` - ie `@autorest/csharp` 
- it will only assume `--tag=all-api-versions`  if either `--profile:`... or `--api-version:`... is specified. 
- rebuild to pick up newer extension library that supports python interpreter detection

