// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    /// <summary>
    /// Test all APIs of the ConfigurationsClient.
    /// </summary>
    public class ConfigurationsClientTests : E2eTestBase
    {
        /// <summary>
        /// All this test class does is to make sure the call comes back with a response.
        /// This test is not responsible to make sure the values that come back are accurate as that would be testing the service logic.
        /// </summary>
        public ConfigurationsClientTests(bool isAsync)
            : base(isAsync)
        {
        }

        /// <summary>
        /// Test basic lifecycle of a Twin Configuration.
        /// This test includes CRUD operations only.
        /// </summary>
        [Test]
        public async Task ConfigurationsClient_ConfigurationsLifecycle()
        {
            string testConfigurationId = $"configlifecycle{GetRandom()}";
            // Generate a random priority less than 100
            int testPriority = int.Parse(GetRandom());
            IotHubServiceClient client = GetClient();
            TwinConfiguration twinConfiguration = CreateTestConfig(testConfigurationId);
            TwinConfiguration createdConfig;

            try
            {
                // Create a twin configuration
                Response<TwinConfiguration> createResponse =
                    await client.Configurations.CreateOrUpdateConfigurationAsync(twinConfiguration);
                createdConfig = createResponse.Value;

                // Get twin configuration
                Response<TwinConfiguration> getResponse = await client.Configurations.GetConfigurationAsync(testConfigurationId).ConfigureAwait(false);

                getResponse.Value.Etag.Should().BeEquivalentTo(createdConfig.Etag, "ETag value should not have changed.");
                createdConfig = createResponse.Value;

                // Update a configuration
                createdConfig.Priority = testPriority;
                Response<TwinConfiguration> updatedConfig = await client.Configurations.CreateOrUpdateConfigurationAsync(createdConfig, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
                Assert.AreEqual(updatedConfig.Value.Priority, testPriority, "Priority should have been updated.");
            }
            finally
            {
                // Delete twin configuration
                await Cleanup(client, twinConfiguration);
            }
        }

        /// <summary>
        /// Test get configurations
        /// </summary>
        [Test]
        public async Task ConfigurationsClient_GetConfigurations()
        {
            const int configurationsCount = 5;
            TwinConfiguration[] twinConfigurations = new TwinConfiguration[configurationsCount];
            TwinConfiguration[] createdConfigurations = new TwinConfiguration[configurationsCount];
            IReadOnlyList<TwinConfiguration> listConfigurations;
            IotHubServiceClient client = GetClient();
            try
            {
                for (int i = 0; i < configurationsCount; i++)
                {
                    twinConfigurations[i] = CreateTestConfig($"testconfigurations{i}{GetRandom()}");

                    // Create Configurations
                    Response<TwinConfiguration> createResponse =
                        await client.Configurations.CreateOrUpdateConfigurationAsync(twinConfigurations[i]).ConfigureAwait(false);
                    createdConfigurations[i] = createResponse.Value;
                }

                // List the configurations for the client
                listConfigurations = (await client.Configurations.GetConfigurationsAsync().ConfigureAwait(false)).Value;

                IEnumerable<string> twinConfigurationsIds = listConfigurations.ToList().Select(configuration => configuration.Id);

                // Compare the response ids with created configurations
                for (int i = 0; i < configurationsCount; i++)
                {
                    Assert.IsTrue(twinConfigurationsIds.Contains(twinConfigurations[i].Id));
                }
            }
            finally
            {
                for (int i = 0; i < configurationsCount; i++)
                    await Cleanup(client, twinConfigurations[i]);
            }
        }

        private async Task Cleanup(IotHubServiceClient client, TwinConfiguration config)
        {
            // cleanup
            try
            {
                if (config != null)
                {
                    await client.Configurations.DeleteConfigurationAsync(config, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test clean up failed: {ex.Message}");
            }
        }

        private TwinConfiguration CreateTestConfig(string testConfigurationId)
        {
            TwinConfiguration twinConfiguration =
                new TwinConfiguration
                {
                    Id = testConfigurationId
                };

            ChangeTrackingDictionary<string, object> deviceContent = new ChangeTrackingDictionary<string, object>();
            deviceContent["properties.desired.deviceContent_key"] = "deviceContent_value-" + twinConfiguration.Id;

            // Labels are optional but adding here due to null check failure in deserialization
            twinConfiguration.Labels.Add("HostPlatform", Environment.OSVersion.ToString());
            twinConfiguration.Content = new ConfigurationContent();
            twinConfiguration.Content.DeviceContent.Add("properties.desired.deviceContent_key", "deviceContent_value-" + twinConfiguration.Id);

            // Specifying '*' to target all devices
            twinConfiguration.TargetCondition = "*";
            // Assign any integer value for priority
            twinConfiguration.Priority = int.Parse(GetRandom());
            return twinConfiguration;
        }
    }
}
