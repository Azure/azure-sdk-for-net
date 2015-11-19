// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Defines operations that the DataLakeUploader needs from the FrontEnd in order to operate
    /// </summary>
    public interface IFrontEndAdapter
    {
        /// <summary>
        /// Creates a new, empty stream at the given path.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="overwrite">Whether to overwrite an existing stream.</param>
        void CreateStream(string streamPath, bool overwrite, byte[] data, int byteCount);

        /// <summary>
        /// Deletes an existing stream at the given path.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="recurse">if set to <c>true</c> [recurse]. This is used for folder streams only.</param>
        void DeleteStream(string streamPath, bool recurse = false);

        /// <summary>
        /// Appends the given byte array to the end of a given stream.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="data">An array of bytes to be appended to the stream.</param>
        /// <param name="offset">The offset at which to append to the stream.</param>
        /// <param name="length">The number of bytes to append (starting at 0).</param>
        /// <exception cref="System.ArgumentNullException">If the data to be appended is null or empty.</exception>
        void AppendToStream(string streamPath, byte[] data, long offset, int length);
        
        /// <summary>
        /// Determines if the stream with given path exists.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <returns>True if the stream exists, false otherwise.</returns>
        bool StreamExists(string streamPath);

        /// <summary>
        /// Gets a value indicating the length of a stream, in bytes.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <returns>The length of the stream, in bytes.</returns>
        long GetStreamLength(string streamPath);

        /// <summary>
        /// Concatenates the given input streams (in order) into the given target stream.
        /// At the end of this operation, input streams will be deleted.
        /// </summary>
        /// <param name="targetStreamPath">The relative path to the target stream.</param>
        /// <param name="inputStreamPaths">An ordered array of paths to the input streams.</param>
        void Concatenate(string targetStreamPath, string[] inputStreamPaths);
    }
}
