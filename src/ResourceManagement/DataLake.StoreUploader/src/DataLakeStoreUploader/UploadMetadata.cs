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
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents general metadata pertaining to an upload.
    /// </summary>
    [DebuggerDisplay("Segments = {SegmentCount}, SegmentLength = {SegmentLength}, UploadId = {UploadId}, FileLength = {FileLength}, FilePath = {FilePath}, EncodingCodePage = {EncodingCodePage}, Delimiter = {Delimiter}")]
    [DataContract]
    public class UploadMetadata
    {
        
        #region Private

        private static readonly DataContractSerializer MetadataSerializer = new DataContractSerializer(typeof(UploadMetadata));
        private static readonly object SaveSync = new object();
        
        #endregion

        #region Constructor

        /// <summary>
        /// Required by XmlSerializer.
        /// </summary>
        internal UploadMetadata()
        {
        }

        /// <summary>
        /// Constructs a new UploadMetadata from the given parameters.
        /// </summary>
        /// <param name="metadataFilePath">The file path to assign to this metadata file (for saving purposes).</param>
        /// <param name="uploadParameters">The parameters to use for constructing this metadata.</param>
        /// <param name="frontEnd">The front end. This is used only in the constructor for determining file length</param>
        internal UploadMetadata(string metadataFilePath, UploadParameters uploadParameters, IFrontEndAdapter frontEnd, long fileSize = -1)
        {
            this.MetadataFilePath = metadataFilePath;
           
            this.UploadId = Guid.NewGuid().ToString("N");
            this.InputFilePath = uploadParameters.InputFilePath;
            this.TargetStreamPath = uploadParameters.TargetStreamPath;
            this.IsDownload = uploadParameters.IsDownload;

            this.SegmentStreamDirectory = GetSegmentStreamDirectory();

            this.IsBinary = uploadParameters.IsBinary;

            this.FileLength = fileSize < 0 ? frontEnd.GetStreamLength(uploadParameters.InputFilePath, !IsDownload) : fileSize;

            this.EncodingCodePage = uploadParameters.FileEncoding.CodePage;

            // we are taking the smaller number of segments between segment lengths of 256 and the segment growth logic.
            // this protects us against agressive increase of thread count resulting in far more segments than
            // is reasonable for a given file size. We also ensure that each segment is at least 256mb in size.
            // This is the size that ensures we have the optimal storage creation in the store.
            var preliminarySegmentCount = (int)Math.Ceiling((double)this.FileLength / uploadParameters.MaxSegementLength);
            this.SegmentCount = Math.Min(preliminarySegmentCount, UploadSegmentMetadata.CalculateSegmentCount(this.FileLength));
            this.SegmentLength = UploadSegmentMetadata.CalculateSegmentLength(this.FileLength, this.SegmentCount);

            this.Segments = new UploadSegmentMetadata[this.SegmentCount];
            for (int i = 0; i < this.SegmentCount; i++)
            {
                this.Segments[i] = new UploadSegmentMetadata(i, this);
            }

            if (!uploadParameters.IsBinary && this.SegmentCount > 1 && !this.IsDownload)
            {
                this.AlignSegmentsToRecordBoundaries();
                
                // ensure that nothing strange happened during alignment
                this.ValidateConsistency();
            }

            // initialize the status to pending, since it is not yet done.
            this.Status = SegmentUploadStatus.Pending;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating the unique identifier associated with this upload.
        /// </summary>
        /// <value>
        /// The upload identifier.
        /// </value>
        [DataMember(Name = "UploadId")]
        public string UploadId { get; set; }

        /// <summary>
        /// /Gets or sets a value indicating the full path to the file to be uploaded.
        /// </summary>
        /// <value>
        /// The input file path.
        /// </value>
        [DataMember(Name = "InputFilePath")]
        public string InputFilePath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the length (in bytes) of the file to be uploaded.
        /// </summary>
        /// <value>
        /// The length of the file.
        /// </value>
        [DataMember(Name = "FileLength")]
        public long FileLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the full stream path where the file will be uploaded to.
        /// </summary>
        /// <value>
        /// The target stream path.
        /// </value>
        [DataMember(Name = "TargetStreamPath")]
        public string TargetStreamPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the directory path where intermediate segment streams will be stored.
        /// </summary>
        /// <value>
        /// The target stream path.
        /// </value>
        [DataMember(Name = "SegmentStreamDirectory")]
        public string SegmentStreamDirectory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of segments this file is split into for purposes of uploading it.
        /// </summary>
        /// <value>
        /// The segment count.
        /// </value>
        [DataMember(Name = "SegmentCount")]
        public int SegmentCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the length (in bytes) of each segment of the file (except the last one, which may be less).
        /// </summary>
        /// <value>
        /// The length of the segment.
        /// </value>
        [DataMember(Name = "SegmentLength")]
        public long SegmentLength { get; set; }

        /// <summary>
        /// Gets a pointer to an array of segment metadata. The segments are ordered by their segment number (sequence).
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        [DataMember(Name = "Segments")]
        public UploadSegmentMetadata[] Segments { get; set; }

        /// <summary>
        /// Gets a value indicating whether the upload file should be treated as a binary file or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is binary; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "IsBinary")]
        public bool IsBinary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a download instead of an upload.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is download; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "IsDownload")]
        public bool IsDownload { get; set; }

        /// <summary>
        /// Gets the CodePage of the current encoding being used.
        /// </summary>
        /// <value>
        ///  The CodePage of the current encoding.
        /// </value>
        [DataMember(Name = "EncodingCodePage")]
        public int EncodingCodePage { get; set; }

        /// <summary>
        /// Gets a value indicating the record boundary delimiter for the file, if any.
        /// </summary>
        /// <value>
        /// The record boundary delimiter
        /// </value>
        [DataMember(Name = "Delimiter")]
        public string Delimiter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the current upload status for this file upload.
        /// This value is checked for folder upload progress and resuming. 
        /// Single file uploads use segment status for tracking.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [DataMember(Name = "Status")]
        public SegmentUploadStatus Status { get; set; }

        /// <summary>
        /// Gets a value indicating the path where this metadata file is located.
        /// </summary>
        /// <value>
        /// The metadata file path.
        /// </value>
        internal string MetadataFilePath { get; set; }

        #endregion

        #region File Operations

        /// <summary>
        /// Attempts to load an UploadMetadata object from the given file.
        /// </summary>
        /// <param name="filePath">The full path to the file where to load the metadata from</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Could not find metadata file</exception>
        /// <exception cref="Microsoft.Azure.Management.DataLake.StoreUploader.InvalidMetadataException">Unable to parse metadata file</exception>
        internal static UploadMetadata LoadFrom(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find metadata file", filePath);
            }

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    UploadMetadata result = MetadataSerializer.ReadObject(stream) as UploadMetadata;
                    if (result != null)
                    {
                        result.MetadataFilePath = filePath;
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidMetadataException("Unable to parse metadata file", ex);
            }
        }

        /// <summary>
        /// Saves the given metadata to its canonical location. This method is thread-safe.
        /// </summary>
        internal void Save()
        {
            if (string.IsNullOrEmpty(this.MetadataFilePath))
            {
                throw new InvalidOperationException("Null or empty MetadataFilePath. Cannot save metadata until this property is set.");
            }

            //quick check to ensure that the metadata we constructed is sane
            this.ValidateConsistency();

            lock (SaveSync)
            {
                if (File.Exists(this.MetadataFilePath))
                {
                    File.Delete(this.MetadataFilePath);
                }

                using (var stream = new FileStream(this.MetadataFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (var bufStream = new BufferedStream(stream))
                    {
                        MetadataSerializer.WriteObject(bufStream, this);
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the metadata file from disk.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Null or empty MetadataFilePath. Cannot delete metadata until this property is set.</exception>
        public void DeleteFile()
        {
            if (string.IsNullOrEmpty(this.MetadataFilePath))
            {
                throw new InvalidOperationException("Null or empty MetadataFilePath. Cannot delete metadata until this property is set.");
            }

            if (File.Exists(this.MetadataFilePath))
            {
                File.Delete(this.MetadataFilePath);
            }
        }

        /// <summary>
        /// Verifies the given metadata for consistency. Checks include:
        /// * Completeness
        /// * Existence and consistency with local file
        /// * Segment data consistency
        /// </summary>
        internal void ValidateConsistency()
        {
            if (this.Segments == null || this.Segments.Length != this.SegmentCount)
            {
                throw new InvalidMetadataException("Inconsistent number of segments");
            }

            long sum = 0;
            int lastSegmentNumber = -1;
            var segments = new BitArray(this.SegmentCount);

            foreach (var segment in this.Segments)
            {
                if (segment.SegmentNumber < 0 || segment.SegmentNumber >= this.SegmentCount)
                {
                    throw new InvalidMetadataException(string.Format("Segment numbers must be at least 0 and less than {0}. Found segment number {1}.", this.SegmentCount, segment.SegmentNumber));
                }

                if (segment.SegmentNumber <= lastSegmentNumber)
                {
                    throw new InvalidMetadataException(string.Format("Segment number {0} appears out of order.", segment.SegmentNumber));
                }

                if (segments[segment.SegmentNumber])
                {
                    throw new InvalidMetadataException(string.Format("Segment number {0} appears twice", segment.SegmentNumber));
                }

                if (segment.Offset != sum)
                {
                    throw new InvalidMetadataException(string.Format("Segment number {0} has an invalid starting offset ({1}). Expected {2}.", segment.SegmentNumber, segment.Offset, sum));
                }

                segments[segment.SegmentNumber] = true;
                sum += segment.Length;
                lastSegmentNumber = segment.SegmentNumber;
            }

            if (sum != this.FileLength)
            {
                throw new InvalidMetadataException("The individual segment lengths do not add up to the input File Length");
            }
        }

        /// <summary>
        /// Splits the target stream path, returning the name of the stream and storing the full directory path (if any) in an out variable.
        /// </summary>
        /// <param name="targetStreamDirectory">The target stream directory, or null of the stream is at the root.</param>
        /// <returns></returns>
        internal string SplitTargetStreamPathByName(out string targetStreamDirectory)
        {
            if (this.IsDownload)
            {
                targetStreamDirectory = Path.GetDirectoryName(this.TargetStreamPath);
                return Path.GetFileName(this.TargetStreamPath);
            }
            else
            {
                var numFoldersInPath = this.TargetStreamPath.Split('/').Length;
                if (numFoldersInPath - 1 == 0 || (numFoldersInPath - 1 == 1 && this.TargetStreamPath.StartsWith("/")))
                {
                    // the scenario where the file is being uploaded at the root
                    targetStreamDirectory = null;
                    return this.TargetStreamPath.TrimStart('/');
                }
                else
                {
                    // the scenario where the file is being uploaded in a sub folder
                    targetStreamDirectory = this.TargetStreamPath.Substring(0,
                        this.TargetStreamPath.LastIndexOf('/'));
                    return this.TargetStreamPath.Substring(this.TargetStreamPath.LastIndexOf('/') + 1);
                }
            }
        }


        internal string GetSegmentStreamDirectory()
        {
            string streamDirectory;
            var streamName = SplitTargetStreamPathByName(out streamDirectory);

            if(this.IsDownload)
            {
                // for downloads, there is always a "folder" (such as 'C:\').
                return string.Format(@"{0}\{1}.segments.{2}",
                    streamDirectory,
                    streamName, Guid.NewGuid());
            }
            else
            {
                if (string.IsNullOrEmpty(streamDirectory))
                {
                    // the scenario where the file is being uploaded at the root
                    return string.Format("/{0}.segments.{1}", streamName, Guid.NewGuid());
                }
                else
                {
                    // the scenario where the file is being uploaded in a sub folder
                    return string.Format("{0}/{1}.segments.{2}",
                        streamDirectory,
                        streamName, Guid.NewGuid());
                }
            }
            
        }
        /// <summary>
        /// Aligns segments to match record boundaries (where a record boundary = a new line).
        /// If not possible (max record size = 4MB), throws an exception.
        /// </summary>
        private void AlignSegmentsToRecordBoundaries()
        {
            int remainingSegments = 0;

            using (var stream = new FileStream(this.InputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                long offset = 0;
                for (int i = 0; i < this.Segments.Length; i++)
                {
                    var segment = this.Segments[i];

                    //updating segment lengths means that both the offset and the length of the next segment needs to be recalculated, to keep the segment lengths somewhat balanced
                    long diff = segment.Offset - offset;
                    segment.Offset = offset;
                    segment.Length += diff;
                    if (segment.Offset >= this.FileLength)
                    {
                        continue;
                    }

                    if (segment.SegmentNumber == this.Segments.Length - 1)
                    {
                        //last segment picks up the slack
                        segment.Length = this.FileLength - segment.Offset;
                    }
                    else
                    {
                        //figure out how much do we need to adjust the length of the segment so it ends on a record boundary (this can be negative or positive)
                        int lengthAdjustment = DetermineLengthAdjustment(segment, stream, Encoding.GetEncoding(this.EncodingCodePage), this.Delimiter) + 1;

                        //adjust segment length and offset
                        segment.Length += lengthAdjustment;
                    }
                    offset += segment.Length;
                    remainingSegments++;
                }
            }

            //since we adjusted the segment lengths, it's possible that the last segment(s) became of zero length; so remove it
            var segments = this.Segments;
            if (remainingSegments < segments.Length)
            {
                Array.Resize(ref segments, remainingSegments);
                this.Segments = segments;
                this.SegmentCount = segments.Length;
            }

            //NOTE: we are not validating consistency here; this method is called by CreateNewMetadata which calls Save() after this, which validates consistency anyway.
        }

        /// <summary>
        /// Calculates the value by which we'd need to adjust the length of the given segment, by searching for the nearest newline around it (before and after), 
        /// and returning the distance to it (which can be positive, if after, or negative, if before).
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="stream"></param>
        /// <param name="encoding"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        /// <exception cref="Microsoft.Azure.Management.DataLake.StoreUploader.UploadFailedException">If no record boundary could be located on either side of the segment end offset within the allowed distance.</exception>
        private int DetermineLengthAdjustment(UploadSegmentMetadata segment, FileStream stream, Encoding encoding, string delimiter = null)
        {
            long referenceFileOffset = segment.Offset + segment.Length;
            byte[] buffer = new byte[SingleSegmentUploader.MaxRecordLength];

            //read 2MB before the segment boundary and 2MB after (for a total of 4MB = max append length)
            int bytesRead = ReadIntoBufferAroundReference(stream, buffer, referenceFileOffset);
            if (bytesRead > 0)
            {
                int middlePoint = bytesRead / 2;
                //search for newline in it
                int newLinePosBefore = StringExtensions.FindNewline(buffer, middlePoint + 1, middlePoint + 1, true, encoding, delimiter);

                //in some cases, we may have a newline that is 2 characters long, and it occurrs exactly on the midpoint, which means we won't be able to find its end.
                //see if that's the case, and then search for a new candidate before it.
                if (string.IsNullOrEmpty(delimiter) && newLinePosBefore == middlePoint + 1 && buffer[newLinePosBefore] == (byte)'\r')
                {
                    int newNewLinePosBefore = StringExtensions.FindNewline(buffer, middlePoint, middlePoint, true, encoding);
                    if (newNewLinePosBefore >= 0)
                    {
                        newLinePosBefore = newNewLinePosBefore;
                    }
                }

                int newLinePosAfter = StringExtensions.FindNewline(buffer, middlePoint, middlePoint, false, encoding, delimiter);
                if (string.IsNullOrEmpty(delimiter) && newLinePosAfter == buffer.Length - 1 && buffer[newLinePosAfter] == (byte)'\r' && newLinePosBefore >= 0)
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
                    SingleSegmentUploader.MaxRecordLength / 1024 / 1024 / 2,
                    segment.SegmentNumber,
                    segment.Offset,
                    SingleSegmentUploader.MaxRecordLength / 1024 / 1024));
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
