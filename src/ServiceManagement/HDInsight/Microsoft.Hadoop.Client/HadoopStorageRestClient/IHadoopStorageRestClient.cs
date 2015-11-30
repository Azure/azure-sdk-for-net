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
namespace Microsoft.Hadoop.Client.HadoopStorageRestClient
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    internal interface IHadoopStorageRestClient
    {
        /// <summary>
        ///     List the statuses of the files/directories in the given path if the path is a directory.
        /// </summary>
        /// <param name="path">Path to directory.</param>
        /// <returns>
        ///     The statuses of the files/directories in the given path returns null if path does not exist in the file system.
        /// </returns>
        Task<IHttpResponseMessageAbstraction> ListStatus(string path);

        /// <summary>
        ///     Return a file status data above given path.
        /// </summary>
        /// <param name="path">The path we want information from.</param>
        /// <returns>File status for given path.</returns>
        Task<IHttpResponseMessageAbstraction> GetFileStatus(string path);

        /// <summary>
        ///     Checks whether given path exists in the file system.
        /// </summary>
        /// <param name="path">Path to check.</param>
        /// <returns>True if the given path exists in the file system, otherwise false.</returns>
        Task<IHttpResponseMessageAbstraction> Exists(string path);

        /// <summary>
        ///     Make the given directory and all non-existent parents into directories.
        ///     Existence of the directory hierarchy is not an error.
        /// </summary>
        /// <param name="path">Path to directory.</param>
        /// <returns>Confirmation message with success indicator flag.</returns>
        Task<IHttpResponseMessageAbstraction> CreateDirectory(string path);

        /// <summary>
        ///     Writes the content of the input stream to a file on a file system.
        /// </summary>
        /// <param name="path">The file name to create and open.</param>
        /// <param name="data">The Stream of data.</param>
        /// <param name="overwrite">Specifies if existing file should be overwritten.</param>
        /// <returns>Confirmation message and URI to file location.</returns>
        Task<IHttpResponseMessageAbstraction> Write(string path, Stream data, bool? overwrite);

        /// <summary>
        ///     Writes the content of the input stream to a file on a file system.
        /// </summary>
        /// <param name="path">The file name to create and open.</param>
        /// <param name="data">The Stream of data.</param>
        /// <returns>Confirmation message and URI to file location.</returns>
        Task<IHttpResponseMessageAbstraction> Write(string path, Stream data);

        /// <summary>
        ///     Append to an existing file.
        /// </summary>
        /// <param name="path">The existing file to be appended.</param>
        /// <param name="data">The Stream of data.</param>
        /// <returns>Confirmation message.</returns>
        Task<IHttpResponseMessageAbstraction> Append(string path, Stream data);

        /// <summary>
        ///     Opens data stream at indicated path.
        /// </summary>
        /// <param name="path">File name to open.</param>
        /// <param name="offset">The starting byte position.</param>
        /// <param name="length">The number of bytes to be processed. Null means entire file.</param>
        /// <param name="buffersize">The size of the buffer to be used.</param>
        /// <returns>Redirected exact location of chosen file.</returns>
        Task<IHttpResponseMessageAbstraction> Read(string path, long? offset, long? length, int? buffersize);

        /// <summary>
        ///     Delete file.
        /// </summary>
        /// <param name="path">The path to delete.</param>
        /// <param name="recursive">
        ///     If path is a directory and set to true, the directory is deleted else throws an exception. In
        ///     case of a file the recursive can be set to either true or false.
        /// </param>
        /// <returns>Confirmation message with 'true' in message content if delete is successful, else 'false'.</returns>
        Task<IHttpResponseMessageAbstraction> Delete(string path, bool? recursive);

        /// <summary>
        ///     Rename file.
        /// </summary>
        /// <param name="path">Source path.</param>
        /// <param name="destination">Destination path.</param>
        /// <returns>Confirmation message with success indicator flag.</returns>
        Task<IHttpResponseMessageAbstraction> Rename(string path, string destination);
    }
}
