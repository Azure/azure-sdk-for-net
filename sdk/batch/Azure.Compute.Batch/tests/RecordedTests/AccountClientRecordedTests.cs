// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [SyncOnly]
        public void GetSupportedImages()
        {
            BatchServiceClient client = CreateClient();
            AccountClient accountClient = client.CreateAccountClient();

            Pageable<ImageInformation> images = accountClient.GetSupportedImages();

            Assert.IsNotEmpty(images);
        }
    }
}
