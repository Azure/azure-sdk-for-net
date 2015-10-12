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

using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Sql2.Tests.ScenarioTests
{
    /// <summary>
    /// Contains tests for the lifecycle of a Database data masking policy and data masking rules
    /// </summary>
    public class Sql2DataMaskingScenarioTests
    {
        /// <summary>
        /// Creates and returns a DataMaskingPolicyProperties object that holds the default settings for a data masking policy
        /// </summary>
        /// <returns>A DataMaskingPolicyProperties object with the default policy settings</returns>
        private DataMaskingPolicyProperties MakeDefaultDataMaskingPolicyProperties()
        {
            DataMaskingPolicyProperties props = new DataMaskingPolicyProperties();
            props.DataMaskingState = "NewCustomer";
            props.ExemptPrincipals = "";
            return props;
        }
        
        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="expected">The expected value of the properties object</param>
        /// <param name="actual">The properties object that needs to be checked</param>
        private static void VerifyDataMaskingPolicyInformation(DataMaskingPolicyProperties expected, DataMaskingPolicyProperties actual)
        {
            Assert.Equal(expected.DataMaskingState, actual.DataMaskingState);
            Assert.Equal(expected.ExemptPrincipals, actual.ExemptPrincipals);
        }

        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle of a given database's data masking policy. It is meant to be called with a name of an already exisiting database (and therefore already existing 
        /// server and resource group). This test does not create these resources and does not remove them.
        /// </summary>
        private void TestDataMaskingPolicyAPIs(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            DataMaskingPolicyGetResponse getDefaultPolicyResponse = sqlClient.DataMasking.GetPolicy(resourceGroupName, server.Name, database.Name);
            DataMaskingPolicyProperties properties = getDefaultPolicyResponse.DataMaskingPolicy.Properties;
            
            // Verify that the initial Get request contains the default policy.
            TestUtilities.ValidateOperationResponse(getDefaultPolicyResponse, HttpStatusCode.OK);
            VerifyDataMaskingPolicyInformation(MakeDefaultDataMaskingPolicyProperties(), properties);

            // Modify the policy properties, send and receive, see it its still ok
            properties.DataMaskingState = "Enabled";
            properties.ExemptPrincipals = "principal1;principal2";
            DataMaskingPolicyCreateOrUpdateParameters updateParams = new DataMaskingPolicyCreateOrUpdateParameters(); 
            updateParams.Properties = properties;

            var updateResponse = sqlClient.DataMasking.CreateOrUpdatePolicy(resourceGroupName, server.Name, database.Name, updateParams);

            // Verify that the initial Get request of contains the default policy.
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            DataMaskingPolicyGetResponse getUpdatedPolicyResponse = sqlClient.DataMasking.GetPolicy(resourceGroupName, server.Name, database.Name);
            DataMaskingPolicyProperties updatedProperties = getUpdatedPolicyResponse.DataMaskingPolicy.Properties;

            // Verify that the Get request contains the updated policy.
            TestUtilities.ValidateOperationResponse(getUpdatedPolicyResponse, HttpStatusCode.OK);
            VerifyDataMaskingPolicyInformation(properties, updatedProperties);
        }

        /// <summary>
        /// Create a data masking rule
        /// </summary>
        private DataMaskingRuleProperties MakeRuleProperties(string schema, string table, string column)
        {
            DataMaskingRuleProperties props = new DataMaskingRuleProperties();
            props.SchemaName = schema;
            props.TableName = table;
            props.ColumnName = column;
            props.MaskingFunction = "Default";
            props.NumberFrom = null;
            props.NumberTo = null;
            props.PrefixSize = null;
            props.SuffixSize = null;
            props.ReplacementString = null;
            return props;
        }

        /// <summary>
        /// Verify that the received properties match their expected values
        /// </summary>
        /// <param name="actual">The properties object that needs to be checked</param>
        /// <param name="expected">The expected value of the properties object</param>
        private static void VerifyDataMaskingRuleInformation(DataMaskingRuleProperties actual, DataMaskingRuleProperties expected)
        {
            Assert.Equal(expected.TableName, actual.TableName);
            Assert.Equal(expected.ColumnName, actual.ColumnName);   
            Assert.Equal(expected.MaskingFunction, actual.MaskingFunction);
            Assert.Equal(expected.NumberFrom, actual.NumberFrom);
            Assert.Equal(expected.NumberTo, actual.NumberTo);
            Assert.Equal(expected.PrefixSize, actual.PrefixSize);
            Assert.Equal(expected.ReplacementString, actual.ReplacementString);
            Assert.Equal(expected.SuffixSize, actual.SuffixSize);
        }

        private void CreateDatabaseContents(SqlConnection conn, string table, string column)
        {
            try
            {
                conn.Open();
                string query = string.Format("CREATE TABLE {0} ({1} NVARCHAR(20) NOT NULL)", table, column);
                var command = conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// The non-boilerplated test code of the APIs for managing the lifecycle data masking rules. 
        /// It is meant to be called with a name of an already exisiting database (and therefore already existing server and resource group). 
        /// This test does not create these resources and does not remove them.
        /// The flow is:
        /// 1) Create policy (it's a prereq)
        /// 2) Create rule1, validate its creation and its content by doing another GET call
        /// 3) Update rule1, validate the update by doing another GET call
        /// 4) Create rule2, validate its creation and its content
        /// 5) Get the list of rules, see that there are two and each one of them has the right content
        /// 6) Delete rule1, see that we get OK
        /// 8) List the rules, see that we now have one rule there and it is rule 2
        /// </summary>
        /// <param name="sqlClient">The sqlClient</param>
        /// <param name="resourceGroupName">The resource group name to use in this test</param>
        /// <param name="server">The server to use in this test</param>
        /// <param name="database">The database to use in this test</param>
        private void TestDataMaskingRuleAPIs(SqlManagementClient sqlClient, string resourceGroupName, Server server, Database database)
        {
            DataMaskingPolicyCreateParameters policyParams = new DataMaskingPolicyCreateParameters();
            policyParams.Properties = MakeDefaultDataMaskingPolicyProperties();
            policyParams.Properties.DataMaskingState = "Enabled";
            sqlClient.DataMasking.CreateOrUpdatePolicy(resourceGroupName, server.Name, database.Name, policyParams);
 
            int ruleCounter = 1;
            DataMaskingRuleCreateOrUpdateParameters ruleParams = new DataMaskingRuleCreateOrUpdateParameters();
            string serverName = server.Properties.FullyQualifiedDomainName;
            string uid = server.Properties.AdministratorLogin;
            string pwd = server.Properties.AdministratorLoginPassword;
            string dbName = database.Name;
            string connString = string.Format("Server={0};uid={1}; pwd={2};Database={3};Integrated Security=False;", serverName, uid, pwd, dbName);
            var conn = new SqlConnection();
            conn.ConnectionString = connString;
            string schemaName = "DBO";
            string tableName = "table1", columnName = "column1";

            string firewallRuleName = TestUtilities.GenerateName("all");
            string startIp1 = "1.1.1.1";
            string endIp1 = "255.255.255.255";

            sqlClient.FirewallRules.CreateOrUpdate(resourceGroupName, serverName.Split('.').ElementAt(0), firewallRuleName, new FirewallRuleCreateOrUpdateParameters()
            {
                Properties = new FirewallRuleCreateOrUpdateProperties()
                {
                    StartIpAddress = startIp1,
                    EndIpAddress = endIp1,
                }
            });
            CreateDatabaseContents(conn, tableName, columnName);

            Func<DataMaskingRuleCreateOrUpdateParameters, Predicate<DataMaskingRule>> isRuleOnColumn = (DataMaskingRuleCreateOrUpdateParameters parms) =>
            {
                return (DataMaskingRule r1) =>
                {
                    return parms.Properties.ColumnName == r1.Properties.ColumnName &&
                   parms.Properties.TableName == r1.Properties.TableName &&
                   parms.Properties.SchemaName == r1.Properties.SchemaName;
                };
            };

            ruleParams.Properties = MakeRuleProperties(schemaName, tableName, columnName);
            var createRuleResponse = sqlClient.DataMasking.CreateRule(resourceGroupName, server.Name, database.Name, ruleParams);

            // Verify that the initial create request went well.
            TestUtilities.ValidateOperationResponse(createRuleResponse, HttpStatusCode.OK);
            
            var listAfterCreateResponse = sqlClient.DataMasking.List(resourceGroupName, server.Name, database.Name);
            TestUtilities.ValidateOperationResponse(listAfterCreateResponse, HttpStatusCode.OK);

            var onColumnOfFirstCreatedRule = isRuleOnColumn(ruleParams);
           // VerifyDataMaskingRuleInformation((listAfterCreateResponse.DataMaskingRules.FirstOrDefault(r => onColumnOfFirstCreatedRule(r)).Properties, ruleParams.Properties);

            // Modify the policy properties, send and receive, see it its still ok
            string updatedTableName = "tbl2";
            CreateDatabaseContents(conn, updatedTableName, columnName);
            
            ruleParams.Properties.TableName = updatedTableName;
            var updateResponse = sqlClient.DataMasking.CreateRule(resourceGroupName, server.Name, database.Name, ruleParams);
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

                        
            var getAfterUpdateResponse = sqlClient.DataMasking.List(resourceGroupName, server.Name, database.Name);
            var onColumnOfFirstCreatedRule = isRuleOnColumn(ruleParams);
            TestUtilities.ValidateOperationResponse(getAfterUpdateResponse, HttpStatusCode.OK);


            VerifyDataMaskingRuleInformation(getAfterUpdateResponse.DataMaskingRule.Properties, ruleParams.Properties);

            DataMaskingRuleCreateOrUpdateParameters ruleParams2 = new DataMaskingRuleCreateOrUpdateParameters();
            tableName = "table2";
            columnName = "column2";
            CreateDatabaseContents(conn, tableName, columnName);
            ruleParams2.Properties = MakeRuleProperties(schemaName, tableName, columnName);

            createRuleResponse = sqlClient.DataMasking.CreateOrUpdateRule(resourceGroupName, server.Name, database.Name, ruleParams2);
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            DataMaskingRuleListResponse listResponse = sqlClient.DataMasking.List(resourceGroupName, server.Name, database.Name);
            TestUtilities.ValidateOperationResponse(listResponse, HttpStatusCode.OK);

            Assert.Equal(2, listResponse.DataMaskingRules.Count);
 

            var onColumnOfFirstRule = isRuleOnColumn(ruleParams);
            VerifyDataMaskingRuleInformation(listResponse.DataMaskingRules.FirstOrDefault(r => onColumnOfFirstRule(r)).Properties, ruleParams.Properties);
            var onColumnOfSecondRule = isRuleOnColumn(ruleParams2);
            VerifyDataMaskingRuleInformation(listResponse.DataMaskingRules.FirstOrDefault(r => onColumnOfSecondRule(r)).Properties, ruleParams2.Properties);

            AzureOperationResponse deleteResponse = sqlClient.DataMasking.Delete(resourceGroupName, server.Name, database.Name);
            TestUtilities.ValidateOperationResponse(deleteResponse, HttpStatusCode.OK);

            DataMaskingRuleListResponse listAfterDeleteResponse = sqlClient.DataMasking.List(resourceGroupName, server.Name, database.Name);
            TestUtilities.ValidateOperationResponse(listAfterDeleteResponse, HttpStatusCode.OK);

            Assert.Equal(listAfterDeleteResponse.DataMaskingRules.Count, 1);
            VerifyDataMaskingRuleInformation(listResponse.DataMaskingRules.FirstOrDefault(r => r.Properties.Id == rule2Name).Properties, ruleParams2.Properties);
        }
    
        /// <summary>
        /// Test for the data masking policy lifecycle
        /// </summary>
        [Fact]
        public void DataMaskingPolicyLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestDataMaskingPolicyAPIs);
            }
        }

        /// <summary>
        /// Test for the data masking policy lifecycle
        /// </summary>
        [Fact]
        public void DataMaskingRuleLifecycleTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "12.0", TestDataMaskingRuleAPIs);
            }
        }
    }
}
