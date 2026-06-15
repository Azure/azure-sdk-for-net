# @azure-typespec/http-client-csharp-mgmt

TypeSpec library for emitting Azure management libraries for C#.

## Install

```bash
npm install @azure-typespec/http-client-csharp-mgmt
```

## Emitter usage

1. Via the command line

```bash
tsp compile . --emit=@azure-typespec/http-client-csharp-mgmt
```

2. Via the config

```yaml
emit:
  - '@azure-typespec/http-client-csharp-mgmt'
```

The config can be extended with options as follows:

```yaml
emit:
  - '@azure-typespec/http-client-csharp-mgmt'
options:
  '@azure-typespec/http-client-csharp-mgmt':
    option: value
```

## Emitter options

### `emitter-output-dir`

**Type:** `absolutePath`

Defines the emitter output directory. Defaults to `{output-dir}/@azure-typespec/http-client-csharp-mgmt`
See [Configuring output directory for more info](https://typespec.io/docs/handbook/configuration/configuration/#configuring-output-directory)

### `api-version`

**Type:** `string`

For TypeSpec files using the [`@versioned`](https://typespec.io/docs/libraries/versioning/reference/decorators/#@TypeSpec.Versioning.versioned) decorator, set this option to the version that should be used to generate against.

### `generate-protocol-methods`

**Type:** `boolean`

Set to `false` to skip generation of protocol methods. The default value is `true`.

### `generate-convenience-methods`

**Type:** `boolean`

Set to `false` to skip generation of convenience methods. The default value is `true`.

### `unreferenced-types-handling`

**Type:** `"removeOrInternalize" | "internalize" | "keepAll"`

Defines the strategy on how to handle unreferenced types. The default value is `removeOrInternalize`.

### `new-project`

**Type:** `boolean`

Set to `true` to overwrite the csproj if it already exists. The default value is `false`.

### `save-inputs`

**Type:** `boolean`

Set to `true` to save the `tspCodeModel.json` and `Configuration.json` files that are emitted and used as inputs to the generator. The default value is `false`.

### `package-name`

**Type:** `string`

Define the package name. If not specified, the first namespace defined in the TypeSpec is used as the package name.

### `debug`

**Type:** `boolean`

Set to `true` to automatically attempt to attach to a debugger when executing the C# generator. The default value is `false`.

### `logLevel`

**Type:** `"info" | "debug" | "verbose"`

Set the log level for which to collect traces. The default value is `info`.

### `disable-xml-docs`

**Type:** `boolean`

Set to `true` to disable XML documentation generation. The default value is `false`.

### `disable-roslyn-reduce`

**Type:** `boolean`

Set to `true` to skip the Roslyn reduce (simplification) post-processing step. This speeds up generation and is useful when iterating quickly. The default value is `false`.

### `generator-name`

**Type:** `string`

The name of the generator. By default this is set to `ScmCodeModelGenerator`. Generator authors can set this to the name of a generator that inherits from `ScmCodeModelGenerator`.

### `emitter-extension-path`

**Type:** `string`

Allows emitter authors to specify the path to a custom emitter package, allowing you to extend the emitter behavior. This should be set to `import.meta.url` if you are using a custom emitter.

### `plugins`

**Type:** `string[]`

Paths to generator plugin assemblies (DLLs) or directories containing plugin assemblies. Each plugin must contain a class that extends `GeneratorPlugin`. Paths may be absolute or relative to the resolved `emitter-output-dir`. For example, to load plugins that live in a `codegen` folder under the output directory:

```yaml
options:
  '@typespec/http-client-csharp':
    plugins:
      - 'codegen/MyPlugin.dll' # file relative to emitter-output-dir
      - 'codegen' # directory containing plugin assemblies
      - '/abs/path/to/MyPlugin.dll' # absolute path used as-is
```

### `license`

**Type:** `object { name, company, link, header, description }`

License information for the generated client code.

**Properties:**

| Name          | Type     | Default | Description |
| ------------- | -------- | ------- | ----------- |
| `name`        | `string` |         |             |
| `company`     | `string` |         |             |
| `link`        | `string` |         |             |
| `header`      | `string` |         |             |
| `description` | `string` |         |             |

### `sdk-context-options`

**Type:** `object`

The SDK context options that implement the `CreateSdkContextOptions` interface from the [`@azure-tools/typespec-client-generator-core`](https://www.npmjs.com/package/@azure-tools/typespec-client-generator-core) package to be used by the CSharp emitter.

### `namespace`

**Type:** `string`

The C# namespace to use for the generated code. This will override the TypeSpec namespaces.

### `model-namespace`

**Type:** `boolean`

Whether to put models under a separate 'Models' sub-namespace. This only applies if the 'namespace' option is set. The default value is 'false'.

### `enable-wire-path-attribute`

**Type:** `boolean`

**Default:** `false`

Whether to enable the WirePathAttribute on model properties. The default value is 'false'.

### `use-legacy-resource-detection`

**Type:** `boolean`

**Default:** `true`

Whether to use the legacy custom resource detection logic instead of the standardized resolveArmResources API from @azure-tools/typespec-azure-resource-manager. When true, uses the legacy logic. When false, uses the resolveArmResources API.

### `skip-api-version-override`

**Type:** `boolean`

**Default:** `false`

Temporary workaround: Whether to pass skipApiVersionOverride: true when instantiating ArmOperation types in generated LRO methods. When true, the LRO polling will not override the api-version from the initial request URI. This option will be removed once the api-version override issue is properly resolved in Azure.Core. The default value is 'false'.
