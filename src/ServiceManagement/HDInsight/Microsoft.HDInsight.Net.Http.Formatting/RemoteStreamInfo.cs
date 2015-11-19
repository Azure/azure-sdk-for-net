// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.IO;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// Represents the result for <see cref="MultipartFormDataRemoteStreamProvider.GetRemoteStream"/>.
    /// </summary>
    internal class RemoteStreamInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteStreamInfo"/> class.
        /// </summary>
        /// <param name="remoteStream">
        /// The remote stream instance where the file will be written to.
        /// </param>
        /// <param name="location">The remote file's location.</param>
        /// <param name="fileName">The remote file's name.</param>
        public RemoteStreamInfo(Stream remoteStream, string location, string fileName)
        {
            if (remoteStream == null)
            {
                throw Error.ArgumentNull("remoteStream");
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
            this.RemoteStream = remoteStream;
            this.Location = location;
        }

        /// <summary>
        /// Gets the remote file's location.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the remote file's location.
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the remote stream instance where the file will be written to.
        /// </summary>
        public Stream RemoteStream { get; private set; }
    }
}
