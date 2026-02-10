# tsp-client

`tsp-client` is a simple command line tool to facilitate generating client libraries from TypeSpec.

## Prerequisites

- [Node.js 18.19 LTS](https://nodejs.org/en/download/) or later is required

## Installation

```bash
npm install -g @azure-tools/typespec-client-generator-cli
```

> NOTE: Repo owners should follow the steps in the [tsp-client repo setup](./repo_setup.md) doc.

## Usage

```bash
tsp-client < command > [options]
```

## Commands

Use one of the supported commands to get started generating clients from a TypeSpec project.

This tool will default to using your current working directory to generate clients in and will
use it to look for relevant configuration files. To specify a different output directory, use
the `-o` or `--output-dir` option.

To see supported commands, run:

```bash
tsp-client --help
```

To see supported parameters and options for a specific command, run:

```bash
tsp-client < command > --help
```

Example using the `init` command:

```bash
tsp-client init --help
```

### init

Initialize the client library directory using a tspconfig.yaml. When running this command pass in a path to a local or the URL of a remote tspconfig.yaml with the `-c` or `--tsp-config` flag. If remote, the tspconfig.yaml must include the specific commit in the path. (See example below)

The `init` command generates a directory structure following the standard pattern used across Azure SDK language repositories, creates a [tsp-location.yaml](#tsp-locationyaml) file to control generation, and performs an initial generation of the client library. If you want to skip client library generation, then pass the `--skip-sync-and-generate` flag.

> IMPORTANT: This command should be run from the root of the repository. Example repository root: `azure-sdk-for-python/`

Example:

```bash
tsp-client init -c https://github.com/Azure/azure-rest-api-specs/blob/dee71463cbde1d416c47cf544e34f7966a94ddcb/specification/contosowidgetmanager/Contoso.WidgetManager/tspconfig.yaml
```

### update

The `update` command will look for a [tsp-location.yaml](#tsp-locationyaml) file in your current directory to sync a TypeSpec project and generate a client library. The update flow calls the `sync` and `generate` commands internally, so if you need to separate these steps, use the `sync` and `generate` commands separately instead.

Example:

```bash
tsp-client update
```

For batch library generation see the [Batch library generation](#batch-library-generation) instructions.

### sync

Sync a TypeSpec project with the parameters specified in tsp-location.yaml.

By default the `sync` command will look for a tsp-location.yaml to get the project details and sync them to a temporary directory called `TempTypeSpecFiles`. Alternately, you can pass in the `--local-spec-repo` flag with the path to your local TypeSpec project to pull those files into your temporary directory.

Example:

```bash
tsp-client sync
```

### generate

Generate a client library from a TypeSpec project. The `generate` command should be run after the `sync` command. `generate` relies on the existence of the `TempTypeSpecFiles` directory created by the `sync` command and on an `emitter-package.json` file checked into your repository at the following path: `<repo root>/eng/emitter-package.json`. The `emitter-package.json` file is used to install project dependencies and get the appropriate emitter package.

Example:

```bash
tsp-client generate
```

### convert

Convert an existing swagger specification to a TypeSpec project. This command should only be run once to get started working on a TypeSpec project. TypeSpec projects will need to be optimized manually and fully reviewed after conversion. When using this command a path or url to a swagger README file is required through the `--swagger-readme` flag. By default, the converted TypeSpec project will leverage TypeSpec built-in libraries with standard patterns and templates (highly recommended), which will cause discrepancies between the generated TypeSpec and original swagger. If you really don't want this intended discrepancy, add `--fully-compatible` flag to generate a TypeSpec project that is fully compatible with the swagger.

Example:

```bash
tsp-client convert -o ./Contoso.WidgetManager --swagger-readme < path-to > /readme.md
```

### sort-swagger

Sort an existing swagger specification to be the same content order with TypeSpec generated swagger. This will allow you to easily compare and identify differences between the existing swagger and TypeSpec generated one. You should run this command on existing swagger files and check them in prior to creating converted TypeSpec PRs.

### generate-config-files

This command generates the default configuration files used by tsp-client. Run this command to generate the `emitter-package.json` and `emitter-package-lock.json` under the **eng/** directory of your current repository.

**Required: Use the `--package-json` flag to specify the path to the package.json file of the emitter you will use to generate client libraries.**

Example:

```bash
tsp-client generate-config-files --package-json < path-to-emitter-repo-clone > /package.json
```

Example using the `azure-sdk-for-js` and the `@azure-tools/typespec-ts` emitter:

The `--package-json` flag should be the relative or absolute path to repo clone of the @azure-tools/typespec-ts package.

```bash
azure-sdk-for-js > tsp-client generate-config-files --package-json < path-to-emitter-repo-clone > /package.json
```

To be explicit about specifying dependencies you'd like pinned, add a new field in the package.json file of your emitter called `"azure-sdk/emitter-package-json-pinning"` with a list of the dependencies you want to be forwarded to the emitter-package.json. These dependencies must be specified in your package.json's devDependencies in order for the tool to assign the correct version.

> NOTE: If the `azure-sdk/emitter-package-json-pinning` field is missing from the package.json file, the tool will default to pinning the packages listed under `peerDependencies`.

Example package.json using `"azure-sdk/emitter-package-json-pinning"`:

```json
{
  "name": "@azure-tools/typespec-foo",
  "version": "0.4.0-alpha.20250110.1",
  ...
  "dependencies": {
    "@azure-tools/generator-foo": "0.3.0",
    "@typespec/http-client-foo": "1.2.0"
  },
  "devDependencies": {
    "@typespec/compiler": "0.64.0",
    "rimraf": "^6.0",
  },
  "azure-sdk/emitter-package-json-pinning": [
    "@typespec/compiler"
  ]
}
```

Example `emitter-package.json` generated from the package.json shown above:

```json
{
  "main": "dist/src/index.js",
  "dependencies": {
    "@azure-tools/typespec-foo": "0.4.0-alpha.20250110.1"
  },
  "devDependencies": {
    "@typespec/compiler": "0.64.0"
  }
}
```

If you need to override dependencies for your emitter-package.json you can create a json file to explicitly list the package and corresponding version you want to override. This will add an `overrides` section in your emitter-package.json that will be used during `npm install` or `npm ci`. [See npm overrides doc.](https://docs.npmjs.com/cli/v10/configuring-npm/package-json?v=true#overrides)

Example json file with package overrides:

```json
{
  "@azure-tools/typespec-foo": "https://<dev-feed-url>/typespec-foo-0.4.0-alpha.20250110.1.tgz",
  "@azure-tools/generator-foo": "https://<dev-feed-url>/generator-foo-1.3.0-alpha.20250110.1.tgz"
}
```

Example command specifying overrides:

```bash
tsp-client generate-config-files --overrides my_overrides.json --package-json < path-to-emitter-repo-clone > /package.json
```

Example `emitter-package.json` generated using overrides:

```json
{
  "main": "dist/src/index.js",
  "dependencies": {
    "@azure-tools/typespec-foo": "https://<dev-feed-url>/typespec-foo-0.4.0-alpha.20250110.1.tgz"
  },
  "devDependencies": {
    "@typespec/compiler": "~0.64.0"
  },
  "overrides": {
    "@azure-tools/generator-foo": "https://<dev-feed-url>/generator-foo-1.3.0-alpha.20250110.1.tgz"
  }
}
```

### generate-lock-file

Generate an emitter-package-lock.json under the eng/ directory based on existing `<repo-root>/eng/emitter-package.json`.

Example:

```bash
tsp-client generate-lock-file
```

### install-dependencies

Install the dependencies pinned in emitter-package.json and emitter-package-lock.json (if it exists) at the root of the repository by default. The command supports a positional path parameter if the dependencies need to be installed in an alternate directory.

> IMPORTANT: The node_modules/ directory needs to be installed in a path where basic npm commands will be able to use it. Typically within the same directory path as the target TypeSpec project to compile.

```bash
tsp-client install-dependencies [optional install path]
```

## Important concepts

### Per project setup

Each project will need to have a configuration file called tsp-location.yaml that will tell the tool where to find the TypeSpec project.

#### tsp-location.yaml

This file is created through the `tsp-client init` command or you can manually create it under the project directory to run other commands supported by this tool.

> NOTE: This file should live under the project directory for each service.

The file has the following properties:

| Property                                                        | Description                                                                                                                                                                                                                                                                                           | IsRequired            |
| --------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------- |
| <a id="directory-anchor"></a> directory                         | The top level directory where the main.tsp for the service lives. This should be relative to the spec repo root such as `specification/cognitiveservices/OpenAI.Inference`                                                                                                                            | true                  |
| <a id="additionalDirectories-anchor"></a> additionalDirectories | Sometimes a typespec file will use a relative import that might not be under the main directory. In this case a single `directory` will not be enough to pull down all necessary files. To support this you can specify additional directories as a list to sync so that all needed files are synced. | false: default = null |
| <a id="commit-anchor"></a> commit                               | The commit sha for the version of the typespec files you want to generate off of. This allows us to have idempotence on generation until we opt into pointing at a later version.                                                                                                                     | true                  |
| <a id="repo-anchor"></a> repo                                   | The repo this spec lives in. This should be either `Azure/azure-rest-api-specs` or `Azure/azure-rest-api-specs-pr`. Note that pr will work locally but not in CI until we add another change to handle token based auth.                                                                              | true                  |
| <a id="entrypointFile-anchor"></a> entrypointFile               | A specific entrypoint file used to compile the TypeSpec project. NOTE: This option should only be used with a non-standard entrypoint file name. DO NOT use this option with standard entrypoints: `client.tsp` or `main.tsp`.                                                                        | false                 |

Example:

```yml title=tsp-location.yaml
directory: specification/contosowidgetmanager/Contoso.WidgetManager
commit: 431eb865a581da2cd7b9e953ae52cb146f31c2a6
repo: Azure/azure-rest-api-specs
additionalDirectories:
  - specification/contosowidgetmanager/Contoso.WidgetManager.Shared/
```

## Advanced scenarios

### Batch library generation

Batch client library generation is only supported with the `tsp-client update` command. To enable batch generation follow these steps:

1. Add a tsp-location.yaml file in the parent directory where all of the batch libraries will be generated. Example:

```
- sdk/
  - foo/
    - tsp-location.yaml
    - bar/
    - zas/
```

2. The top level tsp-location.yaml should only have the `batch` property configured. The batch property is expected to be a list of sub-directories that directly contain the regular tsp-location.yaml files with appropriate configurations for client library generation. Other tsp-location.yaml properties such as `directory`, `commit`, `repo`, `additionalDirectories` are not currently supported with the `batch` configuration. Example:

```yml title=tsp-location.yaml
batch:
  - ./bar
  - ./zas
```

3. Ensure that the subdirectories specified in the `batch` list have tsp-location.yaml files configured for them. If a sub-directory doesn't have a tsp-location.yaml file directly under it, tsp-client will return an error. To set up the tsp-location.yaml files in the sub-directories, you can either create the tsp-location.yaml file manually or use `tsp-client init` with an appropriate `emitter-output-dir` configuration to create it.

Example of required file structure:

```
- sdk/
  - foo/
    - tsp-location.yaml
    - bar/
        - tsp-location.yaml
    - zas/
        - tsp-location.yaml
```

Example of regular tsp-location.yaml in sub-directories:

```yml title=tsp-location.yaml
directory: specification/contosowidgetmanager/Contoso.WidgetManager
commit: abc123
repo: Azure/azure-rest-api-specs
additionalDirectories:
  - specification/contosowidgetmanager/Contoso.WidgetManager.Shared/
```

4. Run `tsp-client update` from the parent directory. In the example above it would be the `foo/` directory.

> NOTE: The command will fail immediately if the `update` call fails on a sub-directory.

5. All done! tsp-client will call the update command on each subdirectory, forwarding commandline args to the command.

> NOTE: The `local-spec-repo` flag will have special behavior during batch library generation. tsp-client will get the repo root path for the local spec repo path that is passed into the flag, then it will append the directory value from the tsp-location.yaml file in the corresponding sub-directory.
