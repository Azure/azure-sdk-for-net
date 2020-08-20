# azure-track2-csharp
An early code generator for Track 2 C# client libraries on top of Azure.Core.

We support a number of extensions including using the vendor prefix `x-az-`:

- `x-az-public`: Expose APIs as `public` when `true` or `internal` when `false`.  The default value is `true`.
- `x-az-response-name`: Provide a name for response types other than `GroupOperationResponse`.  Any responses using the same name will be merged together.
- `x-az-response-schema-name`: If we combine headers and a schema into a response type, this allows you to provide the name of the scehma property.  The default value is `Body`.
- `x-az-create-exception`: `true` denotes that this partial type will provide an implementation of the method `Exception CreateException()` to turn an error object into something that can be thrown.  The default value is `false`.
- `x-az-trace`: Indicates whether a parameter will be logged as part of our distributed tracing.  The default value is `false`.
- `x-az-enum-skip-value`: The name of a default value to skip while serializing.
- `x-az-disable-warnings`: Wraps a declaration in a `#pragma disable` when specified.
- `x-az-skip-path-components`: Whether to skip any path components and always assume a fully formed URL to the resource (this currently must be set to `true`).
- `x-az-include-sync-methods`: Whether to generate support for sync methods.  The default value is `false` (this flag should go away soon and always be `true`).
- `x-az-stream`: Whether to generate a non buffered request that takes owhership of the response stream. The default value is `false`.
- `x-az-struct`: Indicates whether a model is struct or not. The default value is `false`.
- `x-az-nullable-array`:  Allows list to be null. The default value is `false`.
- `x-az-internal`: x-ms-external is only allowed on definitions so this does the same for parameters, etc.

### AutoRest plugin configuration
The AutoRest example at https://github.com/Azure/autorest-extension-helloworld
walks through the following section and the docs at
http://azure.github.io/autorest/user/literate-file-formats/configuration.html
and https://github.com/Azure/autorest/tree/master/docs are the
closest I could find to official explanations.

``` yaml

#
# Tell AutoRest about the plugin and how to invoke it
#
pipeline:
    azure-track2-csharp-generator:
        # Add `azure-track2-csharp: true` in config
        # or pass `--azure-track2-csharp` to the CLI
        scope: azure-track2-csharp
        input: swagger-document/individual/transform
#
# Everything else configures AutoRest to save any files we write out
#
        output-artifact: azure-track2-csharp-generator-code
    azure-track2-csharp-generator/emitter:
        input: azure-track2-csharp-generator
        scope: scope-azure-track2-csharp-generator/emitter
scope-azure-track2-csharp-generator/emitter:
    input-artifact: azure-track2-csharp-generator-code
    output-uri-expr: $key
output-artifact: azure-track2-csharp-generator-code

```


![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Common%2Fswagger%2FGenerator%2Freadme.png)
