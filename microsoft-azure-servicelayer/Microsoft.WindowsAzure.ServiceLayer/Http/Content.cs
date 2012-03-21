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
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// HTTP content.
    /// </summary>
    /// <remarks>The class represents a container for HTTP content, which is
    /// used in body of an HTTP request. The class provides multiple methods
    /// for reading stored data, however, unless the content is buffered into
    /// memory, the data can be read only once. If you plan to read data more
    /// than once, you should load content's data into memory by calling
    /// CopyInfoBufferAsync.</remarks>
    public sealed class Content
    {
        private IContent _rawContent;                       // Raw content.

        /// <summary>
        /// Gets content type.
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// Creates a content from the given string.
        /// </summary>
        /// <param name="text">String content.</param>
        /// <param name="contentType">HTTP content type.</param>
        /// <returns>Content object.</returns>
        public static Content CreateFromString(string text, string contentType)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            if (contentType == null)
            {
                throw new ArgumentNullException("contentType");
            }

            return new Content(
                new MemoryContent(text),
                contentType);
        }

        /// <summary>
        /// Creates a content from binary data specified in the array.
        /// </summary>
        /// <param name="bytes">Binary data.</param>
        /// <returns>Content object.</returns>
        public static Content CreateFromByteArray(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }

            return new Content(new MemoryContent(bytes));
        }

        /// <summary>
        /// Creates a content from binary data specified in the stream.
        /// </summary>
        /// <param name="stream">Binary data.</param>
        /// <returns>Content object.</returns>
        public static Content CreateFromStream(IInputStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            return new Content(new StreamContent(stream.AsStreamForRead()));
        }

        /// <summary>
        /// Initializes the content.
        /// </summary>
        /// <param name="rawContent">Content container.</param>
        /// <param name="contentType">Content type.</param>
        private Content(IContent rawContent, string contentType = null)
        {
            _rawContent = rawContent;
            ContentType = contentType;
        }

        /// <summary>
        /// Reads content as a string.
        /// </summary>
        /// <returns>Content string.</returns>
        public IAsyncOperation<string> ReadAsStringAsync()
        {
            return _rawContent
                .ReadAsStringAsync()
                .AsAsyncOperation();
        }

        /// <summary>
        /// Reads content as a byte array.
        /// </summary>
        /// <returns>Content bytes.</returns>
        public IAsyncOperation<IEnumerable<byte>> ReadAsByteArrayAsync()
        {
            //TODO: this mehtod returns IEnumerable<byte> instead of byte[] because
            // winmd does not accept arrays as return values. Check this with the
            // latest version and make this method consistent with 
            // CreateFromByteArray method.
            return _rawContent
                .ReadAsBytesAsync()
                .ContinueWith<IEnumerable<byte>>(t => t.Result, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation();
        }

        /// <summary>
        /// Reads content as a stream of bytes.
        /// </summary>
        /// <returns>Content bytes.</returns>
        public IAsyncOperation<IInputStream> ReadAsStreamAsync()
        {
            return _rawContent
                .ReadAsStreamAsync()
                .ContinueWith(t => t.Result.AsInputStream(), TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation();
        }

        /// <summary>
        /// Copies content into the given stream.
        /// </summary>
        /// <param name="stream">Target stream.</param>
        /// <returns>Result of the operation.</returns>
        public IAsyncAction CopyToAsync(IOutputStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            return _rawContent
                .CopyToAsync(stream.AsStreamForWrite())
                .AsAsyncAction();
        }

        /// <summary>
        /// Copies content into an internal buffer allowing multiple read
        /// operations.
        /// </summary>
        /// <returns>Result of the operation.</returns>
        public IAsyncAction CopyToBufferAsync()
        {
            return _rawContent.BufferContentAsync()
                .ContinueWith(t => { _rawContent = t.Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncAction();
        }

        /// <summary>
        /// Submits content data into the given request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequestMessage request)
        {
            HttpContent content = new System.Net.Http.StreamContent(
                _rawContent.ReadAsStreamAsync().Result);

            if (!string.IsNullOrEmpty(ContentType))
            {
                content.Headers.Add("Content-Type", ContentType);
            }
            request.Content = content;
        }
    }
}
