//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Body of a brokered message.
    /// </summary>
    internal class MessageBody
    {
        private Stream _stream;                             // Content stream.

        /// <summary>
        /// Gets content type of the message body.
        /// </summary>
        internal string ContentType { get; private set; }

        /// <summary>
        /// Constructor for text content.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <param name="text">Text content.</param>
        internal MessageBody(string contentType, string text)
        {
            ContentType = contentType;
            _stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(_stream, Encoding.UTF8);
            writer.Write(text);
            writer.Flush();
            _stream.Position = 0;
        }

        /// <summary>
        /// Constructor for binary content represented as an array of bytes.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <param name="bytes">Binary content.</param>
        internal MessageBody(string contentType, byte[] bytes)
        {
            ContentType = contentType;
            _stream = new MemoryStream(bytes);
        }

        /// <summary>
        /// Constructor for binary content represented as a stream.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <param name="stream">Binary content.</param>
        internal MessageBody(string contentType, Stream stream)
        {
            ContentType = contentType;
            _stream = stream;
        }

        /// <summary>
        /// Reads content as a string.
        /// </summary>
        /// <returns>String content.</returns>
        internal string ReadAsString()
        {
            Stream stream = GetSeekableStream();
            using (new StreamPositionGuard(stream))
            {
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Reads content as a byte array.
        /// </summary>
        /// <returns>Binary content.</returns>
        internal byte[] ReadAsBytes()
        {
            Stream stream = GetSeekableStream();
            using (new StreamPositionGuard(stream))
            {
                using (MemoryStream newStream = new MemoryStream())
                {
                    stream.CopyTo(newStream);
                    newStream.Flush();
                    newStream.Position = 0;
                    return newStream.ToArray();
                }
            }
        }

        /// <summary>
        /// Gets a stream for reading the content.
        /// </summary>
        /// <returns>Stream with the content.</returns>
        internal Stream ReadAsStream()
        {
            Stream stream = GetSeekableStream();
            using (new StreamPositionGuard(stream))
            {
                MemoryStream newStream = new MemoryStream();
                stream.CopyTo(newStream);
                newStream.Flush();
                newStream.Position = 0;
                return newStream;
            }
        }

        /// <summary>
        /// Copies content into the given stream.
        /// </summary>
        /// <param name="destinationStream">Target stream.</param>
        internal void CopyTo(Stream destinationStream)
        {
            Stream stream = GetSeekableStream();
            using (new StreamPositionGuard(stream))
            {
                stream.CopyTo(stream);
            }
        }

        /// <summary>
        /// Gets the seekable stream with the original data.
        /// </summary>
        /// <returns>Stream with the original data.</returns>
        private Stream GetSeekableStream()
        {
            if (!_stream.CanSeek)
            {
                // The stream does not support seeking and cannot be restored after
                // reading operations. Copy it into memory and replace the original.
                MemoryStream newStream = new MemoryStream();
                _stream.CopyTo(newStream);
                newStream.Flush();
                newStream.Position = 0;
                _stream = newStream;
            }
            return _stream;
        }

        /// <summary>
        /// Submits data into the request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequestMessage request)
        {
            request.Content = new StreamContent(_stream);
        }
    }
}
