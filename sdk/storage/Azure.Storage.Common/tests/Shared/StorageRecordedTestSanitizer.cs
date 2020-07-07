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
            if (contentType.Contains("json"))
            {
                try
                {
                    // Check for auth calls to readact any access tokens
                    var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(body).AsSpan(), true, new JsonReaderState());
                    if (JsonDocument.TryParseValue(ref reader, out JsonDocument doc) &&
                        doc.RootElement.GetProperty("token_type").GetString() == "Bearer")
                    {
                        // If we found an auth call, sanitize it
                        using (var stream = new System.IO.MemoryStream())
                        {
                            using (var writer = new Utf8JsonWriter(stream))
                            {
                                writer.WriteStartObject();
                                foreach (JsonProperty property in doc.RootElement.EnumerateObject())
                                {
                                    switch (doc.RootElement.GetProperty(property.Name).ValueKind)
                                    {
                                        case JsonValueKind.Null:
                                            writer.WriteNull(property.Name);
                                            break;
                                        case JsonValueKind.True:
                                            writer.WriteBoolean(property.Name, true);
                                            break;
                                        case JsonValueKind.False:
                                            writer.WriteBoolean(property.Name, false);
                                            break;
                                        case JsonValueKind.Number:
                                            writer.WriteNumber(property.Name, property.Value.GetDouble());
                                            break;
                                        case JsonValueKind.String:
                                            writer.WriteString(
                                                property.Name,
                                                property.Name == "access_token" ?
                                                    SanitizeValue :
                                                    property.Value.GetString());
                                            break;
                                            // Ignore nested objects and arrays...
                                    }
                                }
                                writer.WriteEndObject();
                            }
                            return Encoding.UTF8.GetString(stream.ToArray());
                        }
                    }
                }
                catch
                {
                }
            }
            else if (contentType.Contains("urlencoded"))
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
