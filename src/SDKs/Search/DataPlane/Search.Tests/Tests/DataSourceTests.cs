// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.Azure;
    using Xunit;

    public sealed class DataSourceTests : SearchTestBase<SearchServiceFixture>
    {
        private const string FakeDescription = "Some data source";

        [Fact]
        public void CreateDataSourceReturnsCorrectDefinition()
        {
            Run(() => TestAllDataSourceTypes(CreateAndValidateDataSource));
        }

        [Fact]
        public void CreateDataSourceFailsWithUsefulMessageOnUserError()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();
                dataSource.Type = DataSourceType.Create("thistypedoesnotexist");

                SearchAssert.ThrowsCloudException(
                    () => searchClient.DataSources.Create(dataSource),
                    HttpStatusCode.BadRequest,
                    "Unsupported data source type 'thistypedoesnotexist'");
            });
        }

        [Fact]
        public void GetDataSourceReturnsCorrectDefinition()
        {
            Run(() => TestAllDataSourceTypes(CreateAndGetDataSource));
        }

        [Fact]
        public void GetDataSourceThrowsOnNotFound()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                SearchAssert.ThrowsCloudException(
                    () => searchClient.DataSources.Get("thisdatasourcedoesnotexist"),
                    HttpStatusCode.NotFound);
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
        public void CreateOrUpdateDataSourceIfNotExistsFailsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsFailsOnExistingResource(
                    Data.GetSearchServiceClient().DataSources.CreateOrUpdate,
                    CreateTestDataSource,
                    MutateDataSource);
            });
        }

        [Fact]
        public void CreateOrUpdateDataSourceIfNotExistsSucceedsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.CreateOrUpdateIfNotExistsSucceedsOnNoResource(
                    Data.GetSearchServiceClient().DataSources.CreateOrUpdate,
                    CreateTestDataSource);
            });
        }

        [Fact]
        public void UpdateDataSourceIfExistsSucceedsOnExistingResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsSucceedsOnExistingResource(
                    Data.GetSearchServiceClient().DataSources.CreateOrUpdate,
                    CreateTestDataSource,
                    MutateDataSource);
            });
        }

        [Fact]
        public void UpdateDataSourceIfExistsFailsOnNoResource()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfExistsFailsOnNoResource(
                    Data.GetSearchServiceClient().DataSources.CreateOrUpdate,
                    CreateTestDataSource);
            });
        }

        [Fact]
        public void UpdateDataSourceIfNotChangedSucceedsWhenResourceUnchanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedSucceedsWhenResourceUnchanged(
                    Data.GetSearchServiceClient().DataSources.CreateOrUpdate,
                    CreateTestDataSource,
                    MutateDataSource);
            });
        }

        [Fact]
        public void UpdateDataSourceIfNotChangedFailsWhenResourceChanged()
        {
            Run(() =>
            {
                AccessConditionTests.UpdateIfNotChangedFailsWhenResourceChanged(
                    Data.GetSearchServiceClient().DataSources.CreateOrUpdate,
                    CreateTestDataSource,
                    MutateDataSource);
            });
        }

        [Fact]
        public void DeleteDataSourceIfNotChangedWorksOnlyOnCurrentResource()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();

                AccessConditionTests.DeleteIfNotChangedWorksOnlyOnCurrentResource(
                    searchClient.DataSources.Delete,
                    () => searchClient.DataSources.CreateOrUpdate(dataSource),
                    x => searchClient.DataSources.CreateOrUpdate(MutateDataSource(x)),
                    dataSource.Name);
            });
        }

        [Fact]
        public void DeleteDataSourceIfExistsWorksOnlyWhenResourceExists()
        {
            Run(() =>
            {
                SearchServiceClient searchClient = Data.GetSearchServiceClient();

                DataSource dataSource = CreateTestDataSource();

                AccessConditionTests.DeleteIfExistsWorksOnlyWhenResourceExists(
                    searchClient.DataSources.Delete,
                    () => searchClient.DataSources.CreateOrUpdate(dataSource),
                    dataSource.Name);
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

        private void TestAllDataSourceTypes(Action<SearchServiceClient, DataSource> testMethod)
        {
            SearchServiceClient searchClient = Data.GetSearchServiceClient();

            var deletionDetectionPolicy = new SoftDeleteColumnDeletionDetectionPolicy("isDeleted", "1");
            var changeDetectionPolicy = new HighWaterMarkChangeDetectionPolicy("fakecolumn");

            // Test all combinations of data source types and configurations.

            // AzureSql
            testMethod(searchClient, CreateTestSqlDataSource());
            testMethod(searchClient, CreateTestSqlDataSource(deletionDetectionPolicy));
            testMethod(searchClient, CreateTestSqlDataSource(new SqlIntegratedChangeTrackingPolicy()));
            testMethod(searchClient, CreateTestSqlDataSource(changeDetectionPolicy, deletionDetectionPolicy));

            // SQL on VM
            testMethod(searchClient, CreateTestSqlDataSource(useSqlVm: true));
            testMethod(searchClient, CreateTestSqlDataSource(deletionDetectionPolicy, useSqlVm: true));
            testMethod(searchClient, CreateTestSqlDataSource(new SqlIntegratedChangeTrackingPolicy(), useSqlVm: true));
            testMethod(searchClient, CreateTestSqlDataSource(changeDetectionPolicy, deletionDetectionPolicy, useSqlVm: true));

            // DocumentDB
            testMethod(searchClient, CreateTestDocDbDataSource());
            testMethod(searchClient, CreateTestDocDbDataSource(useChangeDetection: true));
            testMethod(searchClient, CreateTestDocDbDataSource(deletionDetectionPolicy));
            testMethod(searchClient, CreateTestDocDbDataSource(deletionDetectionPolicy, useChangeDetection: true));

            // Azure Blob Storage
            testMethod(searchClient, CreateTestBlobDataSource());
            testMethod(searchClient, CreateTestBlobDataSource(deletionDetectionPolicy));

            // Azure Table Storage
            testMethod(searchClient, CreateTestTableDataSource());
            testMethod(searchClient, CreateTestTableDataSource(deletionDetectionPolicy));
        }

        private void CreateAndValidateDataSource(SearchServiceClient searchClient, DataSource expectedDataSource)
        {
            DataSource actualDataSource = searchClient.DataSources.Create(expectedDataSource);

            try
            {
                AssertDataSourcesEqual(expectedDataSource, actualDataSource);
            }
            finally
            {
                searchClient.DataSources.Delete(expectedDataSource.Name);
            }
        }

        private void CreateAndGetDataSource(SearchServiceClient searchClient, DataSource expectedDataSource)
        {
            searchClient.DataSources.Create(expectedDataSource);

            try
            {
                DataSource actualDataSource = searchClient.DataSources.Get(expectedDataSource.Name);

                expectedDataSource.Credentials.ConnectionString = null; // Get doesn't return connection strings.
                AssertDataSourcesEqual(expectedDataSource, actualDataSource);
            }
            finally
            {
                searchClient.DataSources.Delete(expectedDataSource.Name);
            }
        }

        private static void AssertDataSourcesEqual(DataSource expected, DataSource actual)
        {
            Assert.Equal(expected, actual, new ModelComparer<DataSource>());
        }

        private static DataSource CreateTestDataSource()
        {
            return CreateTestSqlDataSource();
        }

        private static DataSource MutateDataSource(DataSource dataSource)
        {
            dataSource.Description = "Mutated DataSource";
            return dataSource;
        }

        private static DataSource CreateTestSqlDataSource(DataChangeDetectionPolicy changeDetectionPolicy, bool useSqlVm = false)
        {
            // Test different overloads based on the given parameters.
            if (useSqlVm)
            {
                return DataSource.SqlServerOnAzureVM(
                    name: SearchTestUtilities.GenerateName(),
                    sqlConnectionString: IndexerFixture.AzureSqlReadOnlyConnectionString,
                    tableOrViewName: IndexerFixture.AzureSqlTestTableName,
                    changeDetectionPolicy: changeDetectionPolicy,
                    description: FakeDescription);
            }
            else
            {
                return DataSource.AzureSql(
                    name: SearchTestUtilities.GenerateName(),
                    sqlConnectionString: IndexerFixture.AzureSqlReadOnlyConnectionString,
                    tableOrViewName: IndexerFixture.AzureSqlTestTableName,
                    changeDetectionPolicy: changeDetectionPolicy,
                    description: FakeDescription);
            }
        }

        private static DataSource CreateTestSqlDataSource(
            HighWaterMarkChangeDetectionPolicy changeDetectionPolicy,
            DataDeletionDetectionPolicy deletionDetectionPolicy,
            bool useSqlVm = false)
        {
            // Test different overloads based on the given parameters.
            if (useSqlVm)
            {
                return DataSource.SqlServerOnAzureVM(
                    name: SearchTestUtilities.GenerateName(),
                    sqlConnectionString: IndexerFixture.AzureSqlReadOnlyConnectionString,
                    tableOrViewName: IndexerFixture.AzureSqlTestTableName,
                    changeDetectionPolicy: changeDetectionPolicy,
                    deletionDetectionPolicy: deletionDetectionPolicy,
                    description: FakeDescription);
            }
            else
            {
                return DataSource.AzureSql(
                    name: SearchTestUtilities.GenerateName(),
                    sqlConnectionString: IndexerFixture.AzureSqlReadOnlyConnectionString,
                    tableOrViewName: IndexerFixture.AzureSqlTestTableName,
                    changeDetectionPolicy: changeDetectionPolicy,
                    deletionDetectionPolicy: deletionDetectionPolicy,
                    description: FakeDescription);
            }
        }

        private static DataSource CreateTestSqlDataSource(DataDeletionDetectionPolicy deletionDetectionPolicy = null, bool useSqlVm = false)
        {
            // Test different overloads based on the given parameters.
            if (useSqlVm)
            {
                return DataSource.SqlServerOnAzureVM(
                    name: SearchTestUtilities.GenerateName(),
                    sqlConnectionString: IndexerFixture.AzureSqlReadOnlyConnectionString,
                    tableOrViewName: IndexerFixture.AzureSqlTestTableName,
                    deletionDetectionPolicy: deletionDetectionPolicy,
                    description: FakeDescription);
            }
            else
            {
                return DataSource.AzureSql(
                    name: SearchTestUtilities.GenerateName(),
                    sqlConnectionString: IndexerFixture.AzureSqlReadOnlyConnectionString,
                    tableOrViewName: IndexerFixture.AzureSqlTestTableName,
                    deletionDetectionPolicy: deletionDetectionPolicy,
                    description: FakeDescription);
            }
        }

        private static DataSource CreateTestDocDbDataSource(
            DataDeletionDetectionPolicy deletionDetectionPolicy = null,
            bool useChangeDetection = false)
        {
            return DataSource.DocumentDb(
                name: SearchTestUtilities.GenerateName(),
                documentDbConnectionString: "fake",
                collectionName: "faketable",
                query: "fake query",
                useChangeDetection: useChangeDetection,
                deletionDetectionPolicy: deletionDetectionPolicy,
                description: FakeDescription);
        }

        private static DataSource CreateTestBlobDataSource(DataDeletionDetectionPolicy deletionDetectionPolicy = null)
        {
            return DataSource.AzureBlobStorage(
                name: SearchTestUtilities.GenerateName(),
                storageConnectionString: "fake",
                containerName: "fakecontainer",
                pathPrefix: "/fakefolder/",
                deletionDetectionPolicy: deletionDetectionPolicy,
                description: FakeDescription);
        }

        private static DataSource CreateTestTableDataSource(DataDeletionDetectionPolicy deletionDetectionPolicy = null)
        {
            return DataSource.AzureTableStorage(
                name: SearchTestUtilities.GenerateName(),
                storageConnectionString: "fake",
                tableName: "faketable",
                query: "fake query",
                deletionDetectionPolicy: deletionDetectionPolicy,
                description: FakeDescription);
        }
    }
}
