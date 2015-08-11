// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net.Http.Headers;

    internal static class HttpHeaderExtensions
    {
        public static void CopyTo(this HttpContentHeaders fromHeaders, HttpContentHeaders toHeaders)
        {
            Contract.Assert(fromHeaders != null, "fromHeaders cannot be null.");
            Contract.Assert(toHeaders != null, "toHeaders cannot be null.");

            foreach (KeyValuePair<string, IEnumerable<string>> header in fromHeaders)
            {
                toHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
    }
}
