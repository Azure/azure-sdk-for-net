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

namespace CustomerInsights.Tests.Tests
{
    using System;
    using System.Collections.Generic;
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
                var interactionResourceFormat = new InteractionResourceFormat
                                                    {
                                                        ApiEntitySetName = interactionName,
                                                        PrimaryParticipantProfilePropertyName = "profile1",
                                                        IdPropertyNames = new[] { interactionName },
                                                        Fields =
                                                            new[]
                                                                {
                                                                    new PropertyDefinition
                                                                        {
                                                                            FieldName = interactionName,
                                                                            FieldType = "Edm.String",
                                                                            IsArray = false,
                                                                            IsRequired = true
                                                                        },
                                                                    new PropertyDefinition
                                                                        {
                                                                            FieldName = "profile1",
                                                                            FieldType = "Edm.String",
                                                                            IsArray = false,
                                                                            IsRequired = false
                                                                        }
                                                                },
                                                        SmallImage = "\\Images\\smallImage",
                                                        MediumImage = "\\Images\\MediumImage",
                                                        LargeImage = "\\Images\\LargeImage"
                                                    };

                var connectorName = TestUtilities.GenerateName("testConnector");
                var connectorResourceFormat = new ConnectorResourceFormat
                                                  {
                                                      DisplayName = connectorName,
                                                      Description = "Test connector",
                                                      ConnectorType = ConnectorTypes.AzureBlob,
                                                      ConnectorProperties =
                                                          new Dictionary<string, object>
                                                              {
                                                                      {
                                                                          "connectionKeyVaultUrl",
                                                                          $"vault=off;DefaultEndpointsProtocol=https;AccountName=XXX;AccountKey=XXX"
                                                                      }
                                                              }
                                                  };

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

                var interactionResult = aciClient.Interactions.CreateOrUpdate(
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
                    createdMapping.Type,
                    "Microsoft.CustomerInsights/hubs/connectors/mappings",
                    StringComparer.OrdinalIgnoreCase);

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
                    getMapping.Type,
                    "Microsoft.CustomerInsights/hubs/connectors/mappings",
                    StringComparer.OrdinalIgnoreCase);

                var result = aciClient.ConnectorMappings.ListByConnector(ResourceGroupName, HubName, connectorName);
                Assert.True(result.ToList().Count >= 1);
                Assert.True(
                    result.ToList().Any(mappingReturned => connectorMappingName == mappingReturned.ConnectorMappingName));

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