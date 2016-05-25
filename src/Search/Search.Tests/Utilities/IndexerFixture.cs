// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class IndexerFixture : SearchServiceFixture
    {
        // The connection string we use here, as well as table name and target index schema, use the USGS database
        // that we set up to support our code samples.
        private const string AzureSqlReadOnlyConnectionString =
            "Server=tcp:azs-playground.database.windows.net,1433;Database=usgs;User ID=reader;Password=EdrERBt3j6mZDP;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"; // [SuppressMessage("Microsoft.Security", "CS001:SecretInline")]

        public string TargetIndexName { get; private set; }

        public string DataSourceName { get; private set; }

        public override void Initialize(MockContext context)
        {
            base.Initialize(context);

            SearchServiceClient searchClient = this.GetSearchServiceClient();

            TargetIndexName = SearchTestUtilities.GenerateName();

            DataSourceName = SearchTestUtilities.GenerateName();

            var index = new Index(
                TargetIndexName,
                new[]
                {
                    new Field("feature_id", DataType.String) { IsKey = true },
                });

            searchClient.Indexes.Create(index);

            var dataSource = new DataSource(
                DataSourceName,
                DataSourceType.AzureSql,
                new DataSourceCredentials(AzureSqlReadOnlyConnectionString),
                new DataContainer("GeoNamesRI"));

            searchClient.DataSources.Create(dataSource);
        }

        public Indexer CreateTestIndexer()
        {
            return new Indexer(SearchTestUtilities.GenerateName(), DataSourceName, TargetIndexName)
            {
                // We can't test startTime because it's an absolute time that must be within 24 hours of the current
                // time. That doesn't play well with recorded mock payloads.
                Schedule = new IndexingSchedule() { Interval = TimeSpan.FromDays(1) }
            };
        }
    }
}
