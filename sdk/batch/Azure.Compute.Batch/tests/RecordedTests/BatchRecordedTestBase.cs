// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
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
        private string testJobId = "BatchRecordedTestBase_TestJob";

        public BatchRecordedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected BatchServiceClient CreateClient()
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
            BatchServiceClient client = CreateClient();
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
