// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Pipeline
{
    public class CommunicationRelayClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        public CommunicationRelayClientRecordedTestSanitizer()
            => AddJsonPathSanitizer("$..credential");
    }
}
