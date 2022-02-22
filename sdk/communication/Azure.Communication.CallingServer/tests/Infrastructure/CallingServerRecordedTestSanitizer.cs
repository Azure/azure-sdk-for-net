// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.CallingServer.Tests
{
    public class CallingServerRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        private const string PhoneNumberRegEx = @"\\u002B[0-9]{11,15}";

        public CallingServerRecordedTestSanitizer()
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(PhoneNumberRegEx, SanitizeValue));
        }
    }
}
