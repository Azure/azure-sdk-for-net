// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.HDInsight.Net.Http.Formatting.Common;
    using Microsoft.HDInsight.Net.Http.Formatting.Formatting.Parsers;

    /// <summary>
    /// Extension methods to read MIME multipart entities from <see cref="HttpContent"/> instances.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class HttpContentMultipartExtensions
    {
        private const int MinBufferSize = 256;
        private const int DefaultBufferSize = 32 * 1024;

        /// <summary>
        /// Determines whether the specified content is MIME multipart content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>
        ///   <c>true</c> if the specified content is MIME multipart content; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMimeMultipartContent(this HttpContent content)
        {
            if (content == null)
            {
                throw Error.ArgumentNull("content");
            }

            return MimeMultipartBodyPartParser.IsMimeMultipartContent(content);
        }

        /// <summary>
        /// Determines whether the specified content is MIME multipart content with the 
        /// specified subtype. For example, the subtype <c>mixed</c> would match content
        /// with a content type of <c>multipart/mixed</c>. 
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="subtype">The MIME multipart subtype to match.</param>
        /// <returns>
        ///   <c>true</c> if the specified content is MIME multipart content with the specified subtype; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMimeMultipartContent(this HttpContent content, string subtype)
        {
            if (String.IsNullOrWhiteSpace(subtype))
            {
                throw Error.ArgumentNull("subtype");
            }

            if (IsMimeMultipartContent(content))
            {
                if (content.Headers.ContentType.MediaType.Equals("multipart/" + subtype, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Reads all body parts within a MIME multipart message into memory using a <see cref="MultipartMemoryStreamProvider"/>.
        /// </summary>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <returns>A <see cref="Task{T}"/> representing the tasks of getting the result of reading the MIME content.</returns>
        public static Task<MultipartMemoryStreamProvider> ReadAsMultipartAsync(this HttpContent content)
        {
            return ReadAsMultipartAsync<MultipartMemoryStreamProvider>(content, new MultipartMemoryStreamProvider(), DefaultBufferSize);
        }

        /// <summary>
        /// Reads all body parts within a MIME multipart message into memory using a <see cref="MultipartMemoryStreamProvider"/>.
        /// </summary>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task{T}"/> representing the tasks of getting the result of reading the MIME content.</returns>
        public static Task<MultipartMemoryStreamProvider> ReadAsMultipartAsync(this HttpContent content, CancellationToken cancellationToken)
        {
            return ReadAsMultipartAsync<MultipartMemoryStreamProvider>(content, new MultipartMemoryStreamProvider(), DefaultBufferSize, cancellationToken);
        }

        /// <summary>
        /// Reads all body parts within a MIME multipart message using the provided <see cref="MultipartStreamProvider"/> instance
        /// to determine where the contents of each body part is written. 
        /// </summary>
        /// <typeparam name="T">The <see cref="MultipartStreamProvider"/> with which to process the data.</typeparam>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="streamProvider">A stream provider providing output streams for where to write body parts as they are parsed.</param>
        /// <returns>A <see cref="Task{T}"/> representing the tasks of getting the result of reading the MIME content.</returns>
        public static Task<T> ReadAsMultipartAsync<T>(this HttpContent content, T streamProvider) where T : MultipartStreamProvider
        {
            return ReadAsMultipartAsync(content, streamProvider, DefaultBufferSize);
        }

        /// <summary>
        /// Reads all body parts within a MIME multipart message using the provided <see cref="MultipartStreamProvider"/> instance
        /// to determine where the contents of each body part is written. 
        /// </summary>
        /// <typeparam name="T">The <see cref="MultipartStreamProvider"/> with which to process the data.</typeparam>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="streamProvider">A stream provider providing output streams for where to write body parts as they are parsed.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task{T}"/> representing the tasks of getting the result of reading the MIME content.</returns>
        public static Task<T> ReadAsMultipartAsync<T>(this HttpContent content, T streamProvider, CancellationToken cancellationToken)
            where T : MultipartStreamProvider
        {
            return ReadAsMultipartAsync(content, streamProvider, DefaultBufferSize, cancellationToken);
        }

        /// <summary>
        /// Reads all body parts within a MIME multipart message using the provided <see cref="MultipartStreamProvider"/> instance
        /// to determine where the contents of each body part is written and <paramref name="bufferSize"/> as read buffer size.
        /// </summary>
        /// <typeparam name="T">The <see cref="MultipartStreamProvider"/> with which to process the data.</typeparam>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="streamProvider">A stream provider providing output streams for where to write body parts as they are parsed.</param>
        /// <param name="bufferSize">Size of the buffer used to read the contents.</param>
        /// <returns>A <see cref="Task{T}"/> representing the tasks of getting the result of reading the MIME content.</returns>
        public static Task<T> ReadAsMultipartAsync<T>(this HttpContent content, T streamProvider, int bufferSize)
            where T : MultipartStreamProvider
        {
            return ReadAsMultipartAsync(content, streamProvider, bufferSize, CancellationToken.None);
        }

        /// <summary>
        /// Reads all body parts within a MIME multipart message using the provided <see cref="MultipartStreamProvider"/> instance
        /// to determine where the contents of each body part is written and <paramref name="bufferSize"/> as read buffer size.
        /// </summary>
        /// <typeparam name="T">The <see cref="MultipartStreamProvider"/> with which to process the data.</typeparam>
        /// <param name="content">An existing <see cref="HttpContent"/> instance to use for the object's content.</param>
        /// <param name="streamProvider">A stream provider providing output streams for where to write body parts as they are parsed.</param>
        /// <param name="bufferSize">Size of the buffer used to read the contents.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="Task{T}"/> representing the tasks of getting the result of reading the MIME content.</returns>
        public static async Task<T> ReadAsMultipartAsync<T>(this HttpContent content, T streamProvider, int bufferSize,
            CancellationToken cancellationToken) where T : MultipartStreamProvider
        {
            if (content == null)
            {
                throw Error.ArgumentNull("content");
            }

            if (streamProvider == null)
            {
                throw Error.ArgumentNull("streamProvider");
            }

            if (bufferSize < MinBufferSize)
            {
                throw Error.ArgumentMustBeGreaterThanOrEqualTo("bufferSize", bufferSize, MinBufferSize);
            }

            Stream stream;
            try
            {
                stream = await content.ReadAsStreamAsync();
            }
            catch (Exception e)
            {
                throw new IOException(Resources.ReadAsMimeMultipartErrorReading, e);
            }

            using (var parser = new MimeMultipartBodyPartParser(content, streamProvider))
            {
                byte[] data = new byte[bufferSize];
                MultipartAsyncContext context = new MultipartAsyncContext(stream, parser, data, streamProvider.Contents);

                // Start async read/write loop
                await MultipartReadAsync(context, cancellationToken);

                // Let the stream provider post-process when everything is complete
                await streamProvider.ExecutePostProcessingAsync(cancellationToken);
                return streamProvider;
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exception is propagated.")]
        private static async Task MultipartReadAsync(MultipartAsyncContext context, CancellationToken cancellationToken)
        {
            Contract.Assert(context != null, "context cannot be null");
            while (true)
            {
                int bytesRead;
                try
                {
                    bytesRead = await context.ContentStream.ReadAsync(context.Data, 0, context.Data.Length, cancellationToken);
                }
                catch (Exception e)
                {
                    throw new IOException(Resources.ReadAsMimeMultipartErrorReading, e);
                }

                IEnumerable<MimeBodyPart> parts = context.MimeParser.ParseBuffer(context.Data, bytesRead);

                foreach (MimeBodyPart part in parts)
                {
                    foreach (ArraySegment<byte> segment in part.Segments)
                    {
                        try
                        {
                            await part.WriteSegment(segment, cancellationToken);
                        }
                        catch (Exception e)
                        {
                            part.Dispose();
                            throw new IOException(Resources.ReadAsMimeMultipartErrorWriting, e);
                        }
                    }

                    if (CheckIsFinalPart(part, context.Result))
                    {
                        return;
                    }
                }
            }
        }

        private static bool CheckIsFinalPart(MimeBodyPart part, ICollection<HttpContent> result)
        {
            Contract.Assert(part != null, "part cannot be null.");
            Contract.Assert(result != null, "result cannot be null.");
            if (part.IsComplete)
            {
                HttpContent partContent = part.GetCompletedHttpContent();
                if (partContent != null)
                {
                    result.Add(partContent);
                }

                bool isFinal = part.IsFinal;
                part.Dispose();
                return isFinal;
            }

            return false;
        }

        /// <summary>
        /// Managing state for asynchronous read and write operations
        /// </summary>
        private class MultipartAsyncContext
        {
            public MultipartAsyncContext(Stream contentStream, MimeMultipartBodyPartParser mimeParser, byte[] data, ICollection<HttpContent> result)
            {
                Contract.Assert(contentStream != null);
                Contract.Assert(mimeParser != null);
                Contract.Assert(data != null);

                this.ContentStream = contentStream;
                this.Result = result;
                this.MimeParser = mimeParser;
                this.Data = data;
            }

            /// <summary>
            /// Gets the <see cref="Stream"/> that we read from.
            /// </summary>
            public Stream ContentStream { get; private set; }

            /// <summary>
            /// Gets the collection of parsed <see cref="HttpContent"/> instances.
            /// </summary>
            public ICollection<HttpContent> Result { get; private set; }

            /// <summary>
            /// The data buffer that we use for reading data from the input stream into before processing.
            /// </summary>
            public byte[] Data { get; private set; }

            /// <summary>
            /// Gets the MIME parser instance used to parse the data
            /// </summary>
            public MimeMultipartBodyPartParser MimeParser { get; private set; }
        }
    }
}
