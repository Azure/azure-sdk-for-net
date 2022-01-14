// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.SipRouting.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.SipRouting.Tests.Samples
{
    public class Sample_ManageSipTrunkConfiguration : SipRoutingClientLiveTestBase
    {
        public Sample_ManageSipTrunkConfiguration(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        [SyncOnly]
        public void UpdateSipConfiguration()
        {
            var client = GetClient();
            #region Snippet:UpdateSipTrunkConfiguration
            // Update calling configuration for resource
            var trunks = new Dictionary<string, SipTrunk>
            {
                { "sbs1.contoso.com", new SipTrunk(1122) }
            };

            var routes = new List<SipTrunkRoute>
            {
                new SipTrunkRoute(
                    name: "Initial rule",
                    description: "Handle numbers starting with '+123'",
                    numberPattern : @"\+123[0-9]+",
                    trunks : new List<string>{ "sbs1.contoso.com" })
            };
            var configuration = new SipConfiguration() { Trunks = trunks, Routes = routes};
            var response = client.UpdateSipConfiguration(configuration);
            // Output:
            //
            #endregion Snippet:UpdateSipTrunkConfiguration

            Assert.AreEqual(200, response.GetRawResponse().Status);
            #region Snippet:UpdateTrunks
            // Update calling configuration for resource
            trunks = new Dictionary<string, SipTrunk>
            {
                { "sbs1.contoso.com", new SipTrunk(1122) },
                { "sbs2.contoso.com", new SipTrunk(8888) }
            };
            var response1 = client.UpdateSipConfiguration(trunks);
            // Output:
            //
            #endregion Snippet:UpdateTrunks
            Assert.AreEqual(200, response1.GetRawResponse().Status);

            #region Snippet:UpdateRoutingSettings
            var updatedRoutingSettings = new List<SipTrunkRoute>
            {
                new SipTrunkRoute(
                    name: "Updated rule",
                    description:  "Handle all other numbers'",
                    numberPattern: @"\+[1-9][0-9]{3,23}",
                    trunks: new List<string> { "sbs1.contoso.com", "sbs2.contoso.com" })
            };
            var response2 = client.UpdateSipConfiguration(updatedRoutingSettings);
            // Output:
            //
            #endregion Snippet:UpdateRoutingSettings
            Assert.AreEqual(200, response2.GetRawResponse().Status);

            #region Snippet:GetSipConfiguration
            // Get calling configuration for resource
            SipConfiguration config = client.GetSipConfiguration();

            foreach (var trunk in config.Trunks)
            {
                Console.WriteLine($"Sip trunk is set with {trunk.Key} and port {trunk.Value.SipSignalingPort}");
            }

            foreach (var routingRule in config.Routes)
            {
                Console.WriteLine($"{routingRule.Name}: {routingRule.Description}");
            }
            #endregion Snippet:GetSipConfiguration

            Assert.AreEqual(200, response2.GetRawResponse().Status);
        }

        [Test]
        [AsyncOnly]
        public async Task UpdateSipConfigurationAsync()
        {
            var client = GetClient();
            #region Snippet:UpdateSipTrunkConfigurationAsync
            var trunks = new Dictionary<string, SipTrunk>
            {
                { "sbs1.contoso.com", new SipTrunk(1122) }
            };

            var routes = new List<SipTrunkRoute>
            {
                new SipTrunkRoute(
                    name: "Initial rule",
                    description: "Handle numbers starting with '+123'",
                    numberPattern : @"\+123[0-9]+",
                    trunks : new List<string>{ "sbs1.contoso.com" })
            };
            var configuration = new SipConfiguration() { Trunks = trunks, Routes = routes };
            var response = await client.UpdateSipConfigurationAsync(configuration);
            #endregion Snippet:UpdateSipTrunkConfigurationAsync

            Assert.AreEqual(200, response.GetRawResponse().Status);

            #region Snippet:UpdateTrunksAsync
            var updatedTrunks = new Dictionary<string, SipTrunk>
            {
                { "sbs1.contoso.com", new SipTrunk(1122) },
                { "sbs2.contoso.com", new SipTrunk(8888) }
            };

            response = await client.UpdateSipConfigurationAsync(updatedTrunks);

            #endregion Snippet:UpdatePstnGatewaysAsync
            Assert.AreEqual(200, response.GetRawResponse().Status);

            #region Snippet:UpdateRoutingSettingsAsync
            var updatedRoutingSettings = new List<SipTrunkRoute>
            {
                new SipTrunkRoute(
                    name: "Updated rule",
                    description: "Handle all other numbers'",
                    numberPattern: @"\+[1-9][0-9]{3,23}",
                    trunks: new List<string> { "sbs1.contoso.com", "sbs2.contoso.com" })
            };
            response = await client.UpdateSipConfigurationAsync(updatedRoutingSettings);
            // Output:
            //
            #endregion Snippet:UpdateRoutingSettingsAsync
            Assert.AreEqual(200, response.GetRawResponse().Status);

            #region Snippet:GetSipConfigurationAsync
            // Get calling configuration for resource
            SipConfiguration config = await client.GetSipConfigurationAsync();

            foreach (var trunk in config.Trunks)
            {
                Console.WriteLine($"Sip trunk is set with {trunk.Key} and port {trunk.Value.SipSignalingPort}");
            }

            foreach (var routingRule in config.Routes)
            {
                Console.WriteLine($"{routingRule.Name}: {routingRule.Description}");
            }
            #endregion Snippet:GetSipConfigurationAsync

            Assert.NotNull(config);
        }

        private SipRoutingClient GetClient()
        {
            var connectionString = TestEnvironment.ConnectionString;
            var clientOptions = InstrumentClientOptions(new SipRoutingClientOptions());

            #region Snippet:CreateSipRoutingClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            //@@var clientOptions = new SipRoutingClientOptions();
            var client = new SipRoutingClient(connectionString, clientOptions);
            #endregion Snippet:CreateSipRoutingClient

            // instrument client
            client = InstrumentClient(client);
            return client;
        }
    }
}
