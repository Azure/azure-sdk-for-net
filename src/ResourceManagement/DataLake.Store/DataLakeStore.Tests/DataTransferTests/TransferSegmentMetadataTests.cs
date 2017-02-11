// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DataLakeStore.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Azure.Management.DataLake.Store;
    using Xunit;
    
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    public class TransferSegmentMetadataTests
    {

        /// <summary>
        /// Tests that segment count calculation works (it's hard to verify correctness without having access to the data that the base class has, 
        /// so we'll just check the boundary conditions, that it's monotonically increasing and that it doesn't throw exceptions for various inputs.
        /// </summary>
        [Fact]
        public void UploadMetadata_CalculateSegmentCount()
        {
            Assert.Throws<ArgumentException>(() => { TransferSegmentMetadata.CalculateSegmentCount(-1); });

            Assert.Equal(0, TransferSegmentMetadata.CalculateSegmentCount(0));

            long maxLength = 100 * (long)Math.Pow(2, 40);//100 TB
            long increment = 10 * (long)Math.Pow(2, 30); //10GB
            int lastValue = 0;
            for (long length = (long)Math.Pow(2, 20); length < maxLength; length += increment)
            {
                int value = TransferSegmentMetadata.CalculateSegmentCount(length);
                Assert.True(lastValue <= value, "Function is not monotonically increasing");
                lastValue = value;
            }
        }

        /// <summary>
        /// Tests the correct calculation for a typical segment length.
        /// </summary>
        [Fact]
        public void UploadSegmentMetadata_CalculateTypicalSegmentLength()
        {
            Assert.Throws<ArgumentException>(() => { TransferSegmentMetadata.CalculateSegmentLength(1000, -1); });

            const int maxSegmentCount = 16536;
            long fileLength = (long)Math.Pow(2, 30); // see comment below about actually making this larger than Int32.MaxValue
            long segmentLength;

            for (int segmentCount = 1; segmentCount < maxSegmentCount; segmentCount++)
            {
                segmentLength = TransferSegmentMetadata.CalculateSegmentLength(fileLength, segmentCount);

                //the next two asserts verify that the value calculated will split the input file into a balanced set of segments;
                //all the segments should have the same length, except the last one which may have less than that (but never more).
                //a quick heuristic to verify this is: (SegmentLength-1)*SegmentCount < FileLength <= SegmentLength*SegmentCount
                Assert.True(segmentLength * segmentCount >= fileLength, "SegmentLength * SegmentCount must be at least the length of the input file");
                Assert.True((segmentLength - 1) * segmentCount < fileLength, "(SegmentLength - 1) * SegmentCount must be smaller than the length of the input file");
            }

            // test segmentCount == fileLength;
            segmentLength = TransferSegmentMetadata.CalculateSegmentLength(fileLength, (int)fileLength); //for this to work, FileLength must be less than In32.MaxValue
            Assert.Equal(1, segmentLength);
            
           // test that if segment count = 0 then the return value is 0.
            Assert.Equal(
                0,
                TransferSegmentMetadata.CalculateSegmentLength(fileLength, 0));
        }

        /// <summary>
        /// Tests the correct calculation for a particular segment length (ending vs non-ending).
        /// </summary>
        [Fact]
        public void UploadSegmentMetadata_CalculateParticularSegmentLength()
        {
            
            //verify bad inputs
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { TransferSegmentMetadata.CalculateSegmentLength(-1, new TransferMetadata() { FileLength = 10, SegmentCount = 5, SegmentLength = 2 }); });
           
            Assert.Throws<ArgumentOutOfRangeException>(
                () => { TransferSegmentMetadata.CalculateSegmentLength(100, new TransferMetadata() { FileLength = 10, SegmentCount = 5, SegmentLength = 2 }); });
            
            Assert.Throws<ArgumentException>(
                () => { TransferSegmentMetadata.CalculateSegmentLength(1, new TransferMetadata() { FileLength = -10, SegmentCount = 5, SegmentLength = 2 }); });
            
            Assert.Throws<ArgumentException>(
                () => { TransferSegmentMetadata.CalculateSegmentLength(1, new TransferMetadata() { FileLength = 100, SegmentCount = 2, SegmentLength = 2 }); });
           
            Assert.Throws<ArgumentException>(
                () => { TransferSegmentMetadata.CalculateSegmentLength(1, new TransferMetadata() { FileLength = 100, SegmentCount = 5, SegmentLength = 26 }); });

            //test various scenarios with a fixed file length, and varying the segment count from 1 to the FileLength

            int FileLength = 16 * (int)Math.Pow(2, 20);//16MB

            for (int segmentCount = 1; segmentCount <= FileLength; segmentCount += 1024)
            {
                long typicalSegmentLength = TransferSegmentMetadata.CalculateSegmentLength(FileLength, segmentCount);

                var uploadMetadata = new TransferMetadata(){FileLength=FileLength,SegmentCount=segmentCount,SegmentLength=typicalSegmentLength};
                long firstSegmentLength = TransferSegmentMetadata.CalculateSegmentLength(0, uploadMetadata);
                long lastSegmentLength = TransferSegmentMetadata.CalculateSegmentLength(segmentCount - 1, uploadMetadata);

                Assert.Equal(typicalSegmentLength, firstSegmentLength);
                if (segmentCount == 1)
                {
                    Assert.Equal(firstSegmentLength, lastSegmentLength);
                }

                long reconstructedFileLength = typicalSegmentLength * (segmentCount - 1) + lastSegmentLength;
                Assert.Equal(FileLength, reconstructedFileLength);
            }
        }
    }
}
