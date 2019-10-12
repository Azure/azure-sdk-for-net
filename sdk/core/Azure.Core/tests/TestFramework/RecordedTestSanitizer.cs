// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Testing
{
    public class RecordedTestSanitizer
    {
        protected const string SanitizeValue = "Sanitized";
        private static readonly string[] s_sanitizeValueArray = { SanitizeValue };

        private static readonly string[] s_sanitizedHeaders = { "Authorization" };

        public virtual string SanitizeUri(string uri)
        {
            return uri;
        }

        public virtual void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            foreach (var header in s_sanitizedHeaders)
            {
                if (headers.ContainsKey(header))
                {
                    headers[header] = s_sanitizeValueArray;
                }
            }
        }

        public virtual string SanitizeTextBody(string contentType, string body)
        {
            return body;
        }

        public virtual byte[] SanitizeBody(string contentType, byte[] body)
        {
            return body;
        }

        public virtual void SanitizeConnectionString(ConnectionString connectionString)
        {
        }
    }
}
