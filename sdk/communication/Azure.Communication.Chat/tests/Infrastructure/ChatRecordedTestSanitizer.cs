// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Communication.Pipeline;
using Azure.Core;

namespace Azure.Communication.Chat.Tests
{
    public class ChatRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        public const string SanitizedUnsignedUserTokenValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public ChatRecordedTestSanitizer() : base()
            => JsonPathSanitizers.Add("$..token");

        protected override void SanitizeAuthenticationHeader(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(HttpHeader.Names.UserAgent) && headers[HttpHeader.Names.UserAgent].Any(x => x.Contains("Communication.Chat")))
                headers[HttpHeader.Names.Authorization] = new[] { SanitizedUnsignedUserTokenValue };
            else
                base.SanitizeAuthenticationHeader(headers);
        }
    }
}
