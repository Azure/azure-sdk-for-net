// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework.Models;

namespace Azure.Communication.Pipeline
{
    public class PhoneNumbersClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        private const string PhoneNumberRegEx = @"[\\+]?[0-9]{11,15}";
        private const string UrlEncodedPhoneNumberRegEx = @"[\\%2B]{0,3}[0-9]{11,15}";

        public PhoneNumbersClientRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("location");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(PhoneNumberRegEx, SanitizeValue));
            UriRegexSanitizers.Add(new UriRegexSanitizer(UrlEncodedPhoneNumberRegEx, SanitizeValue));
        }
    }
}
