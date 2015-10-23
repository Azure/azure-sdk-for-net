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

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.DataLake.StoreFileSystem;
using Microsoft.Azure.Management.DataLake.StoreFileSystem.Models;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// A front end adapter that communicates with the DataLake Store.
    /// This is a syncrhonous call adapter, which has certain efficiency limitations.
    /// In the future, new adapters that are created should consider implementing the methods
    /// asynchronously.
    /// </summary>
    public class DataLakeStoreFrontEndAdapter : IFrontEndAdapter
    {
        #region Private

        private readonly string _accountName;

        private readonly IDataLakeStoreFileSystemManagementClient _client;

        private readonly CancellationToken _token;

        private const int PerRequestTimeoutMs = 30000; // 30 seconds and we timeout the request

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeStoreFrontEndAdapter"/> class.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="client">The client.</param>
        public DataLakeStoreFrontEndAdapter(string accountName, IDataLakeStoreFileSystemManagementClient client) :
            this(accountName, client, CancellationToken.None)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLakeStoreFrontEndAdapter"/> class.
        /// </summary>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="client">The client.</param>
        /// <param name="token">The token.</param>
        public DataLakeStoreFrontEndAdapter(string accountName, IDataLakeStoreFileSystemManagementClient client, CancellationToken token)
        {
            _accountName = accountName;
            _client = client;
            _token = token;
        }

        #endregion

        #region IFrontEndAdapter implementation

        /// <summary>
        /// Creates a new, empty stream at the given path.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="overwrite">Whether to overwrite an existing stream.</param>
        /// <param name="data"></param>
        /// <param name="byteCount"></param>
        public void CreateStream(string streamPath, bool overwrite, byte[] data, int byteCount)
        {
            using (var toAppend = data != null ? new MemoryStream(data, 0, byteCount) : new MemoryStream())
            {
                var task =_client.FileSystem.DirectCreateAsync(streamPath, _accountName, toAppend,
                    new FileCreateParameters {Overwrite = overwrite}, _token);

                if (!task.Wait(PerRequestTimeoutMs))
                {
                    throw new TaskCanceledException(string.Format("Create stream operation did not complete after {0} milliseconds.", PerRequestTimeoutMs));
                }

                task.GetAwaiter().GetResult();
            }
        }

        /// <summary>
        /// Deletes an existing stream at the given path.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="recurse">if set to <c>true</c> [recurse]. This is used for folder streams only.</param>
        public void DeleteStream(string streamPath, bool recurse = false)
        {
            var task = _client.FileSystem.DeleteAsync(streamPath, _accountName, recurse, _token);
            if (!task.Wait(PerRequestTimeoutMs))
            {
                throw new TaskCanceledException(string.Format("Delete stream operation did not complete after {0} milliseconds.", PerRequestTimeoutMs));
            }

            task.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Appends to stream.
        /// </summary>
        /// <param name="streamPath">The stream path.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="byteCount">The byte count.</param>
        public void AppendToStream(string streamPath, byte[] data, long offset, int byteCount)
        {
            //adjust the buffer to the right size if necessary
            if (byteCount < data.Length)
            {
                var newBuffer = new byte[byteCount];
                Array.Copy(data, newBuffer, byteCount);
                data = newBuffer;
            }

            using (var stream = new MemoryStream(data, 0, byteCount))
            {
                var task = _client.FileSystem.DirectAppendAsync(streamPath, _accountName, stream, null, _token);
                
                if (!task.Wait(PerRequestTimeoutMs))
                {
                    throw new TaskCanceledException(string.Format("Append to stream operation did not complete after {0} milliseconds.", PerRequestTimeoutMs));
                }

                task.GetAwaiter().GetResult();
            }
        }

        /// <summary>
        /// Determines if the stream with given path exists.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <returns>
        /// True if the stream exists, false otherwise.
        /// </returns>
        public bool StreamExists(string streamPath)
        {
            try
            {
                var task = _client.FileSystem.GetFileStatusAsync(streamPath, _accountName, _token);
                if (!task.Wait(PerRequestTimeoutMs))
                {
                    throw new TaskCanceledException(
                        string.Format("Get file status operation did not complete after {0} milliseconds.",
                            PerRequestTimeoutMs));
                }

                task.GetAwaiter().GetResult();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count != 1) throw;

                var cloudEx = ex.InnerExceptions[0] as CloudException;
                if (cloudEx != null && cloudEx.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
            catch (CloudException cloudEx)
            {
                if(cloudEx.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }

            return true;
        }

        /// <summary>
        /// Gets a value indicating the length of a stream, in bytes.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <returns>
        /// The length of the stream, in bytes.
        /// </returns>
        public long GetStreamLength(string streamPath)
        {
            var task = _client.FileSystem.GetFileStatusAsync(streamPath, _accountName, _token);

            if (!task.Wait(PerRequestTimeoutMs))
            {
                throw new TaskCanceledException(
                    string.Format("Get file status operation did not complete after {0} milliseconds.",
                        PerRequestTimeoutMs));
            }

            var fileInfoResponse = task.Result;
            return fileInfoResponse.FileStatus.Length;
        }

        /// <summary>
        /// Concatenates the given input streams (in order) into the given target stream.
        /// At the end of this operation, input streams will be deleted.
        /// </summary>
        /// <param name="targetStreamPath">The relative path to the target stream.</param>
        /// <param name="inputStreamPaths">An ordered array of paths to the input streams.</param>
        public void Concatenate(string targetStreamPath, string[] inputStreamPaths)
        {
            // this is required for the current version of the microsoft concatenate
            // TODO: Improve WebHDFS concatenate to take in the list of paths to concatenate
            // in the request body.
            var paths = "sources=" + string.Join(",", inputStreamPaths);

            // For the current implementation, we require UTF8 encoding.
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(paths)))
            {
                var task = _client.FileSystem.MsConcatAsync(targetStreamPath, _accountName, stream, true, _token);

                if (!task.Wait(PerRequestTimeoutMs))
                {
                    throw new TaskCanceledException(
                        string.Format("Concatenate operation did not complete after {0} milliseconds.",
                            PerRequestTimeoutMs));
                }

                task.GetAwaiter().GetResult();
            }
        }

        #endregion
    }
}
