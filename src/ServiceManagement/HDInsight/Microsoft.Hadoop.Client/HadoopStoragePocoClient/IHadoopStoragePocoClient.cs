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
namespace Microsoft.Hadoop.Client.HadoopStoragePocoClient
{
    using System.IO;
    using System.Threading.Tasks;

    internal interface IHadoopStoragePocoClient
    {
        /// <summary>
        ///     List the statuses of the files/directories in the given path if the path is a directory.
        /// </summary>
        /// <param name="path">Path to directory.</param>
        /// <returns>
        ///     The statuses of the files/directories in the given path returns null if path does not exist in the file system.
        /// </returns>
        Task<DirectoryListing> GetDirectoryStatusAsync(string path);

        /// <summary>
        ///     Return a file status data for the given path.
        /// </summary>
        /// <param name="path">The path we want information for.</param>
        /// <returns>File status for the given path.</returns>
        Task<DirectoryEntry> GetFileStatusAsync(string path);

        /// <summary>
        ///     Checks whether given path exists in the file system.
        /// </summary>
        /// <param name="path">Path to check.</param>
        /// <returns>True if the given path exists in the file system, otherwise false.</returns>
        Task<bool> ExistsAsync(string path);

        /// <summary>
        ///     Creates directory for the given path.
        /// </summary>
        /// <param name="path">Path to directory.</param>
        /// <returns>True if directory was successfully created, otherwise fasle.</returns>
        Task<bool> CreateDirectoryAsync(string path);

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
        Task<string> WriteAsync(Stream content, string path, bool? overwrite);

        /// <summary>
        ///     Appends the content of the input stream to the file.
        /// </summary>
        /// <param name="content">Stream containing data to be appended.</param>
        /// <param name="path">Path of the file.</param>
        /// <returns>Returns true if operation completed successfully.</returns>
        Task<bool> AppendAsync(Stream content, string path);

        /// <summary>
        ///     Opens data stream at indicated path.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <param name="offset">The starting byte position.</param>
        /// <param name="length">The number of bytes to be processed. Null means entire file.</param>
        /// <param name="buffersize">The size of the buffer to be used.</param>
        /// <returns>Stream of data.</returns>
        Task<Stream> ReadAsync(string path, int? offset, int? length, int? buffersize);

        /// <summary>
        ///     Deletes a file or directory at the given path.
        /// </summary>
        /// <param name="path">The path to delete.</param>
        /// <param name="recursive">If path is a directory and set to true, the directory is deleted else throws an exception.
        /// In case of a file the recursive can be set to either true or false.</param>
        /// <returns>True if delete is successful, otherwise false.</returns>
        Task<bool> DeleteAsync(string path, bool? recursive);

        /// <summary>
        ///     Renames file or directory at the given path.
        /// </summary>
        /// <param name="path">Source path.</param>
        /// <param name="newPath">Destination path.</param>
        /// <returns>True if rename is successful, otherwise false.</returns>
        Task<bool> RenameAsync(string path, string newPath);
    }
}
