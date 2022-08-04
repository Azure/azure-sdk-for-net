// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class DataConnectorsTests : TestBase
    {
        #region Test setup

        #endregion

        #region DataConnectors

        [Fact]
        public void DataConnectors_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestHelper.TestEnvironment.SubscriptionId.ToString()
                };

                SecurityInsightsClient.DataConnectors.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId, DataConnectorBody);
                var DataConnectors = SecurityInsightsClient.DataConnectors.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateDataConnectors(DataConnectors);
                SecurityInsightsClient.DataConnectors.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId);
            }
        }

        [Fact]
        public void DataConnectors_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestHelper.TestEnvironment.SubscriptionId.ToString()                    

                };

                var DataConnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId, DataConnectorBody);
                ValidateDataConnector(DataConnector);
                SecurityInsightsClient.DataConnectors.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId);
            }
        }

        [Fact]
        public void DataConnectors_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestHelper.TestEnvironment.SubscriptionId.ToString()

                };

                SecurityInsightsClient.DataConnectors.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId, DataConnectorBody);
                var DataConnector = SecurityInsightsClient.DataConnectors.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId);
                ValidateDataConnector(DataConnector);
                SecurityInsightsClient.DataConnectors.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId);

            }
        }

        [Fact]
        public void DataConnectors_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestHelper.TestEnvironment.SubscriptionId.ToString()

                };

                SecurityInsightsClient.DataConnectors.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId, DataConnectorBody);
                SecurityInsightsClient.DataConnectors.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorId);
            }
        }

        [Fact]
        public void DataConnectors_CheckRequirements()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var DataConnectorsCheckRequirements = new ASCCheckRequirements()
                {
                    SubscriptionId = TestHelper.TestEnvironment.SubscriptionId.ToString()
                }; 

                var DataConnectorCheckRequirement = SecurityInsightsClient.DataConnectorsCheckRequirements.Post(TestHelper.ResourceGroup, TestHelper.WorkspaceName, DataConnectorsCheckRequirements);
                ValidateDataConnectorCheckRequirement(DataConnectorCheckRequirement);
            }
        }

        #endregion

        #region Validations

        private void ValidateDataConnectors(IPage<DataConnector> DataConnectorpage)
        {
            Assert.True(DataConnectorpage.IsAny());

            DataConnectorpage.ForEach(ValidateDataConnector);
        }

        private void ValidateDataConnector(DataConnector DataConnector)
        {
            Assert.NotNull(DataConnector);
        }

        private void ValidateDataConnectorCheckRequirement(DataConnectorRequirementsState DataConnectorCheckRequirement)
        {
            Assert.NotNull(DataConnectorCheckRequirement);
        }

        #endregion
    }
}
