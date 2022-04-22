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
        private const string CopySourceAuthorization = "x-ms-copy-source-authorization";
        private const string PreviousSnapshotUrl = "x-ms-previous-snapshot-url";
        private const string FileRenameSource = "x-ms-file-rename-source";

        public StorageRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("x-ms-encryption-key");
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
            return builder.Uri.AbsoluteUri;
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

            // Remote copy source authorization header
            if (headers.ContainsKey(CopySourceAuthorization))
            {
                headers[CopySourceAuthorization] = new string[] { SanitizeValue };
            }

            // Santize any copy source
            if (headers.TryGetValue(CopySourceName, out var copySource))
            {
                headers[CopySourceName] = copySource.Select(c => SanitizeUri(c)).ToArray();
            }

            if (headers.TryGetValue(RenameSource, out var renameSource))
            {
                headers[RenameSource] = renameSource.Select(c => SanitizeQueryParameters(c)).ToArray();
            }

            if (headers.TryGetValue(PreviousSnapshotUrl, out var snapshotUri))
            {
                headers[PreviousSnapshotUrl] = snapshotUri.Select(c => SanitizeUri(c)).ToArray();
            }

            if (headers.TryGetValue(FileRenameSource, out var fileRenameSource))
            {
                headers[FileRenameSource] = fileRenameSource.Select(c => SanitizeQueryParameters(c)).ToArray();
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
