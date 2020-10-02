// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Sms.Tests
{
    internal class SmsClientRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static readonly Regex s_azureResourceRegEx = new Regex(@"[^/]+?(?=(.communication.azure))", RegexOptions.Compiled);
        private static readonly Regex s_identityInRouteRegEx = new Regex(@"(?<=identities/)([^/]+)", RegexOptions.Compiled);

        public SmsClientRecordedTestSanitizer() : base()
        {
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..from");
            JsonPathSanitizers.Add("$..to");
            JsonPathSanitizers.Add("$..messageId");
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(HttpHeader.Names.Authorization))
            {
                headers[HttpHeader.Names.Authorization] = new[] { SanitizeValue };
            }
            if (headers.ContainsKey("x-ms-content-sha256"))
            {
                headers["x-ms-content-sha256"] = new[] { SanitizeValue };
            }
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                SmsClientTestEnvironment.ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                SmsClientTestEnvironment.FromPhoneNumberEnvironmentVariableName => "+18005551234",
                SmsClientTestEnvironment.ToPhoneNumberEnvironmentVariableName => "+18005555555",
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        private static string SanitizeAzureResource(string uri) => s_azureResourceRegEx.Replace(uri, SanitizeValue).ToLower();

        private static string SanitizeConnectionString(string connectionString)
        {
            const string accessKey = "accesskey";
            const string endpoint = "endpoint";

            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);
            parsed.Replace(accessKey, "Kg==;");

            parsed.Replace(endpoint, SanitizeAzureResource(parsed.GetRequired(endpoint)));

            return parsed.ToString();
        }

        public override string SanitizeUri(string uri)
            => SanitizeAzureResource(s_identityInRouteRegEx.Replace(uri, SanitizeValue).ToLower());
    }
}
