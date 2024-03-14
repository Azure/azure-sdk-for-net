// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

//public partial class MultipartBinaryContent : BinaryContent
//{/// <summary>
// /// A helper class representing a subpart of a multipart content.
// /// </summary>
//    private struct MultipartContentSubpart
//    {
//        /// <summary>
//        /// The <see cref="BinaryContent"/> that represents the content of this subpart.
//        /// </summary>
//        public BinaryContent Content { get; }

//        /// <summary>
//        /// The headers for this subpart.
//        /// </summary>
//        public (string Name, string Value)[] Headers { get; }

//        public MultipartContentSubpart(BinaryContent content, (string, string)[] headers)
//        {
//            Content = content;
//            Headers = headers;
//        }

//        /// <summary>
//        /// Writes the <see cref="Headers"/> and <see cref="Content"/> of this subpart to the provided <see cref="Stream"/>.
//        /// </summary>
//        /// <param name="stream">The <see cref="Stream"/> to write to.</param>
//        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal cancellation of the write operation.</param>
//        public void WriteTo(Stream stream, CancellationToken cancellationToken)
//        {
//            // Write headers on a new line
//            stream.Write(s_crLfBytes, 0, s_crLfBytes.Length);

//            // Write the headers to stream
//            foreach (var header in Headers)
//            {
//                cancellationToken.ThrowIfCancellationRequested();

//                string headerString = $"{header.Name}{ColonSpace}{header.Value}{CrLf}";
//                byte[] headerBytes = Encoding.UTF8.GetBytes(headerString);
//                stream.Write(headerBytes, 0, headerBytes.Length);
//            }

//            // Add another line
//            stream.Write(s_crLfBytes, 0, s_crLfBytes.Length);

//            // Write the content to stream
//            Content.WriteTo(stream, cancellationToken);
//        }

//        /// <summary>
//        /// Writes the <see cref="Headers"/> and <see cref="Content"/> of this subpart to the provided <see cref="Stream"/>.
//        /// </summary>
//        /// <param name="stream">The <see cref="Stream"/> to write to.</param>
//        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal cancellation of the write operation.</param>
//        public async Task WriteToAsync(Stream stream, CancellationToken cancellationToken)
//        {
//            // Write headers on a new line
//            await stream.WriteAsync(s_crLfBytes, 0, s_crLfBytes.Length, cancellationToken).ConfigureAwait(false);

//            // Write the headers to stream
//            foreach (var header in Headers)
//            {
//                string headerString = $"{header.Name}{ColonSpace}{header.Value}{CrLf}";
//                byte[] headerBytes = Encoding.UTF8.GetBytes(headerString);
//                await stream.WriteAsync(headerBytes, 0, headerBytes.Length, cancellationToken).ConfigureAwait(false);
//            }

//            // Add another line
//            await stream.WriteAsync(s_crLfBytes, 0, s_crLfBytes.Length, cancellationToken).ConfigureAwait(false);

//            // Write the content to stream
//            await Content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
//        }
//    }
//}
