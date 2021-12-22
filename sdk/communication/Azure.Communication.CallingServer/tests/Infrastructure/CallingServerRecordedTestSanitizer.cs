// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        private static readonly Regex _phoneNumberRegEx = new Regex(@"\\u002B[0-9]{11,15}", RegexOptions.Compiled);

        public CallingServerRecordedTestSanitizer() : base()
        {
            AddJsonPathSanitizer("$..id");
            AddJsonPathSanitizer("$..callConnectionId");
            AddJsonPathSanitizer("$..rawId");
            AddJsonPathSanitizer("$..groupCallId");
            AddJsonPathSanitizer("$..serverCallId");
            AddJsonPathSanitizer("$..recordingId");
        }

        public override string SanitizeTextBody(string contentType, string body)
            => base.SanitizeTextBody(contentType, _phoneNumberRegEx.Replace(body, SanitizeValue));
    }
}
