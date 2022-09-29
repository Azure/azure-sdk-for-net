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

        protected BatchServiceClient CreateInstrumentedClient(MockResponse response) => CreateInstrumentedClient(new MockTransport(response));

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
            BatchServiceClient client = CreateInstrumentedClient(mockResponse);
            JobClient jobClient = client.CreateJobClient();
            Response response = await jobClient.AddAsync(new Job { Id = "mockid", PoolInfo = new PoolInformation { PoolId = "mockpool" } });

            Assert.AreEqual(response.Status, 201);
            return;
        }
    }
}
