// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Tests
{
    public class MixedRealityRecordMatcher : RecordMatcher
    {
        private const string ClientCorrelationVectorHeaderName = "X-MRC-CV";

        public MixedRealityRecordMatcher()
            : base(compareBodies: ShouldValidateBodies())
        {
            IgnoredHeaders.Add(ClientCorrelationVectorHeaderName);
        }

        public static bool ShouldValidateBodies()
        {
#if NET461
            return true;
#else
            return false;
#endif
        }
    }
}
