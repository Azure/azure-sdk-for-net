// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class SensitivityLabelsScenarioTests
    {
        private const string s_DatabaseNamePrefix = "sqldatabasesensitivitylabelscrudtest-";
        private const string s_SchemaName = "dbo";
        private const string s_TableName = "Persons";
        private const string s_StartIpAddress = "0.0.0.0";
        private const string s_EndIpAddress = "255.255.255.255";
        private const string s_FirewallRuleName = "sqltestrule";

        [Fact]
        public virtual void TestDatabaseSensitivityLabels()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                string resourceGroupName = resourceGroup.Name;

                Server server = context.CreateServer(resourceGroup);
                string serverName = server.Name;

                ISqlManagementClient client = context.GetClient<SqlManagementClient>();
                CreateFirewallRule(resourceGroupName, serverName, client);

                string databaseName = GetDatabaseName();
                Database database = client.Databases.CreateOrUpdate(
                    resourceGroupName, serverName, databaseName,
                    new Database()
                    {
                        Location = server.Location,
                    });
                Assert.NotNull(database);

                CreateTableIfNeeded(serverName, server.FullyQualifiedDomainName, databaseName);

                RunTest(client, resourceGroupName, serverName, databaseName);

                client.Databases.Delete(resourceGroupName, serverName, databaseName);
                client.Servers.Delete(resourceGroupName, serverName);
            }
        }

        protected static void CreateFirewallRule(string resourceGroupName, string serverName, ISqlManagementClient client)
        {
            client.FirewallRules.CreateOrUpdate(resourceGroupName, serverName, s_FirewallRuleName,
                new FirewallRule()
                {
                    StartIpAddress = s_StartIpAddress,
                    EndIpAddress = s_EndIpAddress
                });
        }

        protected static string GetDatabaseName()
        {
            return SqlManagementTestUtilities.GenerateName(s_DatabaseNamePrefix);
        }

        protected void RunTest(ISqlManagementClient client,
            string resourceGroupName, string serverName, string databaseName)
        {
            IPage<SensitivityLabel> sensitivityLabels = ListCurrentSensitivityLabels(
                client, resourceGroupName, serverName, databaseName);
            Assert.NotNull(sensitivityLabels);
            Assert.Empty(sensitivityLabels);

            sensitivityLabels = ListRecommendedSensitivityLabels(client, resourceGroupName, serverName, databaseName);
            Assert.NotNull(sensitivityLabels);
            Assert.NotEmpty(sensitivityLabels);
            int recommendedLabelsCount = sensitivityLabels.Count();
            SensitivityLabel recommendedLabel = sensitivityLabels.First();
            string columnName = recommendedLabel.Id.Split("/")[16];

            SensitivityLabel newLabel = new SensitivityLabel(
                    labelName: recommendedLabel.LabelName,
                    labelId: recommendedLabel.LabelId,
                    informationType: recommendedLabel.InformationType,
                    informationTypeId: recommendedLabel.InformationTypeId);

            SensitivityLabel createdLabel = CreateOrUpdateSensitivityLabel(client, resourceGroupName, serverName, databaseName,
                s_SchemaName, s_TableName, columnName, newLabel);
            AssertEqual(recommendedLabel, createdLabel);

            createdLabel = GetSensitivityLabel(client, resourceGroupName, serverName, databaseName, s_SchemaName, s_TableName, columnName);
            AssertEqual(recommendedLabel, createdLabel);

            sensitivityLabels = ListRecommendedSensitivityLabels(client, resourceGroupName, serverName, databaseName);
            Assert.NotNull(sensitivityLabels);
            Assert.Equal(recommendedLabelsCount - 1, sensitivityLabels.Count());

            DeleteSensitivityLabel(client, resourceGroupName, serverName, databaseName, s_SchemaName, s_TableName, columnName);

            sensitivityLabels = ListRecommendedSensitivityLabels(
                client, resourceGroupName, serverName, databaseName);
            Assert.NotNull(sensitivityLabels);
            Assert.Equal(recommendedLabelsCount, sensitivityLabels.Count());
        }

        protected virtual void DeleteSensitivityLabel(ISqlManagementClient client,
            string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            client.SensitivityLabels.Delete(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName);
        }

        protected virtual SensitivityLabel GetSensitivityLabel(ISqlManagementClient client,
            string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName)
        {
            return client.SensitivityLabels.Get(resourceGroupName, serverName, databaseName,
                schemaName, tableName, columnName, SensitivityLabelSource.Current);
        }

        protected virtual SensitivityLabel CreateOrUpdateSensitivityLabel(ISqlManagementClient client,
            string resourceGroupName, string serverName, string databaseName,
            string schemaName, string tableName, string columnName, SensitivityLabel label)
        {
            return client.SensitivityLabels.CreateOrUpdate(
                resourceGroupName, serverName, databaseName, schemaName, tableName, columnName, label);
        }

        protected virtual IPage<SensitivityLabel> ListCurrentSensitivityLabels(ISqlManagementClient client,
            string resourceGroupName, string serverName, string databaseName)
        {
            return client.SensitivityLabels.ListCurrentByDatabase(
                resourceGroupName, serverName, databaseName);
        }

        protected virtual IPage<SensitivityLabel> ListRecommendedSensitivityLabels(ISqlManagementClient client,
            string resourceGroupName, string serverName, string databaseName)
        {
            return client.SensitivityLabels.ListRecommendedByDatabase(
                resourceGroupName, serverName, databaseName);
        }

        protected static void CreateTableIfNeeded(string serverName, string fullyQualifiedDomainName,
            string databaseName)
        {
            if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Playback)
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
                {
                    DataSource = string.Format(fullyQualifiedDomainName, serverName),
                    UserID = SqlManagementTestUtilities.DefaultLogin,
                    Password = SqlManagementTestUtilities.DefaultPassword,
                    InitialCatalog = databaseName
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(string.Format(@"
                            CREATE TABLE {0} (
                                PersonID int,
                                LastName varchar(255),
                                FirstName varchar(255),
                                Address varchar(255),
                                City varchar(255)
                            );", s_TableName), connection);
                    command.ExecuteNonQuery();
                }

                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }

        private static void AssertEqual(SensitivityLabel expected, SensitivityLabel actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.LabelName, actual.LabelName);
            Assert.Equal(expected.LabelId, actual.LabelId);
            Assert.Equal(expected.InformationType, actual.InformationType);
            Assert.Equal(expected.InformationTypeId, actual.InformationTypeId);
            Assert.Equal(expected.Type, actual.Type);
        }
    }
}
