// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridLiveTestBase : RecordedTestBase<EventGridTestEnvironment>
    {
        public EventGridLiveTestBase(bool isAsync) : base(isAsync /*, RecordedTestMode.Record */)
        {
            Sanitizer = new EventGridRecordedTestSanitizer();
            Sanitizer.SanitizedHeaders.Add(EventGridTestEnvironment.TopicKeyEnvironmentVariableName);
            Sanitizer.SanitizedHeaders.Add(EventGridTestEnvironment.DomainKeyEnvironmentVariableName);
        }
    }
}
