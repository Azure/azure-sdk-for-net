# IoT Models Repository Samples

The Azure IoT Models Repository enables builders to manage and share digital twin models for global consumption. The models are [JSON-LD][json_ld_reference] documents defined using the Digital Twins Definition Language ([DTDL][dtdlv2_reference]).

For more info about the Azure IoT Models Repository checkout the [docs][modelsrepository_msdocs].

## Introduction

You can explore the models repository APIs with the client library using the samples project.

The samples project demonstrates the following:

- Instantiating the client
- Get models and their dependencies from either a remote endpoint or local repository.
- Integration with the Digital Twins Model Parser

## Initializing the models repository client

```C# Snippet:ModelsRepositorySamplesCreateServiceClientWithGlobalEndpoint
// When no URI is provided for instantiation, the Azure IoT Models Repository global endpoint
// https://devicemodels.azure.com/ is used.
var client = new ModelsRepositoryClient(new ModelsRepositoryClientOptions());
Console.WriteLine($"Initialized client pointing to the global endpoint: {client.RepositoryUri.AbsoluteUri}");
```

```C# Snippet:ModelsRepositorySamplesCreateServiceClientWithCustomEndpoint
// This form shows specifing a custom URI for the models repository with default client options.
const string remoteRepoEndpoint = "https://contoso.com/models";
client = new ModelsRepositoryClient(new Uri(remoteRepoEndpoint));
Console.WriteLine($"Initialized client pointing to a custom endpoint: {client.RepositoryUri.AbsoluteUri}");
```

```C# Snippet:ModelsRepositorySamplesCreateServiceClientWithLocalRepository
// The client will also work with a local filesystem URI.
client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));
Console.WriteLine($"Initialized client pointing to a local path: {client.RepositoryUri.LocalPath}");
```

### Repository metadata

Models repositories that implement Azure IoT conventions can **optionally** include a `metadata.json` file at the root of the repository.
The `metadata.json` file provides key attributes of a repository including the features that it provides.
A client can use the repository metadata to make decisions around how to optimally handle an operation.

The following snippet shows how to configure the client to disable repository metadata processing:

```C# Snippet:ModelsRepositorySamplesCreateServiceClientConfigureMetadataClientOption
// ModelsRepositoryClientOptions supports configuration enabling consumption of repository
// metadata within ModelsRepositoryClientOptions.RepositoryMetadata.
// Fetching repository metadata is enabled by default.
// This can be disabled as shown in the following snippet
var customClientOptions = new ModelsRepositoryClientOptions();
customClientOptions.RepositoryMetadata.IsMetadataProcessingEnabled = false;
client = new ModelsRepositoryClient(options: customClientOptions);
Console.WriteLine($"Initialized client with disabled metadata fetching pointing " +
    $"to the global endpoint: {client.RepositoryUri.AbsoluteUri}.");
```

### Override options

If you need to override pipeline behavior, such as provide your own `HttpClient` instance, you can do that via constructor that takes a [ModelsRepositoryClientOptions][modelsrepository_clientoptions] parameter.
It provides an opportunity to override default behavior including:

- Overriding [transport][azure_core_transport]
- Enabling [diagnostics][azure_core_diagnostics]
- Controlling [retry strategy](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md)

## Publish Models

Publishing models to the models repository requires [exercising][modelsrepository_publish_msdocs] common GitHub workflows.

## Get Models

After publishing, your model(s) will be available for consumption from the global repository endpoint. The following snippet shows how to retrieve the corresponding JSON-LD content.

```C# Snippet:ModelsRepositorySamplesGetModelsFromGlobalRepoAsync
// Global endpoint client
var client = new ModelsRepositoryClient();

// The returned ModelResult from GetModelAsync() will include at least the definition for the target dtmi
// within the contained content dictionary.
// If model dependency resolution is enabled (the default), then models in which the
// target dtmi depends on will also be included.
var dtmi = "dtmi:com:example:TemperatureController;1";
ModelResult result = await client.GetModelAsync(dtmi).ConfigureAwait(false);

// In this case the above dtmi has 2 model dependencies.
// dtmi:com:example:Thermostat;1 and dtmi:azure:DeviceManagement:DeviceInformation;1
Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces.");
```

GitHub pull-request workflows are a core aspect of the IoT Models Repository service. To submit models, the user is expected to fork and clone the global [models repository project][modelsrepository_github_repo] then iterate against the local copy. Changes would then be pushed to the fork (ideally in a new branch) and a PR created against the global repository.

To support this workflow and similar use cases, the client supports initialization with a local file-system URI. You can use this for example, to test and ensure newly added models to the locally cloned models repository are in their proper locations.

```C# Snippet:ModelsRepositorySamplesGetModelsFromLocalRepoAsync
// Local sample repository client
var client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));

// The output of GetModelAsync() will include at least the definition for the target dtmi.
// If the model dependency resolution configuration is not disabled, then models in which the
// target dtmi depends on will also be included in the returned ModelResult.Content dictionary.
var dtmi = "dtmi:com:example:TemperatureController;1";
ModelResult result = await client.GetModelAsync(dtmi).ConfigureAwait(false);

// In this case the above dtmi has 2 model dependencies.
// dtmi:com:example:Thermostat;1 and dtmi:azure:DeviceManagement:DeviceInformation;1
Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces.");
```

By default model dependency resolution is enabled. This can be changed by overriding the default
value for the `dependencyResolution` parameter of the `GetModels` operation.

```C# Snippet:ModelsRepositorySamplesGetModelsDisabledDependencyResolution
// Global endpoint client
var client = new ModelsRepositoryClient();

// In this example model dependency resolution is disabled by passing in ModelDependencyResolution.Disabled
// as the value for the dependencyResolution parameter of GetModelAsync(). By default the parameter has a value
// of ModelDependencyResolution.Enabled.
// When model dependency resolution is disabled, only the input dtmi(s) will be processed and
// model dependencies (if any) will be ignored.
var dtmi = "dtmi:com:example:TemperatureController;1";
ModelResult result = await client.GetModelAsync(dtmi, ModelDependencyResolution.Disabled).ConfigureAwait(false);

// In this case the above dtmi has 2 model dependencies but are not returned
// due to disabling model dependency resolution.
Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces.");
```

## Digital Twins Model Parser Integration

The samples provide two different patterns to integrate with the Digital Twins Model Parser.

The following snippet shows first fetching model definitions from the Azure IoT Models Repository then parsing them.

```C# Snippet:ModelsRepositorySamplesParserIntegrationGetModelsAndParseAsync
var client = new ModelsRepositoryClient();
var dtmi = "dtmi:com:example:TemperatureController;1";
ModelResult result = await client.GetModelAsync(dtmi).ConfigureAwait(false);
var parser = new ModelParser();
IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(result.Content.Values);
Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces with {parseResult.Count} entities.");
```

Alternatively, the following snippet shows parsing a model, then fetching dependent model definitions during parsing.
This is achieved by configuring the `ModelParser` to use the sample [ParserDtmiResolver][modelsrepository_sample_extension] client extension.

```C# Snippet:ModelsRepositorySamplesParserIntegrationParseAndGetModelsAsync
var client = new ModelsRepositoryClient();
var dtmi = "dtmi:com:example:TemperatureController;1";
ModelResult result = await client.GetModelAsync(dtmi, ModelDependencyResolution.Disabled).ConfigureAwait(false);
var parser = new ModelParser
{
    // Usage of the ModelsRepositoryClientExtensions.ParserDtmiResolver extension.
    DtmiResolver = client.ParserDtmiResolver
};
IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(result.Content.Values);
Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces with {parseResult.Count} entities.");
```

## DtmiConventions utility functions

The IoT Models Repository applies a set of conventions for organizing digital twin models. This package exposes a class
called `DtmiConventions` which exposes utility functions supporting these conventions. These same functions are used throughout the client.

```C# Snippet:ModelsRepositorySamplesDtmiConventionsIsValidDtmi
// This snippet shows how to validate a given DTMI string is well-formed.

// Returns true
DtmiConventions.IsValidDtmi("dtmi:com:example:Thermostat;1");

// Returns false
DtmiConventions.IsValidDtmi("dtmi:com:example:Thermostat");
```

```C# Snippet:ModelsRepositorySamplesDtmiConventionsGetModelUri
// This snippet shows obtaining a fully qualified path to a model file.

// Local repository example
Uri localRepositoryUri = new Uri("file:///path/to/repository/");
string fullyQualifiedModelPath =
    DtmiConventions.GetModelUri("dtmi:com:example:Thermostat;1", localRepositoryUri).AbsolutePath;

// Prints '/path/to/repository/dtmi/com/example/thermostat-1.json'
Console.WriteLine(fullyQualifiedModelPath);

// Remote repository example
Uri remoteRepositoryUri = new Uri("https://contoso.com/models/");
fullyQualifiedModelPath =
    DtmiConventions.GetModelUri("dtmi:com:example:Thermostat;1", remoteRepositoryUri).AbsoluteUri;

// Prints 'https://contoso.com/models/dtmi/com/example/thermostat-1.json'
Console.WriteLine(fullyQualifiedModelPath);
```

<!-- LINKS -->
[modelsrepository_github_repo]: https://github.com/Azure/iot-plugandplay-models
[modelsrepository_sample_extension]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/modelsrepository/Azure.IoT.ModelsRepository/samples/ModelsRepositoryClientSamples/ModelsRepositoryClientExtensions.cs
[modelsrepository_clientoptions]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/modelsrepository/Azure.IoT.ModelsRepository/src/ModelsRepositoryClientOptions.cs
[modelsrepository_msdocs]: https://learn.microsoft.com/azure/iot-pnp/concepts-model-repository
[modelsrepository_publish_msdocs]: https://learn.microsoft.com/azure/iot-pnp/concepts-model-repository#publish-a-model
[modelsrepository_iot_endpoint]: https://devicemodels.azure.com/
[json_ld_reference]: https://json-ld.org
[dtdlv2_reference]: https://github.com/Azure/opendigitaltwins-dtdl/blob/master/DTDL/v2/dtdlv2.md
[azure_core_transport]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Pipeline.md
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[azure_core_configuration]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md
