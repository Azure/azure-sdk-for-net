// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using System;
    using Xunit;

    public sealed class ServiceStatsTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void GetServiceStatsReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();
                var expectedStats = new ServiceStatistics
                {
                    Counters = new ServiceCounters
                    {
                        DocumentCounter = new ResourceCounter(0, null),
                        IndexCounter = new ResourceCounter(0, 3),
                        IndexerCounter = new ResourceCounter(0, 3),
                        DataSourceCounter = new ResourceCounter(0, 3),
                        StorageSizeCounter = new ResourceCounter(0, 52428800),
                        SynonymMapCounter = new ResourceCounter(0, 3)
                    },
                    Limits = new ServiceLimits
                    {
                        MaxFieldsPerIndex = 1000,
                        MaxIndexerRunTime = TimeSpan.FromMinutes(1),
                        MaxFileExtractionSize = 16777216,
                        MaxFileContentCharactersToExtract = 32768,
                        MaxFieldNestingDepthPerIndex = 10,
                        MaxComplexCollectionFieldsPerIndex = 100
                    }
                };

                ServiceStatistics stats = searchClient.GetServiceStatistics();
                AssertEquals(expectedStats, stats);
            });
        }

        private static void AssertEquals(ServiceStatistics expected, ServiceStatistics actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);
            AssertEquals(expected.Counters, actual.Counters);
            AssertEquals(expected.Limits, actual.Limits);
        }

        private static void AssertEquals(ServiceLimits expected, ServiceLimits actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);
            Assert.Equal(expected.MaxFieldsPerIndex, actual.MaxFieldsPerIndex);
            Assert.Equal(expected.MaxFieldNestingDepthPerIndex, actual.MaxFieldNestingDepthPerIndex);
            Assert.Equal(expected.MaxIndexerRunTime, actual.MaxIndexerRunTime);
            Assert.Equal(expected.MaxFileExtractionSize, actual.MaxFileExtractionSize);
            Assert.Equal(expected.MaxFileContentCharactersToExtract, actual.MaxFileContentCharactersToExtract);
            Assert.Equal(expected.MaxComplexCollectionFieldsPerIndex, actual.MaxComplexCollectionFieldsPerIndex);
        }

        private static void AssertEquals(ServiceCounters expected, ServiceCounters actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);
            AssertEquals(expected.DocumentCounter, actual.DocumentCounter);
            AssertEquals(expected.IndexCounter, actual.IndexCounter);
            AssertEquals(expected.IndexerCounter, actual.IndexerCounter);
            AssertEquals(expected.DataSourceCounter, actual.DataSourceCounter);
            AssertEquals(expected.StorageSizeCounter, actual.StorageSizeCounter);
        }

        private static void AssertEquals(ResourceCounter expected, ResourceCounter actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);
            Assert.Equal(expected.Usage, actual.Usage);
            Assert.Equal(expected.Quota, actual.Quota);
        }
    }
}
