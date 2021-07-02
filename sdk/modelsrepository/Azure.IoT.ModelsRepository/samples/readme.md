# IoT Models Repository Samples

The Azure IoT Models Repository enables builders to manage and share digital twin models for global consumption. The models are [JSON-LD][json_ld_reference] documents defined using the Digital Twins Definition Language ([DTDL][dtdlv2_reference]).

For more info about the Azure IoT Models Repository checkout the [docs][modelsrepository_msdocs].

## Introduction

You can explore the models repository APIs with the client library using the samples project.

The samples project demonstrates the following:

- Instantiate the client
- Get models and their dependencies from either a remote endpoint or local repository.
- Integration with the Digital Twins Model Parser

## Initializing the models repository client

```C# Snippet:ModelsRepositorySamplesCreateServiceClientWithGlobalEndpoint
// When no URI is provided for instantiation, the Azure IoT Models Repository global endpoint
// https://devicemodels.azure.com/ is used and the model dependency resolution
// configuration is set to TryFromExpanded.
var client = new ModelsRepositoryClient(new ModelsRepositoryClientOptions());
Console.WriteLine($"Initialized client pointing to global endpoint: {client.RepositoryUri}");
```

```C# Snippet:ModelsRepositorySamplesCreateServiceClientWithLocalRepository
// The client will also work with a local filesystem URI. This example shows initalization
// with a local URI and disabling model dependency resolution.
client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository),
    new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.Disabled));
Console.WriteLine($"Initialized client pointing to local path: {client.RepositoryUri}");
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

// The output of GetModelsAsync() will include at least the definition for the target dtmi.
// If the model dependency resolution configuration is not disabled, then models in which the
// target dtmi depends on will also be included in the returned IDictionary<string, string>.
var dtmi = "dtmi:com:example:TemperatureController;1";
IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);

// In this case the above dtmi has 2 model dependencies.
// dtmi:com:example:Thermostat;1 and dtmi:azure:DeviceManagement:DeviceInformation;1
Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");
```

GitHub pull-request workflows are a core aspect of the IoT Models Repository service. To submit models, the user is expected to fork and clone the global [models repository project][modelsrepository_github_repo] then iterate against the local copy. Changes would then be pushed to the fork (ideally in a new branch) and a PR created against the global repository.

To support this workflow and similar use cases, the client supports initialization with a local file-system URI. You can use this for example, to test and ensure newly added models to the locally cloned models repository are in their proper locations.

```C# Snippet:ModelsRepositorySamplesGetModelsFromLocalRepoAsync
// Local sample repository client
var client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));

// The output of GetModelsAsync() will include at least the definition for the target dtmi.
// If the model dependency resolution configuration is not disabled, then models in which the
// target dtmi depends on will also be included in the returned IDictionary<string, string>.
var dtmi = "dtmi:com:example:TemperatureController;1";
IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);

// In this case the above dtmi has 2 model dependencies.
// dtmi:com:example:Thermostat;1 and dtmi:azure:DeviceManagement:DeviceInformation;1
Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");
```

You are also able to get definitions for multiple root models at a time by leveraging
the `GetModels` overload that supports an `IEnumerable`.

```C# Snippet:ModelsRepositorySamplesGetMultipleModelsFromGlobalRepoAsync
// Global endpoint client
var client = new ModelsRepositoryClient();

// When given an IEnumerable of dtmis, the output of GetModelsAsync() will include at 
// least the definitions of each dtmi enumerated in the IEnumerable.
// If the model dependency resolution configuration is not disabled, then models in which each
// enumerated dtmi depends on will also be included in the returned IDictionary<string, string>.
var dtmis = new[] { "dtmi:com:example:TemperatureController;1", "dtmi:com:example:azuresphere:sampledevice;1" };
IDictionary<string, string> models = await client.GetModelsAsync(dtmis).ConfigureAwait(false);

// In this case the dtmi "dtmi:com:example:TemperatureController;1" has 2 model dependencies
// and the dtmi "dtmi:com:example:azuresphere:sampledevice;1" has no additional dependencies.
// The returned IDictionary will include 4 models.
Console.WriteLine($"Dtmis {string.Join(", ", dtmis)} resolved in {models.Count} interfaces.");
```

## Digital Twins Model Parser Integration

The samples provide two different patterns to integrate with the Digital Twins Model Parser.

The following snippet shows first fetching model definitions from the Azure IoT Models Repository then parsing them.

```C# Snippet:ModelsRepositorySamplesParserIntegrationGetModelsAndParseAsync
var client = new ModelsRepositoryClient();
var dtmi = "dtmi:com:example:TemperatureController;1";
IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);
var parser = new ModelParser();
IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(models.Values.ToArray());
Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces with {parseResult.Count} entities.");
```

Alternatively, the following snippet shows parsing a model, then fetching dependent model definitions during parsing.
This is achieved by configuring the `ModelParser` to use the sample [ParserDtmiResolver][modelsrepository_sample_extension] client extension.

```C# Snippet:ModelsRepositorySamplesParserIntegrationParseAndGetModelsAsync
var client = new ModelsRepositoryClient(new ModelsRepositoryClientOptions(dependencyResolution: ModelDependencyResolution.Disabled));
var dtmi = "dtmi:com:example:TemperatureController;1";
IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);
var parser = new ModelParser
{
    // Usage of the ModelsRepositoryClientExtensions.ParserDtmiResolver extension.
    DtmiResolver = client.ParserDtmiResolver
};
IReadOnlyDictionary<Dtmi, DTEntityInfo> parseResult = await parser.ParseAsync(models.Values.Take(1).ToArray());
Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces with {parseResult.Count} entities.");
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
[modelsrepository_msdocs]: https://docs.microsoft.com/azure/iot-pnp/concepts-model-repository
[modelsrepository_publish_msdocs]: https://docs.microsoft.com/azure/iot-pnp/concepts-model-repository#publish-a-model
[modelsrepository_iot_endpoint]: https://devicemodels.azure.com/
[json_ld_reference]: https://json-ld.org
[dtdlv2_reference]: https://github.com/Azure/opendigitaltwins-dtdl/blob/master/DTDL/v2/dtdlv2.md
[azure_core_transport]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Pipeline.md
[azure_core_diagnostics]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[azure_core_configuration]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Configuration.md
