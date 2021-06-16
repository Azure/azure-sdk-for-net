// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.SipRouting.Models;
using Azure.Communication.SipRouting.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.SipRouting.Tests.Samples
{
    public class Sample1_ManageSipTrunkConfiguration : SipRoutingClientLiveTestBase
    {
        public Sample1_ManageSipTrunkConfiguration(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        [SyncOnly]
        public void UpdateSipConfiguration()
        {
            var client = GetClient();
            #region Snippet:UpdateSipConfiguration
            // Update calling configuration for resource
            var trunks = new Dictionary<string, TrunkPatch>();
            trunks.Add("sbs1.contoso.com", new TrunkPatch(1122));

            var routes = new List<TrunkRoute>
            {
                new TrunkRoute(
                    name: "Initial rule",
                    numberPattern : @"\+123[0-9]+",
                    trunks : new List<string>{ "sbs1.contoso.com" })
                {
                    Description = "Handle numbers starting with '+123'",
                },
            };
            var response = client.UpdateSipTrunkConfiguration(trunks, routes);
            // Output:
            //
            #endregion Snippet:UpdateSipConfiguration

            Assert.AreEqual(200, response.GetRawResponse().Status);
            #region Snippet:UpdatePstnGateways
            // Update calling configuration for resource
            trunks = new Dictionary<string, TrunkPatch>();
            trunks.Add("sbs1.contoso.com", new TrunkPatch(1122));
            trunks.Add("sbs2.contoso.com", new TrunkPatch(8888));
            var response1 = client.UpdateTrunks(trunks);
            // Output:
            //
            #endregion Snippet:UpdatePstnGateways
            Assert.AreEqual(200, response1.GetRawResponse().Status);

            #region Snippet:UpdatePstnRoutingSettings
            var updatedPstnRoutingSettings = new List<TrunkRoute>
            {
                new TrunkRoute(
                    name: "Updated rule",
                    numberPattern: @"\+[1-9][0-9]{3,23}",
                    trunks: new List<string> { "sbs1.contoso.com", "sbs2.contoso.com" })
                {
                    Description = "Handle all othe runmbers'",
                }
            };
            var response2 = client.UpdateRoutingSettings(updatedPstnRoutingSettings);
            // Output:
            //
            #endregion Snippet:UpdatePstnRoutingSettings
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
            #region Snippet:UpdateSipConfigurationAsync
            // Update calling configuration for resource
            var trunks = new Dictionary<string, TrunkPatch>();
            trunks.Add("sbs1.contoso.com", new TrunkPatch(1122));

            var routes = new List<TrunkRoute>
            {
                new TrunkRoute(
                    name: "Initial rule",
                    numberPattern : @"\+123[0-9]+",
                    trunks : new List<string>{ "sbs1.contoso.com" })
                {
                    Description = "Handle numbers starting with '+123'",
                },
            };
            var response = await client.UpdateSipTrunkConfigurationAsync(trunks, routes);
            // Output:
            //
            #endregion Snippet:UpdateSipConfigurationAsync

            Assert.AreEqual(200, response.GetRawResponse().Status);

            #region Snippet:UpdatePstnGatewaysAsync
            // Update calling configuration for resource
            var updatedTrunks = new Dictionary<string, TrunkPatch>();
            updatedTrunks.Add("sbs1.contoso.com", new TrunkPatch(1122));
            updatedTrunks.Add("sbs2.contoso.com", new TrunkPatch(8888));

            response = await client.UpdateTrunksAsync(updatedTrunks);
            // Output:
            //
            #endregion Snippet:UpdatePstnGatewaysAsync
            Assert.AreEqual(200, response.GetRawResponse().Status);

            #region Snippet:UpdatePstnRoutingSettingsAsync
            var updatedPstnRoutingSettings = new List<TrunkRoute>
            {
                new TrunkRoute(
                    name: "Updated rule",
                    numberPattern: @"\+[1-9][0-9]{3,23}",
                    trunks: new List<string> { "sbs1.contoso.com", "sbs2.contoso.com" })
                {
                    Description = "Handle all othe runmbers'",
                }
            };
            response = await client.UpdateRoutingSettingsAsync(updatedPstnRoutingSettings);
            // Output:
            //
            #endregion Snippet:UpdatePstnRoutingSettingsAsync
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
