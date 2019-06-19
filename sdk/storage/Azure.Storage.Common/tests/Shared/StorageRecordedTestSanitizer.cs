// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.Testing;

namespace Azure.Storage.Test.Shared
{
    public class StorageRecordedTestSanitizer : RecordedTestSanitizer
    {
        private const string SignatureQueryName = "sig";
        private const string CopySourceName = "x-ms-copy-source";

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

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            // Remove the Auth header
            base.SanitizeHeaders(headers);

            // Santize any copy source
            if (headers.TryGetValue(CopySourceName, out var copySource))
            {
                headers[CopySourceName] = copySource.Select(c => this.SanitizeUri(c)).ToArray();
            }
        }
    }
}
