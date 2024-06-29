// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Deidentification.Tests
{
    public class DeidentificationTestEnvironment : TestEnvironment
    {
        public const string FakeSASUri = "https://localhost/fakecontainer";
        public string Endpoint => GetRecordedVariable("DEID_SERVICE_ENDPOINT");
        public string FakeNextLink => $"{Endpoint}/jobs?api-version=2024-01-16-preview&continuationToken=1234";

        public string StorageAccountSASUri => GetRecordedVariable("STORAGE_ACCOUNT_SAS_URI", options => options.IsSecret(FakeSASUri));
    }
}
