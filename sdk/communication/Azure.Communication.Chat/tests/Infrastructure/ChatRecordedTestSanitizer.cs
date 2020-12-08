// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Chat.Tests
{
    public class ChatRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static Regex azureResourceRegEx = new Regex(@"[a-zA-Z0-9]*-communication", RegexOptions.Compiled);
        /// <summary>
        /// This is a testing/unsigned token required on the sanitized payloads for the playback mode due to format validation on CommunicationUserCredential constructors.
        /// </summary>
        public const string SanitizedChatAuthHeaderValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public ChatRecordedTestSanitizer(): base()
        {
            JsonPathSanitizers.Add("$..token");
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(HttpHeader.Names.Authorization))
            {
                if (headers.ContainsKey(HttpHeader.Names.UserAgent) && headers[HttpHeader.Names.UserAgent].Any(x=>x.Contains("Communication.Chat")))
                {
                    headers[HttpHeader.Names.Authorization] = new[] { SanitizedChatAuthHeaderValue };
                    return;
                }
                headers[HttpHeader.Names.Authorization] = new[] { SanitizeValue };
            }
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                ChatTestEnvironment.ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        private static string SanitizeAzureResource(string uri) => azureResourceRegEx.Replace(uri, $"{SanitizeValue}").ToLower();

        private static string SanitizeConnectionString(string connectionString)
        {
            const string accessKey = "accesskey";
            const string endpoint = "endpoint";

            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);
            parsed.Replace(accessKey, "Kg==;");

            parsed.Replace(endpoint, SanitizeAzureResource(parsed.GetRequired(endpoint)));

            return parsed.ToString();
        }

        public override string SanitizeUri(string uri) => SanitizeAzureResource(uri);
    }
}
