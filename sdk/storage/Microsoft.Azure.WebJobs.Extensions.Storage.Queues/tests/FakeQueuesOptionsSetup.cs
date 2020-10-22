﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests.TestDoubles
{
    internal class FakeQueuesOptionsSetup : IConfigureOptions<QueuesOptions>
    {
        public void Configure(QueuesOptions options)
        {
            options.BatchSize = 2;
            options.MaxPollingInterval = TimeSpan.FromSeconds(10);
            options.MaxDequeueCount = 3;
            options.VisibilityTimeout = TimeSpan.Zero;
        }
    }
}
