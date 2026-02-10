# Change Log - @autorest/core

This log was last generated on Mon, 16 Jun 2025 19:35:57 GMT and should not be manually modified.

## 3.10.8
Mon, 16 Jun 2025 19:35:57 GMT

### Patches

- Relax `api-version` in `x-ms-examples` min length to 1

## 3.10.7
Wed, 21 May 2025 20:59:20 GMT

### Patches

- Fix directive not applying when json path query result in some eval errors

## 3.10.6
Tue, 20 May 2025 18:08:56 GMT

### Patches

- Update dependencies

## 3.10.5
Tue, 13 May 2025 03:26:36 GMT

### Patches

- [deduplication] Only treat "$ref" as reference if value is string (part 2)

## 3.10.4
Fri, 14 Mar 2025 16:49:52 GMT

### Patches

- [deduplication] Only treat "$ref" as reference if value is string

## 3.10.3
Thu, 31 Oct 2024 00:11:17 GMT

### Patches

- Include stack trace when logging errors

## 3.10.2
Wed, 28 Feb 2024 18:02:21 GMT

### Patches

- Fix: Crash when deduplication paths
- Fix: Crash reporting zero exit code when a plugin report a crash but send invalid exception

## 3.10.1
Tue, 28 Nov 2023 19:02:52 GMT

### Patches

- Resolve latest installed instead of first

## 3.10.0
Thu, 16 Nov 2023 16:00:04 GMT

### Minor changes

- Update dependencies

## 3.9.7
Mon, 31 Jul 2023 14:56:21 GMT

### Patches

- Fix for final-state-schema with external ref

## 3.9.6
Fri, 26 May 2023 14:12:36 GMT

### Patches

- Update final-state-schema references in merger

## 3.9.5
Thu, 13 Apr 2023 04:20:09 GMT

### Patches

- Fix: Issue with discriminator mapping not working across files

## 3.9.4
Wed, 07 Dec 2022 22:24:34 GMT

### Patches

- Fix: ignore $ref in `x-` pointing to `x-` paths
- Fix: Emitted artifact from csharp on windows use `\` which result in transform not running
- Update dependencies

## 3.9.3
Wed, 19 Oct 2022 16:18:27 GMT

### Patches

- Update system requirement package to fix issue with resolving python on windows

## 3.9.2
Fri, 19 Aug 2022 16:52:58 GMT

### Patches

- Fix suppression not working

## 3.9.1
Wed, 27 Jul 2022 17:44:10 GMT

### Patches

- Fix `where-operation-match` built-in directive

## 3.9.0
Tue, 19 Jul 2022 15:09:55 GMT

### Minor changes

- `x-ms-examples` are loaded latter in the pipeline. This allow plugins to get the raw openapi specs right after load.
- Enable identity sourcemap for extensions

### Patches

- Fix: `$ref` contains percent-encoding.

## 3.8.4
Wed, 27 Apr 2022 18:53:11 GMT

### Patches

- Fix issue with using $ref in responses inserterting $ref in the parent.
- Fix issue with `x-ms-client-name` on inline array type.

## 3.8.3
Tue, 22 Mar 2022 20:26:28 GMT

### Patches

- `allow-no-input` will not stop autorest run immidiately

## 3.8.2
Tue, 22 Mar 2022 00:17:01 GMT

### Patches

- Fix crash when having invalid cli arguments
- Fix progress Bar crashing autorest when stdout redirected to file

## 3.8.1
Mon, 21 Mar 2022 15:38:03 GMT

### Patches

- Fix issue with x-ms-client-name not respected when used inside `type:array` `items`
- Full ref resolver validate the refs are valid

## 3.8.0
Tue, 15 Mar 2022 16:00:38 GMT

### Minor changes

- Log information at the end of autorest run (Runtime, number of files generated).
- `--help` usage include `yaml` and `json` as config file formats
- **Added** new plugin to save transformed input in place
- Enable ability to override the logger log level in specific plugins
- Uptake change in typing in openapi library

### Patches

- Add helper error message on failure

## 3.7.6
Tue, 01 Feb 2022 23:06:50 GMT

### Patches

- **Fix** Issue with emitting converted openapi

## 3.7.5
Wed, 26 Jan 2022 22:31:57 GMT

### Patches

- Update swagger schema changes

## 3.7.4
Wed, 12 Jan 2022 22:31:57 GMT

### Patches

- **Fix** semantic validator allowing `readonly` instead of `readOnly` next to $ref
- Do not update $ref in `x-` extensions

## 3.7.2
Tue, 07 Dec 2021 22:39:16 GMT

_Version update only_

## 3.7.2
Wed, 01 Dec 2021 22:39:16 GMT

_Version update only_

## 3.7.1
Tue, 30 Nov 2021 15:50:35 GMT

_Version update only_

## 3.7.0
Fri, 19 Nov 2021 04:23:42 GMT

### Minor changes

- **Updated** `--help` to use configuration schema and be consistent
- **Added** Support for sourcemap in autorest extensions
- Add installation status of extension with a progress bar.
- Improve error reporting when extension fails to install.

### Patches

- **Fix** --help crash
- **Internal** Remove use of extension method `.last`
- **Fix** Nullable on certain properties during tree shaking
- **Fix** Sourcemap library fails to load when packed with webpack

## 3.6.6
Mon, 11 Oct 2021 21:01:13 GMT

### Patches

- **Fix** Unreferenced discriminated union option being removed

## 3.6.5
Wed, 06 Oct 2021 17:36:17 GMT

### Patches

- **Fix** exit code always 0

## 3.6.4
Tue, 05 Oct 2021 16:39:50 GMT

### Patches

- **Fix** `message-format` not being respected

## 3.6.3
Thu, 23 Sep 2021 19:51:32 GMT

### Patches

- **Added** `include-x-ms-examples-original-file` flag to activate `x-ms-original-file` injection in `x-ms-examples`

## 3.6.2
Fri, 17 Sep 2021 17:52:01 GMT

### Patches

- **Fix** Deduplicating enums dropped `format` property

## 3.6.1
Thu, 16 Sep 2021 18:49:17 GMT

### Patches

- **Fix** Deduplicating `boolean` enums changed type to `string`

## 3.6.0
Wed, 08 Sep 2021 15:39:22 GMT

### Minor changes

- **Uptake** New logger
- Uptake new changes to Swagger->OpenApi3 converter
- `x-ms-examples` loaded via $ref will save orignal location with `x-ms-original-file` extension property
- Keep `x-` extension properties when merging enums
- **Perf** Small perf improvement for components cleaner plugin
-  **Update** to new path mapping sourcemap functionality
- **Remove** quick-check plugin

### Patches

- **Perf** Minor perf in merger plugin
- **Perf** Minor performance improvement in allof cleaner plugin
- Log error when directive where clause is invalid
- Improve erorr message for directive when there is an error in the transform code
- **Fix** Error in config loading would not be logged as the logging session would not be awaited on

## 3.5.0
Mon, 19 Jul 2021 15:15:41 GMT

### Minor changes

- **Added** `debug` flag to directive to enable additional logging
- **Added** support for changing end of line of generated files with new `eol` config.
- **Feature** Resolve relative servers url using spec host
- Allow suppressing warnings without source
- Drop support for node 10
- **Perf** Memory usage improvements
- **Perf** Unload sourcemap from memory if not used

### Patches

- **Added** Flag to skip sourcemap generation
- **Fix** sourcemap for multiple plugins
- **Fix** Issue in directive manipulator preventing multiple directive to run on OpenApi3 documents

## 3.4.5
Thu, 03 Jun 2021 22:37:55 GMT

### Patches

- Blaming files not loaded by autorest

## 3.4.4
Wed, 26 May 2021 18:31:17 GMT

### Patches

- **Bump** @autorest/configuration with fix with yarn/cli.js not found

## 3.4.3
Thu, 20 May 2021 16:41:13 GMT

### Patches

- **Added** $ref sibling validation
- **Fix** Keep `x-` extension next to $ref when tree shaking properties
- **Bump** @autorest/configuration version
- **Added** warning when using `x-ms-code-generation-settings` which is not supported in autorest v3

## 3.4.2
Mon, 10 May 2021 18:01:37 GMT

### Patches

- Update dependencies to include fix for interpolating config value from previous value in same file

## 3.4.1
Tue, 04 May 2021 18:18:45 GMT

### Patches

- **Fix** Uncaught promise exception

## 3.4.0
Tue, 27 Apr 2021 17:48:43 GMT

### Minor changes

- **Updated** CLI Parsing to uptake logic moved to @autorest/configuration and use config validation

### Patches

- **Fix** Default license header containing uninterpolated {generator}
- **Fix** Tree Shaking number enums same as string enum. This allows those enum to get a better auto generated name if no name is provided
- **Perf** improvement to multi api merger

## 3.3.2
Fri, 16 Apr 2021 15:18:54 GMT

### Patches

- **Merge x-ms-paths into paths during multi-api-merger step"

## 3.3.1
Tue, 13 Apr 2021 15:34:55 GMT

### Patches

- **Package update** update schema package for fix with $ref

## 3.3.0
Fri, 09 Apr 2021 19:53:22 GMT

### Minor changes

- **Added** Semantic validator plugin 
- **Feature** Add sourcemap support for errors providing original location of problem
- **Added** support for emitting statistics of the specs and resuting model

### Patches

- **Added** [SemanticValidator] Path parameters validation to the semantic validator
- **Internal** Refactor plugins

## 3.2.4
Fri, 02 Apr 2021 15:18:00 GMT

### Patches

- **Update** @autorest/configuration to take fix for broken interactive plugin

## 3.2.2
Thu, 01 Apr 2021 15:46:41 GMT

### Patches

- Bump @azure-tools/uri version to ~3.1.1
- **Cleanup** Migrated use of require -> es6 imports
- **Added** configure @azure/logger according to debug/verbose flags
- **Added** New normalize-identity plugin to support multi openapi3 files output
- **Added** New config/flag `--output-converted-oai3` to output openapi3 files right after conversion from Swager 2.0
- Update to simplified configuration loader interface

## 3.2.1
Tue, 16 Mar 2021 19:28:18 GMT

### Patches

- **Update** @azure-tools/data-store

## 3.2.0
Tue, 16 Mar 2021 15:52:56 GMT

### Minor changes

- Update swagger schema validator to use new system(`ajv` & `ajv-errors`) providing more relevant information

### Patches

- **Fix** enum deduplicator to prevent crash when using allOf in enums
- **Handle** Discrimnator mapping. Make sure the refs are updated
- **Fix** Cannot read property 'pass-thru' of undefined crash
- Bump dependencies versions

## 3.1.3
Wed, 10 Mar 2021 02:02:59 GMT

### Patches

- **Update** @autorest/configuration to uptake directives array fix

## 3.1.2
Mon, 08 Mar 2021 18:07:37 GMT

### Patches

- Set @autorest/typescript default version to 'latest'
- **Update** @autorest/configuration dependency to update `--require` cli load order fix

## 3.1.1
Fri, 05 Mar 2021 16:31:29 GMT

### Patches

- **Rename** trenton plugin to terraform
- **Fix** Handle using extension properties(x-) under components in OpenAPI3
- **Update** @autorest/configuration dependency to uptake various configuration loading fixes

## 3.1.0
Fri, 26 Feb 2021 21:50:13 GMT

### Minor changes

- **Remove** legacy CLI functionality(Using arguments with single dash).

### Patches

- **Update** Moved configuration loading from @autorest/core and redesign
- **Fix** issue when using properties with `$ref` as name where it would try to resolve a reference.

## 3.0.6375
Sat, 20 Feb 2021 17:49:35 GMT

### Patches

- **Fix** Revert use of flatMap which is not available on node 10

## 3.0.6374
Fri, 19 Feb 2021 21:42:09 GMT

### Patches

- Bundle jsonpath in webpack
- Extract some section into @autorest/core
- Rethink config
- **Fix** problem not resolving the yarn/cli.js file
- **Fix** Components cleaner not removing external non used headers but remove their schemas
- **Revert** removal of header-text config getter

## 3.0.6373
Thu, 11 Feb 2021 18:03:07 GMT

### Patches

- **Fix** Configuration for csharp causing pipeline stage not found error
- **Improvement** Provide a more detail error message when pipeline can't find a stage.
- **Update** @azure-tools/extension to ~3.1.272 and bundle it in the webpack file

## 3.0.6372
Tue, 09 Feb 2021 22:00:21 GMT

### Patches

- **Fix** Issue where it was not possible to override a config flag defined in the same markdown config. Markdown configuration loading now treats yaml code block in increasing priority order.
- **Update** @azure-tools/extension to newer version that will log errors when installing packages.

## 3.0.6371
Mon, 08 Feb 2021 23:06:15 GMT

### Patches

- Internal: Migrate bundling system to webpack
- Update csharp generator to default to v3. Use `--v2` to revert to previous version

## 3.0.6370
Thu, 04 Feb 2021 19:05:18 GMT

### Patches

- Internal: Moved source to src/ folder
- Refactoring: Cleanup of code running transform directives
- Internal code linting fixes
- Internal: Add some tests to the tree shaker

## 3.0.x
Tue, 4 Feb 2020 00:00:00 GMT

### Patches

- rebuild to pick up latest data-store to fix the caching filename size
- OAI2-to-OAI3 converter update in perks.
- TransformerViaPointer was turning null into {} 
- rebuild to fix NPM publishing problem.
- remove additionalProperties: false so v2 generators don't choke.
- rebuild to pick up perks change to fix multibyte utf8 over byte boundary problem
- rebuild to pick up a perks change to support turning underscore in semver to dash on gh releases
- rebuild to pick up newer extension library that supports python interpreter detection
- force rebuild to pick up fix in oai2 converter
- update the oai2-to-oai3 converter (parameterized host parameters should be client parameters if they are $ref'd)

