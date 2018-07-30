// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace DataFactory.Tests.UnitTests
{
    /// <summary>
    /// Tests corresponding to all swagger-style operation examples, which include all implemented operations.
    /// These tests contain workarounds for some service defects/inconsistencies, as noted by specific Issue comments
    /// </summary>
    public class ExamplesUnitTest : BaseUnitTest
    {
        //[Theory]
        //[InlineData(@"secrets.json", @"exampleoutput", @"exampleoutputworkarounds")]
        public void CaptureExamples(string secretsFile, string outputDirectory, string outputDirectoryWorkarounds = null)
        {
            // Uncomment the [Theory] and [InlineData(...)] above and run this method with your favorite locations for secrets and outputs to recapture examples.  It takes about 20-30 minutes.
            ExampleCapture exampleCapture = new ExampleCapture(secretsFile, outputDirectory, outputDirectoryWorkarounds);
            exampleCapture.CaptureAllExamples();
        }

        [Fact]
        public void Factories_CreateOrUpdate()
        {
            RunTest("Factories_CreateOrUpdate", (example, client, responseCode) =>
            {
                Factory resource = client.Factories.CreateOrUpdate(RGN(example), FN(example), FR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Factories_Update()
        {
            RunTest("Factories_Update", (example, client, responseCode) =>
            {
                Factory resource = client.Factories.Update(RGN(example), FN(example), GetTypedParameter<FactoryUpdateParameters>(example, client, "factoryUpdateParameters"));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Factories_ConfigureFactoryRepo()
        {
            RunTest("Factories_ConfigureFactoryRepo", (example, client, responseCode) =>
            {
                Factory resource = client.Factories.ConfigureFactoryRepo(LN(example), GetTypedParameter<FactoryRepoUpdate>(example, client, "factoryRepoUpdate"));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Factories_List()
        {
            RunTest("Factories_List", (example, client, responseCode) =>
            {
                IPage<Factory> resources = client.Factories.List();
                CheckResponseBody(example, client, responseCode, (Page<Factory>)resources);
            });
        }

        [Fact]
        public void Factories_ListByResourceGroup()
        {
            RunTest("Factories_ListByResourceGroup", (example, client, responseCode) =>
            {
                IPage<Factory> resources = client.Factories.ListByResourceGroup(RGN(example));
                CheckResponseBody(example, client, responseCode, (Page<Factory>)resources);
            });
        }

        [Fact]
        public void Factories_Get()
        {
            RunTest("Factories_Get", (example, client, responseCode) =>
            {
                Factory resource = client.Factories.Get(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Factories_Delete()
        {
            RunTest("Factories_Delete", (example, client, responseCode) =>
            {
                client.Factories.Delete(RGN(example), FN(example));
            });
        }

        [Fact]
        public void IntegrationRuntimes_Create()
        {
            RunTest("IntegrationRuntimes_Create", (example, client, responseCode) =>
            {
                IntegrationRuntimeResource resource = client.IntegrationRuntimes.CreateOrUpdate(RGN(example), FN(example), IRN(example), IRR(example, client, "integrationRuntime"));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void IntegrationRuntimes_Update()
        {
            RunTest("IntegrationRuntimes_Update", (example, client, responseCode) =>
            {
                IntegrationRuntimeResource response = client.IntegrationRuntimes.Update(RGN(example), FN(example), IRN(example),
                    new UpdateIntegrationRuntimeRequest
                    {
                        AutoUpdate = IntegrationRuntimeAutoUpdate.Off,
                        UpdateDelayOffset = SafeJsonConvert.SerializeObject(TimeSpan.FromHours(3), client.SerializationSettings)
                    });
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void IntegrationRuntimes_Get()
        {
            RunTest("IntegrationRuntimes_Get", (example, client, responseCode) =>
            {
                IntegrationRuntimeResource resource = client.IntegrationRuntimes.Get(RGN(example), FN(example), IRN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void IntegrationRuntimes_ListByFactory()
        {
            RunTest("IntegrationRuntimes_ListByFactory", (example, client, responseCode) =>
            {
                IPage<IntegrationRuntimeResource> resources = client.IntegrationRuntimes.ListByFactory(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, (Page<IntegrationRuntimeResource>)resources);
            });
        }

        [Fact]
        public void IntegrationRuntimes_Delete()
        {
            RunTest("IntegrationRuntimes_Delete", (example, client, responseCode) =>
            {
                client.IntegrationRuntimes.Delete(RGN(example), FN(example), IRN(example));
            });
        }

        [Fact]
        public void IntegrationRuntimes_GetStatus()
        {
            RunTest("IntegrationRuntimes_GetStatus", (example, client, responseCode) =>
            {
                IntegrationRuntimeStatusResponse resource = client.IntegrationRuntimes.GetStatus(RGN(example), FN(example), IRN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void IntegrationRuntimes_GetConnectionInfo()
        {
            RunTest("IntegrationRuntimes_GetConnectionInfo", (example, client, responseCode) =>
            {
                IntegrationRuntimeConnectionInfo response = client.IntegrationRuntimes.GetConnectionInfo(RGN(example), FN(example), IRN(example));
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void IntegrationRuntimes_GetMonitoringData()
        {
            RunTest("IntegrationRuntimes_GetMonitoringData", (example, client, responseCode) =>
            {
                IntegrationRuntimeMonitoringData response = client.IntegrationRuntimes.GetMonitoringData(RGN(example), FN(example), IRN(example));
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void IntegrationRuntimes_RegenerateAuthKey()
        {
            RunTest("IntegrationRuntimes_RegenerateAuthKey", (example, client, responseCode) =>
            {
                IntegrationRuntimeAuthKeys response = client.IntegrationRuntimes.RegenerateAuthKey(RGN(example), FN(example), IRN(example), GetTypedParameter<IntegrationRuntimeRegenerateKeyParameters>(example, client, "regenerateKeyParameters"));
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void IntegrationRuntimes_ListAuthKeys()
        {
            RunTest("IntegrationRuntimes_ListAuthKeys", (example, client, responseCode) =>
            {
                IntegrationRuntimeAuthKeys response = client.IntegrationRuntimes.ListAuthKeys(RGN(example), FN(example), IRN(example));
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void IntegrationRuntimes_Start()
        {
            RunAyncApiTest("IntegrationRuntimes_Start", (example, client, responseCode) =>
            {
                client.LongRunningOperationRetryTimeout = 0;
                client.IntegrationRuntimes.Start(RGN(example), FN(example), IRN(example));
            });
        }

        [Fact(Skip = "ReRecord due to CR change")]
        public void IntegrationRuntimes_Stop()
        {
            RunAyncApiTest("IntegrationRuntimes_Stop", (example, client, responseCode) =>
            {
                client.LongRunningOperationRetryTimeout = 0;
                client.IntegrationRuntimes.Stop(RGN(example), FN(example), IRN(example));
            });
        }

        [Fact]
        public void IntegrationRuntimes_Upgrade()
        {
            RunAyncApiTest("IntegrationRuntimes_Upgrade", (example, client, responseCode) =>
            {
                client.IntegrationRuntimes.Upgrade(RGN(example), FN(example), IRN(example));
            });
        }

        [Fact]
        public void IntegrationRuntimes_SyncCredentials()
        {
            RunAyncApiTest("IntegrationRuntimes_SyncCredentials", (example, client, responseCode) =>
            {
                client.IntegrationRuntimes.SyncCredentials(RGN(example), FN(example), IRN(example));
            });
        }

        [Fact]
        public void IntegrationRuntimeNodes_Update()
        {
            RunAyncApiTest("IntegrationRuntimeNodes_Update", (example, client, responseCode) =>
            {
                client.IntegrationRuntimeNodes.Update(RGN(example), FN(example), IRN(example), "Node_1",
                new UpdateIntegrationRuntimeNodeRequest
                {
                    ConcurrentJobsLimit = 2
                });
            });
        }

        [Fact]
        public void IntegrationRuntimeNodes_Delete()
        {
            RunAyncApiTest("IntegrationRuntimeNodes_Delete", (example, client, responseCode) =>
            {
                client.IntegrationRuntimeNodes.Delete(RGN(example), FN(example), IRN(example), "Node_1");
            });
        }

        [Fact]
        public void IntegrationRuntimeNodes_GetIpAddress()
        {
            RunAyncApiTest("IntegrationRuntimeNodes_GetIpAddress", (example, client, responseCode) =>
            {
                client.IntegrationRuntimeNodes.Delete(RGN(example), FN(example), IRN(example), "Node_1");
            });
        }

        [Fact]
        public void LinkedServices_Create()
        {
            RunTest("LinkedServices_Create", (example, client, responseCode) =>
            {
                LinkedServiceResource resource = client.LinkedServices.CreateOrUpdate(RGN(example), FN(example), LSN(example), LSR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void LinkedServices_Update()
        {
            RunTest("LinkedServices_Update", (example, client, responseCode) =>
            {
                LinkedServiceResource resource = client.LinkedServices.CreateOrUpdate(RGN(example), FN(example), LSN(example), LSR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void LinkedServices_ListByFactory()
        {
            RunTest("LinkedServices_ListByFactory", (example, client, responseCode) =>
            {
                IPage<LinkedServiceResource> resources = client.LinkedServices.ListByFactory(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, (Page<LinkedServiceResource>)resources);
            });
        }

        [Fact]
        public void LinkedServices_Get()
        {
            RunTest("LinkedServices_Get", (example, client, responseCode) =>
            {
                LinkedServiceResource resource = client.LinkedServices.Get(RGN(example), FN(example), LSN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void LinkedServices_Delete()
        {
            RunTest("LinkedServices_Delete", (example, client, responseCode) =>
            {
                client.LinkedServices.Delete(RGN(example), FN(example), LSN(example));
            });
        }
        
        [Fact]
        public void Triggers_Create()
        {
            RunTest("Triggers_Create", (example, client, responseCode) =>
            {
                TriggerResource resource = client.Triggers.CreateOrUpdate(RGN(example), FN(example), TN(example), TR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Triggers_Update()
        {
            RunTest("Triggers_Update", (example, client, responseCode) =>
            {
                TriggerResource resource = client.Triggers.CreateOrUpdate(RGN(example), FN(example), TN(example), TR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Triggers_ListByFactory()
        {
            RunTest("Triggers_ListByFactory", (example, client, responseCode) =>
            {
                IPage<TriggerResource> resources = client.Triggers.ListByFactory(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, (Page<TriggerResource>)resources);
            });
        }

        [Fact]
        public void Triggers_Get()
        {
            RunTest("Triggers_Get", (example, client, responseCode) =>
            {
                TriggerResource resource = client.Triggers.Get(RGN(example), FN(example), TN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Triggers_Start()
        {
            RunTest("Triggers_Start", (example, client, responseCode) =>
            {
                client.Triggers.BeginStart(RGN(example), FN(example), TN(example));
            });
        }

        [Fact]
        public void TriggerRuns_QueryByFactory()
        {
            RunTest("TriggerRuns_QueryByFactory", (example, client, responseCode) =>
            {
                RunFilterParameters filterParams = GetTypedParameter<RunFilterParameters>(example, client, "filterParameters");
                TriggerRunsQueryResponse response = client.TriggerRuns.QueryByFactory(RGN(example), FN(example), filterParams);
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void Triggers_Stop()
        {
            RunTest("Triggers_Stop", (example, client, responseCode) =>
            {
                client.Triggers.BeginStop(RGN(example), FN(example), TN(example));
            });
        }

        [Fact]
        public void Triggers_Delete()
        {
            RunTest("Triggers_Delete", (example, client, responseCode) =>
            {
                client.Triggers.Delete(RGN(example), FN(example), TN(example));
            });
        }

        [Fact]
        public void Datasets_Create()
        {
            RunTest("Datasets_Create", (example, client, responseCode) =>
            {
                DatasetResource resource = client.Datasets.CreateOrUpdate(RGN(example), FN(example), DSN(example), DSR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Datasets_Update()
        {
            RunTest("Datasets_Update", (example, client, responseCode) =>
            {
                DatasetResource resource = client.Datasets.CreateOrUpdate(RGN(example), FN(example), DSN(example), DSR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Datasets_ListByFactory()
        {
            RunTest("Datasets_ListByFactory", (example, client, responseCode) =>
            {
                IPage<DatasetResource> resources = client.Datasets.ListByFactory(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, (Page<DatasetResource>)resources);
            });
        }

        [Fact]
        public void Datasets_Get()
        {
            RunTest("Datasets_Get", (example, client, responseCode) =>
            {
                DatasetResource resource = client.Datasets.Get(RGN(example), FN(example), DSN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Datasets_Delete()
        {
            RunTest("Datasets_Delete", (example, client, responseCode) =>
            {
                client.Datasets.Delete(RGN(example), FN(example), DSN(example));
            });
        }

        [Fact]
        public void Pipelines_Create()
        {
            RunTest("Pipelines_Create", (example, client, responseCode) =>
            {
                PipelineResource resource = client.Pipelines.CreateOrUpdate(RGN(example), FN(example), PN(example), PR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Pipelines_Update()
        {
            RunTest("Pipelines_Update", (example, client, responseCode) =>
            {
                PipelineResource resource = client.Pipelines.CreateOrUpdate(RGN(example), FN(example), PN(example), PR(example, client));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Pipelines_ListByFactory()
        {
            RunTest("Pipelines_ListByFactory", (example, client, responseCode) =>
            {
                IPage<PipelineResource> resources = client.Pipelines.ListByFactory(RGN(example), FN(example));
                CheckResponseBody(example, client, responseCode, (Page<PipelineResource>)resources);
            });
        }

        [Fact]
        public void Pipelines_Get()
        {
            RunTest("Pipelines_Get", (example, client, responseCode) =>
            {
                PipelineResource resource = client.Pipelines.Get(RGN(example), FN(example), PN(example));
                CheckResponseBody(example, client, responseCode, resource);
            });
        }

        [Fact]
        public void Pipelines_Delete()
        {
            RunTest("Pipelines_Delete", (example, client, responseCode) =>
            {
                client.Pipelines.Delete(RGN(example), FN(example), PN(example));
            });
        }

        [Fact]
        public void Pipelines_CreateRun()
        {
            RunTest("Pipelines_CreateRun", (example, client, responseCode) =>
            {
                CreateRunResponse response = client.Pipelines.CreateRun(RGN(example), FN(example), PN(example), parameters: GetTypedParameter<Dictionary<string, object>>(example, client, "parameters"));
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void PipelineRuns_Cancel()
        {
            RunTest("PipelineRuns_Cancel", (example, client, responseCode) =>
            {
                client.PipelineRuns.Cancel(RGN(example), FN(example), new Guid().ToString());
            });
        }

        [Fact]
        public void PipelineRuns_Get()
        {
            RunTest("PipelineRuns_Get", (example, client, responseCode) =>
            {
                PipelineRun response = client.PipelineRuns.Get(RGN(example), FN(example), GetTypedParameter<string>(example, client, "runId"));
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void PipelineRuns_QueryByFactory()
        {
            RunTest("PipelineRuns_QueryByFactory", (example, client, responseCode) =>
            {
                RunFilterParameters filterParams = GetTypedParameter<RunFilterParameters>(example, client, "filterParameters");
                PipelineRunsQueryResponse response = client.PipelineRuns.QueryByFactory(RGN(example), FN(example), filterParams);
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void ActivityRuns_QueryByPipelineRun()
        {
            RunTest("ActivityRuns_QueryByPipelineRun", (example, client, responseCode) =>
            {
                RunFilterParameters filterParams = GetTypedParameter<RunFilterParameters>(example, client, "filterParameters");
                ActivityRunsQueryResponse response = client.ActivityRuns.QueryByPipelineRun(RGN(example), FN(example), GetTypedParameter<string>(example, client, "runId"), filterParams);
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        [Fact]
        public void Operations_List()
        {
            RunTest("Operations_List", (example, client, responseCode) =>
            {
                IPage<Operation> response = client.Operations.List();
                CheckResponseBody(example, client, responseCode, response);
            });
        }

        private List<HttpResponseMessage> GetResponses(Example example)
        {
            List<HttpResponseMessage> messages = new List<HttpResponseMessage>();
            foreach (var kvp in example.Responses)
            {
                HttpResponseMessage message = new HttpResponseMessage((HttpStatusCode)int.Parse(kvp.Key));
                foreach (var header in kvp.Value.Headers)
                {
                    message.Headers.Add(header.Key, header.Value);
                }
                string body = SafeJsonConvert.SerializeObject(kvp.Value.Body);
                message.Content = new StringContent(body);
                messages.Add(message);
            }
            return messages;
        }

        private Example ReadExample(string exampleName)
        {
            var json = File.ReadAllText(Path.Combine("TestData", exampleName + ".json"));
            Example example = SafeJsonConvert.DeserializeObject<Example>(json);
            example.Name = exampleName;
            return example;
        }

        private IDataFactoryManagementClient GetClient(Example example)
        {
            var handler = new RecordedDelegatingHandler
            {
                Responses = GetResponses(example)
            };
            var client = CreateWorkflowClient(handler);
            client.SubscriptionId = (string)example.Parameters["subscriptionId"];
            return client;
        }

        private void RunTest(string exampleName, Action<Example, IDataFactoryManagementClient, int> test)
        {
            Example example = ReadExample(exampleName);
            var client = GetClient(example);
            foreach (var kvp in example.Responses)
            {
                test(example, client, int.Parse(kvp.Key));
            }
        }

        private void RunAyncApiTest(string exampleName, Action<Example, IDataFactoryManagementClient, int> test)
        {
            Example example = ReadExample(exampleName);
            var client = GetClient(example);
            test(example, client, 202);
        }

        private void RemovePropertyIfPresent(JToken jToken, string propertyName, bool onlyIfNull)
        {
            if (jToken.Type == JTokenType.Object)
            {
                JObject jObject = (JObject)jToken;
                JProperty jProperty = jObject.Property(propertyName);
                if (jProperty != null)
                {
                    if (!onlyIfNull || jProperty.Value.Type == JTokenType.Null)
                    {
                        jObject.Remove(propertyName);
                    }
                }
            }
        }

        private void RenamePropertyIfPresent(JToken jToken, string oldPropertyName, string newPropertyName)
        {
            if (jToken.Type == JTokenType.Object)
            {
                JObject jObject = (JObject)jToken;
                JProperty jProperty = jObject.Property(oldPropertyName);
                if (jProperty != null)
                {
                    jObject.Add(newPropertyName, jProperty.Value);
                    jObject.Remove(oldPropertyName);
                }
                else
                {
                    throw new ArgumentException("Property is not found.");
                }
            }
        }

        private void CheckResponseBody<T>(Example example, IDataFactoryManagementClient client, int responseCode, T response)
        {
            // Compares original raw json captured "expected" response against strongly typed "actual" response from SDK method
            // Issues with workarounds noted inline
            Assert.NotNull(response);
            object expectedObject = example.Responses[responseCode.ToString()].Body;
            string expectedJson = SafeJsonConvert.SerializeObject(expectedObject);
            JToken expectedJToken = JToken.Parse(expectedJson);

            string actualJson = SafeJsonConvert.SerializeObject(response, GetFullSerializerSettings(client));
            JToken actualJToken = JToken.Parse(actualJson);


            Assert.True(JToken.DeepEquals(expectedJToken, actualJToken), 
                string.Format(CultureInfo.InvariantCulture, "CheckResponseBody failed for example {0} response code {1}", example.Name, responseCode));
        }

        private string RGN(Example example)
        {
            return (string)example.Parameters["resourceGroupName"];
        }
        private string FN(Example example)
        {
            return (string)example.Parameters["factoryName"];
        }
        private string IRN(Example example)
        {
            return (string)example.Parameters["integrationRuntimeName"];
        }
        private string LSN(Example example)
        {
            return (string)example.Parameters["linkedServiceName"];
        }
        private string TN(Example example)
        {
            return (string)example.Parameters["triggerName"];
        }
        private string DSN(Example example)
        {
            return (string)example.Parameters["datasetName"];
        }
        private string PN(Example example)
        {
            return (string)example.Parameters["pipelineName"];
        }
        private string LN(Example example)
        {
            return (string)example.Parameters["locationId"];
        }

        private T GetTypedObject<T>(IDataFactoryManagementClient client, object objectRaw)
        {
            string jsonRaw = SafeJsonConvert.SerializeObject(objectRaw);
            T objectTyped = SafeJsonConvert.DeserializeObject<T>(jsonRaw, GetFullSerializerSettings(client));
            return objectTyped;
        }
        private T GetTypedParameter<T>(Example example, IDataFactoryManagementClient client, string paramName)
        {
            object objectRaw = example.Parameters[paramName];
            Type parameterType = typeof(T);

            if (parameterType == typeof(DateTime))
            {
                objectRaw = objectRaw.ToString().Replace("%3A", ":");
            }

            return GetTypedObject<T>(client, objectRaw);
        }
        private Factory FR(Example example, IDataFactoryManagementClient client)
        {
            return GetTypedParameter<Factory>(example, client, "factory");
        }

        private IntegrationRuntimeResource IRR(Example example, IDataFactoryManagementClient client, string paramName)
        {
            return GetTypedParameter<IntegrationRuntimeResource>(example, client, paramName);
        }

        private LinkedServiceResource LSR(Example example, IDataFactoryManagementClient client)
        {
            return GetTypedParameter<LinkedServiceResource>(example, client, "linkedService");
        }

        private TriggerResource TR(Example example, IDataFactoryManagementClient client)
        {
            return GetTypedParameter<TriggerResource>(example, client, "trigger");
        }

        private DatasetResource DSR(Example example, IDataFactoryManagementClient client)
        {
            return GetTypedParameter<DatasetResource>(example, client, "dataset");
        }

        private PipelineResource PR(Example example, IDataFactoryManagementClient client)
        {
            return GetTypedParameter<PipelineResource>(example, client, "pipeline");
        }
    }
}
