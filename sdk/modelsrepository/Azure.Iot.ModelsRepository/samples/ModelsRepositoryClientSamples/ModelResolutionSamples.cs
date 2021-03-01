// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository.Samples
{
    internal class ModelResolutionSamples
    {
        private static string ClientSamplesDirectoryPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string ClientSamplesLocalModelsRepository => Path.Combine(ClientSamplesDirectoryPath, "SampleModelsRepo");

        public static void ClientInitialization()
        {
            // When no Uri is provided for instantiation. The global Azure IoT Models Repository endpoint is used
            // and the dependency model resolution option is set to TryFromExpanded.
            var client = new ModelsRepositoryClient();
            Console.WriteLine($"Initialized client pointing to global endpoint: {client.RepositoryUri}");

            // This form shows specifing a custom Uri for the models repository with default client options.
            // The default client options will enable model dependency resolution.
            const string remoteRepoEndpoint = "https://contoso.com/models";
            client = new ModelsRepositoryClient(new Uri(remoteRepoEndpoint));
            Console.WriteLine($"Initialized client pointing to custom endpoint: {client.RepositoryUri}");

            // The client will also work with a local filesystem Uri. This example shows initalization
            // with a local Uri and disabling model dependency resolution.
            client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository),
                new ModelsRepositoryClientOptions(resolutionOption: DependencyResolutionOption.Disabled));
            Console.WriteLine($"Initialized client pointing to local path: {client.RepositoryUri}");
        }

        public static async Task GetModelsFromGlobalRepoAsync()
        {
            var dtmi = "dtmi:com:example:TemperatureController;1";

            // Global endpoint client
            var client = new ModelsRepositoryClient();

            // The output of GetModelsAsync() will include at least the definition for the target dtmi.
            // If the dependency model resolution option is not disabled, then models in which the
            // target dtmi depends on will also be included in the returned IDictionary<string, string>.
            IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);

            // In this case the above dtmi has 2 model dependencies.
            // dtmi:com:example:Thermostat;1 and dtmi:azure:DeviceManagement:DeviceInformation;1
            Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");
        }

        public static async Task GetModelsFromLocalRepoAsync()
        {
            var dtmi = "dtmi:com:example:TemperatureController;1";

            // Local sample repository client
            var client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));

            // The output of GetModelsAsync() will include at least the definition for the target dtmi.
            // If the dependency model resolution option is not disabled, then models in which the
            // target dtmi depends on will also be included in the returned IDictionary<string, string>.
            IDictionary<string, string> models = await client.GetModelsAsync(dtmi).ConfigureAwait(false);

            // In this case the above dtmi has 2 model dependencies.
            // dtmi:com:example:Thermostat;1 and dtmi:azure:DeviceManagement:DeviceInformation;1
            Console.WriteLine($"{dtmi} resolved in {models.Count} interfaces.");
        }

        public static async Task TryGetModelsFromGlobalRepoButNotFoundAsync()
        {
            var dtmi = "dtmi:com:example:NotFound;1";
            var client = new ModelsRepositoryClient();

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
            var dtmi = "dtmi:com:example:NotFound;1";
            var client = new ModelsRepositoryClient(new Uri(ClientSamplesLocalModelsRepository));

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
