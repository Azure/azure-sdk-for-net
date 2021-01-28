// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Communication.Pipeline
{
    public class CommunicationRecordedTestSanitizer : RecordedTestSanitizer
    {
        private static readonly Regex _azureResourceRegEx = new Regex(@"[^/]+?(?=(.communication.azure))", RegexOptions.Compiled);
        private static readonly Regex _identityInRouteRegEx = new Regex(@"(?<=identities/)([^/]+)", RegexOptions.Compiled);
        private static readonly Regex _phoneNumberRegEx = new Regex(@"[\\+]?[0-9]{11,15}", RegexOptions.Compiled);
        private static readonly Regex _guidRegEx = new Regex(@"(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}", RegexOptions.Compiled);

        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";

        public CommunicationRecordedTestSanitizer() : base()
        {
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..id");
            JsonPathSanitizers.Add("$..phonePlanId");
            JsonPathSanitizers.Add("$..phonePlanGroupId");
            JsonPathSanitizers.Add("$..phonePlanIds[:]");
            JsonPathSanitizers.Add("$..COMMUNICATION_ENDPOINT_STRING");
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

        public override string SanitizeTextBody(string contentType, string body)
        {
            body = base.SanitizeTextBody(contentType, body);
            body = _phoneNumberRegEx.Replace(body, SanitizeValue);

            return body;
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
            => variableName switch
            {
                ConnectionStringEnvironmentVariableName => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeAzureResource(string uri) => _azureResourceRegEx.Replace(uri, SanitizeValue.ToLower());

        internal static string SanitizeConnectionString(string connectionString)
        {
            const string accessKey = "accesskey";
            const string endpoint = "endpoint";

            var parsed = ConnectionString.Parse(connectionString, allowEmptyValues: true);
            parsed.Replace(accessKey, "Kg==;");

            parsed.Replace(endpoint, SanitizeAzureResource(parsed.GetRequired(endpoint)));

            return parsed.ToString();
        }

        public override string SanitizeUri(string uri)
        {
            uri = SanitizeAzureResource(_identityInRouteRegEx.Replace(uri, SanitizeValue.ToLower()));
            return _guidRegEx.Replace(uri, SanitizeValue);
        }
    }
}
