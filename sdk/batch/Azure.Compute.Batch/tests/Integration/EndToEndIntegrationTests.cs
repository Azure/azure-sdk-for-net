// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class EndToEndIntegrationTests : BatchLiveTestBase
    {
        public EndToEndIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        public EndToEndIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        [Ignore("Work in progress")]
        [RecordedTest]
        public async Task HelloWorld()
        {
            var jobId = "HelloWorldJob-" + TestUtilities.GetMyName() + "-" + TestUtilities.GetTimeStamp();

            var client = CreateBatchClient();

            PaasWindowsPoolFixture paasWindowsPoolFixture = new PaasWindowsPoolFixture(client, isPlayBack());
            BatchPool pool  = await paasWindowsPoolFixture.CreatePoolAsync();
        }
    }
}
