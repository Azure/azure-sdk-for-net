using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class SensitivityLabelsScenarioTests
    {
        private const string s_Current = "current";
        private const string s_DatabaseNamePrefix = "sqldatabasesensitivitylabelscrudtest-";
        private const string s_SchemaName = "dbo";
        private const string s_TableName = "Persons";

        [Fact]
        public void TestDatabaseSensitivityLabels()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                ISqlManagementClient client = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);
                client.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, "sqltestrule", new FirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                });

                Database database = client.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, SqlManagementTestUtilities.GenerateName(s_DatabaseNamePrefix), new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(database);

                if (HttpMockServer.GetCurrentMode() != HttpRecorderMode.Playback)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
                    {
                        DataSource = string.Format(server.FullyQualifiedDomainName, server.Name),
                        UserID = SqlManagementTestUtilities.DefaultLogin,
                        Password = SqlManagementTestUtilities.DefaultPassword,
                        InitialCatalog = database.Name
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

                    SleepIfNeeded();
                    IPage<SensitivityLabel> sensitivityLabels = client.SensitivityLabels.ListByDatabase(resourceGroup.Name, server.Name, database.Name);
                    Assert.NotNull(sensitivityLabels);
                    Assert.NotEmpty(sensitivityLabels);
                    Assert.DoesNotContain(sensitivityLabels, label => label.Name.Equals(s_Current));
                    int labelsCount = sensitivityLabels.Count();
                    SensitivityLabel sensitivityLabel = sensitivityLabels.First();
                    string columnName = sensitivityLabel.Id.Split("/")[16];

                    SensitivityLabel responseLabel = client.SensitivityLabels.CreateOrUpdate(
                        resourceGroup.Name, server.Name, database.Name, s_SchemaName, s_TableName, columnName,
                        new SensitivityLabel(labelName: sensitivityLabel.LabelName, informationType: sensitivityLabel.InformationType));
                    AssertEqual(sensitivityLabel, responseLabel);

                    responseLabel = client.SensitivityLabels.Get(resourceGroup.Name, server.Name, database.Name, s_SchemaName, s_TableName, columnName, SensitivityLabelSource.Current);
                    AssertEqual(sensitivityLabel, responseLabel);

                    sensitivityLabels = client.SensitivityLabels.ListByDatabase(resourceGroup.Name, server.Name, database.Name);
                    Assert.NotNull(sensitivityLabels);
                    Assert.Equal(labelsCount, sensitivityLabels.Count());
                    Assert.Equal(labelsCount - 1, sensitivityLabels.Where(l => l.Name == "recommended").Count());
                    Assert.Contains(sensitivityLabels, label => label.Name.Equals(s_Current));

                    client.SensitivityLabels.Delete(resourceGroup.Name, server.Name, database.Name, s_SchemaName, s_TableName, columnName);

                    sensitivityLabels = client.SensitivityLabels.ListByDatabase(resourceGroup.Name, server.Name, database.Name);
                    Assert.NotNull(sensitivityLabels);
                    Assert.Equal(labelsCount, sensitivityLabels.Count());
                    Assert.DoesNotContain(sensitivityLabels, label => label.Name.Equals(s_Current));

                    client.Databases.Delete(resourceGroup.Name, server.Name, database.Name);
                    client.Servers.Delete(resourceGroup.Name, server.Name);
                }
            }
        }

        private static void SleepIfNeeded()
        {
            // Sleep if we are running live to avoid hammering the server.
            // No need to sleep if we are playing back the recording.
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }

        private static void AssertEqual(SensitivityLabel expected, SensitivityLabel actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.LabelName, actual.LabelName);
            Assert.Equal(expected.InformationType, actual.InformationType);
            Assert.Equal(expected.Type, actual.Type);
            Assert.Equal(s_Current, actual.Name);
        }
    }
}
