// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Internal;

    /// <summary>
    /// A <see cref="MultipartStreamProvider"/> implementation suited for use with HTML file uploads for writing file
    /// content to a remote storage <see cref="Stream"/>. The stream provider looks at the <b>Content-Disposition</b>
    /// header field and determines an output remote <see cref="Stream"/> based on the presence of a <b>filename</b>
    /// parameter. If a <b>filename</b> parameter is present in the <b>Content-Disposition</b> header field, then the
    /// body part is written to a remote <see cref="Stream"/> provided by <see cref="GetRemoteStream"/>.
    /// Otherwise it is written to a <see cref="MemoryStream"/>.
    /// </summary>
    internal abstract class MultipartFormDataRemoteStreamProvider : MultipartStreamProvider
    {
        private CancellationToken _cancellationToken = CancellationToken.None;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartFormDataRemoteStreamProvider"/> class.
        /// </summary>
        protected MultipartFormDataRemoteStreamProvider()
        {
            this.FormData = HttpValueCollection.Create();
            this.FileData = new Collection<MultipartRemoteFileData>();
        }

        /// <summary>
        /// Gets a collection of file data passed as part of the multipart form data.
        /// </summary>
        public Collection<MultipartRemoteFileData> FileData { get; private set; }

        /// <summary>
        /// Gets a <see cref="NameValueCollection"/> of form data passed as part of the multipart form data.
        /// </summary>
        public NameValueCollection FormData { get; private set; }

        /// <summary>
        /// Provides a <see cref="RemoteStreamInfo"/> for <see cref="GetStream"/>. Override this method to provide a
        /// remote stream to which the data should be written.
        /// </summary>
        /// <param name="parent">The parent <see cref="HttpContent"/> MIME multipart instance.</param>
        /// <param name="headers">The header fields describing the body part's content. </param>
        /// <returns>
        /// A result specifying a remote stream where the file will be written to and a location where the file can be
        /// accessed. It cannot be null and the stream must be writable.
        /// </returns>
        public abstract RemoteStreamInfo GetRemoteStream(HttpContent parent, HttpContentHeaders headers);

        /// <inheritdoc />
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (MultipartFormDataStreamProviderHelper.IsFileContent(parent, headers))
            {
                RemoteStreamInfo remoteStreamInfo = this.GetRemoteStream(parent, headers);
                if (remoteStreamInfo == null)
                {
                    throw Error.InvalidOperation(Resources.RemoteStreamInfoCannotBeNull,
                        "GetRemoteStream", this.GetType().Name);
                }
                this.FileData.Add(new MultipartRemoteFileData(headers, remoteStreamInfo.Location, remoteStreamInfo.FileName));

                return remoteStreamInfo.RemoteStream;
            }

            return new MemoryStream();
        }

        /// <summary>
        /// Read the non-file contents as form data.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the post processing.</returns>
        public override Task ExecutePostProcessingAsync()
        {
            // In consistency with existing MultipartFormDataStreamProvider,
            // this method predates support for cancellation, and we need to make sure it is always invoked when
            // ExecutePostProcessingAsync is called for compatability.
            return MultipartFormDataStreamProviderHelper.ReadFormDataAsync(this.Contents, this.FormData,
                this._cancellationToken);
        }

        /// <summary>
        /// Read the non-file contents as form data.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the post processing.</returns>
        public override Task ExecutePostProcessingAsync(CancellationToken cancellationToken)
        {
            this._cancellationToken = cancellationToken;
            return this.ExecutePostProcessingAsync();
        }
    }
}
