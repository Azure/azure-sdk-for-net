// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

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
                    CreateTestDocDbDataSource(
                        new HighWaterMarkChangeDetectionPolicy("_ts"),
                        new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1")));

                CreateAndValidateDataSource(searchClient, CreateTestSqlDataSource());
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
                Assert.Equal("Unsupported data source type 'thistypedoesnotexist'", e.Body.Message);
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
                    CreateTestDocDbDataSource(
                        new HighWaterMarkChangeDetectionPolicy("_ts"),
                        new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1")));

                CreateAndGetDataSource(searchClient, CreateTestSqlDataSource());
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

                searchClient.DataSources.Create(initial);

                DataSource updatedExpected = CreateTestDataSource();
                updatedExpected.Name = initial.Name;
                updatedExpected.Container = new DataContainer("somethingdifferent");
                updatedExpected.Description = "somethingdifferent";
                updatedExpected.DataChangeDetectionPolicy = new HighWaterMarkChangeDetectionPolicy("rowversion");
                updatedExpected.DataDeletionDetectionPolicy = new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1");

                DataSource updatedActual = searchClient.DataSources.CreateOrUpdate(updatedExpected);

                AssertDataSourcesEqual(updatedExpected, updatedActual);
            });
        }

        [Fact]
        public void CreateOrUpdateCreatesWhenDataSourceDoesNotExist()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();

                AzureOperationResponse<DataSource> response = 
                    searchClient.DataSources.CreateOrUpdateWithHttpMessagesAsync(dataSource).Result;
                Assert.Equal(HttpStatusCode.Created, response.Response.StatusCode);
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
                AzureOperationResponse deleteResponse = 
                    searchClient.DataSources.DeleteWithHttpMessagesAsync(dataSource.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);

                searchClient.DataSources.Create(dataSource);

                // Now delete twice.
                deleteResponse = searchClient.DataSources.DeleteWithHttpMessagesAsync(dataSource.Name).Result;
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);

                deleteResponse = searchClient.DataSources.DeleteWithHttpMessagesAsync(dataSource.Name).Result;
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.Response.StatusCode);
            });
        }

        [Fact]
        public void CanCreateAndListDataSources()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                // Create a datasource of each supported type
                DataSource dataSource1 = CreateTestSqlDataSource();
                DataSource dataSource2 = CreateTestDocDbDataSource();

                searchClient.DataSources.Create(dataSource1);
                searchClient.DataSources.Create(dataSource2);

                DataSourceListResult listResponse = searchClient.DataSources.List();
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

        private void CreateAndValidateDataSource(SearchServiceClient searchClient, DataSource expectedDataSource)
        {
            DataSource actualDataSource = searchClient.DataSources.Create(expectedDataSource);
            AssertDataSourcesEqual(expectedDataSource, actualDataSource);
        }

        private void CreateAndGetDataSource(SearchServiceClient searchClient, DataSource expectedDataSource)
        {
            searchClient.DataSources.Create(expectedDataSource);
            DataSource actualDataSource = searchClient.DataSources.Get(expectedDataSource.Name);

            AssertDataSourcesEqual(expectedDataSource, actualDataSource, isGet: true);
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
            return CreateTestSqlDataSource();
        }

        private static DataSource CreateTestSqlDataSource()
        {
            const string FakeConnectionString =
                "Server=tcp:fake,1433;Database=fake;User ID=fake;Password=fake;Trusted_Connection=False;" +
                "Encrypt=True;Connection Timeout=30;";

            return
                new DataSource(
                    SearchTestUtilities.GenerateName(),
                    DataSourceType.AzureSql,
                    new DataSourceCredentials(FakeConnectionString),
                    new DataContainer("faketable"))
                {
                    DataChangeDetectionPolicy = new HighWaterMarkChangeDetectionPolicy("fakecolumn")
                };
        }

        private static DataSource CreateTestDocDbDataSource(
            DataChangeDetectionPolicy changeDetectionPolicy = null,
            DataDeletionDetectionPolicy deletionDetectionPolicy = null)
        {
            return
                new DataSource(
                    SearchTestUtilities.GenerateName(),
                    DataSourceType.DocumentDb,
                    new DataSourceCredentials(connectionString: "fake"),
                    new DataContainer("faketable"))
                {
                    DataChangeDetectionPolicy = changeDetectionPolicy,
                    DataDeletionDetectionPolicy = deletionDetectionPolicy,
                };
        }
    }
}
