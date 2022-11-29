// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Xunit;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    public abstract class JobIdFixture : IAsyncLifetime, IReceiveMessages
    {
        private bool _cancelTeardown;

        public string JobId { get; }

        public JobIdFixture()
        {
            JobId = CreateRandomJobId(TestId);
        }

        public void CancelTeardown()
        {
            _cancelTeardown = true;
        }

        public async Task InitializeAsync()
        {
            if (AutoCreateContainer)
            {
                await CreateJobOutputContainerIfNotExistsAsync();
            }
        }

        public async Task DisposeAsync()
        {
            if (!_cancelTeardown)
            {
                await DeleteJobOutputContainerAsync();
            }
        }

        private async Task CreateJobOutputContainerIfNotExistsAsync()
        {
            await StorageConfiguration.GetAccount(null)  // Xunit doesn't provide a convenient way for shared fixtures to log
                                      .GetBlobContainerClient(ContainerNameUtils.GetSafeContainerName(JobId))
                                      .CreateIfNotExistsAsync();
        }

        private async Task DeleteJobOutputContainerAsync()
        {
            await StorageConfiguration.GetAccount(null)  // Xunit doesn't provide a convenient way for shared fixtures to log
                                      .GetBlobContainerClient(ContainerNameUtils.GetSafeContainerName(JobId))
                                      .DeleteIfExistsAsync();
        }

        private static string CreateRandomJobId(string testId)
        {
            // Of the form "mabfc-inttest-joboutput-jan01-010101-1234567890abcdef"

            // Require IDs to be short so they don't push the length over the munging
            // threshold.
            if (testId.Length > 12)
            {
                throw new ArgumentException("testId must be 12 or fewer characters", nameof(testId));
            }

            // Use local time to make it easier to see which is the container for the
            // "current" test run in storage viewers.
            var timestampPart = DateTime.Now.ToString("MMMdd-HHmmss", CultureInfo.InvariantCulture).ToLowerInvariant();

            // Some randomness in case the same test class gets run twice within a
            // second.  We wouldn't expect this to happen very often, so we don't
            // need a lot of randomness, and it's more valuable to keep names below the
            // munging threshold than to reduce the risk of collisions to sub-cosmic-ray levels.
            var randomPart = RandomChars.RandomString(16);

            return $"mabfc-inttest-{testId}-{timestampPart}-{randomPart}";
        }

        public void OnTestCaseFinished(ITestCaseFinished testCaseFinishedMessage)
        {
            // Uses the extended Xunit infrastructure to preserve the test job output container
            // if any tests failed, to allow post-mortem analysis using a storage viewer.
            if (testCaseFinishedMessage.TestsFailed > 0)
            {
                _cancelTeardown = true;
            }
        }

        protected abstract string TestId { get; }

        protected virtual bool AutoCreateContainer { get; } = true;
    }
}
