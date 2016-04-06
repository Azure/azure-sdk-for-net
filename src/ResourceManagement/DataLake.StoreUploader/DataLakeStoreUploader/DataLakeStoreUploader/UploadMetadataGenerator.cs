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

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    internal class UploadMetadataGenerator
    {

        #region Private

        private readonly UploadParameters _parameters;
        private readonly int _maxAppendLength;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of the UploadMetadataGenerator with the given parameters and the default maximum append length.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public UploadMetadataGenerator(UploadParameters parameters)
            : this(parameters, SingleSegmentUploader.BufferLength)
        {
        }

        /// <summary>
        /// Creates a new instance of the UploadMetadataGenerator with the given parameters and the given maximum append length.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="maxAppendLength"></param>
        public UploadMetadataGenerator(UploadParameters parameters, int maxAppendLength)
        {
            _parameters = parameters;
            _maxAppendLength = maxAppendLength;
        }

        #endregion

        #region Metadata Operations

        /// <summary>
        /// Attempts to load the metadata from an existing file in its canonical location.
        /// </summary>
        /// <param name="metadataFilePath">The metadata file path.</param>
        /// <returns></returns>
        public UploadMetadata GetExistingMetadata(string metadataFilePath)
        {
            //load from file (based on input parameters)
            var metadata = UploadMetadata.LoadFrom(metadataFilePath);
            metadata.ValidateConsistency();
            return metadata;
        }    

        /// <summary>
        /// Creates a new metadata based on the given input parameters, and saves it to its canonical location.
        /// </summary>
        /// <returns></returns>
        public UploadMetadata CreateNewMetadata(string metadataFilePath)
        {
            //determine segment count, segment length and Upload Id
            //create metadata
            var metadata = new UploadMetadata(metadataFilePath, _parameters);

            if (!_parameters.IsBinary && metadata.SegmentCount > 1)
            {
                this.AlignSegmentsToRecordBoundaries(metadata);
            }

            //save the initial version
            metadata.Save();

            return metadata;
        }

        /// <summary>
        /// Aligns segments to match record boundaries (where a record boundary = a new line).
        /// If not possible (max record size = 4MB), throws an exception.
        /// </summary>
        /// <param name="metadata"></param>
        private void AlignSegmentsToRecordBoundaries(UploadMetadata metadata)
        {
            int remainingSegments = 0;

            using (var stream = new FileStream(metadata.InputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                long offset = 0;
                for (int i = 0; i < metadata.Segments.Length; i++)
                {
                    var segment = metadata.Segments[i];

                    //updating segment lengths means that both the offset and the length of the next segment needs to be recalculated, to keep the segment lengths somewhat balanced
                    long diff = segment.Offset - offset;
                    segment.Offset = offset;
                    segment.Length += diff;
                    if (segment.Offset >= metadata.FileLength)
                    {
                        continue;
                    }

                    if (segment.SegmentNumber == metadata.Segments.Length - 1)
                    {
                        //last segment picks up the slack
                        segment.Length = metadata.FileLength - segment.Offset;
                    }
                    else
                    {
                        //figure out how much do we need to adjust the length of the segment so it ends on a record boundary (this can be negative or positive)
                        int lengthAdjustment = DetermineLengthAdjustment(segment, stream) + 1;

                        //adjust segment length and offset
                        segment.Length += lengthAdjustment;
                    }
                    offset += segment.Length;
                    remainingSegments++;
                }
            }

            //since we adjusted the segment lengths, it's possible that the last segment(s) became of zero length; so remove it
            var segments = metadata.Segments;
            if (remainingSegments < segments.Length)
            {
                Array.Resize(ref segments, remainingSegments);
                metadata.Segments = segments;
                metadata.SegmentCount = segments.Length;
            }

            //NOTE: we are not validating consistency here; this method is called by CreateNewMetadata which calls Save() after this, which validates consistency anyway.
        }

        /// <summary>
        /// Calculates the value by which we'd need to adjust the length of the given segment, by searching for the nearest newline around it (before and after), 
        /// and returning the distance to it (which can be positive, if after, or negative, if before).
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        /// <exception cref="Microsoft.Azure.Management.DataLake.StoreUploader.UploadFailedException">If no record boundary could be located on either side of the segment end offset within the allowed distance.</exception>
        private int DetermineLengthAdjustment(UploadSegmentMetadata segment, FileStream stream)
        {
            long referenceFileOffset = segment.Offset + segment.Length;
            byte[] buffer = new byte[_maxAppendLength];

            //read 2MB before the segment boundary and 2MB after (for a total of 4MB = max append length)
            int bytesRead = ReadIntoBufferAroundReference(stream, buffer, referenceFileOffset);
            if (bytesRead > 0)
            {
                int middlePoint = bytesRead / 2;
                //search for newline in it
                int newLinePosBefore = StringExtensions.FindNewline(buffer, middlePoint + 1, middlePoint + 1, true);
                
                //in some cases, we may have a newline that is 2 characters long, and it occurrs exactly on the midpoint, which means we won't be able to find its end.
                //see if that's the case, and then search for a new candidate before it.
                if (newLinePosBefore == middlePoint + 1 && buffer[newLinePosBefore] == (byte)'\r')
                {
                    int newNewLinePosBefore = StringExtensions.FindNewline(buffer, middlePoint, middlePoint, true);
                    if (newNewLinePosBefore >= 0)
                    {
                        newLinePosBefore = newNewLinePosBefore;
                    }
                }

                int newLinePosAfter = StringExtensions.FindNewline(buffer, middlePoint, middlePoint, false);
                if (newLinePosAfter == buffer.Length - 1 && buffer[newLinePosAfter] == (byte)'\r' && newLinePosBefore >= 0)
                {
                    newLinePosAfter = -1;
                }

                int closestNewLinePos = FindClosestToCenter(newLinePosBefore, newLinePosAfter, middlePoint);

                //middle point of the buffer corresponds to the reference file offset, so all we need to do is return the difference between the closest newline and the center of the buffer
                if (closestNewLinePos >= 0)
                {
                    return closestNewLinePos - middlePoint;
                }
            }

            //if we get this far, we were unable to find a record boundary within our limits => fail the upload
            throw new UploadFailedException(
                string.Format(
                    "Unable to locate a record boundary within {0}MB on either side of segment {1} (offset {2}). This means the record at that offset is larger than {0}MB.",
                    _maxAppendLength / 1024 / 1024 / 2,
                    segment.SegmentNumber,
                    segment.Offset,
                    _maxAppendLength / 1024 / 1024));
        }

        /// <summary>
        /// Returns the value (of the given two) that is closest in absolute terms to the center value.
        /// Values that are negative are ignored (since these are assumed to represent array indices).
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="centerValue"></param>
        /// <returns></returns>
        private static int FindClosestToCenter(int value1, int value2, int centerValue)
        {
            if (value1 >= 0)
            {
                if (value2 >= 0)
                {
                    return Math.Abs(value2 - centerValue) > Math.Abs(value1 - centerValue) ? value1 : value2;
                }
                else
                {
                    return value1;
                }
            }
            else
            {
                return value2;
            }
        }

        /// <summary>
        /// Reads data from the given file into the given buffer, centered around the given file offset. The first half of the buffer will be 
        /// filled with data right before the given offset, while the remainder of the buffer will contain data right after it (of course, containing the byte at the given offset).
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="fileReferenceOffset"></param>
        /// <returns>The number of bytes reads, which could be less than the length of the input buffer if we can't read due to the beginning or the end of the file.</returns>
        private static int ReadIntoBufferAroundReference(Stream stream, byte[] buffer, long fileReferenceOffset)
        {
            int length = buffer.Length;
            //calculate start offset
            long fileStartOffset = fileReferenceOffset - length / 2;

            if (fileStartOffset < 0)
            {
                //offset is less than zero, adjust it, as well as the length we want to read
                length += (int)fileStartOffset;
                fileStartOffset = 0;
                if (length <= 0)
                {
                    return 0;
                }
            }

            if (fileStartOffset + length > stream.Length)
            {
                //startOffset + length is beyond the end of the stream, adjust the length accordingly
                length = (int)(stream.Length - fileStartOffset);
                if (length <= 0)
                {
                    return 0;
                }
            }

            //read the appropriate block of the file into the buffer, using symmetry with respect to its midpoint
            stream.Seek(fileStartOffset, SeekOrigin.Begin);
            int bufferOffset = 0;
            while (bufferOffset < length)
            {
                int bytesRead = stream.Read(buffer, bufferOffset, length - bufferOffset);
                bufferOffset += bytesRead;
            }
            return length;
        }

        #endregion

    }
}
