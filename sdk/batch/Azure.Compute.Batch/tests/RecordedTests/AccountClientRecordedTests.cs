// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Compute.Batch;
using Azure.Compute.Batch.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Tests.SessionTests
{
    internal class AccountClientRecordedTests : BatchRecordedTestBase
    {
        public AccountClientRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async System.Threading.Tasks.Task GetSupportedImages()
        {
            BatchServiceClient client = CreateClient();
            AccountClient accountClient = client.CreateAccountClient();

            AccountListSupportedImagesOptions options = new AccountListSupportedImagesOptions();
            IEnumerable<ImageInformation> images = await accountClient.GetSupportedImagesAsync(options).ToEnumerableAsync().ConfigureAwait(false);

            Assert.IsNotEmpty(images);
        }
    }
}
