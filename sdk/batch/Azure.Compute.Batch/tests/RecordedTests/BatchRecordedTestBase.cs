// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using Azure.Compute.Batch;
using Azure.Compute.Batch.Models;
using Azure.Compute.Batch.Tests;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Tests.SessionTests
{
    public class BatchRecordedTestBase : RecordedTestBase<BatchClientTestEnvironment>
    {
        protected string idBase;
        private string guid;

        public BatchRecordedTestBase(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            guid = Guid.NewGuid().ToString();
        }

        protected virtual string GetIdBase()
        {
            return GetType().Name;
        }

        protected string GetId(string name, int maxLength = 64)
        {
            StringBuilder stringBuilder = new StringBuilder(GetIdBase());
            if (IsAsync)
            {
                stringBuilder.Append("Async");
            }
            stringBuilder.Append($"_{name}_{guid}");
            return stringBuilder.ToString().Substring(0, 64);
        }

        protected BatchServiceClient CreateServiceClient()
        {
            HttpClientHandler httpHandler = new();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };

            BatchClientOptions options = new BatchClientOptions(BatchClientOptions.ServiceVersion.V2022_01_01_15_0);
            options.Transport = new HttpClientTransport(httpHandler);
            Uri endpointUri = new Uri(TestEnvironment.Endpoint);
            BatchServiceClient batchClient = InstrumentClient(new BatchServiceClient(endpointUri, TestEnvironment.Credential, InstrumentClientOptions(options)));
            foreach (PropertyInfo property in batchClient.GetType().GetProperties())
            {
                if (property.GetType() == typeof(SubClient))
                {
                    SubClient baseClient = property.GetValue(typeof(SubClient)) as SubClient;
                    baseClient.ContentHandler = GetContentFromResponse;
                }
            }

            return batchClient;
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task TestOperation()
        {
            string testJobId = GetId("Job");
            BatchServiceClient client = CreateServiceClient();
            JobClient jobClient = client.CreateJobClient();
            try
            {
                await jobClient.AddAsync(new Job { Id = testJobId, PoolInfo = new PoolInformation { PoolId = "managerPool" } });
                Job job = await jobClient.GetAsync(testJobId);
                Assert.AreEqual(job.Id, testJobId);
            }
            finally
            {
                await jobClient.DeleteAsync(testJobId);
            }

            return;
        }

        // Add live tests here. If you need more information please refer https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#live-testing and
        // here are some examples: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.AccessControl/tests/AccessControlClientLiveTests.cs.

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
