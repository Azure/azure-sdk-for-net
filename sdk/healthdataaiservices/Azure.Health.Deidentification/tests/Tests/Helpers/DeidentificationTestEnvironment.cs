// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("DEID_SERVICE_ENDPOINT");
        public string StorageAccountSASUri => GetRecordedVariable("STORAGE_ACCOUNT_SAS_URI", options => options.IsSecret());
    }
}
