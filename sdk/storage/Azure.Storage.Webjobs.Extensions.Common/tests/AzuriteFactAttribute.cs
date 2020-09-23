// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    // TODO (kasobol-msft) find better way.
    public class AzuriteFactAttribute : FactAttribute
    {
        public AzuriteFactAttribute()
        {
            string azuriteLocation = Environment.GetEnvironmentVariable("AzureWebJobsStorageAzuriteLocation");
            if (string.IsNullOrWhiteSpace(azuriteLocation))
            {
                Skip = "This test requires Azurite installed and it's location available through AzureWebJobsStorageAzuriteLocation variable";
            }
        }
    }
}
