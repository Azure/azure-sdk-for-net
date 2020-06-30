// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TableServiceClientLiveTests : TableServiceLiveTestsBase
    {

        public TableServiceClientLiveTests(bool isAsync) : base(isAsync /* To record tests, add this argument, RecordedTestMode.Record */)
        { }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        [TestCase(null)]
        [TestCase(5)]
        public async Task GetTablesReturnsTablesWithAndWithoutPagination(int? pageCount)
        {
            var createdTables = new List<string>();

            try
            {
                // Create some extra tables.

                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
                    await service.CreateTableAsync(table).ConfigureAwait(false);
                    createdTables.Add(table);
                }

                // Get the table list.

                var tableResponses = (await service.GetTablesAsync(top: pageCount).ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        /// <summary>
        /// Validates the functionality of the TableServiceClient.
        /// </summary>
        [Test]
        public async Task GetTablesReturnsTablesWithFilter()
        {
            var createdTables = new List<string>();

            try
            {
                // Create some extra tables.

                for (int i = 0; i < 10; i++)
                {
                    var table = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
                    await service.CreateTableAsync(table).ConfigureAwait(false);
                    createdTables.Add(table);
                }

                // Query with a filter.

                var tableResponses = (await service.GetTablesAsync(filter: $"TableName eq '{tableName}'").ToEnumerableAsync().ConfigureAwait(false)).ToList();

                Assert.That(() => tableResponses, Is.Not.Empty);
                Assert.That(() => tableResponses.Select(r => r.TableName), Contains.Item(tableName));
            }
            finally
            {
                foreach (var table in createdTables)
                {
                    await service.DeleteTableAsync(table);
                }
            }
        }

        [Test]
        public async Task GetPropertiesReturnsProperties()
        {
            // Get current properties
            TableServiceProperties responseToChange = await service.GetPropertiesAsync().ConfigureAwait(false);

            // Change a property
            responseToChange.Logging.Read = !responseToChange.Logging.Read;

            // Set properties to the changed one
            await service.SetPropertiesAsync(responseToChange).ConfigureAwait(false);

            // Wait 20 sec if on Live mode to ensure properties are updated in the service
            // Minimum time: Sync - 20 sec; Async - 12 sec
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(20000);
            }

            // Get configured properties
            TableServiceProperties changedResponse = await service.GetPropertiesAsync().ConfigureAwait(false);

            // Test each property
            CompareTableServiceProperties(responseToChange, changedResponse);
        }

        [Test]
        public async Task GetTableServiceStatsReturnsStats()
        {
            // Get statistics
            TableServiceStats stats = await service.GetTableServiceStatsAsync().ConfigureAwait(false);

            // Test that the secondary location is live
            Assert.AreEqual(new GeoReplicationStatusType("live"), stats.GeoReplication.Status);
        }

        private void CompareTableServiceProperties(TableServiceProperties expected, TableServiceProperties actual)
        {
            Assert.AreEqual(expected.Logging.Read, actual.Logging.Read);
            Assert.AreEqual(expected.Logging.Version, actual.Logging.Version);
            Assert.AreEqual(expected.Logging.Write, actual.Logging.Write);
            Assert.AreEqual(expected.Logging.Delete, actual.Logging.Delete);
            Assert.AreEqual(expected.Logging.RetentionPolicy.Enabled, actual.Logging.RetentionPolicy.Enabled);
            Assert.AreEqual(expected.Logging.RetentionPolicy.Days, actual.Logging.RetentionPolicy.Days);

            Assert.AreEqual(expected.HourMetrics.Enabled, actual.HourMetrics.Enabled);
            Assert.AreEqual(expected.HourMetrics.Version, actual.HourMetrics.Version);
            Assert.AreEqual(expected.HourMetrics.IncludeAPIs, actual.HourMetrics.IncludeAPIs);
            Assert.AreEqual(expected.HourMetrics.RetentionPolicy.Enabled, actual.HourMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(expected.HourMetrics.RetentionPolicy.Days, actual.HourMetrics.RetentionPolicy.Days);

            Assert.AreEqual(expected.MinuteMetrics.Enabled, actual.MinuteMetrics.Enabled);
            Assert.AreEqual(expected.MinuteMetrics.Version, actual.MinuteMetrics.Version);
            Assert.AreEqual(expected.MinuteMetrics.IncludeAPIs, actual.MinuteMetrics.IncludeAPIs);
            Assert.AreEqual(expected.MinuteMetrics.RetentionPolicy.Enabled, actual.MinuteMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(expected.MinuteMetrics.RetentionPolicy.Days, actual.MinuteMetrics.RetentionPolicy.Days);

            Assert.AreEqual(expected.Cors.Count, actual.Cors.Count);
            for (int i = 0; i < expected.Cors.Count; i++)
            {
                CorsRule expectedRule = expected.Cors[i];
                CorsRule actualRule = actual.Cors[i];
                Assert.AreEqual(expectedRule.AllowedHeaders, actualRule.AllowedHeaders);
                Assert.AreEqual(expectedRule.AllowedMethods, actualRule.AllowedMethods);
                Assert.AreEqual(expectedRule.AllowedOrigins, actualRule.AllowedOrigins);
                Assert.AreEqual(expectedRule.MaxAgeInSeconds, actualRule.MaxAgeInSeconds);
                Assert.AreEqual(expectedRule.ExposedHeaders, actualRule.ExposedHeaders);
            }
        }
    }
}
