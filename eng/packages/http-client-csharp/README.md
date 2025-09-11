# @azure-typespec/http-client-csharp

TypeSpec library for emitting Azure libraries for C#.

## Install

```bash
npm install @azure-typespec/http-client-csharp
```

## Emitter usage

1. Via the command line

```bash
tsp compile . --emit=@azure-typespec/http-client-csharp
```

2. Via the config

```yaml
emit:
  - '@azure-typespec/http-client-csharp'
```

The config can be extended with options as follows:

```yaml
emit:
  - '@azure-typespec/http-client-csharp'
options:
  '@azure-typespec/http-client-csharp':
    option: value
```

## Emitter options

### `emitter-output-dir`

**Type:** `absolutePath`

Defines the emitter output directory. Defaults to `{output-dir}/@azure-typespec/http-client-csharp`
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

### `generator-name`

**Type:** `string`

The name of the generator. By default this is set to `ScmCodeModelGenerator`. Generator authors can set this to the name of a generator that inherits from `ScmCodeModelGenerator`.

### `emitter-extension-path`

**Type:** `string`

Allows emitter authors to specify the path to a custom emitter package, allowing you to extend the emitter behavior. This should be set to `import.meta.url` if you are using a custom emitter.

### `update-code-model`

**Type:** `object`

Allows emitter authors to specify a custom function to modify the generated code model before emitting. This is useful for modifying the code model before it is passed to the generator.

### `license`

**Type:** `object`

License information for the generated client code.

### `sdk-context-options`

**Type:** `object`

The SDK context options that implement the `CreateSdkContextOptions` interface from the [`@azure-tools/typespec-client-generator-core`](https://www.npmjs.com/package/@azure-tools/typespec-client-generator-core) package to be used by the CSharp emitter.

### `namespace`

**Type:** `string`

The C# namespace to use for the generated code. This will override the TypeSpec namespaces.

### `model-namespace`

**Type:** `boolean`

Whether to put models under a separate 'Models' sub-namespace. This only applies if the 'namespace' option is set. The default value is 'false'.
