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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Services.ServiceBus.Http
{
    /// <summary>
    /// Stream-based content.
    /// </summary>
    internal class StreamContent: IHttpContent
    {
        private Stream _stream;                             // Data stream.

        /// <summary>
        /// Initializes the content with the stream data.
        /// </summary>
        /// <param name="stream">Content stream.</param>
        internal StreamContent(Stream stream)
        {
            Debug.Assert(stream != null);
            _stream = stream;
        }

        /// <summary>
        /// Reads content as a string.
        /// </summary>
        /// <returns>Content string.</returns>
        Task<string> IHttpContent.ReadAsStringAsync()
        {
            StreamReader reader = new StreamReader(_stream);
            return reader.ReadToEndAsync();
        }

        /// <summary>
        /// Reads content as a bytes array.
        /// </summary>
        /// <returns>Content bytes.</returns>
        Task<byte[]> IHttpContent.ReadAsBytesAsync()
        {
            MemoryStream buffer = new MemoryStream();
            return _stream
                .CopyToAsync(buffer)
                .ContinueWith(t => buffer.ToArray(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Reads content as a stream of bytes.
        /// </summary>
        /// <returns>Content bytes.</returns>
        Task<Stream> IHttpContent.ReadAsStreamAsync()
        {
            TaskCompletionSource<Stream> completion = new TaskCompletionSource<Stream>();
            completion.SetResult(_stream);
            return completion.Task;
        }

        /// <summary>
        /// Copies content into the given stream.
        /// </summary>
        /// <param name="stream">Destination stream.</param>
        /// <returns>Result of the operation.</returns>
        Task IHttpContent.CopyToAsync(Stream stream)
        {
            return _stream.CopyToAsync(stream);
        }

        /// <summary>
        /// Buffers content into memory making all its read operations 
        /// reusable.
        /// </summary>
        /// <returns>Buffered content.</returns>
        Task<IHttpContent> IHttpContent.BufferContentAsync()
        {
            MemoryStream buffer = new MemoryStream();

            return _stream
                .CopyToAsync(buffer)
                .ContinueWith(t =>
                    {
                        buffer.Flush();
                        byte[] bytes = buffer.ToArray();
                        buffer.Dispose();
                        return new MemoryContent(bytes) as IHttpContent;
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
