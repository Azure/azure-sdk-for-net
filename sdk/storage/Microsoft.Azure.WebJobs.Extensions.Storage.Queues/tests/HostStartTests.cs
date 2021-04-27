// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class HostStartTests
    {
        private readonly QueueServiceClient queueServiceClient;

        public HostStartTests()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
        }

        [Test]
        public async Task Queue_IfNameIsInvalid_ThrowsDuringIndexing()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<InvalidQueueNameProgram>(b =>
                {
                    b.AddAzureStorageQueues()
                    .UseQueueService(queueServiceClient);
                })
                .Build();

            var jobHost = host.GetJobHost<InvalidQueueNameProgram>();

            string expectedMessage = "The dash (-) character may not be the first or last letter - \"-illegalname-\"";

            await jobHost.AssertIndexingError(nameof(InvalidQueueNameProgram.Invalid), expectedMessage);
        }

        private class InvalidQueueNameProgram
        {
            public static void Invalid([Queue("-IllegalName-")] QueueClient queue)
            {
            }
        }
    }
}
