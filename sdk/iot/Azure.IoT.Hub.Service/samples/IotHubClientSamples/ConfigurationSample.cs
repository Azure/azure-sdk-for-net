// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.IoT.Hub.Service.Models;

namespace Azure.IoT.Hub.Service.Samples
{
    /// <summary>
    /// This sample goes through the usage of Configuration on the IoT Hub.
    /// </summary>
    internal class ConfigurationSample
    {
        public readonly IotHubServiceClient IoTHubServiceClient;
        public const int MaxRandomValue = 200;
        public static readonly Random Random = new Random();

        public ConfigurationSample(IotHubServiceClient client)
        {
            IoTHubServiceClient = client;
        }

        public async Task RunSampleAsync()
        {
            string testConfigurationId = $"configuration{Random.Next(MaxRandomValue)}";
            TwinConfiguration twinConfiguration = CreateSampleConfig(testConfigurationId);

            // Create a Twin Configuration.
            await CreateConfigurationAsync(twinConfiguration);

            // Get the Twin Configuration.
            await GetConfigurationAsync(twinConfiguration);

            // Update the Twin Configuration.
            await UpdateConfigurationAsync(twinConfiguration);

            // Delete the Twin Configuration.
            await DeleteConfigurationAsync(twinConfiguration);
        }

        /// <summary>
        /// Creates a new twin configuration.
        /// </summary>
        /// <param name="twinConfiguration">Twin Configuration to create.</param>
        public async Task<TwinConfiguration> CreateConfigurationAsync(TwinConfiguration twinConfiguration)
        {
            SampleLogger.PrintHeader("CREATE TWIN CONFIGURATION");
            TwinConfiguration createdConfig;

            try
            {
                // Create a twin configuration
                #region Snippet:IotHubCreateConfiguration
                Response<TwinConfiguration> createResponse = await IoTHubServiceClient.Configurations
                    .CreateOrUpdateConfigurationAsync(twinConfiguration)
                    .ConfigureAwait(false);
                createdConfig = createResponse.Value;

                Console.WriteLine($"Successfully created a new configuration with Id: '{createdConfig.Id}', ETag: '{createdConfig.Etag}'");

                #endregion Snippet:IotHubCreateConfiguration

                return createdConfig;
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await DeleteConfigurationAsync(twinConfiguration);
                SampleLogger.FatalError($"Failed to create twin configuration due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Get a twin configuration.
        /// </summary>
        /// <param name="twinConfiguration">Twin Configuration</param>
        public async Task<TwinConfiguration> GetConfigurationAsync(TwinConfiguration twinConfiguration)
        {
            SampleLogger.PrintHeader("GET A CONFIGURATION");

            try
            {
                Console.WriteLine($"Getting twin configuration with Id: '{twinConfiguration.Id}'\n");

                #region Snippet:IotHubGetConfiguration

                Response<TwinConfiguration> getResponse = await IoTHubServiceClient.Configurations
                    .GetConfigurationAsync(twinConfiguration.Id)
                    .ConfigureAwait(false);

                TwinConfiguration responseConfiguration = getResponse.Value;

                SampleLogger.PrintSuccess($"Configuration Id: '{responseConfiguration.Id}', ETag: '{responseConfiguration.Etag}'");

                #endregion Snippet:IotHubGetConfiguration

                return responseConfiguration;
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await DeleteConfigurationAsync(twinConfiguration);
                SampleLogger.FatalError($"Failed to get a twin configuration due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Update a twin configuration.
        /// </summary>
        /// <param name="twinConfiguration">Twin Configuration to to be updated.</param>
        public async Task<TwinConfiguration> UpdateConfigurationAsync(TwinConfiguration twinConfiguration)
        {
            SampleLogger.PrintHeader("UPDATE A CONFIGURATION");

            try
            {
                #region Snippet:IotHubUpdateConfiguration

                twinConfiguration.Priority = Random.Next(MaxRandomValue);
                Console.WriteLine($"Updating twin configuration with Id: '{twinConfiguration.Id}''s priority to: '{twinConfiguration.Priority}'");
                Response<TwinConfiguration> response = await IoTHubServiceClient.Configurations
                    .CreateOrUpdateConfigurationAsync(twinConfiguration, IfMatchPrecondition.UnconditionalIfMatch)
                    .ConfigureAwait(false);

                TwinConfiguration updatedConfiguration = response.Value;

                SampleLogger.PrintSuccess($"Successfully updated twin configuration: Id: '{updatedConfiguration.Id}', Priority: '{updatedConfiguration.Priority}', ETag: '{updatedConfiguration.Etag}'");

                #endregion Snippet:IotHubUpdateConfiguration

                return updatedConfiguration;
            }
            catch (Exception ex)
            {
                // Try to cleanup before exiting with fatal error.
                await DeleteConfigurationAsync(twinConfiguration);
                SampleLogger.FatalError($"Failed to update a twin configuration due to:\n{ex}");
                throw;
            }
        }

        /// <summary>
        /// Deletes a twin configuration.
        /// </summary>
        /// <param name="twinConfiguration">Twin Configuration to delete.</param>
        public async Task DeleteConfigurationAsync(TwinConfiguration twinConfiguration)
        {
            SampleLogger.PrintHeader("DELETE A CONFIGURATION");

            try
            {
                Console.WriteLine($"Deleting twin configuration with Id: '{twinConfiguration.Id}'");

                #region Snippet:IotHubDeleteConfiguration

                Response response = await IoTHubServiceClient.Configurations
                    .DeleteConfigurationAsync(twinConfiguration, IfMatchPrecondition.UnconditionalIfMatch)
                    .ConfigureAwait(false);

                SampleLogger.PrintSuccess($"Successfully deleted twin configuration with Id: '{twinConfiguration.Id}'");

                #endregion Snippet:IotHubDeleteConfiguration
            }
            catch (Exception ex)
            {
                SampleLogger.FatalError($"Failed to delete twin configuration due to:\n{ex}");
            }
        }

        private TwinConfiguration CreateSampleConfig(string testConfigurationId)
        {
            var twinConfiguration = new TwinConfiguration
            {
                Id = testConfigurationId,
                Labels =
                {
                    { "HostPlatform", "SomeValue" },
                },
                TargetCondition = "*",
                Priority = Random.Next(MaxRandomValue),
            };

            twinConfiguration.Content = new ConfigurationContent();
            twinConfiguration.Content.DeviceContent.Add("properties.desired.deviceContent_key", $"deviceContent_value-{twinConfiguration.Id}");

            return twinConfiguration;
        }
    }
}
