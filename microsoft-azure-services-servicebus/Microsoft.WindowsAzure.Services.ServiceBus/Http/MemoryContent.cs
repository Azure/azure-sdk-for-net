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
    /// A content whose data is stored in memory.
    /// </summary>
    internal class MemoryContent: IHttpContent
    {
        private byte[] _bytes;                              // Memory content.

        /// <summary>
        /// Initializes content with the text.
        /// </summary>
        /// <param name="text">Content text.</param>
        internal MemoryContent(string text)
        {
            Debug.Assert(text != null);
            _bytes = Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// Initializes content with the array of bytes.
        /// </summary>
        /// <param name="bytes">Content bytes.</param>
        internal MemoryContent(byte[] bytes)
        {
            Debug.Assert(bytes != null);
            _bytes = bytes;
        }

        /// <summary>
        /// Reads content as a string.
        /// </summary>
        /// <returns>Content string.</returns>
        Task<string> IHttpContent.ReadAsStringAsync()
        {
            using (MemoryStream stream = new MemoryStream(_bytes))
            {
                StreamReader reader = new StreamReader(stream);
                return reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// Reads content as a bytes array.
        /// </summary>
        /// <returns>Content bytes.</returns>
        Task<byte[]> IHttpContent.ReadAsBytesAsync()
        {
            TaskCompletionSource<byte[]> completion = new TaskCompletionSource<byte[]>();
            completion.SetResult(_bytes);
            return completion.Task;
        }

        /// <summary>
        /// Reads content as a stream.
        /// </summary>
        /// <returns>Content bytes in a stream.</returns>
        Task<Stream> IHttpContent.ReadAsStreamAsync()
        {
            TaskCompletionSource<Stream> completion = new TaskCompletionSource<Stream>();
            completion.SetResult(new MemoryStream(_bytes));
            return completion.Task;
        }

        /// <summary>
        /// Copies content into the given stream.
        /// </summary>
        /// <param name="stream">Destination stream.</param>
        /// <returns>Result of the operation.</returns>
        Task IHttpContent.CopyToAsync(Stream stream)
        {
            return stream.WriteAsync(_bytes, 0, _bytes.Length);
        }

        /// <summary>
        /// Buffers content into memory.
        /// </summary>
        /// <returns>Buffered content.</returns>
        Task<IHttpContent> IHttpContent.BufferContentAsync()
        {
            TaskCompletionSource<IHttpContent> completion = new TaskCompletionSource<IHttpContent>();
            completion.SetResult(this);
            return completion.Task;
        }
    }
}
