// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

namespace Sql.Tests
{
    public class DataMaskingScenarioTests
    {
        [Fact]
        public void TestCreateUpdateGetDataMaskingRules()
        {
            string testPrefix = "sqldatamaskingcrudtest-";
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                Server server = context.CreateServer(resourceGroup);

                // Create database
                //
                string dbName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                });
                Assert.NotNull(db1);

                // Create server firewall rule
                sqlClient.FirewallRules.CreateOrUpdate(resourceGroup.Name, server.Name, "sqltestrule", new FirewallRule()
                {
                    StartIpAddress = "0.0.0.0",
                    EndIpAddress = "255.255.255.255"
                });

                // Create test table with columns
                // This is not needed in playback because in playback, there is no actual database to execute against
                HttpRecorderMode testMode = HttpMockServer.GetCurrentMode();

                if (testMode != HttpRecorderMode.Playback)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
                    {
                        DataSource = string.Format(server.FullyQualifiedDomainName, server.Name),
                        UserID = SqlManagementTestUtilities.DefaultLogin,
                        Password = SqlManagementTestUtilities.DefaultPassword,
                        InitialCatalog = dbName
                    };

                    using (SqlConnection conn = new SqlConnection(builder.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand("create table table1 (column1 int, column2 nvarchar(max))", conn);

                        command.ExecuteNonQuery();
                    }
                }

                // Verify Policy is disabled to begin with
                DataMaskingPolicy policy = sqlClient.DataMaskingPolicies.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(DataMaskingState.Disabled, policy.DataMaskingState);

                // Create a Number data masking rule (enables the data masking policy)
                DataMaskingRule numberRule = new DataMaskingRule()
                {
                    SchemaName = "dbo",
                    TableName = "table1",
                    ColumnName = "column1",
                    MaskingFunction = DataMaskingFunction.Number,
                    NumberFrom = "0",
                    NumberTo = "10"
                };
                
                // Create a Text data masking rule
                DataMaskingRule textRule = new DataMaskingRule()
                {
                    SchemaName = "dbo",
                    TableName = "table1",
                    ColumnName = "column2",
                    MaskingFunction = DataMaskingFunction.Text,
                    PrefixSize = "1",
                    SuffixSize = "1",
                    ReplacementString = "teststring"
                };

                // Not creating datamasking rule names because name is ignored when creating the rules anyway
                sqlClient.DataMaskingRules.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, "name", numberRule);
                sqlClient.DataMaskingRules.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, "name2", textRule);

                // Verify Policy is now enabled
                policy = sqlClient.DataMaskingPolicies.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(DataMaskingState.Enabled, policy.DataMaskingState);

                // List data masking rules
                IEnumerable<DataMaskingRule> rules = sqlClient.DataMaskingRules.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(2, rules.Count());

                // Verify number rule
                numberRule = rules.FirstOrDefault(rule => rule.MaskingFunction == DataMaskingFunction.Number);
                Assert.Equal("dbo", numberRule.SchemaName);
                Assert.Equal("table1", numberRule.TableName);
                Assert.Equal("column1", numberRule.ColumnName);
                Assert.Equal("0", numberRule.NumberFrom);
                Assert.Equal("10", numberRule.NumberTo);

                // Verify text rule
                textRule = rules.FirstOrDefault(rule => rule.MaskingFunction == DataMaskingFunction.Text);
                Assert.Equal("dbo", textRule.SchemaName);
                Assert.Equal("table1", textRule.TableName);
                Assert.Equal("column2", textRule.ColumnName);
                Assert.Equal("1", textRule.PrefixSize);
                Assert.Equal("1", textRule.SuffixSize);
                Assert.Equal("teststring", textRule.ReplacementString);

                // Delete one rule through PUT
                numberRule.RuleState = DataMaskingRuleState.Disabled;
                sqlClient.DataMaskingRules.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, "name", numberRule);

                // List data masking rules
                rules = sqlClient.DataMaskingRules.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(1, rules.Count());
                
                // Verify Policy now enabled
                policy = sqlClient.DataMaskingPolicies.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(DataMaskingState.Enabled, policy.DataMaskingState);

                // Disable data masking policy (this deletes data masking rules)
                sqlClient.DataMaskingPolicies.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new DataMaskingPolicy()
                {
                    DataMaskingState = DataMaskingState.Disabled
                });

                // Verify policy is disabled
                policy = sqlClient.DataMaskingPolicies.Get(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(DataMaskingState.Disabled, policy.DataMaskingState);

                // Verify no rules are returned
                rules = sqlClient.DataMaskingRules.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.Equal(0, rules.Count());
            };
        }
    }
}
