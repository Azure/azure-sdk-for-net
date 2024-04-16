// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Compute.Batch.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.Integration
{
    internal class BatchApplicationsIntegrationTests : BatchLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BatchApplicationsIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchApplicationsIntegrationTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchApplicationsIntegrationTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BatchApplicationsIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetandListApplication()
        {
            var client = CreateBatchClient();

            // list out all applications
            string appID = null;
            await foreach (BatchApplication item in client.GetApplicationsAsync())
            {
                appID = item.Id;
            }
            Assert.NotNull(appID);

            // verify we can get an application
            var application = await client.GetApplicationAsync(appID);
            Assert.AreEqual(appID, application.Value.Id);
        }
    }
}
