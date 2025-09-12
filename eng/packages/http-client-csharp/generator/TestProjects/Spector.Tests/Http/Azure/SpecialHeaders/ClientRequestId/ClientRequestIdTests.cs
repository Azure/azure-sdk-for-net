// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core.Pipeline;
using Azure.SpecialHeaders.XmsClientRequestId;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests.Http.Azure.SpecialHeaders.ClientRequestId
{
    public class ClientRequestIdTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Azure_SpecialHeaders_ClientRequestId_get() => Test(async (host) =>
        {
            // The Spector scenario expects a specific client request ID value
            // We use CreateClientRequestIdScope to set it explicitly for testing
            using (HttpPipeline.CreateClientRequestIdScope("9C4D50EE-2D56-4CD3-8152-34347DC9F2B0"))
            {
                var response = await new XmsClientRequestIdClient(host, new XmsClientRequestIdClientOptions()).GetAsync();
                Assert.AreEqual(204, response.Status);
            }
        });
    }
}