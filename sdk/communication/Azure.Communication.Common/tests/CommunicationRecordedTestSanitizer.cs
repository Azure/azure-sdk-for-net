// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Pipeline
{
    public class CommunicationRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static readonly Regex _azureResourceRegEx = new Regex(@"[^/]+?(?=(.communication.azure))", RegexOptions.Compiled);

        public const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";

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
                ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeAzureResource(string uri) => _azureResourceRegEx.Replace(uri, SanitizeValue.ToLower());

        private static string SanitizeConnectionString(string connectionString)
        {
            const string accessKey = "accesskey";
            const string endpoint = "endpoint";
            const string someBase64String = "Kg==";

            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);
            parsed.Replace(accessKey, someBase64String);
            parsed.Replace(endpoint, SanitizeAzureResource(parsed.GetRequired(endpoint)));

            return parsed.ToString();
        }

        public override string SanitizeUri(string uri)
            => base.SanitizeUri(SanitizeAzureResource(uri));
    }
}
