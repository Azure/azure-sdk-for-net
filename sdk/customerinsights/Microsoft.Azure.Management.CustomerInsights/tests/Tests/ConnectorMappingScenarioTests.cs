// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.CustomerInsights;
    using Microsoft.Azure.Management.CustomerInsights.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    public class ConnectorMappingScenarioTests
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        static ConnectorMappingScenarioTests()
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
        public void CrdConnectorMappingFullCycle()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var aciClient = context.GetServiceClient<CustomerInsightsManagementClient>();

                var interactionName = TestUtilities.GenerateName("TestInteractionType");
                var interactionResourceFormat = Helpers.GetTestInteraction(interactionName, "profile1");

                var connectorName = TestUtilities.GenerateName("testConnector");
                var connectorResourceFormat = Helpers.GetTestConnector(connectorName, "Test connector");

                var connectorMappingName = TestUtilities.GenerateName("testMapping");
                var connectorMappingResourceFormat = new ConnectorMappingResourceFormat
                                                         {
                                                             EntityType = EntityTypes.Interaction,
                                                             EntityTypeName = interactionName,
                                                             DisplayName = connectorMappingName,
                                                             Description = "Test mapping",
                                                             MappingProperties =
                                                                 new ConnectorMappingProperties
                                                                     {
                                                                         FolderPath = "http://sample.dne/file",
                                                                         FileFilter = "unknown",
                                                                         HasHeader = false,
                                                                         ErrorManagement =
                                                                             new ConnectorMappingErrorManagement
                                                                                 {
                                                                                     ErrorManagementType =
                                                                                         ErrorManagementTypes.StopImport,
                                                                                     ErrorLimit = 10
                                                                                 },
                                                                         Format =
                                                                             new ConnectorMappingFormat
                                                                                 {
                                                                                     ColumnDelimiter = "|"
                                                                                 },
                                                                         Availability =
                                                                             new ConnectorMappingAvailability
                                                                                 {
                                                                                     Frequency = FrequencyTypes.Hour,
                                                                                     Interval = 5
                                                                                 },
                                                                         Structure =
                                                                             new[]
                                                                                 {
                                                                                     new ConnectorMappingStructure
                                                                                         {
                                                                                             PropertyName = "unknwon1",
                                                                                             ColumnName = "unknown1",
                                                                                             IsEncrypted = false
                                                                                         },
                                                                                     new ConnectorMappingStructure
                                                                                         {
                                                                                             PropertyName = "unknwon2",
                                                                                             ColumnName = "unknown2",
                                                                                             IsEncrypted = true
                                                                                         }
                                                                                 },
                                                                         CompleteOperation =
                                                                             new ConnectorMappingCompleteOperation
                                                                                 {
                                                                                     CompletionOperationType =
                                                                                         CompletionOperationTypes.DeleteFile,
                                                                                     DestinationFolder = "fakePath"
                                                                                 }
                                                                     }
                                                         };

                aciClient.Interactions.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    interactionName,
                    interactionResourceFormat);
                aciClient.Connectors.CreateOrUpdate(ResourceGroupName, HubName, connectorName, connectorResourceFormat);

                var createdMapping = aciClient.ConnectorMappings.CreateOrUpdate(
                    ResourceGroupName,
                    HubName,
                    connectorName,
                    connectorMappingName,
                    connectorMappingResourceFormat);
                Assert.Equal(connectorMappingName, createdMapping.ConnectorMappingName);
                Assert.Equal(
                    createdMapping.Name,
                    HubName + "/" + connectorName + "/" + connectorMappingName,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/connectors/mappings",
                    createdMapping.Type, StringComparer.OrdinalIgnoreCase);

                var getMapping = aciClient.ConnectorMappings.Get(
                    ResourceGroupName,
                    HubName,
                    connectorName,
                    connectorMappingName);

                Assert.Equal(connectorMappingName, getMapping.ConnectorMappingName);
                Assert.Equal(
                    getMapping.Name,
                    HubName + "/" + connectorName + "/" + connectorMappingName,
                    StringComparer.OrdinalIgnoreCase);
                Assert.Equal(
                    "Microsoft.CustomerInsights/hubs/connectors/mappings",
                    getMapping.Type, StringComparer.OrdinalIgnoreCase);

                var result = aciClient.ConnectorMappings.ListByConnector(ResourceGroupName, HubName, connectorName);
                Assert.True(result.ToList().Count >= 1);
                Assert.Contains(result.ToList(), mappingReturned => connectorMappingName == mappingReturned.ConnectorMappingName);

                var deleteMappingResponse =
                    aciClient.ConnectorMappings.DeleteWithHttpMessagesAsync(
                        ResourceGroupName,
                        HubName,
                        connectorName,
                        connectorMappingName).Result;
                Assert.Equal(HttpStatusCode.OK, deleteMappingResponse.Response.StatusCode);
            }
        }
    }
}