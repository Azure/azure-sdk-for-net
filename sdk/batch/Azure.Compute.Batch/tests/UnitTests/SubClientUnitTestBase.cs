// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch;
using Azure.Compute.Batch.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Tests.UnitTests
{
    public class SubClientUnitTestBase : ClientTestBase
    {
        public SubClientUnitTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected BatchServiceClient CreateServiceClient(MockResponse response) => CreateInstrumentedClient(new MockTransport(response));

        protected BatchServiceClient CreateInstrumentedClient(MockTransport transport)
        {
            Uri fakeEndpoint = new("https://notreal.azure.com");
            FakeTokenCredential fakeTokenCredential = new FakeTokenCredential();
            BatchClientOptions options = new BatchClientOptions() { Transport = transport };

            BatchServiceClient serviceClient = InstrumentClient(new BatchServiceClient(fakeEndpoint, fakeTokenCredential, options));
            return serviceClient;
        }

        [Test]
        public async System.Threading.Tasks.Task SampleMockTest()
        {
            MockResponse mockResponse = new MockResponse(201);
            BatchServiceClient client = CreateServiceClient(mockResponse);
            JobClient jobClient = client.CreateJobClient();
            Response response = await jobClient.AddAsync(new Job { Id = "mockid", PoolInfo = new PoolInformation { PoolId = "mockpool" } });

            Assert.AreEqual(response.Status, 201);
        }

        [Test]
        public async System.Threading.Tasks.Task HandleGetTest()
        {
            string id = "jobId";
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(CreateJobString(id));
            BatchServiceClient client = CreateServiceClient(mockResponse);
            JobClient jobClient = client.CreateJobClient();
            Job job = await jobClient.GetAsync(id);

            Assert.AreEqual(job.PoolInfo.PoolId, "managerPool");
        }

        /*
        [Test]
        public async System.Threading.Tasks.Task HandleListTest()
        {
            string baseId = "jobId";
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(CreateJobStrings(baseId, 5));
            BatchServiceClient client = CreateServiceClient(mockResponse);
            JobClient jobClient = client.CreateJobClient();
        }
        */

        private string CreateJobString(string id)
        {
            string jobString = @"
            {{
              ""id"": ""{0}"",
              ""poolInfo"":{{
                ""poolId"":""managerPool""
              }},
              ""executionInfo"":{{
                ""startTime"":""2022-10-16T17:41:42.725855Z"",
                ""poolId"":""managerPool""
              }},
              ""onAllTasksComplete"":""noaction"",
              ""onTaskFailure"":""noaction""
            }}";
            jobString = string.Format(jobString, id);
            return jobString;
        }

        private string CreateJobStrings(string baseId, int count)
        {
            StringBuilder stringBuilder = new StringBuilder("[");
            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                {
                    stringBuilder.Append(", ");
                }
                string jobString = CreateJobString(baseId + i);
                stringBuilder.Append(jobString);
            }
            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }
    }
}
