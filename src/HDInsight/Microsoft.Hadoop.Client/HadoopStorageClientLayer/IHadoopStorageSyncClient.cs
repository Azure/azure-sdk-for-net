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

namespace Microsoft.Hadoop.Client.HadoopStorageClientLayer
{
    using System.IO;

    /// <summary>
    ///     Represents a Hadoop storage client with synchronous operations.
    /// </summary>
    public interface IHadoopStorageSyncClient : IHadoopStorageClientBase
    {
        /// <summary>
        ///     Appends the content of the input stream to the file.
        /// </summary>
        /// <param name="content">Stream containing data to be appended.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>Returns true if operation completed successfully.</returns>
        bool Append(Stream content, string path);

        /// <summary>
        ///     Creates directory for the given path.
        /// </summary>
        /// <param name="path">Path to directory.</param>
        /// <returns>True if directory was successfully created, otherwise fasle.</returns>
        bool CreateDirectory(string path);

        /// <summary>
        ///     Deletes a file or directory at the given path.
        /// </summary>
        /// <param name="path">The path to delete.</param>
        /// <param name="recursive">
        ///     If path is a directory and set to true, the directory is deleted else throws an exception.
        ///     In case of a file the recursive can be set to either true or false.
        /// </param>
        /// <returns>True if delete is successful, otherwise false.</returns>
        bool Delete(string path, bool? recursive);

        /// <summary>
        ///     Deletes a file or directory at the given path. If directory is not empty exception will be thrown.
        /// </summary>
        /// <param name="path">The path to delete.</param>
        /// <returns>True if delete is successful, otherwise false.</returns>
        bool Delete(string path);

        /// <summary>
        ///     Checks whether given path exists in the file system.
        /// </summary>
        /// <param name="path">Path to check.</param>
        /// <returns>True if the given path exists in the file system, otherwise false.</returns>
        bool Exists(string path);

        /// <summary>
        ///     List the statuses of the files/directories in the given path if the path is a directory.
        /// </summary>
        /// <param name="path">Path to directory.</param>
        /// <returns>
        ///     The statuses of the files/directories in the given path returns null if path does not exist in the file system.
        /// </returns>
        DirectoryListing GetDirectoryStatus(string path);

        /// <summary>
        ///     Return a file status data for the given path.
        /// </summary>
        /// <param name="path">The path we want information for.</param>
        /// <returns>File status for the given path.</returns>
        DirectoryEntry GetFileStatus(string path);

        /// <summary>
        ///     Opens data stream at indicated path.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <param name="offset">The starting byte position.</param>
        /// <param name="length">The number of bytes to be processed. Null means entire file.</param>
        /// <param name="bufferSize">The size of the buffer to be used.</param>
        /// <returns>Stream of data.</returns>
        Stream Read(string path, int? offset, int? length, int? bufferSize);

        /// <summary>
        ///     Opens data stream at indicated path. Whole file will be read.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <returns>Stream of data.</returns>
        Stream Read(string path);

        /// <summary>
        ///     Opens data stream at indicated path. Starting offset can be set.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <param name="offset">The starting byte position.</param>
        /// <returns>Stream of data.</returns>
        Stream Read(string path, int? offset);

        /// <summary>
        ///     Opens data stream at indicated path. Starting offset and length of stream can be set.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <param name="offset">The starting byte position.</param>
        /// <param name="length">The number of bytes to be processed. Null means entire file.</param>
        /// <returns>Stream of data.</returns>
        Stream Read(string path, int? offset, int? length);

        /// <summary>
        ///     Renames file or directory at the given path.
        /// </summary>
        /// <param name="path">Source path.</param>
        /// <param name="newPath">Destination path.</param>
        /// <returns>True if rename is successful, otherwise false.</returns>
        bool Rename(string path, string newPath);

        /// <summary>
        ///     Writes the content of the input stream to a file on a file system.
        /// </summary>
        /// <param name="content">Stream containing data to be writen.</param>
        /// <param name="path">Path of the file.</param>
        /// <param name="overwrite">
        ///     If overwrite is set to true, the existing file will be overwritten.
        ///     If the file exists and overwrite is not set or it's set to false, an error will be thrown.
        /// </param>
        /// <returns>Path of the file created.</returns>
        string Write(Stream content, string path, bool? overwrite);

        /// <summary>
        ///     Writes the content of the input stream to a file on a file system. If file does not exists, exception will be thrown.
        /// </summary>
        /// <param name="content">Stream containing data to be writen.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>Path of the file created.</returns>
        string Write(Stream content, string path);
    }
}
