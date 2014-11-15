// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Net.Http.Headers;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Represents a multipart file data for remote storage.
    /// </summary>
    internal class MultipartRemoteFileData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartRemoteFileData"/> class.
        /// </summary>
        /// <param name="headers">The headers of the multipart file data.</param>
        /// <param name="location">The remote file's location.</param>
        /// <param name="fileName">The remote file's name.</param>
        public MultipartRemoteFileData(HttpContentHeaders headers, string location, string fileName)
        {
            if (headers == null)
            {
                throw Error.ArgumentNull("headers");
            }

            if (location == null)
            {
                throw Error.ArgumentNull("location");
            }

            if (fileName == null)
            {
                throw Error.ArgumentNull("fileName");
            }

            this.FileName = fileName;
            this.Headers = headers;
            this.Location = location;
        }

        /// <summary>
        /// Gets the remote file's name.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the headers of the multipart file data.
        /// </summary>
        public HttpContentHeaders Headers { get; private set; }

        /// <summary>
        /// Gets the remote file's location.
        /// </summary>
        public string Location { get; private set; }
    }
}
