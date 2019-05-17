// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Testing
{
    public class RecordedTestRedactions
    {
        private const string RedactedValue = "REDACTED";
        private static readonly string[] RedactedValueArray = new [] { RedactedValue };

        public virtual string RedactUri(string uri)
        {
            return uri;
        }

        public virtual void RedactHeaders(IDictionary<string, string[]> headers)
        {
            if (headers.ContainsKey("Authorization"))
            {
                headers["Authorization"] = RedactedValueArray;
            }
        }

        public virtual string RedactTextBody(string body)
        {
            return body;
        }

        public virtual byte[] RedactBody(byte[] body)
        {
            return body;
        }

        public virtual void RedactConnectionString(ConnectionString connectionString)
        {
            if (connectionString.Pairs.ContainsKey("Secret"))
            {
                connectionString.Pairs["Secret"] = RedactedValue;
            }
        }
    }
}
