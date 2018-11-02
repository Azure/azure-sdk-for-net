﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DataLakeStore.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using Microsoft.Azure.Management.DataLake.Store;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    public class SingleSegmentUploaderTests : IDisposable
    {

        #region Private

        private readonly byte[] _smallFileContents = new byte[10 * 1024]; //10KB file
        private string _smallFilePath;

        private readonly byte[] _largeFileContents = new byte[10 * 1024 * 1024]; //10MB file
        private string _largeFilePath;
        
        private readonly byte[] _textFileContents = new byte[20 * 1024 * 1024]; //20MB file
        private string _textFilePath;

        private readonly byte[] _badTextFileContents = new byte[10 * 1024 * 1024]; //10MB file
        private string _badTextFilePath;

        private const string StreamPath = "abc";

        #endregion

        #region Test Setup & Teardown

        public SingleSegmentUploaderTests()
        {
            var runFolder = Guid.NewGuid();
            TestHelpers.GenerateFileData(_smallFileContents, runFolder.ToString(), out _smallFilePath);
            TestHelpers.GenerateFileData(_largeFileContents, runFolder.ToString(), out _largeFilePath);
            TestHelpers.GenerateTextFileData(_textFileContents, 1, SingleSegmentUploader.BufferLength, out _textFilePath);
            TestHelpers.GenerateTextFileData(_badTextFileContents, SingleSegmentUploader.BufferLength + 1, SingleSegmentUploader.BufferLength + 2, out _badTextFilePath);
        }

        public void Dispose()
        {
            var tempDir = Path.GetDirectoryName(_largeFilePath);
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }

            if (File.Exists(_textFilePath))
            {
                File.Delete(_textFilePath);
            }

            if (File.Exists(_badTextFilePath))
            {
                File.Delete(_badTextFilePath);
            }
        }

        #endregion

        #region Tests

        /// <summary>
        /// Tests a simple upload consisting of a single block (the file is small enough to be uploaded without splitting into smaller buffers)
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_UploadSingleBlockStream()
        {
            var fe = new InMemoryFrontEnd();

            var metadata = CreateMetadata(_smallFilePath, _smallFileContents.Length);
            var progressTracker = new TestProgressTracker();
            var ssu = new SingleSegmentUploader(0, metadata, fe, progressTracker);
            ssu.UseBackOffRetryStrategy = false;
            ssu.Upload();

            var actualContents = fe.GetStreamContents(StreamPath);
            AssertExtensions.AreEqual(_smallFileContents, actualContents, "Unexpected uploaded stream contents.");
            VerifyTracker(progressTracker, true);
        }

        /// <summary>
        /// Tests an uploading consisting of a larger file, which will need to be uploaded in sequential buffers.
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_UploadMultiBlockStream()
        {
            var fe = new InMemoryFrontEnd();

            var metadata = CreateMetadata(_largeFilePath, _largeFileContents.Length);
            var progressTracker = new TestProgressTracker();
            var ssu = new SingleSegmentUploader(0, metadata, fe, progressTracker);
            ssu.UseBackOffRetryStrategy = false;
            ssu.Upload();

            var actualContents = fe.GetStreamContents(StreamPath);
            AssertExtensions.AreEqual(_largeFileContents, actualContents, "Unexpected uploaded stream contents.");
            VerifyTracker(progressTracker, true);
        }

        /// <summary>
        /// Tests the case when only a part of the file is to be uploaded (i.e., all other cases feed in the entire file)
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_UploadFileRange()
        {
            int length = _smallFileContents.Length / 3;

            var fe = new InMemoryFrontEnd();

            var metadata = CreateMetadata(_smallFilePath, length);
            var progressTracker = new TestProgressTracker();
            var ssu = new SingleSegmentUploader(0, metadata, fe, progressTracker);
            ssu.UseBackOffRetryStrategy = false;
            ssu.Upload();

            var actualContents = fe.GetStreamContents(StreamPath);
            var expectedContents = new byte[length];
            Array.Copy(_smallFileContents, 0, expectedContents, 0, length);
            AssertExtensions.AreEqual(expectedContents, actualContents, "Unexpected uploaded stream contents.");
            VerifyTracker(progressTracker, true);
        }

        /// <summary>
        /// Tests the case when an existing stream with the same name already exists on the server. That stream needs to be fully replaced with the new data.
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_TargetStreamExists()
        {
            var fe = new InMemoryFrontEnd();

            //load up an existing stream
            fe.CreateStream(StreamPath, true, null, 0);
            var data = Encoding.UTF8.GetBytes("random");
            fe.AppendToStream(StreamPath, data, 0, (int)data.Length);

            //force a re-upload of the stream
            var metadata = CreateMetadata(_smallFilePath, _smallFileContents.Length);
            var ssu = new SingleSegmentUploader(0, metadata, fe);
            ssu.UseBackOffRetryStrategy = false;
            ssu.Upload();

            var actualContents = fe.GetStreamContents(StreamPath);
            AssertExtensions.AreEqual(_smallFileContents, actualContents, "Unexpected uploaded stream contents.");
        }

        /// <summary>
        /// Tests the case when the upload did "succeed", but the server reports back a different stream length than expected.
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_VerifyUploadStreamFails()
        {
            //create a mock front end which doesn't do anything
            var workingFrontEnd = new InMemoryFrontEnd();
            var fe = new MockableFrontEnd(workingFrontEnd);
            
            fe.CreateStreamImplementation = (streamPath, overwrite, data, byteCount) => { };
            fe.DeleteStreamImplementation = (streamPath, recurse, isDownload) => { };
            fe.StreamExistsImplementation = (streamPath, isDownload) => { return true; };
            fe.AppendToStreamImplementation = (streamPath, data, offset, byteCount) => { };
            fe.GetStreamLengthImplementation = (streamPath, isDownload) => { return 0; };

            //upload some data
            var metadata = CreateMetadata(_smallFilePath, _smallFileContents.Length);
            var ssu = new SingleSegmentUploader(0, metadata, fe);
            ssu.UseBackOffRetryStrategy = false;

            //the Upload method should fail if it cannot verify that the stream was uploaded after the upload (i.e., it will get a length of 0 at the end)
            Assert.Throws<TransferFailedException>(() => { ssu.Upload(); });
        }

        /// <summary>
        /// Tests the case when the SingleSegmentUploader should upload a non-binary file (i.e., split on record boundaries).
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_UploadNonBinaryFile()
        {
            var fe = new InMemoryFrontEnd();

            var metadata = CreateMetadata(_textFilePath, _textFileContents.Length);
            metadata.IsBinary = false;
            var progressTracker = new TestProgressTracker();
            var ssu = new SingleSegmentUploader(0, metadata, fe, progressTracker);
            ssu.UseBackOffRetryStrategy = false;
            ssu.Upload();

            //verify the entire file is identical to the source file
            var actualContents = fe.GetStreamContents(StreamPath);
            AssertExtensions.AreEqual(_textFileContents, actualContents, "Unexpected uploaded stream contents.");

            //verify the append blocks start/end on record boundaries
            var appendBlocks = fe.GetAppendBlocks(StreamPath);
            int lengthSoFar = 0;
            foreach (var append in appendBlocks)
            {
                lengthSoFar += append.Length;
                if (lengthSoFar < actualContents.Length)
                {
                    Assert.Equal('\n', (char)append[append.Length - 1]);
                }
            }

            VerifyTracker(progressTracker, true);
        }

        /// <summary>
        /// Tests the case when the SingleSegmentUploader tries upload a non-binary file (i.e., split on record boundaries), but at least one record is larger than the max allowed size.
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_UploadNonBinaryFileTooLargeRecord()
        {
            var fe = new InMemoryFrontEnd();

            var metadata = CreateMetadata(_badTextFilePath, _badTextFileContents.Length);
            metadata.IsBinary = false;
            var progressTracker = new TestProgressTracker();
            var ssu = new SingleSegmentUploader(0, metadata, fe, progressTracker);
            ssu.UseBackOffRetryStrategy = false;
            Assert.Throws<TransferFailedException>(() => ssu.Upload());
        }

        /// <summary>
        /// Tests various scenarios where the upload will fail repeatedly; verifies that the uploader will retry a certain number of times before finally giving up
        /// </summary>
        [Fact]
        public void SingleSegmentUploader_RetryBlock()
        {
            TestRetryBlock(0);
            TestRetryBlock(1);
            TestRetryBlock(2);
            TestRetryBlock(3);
            TestRetryBlock(4);
            TestRetryBlock(5);
        }

        internal void TestRetryBlock(int failCount)
        {
            bool expectSuccess = failCount < SingleSegmentUploader.MaxBufferUploadAttemptCount;

            int callCount = 0;

            var workingFrontEnd = new InMemoryFrontEnd();
            var fe = new MockableFrontEnd(workingFrontEnd);
            fe.CreateStreamImplementation =
                (streamPath, overwrite, data, byteCount) =>
                {
                    callCount++;
                    if (callCount <= failCount)
                    {
                        throw new IntentionalException();
                    }
                    workingFrontEnd.CreateStream(streamPath, overwrite, data, byteCount);
                };

            fe.AppendToStreamImplementation =
                (streamPath, data, offset, byteCount) =>
                {
                    callCount++;
                    if (callCount <= failCount)
                    {
                        throw new IntentionalException();
                    }
                    workingFrontEnd.AppendToStream(streamPath, data, offset, byteCount);
                };

            var metadata = CreateMetadata(_smallFilePath, _smallFileContents.Length);
            var progressTracker = new TestProgressTracker();
            var ssu = new SingleSegmentUploader(0, metadata, fe, progressTracker);
            ssu.UseBackOffRetryStrategy = false;

            if (expectSuccess)
            {
                ssu.Upload();
                var actualContents = workingFrontEnd.GetStreamContents(StreamPath);
                AssertExtensions.AreEqual(_smallFileContents, actualContents, "Unexpected uploaded stream contents.");
            }
            else
            {
                Assert.Throws<IntentionalException>(() => { ssu.Upload(); });
            }
            VerifyTracker(progressTracker, expectSuccess);
        }

        private TransferMetadata CreateMetadata(string filePath, long fileLength)
        {
            var metadata = new TransferMetadata()
            {
                InputFilePath = filePath,
                FileLength = fileLength,
                TargetStreamPath = StreamPath,
                SegmentCount = 1,
                SegmentLength = TransferSegmentMetadata.CalculateSegmentLength(fileLength, 1),
                Segments = new TransferSegmentMetadata[1],
                IsBinary = true
            };

            metadata.Segments[0] = new TransferSegmentMetadata(0, metadata);
            metadata.Segments[0].Path = metadata.TargetStreamPath;
            return metadata;
        }

        private void VerifyTracker(TestProgressTracker tracker, bool isSuccessfulUpload)
        {
            Assert.True(0 < tracker.Reports.Count, "No progress reports tracked");

            long lastIndication = 0;
            for (int i = 0; i < tracker.Reports.Count; i++)
            {
                var currentReport = tracker.Reports[i];
                if (!isSuccessfulUpload && i == tracker.Reports.Count - 1)
                {
                    Assert.True(currentReport.IsFailed, "Last report did not indicate failure for a failed upload");
                    Assert.Equal(lastIndication, currentReport.TransferredByteCount);
                }
                else
                {
                    Assert.False(currentReport.IsFailed, "Progress report indicated failure but failure was not expected");
                    Assert.True(lastIndication < currentReport.TransferredByteCount, "Progress reports are not in increasing order");
                }
                lastIndication = currentReport.TransferredByteCount;
            }
        }

        #endregion

        private class IntentionalException : Exception { }

        private class TestProgressTracker : IProgress<SegmentTransferProgress>
        {
            public TestProgressTracker()
            {
                this.Reports = new List<SegmentTransferProgress>();
            }

            public void Report(SegmentTransferProgress value)
            {
                this.Reports.Add(value);
            }

            public IList<SegmentTransferProgress> Reports{ get; private set; }
        }

    }
}
