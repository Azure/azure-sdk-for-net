// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityInsights.Tests.Helpers;
using Xunit;

namespace SecurityInsights.Tests
{
    public class DataConnectorsTests : TestBase
    {
        #region Test setup

        private static string ResourceGroup = "ndicola-pfsense";
        private static string WorkspaceName = "ndicola-pfsense";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var SecurityInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityInsightsClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityInsightsClient>(handlers: handler);

            return SecurityInsightsClient;
        }

        #endregion

        #region DataConnectors

        [Fact]
        public void DataConnectors_List()
        {
            Thread.Sleep(3000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestEnvironment.SubscriptionId.ToString()

                };

                SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroup, WorkspaceName, DataConnectorId, DataConnectorBody);
                var DataConnectors = SecurityInsightsClient.DataConnectors.List(ResourceGroup, WorkspaceName);
                ValidateDataConnectors(DataConnectors);
                SecurityInsightsClient.DataConnectors.Delete(ResourceGroup, WorkspaceName, DataConnectorId);
            }
        }

        [Fact]
        public void DataConnectors_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestEnvironment.SubscriptionId.ToString()                    

                };

                var DataConnector = SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroup, WorkspaceName, DataConnectorId, DataConnectorBody);
                ValidateDataConnector(DataConnector);
                SecurityInsightsClient.DataConnectors.Delete(ResourceGroup, WorkspaceName, DataConnectorId);
            }
        }

        [Fact]
        public void DataConnectors_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestEnvironment.SubscriptionId.ToString()

                };

                SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroup, WorkspaceName, DataConnectorId, DataConnectorBody);
                var DataConnector = SecurityInsightsClient.DataConnectors.Get(ResourceGroup, WorkspaceName, DataConnectorId);
                ValidateDataConnector(DataConnector);
                SecurityInsightsClient.DataConnectors.Delete(ResourceGroup, WorkspaceName, DataConnectorId);

            }
        }

        [Fact]
        public void DataConnectors_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var DataConnectorId = Guid.NewGuid().ToString();
                var DataConnectorBody = new ASCDataConnector()
                {
                    DataTypes = new AlertsDataTypeOfDataConnector() { Alerts = new DataConnectorDataTypeCommon() { State = "enabled" } },
                    SubscriptionId = TestEnvironment.SubscriptionId.ToString()

                };

                SecurityInsightsClient.DataConnectors.CreateOrUpdate(ResourceGroup, WorkspaceName, DataConnectorId, DataConnectorBody);
                SecurityInsightsClient.DataConnectors.Delete(ResourceGroup, WorkspaceName, DataConnectorId);
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

        #endregion
    }
}
