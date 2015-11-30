// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client.Storage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a public interface for file abstraction.
    /// </summary>
    internal interface IStorageAbstraction
    {
        /// <summary>
        /// Determines if a file exists on the storage system.
        /// </summary>
        /// <param name="path">
        /// The Uri to the file.
        /// </param>
        /// <returns>
        /// A task object that can be awaited.  The result is true if the file exists, otherwise false.
        /// </returns>
        Task<bool> Exists(Uri path);

        /// <summary>
        /// Removes a file from the storage system.
        /// </summary>
        /// <param name="path">
        /// The Uri to the file.
        /// </param>
        void Delete(Uri path);

        /// <summary>
        /// Creates a WASB container.
        /// </summary>
        /// <param name="containerName">
        /// The name of the container.
        /// </param>
        /// <returns>
        /// A task object that can be awaited.
        /// </returns>
        Task CreateContainerIfNotExists(string containerName);

        /// <summary>
        /// Writes the content of a stream to a file on the storage system.
        /// </summary>
        /// <param name="path">
        /// The Uri to the file.
        /// </param>
        /// <param name="stream">
        /// A stream containing the content to place in the file.
        /// </param>
        /// <returns>
        /// A task object that can be awaited.
        /// </returns>
        Task Write(Uri path, Stream stream);

        /// <summary>
        /// Reads the content of a file on the storage system into a stream.
        /// </summary>
        /// <param name="path">
        /// The Uri to the file.
        /// </param>
        /// <returns>
        /// A task object that can be awaited.  The result is a stream containing the content of the file on the storage system.
        /// </returns>
        Task<Stream> Read(Uri path);

        /// <summary>
        /// Downloads the content of a file on the storage system into a local file.
        /// </summary>
        /// <param name="path">
        /// The Uri to the file.
        /// </param>
        /// <param name="localFileName">
        /// Full path of the local file.
        /// </param>
        /// <returns>
        /// A task object that can be awaited and downloads the content of a blob to a local file.
        /// </returns>
        Task DownloadToFile(Uri path, string localFileName);

        /// <summary>
        /// Lists the contents of a given path on the storage system.
        /// </summary>
        /// <param name="path">
        /// The Uri to the file.
        /// </param>
        /// <param name="recursive">
        /// A flag indicating if the traversal should be recursive.
        /// </param>
        /// <returns>
        /// A task object that can be awaited.  The result is the list of files located under the given path on the storage system.
        /// </returns>
        Task<IEnumerable<Uri>> List(Uri path, bool recursive);
    }
}
