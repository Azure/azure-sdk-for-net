// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Testing
{
    public class RecordedTestSanitizer
    {
        private const string SanitizeValue = "Sanitized";
        private static readonly string[] SanitizeValueArray = new [] { SanitizeValue };

        public virtual string SanitizeUri(string uri)
        {
            return uri;
        }

        public virtual void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey("Authorization"))
            {
                headers["Authorization"] = SanitizeValueArray;
            }
        }

        public virtual string SanitizeTextBody(string body)
        {
            return body;
        }

        public virtual byte[] SanitizeBody(byte[] body)
        {
            return body;
        }

        public virtual void SanitizeConnectionString(ConnectionString connectionString)
        {
            if (connectionString.Pairs.ContainsKey("Secret"))
            {
                connectionString.Pairs["Secret"] = SanitizeValue;
            }
        }
    }
}
