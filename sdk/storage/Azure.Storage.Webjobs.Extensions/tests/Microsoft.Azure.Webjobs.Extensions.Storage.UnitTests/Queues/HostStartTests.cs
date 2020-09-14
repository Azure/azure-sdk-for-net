// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Xunit;
using Microsoft.Azure.WebJobs.Extensions.Storage.UnitTests;
using Azure.Storage.Queues;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class HostStartTests : IClassFixture<AzuriteFixture>
    {
        private readonly AzuriteFixture azuriteFixture;

        public HostStartTests(AzuriteFixture azuriteFixture)
        {
            this.azuriteFixture = azuriteFixture;
        }

        [AzuriteFact]
        public async Task Queue_IfNameIsInvalid_ThrowsDuringIndexing()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<InvalidQueueNameProgram>(b =>
                {
                    b.AddAzureStorage()
                    .UseStorage(StorageAccount.NewFromConnectionString(azuriteFixture.GetAccount().ConnectionString));
                })
                .Build();


            var jobHost = host.GetJobHost<InvalidQueueNameProgram>();

            string expectedMessage = String.Format(CultureInfo.InvariantCulture,
    "The dash (-) character may not be the first or last letter - \"-illegalname-\"{0}Parameter " +
    "name: name", Environment.NewLine);

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
