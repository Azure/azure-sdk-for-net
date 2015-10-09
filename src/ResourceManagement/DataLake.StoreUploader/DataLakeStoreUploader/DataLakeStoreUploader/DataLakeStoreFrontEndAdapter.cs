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
using System.Text;
using System.Threading;
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
            var response = _client.FileSystem.BeginCreateAsync(streamPath, _accountName, new FileCreateParameters { Overwrite = overwrite }, _token).Result;

            using (var toAppend = data != null ? new MemoryStream(data, 0, byteCount) : new MemoryStream())
            {
                _client.FileSystem.CreateAsync(response.Location, toAppend, _token).GetAwaiter().GetResult();
            }
        }

        /// <summary>
        /// Deletes an existing stream at the given path.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        public void DeleteStream(string streamPath)
        {
            _client.FileSystem.DeleteAsync(streamPath, _accountName, false, _token).GetAwaiter().GetResult();
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
                var response = _client.FileSystem.BeginAppendAsync(streamPath, _accountName, null, _token).Result;
                _client.FileSystem.AppendAsync(response.Location, stream, _token).GetAwaiter().GetResult();
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
                _client.FileSystem.GetFileStatusAsync(streamPath, _accountName, _token).GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                // TODO: implement logic to check for specific exceptions to return false
                return false;
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
            var fileInfoResponse = _client.FileSystem.GetFileStatusAsync(streamPath, _accountName, _token).Result;
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
                _client.FileSystem.MsConcatAsync(targetStreamPath, _accountName, stream, _token)
                    .GetAwaiter()
                    .GetResult();
            }
        }

        #endregion

    }
}
