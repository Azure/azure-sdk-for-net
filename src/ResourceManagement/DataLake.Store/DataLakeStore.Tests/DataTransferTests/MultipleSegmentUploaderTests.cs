// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DataLakeStore.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using Microsoft.Azure.Management.DataLake.Store;
    using Xunit;
    
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    public class MultipleSegmentUploaderTests : IDisposable
    {

        private readonly byte[] _smallFileContents = new byte[10 * 1024]; //10KB file
        private string _smallFilePath;

        #region Test Setup & Teardown
        public MultipleSegmentUploaderTests()
        {
            GenerateFileData(_smallFileContents, ref _smallFilePath);
        }

        private void GenerateFileData(byte[] contents, ref string filePath)
        {
            filePath = Path.GetTempFileName();

            var rnd = new Random(0);
            rnd.NextBytes(contents);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.WriteAllBytes(filePath, contents);
        }

        public void Dispose()
        {
            if (File.Exists(_smallFilePath))
            {
                File.Delete(_smallFilePath);
            }
        }

        #endregion

        #region Tests

        /// <summary>
        /// Tests an uneventful upload from scratch made of 1 segment.
        /// </summary>
        [Fact]
        public void MultipleSegmentUploader_OneSegment()
        {
            var fe = new InMemoryFrontEnd();
            var metadata = CreateMetadata(1);
            try
            {
                var msu = new MultipleSegmentUploader(metadata, 1, fe);
                msu.UseSegmentBlockBackOffRetryStrategy = false;
                msu.Upload();
                VerifyTargetStreamsAreComplete(metadata, fe);
            }
            finally
            {
                metadata.DeleteFile();
            }
        }

        /// <summary>
        /// Tests an uneventful upload from scratch made of several segments
        /// </summary>
        [Fact]
        public void MultipleSegmentUploader_MultipleSegments()
        {
            var fe = new InMemoryFrontEnd();
            var metadata = CreateMetadata(10);
            try
            {
                var msu = new MultipleSegmentUploader(metadata, 1, fe);
                msu.UseSegmentBlockBackOffRetryStrategy = false;
                msu.Upload();
                VerifyTargetStreamsAreComplete(metadata, fe);
            }
            finally
            {
                metadata.DeleteFile();
            }
        }

        /// <summary>
        /// Tests an uneventful upload from scratch made of several segments
        /// </summary>
        [Fact]
        public void MultipleSegmentUploader_MultipleSegmentsAndMultipleThreads()
        {
            var fe = new InMemoryFrontEnd();
            var metadata = CreateMetadata(10);
            int threadCount = metadata.SegmentCount * 10; //intentionally setting this higher than the # of segments
            try
            {
                var msu = new MultipleSegmentUploader(metadata, threadCount, fe);
                msu.UseSegmentBlockBackOffRetryStrategy = false;
                msu.Upload();
                VerifyTargetStreamsAreComplete(metadata, fe);
            }
            finally
            {
                metadata.DeleteFile();
            }
        }

        /// <summary>
        /// Tests an uneventful upload from resume made of several segments
        /// </summary>
        [Fact]
        public void MultipleSegmentUploader_ResumedUploadWithMultipleSegments()
        {
            //the strategy here is to upload everything, then delete a set of the segments, and verify that a resume will pick up the slack

            var fe = new InMemoryFrontEnd();
            var metadata = CreateMetadata(10);

            try
            {
                var msu = new MultipleSegmentUploader(metadata, 1, fe);
                msu.UseSegmentBlockBackOffRetryStrategy = false;
                msu.Upload();
                VerifyTargetStreamsAreComplete(metadata, fe);

                //delete about 50% of segments
                for (int i = 0; i < metadata.SegmentCount; i++)
                {
                    var currentSegment = metadata.Segments[i];
                    if (i % 2 == 0)
                    {
                        currentSegment.Status = SegmentTransferStatus.Pending;
                        fe.DeleteStream(currentSegment.Path);
                    }
                }

                //re-upload everything
                msu = new MultipleSegmentUploader(metadata, 1, fe);
                msu.Upload();
                VerifyTargetStreamsAreComplete(metadata, fe);
            }
            finally
            {
                metadata.DeleteFile();
            }
        }

        /// <summary>
        /// Tests an upload made of several segments, where 
        /// * some fail a couple of times => upload can finish.
        /// * some fail too many times => upload will not finish
        /// </summary>
        [Fact]
        public void MultipleSegmentUploader_SegmentInstability()
        {
            TestRetry(0);
            TestRetry(1);
            TestRetry(2);
            TestRetry(3);
            TestRetry(4);
            TestRetry(5);
        }

        private void TestRetry(int segmentFailCount)
        {
            //we only have access to the underlying FrontEnd, so we need to simulate many exceptions in order to force a segment to fail the upload (multiply by SingleSegmentUploader.MaxBufferUploadAttemptAccount)
            //this only works because we have a small file, which we know will fit in only one buffer (for a larger file, more complex operations are necessary)
            int actualfailCount = segmentFailCount * SingleSegmentUploader.MaxBufferUploadAttemptCount;
            bool expectSuccess = segmentFailCount < MultipleSegmentUploader.MaxUploadAttemptCount;

            int callCount = 0;

            //create a mock front end sitting on top of a working front end that simulates some erros for some time
            var workingFrontEnd = new InMemoryFrontEnd();
            var fe = new MockableFrontEnd(workingFrontEnd);
            fe.CreateStreamImplementation =
                (streamPath, overwrite, data, byteCount) =>
                {
                    callCount++;
                    if (callCount <= actualfailCount)
                    {
                        throw new IntentionalException();
                    }
                    workingFrontEnd.CreateStream(streamPath, overwrite, data, byteCount);
                };

            fe.AppendToStreamImplementation =
                (streamPath, data, offset, byteCount) =>
                {
                    callCount++;
                    if (callCount <= actualfailCount)
                    {
                        throw new IntentionalException();
                    }
                    workingFrontEnd.AppendToStream(streamPath, data, offset, byteCount);
                };

            var metadata = CreateMetadata(1);
            try
            {
                var msu = new MultipleSegmentUploader(metadata, 1, fe);
                msu.UseSegmentBlockBackOffRetryStrategy = false;

                if (expectSuccess)
                {
                    //the Upload method should not throw any exceptions in this case
                    msu.Upload();
                    
                    //if we are expecting success, verify that both the metadata and the target streams are complete
                    VerifyTargetStreamsAreComplete(metadata, workingFrontEnd);
                }
                else
                {
                    //the Upload method should throw an aggregate exception in this case
                    Assert.Throws<AggregateException>(() => { msu.Upload(); });

                    //if we do not expect success, verify that at least 1 segment was marked as Failed
                    Assert.True(metadata.Segments.Any(s => s.Status == SegmentTransferStatus.Failed), "Could not find any failed segments");

                    //for every other segment, verify it was completed OK
                    foreach (var segment in metadata.Segments.Where(s => s.Status != SegmentTransferStatus.Failed))
                    {
                        VerifyTargetStreamIsComplete(segment, metadata, workingFrontEnd);
                    }
                }
            }
            finally
            {
                metadata.DeleteFile();
            }
        }

        #endregion

        #region Test helpers

        private void VerifyTargetStreamsAreComplete(TransferMetadata metadata, InMemoryFrontEnd fe)
        {
            foreach (var segment in metadata.Segments)
            {
                VerifyTargetStreamIsComplete(segment, metadata, fe);
            }
        }

        private void VerifyTargetStreamIsComplete(TransferSegmentMetadata segmentMetadata, TransferMetadata metadata, InMemoryFrontEnd frontEnd)
        {
            Assert.Equal(SegmentTransferStatus.Complete, segmentMetadata.Status);
            Assert.True(frontEnd.StreamExists(segmentMetadata.Path), string.Format("Segment {0} was not uploaded", segmentMetadata.SegmentNumber));
            Assert.Equal(segmentMetadata.Length, frontEnd.GetStreamLength(segmentMetadata.Path));

            var actualContents = frontEnd.GetStreamContents(segmentMetadata.Path);
            var expectedContents = GetExpectedContents(segmentMetadata, metadata);
            AssertExtensions.AreEqual(expectedContents, actualContents, "Segment {0} has unexpected contents", segmentMetadata.SegmentNumber);
        }


        private byte[] GetExpectedContents(TransferSegmentMetadata segment, TransferMetadata metadata)
        {
            byte[] result = new byte[segment.Length];
            Array.Copy(_smallFileContents, (int)(segment.SegmentNumber * metadata.SegmentLength), result, 0, (int)segment.Length);
            return result;
        }

        private TransferMetadata CreateMetadata(int segmentCount)
        {
            var path = Path.GetTempFileName();
            var metadata = new TransferMetadata()
            {
                MetadataFilePath = path,
                InputFilePath = _smallFilePath,
                FileLength = _smallFileContents.Length,
                SegmentCount = segmentCount,
                SegmentLength = TransferSegmentMetadata.CalculateSegmentLength(_smallFileContents.Length, segmentCount),
                Segments = new TransferSegmentMetadata[segmentCount],
                TargetStreamPath = "abc",
                TransferId = "123",
                IsBinary = true
            };

            long offset = 0;
            for (int i = 0; i < segmentCount; i++)
            {
                long length = TransferSegmentMetadata.CalculateSegmentLength(i, metadata);
                metadata.Segments[i] = new TransferSegmentMetadata()
                {
                    SegmentNumber = i,
                    Offset = offset,
                    Status = SegmentTransferStatus.Pending,
                    Length = length,
                    Path = string.Format("{0}.{1}.segment{2}", metadata.TargetStreamPath, metadata.TransferId, i)
                };
                offset += length;
            }

            return metadata;
        }

        private class IntentionalException : Exception { }

        #endregion

    }
}
