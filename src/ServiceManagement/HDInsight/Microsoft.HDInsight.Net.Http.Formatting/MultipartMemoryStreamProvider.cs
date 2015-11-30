// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Provides a <see cref="MultipartStreamProvider"/> implementation that returns a <see cref="MemoryStream"/> instance.
    /// This facilitates deserialization or other manipulation of the contents in memory.
    /// </summary>
    internal class MultipartMemoryStreamProvider : MultipartStreamProvider
    {
        /// <summary>
        /// This <see cref="MultipartStreamProvider"/> implementation returns a <see cref="MemoryStream"/> instance.
        /// This facilitates deserialization or other manipulation of the contents in memory. 
        /// </summary>
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (parent == null)
            {
                throw Error.ArgumentNull("parent");
            }

            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            return new MemoryStream();
        }
    }
}
