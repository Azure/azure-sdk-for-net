// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ConnectorScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static ConnectorScenarioTests()
        {
            HubName = AppSettings.HubName;
            ResourceGroupName = AppSettings.ResourceGroupName;
        }

        /// <summary>
        ///     Hub Name
        /// </summary>
        private static readonly string HubName;

        /// <summary>
        ///     Reosurce Group Name
        /// </summary>
        private static readonly string ResourceGroupName;

        [Fact]
        public void CrdConnectorFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var connectorName = TestUtilities.GenerateName("testConnector");
                var connectorResourceFormat = Helpers.GetTestConnector(connectorName, "Test connector");

                var createdConnector = aciClient.Connectors.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    connectorName,
                    connectorResourceFormat);

                Assert.Equal(connectorName, createdConnector.ConnectorName);
                Assert.Equal(createdConnector.Name, HubName + "/" + connectorName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/connectors",
                    createdConnector.Type, StringComparer.OrdinalIgnoreCase);

                var getConnector = aciClient.Connectors.Get(ResourceGroupName, HubName, connectorName);

                Assert.Equal(connectorName, getConnector.ConnectorName);
                Assert.Equal(getConnector.Name, HubName + "/" + connectorName, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/connectors",
                    getConnector.Type, StringComparer.OrdinalIgnoreCase);

                var deleteConnectorResponse =
                    aciClient.Connectors.DeleteWithHttpMessagesAsync(ResourceGroupName, HubName, connectorName).Result;

                Assert.Equal(HttpStatusCode.OK, deleteConnectorResponse.Response.StatusCode);
            }
        }

        [Fact]
        public void ListConnectorsInHub()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var connectorName1 = "testConnector1";
                var connectorResourceFormat1 = Helpers.GetTestConnector(connectorName1, "Test connector 1");

                var connectorName2 = "testConnector2";
                var connectorResourceFormat2 = Helpers.GetTestConnector(connectorName2, "Test connector 2");

                aciClient.Connectors.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    connectorName1,
                    connectorResourceFormat1);
                aciClient.Connectors.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    connectorName2,
                    connectorResourceFormat2);

                var result = aciClient.Connectors.ListByHub(ResourceGroupName, HubName);
                Assert.True(result.ToList().Count >= 2);
                Assert.True(
                    result.ToList().Any(connectorReturned => connectorName1 == connectorReturned.ConnectorName)
                    && result.ToList().Any(connectorReturned => connectorName2 == connectorReturned.ConnectorName));
            }
        }
    }
}