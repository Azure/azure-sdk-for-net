// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests.Utilities
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Index = Microsoft.Azure.Search.Models.Index;

    public class IndexerFixture : SearchServiceFixture
    {
        // The connection string we use here, as well as table name and target index schema, use the USGS database
        // that we set up to support our code samples.
        //
        // ASSUMPTION: Change tracking has already been enabled on the database with ALTER DATABASE ... SET CHANGE_TRACKING = ON
        // and it has been enabled on the table with ALTER TABLE ... ENABLE CHANGE_TRACKING
        public const string AzureSqlReadOnlyConnectionString =
            "Server=tcp:azs-playground.database.windows.net,1433;Database=usgs;User ID=reader;Password=EdrERBt3j6mZDP;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"; // [SuppressMessage("Microsoft.Security", "CS001:SecretInline")]

        public const string AzureSqlTestTableName = "GeoNamesRI";

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
                    new Field("feature_name", DataType.String) { IsFilterable = true, IsSearchable = true },
                    new Field("feature_class", DataType.String),
                    new Field("state", DataType.String) { IsFilterable = true, IsSearchable = true },
                    new Field("county_name", DataType.String) { IsFilterable = true, IsSearchable = true },
                    new Field("elevation", DataType.Int32) { IsFilterable = true },
                    new Field("map_name", DataType.String) { IsFilterable = true, IsSearchable = true },
                    new Field("history", DataType.Collection(DataType.String)) { IsSearchable = true },
                    new Field("myEntities", DataType.Collection(DataType.String)) { IsSearchable = true },
                    new Field("myText", DataType.String) { IsSearchable = true }
                });

            searchClient.Indexes.Create(index);

            var dataSource =
                DataSource.AzureSql(
                    name: DataSourceName,
                    sqlConnectionString: AzureSqlReadOnlyConnectionString,
                    tableOrViewName: AzureSqlTestTableName);

            searchClient.DataSources.Create(dataSource);
        }

        public Indexer CreateTestIndexer() =>
            new Indexer(SearchTestUtilities.GenerateName(), DataSourceName, TargetIndexName)
            {
                // We can't test startTime because it's an absolute time that must be within 24 hours of the current
                // time. That doesn't play well with recorded mock payloads.
                Schedule = new IndexingSchedule(interval: TimeSpan.FromDays(1)),
                FieldMappings = new[]
                {
                    // Try all the field mapping functions (even if they don't make sense in the context of the test DB).
                    new FieldMapping("feature_class", FieldMappingFunction.Base64Encode()),
                    new FieldMapping("state_alpha", "state", FieldMappingFunction.UrlEncode()),
                    new FieldMapping("county_name", FieldMappingFunction.ExtractTokenAtPosition(" ", 0)),
                    new FieldMapping("elev_in_m", "elevation", FieldMappingFunction.UrlDecode()),
                    new FieldMapping("map_name", FieldMappingFunction.Base64Decode()),
                    new FieldMapping("history", FieldMappingFunction.JsonArrayToStringCollection())
                }
            };

        public Indexer CreateTestIndexerWithSkillset(string skillsetName, IList<FieldMapping> outputFieldMapping)
        {
            return new Indexer(name: SearchTestUtilities.GenerateName(), dataSourceName: DataSourceName, targetIndexName: TargetIndexName, skillsetName: skillsetName)
            {
                // We can't test startTime because it's an absolute time that must be within 24 hours of the current
                // time. That doesn't play well with recorded mock payloads.
                Schedule = new IndexingSchedule(interval: TimeSpan.FromDays(1)),
                OutputFieldMappings = outputFieldMapping
            };
        }

        public Indexer MutateIndexer(Indexer indexer)
        {
            indexer.Description = "Mutated Indexer";
            return indexer;
        }
    }
}
