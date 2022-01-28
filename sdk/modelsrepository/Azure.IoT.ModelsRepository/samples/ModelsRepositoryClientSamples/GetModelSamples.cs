// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Samples
{
    internal class GetModelSamples
    {
        private static string ClientSamplesDirectoryPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string ClientSamplesLocalModelsRepository => Path.Combine(ClientSamplesDirectoryPath, "SampleModelsRepo");

        public static void ClientInitialization()
        {
            #region Snippet:ModelsRepositorySamplesCreateServiceClientWithGlobalEndpoint

            // When no URI is provided for instantiation, the Azure IoT Models Repository global endpoint
            // https://devicemodels.azure.com/ is used.
            var client = new ModelsRepositoryClient(new ModelsRepositoryClientOptions());
            Console.WriteLine($"Initialized client pointing to the global endpoint: {client.RepositoryUri.AbsoluteUri}");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientWithGlobalEndpoint

            #region Snippet:ModelsRepositorySamplesCreateServiceClientWithCustomEndpoint

            // This form shows specifing a custom URI for the models repository with default client options.
            const string remoteRepoEndpoint = "https://contoso.com/models";
            client = new ModelsRepositoryClient(new Uri(remoteRepoEndpoint));
            Console.WriteLine($"Initialized client pointing to a custom endpoint: {client.RepositoryUri.AbsoluteUri}");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientWithCustomEndpoint

            #region Snippet:ModelsRepositorySamplesCreateServiceClientWithLocalRepository

            // The client will also work with a local filesystem URI.
            client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));
            Console.WriteLine($"Initialized client pointing to a local path: {client.RepositoryUri.LocalPath}");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientWithLocalRepository

            #region Snippet:ModelsRepositorySamplesCreateServiceClientConfigureMetadataClientOption

            // ModelsRepositoryClientOptions supports configuration enabling consumption of repository
            // metadata within ModelsRepositoryClientOptions.RepositoryMetadata.
            // Fetching repository metadata is enabled by default.
            // This can be disabled as shown in the following snippet
            var customClientOptions = new ModelsRepositoryClientOptions();
            customClientOptions.RepositoryMetadata.IsMetadataProcessingEnabled = false;
            client = new ModelsRepositoryClient(options: customClientOptions);
            Console.WriteLine($"Initialized client with disabled metadata fetching pointing " +
                $"to the global endpoint: {client.RepositoryUri.AbsoluteUri}.");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientConfigureMetadataClientOption
        }

        public static async Task GetModelFromGlobalRepoAsync()
        {
            #region Snippet:ModelsRepositorySamplesGetModelsFromGlobalRepoAsync

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

            #endregion Snippet:ModelsRepositorySamplesGetModelsFromGlobalRepoAsync
        }

        public static async Task GetModelDisabledDependencyResolution()
        {
            #region Snippet:ModelsRepositorySamplesGetModelsDisabledDependencyResolution

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

            #endregion Snippet:ModelsRepositorySamplesGetModelsDisabledDependencyResolution
        }

        public static async Task GetModelFromLocalRepoAsync()
        {
            #region Snippet:ModelsRepositorySamplesGetModelsFromLocalRepoAsync

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

            #endregion Snippet:ModelsRepositorySamplesGetModelsFromLocalRepoAsync
        }

        public static async Task TryGetModelFromGlobalRepoButNotFoundAsync()
        {
            var client = new ModelsRepositoryClient();
            var dtmi = "dtmi:com:example:NotFound;1";

            try
            {
                ModelResult result = await client.GetModelAsync(dtmi).ConfigureAwait(false);
                Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces.");
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                Console.WriteLine($"{dtmi} was not found in the default public models repository: {ex.Message}");
            }
        }

        public static async Task TryGetModelFromLocalRepoButNotFoundAsync()
        {
            var client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));
            var dtmi = "dtmi:com:example:NotFound;1";

            try
            {
                ModelResult result = await client.GetModelAsync(dtmi).ConfigureAwait(false);
                Console.WriteLine($"{dtmi} resolved in {result.Content.Count} interfaces.");
            }
            catch (RequestFailedException ex) when (ex.InnerException is FileNotFoundException)
            {
                Console.WriteLine($"{dtmi} was not found in the default public models repository: {ex.Message}");
            }
        }

        public static async Task TryGetModelsWithInvalidDtmiAsync()
        {
            var invalidDtmi = "dtmi:com:example:InvalidDtmi";

            // Model resolution will fail with invalid dtmis
            var client = new ModelsRepositoryClient();
            try
            {
                await client.GetModelAsync(invalidDtmi);
            }
            catch (ArgumentException ex)
            {
                // Invalid DTMI format "dtmi:com:example:InvalidDtmi".
                Console.WriteLine(ex);
            }
        }
    }
}
