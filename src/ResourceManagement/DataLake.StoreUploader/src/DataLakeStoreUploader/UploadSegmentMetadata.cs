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
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents metadata for a particular file segment.
    /// </summary>
    [DebuggerDisplay("Segment {SegmentNumber}, Length = {Length}, Status = {Status}")]
    [DataContract(Name = "Segment")]
    public class UploadSegmentMetadata
    {

        #region Constructor

        /// <summary>
        /// Required by XmlSerializer
        /// </summary>
        internal UploadSegmentMetadata()
        {
        }

        /// <summary>
        /// Creates a new UploadSegmentMetadata with the given segment number.
        /// </summary>
        /// <param name="segmentNumber"></param>
        /// <param name="metadata"></param>
        internal UploadSegmentMetadata(int segmentNumber, UploadMetadata metadata)
        {
            this.SegmentNumber = segmentNumber;
            this.Status = SegmentUploadStatus.Pending;
            string ignored;
            var targetStreamName = metadata.SplitTargetStreamPathByName(out ignored);
            this.Path = string.Format("{0}/{1}.{2}.segment{3}", metadata.SegmentStreamDirectory, targetStreamName, metadata.UploadId, this.SegmentNumber);
            this.Offset = this.SegmentNumber * metadata.SegmentLength; // segment number is zero-based
            this.Length = CalculateSegmentLength(this.SegmentNumber, metadata);
        }

        #endregion

        #region Segment Length Calculation

        /// <summary>
        /// Calculates the length of a typical (non-terminal) segment for a file of the given length that is split into the given number of segments.
        /// </summary>
        /// <param name="fileLength">The length of the file, in bytes.</param>
        /// <param name="segmentCount">The number of segments to split the file into.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Number of segments must be a positive integer</exception>
        public static long CalculateSegmentLength(long fileLength, int segmentCount)
        {
            if (segmentCount < 0)
            {
                throw new ArgumentException("Number of segments must be a positive integer");
            }

            if (segmentCount == 0)
            {
                // In this case, we are attempting to upload an empty file, 
                // in which case the uploader should just return
                return 0;
            }

            long segmentLength = fileLength / segmentCount;

            //if the file cannot be split into even segments, we need to increment the typical segment length by 1 
            //in order to have the last segment in the file be smaller than the other ones.
            if (fileLength % segmentCount != 0)
            {
                //BUT we can only do this IF this wouldn't cause the last segment to have a negative length
                if (fileLength - (segmentCount - 1) * (segmentLength + 1) > 0)
                {
                    segmentLength++;
                }
            }

            return segmentLength;
        }

        /// <summary>
        /// Calculates the length of the segment with given number for a file with given length that is split into the given number of segments.
        /// </summary>
        /// <param name="segmentNumber">The segment number.</param>
        /// <param name="metadata">The metadata for the current upload.</param>
        /// <returns></returns>
        internal static long CalculateSegmentLength(int segmentNumber, UploadMetadata metadata)
        {
            if (segmentNumber < 0 || segmentNumber >= metadata.SegmentCount)
            {
                throw new ArgumentOutOfRangeException("segmentNumber", "Segment Number must be at least zero and less than the total number of segments");
            }

            if (metadata.FileLength < 0)
            {
                throw new ArgumentException("fileLength", "Cannot have a negative file length");
            }

            //verify if the last segment would have a positive value
            long lastSegmentLength = metadata.FileLength - (metadata.SegmentCount - 1) * metadata.SegmentLength;
            if (lastSegmentLength < 0)
            {
                throw new ArgumentException("The given values for segmentCount and segmentLength cannot possibly be used to split a file with the given fileLength (the last segment would have a negative length)");
            }
            else if (lastSegmentLength > metadata.SegmentLength)
            {
                //verify if the given segmentCount and segmentLength combination would produce an even split
                if (metadata.FileLength - (metadata.SegmentCount - 1) * (metadata.SegmentLength + 1) > 0)
                {
                    throw new ArgumentException("The given values for segmentCount and segmentLength would not produce an even split of a file with given fileLength");
                }
            }

            if (metadata.FileLength == 0)
            {
                return 0;
            }

            //all segments except the last one have the same length;
            //the last one only has the 'full' length if by some miracle the file length is a perfect multiple of the Segment Length
            if (segmentNumber < metadata.SegmentCount - 1)
            {
                return metadata.SegmentLength;
            }
            else
            {
                return lastSegmentLength;
            }
        }

        #endregion

        #region Segment Count Calculation

        /// <summary>
        /// </summary>
        private const int BaseMultiplier = 50;

        /// <summary>
        /// The Reducer is the number of times the length of the file should increase in order to inflate the number of segments by a factor of 'Multiplier'.
        /// See class description for more details.
        /// </summary>
        private const int SegmentCountReducer = 10;

        /// <summary>
        /// The Multiplier is the number of times the segment count is inflated when the length of the file increases by a factor of 'Reducer'.
        /// See class description for more details.
        /// </summary>
        private const int SegmentCountMultiplier = 2;

        /// <summary>
        /// The minimum number of bytes in a segment. For best performance, should be sync-ed with the upload buffer length.
        /// </summary>
        internal const int MinimumSegmentSize = SingleSegmentUploader.BufferLength;

        /// <summary>
        /// Calculates the number of segments a file of the given length should be split into.
        /// The method to calculate this is based on some empirical measurements that allows both the number of segments and the length of each segment to grow as the input file size grows.
        /// They both grow on a logarithmic pattern as the file length increases.
        /// The formula is roughly this:
        /// * Multiplier = Min(100, 50 * 2 ^ Log10(FileLengthInGB))
        /// * SegmentCount = Max(1, Multiplier * 2 ^ Log10(FileLengthInGB)
        /// Essentially we quadruple the number of segments for each tenfold increase in the file length, with certain caps. The formula is designed to support both small files and
        /// extremely large files (and not cause very small segment lengths or very large number of segments).
        /// </summary>
        /// <param name="fileLength">The length of the file, in bytes.</param>
        /// <returns>
        /// The number of segments to split the file into. Returns 0 if fileLength is 0.
        /// </returns>
        /// <exception cref="System.ArgumentException">File Length cannot be negative</exception>
        public static int CalculateSegmentCount(long fileLength)
        {
            if (fileLength < 0)
            {
                throw new ArgumentException("File Length cannot be negative");
            }

            if (fileLength == 0)
            {
                //empty file => no segments
                return 0;
            }

            int minNumberOfSegments = (int)Math.Max(1, fileLength / MinimumSegmentSize);

            //convert the file length into GB
            double lengthInGb = fileLength / 1024.0 / 1024 / 1024;

            //apply the formula described in the class description and return the result
            double baseMultiplier = CalculateBaseMultiplier(lengthInGb);
            int segmentCount = (int)(baseMultiplier * Math.Pow(SegmentCountMultiplier, Math.Log(lengthInGb, SegmentCountReducer)));
            if (segmentCount > minNumberOfSegments)
            {
                segmentCount = minNumberOfSegments;
            }

            if (segmentCount < 1)
            {
                segmentCount = 1;
            }

            return segmentCount;
        }

        private static double CalculateBaseMultiplier(double lengthInGb)
        {
            double value = BaseMultiplier * Math.Pow(2, Math.Log10(lengthInGb));
            return Math.Min(100, value);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating the number (sequence) of the segment in the file.
        /// </summary>
        /// <value>
        /// The segment number.
        /// </value>
        [DataMember(Name = "Number")]
        public int SegmentNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the starting offset of the segment in the file.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        [DataMember(Name = "Offset")]
        public long Offset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the size of the segment (in bytes).
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        [DataMember(Name = "Length")]
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the current upload status for this segment.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DataMember(Name = "Status")]
        public SegmentUploadStatus Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the stream path assigned to this segment.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        [DataMember(Name = "Path")]
        public string Path { get; set; }

        #endregion

    }
}
