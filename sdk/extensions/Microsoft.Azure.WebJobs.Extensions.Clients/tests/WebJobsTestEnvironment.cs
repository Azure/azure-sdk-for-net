// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Extensions.Azure.WebJobs.Tests
{
    public class WebJobsTestEnvironment : TestEnvironment
    {
        public string KeyVaultUrl => GetRecordedVariable("AZURE_KEYVAULT_URL");
    }
}