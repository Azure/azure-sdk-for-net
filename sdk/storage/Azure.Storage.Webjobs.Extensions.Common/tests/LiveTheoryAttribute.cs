// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    // TODO (kasobol-msft) find better way.
    public class LiveTheoryAttribute : TheoryAttribute
    {
        public LiveTheoryAttribute()
        {
            string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Skip = "This test requires connection string to real storage account defined in AzureWebJobsStorage variable";
            }
        }
    }
}
