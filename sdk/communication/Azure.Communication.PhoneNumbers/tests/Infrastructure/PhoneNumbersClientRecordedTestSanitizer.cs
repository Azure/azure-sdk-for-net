// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.Communication.Pipeline
{
    public class PhoneNumbersClientRecordedTestSanitizer : CommunicationRecordedTestSanitizer
    {
        private static readonly Regex _phoneNumberRegEx = new Regex(@"[\\+]?[0-9]{11,15}", RegexOptions.Compiled);
        private static readonly Regex _guidRegEx = new Regex(@"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}", RegexOptions.Compiled);

        public PhoneNumbersClientRecordedTestSanitizer()
        {
            JsonPathSanitizers.Add("$..phonePlanId");
            JsonPathSanitizers.Add("$..phonePlanGroupId");
            JsonPathSanitizers.Add("$..phonePlanIds[:]");
        }

        public override string SanitizeTextBody(string contentType, string body)
            => base.SanitizeTextBody(contentType, _phoneNumberRegEx.Replace(body, SanitizeValue));

        public override string SanitizeUri(string uri)
            => base.SanitizeUri(_guidRegEx.Replace(uri, SanitizeValue));
    }
}
