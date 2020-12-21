// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.MixedReality.Authentication.Tests
{
    public class MixedRealityRecordMatcher : RecordMatcher
    {
        private const string ClientCorrelationVectorHeaderName = "X-MRC-CV";

        public MixedRealityRecordMatcher()
        {
            IgnoredHeaders.Add(ClientCorrelationVectorHeaderName);
            VolatileHeaders.Add(ClientCorrelationVectorHeaderName);
            VolatileResponseHeaders.Add(ClientCorrelationVectorHeaderName);
        }
    }
}
