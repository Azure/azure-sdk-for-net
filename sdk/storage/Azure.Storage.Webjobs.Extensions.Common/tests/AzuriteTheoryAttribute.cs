// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Xunit;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    // TODO (kasobol-msft) find better way.
    public class AzuriteTheoryAttribute : TheoryAttribute
    {
        public AzuriteTheoryAttribute()
        {
            string azuriteLocation = Environment.GetEnvironmentVariable("AZURE_AZURITE_LOCATION");
            if (string.IsNullOrWhiteSpace(azuriteLocation))
            {
                Skip = "This test requires Azurite installed and it's location available through AZURE_AZURITE_LOCATION variable";
            }
        }
    }
}
