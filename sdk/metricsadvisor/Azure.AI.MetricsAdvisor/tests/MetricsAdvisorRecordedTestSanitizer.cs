// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static Regex emailRegex = new Regex(@"\w+@microsoft.com", RegexOptions.Compiled);
        public MetricsAdvisorRecordedTestSanitizer()
        {
            SanitizedHeaders.Add(Constants.SubscriptionAuthorizationHeader);
            SanitizedHeaders.Add(Constants.ApiAuthorizationHeader);
            AddJsonPathSanitizer("$..password");
            AddJsonPathSanitizer("$..certificatePassword");
            AddJsonPathSanitizer("$..clientSecret");
            AddJsonPathSanitizer("$..keyVaultClientSecret");
            AddJsonPathSanitizer("$..connectionString");
            AddJsonPathSanitizer("$..apiKey");
            AddJsonPathSanitizer("$..accountKey");
            AddJsonPathSanitizer("$..authHeader");
            AddJsonPathSanitizer("$..httpHeader");
            // TODO: Remove when re-recording
            LegacyConvertJsonDateTokens = true;
        }

        public override string SanitizeTextBody(string contentType, string body)
        {
            body = emailRegex.Replace(body, "foo@contoso.com");

            return base.SanitizeTextBody(contentType, body);
        }
    }
}
