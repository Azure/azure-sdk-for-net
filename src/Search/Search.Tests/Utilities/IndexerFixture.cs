// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using System.Net;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace Microsoft.Azure.Search.Tests.Utilities
{
    public class IndexerFixture : SearchServiceFixture
    {
        // The connection string we use here, as well as table name and target index schema, use the usgs database that we set up 
        // to support our code samples. 
        private const string AzureSqlReadOnlyConnectionString = "Server=tcp:azs-playground.database.windows.net,1433;Database=usgs;User ID=reader;Password=EdrERBt3j6mZDP;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        public IndexerFixture()
        {
            SearchServiceClient searchClient = this.GetSearchServiceClient();

            TargetIndexName = TestUtilities.GenerateName();

            DataSourceName = TestUtilities.GenerateName();

            var index = new Index(
                TargetIndexName,
                new[]
                {
                    new Field("feature_id", DataType.String) { IsKey = true },
                });

            AzureOperationResponse createResponse = searchClient.Indexes.Create(index);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var dataSource = new DataSource(
                DataSourceName,
                DataSourceType.AzureSql,
                new DataSourceCredentials(AzureSqlReadOnlyConnectionString),
                new DataContainer("GeoNamesRI"));

            createResponse = searchClient.DataSources.Create(dataSource);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        }

        public string TargetIndexName { get; private set; }

        public string DataSourceName { get; private set; }

        public Indexer CreateTestIndexer()
        {
            return new Indexer(TestUtilities.GenerateName(), DataSourceName, TargetIndexName)
            {
                // We can't test startTime because it's an absolute time that must be within 24 hours of the current
                // time. That doesn't play well with recorded mock payloads.
                Schedule = new IndexingSchedule() { Interval = TimeSpan.FromDays(1) }
            };
        }
    }
}
