// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Communication.Pipeline
{
    public class PhoneNumbersClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        private static readonly Regex _phoneNumberRegEx = new Regex(@"[\\+]?[0-9]{11,15}", RegexOptions.Compiled);
        private static readonly Regex _urlEncodedPhoneNumberRegEx = new Regex(@"[\\%2B]{0,3}[0-9]{11,15}", RegexOptions.Compiled);

        public override string SanitizeTextBody(string contentType, string body)
            => base.SanitizeTextBody(contentType, _phoneNumberRegEx.Replace(body, SanitizeValue));

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            base.SanitizeHeaders(headers);

            if (headers.ContainsKey("location"))
            {
                headers["location"] = new[] { _urlEncodedPhoneNumberRegEx.Replace(headers["location"].First(), SanitizeValue) };
            }
        }

        public override string SanitizeUri(string uri)
        {
            uri = base.SanitizeUri(uri);
            return _urlEncodedPhoneNumberRegEx.Replace(uri, SanitizeValue);
        }
    }
}
