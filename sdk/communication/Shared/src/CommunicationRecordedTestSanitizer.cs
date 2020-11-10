// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Azure.Communication.Pipeline
{
    internal class CommunicationRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static readonly Regex s_azureResourceRegEx = new Regex(@"[^/]+?(?=(.communication.azure))", RegexOptions.Compiled);
        private static readonly Regex s_identityInRouteRegEx = new Regex(@"(?<=identities/)([^/]+)", RegexOptions.Compiled);

        /// <summary>
        /// This is a testing/unsigned token required on the sanitized payloads for the playback mode due to format validation on CommunicationUserCredential constructors.
        /// </summary>
        internal const string SanitizedChatAuthHeaderValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public CommunicationRecordedTestSanitizer() : base()
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
                if (headers.ContainsKey(HttpHeader.Names.UserAgent) && headers[HttpHeader.Names.UserAgent].Any(x => x.Contains("Communication.Chat")))
                {
                    headers[HttpHeader.Names.Authorization] = new[] { SanitizedChatAuthHeaderValue };
                    return;
                }
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
                CommunicationEnvironmentVariableNames.ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                CommunicationEnvironmentVariableNames.FromPhoneNumberEnvironmentVariableName => "+18005551234",
                CommunicationEnvironmentVariableNames.ToPhoneNumberEnvironmentVariableName => "+18005555555",
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