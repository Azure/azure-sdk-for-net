// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;

    /// <summary>
    /// An <see cref="MultipartStreamProvider"/> implementation examines the headers provided by the MIME multipart parser
    /// as part of the MIME multipart extension methods (see <see cref="HttpContentMultipartExtensions"/>) and decides 
    /// what kind of stream to return for the body part to be written to.
    /// </summary>
    internal abstract class MultipartStreamProvider
    {
        private Collection<HttpContent> _contents = new Collection<HttpContent>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipartStreamProvider"/> class.
        /// </summary>
        protected MultipartStreamProvider()
        {
        }

        /// <summary>
        /// Gets the collection of <see cref="HttpContent"/> instances where each instance represents a MIME body part.
        /// </summary>
        public Collection<HttpContent> Contents
        {
            get { return this._contents; }
        }

        /// <summary>
        /// When a MIME multipart body part has been parsed this method is called to get a stream for where to write the body part to.
        /// </summary>
        /// <param name="parent">The parent <see cref="HttpContent"/> MIME multipart instance.</param>
        /// <param name="headers">The header fields describing the body parts content. Looking for header fields such as 
        /// Content-Type and Content-Disposition can help provide the appropriate stream. In addition to using the information
        /// in the provided header fields, it is also possible to add new header fields or modify existing header fields. This can
        /// be useful to get around situations where the Content-type may say <b>application/octet-stream</b> but based on
        /// analyzing the <b>Content-Disposition</b> header field it is found that the content in fact is <b>application/json</b>, for example.</param>
        /// <returns>A stream instance where the contents of a body part will be written to.</returns>
        public abstract Stream GetStream(HttpContent parent, HttpContentHeaders headers);

        /// <summary>
        /// Immediately upon reading the last MIME body part but before completing the read task, this method is 
        /// called to enable the <see cref="MultipartStreamProvider"/> to do any post processing on the <see cref="HttpContent"/>
        /// instances that have been read. For example, it can be used to copy the data to another location, or perform
        /// some other kind of post processing on the data before completing the read operation.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the post processing.</returns>
        public virtual Task ExecutePostProcessingAsync()
        {
            return TaskHelpers.Completed();
        }

        /// <summary>
        /// Immediately upon reading the last MIME body part but before completing the read task, this method is 
        /// called to enable the <see cref="MultipartStreamProvider"/> to do any post processing on the <see cref="HttpContent"/>
        /// instances that have been read. For example, it can be used to copy the data to another location, or perform
        /// some other kind of post processing on the data before completing the read operation.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task"/> representing the post processing.</returns>
        public virtual Task ExecutePostProcessingAsync(CancellationToken cancellationToken)
        {
            // Call the other overload to maintain backward compatibility.
            return this.ExecutePostProcessingAsync();
        }
    }
}
