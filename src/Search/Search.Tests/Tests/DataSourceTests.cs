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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.TestCategories;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class DataSourceTests : SearchTestBase<SearchServiceFixture>
    {
        [Fact]
        public void CreateDataSourceReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                CreateAndValidateDataSource(searchClient, CreateTestDataSource());

                CreateAndValidateDataSource(
                    searchClient,
                    CreateTestDataSource(
                        DataSourceType.DocumentDb, 
                        new HighWaterMarkChangeDetectionPolicy("_ts"),
                        new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1")));

                CreateAndValidateDataSource(
                    searchClient,
                    CreateTestDataSource(DataSourceType.AzureSql, new SqlIntegratedChangeTrackingPolicy()));
            });
        }

        [Fact]
        public void CreateDataSourceFailsWithUsefulMessageOnUserError()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();
                dataSource.Type = "thistypedoesnotexist";

                CloudException e = Assert.Throws<CloudException>(() => searchClient.DataSources.Create(dataSource));
                Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                Assert.Equal("Unsupported data source type 'thistypedoesnotexist'", e.Error.Message);
            });
        }

        [Fact]
        public void GetDataSourceReturnsCorrectDefinition()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                CreateAndGetDataSource(searchClient, CreateTestDataSource());

                CreateAndGetDataSource(
                    searchClient,
                    CreateTestDataSource(
                        DataSourceType.DocumentDb,
                        new HighWaterMarkChangeDetectionPolicy("_ts"),
                        new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1")));

                CreateAndGetDataSource(
                    searchClient,
                    CreateTestDataSource(DataSourceType.AzureSql, new SqlIntegratedChangeTrackingPolicy()));
            });
        }

        [Fact]
        public void GetDataSourceThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                CloudException e = Assert.Throws<CloudException>(() => searchClient.DataSources.Get("thisdatasourcedoesnotexist"));
                Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
            });
        }

        [Fact]
        public void CanUpdateDataSource()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource initial = CreateTestDataSource();

                DataSourceDefinitionResponse createResponse = searchClient.DataSources.Create(initial);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                DataSource updated = CreateTestDataSource();
                updated.Name = initial.Name;
                updated.Container = new DataContainer("somethingdifferent");
                updated.Description = "somethingdifferent";
                updated.DataChangeDetectionPolicy = new HighWaterMarkChangeDetectionPolicy("rowversion");
                updated.DataDeletionDetectionPolicy = new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1");

                DataSourceDefinitionResponse updateResponse = searchClient.DataSources.CreateOrUpdate(updated);
                Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

                AssertDataSourcesEqual(updated, updateResponse.DataSource);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenDataSourceDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();

                DataSourceDefinitionResponse response = searchClient.DataSources.CreateOrUpdate(dataSource);
                Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            });
        }

        [Fact]
        public void DeleteDataSourceIsIdempotent()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();

                // Try delete before the datasource even exists.
                AzureOperationResponse deleteResponse = searchClient.DataSources.Delete(dataSource.Name);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);

                DataSourceDefinitionResponse createResponse = searchClient.DataSources.Create(dataSource);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // Now delete twice.
                deleteResponse = searchClient.DataSources.Delete(dataSource.Name);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                deleteResponse = searchClient.DataSources.Delete(dataSource.Name);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
            });
        }

        [Fact]
        public void CanCreateAndListDataSources()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                // Create a datasource of each supported type
                DataSource dataSource1 = CreateTestDataSource(DataSourceType.AzureSql);
                DataSource dataSource2 = CreateTestDataSource(DataSourceType.DocumentDb);

                DataSourceDefinitionResponse createResponse = searchClient.DataSources.Create(dataSource1);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                createResponse = searchClient.DataSources.Create(dataSource2);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                DataSourceListResponse listResponse = searchClient.DataSources.List();
                Assert.Equal(HttpStatusCode.OK, listResponse.StatusCode);
                Assert.Equal(2, listResponse.DataSources.Count);

                IEnumerable<string> dataSourceNames = listResponse.DataSources.Select(i => i.Name);
                Assert.Contains(dataSource1.Name, dataSourceNames);
                Assert.Contains(dataSource2.Name, dataSourceNames);
            });
        }

        [Fact]
        public void ExistsReturnsTrueForExistingDataSource()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                DataSource dataSource = CreateTestDataSource();
                client.DataSources.Create(dataSource);

                Assert.True(client.DataSources.Exists(dataSource.Name));
            });
        }

        [Fact]
        public void ExistsReturnsFalseForNonExistingDataSource()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();
                Assert.False(client.DataSources.Exists("invalidds"));
            });
        }

        private void CreateAndValidateDataSource(SearchServiceClient searchClient, DataSource dataSource)
        {
            DataSourceDefinitionResponse createResponse = searchClient.DataSources.Create(dataSource);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
            AssertDataSourcesEqual(dataSource, createResponse.DataSource);
        }

        private void CreateAndGetDataSource(SearchServiceClient searchClient, DataSource dataSource)
        {
            DataSourceDefinitionResponse createResponse = searchClient.DataSources.Create(dataSource);
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            DataSourceDefinitionResponse getResponse = searchClient.DataSources.Get(dataSource.Name);
            Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

            AssertDataSourcesEqual(dataSource, getResponse.DataSource, isGet: true);
        }

        private static void AssertDataSourcesEqual(DataSource expected, DataSource actual, bool isGet = false)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Description, actual.Description);
            Assert.Equal(expected.Type, actual.Type);
            AssertCredentialsEqual(expected.Credentials, actual.Credentials, isGet);
            AssertDataContainersEqual(expected.Container, actual.Container);
            AssertDataChangeDetectionPoliciesEqual(expected.DataChangeDetectionPolicy, actual.DataChangeDetectionPolicy);
            AssertDataDeletionDetectionPoliciesEqual(expected.DataDeletionDetectionPolicy, actual.DataDeletionDetectionPolicy);
        }

        private static void AssertDataChangeDetectionPoliciesEqual(DataChangeDetectionPolicy expected, DataChangeDetectionPolicy actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);

            HighWaterMarkChangeDetectionPolicy expectedHwm = expected as HighWaterMarkChangeDetectionPolicy;
            if (expectedHwm != null)
            {
                HighWaterMarkChangeDetectionPolicy actualHwm = Assert.IsType<HighWaterMarkChangeDetectionPolicy>(actual);
                Assert.Equal(expectedHwm.HighWaterMarkColumnName, actualHwm.HighWaterMarkColumnName);
                return;
            }

            SqlIntegratedChangeTrackingPolicy expectedIct = expected as SqlIntegratedChangeTrackingPolicy;
            if (expectedIct != null)
            {
                Assert.IsType<SqlIntegratedChangeTrackingPolicy>(actual);
                return;
            }

            Assert.False(true, "Unexpected type of change detection policy (did you forget to add support for a new policy type to test code?):" + expected.GetType().Name);
        }

        private static void AssertDataDeletionDetectionPoliciesEqual(DataDeletionDetectionPolicy expected, DataDeletionDetectionPolicy actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
                return;
            }

            Assert.NotNull(actual);

            SoftDeleteColumnDeletionDetectionPolicy expectedSoftDelete = expected as SoftDeleteColumnDeletionDetectionPolicy;
            if (expectedSoftDelete != null)
            {
                SoftDeleteColumnDeletionDetectionPolicy actualSoftDelete = Assert.IsType<SoftDeleteColumnDeletionDetectionPolicy>(actual);
                Assert.Equal(expectedSoftDelete.SoftDeleteColumnName, actualSoftDelete.SoftDeleteColumnName);
                Assert.Equal(expectedSoftDelete.SoftDeleteMarkerValue, actualSoftDelete.SoftDeleteMarkerValue);
                return;
            }

            Assert.False(true, "Unexpected type of deletion detection policy (did you forget to add support for a new policy type to test code?):" + expected.GetType().Name);
        }

        private static void AssertCredentialsEqual(DataSourceCredentials expected, DataSourceCredentials actual, bool isGet)
        {
            if (expected == null)
            {
                Assert.Null(actual);
            }
            else if (isGet)
            {
                // Get doesn't return the connection string
                Assert.Null(actual.ConnectionString);
            }
            else
            {
                Assert.NotNull(actual);
                Assert.Equal(expected.ConnectionString, actual.ConnectionString);
            }
        }

        private static void AssertDataContainersEqual(DataContainer expected, DataContainer actual)
        {
            Assert.NotNull(expected);
            Assert.NotNull(actual);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Query, actual.Query);
        }

        private static DataSource CreateTestDataSource()
        {
            return CreateTestDataSource(DataSourceType.AzureSql);
        }

        private static DataSource CreateTestDataSource(
            DataSourceType type, 
            DataChangeDetectionPolicy changeDetectionPolicy = null,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null)
        {
            return 
                new DataSource(
                    TestUtilities.GenerateName(),
                    type,
                    new DataSourceCredentials(connectionString: "fake"),
                    new DataContainer("faketable"))
                {
                    DataChangeDetectionPolicy = changeDetectionPolicy,
                    DataDeletionDetectionPolicy = deletionDetectionPolicy,
                };
        }
    }
}
