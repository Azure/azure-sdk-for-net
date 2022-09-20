// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DnsResolver.Tests;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.ResourceManager.DnsResolver.Tests
{
    public class DnsResolverTestBase : ManagementRecordedTestBase<DnsResolverManagementTestEnvironment>
    {
        protected AzureLocation DefaultLocation => AzureLocation.WestUS2;
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        public DnsResolverTestBase(bool isAsync) : base(isAsync)
        {
        }

        public DnsResolverTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            var resourceGroupName = Recording.GenerateAssetName("testRG-");
            var rgOp = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceGroupName,
                new ResourceGroupData(DefaultLocation)
                {
                    Tags =
                    {
                        { "test", "env" }
                    }
                });
            return rgOp.Value;
        }

        protected async Task CreateVirtualNetworkAsync(string virtualNetworkName)
        {
            var baseUri = $"https://{TestEnvironment.Location}.test.azuremresolver.net:9002";
            var relativeUri = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}";
            var client = new HttpClient();

            var virtualNetwork = new
            {
                location = TestEnvironment.Location,
                properties = new
                {
                    addressSpace = new
                    {
                        addressPrefixes = new[] { "10.0.0.0/8" },
                    }
                },
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(virtualNetwork), Encoding.UTF8, "application/json");
            await client.PutAsync(baseUri + relativeUri, httpContent);
        }

        protected async Task CreateSubnetAsync(string virtualNetworkName)
        {
            var subnetName = "snet-sim2";
            var baseUri = $"https://{TestEnvironment.Location}.test.azuremresolver.net:9002";
            var relativeUri = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{TestEnvironment.ResourceGroup}/providers/Microsoft.Network/virtualNetworks/{virtualNetworkName}/subnets/{subnetName}";
            var client = new HttpClient();

            var virtualNetwork = new
            {
                location = TestEnvironment.Location,
                properties = new
                {
                    addressPrefix = "10.2.2.0/28",
                },
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(virtualNetwork), Encoding.UTF8, "application/json");
            await client.PutAsync(baseUri + relativeUri, httpContent);
        }
    }
}
