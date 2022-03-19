// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridLiveTestBase : RecordedTestBase<EventGridTestEnvironment>
    {
        public EventGridLiveTestBase(bool isAsync) : base(isAsync/*, RecordedTestMode.Record*/)
        {
            SanitizedHeaders.Add(Constants.SasKeyName);
            SanitizedHeaders.Add(Constants.SasTokenName);
            JsonPathSanitizers.Add("$..traceparent");
        }
    }
}
