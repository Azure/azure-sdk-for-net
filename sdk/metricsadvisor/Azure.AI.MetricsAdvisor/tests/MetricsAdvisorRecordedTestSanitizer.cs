// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorRecordedTestSanitizer : RecordedTestSanitizer
    {
        public MetricsAdvisorRecordedTestSanitizer()
        {
            SanitizedHeaders.Add(Constants.SubscriptionAuthorizationHeader);
            SanitizedHeaders.Add(Constants.ApiAuthorizationHeader);
            JsonPathSanitizers.Add("$..password");
            JsonPathSanitizers.Add("$..certificatePassword");
            JsonPathSanitizers.Add("$..clientSecret");
            JsonPathSanitizers.Add("$..keyVaultClientSecret");
            JsonPathSanitizers.Add("$..apiKey");
            JsonPathSanitizers.Add("$..accountKey");
            JsonPathSanitizers.Add("$..authHeader");
            JsonPathSanitizers.Add("$..httpHeader");
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"\w+@microsoft.com", "foo@contoso.com"));
        }
    }
}
