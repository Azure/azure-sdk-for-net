// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("DEID_SERVICE_ENDPOINT");
        public string StorageAccountConnectionString => GetRecordedVariable("STORAGE_ACCOUNT_CONNECTION_STRING", options => options.IsSecret());
    }
}
