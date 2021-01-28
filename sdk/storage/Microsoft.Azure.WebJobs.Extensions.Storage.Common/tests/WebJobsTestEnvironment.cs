// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class WebJobsTestEnvironment : TestEnvironment
    {
        public string PrimaryStorageAccountConnectionString => GetVariable("AZUREWEBJOBSSTORAGE");

        public string SecondaryStorageAccountConnectionString => GetVariable("AZUREWEBJOBSSECONDARYSTORAGE");
    }
}
