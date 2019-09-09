// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataFactory.Tests.ScenarioTests
{
    public class TriggerScenarioTests : ScenarioTestBase<TriggerScenarioTests>
    {
        internal static TriggerResource GetTriggerResource(string description, string pipelineName, string outputBlobName)
        {
            TriggerResource resource = new TriggerResource()
            {
                Properties = new ScheduleTrigger()
                {
                    Description = description,
                    Recurrence = new ScheduleTriggerRecurrence()
                    {
                        TimeZone = "UTC",
                        StartTime = DateTime.UtcNow.AddMinutes(-1),
                        EndTime = DateTime.UtcNow.AddMinutes(15),
                        Frequency = RecurrenceFrequency.Minute,
                        Interval = 4,
                        Schedule = null
                    },
                    Pipelines = new List<TriggerPipelineReference>()
                }
            };

            TriggerPipelineReference triggerPipelineReference = new TriggerPipelineReference()
            {
                PipelineReference = new PipelineReference(pipelineName),
                Parameters = new Dictionary<string, object>()
            };

            string[] outputBlobNameList = new string[1];
            outputBlobNameList[0] = outputBlobName;

            JArray outputBlobNameArray = JArray.FromObject(outputBlobNameList);

            triggerPipelineReference.Parameters.Add("OutputBlobNameList", outputBlobNameArray);

            ((ScheduleTrigger)(resource.Properties)).Pipelines.Add(triggerPipelineReference);

            return resource;
        }

        internal static async Task Create(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string triggerName, TriggerResource expectedTrigger)
        {
            AzureOperationResponse<TriggerResource> createTriggerResponse = await client.Triggers.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, triggerName, expectedTrigger);
            ValidateTrigger(client, resourceGroupName, dataFactoryName, expectedTrigger, createTriggerResponse.Body, triggerName);
            Assert.Equal(HttpStatusCode.OK, createTriggerResponse.Response.StatusCode);
        }

        internal static async Task Update(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string triggerName, TriggerResource expectedTrigger)
        {
            AzureOperationResponse<TriggerResource> updateTriggerResponse = await client.Triggers.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, dataFactoryName, triggerName, expectedTrigger);
            ValidateTrigger(client, resourceGroupName, dataFactoryName, expectedTrigger, updateTriggerResponse.Body, triggerName);
            Assert.Equal(HttpStatusCode.OK, updateTriggerResponse.Response.StatusCode);
        }

        internal static async Task Delete(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string triggerName)
        {
            AzureOperationResponse deleteTriggerResponse = await client.Triggers.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, triggerName);
            Assert.Equal(HttpStatusCode.OK, deleteTriggerResponse.Response.StatusCode);
            deleteTriggerResponse = await client.Triggers.DeleteWithHttpMessagesAsync(resourceGroupName, dataFactoryName, triggerName);
            Assert.Equal(HttpStatusCode.NoContent, deleteTriggerResponse.Response.StatusCode);
        }

        internal static async Task GetList(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, string datasetName, TriggerResource expectedTrigger)
        {
            AzureOperationResponse<TriggerResource> getTriggerResponse = await client.Triggers.GetWithHttpMessagesAsync(resourceGroupName, dataFactoryName, datasetName);
            ValidateTrigger(client, resourceGroupName, dataFactoryName, expectedTrigger, getTriggerResponse.Body, datasetName);
            Assert.Equal(HttpStatusCode.OK, getTriggerResponse.Response.StatusCode);

            AzureOperationResponse<IPage<TriggerResource>> listTriggerResponse = await client.Triggers.ListByFactoryWithHttpMessagesAsync(resourceGroupName, dataFactoryName);
            ValidateTrigger(client, resourceGroupName, dataFactoryName, expectedTrigger, listTriggerResponse.Body.First(), datasetName);
            Assert.Equal(HttpStatusCode.OK, listTriggerResponse.Response.StatusCode);
        }

        private static void ValidateTrigger(DataFactoryManagementClient client, string resourceGroupName, string dataFactoryName, TriggerResource expected, TriggerResource actual, string expectedName)
        {
            ValidateSubResource(client, resourceGroupName, actual, dataFactoryName, expectedName, "triggers");
            Assert.IsType<ScheduleTrigger>(actual.Properties);
            Assert.Equal(((ScheduleTrigger)expected.Properties).Recurrence.Frequency, ((ScheduleTrigger)actual.Properties).Recurrence.Frequency);
            Assert.Equal(((ScheduleTrigger)expected.Properties).Recurrence.Interval, ((ScheduleTrigger)actual.Properties).Recurrence.Interval);
        }
    }
}

