// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataLake.Store
{
    /// <summary>
    /// Represents general metadata pertaining to a transfer.
    /// </summary>
    [DebuggerDisplay("FileCount = {FileCount}, TransferId = {TransferId}, IsRecursive = {IsRecursive}")]
    public class TransferFolderMetadata
    {

        #region Private

        private static readonly JsonSerializer MetadataSerializer = new JsonSerializer();
        private static readonly object SaveSync = new object();

        #endregion

        #region Constructor

        /// <summary>
        /// Required by JsonSerializer.
        /// </summary>
        [JsonConstructor]
        internal TransferFolderMetadata()
        {
        }

        /// <summary>
        /// Constructs a new TransferFolderMetadata object from the given parameters.
        /// </summary>
        /// <param name="metadataFilePath">The file path to assign to this metadata file (for saving purposes).</param>
        /// <param name="transferParameters">The parameters to use for constructing this metadata.</param>
        /// <param name="frontend">The frontend to use when generating per file metadata.</param>
        public TransferFolderMetadata(string metadataFilePath, TransferParameters transferParameters, IFrontEndAdapter frontend)
        {
            this.MetadataFilePath = metadataFilePath;
           
            this.TransferId = Guid.NewGuid().ToString("N");
            this.InputFolderPath = transferParameters.InputFilePath;
            this.TargetStreamFolderPath = transferParameters.TargetStreamPath.TrimEnd('/');
            this.IsRecursive = transferParameters.IsRecursive;
            // get this list of all files in the source directory, depending on if this is recursive or not.
            ConcurrentQueue<string> allFiles;
            ConcurrentQueue<Exception> exceptions = new ConcurrentQueue<Exception>();

            Dictionary<string, long> downloadFiles = new Dictionary<string, long>();
            if (transferParameters.IsDownload)
            {
                foreach (var entry in frontend.ListDirectory(transferParameters.InputFilePath, transferParameters.IsRecursive))
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
            this.Files = new TransferMetadata[this.FileCount];
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
                            var paramsPerFile = new TransferParameters
                            (
                                curFile,
                                String.Format("{0}{1}{2}", this.TargetStreamFolderPath, transferParameters.IsDownload ? "\\" : "/", relativeFilePath),
                                transferParameters.AccountName,
                                transferParameters.PerFileThreadCount,
                                transferParameters.ConcurrentFileCount,
                                transferParameters.IsOverwrite,
                                transferParameters.IsResume,
                                transferParameters.IsBinary,
                                transferParameters.IsRecursive,
                                transferParameters.IsDownload,
                                transferParameters.MaxSegementLength,
                                transferParameters.LocalMetadataLocation
                            );

                            long size = -1;
                            if (transferParameters.IsDownload && downloadFiles != null)
                            {
                                size = downloadFiles[curFile];
                            }
                            var transferMetadataPath = Path.Combine(transferParameters.LocalMetadataLocation, string.Format("{0}.transfer.xml", Path.GetFileName(curFile)));
                            var eachFileMetadata = new TransferMetadata(transferMetadataPath, paramsPerFile, frontend, size);
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
        /// Gets or sets a value indicating the unique identifier associated with this transfer.
        /// </summary>
        /// <value>
        /// The transfer identifier.
        /// </value>
        [JsonProperty(PropertyName = "TransferId")]
        public string TransferId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the full path to the file to be transferred.
        /// </summary>
        /// <value>
        /// The input file path.
        /// </value>
        [JsonProperty(PropertyName = "InputFolderPath")]
        public string InputFolderPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the full stream folder path that will be used as the root folder for all files and folders being transferred.
        /// </summary>
        /// <value>
        /// The target stream path.
        /// </value>
        [JsonProperty(PropertyName = "TargetStreamFolderPath")]
        public string TargetStreamFolderPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of files in this transfer.
        /// </summary>
        /// <value>
        /// The segment count.
        /// </value>
        [JsonProperty(PropertyName = "FileCount")]
        public int FileCount { get; set; }

        /// <summary>
        /// Gets or sets the total bytes for all the files.
        /// </summary>
        /// <value>
        /// The total bytes for all the files.
        /// </value>
        [JsonProperty(PropertyName = "TotalFileBytes")]
        public long TotalFileBytes { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is recurisve directory transfer or a flat directory transfer
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is recursive; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty(PropertyName = "IsRecursive")]
        public bool IsRecursive { get; set; }

        /// <summary>
        /// Gets a pointer to an array of file transfer metadata. This is used for each file that is being transferred.
        /// </summary>
        /// <value>
        /// The segments.
        /// </value>
        [JsonProperty(PropertyName = "Files")]
        public TransferMetadata[] Files { get; set; }

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
        /// Attempts to load an TransferFolderMetadata object from the given file.
        /// </summary>
        /// <param name="filePath">The full path to the file where to load the metadata from</param>
        /// <param name="threadCount">The number of threads to use while populating the metadata. This is determined by the concurrent file count</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Could not find metadata file</exception>
        /// <exception cref="Microsoft.Azure.Management.DataLake.Store.InvalidMetadataException">Unable to parse metadata file</exception>
        internal static TransferFolderMetadata LoadFrom(string filePath, int threadCount)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Could not find metadata file", filePath);
            }

            try
            {
                TransferFolderMetadata result = JsonConvert.DeserializeObject<TransferFolderMetadata>(File.ReadAllText(filePath));
                if (result != null)
                {
                    result.MetadataFilePath = filePath;

                    // in the case where thread count is the default, explicitly set it to the ideal file/folder count for loading
                    // the metadata. Note that this value may be changed once the metadata is loaded when the ideal is re-computed
                    // based on:
                    // 1. Total files remaining (since this is a resume)
                    // 2. Total remaining file size.
                    if (threadCount < 1)
                    {
                        threadCount = DataLakeStoreTransferClient.DefaultIdealPerFileThreadCountForFolders;
                    }

                    // populate all child metadata file paths as well
                    var localMetadataFolder = Path.GetDirectoryName(filePath);
                    int updatesPerThread = (int)Math.Ceiling((double)result.Files.Length / threadCount);

                    var threads = new List<Thread>(threadCount);
                    for(int i = 0; i < threadCount; i++)
                    {
                        var t = new Thread(() =>
                        {
                            int startIndex = i * updatesPerThread;
                            int endIndex = startIndex + updatesPerThread;
                            for (int j = startIndex; j < endIndex; j++)
                            {
                                if (j >= result.Files.Length)
                                {
                                    // just in case.
                                    break;
                                }
                                var transferMetadataPath = Path.Combine(localMetadataFolder, string.Format("{0}.transfer.xml", Path.GetFileName(result.Files[j].InputFilePath)));
                                result.Files[j].MetadataFilePath = transferMetadataPath;
                            }
                        });

                        t.Start();
                        threads.Add(t);
                    }

                    foreach(var t in threads)
                    {
                        t.Join();
                    }
                }

                return result;
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

                using (var stream = new StreamWriter(new FileStream(this.MetadataFilePath, FileMode.Create, FileAccess.Write, FileShare.None)))
                {
                    MetadataSerializer.Serialize(stream, this);
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
