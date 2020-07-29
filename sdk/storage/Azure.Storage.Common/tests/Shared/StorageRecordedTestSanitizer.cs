// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Storage.Test.Shared
{
    public class StorageRecordedTestSanitizer : RecordedTestSanitizer
    {
        private const string SignatureQueryName = "sig";
        private const string CopySourceName = "x-ms-copy-source";
        private const string RenameSource = "x-ms-rename-source";

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

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            // Remove the Auth header
            base.SanitizeHeaders(headers);

            // Santize any copy source
            if (headers.TryGetValue(CopySourceName, out var copySource))
            {
                headers[CopySourceName] = copySource.Select(c => SanitizeUri(c)).ToArray();
            }

            if (headers.TryGetValue(RenameSource, out var renameSource))
            {
                headers[RenameSource] = renameSource.Select(c => SanitizeQueryParameters(c)).ToArray();
            }
        }

        public override string SanitizeTextBody(string contentType, string body)
        {
            if (contentType.Contains("urlencoded"))
            {
                try
                {
                    // If it's been URL encoded, make sure it doesn't contain
                    // a client_secret
                    var builder = new UriBuilder() { Query = body };
                    var query = new UriQueryParamsCollection(body);
                    if (query.ContainsKey("client_secret"))
                    {
                        query["client_secret"] = SanitizeValue;
                    }
                    return query.ToString();
                }
                catch
                {
                }
            }

            // If anything goes wrong, don't sanitize
            return body;
        }

        public override string SanitizeVariable(string variableName, string environmentVariableValue) =>
            variableName switch
            {
                "Storage_TestConfigDefault" => SanitizeConnectionString(environmentVariableValue),
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };

        private static string SanitizeConnectionString(string connectionString)
        {
            connectionString = connectionString.Replace("AccountKey=Sanitized", "AccountKey=Kg==;");
            return connectionString;
        }
    }
}
