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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents a general purpose file uploader into DataLake. Supports the efficient upload of large files.
    /// </summary>
    public sealed class DataLakeStoreUploader
    {

        #region Private

        /// <summary>
        /// The maximum number of parallel threads to allow. 
        /// </summary>
        public const int MaxAllowedThreads = 1024;
        private readonly IFrontEndAdapter _frontEnd;
        private readonly IProgress<UploadProgress> _progressTracker;
        private readonly string _metadataFilePath;
        private readonly CancellationToken _token;
        private int _previousDefaultConnectionLimit;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the DataLakeUploader class, by specifying a pointer to the FrontEnd to use for the upload.
        /// </summary>
        /// <param name="uploadParameters">The Upload Parameters to use.</param>
        /// <param name="frontEnd">A pointer to the FrontEnd interface to use for the upload.</param>
        /// <param name="progressTracker">(Optional) A tracker that reports progress on the upload.</param>
        public DataLakeStoreUploader(UploadParameters uploadParameters, IFrontEndAdapter frontEnd, IProgress<UploadProgress> progressTracker = null) :
            this(uploadParameters, frontEnd, CancellationToken.None, progressTracker)
        {
            
        }

        /// <summary>
        /// Creates a new instance of the DataLakeUploader class, by specifying a pointer to the FrontEnd to use for the upload.
        /// </summary>
        /// <param name="uploadParameters">The Upload Parameters to use.</param>
        /// <param name="frontEnd">A pointer to the FrontEnd interface to use for the upload.</param>
        /// <param name="progressTracker">(Optional) A tracker that reports progress on the upload.</param>
        public DataLakeStoreUploader(UploadParameters uploadParameters, IFrontEndAdapter frontEnd, CancellationToken token, IProgress<UploadProgress> progressTracker = null )
        {
            this.Parameters = uploadParameters;
            _frontEnd = frontEnd;

            //ensure that input parameters are correct
            ValidateParameters();

            _metadataFilePath = GetCanonicalMetadataFilePath();
            _progressTracker = progressTracker;
            _token = token;
        }

        /// <summary>
        /// Gets the canonical metadata file path.
        /// </summary>
        /// <returns></returns>
        private string GetCanonicalMetadataFilePath()
        {
            return Path.Combine(this.Parameters.LocalMetadataLocation, string.Format("{0}.upload.xml", Path.GetFileName(this.Parameters.InputFilePath)));
        }

        #endregion

        #region Invocation

        /// <summary>
        /// Gets the parameters to use for this upload.
        /// </summary>
        public UploadParameters Parameters { get; private set; }

        /// <summary>
        /// Executes the upload as defined by the input parameters.
        /// </summary>
        public void Execute()
        {
            //load up existing metadata or create a fresh one
            var metadata = GetMetadata();

            if (metadata.SegmentCount < this.Parameters.ThreadCount)
            {
                // reducing the thread count to make it equal to the segment count
                // if it is larger, since those extra threads will not be used.
                this.Parameters.ThreadCount = metadata.SegmentCount;
            }

            //begin (or resume) uploading the file
            UploadFile(metadata);

            if (_frontEnd.StreamExists(metadata.SegmentStreamDirectory))
            {
                // delete the folder that contained the intermediate segments, if there was one (for single segment uploads there will not be)
                _frontEnd.DeleteStream(metadata.SegmentStreamDirectory, true);
            }

            //clean up metadata after a successful upload
            metadata.DeleteFile();
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
            if (!File.Exists(this.Parameters.InputFilePath))
            {
                throw new FileNotFoundException("Could not find input file", this.Parameters.InputFilePath);
            }

            if (string.IsNullOrWhiteSpace(this.Parameters.TargetStreamPath))
            {
                throw new ArgumentNullException("TargetStreamPath", "Null or empty Target Stream Path");
            }

            if (this.Parameters.TargetStreamPath.EndsWith("/"))
            {
                throw new ArgumentException("Invalid TargetStreamPath, a stream path should not end with /");
            }

            if (string.IsNullOrWhiteSpace(this.Parameters.AccountName))
            {
                throw new ArgumentNullException("AccountName", "Null or empty Account Name");
            }

            if (this.Parameters.ThreadCount < 1 || this.Parameters.ThreadCount > MaxAllowedThreads)
            {
                throw new ArgumentOutOfRangeException(string.Format("ThreadCount must be at least 1 and at most {0}", MaxAllowedThreads), "ThreadCount");
            }
        }

        #endregion

        #region Metadata Operations

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <returns></returns>
        private UploadMetadata GetMetadata()
        {
            var metadataGenerator = new UploadMetadataGenerator(this.Parameters);
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

        #region Uploading Operations

        /// <summary>
        /// Validates that the metadata is valid for a resume operation, and also updates the internal Segment States to match what the Server looks like.
        /// If any changes are made, the metadata will be saved to its canonical location.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateMetadataForResume(UploadMetadata metadata)
        {
            ValidateMetadataMatchesLocalFile(metadata);

            //verify that the target stream does not already exist (in case we don't want to overwrite)
            if (!this.Parameters.IsOverwrite && _frontEnd.StreamExists(metadata.TargetStreamPath))
            {
                throw new InvalidOperationException("Target Stream already exists");
            }

            //make sure we don't upload part of the file as binary, while the rest is non-binary (that's just asking for trouble)
            if (this.Parameters.IsBinary != metadata.IsBinary)
            {
                throw new InvalidOperationException(
                    string.Format(
                        "Existing metadata was created for a {0}binary file while the current parameters requested a {1}binary upload.", 
                        metadata.IsBinary ? string.Empty : "non-", 
                        this.Parameters.IsBinary ? string.Empty : "non-"));
            }

            //see what files(segments) already exist - update metadata accordingly (only for segments that are missing from server; if it's on the server but not in metadata, reupload)
            foreach (var segment in metadata.Segments)
            {
                if (segment.Status == SegmentUploadStatus.Complete)
                {
                    var retryCount = 0;
                    while (retryCount < SingleSegmentUploader.MaxBufferUploadAttemptCount)
                    {
                        _token.ThrowIfCancellationRequested();
                        retryCount++;
                        try
                        {
                            //verify that the stream exists and that the length is as expected
                            if (!_frontEnd.StreamExists(segment.Path))
                            {
                                // this segment was marked as completed, but no target stream exists; it needs to be reuploaded
                                segment.Status = SegmentUploadStatus.Pending;
                            }
                            else
                            {
                                var remoteLength = _frontEnd.GetStreamLength(segment.Path);
                                if (remoteLength != segment.Length)
                                {
                                    //the target stream has a different length than the input segment, which implies they are inconsistent; it needs to be reuploaded
                                    segment.Status = SegmentUploadStatus.Pending;
                                }
                            }

                            break;
                        }
                        catch (Exception e)
                        {
                            _token.ThrowIfCancellationRequested();
                            if (retryCount >= SingleSegmentUploader.MaxBufferUploadAttemptCount)
                            {
                                throw new UploadFailedException(
                                    string.Format(
                                        "Cannot validate metadata in order to resume due to the following exception retrieving file information: {0}",
                                        e));
                            }

                            SingleSegmentUploader.WaitForRetry(retryCount, Parameters.UseSegmentBlockBackOffRetryStrategy, _token);
                        }
                    }
                }
                else
                {
                    //anything which is not in 'Completed' status needs to be reuploaded
                    segment.Status = SegmentUploadStatus.Pending;
                }
            }
            metadata.Save();
        }

        /// <summary>
        /// Verifies that the metadata is valid for a fresh upload.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateMetadataForFreshUpload(UploadMetadata metadata)
        {
            ValidateMetadataMatchesLocalFile(metadata);

            //verify that the target stream does not already exist (in case we don't want to overwrite)
            if (!this.Parameters.IsOverwrite && _frontEnd.StreamExists(metadata.TargetStreamPath))
            {
                throw new InvalidOperationException("Target Stream already exists");
            }
        }

        /// <summary>
        /// Verifies that the metadata is consistent with the local file information.
        /// </summary>
        /// <param name="metadata"></param>
        private void ValidateMetadataMatchesLocalFile(UploadMetadata metadata)
        {
            if (metadata.TargetStreamPath.Trim() != this.Parameters.TargetStreamPath.Trim())
            {
                throw new InvalidOperationException("Metadata points to a different target stream than the input parameters");
            }
            
            //verify that it matches against local file (size, name)
            var metadataInputFileInfo = new FileInfo(metadata.InputFilePath);
            var paramInputFileInfo = new FileInfo(this.Parameters.InputFilePath);
            
            if (!paramInputFileInfo.FullName.Equals(metadataInputFileInfo.FullName, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("The metadata refers to different file than the one requested");
            }

            if (!metadataInputFileInfo.Exists)
            {
                throw new InvalidOperationException("The metadata refers to a file that does not exist");
            }

            if (metadata.FileLength != metadataInputFileInfo.Length)
            {
                throw new InvalidOperationException("The metadata's file information differs from the actual file");
            }
        }

        /// <summary>
        /// Uploads the file using the given metadata.
        /// 
        /// </summary>
        /// <param name="metadata"></param>
        private void UploadFile(UploadMetadata metadata)
        {
            try
            {
                //we need to override the default .NET value for max connections to a host to our number of threads, if necessary (otherwise we won't achieve the parallelism we want)
                _previousDefaultConnectionLimit = ServicePointManager.DefaultConnectionLimit;
                ServicePointManager.DefaultConnectionLimit = Math.Max(this.Parameters.ThreadCount,
                    ServicePointManager.DefaultConnectionLimit);

                //match up the metadata with the information on the server
                if (this.Parameters.IsResume)
                {
                    ValidateMetadataForResume(metadata);
                }
                else
                {
                    ValidateMetadataForFreshUpload(metadata);
                }

                var segmentProgressTracker = CreateSegmentProgressTracker(metadata);

                if (metadata.SegmentCount == 0)
                {
                    // simply create the target stream, overwriting existing streams if they exist
                    _frontEnd.CreateStream(metadata.TargetStreamPath, true, null, 0);
                }
                else if (metadata.SegmentCount > 1)
                {
                    //perform the multi-segment upload
                    var msu = new MultipleSegmentUploader(metadata, this.Parameters.ThreadCount, _frontEnd, _token,
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
            }
            catch (OperationCanceledException)
            {
                // do nothing since we have already marked everything as failed
            }
            finally
            {
                //revert back the default .NET value for max connections to a host to whatever it was before
                ServicePointManager.DefaultConnectionLimit = _previousDefaultConnectionLimit;
            }
        }

        /// <summary>
        /// Creates the segment progress tracker.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        private IProgress<SegmentUploadProgress> CreateSegmentProgressTracker(UploadMetadata metadata)
        {
            if (_progressTracker == null)
            {
                return null;
            }
         
            var overallProgress = new UploadProgress(metadata);
            return new Progress<SegmentUploadProgress>(
                (sup) =>
                {
                    //update the overall progress and report it back
                    overallProgress.SetSegmentProgress(sup);
                    _progressTracker.Report(overallProgress);
                });

        }

        /// <summary>
        /// Concatenates all the segments defined in the metadata into a single stream.
        /// </summary>
        /// <param name="metadata"></param>
        private void ConcatenateSegments(UploadMetadata metadata)
        {
            string[] inputPaths = new string[metadata.SegmentCount];
            
            //verify if target stream exists
            if (_frontEnd.StreamExists(metadata.TargetStreamPath))
            {
                if (this.Parameters.IsOverwrite)
                {
                    _frontEnd.DeleteStream(metadata.TargetStreamPath);
                }
                else
                {
                    throw new InvalidOperationException("Target Stream already exists");
                }
            }

            //ensure all input streams exist and are of the expected length
            //ensure all segments in the metadata are marked as 'complete'
            var exceptions = new List<Exception>();
            Parallel.For(
                0,
                metadata.SegmentCount,
                new ParallelOptions() { MaxDegreeOfParallelism = this.Parameters.ThreadCount },
                (i) =>
                {
                    try
                    {
                        if (metadata.Segments[i].Status != SegmentUploadStatus.Complete)
                        {
                            throw new UploadFailedException("Cannot perform 'Concatenate' operation because not all streams are fully uploaded.");
                        }

                        var remoteStreamPath = metadata.Segments[i].Path;
                        var retryCount = 0;
                        long remoteLength = -1;
                        
                        while (retryCount < SingleSegmentUploader.MaxBufferUploadAttemptCount)
                        {
                            _token.ThrowIfCancellationRequested();
                            retryCount++;
                            try
                            {
                                remoteLength = _frontEnd.GetStreamLength(remoteStreamPath);
                                break;
                            }
                            catch (Exception e)
                            {
                                _token.ThrowIfCancellationRequested();
                                if (retryCount >= SingleSegmentUploader.MaxBufferUploadAttemptCount)
                                {
                                    throw new UploadFailedException(
                                        string.Format(
                                            "Cannot perform 'Concatenate' operation due to the following exception retrieving file information: {0}",
                                            e));
                                }

                                SingleSegmentUploader.WaitForRetry(retryCount, Parameters.UseSegmentBlockBackOffRetryStrategy, _token);
                            }
                        }

                        
                        if (remoteLength != metadata.Segments[i].Length)
                        {
                            throw new UploadFailedException(string.Format("Cannot perform 'Concatenate' operation because segment {0} has an incorrect length (expected {1}, actual {2}).", i, metadata.Segments[i].Length, remoteLength));
                        }

                        inputPaths[i] = remoteStreamPath;
                    }
                    catch (Exception ex)
                    {
                        //collect any exceptions, whether we just generated them above or whether they come from the Front End,
                        exceptions.Add(ex);
                    }
                });

            if (exceptions.Count > 0)
            {
                throw new AggregateException("At least one concatenate test failed", exceptions.ToArray());
            }

            //issue the command
            _frontEnd.Concatenate(metadata.TargetStreamPath, inputPaths);            
        }
        
        #endregion

    }
}
