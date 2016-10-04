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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents general metadata pertaining to an upload.
    /// </summary>
    [DebuggerDisplay("FileCount = {FileCount}, UploadId = {UploadId}, IsRecursive = {IsRecursive}")]
    [DataContract]
    public class UploadFolderMetadata
    {
        
        #region Private

        private static readonly DataContractSerializer MetadataSerializer = new DataContractSerializer(typeof(UploadFolderMetadata));
        private static readonly object SaveSync = new object();
        
        #endregion

        #region Constructor

        /// <summary>
        /// Required by XmlSerializer.
        /// </summary>
        internal UploadFolderMetadata()
        {
        }

        /// <summary>
        /// Constructs a new UploadMetadata from the given parameters.
        /// </summary>
        /// <param name="metadataFilePath">The file path to assign to this metadata file (for saving purposes).</param>
        /// <param name="uploadParameters">The parameters to use for constructing this metadata.</param>
        /// <param name="frontend">The frontend to use when generating per file metadata.</param>
        public UploadFolderMetadata(string metadataFilePath, UploadParameters uploadParameters, IFrontEndAdapter frontend)
        {
            this.MetadataFilePath = metadataFilePath;
           
            this.UploadId = Guid.NewGuid().ToString("N");
            this.InputFolderPath = uploadParameters.InputFilePath;
            this.TargetStreamFolderPath = uploadParameters.TargetStreamPath.TrimEnd('/');
            this.IsRecursive = uploadParameters.IsRecursive;
            // get this list of all files in the source directory, depending on if this is recursive or not.
            ConcurrentQueue<string> allFiles;
            ConcurrentQueue<Exception> exceptions = new ConcurrentQueue<Exception>();

            Dictionary<string, long> downloadFiles = new Dictionary<string, long>();
            if (uploadParameters.IsDownload)
            {
                foreach (var entry in frontend.ListDirectory(uploadParameters.InputFilePath, uploadParameters.IsRecursive))
                {
                    downloadFiles.Add(entry.Key, entry.Value);
                }

                allFiles = new ConcurrentQueue<string>(downloadFiles.Keys);
                this.TotalFileBytes = downloadFiles.Values.Sum();
            }
            else
            {
                allFiles = new ConcurrentQueue<string>(this.IsRecursive ? Directory.EnumerateFiles(this.InputFolderPath, "*.*", SearchOption.AllDirectories) :
                    Directory.EnumerateFiles(this.InputFolderPath, "*.*", SearchOption.TopDirectoryOnly));

                this.TotalFileBytes = GetByteCountFromFileList(allFiles);
            }

            this.FileCount = allFiles.Count();
            this.Files = new UploadMetadata[this.FileCount];
            // explicitly set the thread pool start amount to at most 500
            int threadCount = Math.Min(this.FileCount, 500);
            var threads = new List<Thread>(threadCount);

            //start a bunch of new threads that will create the metadata and ensure a protected index.
            int currentIndex = 0;
            object indexIncrementLock = new object();
            for (int i = 0; i < threadCount; i++)
            {
                var t = new Thread(() => {
                    string curFile;
                    while (allFiles.TryDequeue(out curFile))
                    {
                        try
                        {
                            var relativeFilePath = curFile.Replace(this.InputFolderPath, "").TrimStart('\\').TrimStart('/');
                            var paramsPerFile = new UploadParameters
                            (
                                curFile,
                                String.Format("{0}{1}{2}", this.TargetStreamFolderPath, uploadParameters.IsDownload ? "\\" : "/", relativeFilePath),
                                uploadParameters.AccountName,
                                uploadParameters.PerFileThreadCount,
                                uploadParameters.ConcurrentFileCount,
                                uploadParameters.IsOverwrite,
                                uploadParameters.IsResume,
                                uploadParameters.IsBinary,
                                uploadParameters.IsRecursive,
                                uploadParameters.IsDownload,
                                uploadParameters.MaxSegementLength,
                                uploadParameters.LocalMetadataLocation
                            );

                            long size = -1;
                            if (uploadParameters.IsDownload && downloadFiles != null)
                            {
                                size = downloadFiles[curFile];
                            }
                            var uploadMetadataPath = Path.Combine(uploadParameters.LocalMetadataLocation, string.Format("{0}.upload.xml", Path.GetFileName(curFile)));
                            var eachFileMetadata = new UploadMetadata(uploadMetadataPath, paramsPerFile, frontend, size);
                            lock (indexIncrementLock)
                            {
                                this.Files[currentIndex] = eachFileMetadata;
                                currentIndex++;
                            }
                        }
                        catch (Exception e)
                        {
                            exceptions.Enqueue(e);
                        }
                    }
                });
                t.Start();
                threads.Add(t);
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("At least one file failed to have metadata generated", exceptions.ToArray());
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
        /// Gets or sets a value indicating the full path to the file to be uploaded.
        /// </summary>
        /// <value>
        /// The input file path.
        /// </value>
        [DataMember(Name = "InputFolderPath")]
        public string InputFolderPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the full stream folder path that will be used as the root folder for all files and folders being uploaded.
        /// </summary>
        /// <value>
        /// The target stream path.
        /// </value>
        [DataMember(Name = "TargetStreamFolderPath")]
        public string TargetStreamFolderPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of files in this upload.
        /// </summary>
        /// <value>
        /// The segment count.
        /// </value>
        [DataMember(Name = "FileCount")]
        public int FileCount { get; set; }

        /// <summary>
        /// Gets or sets the total bytes for all the files.
        /// </summary>
        /// <value>
        /// The total bytes for all the files.
        /// </value>
        [DataMember(Name = "TotalFileBytes")]
        public long TotalFileBytes { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is recurisve directory upload or a flat directory upload
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is recursive; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "IsRecursive")]
        public bool IsRecursive { get; set; }

        /// <summary>
        /// Gets a pointer to an array of file upload metadata. This is used for each file that is being uploaded.
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        [DataMember(Name = "Files")]
        public UploadMetadata[] Files { get; set; }

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
        /// Attempts to load an UploadFolderMetadata object from the given file.
        /// </summary>
        /// <param name="filePath">The full path to the file where to load the metadata from</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Could not find metadata file</exception>
        /// <exception cref="Microsoft.Azure.Management.DataLake.StoreUploader.InvalidMetadataException">Unable to parse metadata file</exception>
        internal static UploadFolderMetadata LoadFrom(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find metadata file", filePath);
            }

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    UploadFolderMetadata result = MetadataSerializer.ReadObject(stream) as UploadFolderMetadata;
                    if (result != null)
                    {
                        result.MetadataFilePath = filePath;

                        // populate all child metadata file paths as well
                        var localMetadataFolder = Path.GetDirectoryName(filePath);
                        Parallel.ForEach(result.Files, new ParallelOptions { MaxDegreeOfParallelism = -1 }, file =>
                        {
                            var uploadMetadataPath = Path.Combine(localMetadataFolder, string.Format("{0}.upload.xml", Path.GetFileName(file.InputFilePath)));
                            file.MetadataFilePath = uploadMetadataPath;
                        });

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
        public void Save()
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
        /// Verifies the given metadata for consistency. Checks include, for each file:
        /// * Completeness
        /// * Existence and consistency with local file
        /// * Segment data consistency
        /// </summary>
        internal void ValidateConsistency()
        {
            foreach(var metadata in this.Files)
            {
                metadata.ValidateConsistency();
            }
        }

        /// <summary>
        /// Gets the byte count in the given list of files.
        /// </summary>
        /// <param name="fileList">The file list.</param>
        /// <returns>The total byte count for the file list</returns>
        internal long GetByteCountFromFileList(IEnumerable<string> fileList)
        {
            long count = 0;
            foreach (var entry in fileList)
            {
                count += new FileInfo(entry).Length;
            }

            return count;
        }

        #endregion

    }
}
