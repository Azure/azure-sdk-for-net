// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Chat.Tests
{
    public class ChatRecordedTestSanitizer : RecordedTestSanitizer
    {
        public const string SanitizedUnsignedUserTokenValue = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

        public ChatRecordedTestSanitizer() : base()
        {
            JsonPathSanitizers.Add("$..token");
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(HttpHeader.Names.Authorization))
            {
                if (headers.ContainsKey(HttpHeader.Names.UserAgent) && headers[HttpHeader.Names.UserAgent].Any(x => x.Contains("Communication.Chat")))
                {
                    headers[HttpHeader.Names.Authorization] = new[] { SanitizedUnsignedUserTokenValue };
                    return;
                }
                headers[HttpHeader.Names.Authorization] = new[] { SanitizeValue };
            }
        }
        public override string SanitizeVariable(string variableName, string environmentVariableValue)
            => variableName switch
            {
                ChatTestEnvironment.ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeConnectionString(string connectionString)
        {
            const string accessKey = "accesskey";

            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);
            parsed.Replace(accessKey, "Kg==;");

            return parsed.ToString();
        }
    }
}
