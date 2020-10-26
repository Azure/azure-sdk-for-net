// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.WebJobs.Extensions.Storage.Common.Tests
{
    public class WebJobsTestEnvironment : TestEnvironment
    {
        public WebJobsTestEnvironment()
        : base("storage") { }

        public string PrimaryStorageAccountConnectionString => GetVariable("AZUREWEBJOBSSTORAGE");

        public string SecondaryStorageAccountConnectionString => GetVariable("AZUREWEBJOBSSECONDARYSTORAGE");
    }
}
