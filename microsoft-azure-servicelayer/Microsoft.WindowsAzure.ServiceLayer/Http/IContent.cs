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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.Http
{
    /// <summary>
    /// Content interface. The interface is used to hide details on physical 
    /// storage mechanism.
    /// </summary>
    interface IContent
    {
        /// <summary>
        /// Reads content as a string.
        /// </summary>
        /// <returns>Content string.</returns>
        Task<string> ReadAsStringAsync();

        /// <summary>
        /// Reads content as an array of bytes.
        /// </summary>
        /// <returns>Content bytes.</returns>
        Task<byte[]> ReadAsBytesAsync();

        /// <summary>
        /// Reads content as a stream.
        /// </summary>
        /// <returns>Content bytes.</returns>
        Task<Stream> ReadAsStreamAsync();

        /// <summary>
        /// Copies content into the given stream.
        /// </summary>
        /// <param name="stream">Target stream.</param>
        /// <returns>Result of the operation.</returns>
        Task CopyToAsync(Stream stream);

        /// <summary>
        /// Buffers content into memory.
        /// </summary>
        /// <returns>Buffered content.</returns>
        /// <remarks>Buffering content allows multiple reading operations from
        /// the same content. Without buffering, data from stream-based content
        /// can be read only once.</remarks>
        Task<IContent> BufferContentAsync();
    }
}
