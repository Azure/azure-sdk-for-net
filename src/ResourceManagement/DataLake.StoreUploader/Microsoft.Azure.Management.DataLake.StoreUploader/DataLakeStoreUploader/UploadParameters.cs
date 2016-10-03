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

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Represents parameters for the DataLake Uploader.
    /// </summary>
    public class UploadParameters
    {
        /// <summary>
        /// Creates a new set of parameters for the DataLake Uploader.
        /// </summary>
        /// <param name="inputFilePath">The full path to the file or folder to be uploaded.</param>
        /// <param name="targetStreamPath">The full stream path where the file or folder will be uploaded to.</param>
        /// <param name="accountName">Name of the account to upload to.</param>
        /// <param name="perFileThreadCount">The per file thread count, indicating the number of file segments to upload in parallel. This number is capped at FILE_SIZE/maxSegmentLength for optimal performance.</param>
        /// <param name="concurrentFileCount">The parallel file count, indicating the number of files to upload in parallel during a folder upload. This parameter is ignored for single file uploads. Default is 5 for folder uploads</param>
        /// <param name="isOverwrite">(Optional) Whether to overwrite the target stream or not.</param>
        /// <param name="isResume">(Optional) Indicates whether to resume a previously interrupted upload.</param>
        /// <param name="isBinary">(Optional) Indicates whether to treat the input file as a binary file (true), or whether to align upload blocks to record boundaries (false).</param>
        /// <param name="isRecursive">(Optional) Indicates whether to upload the source folder recursively or not. If true, will upload the source directory and all sub directories, preserving directory structure.</param>
        /// <param name="isDownload">(Optional) if set to <c>true</c> [is download] instead of an upload scenario. Default is false.</param>
        /// <param name="maxSegmentLength">Maximum length of each segment. The default is 256mb, which gives optimal performance. Modify at your own risk.</param>
        /// <param name="localMetadataLocation">(Optional) Indicates the directory path where to store the local upload metadata file while the upload is in progress. This location must be writeable from this application. Default location: SpecialFolder.LocalApplicationData.</param>
        public UploadParameters(string inputFilePath, string targetStreamPath, string accountName, int perFileThreadCount = 10, int concurrentFileCount = 5, bool isOverwrite = false, bool isResume = false, bool isBinary = true, bool isRecursive = false, bool isDownload = false, long maxSegmentLength = 256 * 1024 * 1024, string localMetadataLocation = null)
        {
            this.InputFilePath = inputFilePath;
            this.TargetStreamPath = targetStreamPath;
            this.PerFileThreadCount = perFileThreadCount;
            this.ConcurrentFileCount = concurrentFileCount;
            this.AccountName = accountName;
            this.IsOverwrite = isOverwrite;
            this.IsResume = isResume;
            this.IsBinary = isBinary;
            this.IsRecursive = isRecursive;
            this.MaxSegementLength = maxSegmentLength;
            this.IsDownload = isDownload;

            if (string.IsNullOrWhiteSpace(localMetadataLocation))
            {
                localMetadataLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }
            this.LocalMetadataLocation = localMetadataLocation;

            this.UseSegmentBlockBackOffRetryStrategy = true;

            // TODO: in the future we will expose these as optional parameters, allowing customers to specify encoding and delimiters.
            this.FileEncoding = System.Text.Encoding.UTF8;
            this.Delimiter = null;
        }

        /// <summary>
        /// Creates a new set of parameters for the DataLake Uploader.
        /// </summary>
        /// <param name="inputFilePath">The full path to the file or folder to be uploaded.</param>
        /// <param name="targetStreamPath">The full stream path where the file or folder will be uploaded to.</param>
        /// <param name="accountName">Name of the account to upload to.</param>
        /// <param name="useSegmentBlockBackOffRetryStrategy">if set to <c>true</c> [use segment block back off retry strategy].</param>
        /// <param name="perFileThreadCount">The per file thread count, indicating the number of file segments to upload in parallel. This number is capped at FILE_SIZE/maxSegmentLength for optimal performance.</param>
        /// <param name="concurrentFileCount">The parallel file count, indicating the number of files to upload in parallel during a folder upload. This parameter is ignored for single file uploads. Default is 5 for folder uploads</param>
        /// <param name="isOverwrite">(Optional) Whether to overwrite the target stream or not.</param>
        /// <param name="isResume">(Optional) Indicates whether to resume a previously interrupted upload.</param>
        /// <param name="isBinary">(Optional) Indicates whether to treat the input file as a binary file (true), or whether to align upload blocks to record boundaries (false).</param>
        /// <param name="isRecursive">(Optional) Indicates whether to upload the source folder recursively or not. If true, will upload the source directory and all sub directories, preserving directory structure.</param>
        /// <param name="isDownload">(Optional) if set to <c>true</c> [is download] instead of an upload scenario. Default is false.</param>
        /// <param name="maxSegmentLength">Maximum length of the segment.</param>
        /// <param name="localMetadataLocation">(Optional) Indicates the directory path where to store the local upload metadata file while the upload is in progress. This location must be writeable from this application. Default location: SpecialFolder.LocalApplicationData.</param>
        internal UploadParameters(string inputFilePath, string targetStreamPath, string accountName, bool useSegmentBlockBackOffRetryStrategy, int perFileThreadCount = 10, int concurrentFileCount = 5, bool isOverwrite = false, bool isResume = false, bool isBinary = true, bool isRecursive = false, bool isDownload = false, long maxSegmentLength = 256 * 1024 * 1024, string localMetadataLocation = null) :
            this(inputFilePath, targetStreamPath, accountName, perFileThreadCount, concurrentFileCount, isOverwrite, isResume, isBinary, isRecursive, isDownload, maxSegmentLength, localMetadataLocation)
        {
            this.UseSegmentBlockBackOffRetryStrategy = useSegmentBlockBackOffRetryStrategy;
        }

        /// <summary>
        /// Gets a value indicating whether [to use segment block back off retry strategy].
        /// </summary>
        /// <value>
        /// <c>true</c> if [to use segment block back off retry strategy]; otherwise, <c>false</c>.
        /// </value>
        internal bool UseSegmentBlockBackOffRetryStrategy { get; set; }

        /// <summary>
        /// Gets a value indicating the full path to the file or folder to be uploaded.
        /// </summary>
        /// <value>
        /// The input file path.
        /// </value>
        public string InputFilePath { get; internal set; }

        /// <summary>
        /// Gets a value indicating the full stream path where the file will be uploaded to.
        /// </summary>
        /// <value>
        /// The target stream path.
        /// </value>
        public string TargetStreamPath { get; internal set; }

        /// <summary>
        /// Gets a value indicating the name of the account to upload to or download from.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; internal set; }

        /// <summary>
        /// Gets a value indicating the maximum number of parallel threads to use for a single file upload or download.
        /// </summary>
        /// <value>
        /// The file thread count.
        /// </value>
        public int PerFileThreadCount { get; internal set; }


        /// <summary>
        /// Gets the parallel file count, which indicates how many files in a folder will be uploaded or downloaded in parallel
        /// </summary>
        /// <value>
        /// The number of files to upload or download at once.
        /// </value>
        public int ConcurrentFileCount { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether to overwrite the target stream if it already exists.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is overwrite; otherwise, <c>false</c>.
        /// </value>
        public bool IsOverwrite { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether to resume a previously interrupted upload.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is resume; otherwise, <c>false</c>.
        /// </value>
        public bool IsResume { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the input file should be treated as a binary (true) or a delimited input (false).
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is binary; otherwise, <c>false</c>.
        /// </value>
        public bool IsBinary { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the folder upload should recursively upload the source folder. This is only valid for folder uploads and will be ignored for file uploads.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is recursive; otherwise, <c>false</c>.
        /// </value>
        public bool IsRecursive { get; internal set; }


        /// <summary>
        /// Gets a value indicating whether this instance is downloading to the local machine instead of uploading.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is download; otherwise, <c>false</c>.
        /// </value>
        public bool IsDownload { get; internal set; }

        /// <summary>
        /// Gets the maximum length of each segement.
        /// </summary>
        /// <value>
        /// The maximum length of each segement.
        /// </value>
        public long MaxSegementLength { get; internal set; }

        /// <summary>
        /// Gets a value indicating the directory path where to store the metadata for the upload.
        /// </summary>
        /// <value>
        /// The local metadata location.
        /// </value>
        public string LocalMetadataLocation { get; internal set; }

        /// <summary>
        /// Gets a value indicating the encoding of the file being uploaded.
        /// </summary>
        /// <value>
        /// The file encoding.
        /// </value>
        public System.Text.Encoding FileEncoding { get; internal set; }

        /// <summary>
        /// Gets a value indicating the record boundary delimiter for the file, if any.
        /// </summary>
        /// <value>
        /// The record boundary delimiter
        /// </value>
        public string Delimiter { get; internal set; }
    }
}