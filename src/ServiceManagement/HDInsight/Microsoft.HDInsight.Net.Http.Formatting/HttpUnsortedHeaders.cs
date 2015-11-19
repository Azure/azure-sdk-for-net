// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Net.Http.Headers;

    /// <summary>
    /// All of the existing non-abstract <see cref="HttpHeaders"/> implementations, namely
    /// <see cref="HttpRequestHeaders"/>, <see cref="HttpResponseHeaders"/>, and <see cref="HttpContentHeaders"/>
    /// enforce strict rules on what kinds of HTTP header fields can be added to each collection.
    /// When parsing the "application/http" media type we need to just get the unsorted list. It
    /// will get sorted later.
    /// </summary>
    internal class HttpUnsortedHeaders : HttpHeaders
    {
    }
}
