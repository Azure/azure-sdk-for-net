// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGridV2.Tests
{
    public class EventGridV2ClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("EventGridV2_ENDPOINT");

        // Add other client paramters here as above.
    }
}
