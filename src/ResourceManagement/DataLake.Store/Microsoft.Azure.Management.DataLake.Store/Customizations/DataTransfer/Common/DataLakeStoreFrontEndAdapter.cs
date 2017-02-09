// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.DataLake.Store;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.DataLake.Store.Models;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Rest;

namespace Microsoft.Azure.Management.DataLake.Store
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

        private const int PerRequestTimeoutMs = 60000; // 60 seconds and we timeout the request

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
        /// <param name="data">The data.</param>
        /// <param name="byteCount">The byte count.</param>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public void CreateStream(string streamPath, bool overwrite, byte[] data, int byteCount)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            using (var toAppend = data != null ? new MemoryStream(data, 0, byteCount) : new MemoryStream())
            {
                var task = _client.FileSystem.CreateAsync(_accountName, streamPath, toAppend, overwrite: overwrite, cancellationToken: _token);

                if (!task.Wait(PerRequestTimeoutMs))
                {
                    var ex = new TaskCanceledException(string.Format("Create stream operation did not complete after {0} milliseconds.", PerRequestTimeoutMs));
                    TracingHelper.LogError(ex);
                    throw ex;
                }

                task.GetAwaiter().GetResult();
            }
            stopWatch.Stop();
            TracingHelper.LogInfo("Op:CREATE,Path:{0},Overwrite:{1},TimeMs:{2}", streamPath, overwrite, stopWatch.ElapsedMilliseconds);
            
        }

        /// <summary>
        /// Deletes an existing stream at the given path.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="recurse">if set to <c>true</c> [recurse]. This is used for folder streams only.</param>
        /// <param name="isDownload">if set to <c>true</c> [is download], meaning we will delete a stream on the local machine instead of on the server.</param>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public void DeleteStream(string streamPath, bool recurse = false, bool isDownload = false)
        {
            if (isDownload)
            {
                if (Directory.Exists(streamPath))
                {
                    Directory.Delete(streamPath, recurse);
                }
                else if (File.Exists(streamPath))
                {
                    File.Delete(streamPath);
                }
            }
            else
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var task = _client.FileSystem.DeleteAsync(_accountName, streamPath, recurse, cancellationToken: _token);
                if (!task.Wait(PerRequestTimeoutMs))
                {
                    var ex = new TaskCanceledException(string.Format("Delete stream operation did not complete after {0} milliseconds.", PerRequestTimeoutMs));
                    TracingHelper.LogError(ex);

                    throw ex;
                }

                task.GetAwaiter().GetResult();
                stopWatch.Stop();
                TracingHelper.LogInfo("Op:DELETE,Path:{0},recurse:{1},TimeMs:{2}", streamPath, recurse, stopWatch.ElapsedMilliseconds);
            }
        }

        /// <summary>
        /// Appends to stream.
        /// </summary>
        /// <param name="streamPath">The stream path.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="byteCount">The byte count.</param>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public void AppendToStream(string streamPath, byte[] data, long offset, int byteCount)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            using (var stream = new MemoryStream(data, 0, byteCount))
            {
                var task = _client.FileSystem.AppendAsync(_accountName, streamPath, stream, offset, cancellationToken: _token);

                if (!task.Wait(PerRequestTimeoutMs))
                {
                    var ex = new TaskCanceledException(string.Format("Append to stream operation did not complete after {0} milliseconds.", PerRequestTimeoutMs));
                    TracingHelper.LogError(ex);

                    throw ex;
                }

                task.GetAwaiter().GetResult();
            }
            stopWatch.Stop();
            TracingHelper.LogInfo("Op:APPEND,Path:{0},offset:{1},TimeMs:{2}", streamPath, offset, stopWatch.ElapsedMilliseconds);
        }

        public Stream ReadStream(string streamPath, long offset, long length, bool isDownload = false)
        {
            if (isDownload)
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var task = _client.FileSystem.OpenWithHttpMessagesAsync(_accountName, streamPath, length, offset, cancellationToken: _token);

                if (!task.Wait(PerRequestTimeoutMs))
                {
                    var ex = new TaskCanceledException(string.Format("Reading stream operation did not complete after {0} milliseconds. TraceId: {1}", PerRequestTimeoutMs, task.Result.RequestId));
                    TracingHelper.LogError(ex);

                    throw ex;
                }

                Stream toReturn = task.GetAwaiter().GetResult().Body;
                stopWatch.Stop();
                TracingHelper.LogInfo("Op:READ,Path:{0},offset:{1},length:{2},TimeMs:{3}", streamPath, offset, length, stopWatch.ElapsedMilliseconds);

                return toReturn;
            }
            else
            {
                // note that length is not used here since we will automatically stop reading once we reach the end of the stream.
                var stream = new FileStream(streamPath, FileMode.Open, FileAccess.Read, FileShare.Read);

                if (offset >= stream.Length)
                {
                    var ex = new ArgumentException("StartOffset is beyond the end of the input file", "StartOffset");
                    TracingHelper.LogError(ex);

                    throw ex;
                }

                stream.Seek(offset, SeekOrigin.Begin);
                return stream;
            }
        }

        /// <summary>
        /// Determines if the stream with given path exists.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="isDownload">if set to <c>true</c> [is download], meaning we will test if the stream exists on the local machine instead of on the server.</param>
        /// <returns>
        /// True if the stream exists, false otherwise.
        /// </returns>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public bool StreamExists(string streamPath, bool isDownload = false)
        {
            if (isDownload)
            {
                return File.Exists(streamPath) || Directory.Exists(streamPath);
            }
            else
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                try
                {
                    var task = _client.FileSystem.GetFileStatusAsync(_accountName, streamPath, cancellationToken: _token);
                    if (!task.Wait(PerRequestTimeoutMs))
                    {
                        var ex = new TaskCanceledException(
                            string.Format("Get file status operation did not complete after {0} milliseconds.",
                                PerRequestTimeoutMs));
                        TracingHelper.LogError(ex);

                        throw ex;
                    }

                    task.GetAwaiter().GetResult();
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerExceptions.Count != 1)
                    {
                        TracingHelper.LogError(ex);

                        throw ex;
                    }

                    var cloudEx = ex.InnerExceptions[0] as AdlsErrorException;
                    if (cloudEx != null && (cloudEx.Response.StatusCode == HttpStatusCode.NotFound || cloudEx.Body.RemoteException is AdlsFileNotFoundException))
                    {
                        return false;
                    }

                    TracingHelper.LogError(ex);

                    throw ex;
                }
                catch (AdlsErrorException cloudEx)
                {
                    if (cloudEx.Response.StatusCode == HttpStatusCode.NotFound || cloudEx.Body.RemoteException is AdlsFileNotFoundException)
                    {
                        return false;
                    }

                    TracingHelper.LogError(cloudEx);

                    throw cloudEx;
                }
                finally
                {
                    stopWatch.Stop();
                    TracingHelper.LogInfo("Op:GETFILESTATUS,Path:{0},TestStream,TimeMs:{1}", streamPath, stopWatch.ElapsedMilliseconds);
                }

                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating the length of a stream, in bytes.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <param name="isDownload">if set to <c>true</c> [is download], meaning we will get the stream length on the local machine instead of on the server.</param>
        /// <returns>
        /// The length of the stream, in bytes.
        /// </returns>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public long GetStreamLength(string streamPath, bool isDownload = false)
        {
            if (isDownload)
            {
                return new FileInfo(streamPath).Length;
            }
            else
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var task = _client.FileSystem.GetFileStatusAsync(_accountName, streamPath, cancellationToken: _token);

                if (!task.Wait(PerRequestTimeoutMs))
                {
                    var ex = new TaskCanceledException(
                        string.Format("Get file status operation did not complete after {0} milliseconds.",
                            PerRequestTimeoutMs));

                    TracingHelper.LogError(ex);

                    throw ex;
                }

                var fileInfoResponse = task.Result;
                stopWatch.Stop();
                TracingHelper.LogInfo("Op:GETFILESTATUS,Path:{0},GetLength,TimeMs:{1}", streamPath, stopWatch.ElapsedMilliseconds);

                return (long)fileInfoResponse.FileStatus.Length;
            }
        }

        /// <summary>
        /// Determines if the stream with given path on the server is a directory or a terminating file.
        /// This is used exclusively for download.
        /// </summary>
        /// <param name="streamPath">The relative path to the stream.</param>
        /// <returns>
        /// True if the stream is a directory, false otherwise.
        /// </returns>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public bool IsDirectory(string streamPath)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var task = _client.FileSystem.GetFileStatusAsync(_accountName, streamPath, cancellationToken: _token);

            if (!task.Wait(PerRequestTimeoutMs))
            {
                var ex = new TaskCanceledException(
                    string.Format("Get file status operation did not complete after {0} milliseconds.",
                        PerRequestTimeoutMs));

                TracingHelper.LogError(ex);

                throw ex;
            }

            var fileInfoResponse = task.Result;
            stopWatch.Stop();
            TracingHelper.LogInfo("Op:GETFILESTATUS,Path:{0},IsDirectory,TimeMs:{1}", streamPath, stopWatch.ElapsedMilliseconds);

            return fileInfoResponse.FileStatus.Type.GetValueOrDefault() == FileType.DIRECTORY;
        }

        /// <summary>
        /// Lists the Data Lake Store directory specified.
        /// </summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns>
        /// The list of string paths and their corresponding file sizes, in bytes.
        /// </returns>
        public IDictionary<string, long> ListDirectory(string directoryPath, bool recursive)
        {
            Dictionary<string, long> toReturn = new Dictionary<string, long>();
            var files = _client.FileSystem.ListFileStatus(_accountName, directoryPath).FileStatuses.FileStatus;
            foreach (var file in files)
            {
                if (file.Type == FileType.FILE)
                {
                    toReturn.Add(string.Format("{0}/{1}", directoryPath, file.PathSuffix), file.Length.GetValueOrDefault());
                }
                else if (recursive)
                {
                    foreach (var entry in ListDirectory(string.Format("{0}/{1}", directoryPath, file.PathSuffix), true))
                    {
                        toReturn.Add(entry.Key, entry.Value);
                    }
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Concatenates the given input streams (in order) into the given target stream.
        /// At the end of this operation, input streams will be deleted.
        /// </summary>
        /// <param name="targetStreamPath">The relative path to the target stream.</param>
        /// <param name="inputStreamPaths">An ordered array of paths to the input streams.</param>
        /// <param name="isDownload">if set to <c>true</c> [is download], meaning we will concatenate the streams on the local machine instead of on the server.</param>
        /// <exception cref="System.Threading.Tasks.TaskCanceledException"></exception>
        public void Concatenate(string targetStreamPath, string[] inputStreamPaths, bool isDownload = false)
        {
            if (isDownload)
            {
                if (inputStreamPaths.Length != 2)
                {
                    var ex = new InvalidOperationException(string.Format("Invalid list of stream paths for download finalization. Expected Paths: 2. Actual paths: {0}", inputStreamPaths.Length));
                    TracingHelper.LogError(ex);

                    throw ex;
                }

                File.Move(inputStreamPaths[0], inputStreamPaths[1]);
            }
            else
            {
                // this is required for the current version of the microsoft concatenate
                // TODO: Improve WebHDFS concatenate to take in the list of paths to concatenate
                // in the request body.
                var paths = "sources=" + string.Join(",", inputStreamPaths);

                var stopWatch = new Stopwatch();
                stopWatch.Start();
                // For the current implementation, we require UTF8 encoding.
                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(paths)))
                {
                    var task = _client.FileSystem.MsConcatAsync(_accountName, targetStreamPath, stream, true, cancellationToken: _token);

                    if (!task.Wait(PerRequestTimeoutMs))
                    {
                        var ex = new TaskCanceledException(
                            string.Format("Concatenate operation did not complete after {0} milliseconds.",
                                PerRequestTimeoutMs));

                        TracingHelper.LogError(ex);

                        throw ex;
                    }

                    task.GetAwaiter().GetResult();
                    stopWatch.Stop();
                    TracingHelper.LogInfo("Op:MSCONCAT,Path:{0},NumberOfStreams:{1},TimeMs:{2}", targetStreamPath, inputStreamPaths.Length, stopWatch.ElapsedMilliseconds);
                }
            }
        }

        #endregion
    }
}
