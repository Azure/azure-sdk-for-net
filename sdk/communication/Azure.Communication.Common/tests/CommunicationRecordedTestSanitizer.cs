// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Communication.Tests;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Pipeline
{
    public class CommunicationRecordedTestSanitizer : RecordedTestSanitizer
    {
        protected virtual void SanitizeAuthenticationHeader(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey(HttpHeader.Names.Authorization))
                headers[HttpHeader.Names.Authorization] = new[] { SanitizeValue };
        }

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            SanitizeAuthenticationHeader(headers);
            if (headers.ContainsKey("x-ms-content-sha256"))
                headers["x-ms-content-sha256"] = new[] { SanitizeValue };
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
            => variableName switch
            {
                CommunicationTestEnvironment.ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                CommunicationTestEnvironment.LiveTestConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        protected static string SanitizeConnectionString(string connectionString)
        {
            const string accessKey = "accesskey";
            const string someBase64String = "Kg==";

            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);
            parsed.Replace(accessKey, someBase64String);

            return parsed.ToString();
        }
    }
}
