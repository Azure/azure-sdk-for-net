// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.Communication.Pipeline
{
    public class PhoneNumbersClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        private static readonly Regex _phoneNumberRegEx = new Regex(@"[\\+]?[0-9]{11,15}", RegexOptions.Compiled);

        public override string SanitizeTextBody(string contentType, string body)
            => base.SanitizeTextBody(contentType, _phoneNumberRegEx.Replace(body, SanitizeValue));
    }
}
