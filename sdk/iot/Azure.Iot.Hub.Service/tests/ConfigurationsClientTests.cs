// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Random _random = new Random();

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
            //{GetRandom()}
            string testConfigurationId = "testConfiguration";
            // Generate a random priority less than 100
            int testPriority = _random.Next(100);
            IotHubServiceClient client = GetClient();
            TwinConfiguration configuration = null;

            try
            {
                // Create a twin configuration
                Response<TwinConfiguration>  createResponse =
                    await client.Configurations.CreateOrUpdateConfigurationAsync(
                    new TwinConfiguration
                    {
                        Id = testConfigurationId
                    }).ConfigureAwait(false);

                configuration = createResponse.Value;

                // Get twin configuration
                Response<TwinConfiguration> getResponse = await client.Configurations.GetConfigurationAsync(testConfigurationId).ConfigureAwait(false);

                getResponse.Value.Etag.Should().BeEquivalentTo(configuration.Etag, "ETag value should not have changed.");

                configuration = createResponse.Value;

                // Update a configuration
                configuration.Priority = testPriority;

                Response<TwinConfiguration> updateResponse = await client.Configurations.CreateOrUpdateConfigurationAsync(configuration, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);

                Assert.AreEqual(updateResponse.Value.Priority, testPriority, "Priority should have been updated.");

            }
            finally
            {
                // Delete twin configuration
                await Cleanup(client, configuration);
            }
        }

        /// <summary>
        /// Test get configurations
        /// </summary>
        [Test]
        public async Task ConfigurationsClient_GetConfigurations()
        {
            int configurationsCount = 5;
            string[] testConfigurationIds = new string[configurationsCount];
            for (int i = 0; i < configurationsCount; i++)
            {
                testConfigurationIds[i] = $"GetConfigurations{i}{GetRandom()}";
            }

            IotHubServiceClient client = GetClient();
            TwinConfiguration[] configurations = null;

            try
            {
                // Create a twin configuration
                for (int i = 0; i < configurationsCount; i++)
                {
                    Response<TwinConfiguration> createResponse =
                    await client.Configurations.CreateOrUpdateConfigurationAsync(
                    new TwinConfiguration
                    {
                        Id = testConfigurationIds[i]
                    }).ConfigureAwait(false);
                    configurations[i] = createResponse.Value;
                }

                // List the modules on the test device
                IReadOnlyList<TwinConfiguration> twinConfigurations = (await client.Configurations.GetConfigurationsAsync(configurationsCount).ConfigureAwait(false)).Value;

                IEnumerable<string> twinConfigurationsIds = twinConfigurations.ToList().Select(configuration => configuration.Id);

                Assert.AreEqual(configurationsCount, twinConfigurations.Count);
                for (int i = 0; i < configurationsCount; i++)
                {
                    Assert.IsTrue(twinConfigurationsIds.Contains(testConfigurationIds[i]));
                }
            }
            finally
            {
                for (int i = 0; i < configurationsCount; i++)
                {
                   // await Cleanup(client, configurations[i]);
                }
            }
        }

        private async Task Cleanup(IotHubServiceClient client, TwinConfiguration twinConfiguration)
        {
            // cleanup
            try
            {
                if (twinConfiguration != null)
                {
                    await client.Configurations.DeleteConfigurationAsync(twinConfiguration, IfMatchPrecondition.UnconditionalIfMatch).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Test clean up failed: {ex.Message}");
            }
        }
    }
}
