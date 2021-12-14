// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.Chat.Tests
{
    public class ChatRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        public const string SanitizedUnsignedUserTokenValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public ChatRecordedTestSanitizer() : base()
            => AddJsonPathSanitizer("$..token");
    }
}
