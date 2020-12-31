// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Management.StorageCache.Tests
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.StorageCache.Models;
    using Microsoft.Azure.Management.StorageCache.Tests.Fixtures;
    using Microsoft.Azure.Management.StorageCache.Tests.Utilities;
    using Microsoft.Azure.Test.HttpRecorder;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Defines the <see cref="UsageModelTests" />.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class UsageModelTests
    {
        /// <summary>
        /// Defines the testOutputHelper.
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Defines the Fixture.
        /// </summary>
        private readonly StorageCacheTestFixture fixture;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsageModelTests"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="StorageCacheTestFixture"/>.</param>
        public UsageModelTests(ITestOutputHelper testOutputHelper, StorageCacheTestFixture fixture)
        {
            this.fixture = fixture;
            this.testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Verify the list of storage cache SKUs available to this subscription.
        /// </summary>
        [Fact]
        public void TestGetSKUList()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                IList<ResourceSku> cacheSkuResponse = client.Skus.List().Value;
                Assert.True(cacheSkuResponse.Count >= 1);
                foreach (ResourceSku resourceSku in cacheSkuResponse)
                {
                    if (string.Equals(resourceSku.Name, "Standard_2G"))
                    {
                        Assert.Equal("2", resourceSku.Capabilities[0].Value);
                        Assert.Equal("3072,6144,12288", resourceSku.Capabilities[1].Value);
                    }

                    if (string.Equals(resourceSku.Name, "Standard_4G"))
                    {
                        Assert.Equal("4", resourceSku.Capabilities[0].Value);
                        Assert.Equal("6144,12288,24576", resourceSku.Capabilities[1].Value);
                    }

                    if (string.Equals(resourceSku.Name, "Standard_8G"))
                    {
                        Assert.Equal("8", resourceSku.Capabilities[0].Value);
                        Assert.Equal("12288,24576,49152", resourceSku.Capabilities[1].Value);
                    }
                }
            }
        }

        /// <summary>
        /// Verify the list of cache usage models available to this subscription.
        /// </summary>
        [Fact]
        public void TestGetUsageModels()
        {
            this.testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;
                IList<UsageModel> usageModelResponse = client.UsageModels.List().Value;
                Assert.True(usageModelResponse.Count >= 1);
                foreach (UsageModel usageModel in usageModelResponse)
                {
                    this.testOutputHelper.WriteLine("Usage Model display - {0}", usageModel.Display.Description);
                    this.testOutputHelper.WriteLine("Usage Model type - {0}", usageModel.TargetType);
                    this.testOutputHelper.WriteLine("Usage Model name - {0}", usageModel.ModelName);
                    string[] array = { "READ_HEAVY_INFREQ", "WRITE_WORKLOAD_15", "WRITE_AROUND" };
                    if (string.Equals(usageModel.TargetType, "Nfs"))
                    {
                        Assert.Contains(usageModel.ModelName, array);
                    }
                }
            }
        }
    }
}