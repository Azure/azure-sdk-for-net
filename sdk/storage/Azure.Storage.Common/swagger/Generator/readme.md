# azure-track2-csharp
An early code generator for Track 2 C# client libraries on top of Azure.Core.

### Autorest plugin configuration
The AutoRest example at https://github.com/Azure/autorest-extension-helloworld
walks through the following section and the docs at
http://azure.github.io/autorest/user/literate-file-formats/configuration.html
and https://github.com/Azure/autorest/tree/garrett/docs/developer are the
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
        # There's no `input:` section because we process the raw swagger

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
