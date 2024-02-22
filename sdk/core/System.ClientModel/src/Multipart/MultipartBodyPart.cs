// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace System.ClientModel.Primitives
{
    /// <summary>
    /// A body part of multipart content.
    /// </summary>
    public class MultipartBodyPart: IPersistableStreamModel<MultipartBodyPart>
    {
        private const int BufferSize = 1024;
        /// <summary> The request content of this part. </summary>
        public object Content { get; }
        /// <summary> The headers of this content part. </summary>
        public IDictionary<string, string> Headers { get; }
        public string ContentType { get; } = "application/json";

        /// <summary>
        ///  Initializes a new instance of the <see cref="MultipartBodyPart"/> class.
        ///  </summary>
        ///  <param name="content">The content of the body part.</param>
        /// <param name="headers">The headers of this body part.</param>
        private MultipartBodyPart(object content, IDictionary<string, string>? headers = null)
        {
            Content = content;
            Headers = headers ?? new Dictionary<string, string>();
        }

        public MultipartBodyPart(BinaryData content, IDictionary<string, string>? headers = null): this(content as object, headers)
        {
            ContentType = content.MediaType ?? "application/json";
        }
        public MultipartBodyPart(MultipartFile content, IDictionary<string, string>? headers = null): this(content as object, headers)
        {
            ContentType = content.ContentType ?? "application/octet-stream";
        }
        void IPersistableStreamModel<MultipartBodyPart>.Write(Stream stream, ModelReaderWriterOptions options)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            byte[] buffer;
            switch (Content)
            {
                case BinaryData binaryData:
                    //buffer = binaryData.ToArray();
                    //stream.Write(buffer, 0, buffer.Length);
                    Stream s = binaryData.ToStream();
                    s.CopyTo(stream);
                    break;
                case MultipartFile file:
                    if (file.FilePath != null)
                    {
                        using FileStream fileStream = File.OpenRead(file.FilePath);
                        buffer = new byte[BufferSize];
                        int numBytesToRead = BufferSize;
                        long numBytesRemaining = fileStream.Length;
                        while (numBytesRemaining > 0)
                        {
                            // Read may return anything from 0 to numBytesToRead.
                            int n = fileStream.Read(buffer, 0, numBytesToRead);

                            // Break when the end of the file is reached.
                            if (n == 0)
                                break;

                            numBytesRemaining -= n;
                            stream.Write(buffer, 0, n);
                        }
                    } else if (file.Content != null)
                    {
                        buffer = file.Content.ToArray();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unsupported content type");
            }
        }
        Task IPersistableStreamModel<MultipartBodyPart>.WriteAsync(Stream stream, ModelReaderWriterOptions options, CancellationToken cancellationToken)
        {
            if (options == null || options.Format != "MPFD")
            {
                throw new InvalidOperationException("The specified format is not supported.");
            }
            return SerializeToStreamAsync(stream, cancellationToken);
        }
        private async Task SerializeToStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
            //return WriteToStreamAsync(stream, cancellation);
            byte[] buffer;
            switch (Content)
            {
                case BinaryData binaryData:
                    //buffer = binaryData.ToArray();
                    //await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                    Stream s = binaryData.ToStream();
                    await s.CopyToAsync(stream, (int)s.Length, cancellationToken).ConfigureAwait(false);
                    break;
                case MultipartFile file:
                    if (file.FilePath != null)
                    {
                        using FileStream fileStream = File.OpenRead(file.FilePath);
                        buffer = new byte[BufferSize];
                        int numBytesToRead = BufferSize;
                        long numBytesRemaining = fileStream.Length;
                        while (numBytesRemaining > 0)
                        {
                            // Read may return anything from 0 to numBytesToRead.
                            int n = fileStream.Read(buffer, 0, numBytesToRead);

                            // Break when the end of the file is reached.
                            if (n == 0)
                                break;

                            numBytesRemaining -= n;
                            await stream.WriteAsync(buffer, 0, n, cancellationToken).ConfigureAwait(false);
                        }
                    } else if (file.Content != null)
                    {
                        buffer = file.Content.ToArray();
                        await stream.WriteAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unsupported content type");
            }
        }
        MultipartBodyPart IPersistableStreamModel<MultipartBodyPart>.Create(Stream stream, string contentType, ModelReaderWriterOptions options)
        {
            //not implemented
            return new MultipartBodyPart(BinaryData.FromString("not implemneted"), new Dictionary<string, string>());
        }

        string IPersistableStreamModel<MultipartBodyPart>.GetMediaType(ModelReaderWriterOptions options)
        {
            return ContentType;
        }
    }
}
