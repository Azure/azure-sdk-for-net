// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.Data.Tables.Tests
{
    public class TablesRecordedTestSanitizer : RecordedTestSanitizer
    {
        private const string SignatureQueryName = "sig";

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                TablesTestEnvironment.PrimaryKeyEnvironmentVariableName => string.Empty,
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }

        public override string SanitizeUri(string uri)
        {
            var builder = new UriBuilder(base.SanitizeUri(uri));
            var query = new UriQueryParamsCollection(builder.Query);
            if (query.ContainsKey(SignatureQueryName))
            {
                query[SignatureQueryName] = SanitizeValue;
                builder.Query = query.ToString();
            }
            return builder.Uri.ToString();
        }

        public string SanitizeQueryParameters(string queryParameters)
        {
            var query = new UriQueryParamsCollection(queryParameters);
            if (query.ContainsKey(SignatureQueryName))
            {
                query[SignatureQueryName] = SanitizeValue;
            }
            return query.ToString();
        }
    }
}
