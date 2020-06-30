// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridLiveTestBase : RecordedTestBase<EventGridTestEnvironment>
    {
        // These constants should eventually go in our product code, as they will be needed when creating
        // the AzureKeyCredential.
        public const string SasKeyName = "aeg-sas-key";
        public const string SasTokenName = "aeg-sas-token";

        public EventGridLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new EventGridRecordedTestSanitizer();
            Sanitizer.SanitizedHeaders.Add(SasKeyName);
            Sanitizer.SanitizedHeaders.Add(SasTokenName);
        }
    }
}
