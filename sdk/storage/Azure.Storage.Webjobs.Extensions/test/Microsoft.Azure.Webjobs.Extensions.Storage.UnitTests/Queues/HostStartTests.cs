// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.FunctionalTests.TestDoubles;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage.Queue;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class HostStartTests
    {
        [Fact]
        public void Queue_IfNameIsInvalid_ThrowsDuringIndexing()
        {
            IHost host = new HostBuilder()
                .ConfigureDefaultTestHost<InvalidQueueNameProgram>(b =>
                {
                    b.AddAzureStorage()
                    .UseFakeStorage();
                })
                .Build();


            var jobHost = host.GetJobHost<InvalidQueueNameProgram>();

            string expectedMessage = String.Format(CultureInfo.InvariantCulture,
    "The dash (-) character may not be the first or last letter - \"-illegalname-\"{0}Parameter " +
    "name: name", Environment.NewLine);

            jobHost.AssertIndexingError(nameof(InvalidQueueNameProgram.Invalid), expectedMessage); 
        }

        private class InvalidQueueNameProgram
        {
            public static void Invalid([Queue("-IllegalName-")] CloudQueue queue)
            {
            }
        }
    }
}
