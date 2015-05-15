﻿//
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
            props.DataMaskingState = "Disabled";
            props.MaskingLevel = "Relaxed";
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
            Assert.Equal(expected.MaskingLevel, actual.MaskingLevel);
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
            properties.MaskingLevel = "Relaxed";
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
        /// <param name="uniqueId">A unique id to act as a seed for the ruleId, the masked table name and the masked column name</param>
        /// <returns>A DataMaskingRuleProperties describing the rule</returns>
        private DataMaskingRuleProperties MakeRuleProperties(int uniqueId)
        {
            DataMaskingRuleProperties props = new DataMaskingRuleProperties();
            props.Id = "ruleId" + uniqueId;
            props.TableName = "t-name " + uniqueId;
            props.ColumnName = "col-name " + uniqueId;
            props.AliasName = null;
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
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.TableName, actual.TableName);
            Assert.Equal(expected.ColumnName, actual.ColumnName);
            Assert.Equal(expected.AliasName, actual.AliasName);
            Assert.Equal(expected.MaskingFunction, actual.MaskingFunction);
            Assert.Equal(expected.NumberFrom, actual.NumberFrom);
            Assert.Equal(expected.NumberTo, actual.NumberTo);
            Assert.Equal(expected.PrefixSize, actual.PrefixSize);
            Assert.Equal(expected.ReplacementString, actual.ReplacementString);
            Assert.Equal(expected.SuffixSize, actual.SuffixSize);
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
            DataMaskingPolicyCreateOrUpdateParameters policyParams = new DataMaskingPolicyCreateOrUpdateParameters();
            policyParams.Properties = MakeDefaultDataMaskingPolicyProperties();
            policyParams.Properties.MaskingLevel = "Relaxed";
            sqlClient.DataMasking.CreateOrUpdatePolicy(resourceGroupName, server.Name, database.Name, policyParams);
 
            int ruleCounter = 1;
            DataMaskingRuleCreateOrUpdateParameters ruleParams = new DataMaskingRuleCreateOrUpdateParameters();
            ruleParams.Properties = MakeRuleProperties(ruleCounter++);
            string rule1Name = ruleParams.Properties.Id;
            var createRuleResponse = sqlClient.DataMasking.CreateOrUpdateRule(resourceGroupName, server.Name, database.Name, rule1Name, ruleParams);

            // Verify that the initial create request went well.
            TestUtilities.ValidateOperationResponse(createRuleResponse, HttpStatusCode.OK);
            
            var getAfterCreateResponse = sqlClient.DataMasking.GetRule(resourceGroupName, server.Name, database.Name, rule1Name);

            TestUtilities.ValidateOperationResponse(getAfterCreateResponse, HttpStatusCode.OK);
            VerifyDataMaskingRuleInformation(getAfterCreateResponse.DataMaskingRule.Properties, ruleParams.Properties);

            // Modify the policy properties, send and receive, see it its still ok
            ruleParams.Properties.TableName = "tbl2";

            var updateResponse = sqlClient.DataMasking.CreateOrUpdateRule(resourceGroupName, server.Name, database.Name, rule1Name, ruleParams);

            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            var getAfterUpdateResponse = sqlClient.DataMasking.GetRule(resourceGroupName, server.Name, database.Name, rule1Name);

            TestUtilities.ValidateOperationResponse(getAfterUpdateResponse, HttpStatusCode.OK);
            VerifyDataMaskingRuleInformation(getAfterUpdateResponse.DataMaskingRule.Properties, ruleParams.Properties);

            DataMaskingRuleCreateOrUpdateParameters ruleParams2 = new DataMaskingRuleCreateOrUpdateParameters();
            ruleParams2.Properties = MakeRuleProperties(ruleCounter++);
            string rule2Name = ruleParams2.Properties.Id;

            createRuleResponse = sqlClient.DataMasking.CreateOrUpdateRule(resourceGroupName, server.Name, database.Name, rule2Name, ruleParams2);
            TestUtilities.ValidateOperationResponse(updateResponse, HttpStatusCode.OK);

            DataMaskingRuleListResponse listResponse = sqlClient.DataMasking.List(resourceGroupName, server.Name, database.Name);
            TestUtilities.ValidateOperationResponse(listResponse, HttpStatusCode.OK);

            Assert.Equal(2, listResponse.DataMaskingRules.Count);

            VerifyDataMaskingRuleInformation(listResponse.DataMaskingRules.FirstOrDefault(r => r.Name == rule1Name).Properties, ruleParams.Properties);
            VerifyDataMaskingRuleInformation(listResponse.DataMaskingRules.FirstOrDefault(r => r.Name == rule2Name).Properties, ruleParams2.Properties);

            AzureOperationResponse deleteResponse = sqlClient.DataMasking.Delete(resourceGroupName, server.Name, database.Name, rule1Name);
            TestUtilities.ValidateOperationResponse(deleteResponse, HttpStatusCode.OK);

            DataMaskingRuleListResponse listAfterDeleteResponse = sqlClient.DataMasking.List(resourceGroupName, server.Name, database.Name);
            TestUtilities.ValidateOperationResponse(listAfterDeleteResponse, HttpStatusCode.OK);

            Assert.Equal(listAfterDeleteResponse.DataMaskingRules.Count, 1);
            VerifyDataMaskingRuleInformation(listResponse.DataMaskingRules.FirstOrDefault(r => r.Name == rule2Name).Properties, ruleParams2.Properties);
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
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "2.0", TestDataMaskingPolicyAPIs);
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
                Sql2ScenarioHelper.RunDatabaseTestInEnvironment(new BasicDelegatingHandler(), "2.0", TestDataMaskingRuleAPIs);
            }
        }
    }
}
