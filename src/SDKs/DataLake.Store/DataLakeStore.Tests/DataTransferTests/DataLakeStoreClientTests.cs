﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace DataLakeStore.Tests
{
    using Microsoft.Azure.Management.DataLake.Store;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Xunit;

    /// <summary>
    /// Unit tests for the uploader.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    public class DataLakeTransferClientTests : IDisposable
    {
        #region Private

        private const int LargeFileLength = 9 * 1024 * 1024; // 9mb
        private readonly byte[] _largeFileData = new byte[LargeFileLength];
        private string _largeFilePath;
        private const int SmallFileLength = 128; 
        private readonly byte[] _smallFileData = new byte[SmallFileLength];
        private string _smallFilePath;
        private string _downloadFilePath;
        private const int ThreadCount = 1;
        private const string TargetStreamPath = "1";

        #endregion

        #region Test Setup & Teardown

        public DataLakeTransferClientTests()
        {
            var runFolder = Guid.NewGuid();
            TestHelpers.GenerateFileData(_largeFileData, runFolder.ToString(), out _largeFilePath);
            TestHelpers.GenerateFileData(_smallFileData, runFolder.ToString(), out _smallFilePath);
            TestHelpers.GenerateFileData(_smallFileData, runFolder.ToString(), out _downloadFilePath);
        }

        public void Dispose()
        {
            var tempDir = Path.GetDirectoryName(_largeFilePath);
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }

        #endregion

        #region Tests

        /// <summary>
        /// Tests the case when invalid parameters are being passed to the uploader.
        /// </summary>
        [Fact]
        public void DataLakeUploader_InvalidParameters()
        {
            //invalid file path
            string invalidFilePath = Path.GetRandomFileName();
            Assert.False(File.Exists(invalidFilePath), "Unit test error: generated temp file actually exists");

            Assert.Throws<FileNotFoundException>(
                () =>
                {
                    new DataLakeStoreTransferClient(new TransferParameters(invalidFilePath, "1", "foo", maxSegmentLength: 4 * 1024 * 1024), new InMemoryFrontEnd());
                });

            //no target stream
            Assert.Throws<ArgumentNullException>(
                () => { new DataLakeStoreTransferClient(new TransferParameters(_largeFilePath, null, "foo", maxSegmentLength: 4 * 1024 * 1024), new InMemoryFrontEnd()); });

            //target stream ends in '/'
            Assert.Throws<ArgumentException>(
                () => { new DataLakeStoreTransferClient(new TransferParameters(_largeFilePath, "1/", "foo", maxSegmentLength: 4 * 1024 * 1024), new InMemoryFrontEnd()); });

            //no account name
            Assert.Throws<ArgumentNullException>(
                () => { new DataLakeStoreTransferClient(new TransferParameters(_largeFilePath, "1", null, maxSegmentLength: 4 * 1024 * 1024), new InMemoryFrontEnd()); });

            //bad thread count
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { new DataLakeStoreTransferClient(new TransferParameters(_largeFilePath, "1", "foo", perFileThreadCount: DataLakeStoreTransferClient.MaxAllowedThreadsPerFile + 1, maxSegmentLength: 4 * 1024 * 1024), new InMemoryFrontEnd()); });

            Assert.Throws<ArgumentOutOfRangeException>(
                () => { new DataLakeStoreTransferClient(new TransferParameters(_largeFilePath, "1", "foo", concurrentFileCount: DataLakeStoreTransferClient.MaxAllowedThreadsPerFile + 1, maxSegmentLength: 4 * 1024 * 1024), new InMemoryFrontEnd()); });

            Assert.Throws<ArgumentOutOfRangeException>(
                () => { new DataLakeStoreTransferClient(new TransferParameters(_largeFilePath, "1", "foo", concurrentFileCount: 1, maxSegmentLength: 0), new InMemoryFrontEnd()); });
        }

        /// <summary>
        /// Tests the case when the target stream exists and we haven't set the overwrite flag.
        /// </summary>
        [Fact]
        public void DataLakeUploader_TargetExistsNoOverwrite()
        {
            var frontEnd = new InMemoryFrontEnd();
            frontEnd.CreateStream(TargetStreamPath, true, null, 0);

            //no resume, no overwrite
            var up = CreateParameters(filePath: _smallFilePath, isResume: false);
            var uploader = new DataLakeStoreTransferClient(up, frontEnd);
            Assert.Throws<InvalidOperationException>(() => uploader.Execute());

            //resume, no overwrite
            up = CreateParameters(filePath: _smallFilePath, isResume: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            Assert.Throws<InvalidOperationException>(() => uploader.Execute());

            //resume, overwrite
            up = CreateParameters(filePath: _smallFilePath, isResume: true, isOverwrite: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.Execute();

            //no resume, overwrite
            up = CreateParameters(filePath: _smallFilePath, isResume: false, isOverwrite: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.Execute();

            //download no resume, no overwrite
            up = CreateParameters(filePath: TargetStreamPath, targetStreamPath: _downloadFilePath, isResume: false, isDownload: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            Assert.Throws<InvalidOperationException>(() => uploader.Execute());

            //download resume, no overwrite
            up = CreateParameters(filePath: TargetStreamPath, targetStreamPath: _downloadFilePath, isResume: true, isDownload: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            Assert.Throws<InvalidOperationException>(() => uploader.Execute());

            //download resume, overwrite
            up = CreateParameters(filePath: TargetStreamPath, targetStreamPath: _downloadFilePath, isResume: true, isOverwrite: true, isDownload: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.Execute();

            //download no resume, overwrite
            up = CreateParameters(filePath: TargetStreamPath, targetStreamPath: _downloadFilePath, isResume: false, isOverwrite: true, isDownload: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.Execute();
        }

        /// <summary>
        /// Tests the case of a fresh upload with multiple segments.
        /// </summary>
        [Fact]
        public void DataLakeUploader_FreshUploadDownload()
        {
            var frontEnd = new InMemoryFrontEnd();
            var up = CreateParameters(isResume: false);
            TransferProgress progress = null;
            var syncRoot = new object();
            IProgress<TransferProgress> progressTracker = new Progress<TransferProgress>(
                (p) => 
                {
                    lock (syncRoot)
                    {
                        //it is possible that these come out of order because of race conditions (multiple threads reporting at the same time); only update if we are actually making progress
                        if (progress == null || progress.TransferredByteCount < p.TransferredByteCount)
                        {
                            progress = p;
                        }
                    }
                });
            var uploader = new DataLakeStoreTransferClient(up, frontEnd, progressTracker);

            uploader.Execute();

            VerifyFileUploadedSuccessfully(up, frontEnd);
            VerifyProgressStatus(progress, _largeFileData.Length);

            Assert.Equal(ThreadCount, uploader.Parameters.PerFileThreadCount);

            // now download
            // change the thread count to be the default and validate that it is different.
            progress = null;
            up = CreateParameters(isResume: false, isDownload: true, targetStreamPath: _downloadFilePath, isOverwrite: true, filePath: TargetStreamPath);
            up.PerFileThreadCount = -1;
            uploader = new DataLakeStoreTransferClient(up, frontEnd, progressTracker);

            uploader.Execute();

            VerifyFileUploadedSuccessfully(up, frontEnd);
            VerifyProgressStatus(progress, _largeFileData.Length);
            Assert.True(up.PerFileThreadCount > 0 && uploader.Parameters.PerFileThreadCount > 0);
        }

        /// <summary>
        /// Tests the case of a fresh upload with multiple segments and multiple files.
        /// </summary>
        [Fact(Skip = "Randomly failing on CI. Needs investigation from DataLakeStore team")]
        public void DataLakeUploader_FreshFolderUploadDownload()
        {
            var frontEnd = new InMemoryFrontEnd();
            var up = CreateParameters(isResume: false, isRecursive: true);

            // set the per file thread count to the default to validate computed values.
            up.PerFileThreadCount = -1;
            TransferFolderProgress progress = null;
            var syncRoot = new object();
            IProgress<TransferFolderProgress> progressTracker = new Progress<TransferFolderProgress>(
                (p) =>
                {
                    lock (syncRoot)
                    {
                        //it is possible that these come out of order because of race conditions (multiple threads reporting at the same time); only update if we are actually making progress
                        if (progress == null || progress.TransferredByteCount < p.TransferredByteCount)
                        {
                            progress = p;
                        }
                    }
                });
            var uploader = new DataLakeStoreTransferClient(up, frontEnd, null, progressTracker);

            uploader.Execute();

            VerifyFileUploadedSuccessfully(up, frontEnd);
            VerifyFolderProgressStatus(progress, _largeFileData.Length + (_smallFileData.Length *2), 3);

            // verify that per file thread count is different but concurrent is the same.
            Assert.True(up.PerFileThreadCount > 0 && uploader.Parameters.PerFileThreadCount > 0);
            Assert.Equal(2, uploader.Parameters.ConcurrentFileCount);

            // now download
            var downloadFrontEnd = new MockableFrontEnd(frontEnd);
            
            // replace the isDirectory implementation to return true
            downloadFrontEnd.IsDirectoryImplementation = (streamPath) => { return true; };
            progress = null;
            up = CreateParameters(isRecursive: true, isResume: false, isDownload: true, targetStreamPath: Path.GetDirectoryName(_downloadFilePath), isOverwrite: true, filePath: TargetStreamPath);

            // set concurrentFileCount to default and validate that it changed.
            up.ConcurrentFileCount = -1;
            uploader = new DataLakeStoreTransferClient(up, downloadFrontEnd, null, progressTracker);

            uploader.Execute();
            VerifyFileUploadedSuccessfully(up, downloadFrontEnd.BaseAdapter);
            VerifyFolderProgressStatus(progress, _largeFileData.Length + (_smallFileData.Length * 2), 3);

            Assert.True(up.ConcurrentFileCount > 0 && uploader.Parameters.ConcurrentFileCount > 0);
            Assert.Equal(ThreadCount, uploader.Parameters.PerFileThreadCount);

            // run it one more time with both as defaults
            up.PerFileThreadCount = -1;
            up.ConcurrentFileCount = -1;
            uploader = new DataLakeStoreTransferClient(up, downloadFrontEnd, null, progressTracker);

            uploader.Execute();
            VerifyFileUploadedSuccessfully(up, downloadFrontEnd.BaseAdapter);
            VerifyFolderProgressStatus(progress, _largeFileData.Length + (_smallFileData.Length * 2), 3);
            Assert.True(up.ConcurrentFileCount > 0 && uploader.Parameters.ConcurrentFileCount > 0);
            Assert.True(up.PerFileThreadCount > 0 && uploader.Parameters.PerFileThreadCount > 0);
        }

        /// <summary>
        /// Tests the case of a fresh upload with multiple segments being cancelled
        /// </summary>
        [Fact]
        public void DataLakeUploader_CancelUpload()
        {
            CancellationTokenSource myTokenSource = new CancellationTokenSource();
            var cancelToken = myTokenSource.Token;
            var frontEnd = new InMemoryFrontEnd();
            var mockedFrontend = new MockableFrontEnd(frontEnd);
            mockedFrontend.GetStreamLengthImplementation = (streamPath, isDownload) =>
            {
                // sleep for 2 second to allow for the cancellation to actual happen
                Thread.Sleep(2000);
                return frontEnd.GetStreamLength(streamPath, isDownload);
            };

            mockedFrontend.StreamExistsImplementation = (streamPath, isDownload) =>
            {
                // sleep for 2 second to allow for the cancellation to actual happen
                Thread.Sleep(2000);
                return frontEnd.StreamExists(streamPath, isDownload);
            };
            var up = CreateParameters(isResume: false);
            TransferProgress progress = null;
            var syncRoot = new object();
            IProgress<TransferProgress> progressTracker = new Progress<TransferProgress>(
                (p) =>
                {
                    lock (syncRoot)
                    {
                        //it is possible that these come out of order because of race conditions (multiple threads reporting at the same time); only update if we are actually making progress
                        if (progress == null || progress.TransferredByteCount < p.TransferredByteCount)
                        {
                            progress = p;
                        }
                    }
                });
            var uploader = new DataLakeStoreTransferClient(up, mockedFrontend, cancelToken, progressTracker);

            Task uploadTask = Task.Run(() =>
            {
                uploader.Execute();
                Thread.Sleep(2000);
            }, cancelToken);
            myTokenSource.Cancel();
            Assert.True(cancelToken.IsCancellationRequested);

            while (uploadTask.Status == TaskStatus.Running || uploadTask.Status == TaskStatus.WaitingToRun)
            {
                Thread.Sleep(250);
            }

            // Verify that the file did not get uploaded completely.
            Assert.False(frontEnd.StreamExists(up.TargetStreamPath), "Uploaded stream exists when it should not yet have been completely created");
        }

        /// <summary>
        /// Tests the resume upload when the metadata indicates all files are uploaded but no files exist on the server.
        /// </summary>
        [Fact]
        public void DataLakeUploader_ResumeUploadDownloadWithAllMissingFiles()
        {
            //this scenario is achieved by refusing to execute the concat command on the front end for the initial upload (which will interrupt it)
            //and then resuming the upload against a fresh front-end (which obviously has no files there)
            
            var backingFrontEnd1 = new InMemoryFrontEnd();
            var frontEnd1 = new MockableFrontEnd(backingFrontEnd1);
            frontEnd1.ConcatenateImplementation = (target, inputs, isDownload) => { throw new IntentionalException(); }; //fail the concatenation

            //attempt full upload
            var up = CreateParameters(isResume: false);

            var uploader = new DataLakeStoreTransferClient(up, frontEnd1);
            uploader.DeleteMetadataFile();

            Assert.Throws<IntentionalException>(() => uploader.Execute());
            Assert.False(frontEnd1.StreamExists(up.TargetStreamPath), "Target stream should not have been created");
            Assert.True(0 < backingFrontEnd1.StreamCount, "No temporary streams seem to have been created");

            //attempt to resume the upload
            var frontEnd2 = new InMemoryFrontEnd();
            up = CreateParameters(isResume: true);
            uploader = new DataLakeStoreTransferClient(up, frontEnd2);

            //at this point the metadata exists locally but there are no target files in frontEnd2
            try
            {
                uploader.Execute();
            }
            finally
            {
                uploader.DeleteMetadataFile();
            }

            VerifyFileUploadedSuccessfully(up, frontEnd2);

            // now download the same way.
            var frontEnd3 = new MockableFrontEnd(frontEnd2); // need to have data from the successful upload available.
            frontEnd3.ConcatenateImplementation = (target, inputs, isDownload) => { throw new IntentionalException(); }; //fail the concatenation
            up = CreateParameters(isResume: false, isDownload: true, targetStreamPath: _downloadFilePath, isOverwrite: true, filePath: up.TargetStreamPath);
            uploader = new DataLakeStoreTransferClient(up, frontEnd3);

            Assert.Throws<IntentionalException>(() => uploader.Execute());
            Assert.False(frontEnd1.StreamExists(up.TargetStreamPath, true), "Target stream should not have been created");

            // now use the good front end
            up = CreateParameters(isResume: true, isDownload: true, targetStreamPath: _downloadFilePath, isOverwrite: true, filePath: up.InputFilePath);
            uploader = new DataLakeStoreTransferClient(up, frontEnd2);
            //at this point the metadata exists locally but there are no target files in frontEnd2
            try
            {
                uploader.Execute();
            }
            finally
            {
                uploader.DeleteMetadataFile();
            }

            VerifyFileUploadedSuccessfully(up, frontEnd2);
        }

        /// <summary>
        /// Tests the resume upload when only some segments were uploaded previously
        /// </summary>
        [Fact]
        public void DataLakeUploader_ResumePartialFolderUpload()
        {
            //attempt to load the file fully, but only allow creating 1 target stream
            var backingFrontEnd = new InMemoryFrontEnd();
            var frontEnd = new MockableFrontEnd(backingFrontEnd);
            
            int createStreamCount = 0;
            frontEnd.CreateStreamImplementation = (path, overwrite, data, byteCount) =>
            {
                createStreamCount++;
                if (createStreamCount > 1)
                {
                    //we only allow 1 file to be created
                    throw new IntentionalException();
                }
                backingFrontEnd.CreateStream(path, overwrite, data, byteCount);
            };
            var up = CreateParameters(isResume: false, isRecursive: true);
            var uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.DeleteMetadataFile();

            Assert.Throws<AggregateException>(() => uploader.Execute());
            Assert.Equal(1, frontEnd.ListDirectory(up.TargetStreamPath, false).Keys.Count);
            Assert.Equal(1, backingFrontEnd.StreamCount);

            //resume the upload but point it to the real back-end, which doesn't throw exceptions
            up = CreateParameters(isResume: true, isRecursive: true);
            uploader = new DataLakeStoreTransferClient(up, backingFrontEnd);

            try
            {
                uploader.Execute();
            }
            finally
            {
                uploader.DeleteMetadataFile();
            }

            VerifyFileUploadedSuccessfully(up, backingFrontEnd);
        }

        /// <summary>
        /// Tests the resume upload when only some segments were uploaded previously
        /// </summary>
        [Fact]
        public void DataLakeUploader_ResumePartialUploadDownload()
        {
            //attempt to load the file fully, but only allow creating 1 target stream
            var backingFrontEnd = new InMemoryFrontEnd();
            var frontEnd = new MockableFrontEnd(backingFrontEnd);

            int createStreamCount = 0;
            frontEnd.CreateStreamImplementation = (path, overwrite, data, byteCount) =>
            {
                createStreamCount++;
                if (createStreamCount > 1)
                {
                    //we only allow 1 file to be created
                    throw new IntentionalException();
                }
                backingFrontEnd.CreateStream(path, overwrite, data, byteCount);
            };

            var up = CreateParameters(isResume: false);
            var uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.DeleteMetadataFile();

            Assert.Throws<AggregateException>(() => uploader.Execute());
            Assert.Equal(1, frontEnd.ListDirectory(up.TargetStreamPath, false).Keys.Count);
            Assert.Equal(1, backingFrontEnd.StreamCount);

            //resume the upload but point it to the real back-end, which doesn't throw exceptions
            up = CreateParameters(isResume: true);
            uploader = new DataLakeStoreTransferClient(up, backingFrontEnd);

            try
            {
                uploader.Execute();
            }
            finally
            {
                uploader.DeleteMetadataFile();
            }

            VerifyFileUploadedSuccessfully(up, backingFrontEnd);

            // now download the same way.
            var frontEnd2 = new MockableFrontEnd(backingFrontEnd); // need to have data from the successful upload available.
            createStreamCount = 0;
            frontEnd2.ReadStreamImplementation = (path, data, byteCount, isDownload) =>
            {
                createStreamCount++;
                if (createStreamCount > 1)
                {
                    //we only allow 1 file to be created
                    throw new IntentionalException();
                }
                return backingFrontEnd.ReadStream(path, data, byteCount, isDownload);
            };

            up = CreateParameters(isResume: false, isDownload: true, targetStreamPath: _downloadFilePath, isOverwrite: true, filePath: up.TargetStreamPath);
            uploader = new DataLakeStoreTransferClient(up, frontEnd2);

            Assert.Throws<AggregateException>(() => uploader.Execute());
            Assert.False(frontEnd2.StreamExists(up.TargetStreamPath), "Target stream should not have been created");

            // now use the good front end
            up = CreateParameters(isResume: true, isDownload: true, targetStreamPath: _downloadFilePath, isOverwrite: true, filePath: up.InputFilePath);
            uploader = new DataLakeStoreTransferClient(up, backingFrontEnd);
            
            //resume the download but point it to the real back-end, which doesn't throw exceptions
            try
            {
                uploader.Execute();
            }
            finally
            {
                uploader.DeleteMetadataFile();
            }

            VerifyFileUploadedSuccessfully(up, backingFrontEnd);
        }

        /// <summary>
        /// Tests the upload case with only 1 segment (since that is an optimization of the broader case).
        /// </summary>
        [Fact]
        public void DataLakeUploader_UploadDownloadSingleSegment()
        {
            var frontEnd = new InMemoryFrontEnd();
            var up = new TransferParameters(
                inputFilePath: _smallFilePath,
                targetStreamPath: "1",
                perFileThreadCount: ThreadCount,
                accountName: "foo",
                isResume: false,
                maxSegmentLength: 4 * 1024 * 1024,
                localMetadataLocation: Path.GetTempPath());

            File.WriteAllBytes(_smallFilePath, _smallFileData);

            var uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.Execute();

            VerifyFileUploadedSuccessfully(up, frontEnd, _smallFileData);
            up = new TransferParameters(
                inputFilePath: "1",
                targetStreamPath: _downloadFilePath,
                perFileThreadCount: ThreadCount,
                accountName: "foo",
                isResume: false,
                isOverwrite: true,
                isDownload: true,
                maxSegmentLength: 4 * 1024 * 1024,
                localMetadataLocation: Path.GetTempPath());
            
            // now download
            uploader = new DataLakeStoreTransferClient(up, frontEnd);
            uploader.Execute();
            VerifyFileUploadedSuccessfully(up, frontEnd, _smallFileData);

        }

        #endregion
        
        #region Test helpers

        /// <summary>
        /// Creates a parameter object.
        /// </summary>
        /// <param name="isResume">Whether to resume.</param>
        /// <param name="isOverwrite">Whether to enable overwrite.</param>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private TransferParameters CreateParameters(bool isResume, bool isOverwrite = false, string filePath = null, bool isRecursive = false, bool isDownload = false, string targetStreamPath = "1")
        {
            if (filePath == null)
            {
                if (isRecursive)
                {
                    filePath = Path.GetDirectoryName(_largeFilePath);
                }
                else
                {
                    filePath = _largeFilePath;
                }
            }
            return new TransferParameters(
                inputFilePath: filePath,
                targetStreamPath: targetStreamPath,
                accountName: "foo",
                useSegmentBlockBackOffRetryStrategy: false,
                perFileThreadCount: ThreadCount,
                isOverwrite: isOverwrite,
                isResume: isResume,
                isRecursive: isRecursive,
                isDownload: isDownload,
                maxSegmentLength: 4 * 1024 * 1024,
                concurrentFileCount: 2,
                localMetadataLocation: Path.GetTempPath());
        }

        /// <summary>
        /// Verifies the file was successfully uploaded.
        /// </summary>
        /// <param name="up">The upload parameters.</param>
        /// <param name="frontEnd">The front end.</param>
        private void VerifyFileUploadedSuccessfully(TransferParameters up, InMemoryFrontEnd frontEnd)
        {
            if (up.IsRecursive)
            {
                var fileList = new Dictionary<string, byte[]>
                {
                    {string.Format("{0}/{1}", up.TargetStreamPath, Path.GetFileName(_largeFilePath)), _largeFileData },
                    {string.Format("{0}/{1}", up.TargetStreamPath, Path.GetFileName(_smallFilePath)), _smallFileData },
                    {string.Format("{0}/{1}", up.TargetStreamPath, Path.GetFileName(_downloadFilePath)), _smallFileData }
                };

                VerifyFileUploadedSuccessfully(fileList, frontEnd, up.IsDownload);
            }
            else
            {
                VerifyFileUploadedSuccessfully(up, frontEnd, _largeFileData);
            }
        }

        /// <summary>
        /// Verifies the file was successfully uploaded.
        /// </summary>
        /// <param name="up">The upload parameters.</param>
        /// <param name="frontEnd">The front end.</param>
        /// <param name="fileContents">The file contents.</param>
        private void VerifyFileUploadedSuccessfully(TransferParameters up, InMemoryFrontEnd frontEnd, byte[] fileContents)
        {
            VerifyFileUploadedSuccessfully(new Dictionary<string, byte[]> { { up.TargetStreamPath, fileContents } }, frontEnd, up.IsDownload);
        }

        /// <summary>
        /// Verifies the file was successfully uploaded.
        /// </summary>
        /// <param name="targetPathsAndData">The target paths and data for each path.</param>
        /// <param name="frontEnd">The front end to use.</param>
        private void VerifyFileUploadedSuccessfully(Dictionary<string, byte[]> targetPathsAndData, InMemoryFrontEnd frontEnd, bool isDownload)
        {
            var streamCount = targetPathsAndData.Keys.Count;
            Assert.Equal(streamCount, frontEnd.StreamCount);
            foreach (var path in targetPathsAndData.Keys)
            {
                Assert.True(frontEnd.StreamExists(path, isDownload), "Uploaded stream does not exist");
                Assert.Equal(targetPathsAndData[path].Length, frontEnd.GetStreamLength(path, isDownload));

                var uploadedData = frontEnd.GetStreamContents(path, isDownload);
                AssertExtensions.AreEqual(targetPathsAndData[path], uploadedData, "Uploaded stream is not binary identical to input file");
            }
        }

        /// <summary>
        /// Verifies the progress status.
        /// </summary>
        /// <param name="progress">The upload progress.</param>
        /// <param name="fileLength">The file length.</param>
        private void VerifyProgressStatus(TransferProgress progress, long fileLength)
        {
            Assert.Equal(fileLength, progress.TotalFileLength);
            Assert.True(1 <= progress.TotalSegmentCount, "UploadProgress: Unexpected value for TotalSegmentCount");
            Assert.Equal(progress.TotalFileLength, progress.TransferredByteCount);

            long uploadedByteSum = 0;
            for (int i = 0; i < progress.TotalSegmentCount; i++)
            {
                var segmentProgress = progress.GetSegmentProgress(i);
                Assert.False(segmentProgress.IsFailed, string.Format("UploadProgress: Segment {0} seems to have failed", i));
                Assert.Equal(i, segmentProgress.SegmentNumber);
                Assert.Equal(segmentProgress.Length, segmentProgress.TransferredByteCount);
                uploadedByteSum += segmentProgress.TransferredByteCount;
            }

            Assert.Equal(progress.TransferredByteCount, uploadedByteSum);
        }

        /// <summary>
        /// Verifies the progress status.
        /// </summary>
        /// <param name="progress">The progress.</param>
        /// <param name="totalFileLength">Total length of the file.</param>
        /// <param name="totalFiles">The total files.</param>
        private void VerifyFolderProgressStatus(TransferFolderProgress progress, long totalFileLength, int totalFiles)
        {
            Assert.Equal(totalFileLength, progress.TotalFileLength);
            Assert.Equal(totalFiles, progress.TotalFileCount);
            Assert.Equal(progress.TotalFileCount, progress.TransferredFileCount);
            Assert.Equal(progress.TotalFileLength, progress.TransferredByteCount);

            for (int i = 0; i < progress.TotalFileCount; i++)
            {
                var eachProgress = progress.GetSegmentProgress(i);
                VerifyProgressStatus(eachProgress, eachProgress.TotalFileLength);
            }
        }

        private class IntentionalException : Exception { }

        #endregion
    }
}
