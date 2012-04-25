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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

using NetHttpContent = System.Net.Http.HttpContent;
using NetHttpRequestMessage = System.Net.Http.HttpRequestMessage;
using NetHttpResponseMessage = System.Net.Http.HttpResponseMessage;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// A data container for brokered messages, HTTP requests and responses.
    /// </summary>
    /// <remarks>
    /// The class represents a container for HTTP content, which is used in 
    /// body of an HTTP request. The class provides multiple methods for 
    /// reading stored data, however, unless the content is buffered into
    /// memory, the data can be read only once. If you plan to read data more
    /// than once, you should load content's data into memory by calling
    /// CopyInfoBufferAsync.</remarks>
    public sealed class HttpContent
    {
        private IHttpContent _rawContent;                       // Container with data.

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
        public static HttpContent CreateFromText(string text, string contentType)
        {
            Validator.ArgumentIsNotNull("text", text);
            Validator.ArgumentIsNotNullOrEmptyString("contentType", contentType);

            return new HttpContent(
                new MemoryContent(text),
                contentType);
        }

        /// <summary>
        /// Creates a content from binary data specified in the array.
        /// </summary>
        /// <param name="bytes">Binary data.</param>
        /// <returns>Content object.</returns>
        public static HttpContent CreateFromByteArray([ReadOnlyArray] byte[] bytes)
        {
            Validator.ArgumentIsNotNull("bytes", bytes);

            return new HttpContent(new MemoryContent(bytes));
        }

        /// <summary>
        /// Creates a content from binary data specified in the stream.
        /// </summary>
        /// <param name="stream">Binary data.</param>
        /// <returns>Content object.</returns>
        public static HttpContent CreateFromStream(IInputStream stream)
        {
            Validator.ArgumentIsNotNull("stream", stream);

            return new HttpContent(new StreamContent(stream.AsStreamForRead()));
        }

        /// <summary>
        /// Initializes the content.
        /// </summary>
        /// <param name="rawContent">Content container.</param>
        /// <param name="contentType">Content type.</param>
        private HttpContent(IHttpContent rawContent, string contentType = null)
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
            Validator.ArgumentIsNotNull("stream", stream);

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
        internal void SubmitTo(NetHttpRequestMessage request)
        {
            NetHttpContent content = new System.Net.Http.StreamContent(
                _rawContent.ReadAsStreamAsync().Result);

            if (!string.IsNullOrEmpty(ContentType))
            {
                content.Headers.Add(Constants.ContentTypeHeader, ContentType);
            }
            request.Content = content;
        }

        /// <summary>
        /// Creates a content from the HTTP response.
        /// </summary>
        /// <param name="response">Source HTTP response.</param>
        /// <returns>Content.</returns>
        internal static HttpContent CreateFromResponse(NetHttpResponseMessage response)
        {
            HttpContent content = null;

            if (response.Content != null)
            {
                content = new HttpContent(new StreamContent(response.Content.ReadAsStreamAsync().Result));

                IEnumerable<string> contentTypes;

                if (response.Content.Headers.TryGetValues(Constants.ContentTypeHeader, out contentTypes))
                {
                    foreach (string type in contentTypes)
                    {
                        content.ContentType = type;
                        break;
                    }
                }
            }
            return content;
        }
    }
}
