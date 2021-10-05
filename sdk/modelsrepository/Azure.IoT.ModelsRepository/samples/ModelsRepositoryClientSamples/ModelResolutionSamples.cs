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
    internal class ModelResolutionSamples
    {
        private static string ClientSamplesDirectoryPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string ClientSamplesLocalModelsRepository => Path.Combine(ClientSamplesDirectoryPath, "SampleModelsRepo");

        public static void ClientInitialization()
        {
            #region Snippet:ModelsRepositorySamplesCreateServiceClientWithGlobalEndpoint

            // When no URI is provided for instantiation, the Azure IoT Models Repository global endpoint
            // https://devicemodels.azure.com/ is used.
            var client = new ModelsRepositoryClient(new ModelsRepositoryClientOptions());
            Console.WriteLine($"Initialized client pointing to global endpoint: {client.RepositoryUri.AbsoluteUri}");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientWithGlobalEndpoint

            #region Snippet:ModelsRepositorySamplesCreateServiceClientWithCustomEndpoint

            // This form shows specifing a custom URI for the models repository with default client options.
            const string remoteRepoEndpoint = "https://contoso.com/models";
            client = new ModelsRepositoryClient(new Uri(remoteRepoEndpoint));
            Console.WriteLine($"Initialized client pointing to custom endpoint: {client.RepositoryUri.AbsoluteUri}");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientWithCustomEndpoint

            #region Snippet:ModelsRepositorySamplesCreateServiceClientWithLocalRepository

            // The client will also work with a local filesystem URI.
            client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));
            Console.WriteLine($"Initialized client pointing to local path: {client.RepositoryUri.LocalPath}");

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientWithLocalRepository

            #region Snippet:ModelsRepositorySamplesCreateServiceClientConfigureMetadataClientOption

            // Specifying metadataExpiry in client options will set the minimum time span for which the client
            // will consider the initial fetched metadata state as stale.
            // When the client metadata state is stale, the next service operation that can make use of metadata
            // will first fetch and refresh the client metadata state. The operation will then continue as normal.
            var customClientOptions = new ModelsRepositoryClientOptions(metadataExpiry: TimeSpan.FromMinutes(30));
            client = new ModelsRepositoryClient(options: customClientOptions);

            #endregion Snippet:ModelsRepositorySamplesCreateServiceClientConfigureMetadataClientOption
        }

        public static async Task GetModelsFromGlobalRepoAsync()
        {
            #region Snippet:ModelsRepositorySamplesGetModelsFromGlobalRepoAsync

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

            #endregion Snippet:ModelsRepositorySamplesGetModelsFromGlobalRepoAsync
        }

        public static async Task GetModelsDisabledDependencyResolution()
        {
            #region Snippet:ModelsRepositorySamplesGetModelsDisabledDependencyResolution

            // Global endpoint client
            var client = new ModelsRepositoryClient();

            // In this example model dependency resolution is disabled by passing in ModelDependencyResolution.Disabled
            // as the value for the dependencyResolution parameter of GetModelsAsync(). By default the parameter has a value
            // of ModelDependencyResolution.Enabled.
            // When model dependency resolution is disabled, only the input dtmi(s) will be processed and
            // model dependencies (if any) will be ignored.
            var dtmi = "dtmi:com:example:TemperatureController;1";
            IDictionary<string, string> models = await client.GetModelsAsync(dtmi, ModelDependencyResolution.Disabled).ConfigureAwait(false);

            // In this case the above dtmi has 2 model dependencies but are not returned
            // due to disabling model dependency resolution.
            Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");

            #endregion Snippet:ModelsRepositorySamplesGetModelsDisabledDependencyResolution
        }

        public static async Task GetMultipleModelsFromGlobalRepoAsync()
        {
            #region Snippet:ModelsRepositorySamplesGetMultipleModelsFromGlobalRepoAsync

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

            #endregion Snippet:ModelsRepositorySamplesGetMultipleModelsFromGlobalRepoAsync
        }

        public static async Task GetModelsFromLocalRepoAsync()
        {
            #region Snippet:ModelsRepositorySamplesGetModelsFromLocalRepoAsync

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

            #endregion Snippet:ModelsRepositorySamplesGetModelsFromLocalRepoAsync
        }

        public static async Task TryGetModelsFromGlobalRepoButNotFoundAsync()
        {
            var client = new ModelsRepositoryClient();
            var dtmi = "dtmi:com:example:NotFound;1";

            try
            {
                IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);
                Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                Console.WriteLine($"{dtmi} was not found in the default public models repository: {ex.Message}");
            }
        }

        public static async Task TryGetModelsFromLocalRepoButNotFoundAsync()
        {
            var client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));
            var dtmi = "dtmi:com:example:NotFound;1";

            try
            {
                IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);
                Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");
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
                await client.GetModelsAsync(invalidDtmi);
            }
            catch (ArgumentException ex)
            {
                // Invalid DTMI format "dtmi:com:example:InvalidDtmi".
                Console.WriteLine(ex);
            }
        }
    }
}
