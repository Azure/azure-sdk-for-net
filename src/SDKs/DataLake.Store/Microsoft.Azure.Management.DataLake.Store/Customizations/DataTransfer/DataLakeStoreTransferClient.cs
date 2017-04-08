// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Represents a delegate that is called in the event of a thread transfering a file terminating unexpectedly.
    /// </summary>
    public delegate void FileTransferThreadFailProgressUpdate(TransferMetadata failedFile);

    /// <summary>
    /// Represents a general purpose file transfer client into a Data Lake Store. Supports the efficient transfer of large files.
    /// </summary>
    public sealed class DataLakeStoreTransferClient
    {

        #region Private

        /// <summary>
        /// The maximum number of parallel threads to allow. 
        /// </summary>
        public const int MaxAllowedThreadsPerFile = 1024;
        internal const int DefaultMaxPerFileThreadCount = 75;
        internal const int DefaultIdealConcurrentFileCount = 25;
        internal const int DefaultIdealPerFileThreadCountForFolders = 100;
        private readonly IFrontEndAdapter _frontEnd;
        private readonly IProgress<TransferProgress> _progressTracker;
        private readonly IProgress<TransferFolderProgress> _folderProgressTracker;
        private readonly string _metadataFilePath;
        private readonly CancellationToken _token;
        private bool isDirectory = false;

#if !PORTABLE
        private int _previousDefaultConnectionLimit;
#endif

#endregion

        // this is used to ensure that all threads, including tracking threads, ultimately terminate.
        internal static ConcurrentQueue<TransferMetadata> AllFiles { get; private set; }

        internal static List<Thread> ExecutionThreads { get; private set; }

        /// <summary>
        ///  An event that is registered to progress tracking to ensure that, in the event of an unexpected transfer failure,
        ///  progress is properly updated.
        /// </summary>
        public event FileTransferThreadFailProgressUpdate OnFileTransferThreadFailProgressUpdate;

        #region Constructor

        /// <summary>
        /// Creates a new instance of the DataLakeStoreTransferClient class, by specifying a pointer to the FrontEnd to use for the transfer.
        /// </summary>
        /// <param name="transferParameters">The transfer parameters to use.</param>
        /// <param name="frontEnd">A pointer to the FrontEnd interface to use for the transfer.</param>
        /// <param name="progressTracker">(Optional) A tracker that reports progress on the transfer.</param>
        /// <param name="folderProgressTracker">(Optional) The folder progress tracker.</param>
        public DataLakeStoreTransferClient(
            TransferParameters transferParameters,
            IFrontEndAdapter frontEnd,
            IProgress<TransferProgress> progressTracker = null,
            IProgress<TransferFolderProgress> folderProgressTracker = null) :
            this(transferParameters, frontEnd, CancellationToken.None, progressTracker, folderProgressTracker)
        {
            
        }

        /// <summary>
        /// Creates a new instance of the DataLakeStoreTransferClient class, by specifying a pointer to the FrontEnd to use for the transfer.
        /// </summary>
        /// <param name="transferParameters">The transfer Parameters to use.</param>
        /// <param name="frontEnd">A pointer to the FrontEnd interface to use for the transfer.</param>
        /// <param name="token">The token.</param>
        /// <param name="progressTracker">(Optional) A tracker that reports progress on the transfer.</param>
        /// <param name="folderProgressTracker">(Optional) The folder progress tracker.</param>
        public DataLakeStoreTransferClient(
            TransferParameters transferParameters,
            IFrontEndAdapter frontEnd,
            CancellationToken token,
            IProgress<TransferProgress> progressTracker = null,
            IProgress<TransferFolderProgress> folderProgressTracker = null)
        {
            this.Parameters = transferParameters;
            _frontEnd = frontEnd;

            //we need to override the default .NET value for max connections to a host to our number of threads, if necessary (otherwise we won't achieve the parallelism we want)
#if !PORTABLE
            _previousDefaultConnectionLimit = ServicePointManager.DefaultConnectionLimit;
            ServicePointManager.DefaultConnectionLimit = Math.Max((this.Parameters.PerFileThreadCount * this.Parameters.ConcurrentFileCount) + this.Parameters.ConcurrentFileCount,
                ServicePointManager.DefaultConnectionLimit);
#endif
            //ensure that input parameters are correct
            ValidateParameters();

            _metadataFilePath = GetCanonicalMetadataFilePath();
            _progressTracker = progressTracker;
            _folderProgressTracker = folderProgressTracker;
            _token = token;
        }

        /// <summary>
        /// Gets the canonical metadata file path.
        /// </summary>
        /// <returns></returns>
        private string GetCanonicalMetadataFilePath()
        {
            return Path.Combine(this.Parameters.LocalMetadataLocation, string.Format("{0}.transfer.xml", Path.GetFileName(this.Parameters.InputFilePath)));
        }

        #endregion

        #region Invocation

        /// <summary>
        /// Gets the parameters to use for this transfer.
        /// </summary>
        public TransferParameters Parameters { get; private set; }

        /// <summary>
        /// Executes the transfer as defined by the input parameters.
        /// </summary>
        public void Execute()
        {
            try
            {
                // check if we are transfering a file or a directory
                if (!isDirectory)
                {
                    //load up existing metadata or create a fresh one
                    var metadata = GetMetadata();

                    //match up the metadata with the information on the server
                    if (this.Parameters.IsResume)
                    {
                        ValidateMetadataForResume(metadata);
                    }
                    else
                    {
                        ValidateMetadataForFreshTransfer(metadata);
                    }

                    // set thread counts if defaults are desired.
                    if(this.Parameters.PerFileThreadCount <= 0)
                    {
                        this.Parameters.PerFileThreadCount = GetDefaultPerFileThreadCount(
                            metadata.FileLength, 
                            this.Parameters.MaxSegementLength);
                    }

                    // optimize thread count based on file size
                    if (metadata.SegmentCount < this.Parameters.PerFileThreadCount)
                    {
                        this.Parameters.PerFileThreadCount = metadata.SegmentCount;
                    }

                    ServiceClientTracing.Information("Single file thread count validated and optimized to: {0}", this.Parameters.PerFileThreadCount);
                    
                    //begin (or resume) uploading/downloading the file
                    if(this.Parameters.IsDownload)
                    {
                        DownloadFile(metadata);
                    }
                    else
                    {
                        UploadFile(metadata);
                    }

                    //clean up metadata after a successful transfer
                    metadata.DeleteFile();
                }
                else
                {
                    var metadata = GetFolderMetadata();
                    
                    //match up the metadata with the information on the server
                    if (this.Parameters.IsResume)
                    {
                        ValidateFolderMetadataForResume(metadata);
                    }
                    else
                    {
                        ValidateFolderMetadataForFreshTransfer(metadata);
                    }
                    
                    // set defaults for number of files and per file thread count
                    
                    int tempConcurrentFileCount;

                    int tempPerFileThreadCount = GetDefaultPerFileThreadCountForFolder(
                        metadata.TotalFileBytes,
                        metadata.FileCount,
                        this.Parameters.MaxSegementLength,
                        out tempConcurrentFileCount);

                    this.Parameters.ConcurrentFileCount = tempConcurrentFileCount;

                    if (this.Parameters.PerFileThreadCount <= 0)
                    {
                        this.Parameters.PerFileThreadCount = tempPerFileThreadCount;
                    }

                    if (this.Parameters.ConcurrentFileCount > metadata.FileCount)
                    {
                        this.Parameters.ConcurrentFileCount = metadata.FileCount;
                    }

                    ServiceClientTracing.Information("Single file thread count validated and optimized to: {0}", this.Parameters.PerFileThreadCount);
                    ServiceClientTracing.Information("Concurrent file count validated and optimized to: {0}", this.Parameters.ConcurrentFileCount);

                    try
                    {
                        Thread progressThread;
                        var fileProgressTracker = CreateFileProgressTracker(metadata, out progressThread);
                        var exceptions = new ConcurrentQueue<Exception>();
                        AllFiles = new ConcurrentQueue<TransferMetadata>(metadata.Files);
                        int threadCount = Math.Min(AllFiles.Count, this.Parameters.ConcurrentFileCount);

                        ExecutionThreads = new List<Thread>(threadCount);

                        if (progressThread != null)
                        {
                            progressThread.Start();
                        }

                        // break up the batch save into 100 even chunks. This is most important for very large directories
                        var filesPerSave = (int)Math.Ceiling((double)metadata.FileCount / 100);
                        //start a bunch of new threads that pull from the file list and then wait for them to finish
                        int filesCompleted = 0;
                        for (int i = 0; i < threadCount; i++)
                        {
                            var t = new Thread(() => {
                                TransferMetadata file;
                                while (AllFiles.TryDequeue(out file))
                                {
                                    try
                                    {
                                        _token.ThrowIfCancellationRequested();
                                        // only initiate transfers for files that are not already complete
                                        if (file.Status != SegmentTransferStatus.Complete)
                                        {
                                            var segmentProgressTracker = CreateSegmentProgressTracker(file, fileProgressTracker);
                                            if (this.Parameters.IsDownload)
                                            {
                                                DownloadFile(file, segmentProgressTracker);
                                            }
                                            else
                                            {
                                                UploadFile(file, segmentProgressTracker);
                                            }
                                        }
                                    }
                                    catch (OperationCanceledException ex)
                                    {
                                        // Add to the queue and re-throw so that we immediately abort
                                        exceptions.Enqueue(ex);

                                        // on cancel definitely try to save the metadata
                                        try
                                        {
                                            // replace the file in the list with the one that we have been modifying
                                            foreach (var item in metadata.Files.Where(f => f.TransferId.Equals(file.TransferId)))
                                            {
                                                item.Status = file.Status;
                                                item.Segments = file.Segments;
                                            }

                                            metadata.Save();
                                        }
                                        catch { } // if we can't save the metadata we shouldn't fail out. 
                                        // break out of the loop since the operation is cancelled.
                                        break;
                                    }
                                    catch (Exception ex)
                                    {
                                        // for all other exceptions just enqueue and continue.
                                        exceptions.Enqueue(ex);
                                        // in this case we should save since something bad happened, but only if we aren't going to save anyway in the finally.
                                        if (filesCompleted % filesPerSave != 0)
                                        {
                                            try
                                            {
                                                // replace the file in the list with the one that we have been modifying

                                                foreach (var item in metadata.Files.Where(f => f.TransferId.Equals(file.TransferId)))
                                                {
                                                    item.Status = file.Status;
                                                    item.Segments = file.Segments;
                                                }

                                                metadata.Save();
                                            }
                                            catch { } // if we can't save the metadata we shouldn't fail out. 
                                        }

                                        // indicate we failed to tracking thread.
                                        if(this.OnFileTransferThreadFailProgressUpdate != null)
                                        {
                                            this.OnFileTransferThreadFailProgressUpdate(file);
                                        }
                                    }
                                    finally
                                    {
                                        // increment the files that we have made it through (even if they have failed).
                                        // this ensures that we will periodically save the metadata
                                        Interlocked.Increment(ref filesCompleted);
                                        try
                                        {
                                            foreach (var item in metadata.Files.Where(f => f.TransferId.Equals(file.TransferId)))
                                            {
                                                item.Status = file.Status;
                                                item.Segments = file.Segments;
                                            }

                                            // delete the temp metadata created if it exists.
                                            file.DeleteFile();
                                            file = null;

                                            // after each iteration for each file, check to see if state should be saved.
                                            if (filesCompleted % filesPerSave == 0)
                                            {
                                                try
                                                {
                                                    metadata.Save();
                                                }
                                                catch { } // if we can't save the metadata we shouldn't fail out. 
                                            }
                                        }
                                        catch { } // if we can't delete a temp file we shouldn't fail out.
                                    }
                                }
                            });
                            t.Start();
                            ExecutionThreads.Add(t);
                        }

                        foreach (var t in ExecutionThreads)
                        {
                            t.Join();
                        }

                        if (progressThread != null && !progressThread.Join(2000)) // give the thread another 2 seconds to terminate.
                        {
                            TracingHelper.LogInfo("The progress tracking thread did not terminate on its own after all other threads terminated. Progress tracking for this run may not be completely accurate but execution will complete.");
                        }

                        if (exceptions.Count > 0)
                        {
                            var ex = new AggregateException(exceptions);
                            TracingHelper.LogError(ex);
                            throw ex;
                        }

                        metadata.DeleteFile();
                    }
                    catch (OperationCanceledException)
                    {
                        // do not rethrow in this case.
                        try
                        {
                            // if anything went wrong, make sure that we attempt to save the current state of the folder metadata
                            metadata.Save();
                        }
                        catch { } // saving the metadata is a best effort, we will not fail out for this reason and we want to ensure the root exception is preserved.
                    }
                    catch (AggregateException ex)
                    {
                        try
                        {
                            // if anything went wrong, make sure that we attempt to save the current state of the folder metadata
                            metadata.Save();
                        }
                        catch { } // saving the metadata is a best effort, we will not fail out for this reason and we want to ensure the root exception is preserved.

                        if (!ex.InnerExceptions.OfType<OperationCanceledException>().Any())
                        {
                            TracingHelper.LogError(ex);

                            throw;
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            // if anything went wrong, make sure that we attempt to save the current state of the folder metadata
                            metadata.Save();
                        }
                        catch { } // saving the metadata is a best effort, we will not fail out for this reason and we want to ensure the root exception is preserved.
                        TracingHelper.LogError(ex);

                        throw;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // do not throw this higher, since we have cancelled out.
            }
            finally
            {
#if !PORTABLE
                //revert back the default .NET value for max connections to a host to whatever it was before
                ServicePointManager.DefaultConnectionLimit = _previousDefaultConnectionLimit;
#endif
            }
        }

        /// <summary>
        /// Validates the parameters.
        /// </summary>
        /// <exception cref="System.IO.FileNotFoundException">Could not find input file</exception>
        /// <exception cref="System.ArgumentNullException">
        /// TargetStreamPath;Null or empty Target Stream Path
        /// or
        /// AccountName;Null or empty Account Name
        /// </exception>
        /// <exception cref="System.ArgumentException">Invalid TargetStreamPath, a stream path should not end with /</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ThreadCount</exception>
        private void ValidateParameters()
        {
            if ((!this.Parameters.IsDownload && !File.Exists(this.Parameters.InputFilePath) && !Directory.Exists(this.Parameters.InputFilePath)) || (this.Parameters.IsDownload && !_frontEnd.StreamExists(this.Parameters.InputFilePath)))
            {
                var ex = new FileNotFoundException(string.Format("Could not find {0} input file or folder", this.Parameters.IsDownload ? "Data Lake stream" : "local"), this.Parameters.InputFilePath);

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (string.IsNullOrWhiteSpace(this.Parameters.TargetStreamPath))
            {
                var ex = new ArgumentNullException("TargetStreamPath", "Null or empty Target Stream Path");

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (this.Parameters.TargetStreamPath.EndsWith("/"))
            {
                var ex = new ArgumentException("Invalid TargetStreamPath, a stream path should not end with /");

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (string.IsNullOrWhiteSpace(this.Parameters.AccountName))
            {
                var ex = new ArgumentNullException("AccountName", "Null or empty Account Name");

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (this.Parameters.PerFileThreadCount > MaxAllowedThreadsPerFile)
            {
                var ex = new ArgumentOutOfRangeException("PerFileThreadCount", string.Format("PerFileThreadCount must be less than {0}", MaxAllowedThreadsPerFile));

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (this.Parameters.ConcurrentFileCount > MaxAllowedThreadsPerFile)
            {
                var ex = new ArgumentOutOfRangeException("ConcurrentFileCount", string.Format("ConcurrentFileCount must be less than {0}", MaxAllowedThreadsPerFile));

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (this.Parameters.MaxSegementLength < 1)
            {
                var ex = new ArgumentOutOfRangeException("MaxSegmentLength", string.Format("MaxSegmentLength must be greater than 0 bytes. Value passed in: {0}", this.Parameters.MaxSegementLength));
                TracingHelper.LogError(ex);

                throw ex;
            }

            // if the input is a directory, set it
            isDirectory = this.Parameters.IsDownload? _frontEnd.IsDirectory(this.Parameters.InputFilePath) : Directory.Exists(this.Parameters.InputFilePath);
            
        }

        #endregion

        #region Metadata Operations

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <returns></returns>
        private TransferFolderMetadata GetFolderMetadata()
        {
            var metadataGenerator = new TransferFolderMetadataGenerator(this.Parameters, _frontEnd);
            if (this.Parameters.IsResume)
            {
                return metadataGenerator.GetExistingMetadata(_metadataFilePath);
            }
            else
            {
                return metadataGenerator.CreateNewMetadata(_metadataFilePath);
            }
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <returns></returns>
        private TransferMetadata GetMetadata()
        {
            var metadataGenerator = new TransferMetadataGenerator(this.Parameters, _frontEnd);
            if (this.Parameters.IsResume)
            {
                return metadataGenerator.GetExistingMetadata(_metadataFilePath);
            }
            else
            {
                return metadataGenerator.CreateNewMetadata(_metadataFilePath);
            }
        }

        private int GetDefaultPerFileThreadCount(long fileLength, long maxSegmentLength)
        {
            if (maxSegmentLength < 1)
            {
                var ex = new ArgumentOutOfRangeException("maxSegmentLength", string.Format("maxSegmentLength must be greater than 0 bytes. Value passed in: {0}", maxSegmentLength));
                TracingHelper.LogError(ex);

                throw ex;
            }

            return (int)Math.Min(Math.Ceiling((double)fileLength / maxSegmentLength), DefaultMaxPerFileThreadCount);
        }

        private int GetDefaultPerFileThreadCountForFolder(long folderSize, long fileCount, long maxSegmentLength, out int concurrentFileCount)
        {
            if (fileCount < 1)
            {
                // this case should never happen, but if it does we should throw
                var ex = new ArgumentOutOfRangeException("fileCount", string.Format("fileCount must be greater than 0 for a transfer operation. Number of files: {0}", fileCount));
                TracingHelper.LogError(ex);

                throw ex;
            }

            if (this.Parameters.ConcurrentFileCount > 0)
            {
                concurrentFileCount = this.Parameters.ConcurrentFileCount;
            }
            else
            {
                concurrentFileCount = DefaultIdealConcurrentFileCount;
            }

            long avgFileSize = folderSize / fileCount;

            int perFileThreadCountToUse = GetDefaultPerFileThreadCount(avgFileSize, maxSegmentLength);
            int idealPerFileThreadCount = (int)Math.Ceiling((double)DefaultIdealConcurrentFileCount / concurrentFileCount);


            if (perFileThreadCountToUse > idealPerFileThreadCount)
            {
                perFileThreadCountToUse = idealPerFileThreadCount;
            }
            else if(this.Parameters.ConcurrentFileCount <= 0)
            {
                // Ideally 25 files transfering at once with four threads is good, However if possible we can increase this
                // if the ideal average number of threads is low ( < 4).
                // this is only true in the case where the caller did not specify a folder thread count.
                concurrentFileCount = (int)Math.Ceiling((double)DefaultIdealPerFileThreadCountForFolders / perFileThreadCountToUse);
            }
            else
            {
                // here we can increase the number of threads per file
                // opportunistically, since it really just increases 
                // the max number of threads for a given file.
                perFileThreadCountToUse = (int)Math.Ceiling((double)DefaultIdealPerFileThreadCountForFolders / concurrentFileCount);
            }

            return perFileThreadCountToUse;
        }

        /// <summary>
        /// Deletes the metadata file from disk.
        /// </summary>
        internal void DeleteMetadataFile()
        {
            if (File.Exists(_metadataFilePath))
            {
                File.Delete(_metadataFilePath);
            }
        }

        #endregion

        #region Transfer Operations

        /// <summary>
        /// Validates that the metadata is valid for a resume operation, and also updates the internal Segment States to match what the Server looks like.
        /// If any changes are made, the metadata will be saved to its canonical location.
        /// </summary>
        /// <param name="metadata"></param>
        private TransferMetadata ValidateMetadataForResume(TransferMetadata metadata, bool isFolderTransfer = false)
        {
            ValidateMetadataMatchesLocalFile(metadata, isFolderTransfer);
            if(isFolderTransfer && metadata.Status == SegmentTransferStatus.Complete)
            {
                // validate that the target stream does exist. If not, set its status back to pending
                var retryCount = 0;
                while (retryCount < SingleSegmentUploader.MaxBufferUploadAttemptCount)
                {
                    _token.ThrowIfCancellationRequested();
                    retryCount++;
                    try
                    {
                        //verify that the stream exists and that the length is as expected
                        if (!_frontEnd.StreamExists(metadata.TargetStreamPath, this.Parameters.IsDownload))
                        {
                            // this file was marked as completed, but no target stream exists; it needs to be retransferred
                            metadata.Status = SegmentTransferStatus.Pending;
                        }
                        else
                        {
                            var remoteLength = _frontEnd.GetStreamLength(metadata.TargetStreamPath, this.Parameters.IsDownload);
                            if (remoteLength != metadata.FileLength)
                            {
                                //the target stream has a different length than the input segment, which implies they are inconsistent; it needs to be retransferred
                                //in this case it is considered safe to delete the file on the server,
                                //since it is in an inconsistent state and we will be re-transfering it anyway
                                _frontEnd.DeleteStream(metadata.TargetStreamPath, this.Parameters.IsDownload);
                                metadata.Status = SegmentTransferStatus.Pending;
                            }
                        }

                        break;
                    }
                    catch (Exception e)
                    {
                        _token.ThrowIfCancellationRequested();
                        if (retryCount >= SingleSegmentUploader.MaxBufferUploadAttemptCount)
                        {
                            var ex = new TransferFailedException(
                                string.Format(
                                    "Cannot validate metadata for stream: {0} in order to resume due to the following exception retrieving file information: {1}",
                                    metadata.TargetStreamPath,
                                    e));

                            TracingHelper.LogError(ex);

                            throw ex;
                        }

                        var waitTime = SingleSegmentUploader.WaitForRetry(retryCount, Parameters.UseSegmentBlockBackOffRetryStrategy, _token);
                        TracingHelper.LogInfo("ValidateMetadataForResume - folder transfer: StreamExists and GetStreamLength at path:{0} failed on try: {1} with exception: {2}. Wait time in ms before retry: {3}",
                            metadata.TargetStreamPath,
                            retryCount,
                            e,
                            waitTime);
                    }
                }

                return metadata;
            }
            
            //verify that the target stream does not already exist and hasn't completed (in case we don't want to overwrite)
            if (!this.Parameters.IsOverwrite && _frontEnd.StreamExists(metadata.TargetStreamPath, this.Parameters.IsDownload))
            {
                var ex = new InvalidOperationException(string.Format("Stream at path: {0} already exists. Please set overwrite to true to overwrite streams that exist.", metadata.TargetStreamPath));

                TracingHelper.LogError(ex);

                throw ex;
            }

            //make sure we don't transfer part of the file as binary, while the rest is non-binary (that's just asking for trouble)
            if (this.Parameters.IsBinary != metadata.IsBinary)
            {
                var ex = new InvalidOperationException(
                    string.Format(
                        "Existing metadata was created for a {0}binary file while the current parameters requested a {1}binary upload.", 
                        metadata.IsBinary ? string.Empty : "non-", 
                        this.Parameters.IsBinary ? string.Empty : "non-"));

                TracingHelper.LogError(ex);

                throw ex;
            }

            //see what files(segments) already exist - update metadata accordingly (only for segments that are missing from server; if it's on the server but not in metadata, reupload)
            foreach (var segment in metadata.Segments)
            {
                if (segment.Status == SegmentTransferStatus.Complete)
                {
                    var retryCount = 0;
                    while (retryCount < SingleSegmentUploader.MaxBufferUploadAttemptCount)
                    {
                        _token.ThrowIfCancellationRequested();
                        retryCount++;
                        try
                        {
                            //verify that the stream exists and that the length is as expected
                            if (!_frontEnd.StreamExists(segment.Path, this.Parameters.IsDownload))
                            {
                                // this segment was marked as completed, but no target stream exists; it needs to be retransferred
                                segment.Status = SegmentTransferStatus.Pending;
                            }
                            else
                            {
                                var remoteLength = _frontEnd.GetStreamLength(segment.Path, this.Parameters.IsDownload);
                                if (remoteLength != segment.Length)
                                {
                                    //the target stream has a different length than the input segment, which implies they are inconsistent; it needs to be retransferred
                                    segment.Status = SegmentTransferStatus.Pending;
                                }
                            }

                            break;
                        }
                        catch (Exception e)
                        {
                            _token.ThrowIfCancellationRequested();
                            if (retryCount >= SingleSegmentUploader.MaxBufferUploadAttemptCount)
                            {
                                var ex = new TransferFailedException(
                                    string.Format(
                                        "Cannot validate metadata for stream: {0} in order to resume due to the following exception retrieving file information: {1}",
                                        metadata.TargetStreamPath,
                                        e));

                                TracingHelper.LogError(ex);

                                throw ex;
                            }

                            var waitTime = SingleSegmentUploader.WaitForRetry(retryCount, Parameters.UseSegmentBlockBackOffRetryStrategy, _token);
                            TracingHelper.LogInfo("ValidateMetadataForResume - file transfer: StreamExists and GetStreamLength at path:{0} failed on try: {1} with exception: {2}. Wait time in ms before retry: {3}",
                                metadata.TargetStreamPath,
                                retryCount,
                                e,
                                waitTime);
                        }
                    }
                }
                else
                {
                    //anything which is not in 'Completed' status needs to be retransferred
                    segment.Status = SegmentTransferStatus.Pending;
                }
            }

            if (!isFolderTransfer)
            {
                metadata.Save();
            }

            return metadata;
        }

        /// <summary>
        /// Verifies that the metadata is valid for a fresh transfer.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateMetadataForFreshTransfer(TransferMetadata metadata)
        {
            ValidateMetadataMatchesLocalFile(metadata);

            //verify that the target stream does not already exist (in case we don't want to overwrite)
            if (!this.Parameters.IsOverwrite && _frontEnd.StreamExists(metadata.TargetStreamPath, this.Parameters.IsDownload))
            {
                var ex = new InvalidOperationException(string.Format("Target Stream: {0} already exists", metadata.TargetStreamPath));

                TracingHelper.LogError(ex);

                throw ex;
            }
        }

        /// <summary>
        /// Verifies that the metadata is consistent with the local file information.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateMetadataMatchesLocalFile(TransferMetadata metadata, bool isFolderTransfer = false)
        {
            //verify that it matches against source file (size, name)
            if (isFolderTransfer)
            {
                if (!metadata.TargetStreamPath.Trim().Contains(this.Parameters.TargetStreamPath.Trim()))
                {
                    var ex = new InvalidOperationException(string.Format("Metadata points to a different target stream folder in path: {0} than the input parameters: {1}", metadata.TargetStreamPath, this.Parameters.TargetStreamPath));

                    TracingHelper.LogError(ex);

                    throw ex;
                }
            }
            else
            {
                if (metadata.TargetStreamPath.Trim() != this.Parameters.TargetStreamPath.Trim())
                {
                    var ex = new InvalidOperationException("Metadata points to a different target stream than the input parameters");

                    TracingHelper.LogError(ex);

                    throw ex;
                }

                if (!this.Parameters.InputFilePath.Equals(metadata.InputFilePath, StringComparison.OrdinalIgnoreCase))
                {
                    var ex = new InvalidOperationException("The metadata refers to different file than the one requested");

                    TracingHelper.LogError(ex);

                    throw ex;
                }
            }

            // We only test for the stream existing and size for transfer, for download this
            // is covered in a separate check.
            if (!metadata.IsDownload && !_frontEnd.StreamExists(metadata.InputFilePath, !metadata.IsDownload))
            {
                var ex = new InvalidOperationException("The metadata refers to a file that does not exist");

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (!metadata.IsDownload && metadata.FileLength != _frontEnd.GetStreamLength(metadata.InputFilePath, !metadata.IsDownload))
            {
                var ex = new InvalidOperationException("The metadata's file information differs from the actual file");

                TracingHelper.LogError(ex);

                throw ex;
            }
        }

        /// <summary>
        /// Validates that the metadata is valid for a resume operation, and also updates the internal Segment States to match what the Server looks like.
        /// If any changes are made, the metadata will be saved to its canonical location.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateFolderMetadataForResume(TransferFolderMetadata metadata)
        {
            ValidateFolderMetadataMatchesLocalFile(metadata);
            var exceptions = new ConcurrentQueue<Exception>();
            var threadsToRun = new List<Thread>(metadata.Files.Length);
            var files = new ConcurrentQueue<TransferMetadata>(metadata.Files);
            int threadCount = Math.Min(metadata.Files.Length, 500);
            for (int i =0; i < threadCount; i++)
            {
                var t = new Thread(() =>
                {
                    //see what files already exist - update metadata accordingly (only for segments that are missing from server; if it's on the server but not in metadata, retransfer)
                    TransferMetadata toValidate;
                    while (files.TryDequeue(out toValidate))
                    {
                        _token.ThrowIfCancellationRequested();
                        try
                        {
                            var toReplace = ValidateMetadataForResume(toValidate, true);
                            for (int j = 0; j < metadata.Files.Length; j++)
                            {
                                if (metadata.Files[j].TransferId == toReplace.TransferId)
                                {
                                    metadata.Files[j] = toReplace;
                                    break;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            exceptions.Enqueue(e);
                        }
                    }
                });

                t.Start();
                threadsToRun.Add(t);
            }

            foreach(var t in threadsToRun)
            {
                t.Join();
            }

            if(exceptions.Count > 0)
            {
                var ex = new AggregateException(exceptions);

                TracingHelper.LogError(ex);

                throw ex;
            }

            metadata.Save();
        }

        /// <summary>
        /// Verifies that the metadata is valid for a fresh transfer.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateFolderMetadataForFreshTransfer(TransferFolderMetadata metadata)
        {
            ValidateFolderMetadataMatchesLocalFile(metadata);
            var exceptions = new ConcurrentQueue<Exception>();
            var threadsToRun = new List<Thread>(metadata.Files.Length);
            var files = new ConcurrentQueue<TransferMetadata>(metadata.Files);
            int threadCount = Math.Min(metadata.Files.Length, 500);
            for (int i = 0; i < threadCount; i++)
            {
                var t = new Thread(() =>
                {
                    TransferMetadata toValidate;
                    while (files.TryDequeue(out toValidate))
                    {
                        _token.ThrowIfCancellationRequested();
                        //verify that the target stream does not already exist (in case we don't want to overwrite)
                        if (!this.Parameters.IsOverwrite && _frontEnd.StreamExists(toValidate.TargetStreamPath, this.Parameters.IsDownload))
                        {
                            exceptions.Enqueue(new InvalidOperationException(string.Format("Stream at path: {0} already exists. Please set overwrite to true to overwrite streams that exist.", toValidate.TargetStreamPath)));
                        }
                    }
                });

                t.Start();
                threadsToRun.Add(t);
            }

            foreach(var t in threadsToRun)
            {
                t.Join();
            }

            if(exceptions.Count > 0)
            {
                var ex = new AggregateException(exceptions);

                TracingHelper.LogError(ex);

                throw ex;
            }
        }

        /// <summary>
        /// Verifies that the metadata is consistent with the local file information.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateFolderMetadataMatchesLocalFile(TransferFolderMetadata metadata)
        {
            if (metadata.TargetStreamFolderPath.Trim() != this.Parameters.TargetStreamPath.Trim())
            {
                var ex = new InvalidOperationException(string.Format("Metadata points to a different target stream folder: {0} than the input parameters: {1}", metadata.TargetStreamFolderPath, this.Parameters.TargetStreamPath));

                TracingHelper.LogError(ex);

                throw ex;
            }

            //verify that it matches against source folder (size, name)
            if (!this.Parameters.InputFilePath.Equals(metadata.InputFolderPath, StringComparison.OrdinalIgnoreCase))
            {
                var ex = new InvalidOperationException("The metadata refers to different folder than the one requested");

                TracingHelper.LogError(ex);

                throw ex;
            }

            if (!_frontEnd.StreamExists(metadata.InputFolderPath, !this.Parameters.IsDownload))
            {
                var ex = new InvalidOperationException("The metadata refers to a folder that does not exist");

                TracingHelper.LogError(ex);

                throw ex;
            }


            long totalBytes = 0;
            var fileAndSizePairs = new Dictionary<string, long>();
            if (this.Parameters.IsDownload)
            {
                foreach (var entry in _frontEnd.ListDirectory(metadata.InputFolderPath, metadata.IsRecursive))
                {
                    fileAndSizePairs.Add(entry.Key, entry.Value);
                }

                totalBytes = fileAndSizePairs.Values.Sum();
            }
            else
            {
                var metadataInputFileInfo = new DirectoryInfo(metadata.InputFolderPath);
                totalBytes = metadataInputFileInfo.GetFiles("*.*",
                    this.Parameters.IsRecursive ?
                    SearchOption.AllDirectories :
                    SearchOption.TopDirectoryOnly).Sum(file => file.Length);
            }
            if (metadata.TotalFileBytes != totalBytes)
            {
                var ex = new InvalidOperationException("The metadata's total size information for all files in the directory differs from the actual directory information!");

                TracingHelper.LogError(ex);

                throw ex;
            }

            var exceptions = new ConcurrentQueue<Exception>();
            var threadsToRun = new List<Thread>(metadata.Files.Length);
            var files = new ConcurrentQueue<TransferMetadata>(metadata.Files);
            int threadCount = Math.Min(metadata.Files.Length, 500);
            for (int i = 0; i < threadCount; i++)
            {
                var t = new Thread(() =>
                {
                    TransferMetadata toValidate;
                    while (files.TryDequeue(out toValidate))
                    {
                        _token.ThrowIfCancellationRequested();
                        try
                        {
                            ValidateMetadataMatchesLocalFile(toValidate, true);
                            if (this.Parameters.IsDownload)
                            {
                                // validate the file exists and the size is correct
                                if (!fileAndSizePairs.ContainsKey(toValidate.InputFilePath) || fileAndSizePairs[toValidate.InputFilePath] != toValidate.FileLength)
                                {
                                    var ex = new InvalidOperationException("The metadata refers to a file that does not exist or the file size does not match");

                                    TracingHelper.LogError(ex);

                                    throw ex;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            exceptions.Enqueue(e);
                        }
                    }
                });

                t.Start();
                threadsToRun.Add(t);
            }

            foreach (var t in threadsToRun)
            {
                t.Join();
            }

            if(exceptions.Count > 0)
            {
                var ex = new AggregateException(exceptions);

                TracingHelper.LogError(ex);

                throw ex;
            }
        }

        /// <summary>
        /// Uploads the file using the given metadata.
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        private void UploadFile(TransferMetadata metadata, IProgress<SegmentTransferProgress> segmentProgressTracker = null)
        {
            try
            {
                segmentProgressTracker = segmentProgressTracker ?? CreateSegmentProgressTracker(metadata);

                if (metadata.SegmentCount == 0)
                {
                    // simply create the target stream, overwriting existing streams if they exist
                    _frontEnd.CreateStream(metadata.TargetStreamPath, true, null, 0);
                }
                else if (metadata.SegmentCount > 1)
                {
                    //perform the multi-segment upload
                    // reducing the thread count to make it equal to the segment count
                    // if it is larger, since those extra threads will not be used.
                    var msu = new MultipleSegmentUploader(metadata, 
                        metadata.SegmentCount < this.Parameters.PerFileThreadCount ? 
                        metadata.SegmentCount : 
                        this.Parameters.PerFileThreadCount, 
                        _frontEnd, _token,
                        segmentProgressTracker);
                    msu.UseSegmentBlockBackOffRetryStrategy = this.Parameters.UseSegmentBlockBackOffRetryStrategy;
                    msu.Upload();

                    //concatenate the files at the end
                    ConcatenateSegments(metadata);
                }
                else
                {
                    //optimization if we only have one segment: upload it directly to the target stream
                    metadata.Segments[0].Path = metadata.TargetStreamPath;
                    var ssu = new SingleSegmentUploader(0, metadata, _frontEnd, _token, segmentProgressTracker);
                    ssu.UseBackOffRetryStrategy = this.Parameters.UseSegmentBlockBackOffRetryStrategy;
                    ssu.Upload();
                }
                metadata.Status = SegmentTransferStatus.Complete;

            }
            catch (OperationCanceledException)
            {
                // do nothing since we have already marked everything as failed
            }
        }

        /// <summary>
        /// Downloads the file using the given metadata.
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        private void DownloadFile(TransferMetadata metadata, IProgress<SegmentTransferProgress> segmentProgressTracker = null)
        {
            if (!_frontEnd.StreamExists(metadata.InputFilePath))
            {
                var ex = new FileNotFoundException("Unable to locate remote file", metadata.InputFilePath);

                TracingHelper.LogError(ex);

                throw ex;
            }

            try
            {
                segmentProgressTracker = segmentProgressTracker ?? CreateSegmentProgressTracker(metadata);

                // ensure the full folder to the target file exists before attempting to create the target file.
                Directory.CreateDirectory(Path.GetDirectoryName(metadata.TargetStreamPath));

                if (metadata.SegmentCount == 0)
                {
                    // simply create the target stream, overwriting existing streams if they exist
                    File.Create(metadata.TargetStreamPath);
                }
                else if (metadata.SegmentCount > 1)
                {
                    //perform the multi-segment download
                    // reducing the thread count to make it equal to the segment count
                    // if it is larger, since those extra threads will not be used.
                    using (var targetStream = new FileStream(metadata.TargetStreamPath + ".inprogress", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        // set length to the target length up front to test for disk space issues
                        // then reset it to 0.
                        targetStream.SetLength(metadata.FileLength);
                        targetStream.SetLength(0);
                    }

                    var msu = new MultipleSegmentDownloader(metadata,
                        metadata.SegmentCount < this.Parameters.PerFileThreadCount ?
                        metadata.SegmentCount :
                        this.Parameters.PerFileThreadCount,
                        _frontEnd, _token,
                        segmentProgressTracker);
                    msu.UseSegmentBlockBackOffRetryStrategy = this.Parameters.UseSegmentBlockBackOffRetryStrategy;
                    msu.Download();

                    //concatenate the files at the end
                    ConcatenateSegments(metadata);
                    
                }
                else
                {
                    //optimization if we only have one segment: download it directly to the target stream

                    using (var targetStream = new FileStream(metadata.TargetStreamPath, FileMode.Create, FileAccess.Write))
                    {
                        // set length to the target length up front to test for disk space issues
                        // then reset it to 0 to ensure that we explicitly call out how big the file is.
                        targetStream.SetLength(metadata.FileLength);
                        targetStream.SetLength(0);
                    }

                    metadata.Segments[0].Path = metadata.TargetStreamPath;
                    var ssu = new SingleSegmentDownloader(0, metadata, _frontEnd, _token, segmentProgressTracker);
                    ssu.UseBackOffRetryStrategy = this.Parameters.UseSegmentBlockBackOffRetryStrategy;
                    ssu.Download();
                    ssu.VerifyDownloadedStream();
                }
                metadata.Status = SegmentTransferStatus.Complete;

            }
            catch (OperationCanceledException)
            {
                // do nothing since we have already marked everything as failed
            }
        }

        /// <summary>
        /// Creates the segment progress tracker.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        private IProgress<SegmentTransferProgress> CreateSegmentProgressTracker(TransferMetadata metadata, IProgress<TransferProgress> customTracker = null)
        {
            if (_progressTracker == null && customTracker == null)
            {
                return null;
            }
         
            var overallProgress = new TransferProgress(metadata, customTracker);
            return new Progress<SegmentTransferProgress>(
                (sup) =>
                {
                    //update the overall progress and report it back
                    overallProgress.SetSegmentProgress(sup);

                    // used in the folder transfer case.
                    if (customTracker != null)
                    {
                        customTracker.Report(overallProgress);
                    }
                    else
                    {
                        _progressTracker.Report(overallProgress);
                    }
                });

        }

        /// <summary>
        /// Creates a file progress tracker.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        private IProgress<TransferProgress> CreateFileProgressTracker(TransferFolderMetadata metadata, out Thread toStart)
        {
            toStart = null;
            if (_folderProgressTracker == null)
            {
                return null;
            }

            var overallProgress = new TransferFolderProgress(metadata);

            // register an event to ensure that, no matter what, we account for all file transfers.
            this.OnFileTransferThreadFailProgressUpdate += overallProgress.OnFileTransferThreadAborted;
            toStart = overallProgress.GetProgressTrackingThread(_token);
            return new Progress<TransferProgress>(
                (sup) =>
                {
                    if(_token.IsCancellationRequested)
                    {
                        return;
                    }

                    //update the overall progress and report it back
                    overallProgress.SetSegmentProgress(sup);
                    _folderProgressTracker.Report(overallProgress);
                });
        }

        /// <summary>
        /// Concatenates all the segments defined in the metadata into a single stream.
        /// </summary>
        /// <param name="metadata"></param>
        private void ConcatenateSegments(TransferMetadata metadata)
        {
            string[] inputPaths = new string[this.Parameters.IsDownload ? 2 : metadata.SegmentCount];
            
            //verify if target stream exists
            if (_frontEnd.StreamExists(metadata.TargetStreamPath, this.Parameters.IsDownload))
            {
                if (this.Parameters.IsOverwrite)
                {
                    _frontEnd.DeleteStream(metadata.TargetStreamPath, false, this.Parameters.IsDownload);
                }
                else
                {
                    var ex = new InvalidOperationException(string.Format("Target Stream: {0} already exists", metadata.TargetStreamPath));

                    TracingHelper.LogError(ex);

                    throw ex;
                }
            }

            var exceptions = new ConcurrentQueue<Exception>();
            if (this.Parameters.IsDownload)
            {
                // call concatenate, which really just renames
                // the "inprogress" file to complete.
                inputPaths[0] = string.Format("{0}.inprogress", metadata.TargetStreamPath);
                inputPaths[1] = metadata.TargetStreamPath;

                // validate that the file is the right length.
                var retryCount = 0;
                long remoteLength = -1;
                try
                {
                    while (retryCount < SingleSegmentUploader.MaxBufferUploadAttemptCount)
                    {
                        _token.ThrowIfCancellationRequested();
                        retryCount++;
                        try
                        {
                            remoteLength = _frontEnd.GetStreamLength(inputPaths[0], this.Parameters.IsDownload);
                            break;
                        }
                        catch (Exception e)
                        {
                            _token.ThrowIfCancellationRequested();
                            if (retryCount >= SingleSegmentUploader.MaxBufferUploadAttemptCount)
                            {
                                var ex = new TransferFailedException(
                                    string.Format(
                                        "Cannot perform 'Finalization' operation due to the following exception retrieving file information: {0}",
                                        e));

                                TracingHelper.LogError(ex);

                                throw ex;
                            }

                            var waitTime = SingleSegmentUploader.WaitForRetry(retryCount, Parameters.UseSegmentBlockBackOffRetryStrategy, _token);
                            TracingHelper.LogInfo("ConcatenateSegments: GETFILESTATUS at path:{0} failed on try: {1} with exception: {2}. Wait time in ms before retry: {3}",
                                metadata.TargetStreamPath,
                                retryCount,
                                e,
                                waitTime);
                        }
                    }

                    if (remoteLength != metadata.FileLength)
                    {
                        var ex = new TransferFailedException(string.Format("Cannot perform 'Finalization' operation because in progress file {0} has an incorrect length (expected {1}, actual {2}).", inputPaths[0], metadata.FileLength, remoteLength));

                        TracingHelper.LogError(ex);

                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    exceptions.Enqueue(ex);
                }
            }
            else
            {
                //ensure all segments in the metadata are marked as 'complete'
                
                for (int i = 0; i < metadata.SegmentCount; i++)
                {
                    try
                    {
                        if (metadata.Segments[i].Status != SegmentTransferStatus.Complete)
                        {
                            var ex = new TransferFailedException("Cannot perform 'Concatenate' operation because not all streams are fully uploaded.");

                            TracingHelper.LogError(ex);

                            throw ex;
                        }

                        inputPaths[i] = metadata.Segments[i].Path.Replace('\\','/');
                    }
                    catch (Exception ex)
                    {
                        //collect any exceptions, whether we just generated them above or whether they come from the Front End,
                        exceptions.Enqueue(ex);
                    }
                }
            }

            if (exceptions.Count > 0)
            {
                var ex = new AggregateException("At least one concatenate test failed", exceptions.ToArray());

                TracingHelper.LogError(ex);

                throw ex;
            }

            //issue the command
            _frontEnd.Concatenate(metadata.TargetStreamPath, inputPaths, this.Parameters.IsDownload);            
        }
        
        #endregion

    }
}
