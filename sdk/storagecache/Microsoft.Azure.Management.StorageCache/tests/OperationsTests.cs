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
    /// Defines the <see cref="OperationsTests" />.
    /// </summary>
    [Collection("StorageCacheCollection")]
    public class OperationsTests
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
        /// Initializes a new instance of the <see cref="OperationsTests"/> class.
        /// </summary>
        /// <param name="testOutputHelper">The testOutputHelper<see cref="ITestOutputHelper"/>.</param>
        /// <param name="fixture">The Fixture<see cref="StorageCacheTestFixture"/>.</param>
        public OperationsTests(ITestOutputHelper testOutputHelper, StorageCacheTestFixture fixture)
        {
            this.fixture = fixture;
            this.testOutputHelper = testOutputHelper;
        }

        /// <summary>
        /// Verify the list of operations available to this subscription.
        /// </summary>
        [Fact]
        public void TestOperationsList()
        {
            testOutputHelper.WriteLine($"Running in {HttpMockServer.GetCurrentMode()} mode.");
            using (StorageCacheTestContext context = new StorageCacheTestContext(this))
            {
                var client = context.GetClient<StorageCacheManagementClient>();
                client.ApiVersion = StorageCacheTestEnvironmentUtilities.APIVersion;

                ApiOperationDisplay stopOperationDisplay = new ApiOperationDisplay("Stop the cache", "Microsoft Azure HPC Cache", "Cache", "Stops the cache");
                ApiOperationListResult result = OperationsExtensions.List(client.Operations);

                IList<MetricSpecification> metrics = new List<MetricSpecification>();

                MetricDimension dim = new MetricDimension
                {
                    DisplayName = "dname",
                    InternalName = "iname",
                    Name = "name",
                    ToBeExportedForShoebox = false
                };

                IList<MetricDimension> dims = new List<MetricDimension>();
                dims.Add(dim);

                IList<string> aggrTypes = new List<string>();
                aggrTypes.Add("string");

                MetricSpecification metric = new MetricSpecification
                {
                    AggregationType = "string",
                    Unit = "unit",
                    Name = "name",
                    MetricClass = "metricClass",
                    DisplayName = "displayName",
                    DisplayDescription = "displayDescription",
                    SupportedAggregationTypes = aggrTypes,
                    Dimensions = dims
                };

                ApiOperationPropertiesServiceSpecification serviceSpecification = new ApiOperationPropertiesServiceSpecification();
                serviceSpecification.MetricSpecifications = metrics;

                foreach(ApiOperation api in result.Value)
                {
                    if (api.Name == "Microsoft.StorageCache/caches/Stop/action")
                    {
                        Assert.Equal(api.Display.Resource, stopOperationDisplay.Resource);
                        Assert.Equal(api.Display.Provider, stopOperationDisplay.Provider);
                        Assert.Equal(api.Display.Description, stopOperationDisplay.Description);
                        Assert.Equal(api.Display.Operation, stopOperationDisplay.Operation);
                    }
                    if (api.Name == "Microsoft.StorageCache/caches/providers/Microsoft.Insights/metricDefinitions/read")
                    {
                        testOutputHelper.WriteLine("Microsoft.StorageCache/caches/providers/Microsoft.Insights/metricDefinitions/read");
                        testOutputHelper.WriteLine($"isDataAction {api.IsDataAction}");
                        testOutputHelper.WriteLine($"origin {api.Origin}");
                        if (api.Display != null)
                        {
                            ApiOperationDisplay display = api.Display;
                            testOutputHelper.WriteLine($"Display operation {display.Operation}");
                            testOutputHelper.WriteLine($"Display provider {display.Provider}");
                            testOutputHelper.WriteLine($"Display resource {display.Resource}");
                            testOutputHelper.WriteLine($"Display description {display.Description}");
                        }
                        ApiOperationPropertiesServiceSpecification aopss = api.ServiceSpecification;
                        if(aopss != null)
                        {
                            IList<MetricSpecification> mss = aopss.MetricSpecifications;
                            foreach(MetricSpecification ms in mss)
                            {
                                testOutputHelper.WriteLine($"Metric Specification Name {ms.Name}");
                                testOutputHelper.WriteLine($"Metric Specification Display Name {ms.DisplayName}");
                                testOutputHelper.WriteLine($"Metric Specification Display Description {ms.DisplayDescription}");
                                testOutputHelper.WriteLine($"Metric Specification Unit {ms.Unit}");
                                testOutputHelper.WriteLine($"Metric Specification AggrType {ms.AggregationType}");
                                testOutputHelper.WriteLine($"Metric Specification MetricClass {ms.MetricClass}");

                                foreach(string sat in ms.SupportedAggregationTypes)
                                {
                                    testOutputHelper.WriteLine($"Metric Specification Supported Aggr Type {sat}");
                                }
                            }
                        }
                    }
                }
                testOutputHelper.WriteLine($"NextLink {result.NextLink}");
                Assert.True(result.Value.Count > 1);

                // Try one with a null client.
                Assert.Throws<System.NullReferenceException>(() => OperationsExtensions.List(null));
            }
        }
    }
}