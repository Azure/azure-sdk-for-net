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
using System.Xml.Serialization;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents general metadata pertaining to an upload.
    /// </summary>
    [DebuggerDisplay("Segments = {SegmentCount}, SegmentLength = {SegmentLength}, UploadId = {UploadId}, FileLength = {FileLength}, FilePath = {FilePath}")]
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
        internal UploadMetadata(string metadataFilePath, UploadParameters uploadParameters)
        {
            this.MetadataFilePath = metadataFilePath;
           
            this.UploadId = Guid.NewGuid().ToString("N");
            this.InputFilePath = uploadParameters.InputFilePath;
            this.TargetStreamPath = uploadParameters.TargetStreamPath;

            string streamDirectory;
            var streamName = SplitTargetStreamPathByName(out streamDirectory);
            
            if (string.IsNullOrEmpty(streamDirectory))
            {
                // the scenario where the file is being uploaded at the root
                this.SegmentStreamDirectory = string.Format("/{0}.segments.{1}", streamName, Guid.NewGuid());
            }
            else
            {
                // the scenario where the file is being uploaded in a sub folder
                this.SegmentStreamDirectory = string.Format("{0}/{1}.segments.{2}",
                    streamDirectory,
                    streamName, Guid.NewGuid());
            }

            this.IsBinary = uploadParameters.IsBinary;

            var fileInfo = new FileInfo(uploadParameters.InputFilePath);
            this.FileLength = fileInfo.Length;
            
            // we are taking the smaller number of segments between segment lengths of 256 and the segment growth logic.
            // this protects us against agressive increase of thread count resulting in far more segments than
            // is reasonable for a given file size. We also ensure that each segment is at least 256mb in size.
            // This is the size that ensures we have the optimal storage creation in the store.
            var preliminarySegmentCount = (int)Math.Ceiling((double) fileInfo.Length/uploadParameters.MaxSegementLength);
            this.SegmentCount = Math.Min(preliminarySegmentCount, UploadSegmentMetadata.CalculateSegmentCount(fileInfo.Length));
            this.SegmentLength = UploadSegmentMetadata.CalculateSegmentLength(fileInfo.Length, this.SegmentCount);

            this.Segments = new UploadSegmentMetadata[this.SegmentCount];
            for (int i = 0; i < this.SegmentCount; i++)
            {
                this.Segments[i] = new UploadSegmentMetadata(i, this);
            }
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

        #endregion

    }
}
