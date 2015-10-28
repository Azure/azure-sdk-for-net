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
        /// <param name="inputFilePath">The full path to the file to be uploaded.</param>
        /// <param name="targetStreamPath">The full stream path where the file will be uploaded to.</param>
        /// <param name="accountName">Name of the account to upload to.</param>
        /// <param name="threadCount">(Optional) The maximum number of parallel threads to use for the upload.</param>
        /// <param name="isOverwrite">(Optional) Whether to overwrite the target stream or not.</param>
        /// <param name="isResume">(Optional) Indicates whether to resume a previously interrupted upload.</param>
        /// <param name="isBinary">(Optional) Indicates whether to treat the input file as a binary file (true), or whether to align upload blocks to record boundaries (false).</param>
        /// <param name="maxSegmentLength">Maximum length of each segment. The default is 256mb, which gives optimal performance. Modify at your own risk.</param>
        /// <param name="localMetadataLocation">(Optional) Indicates the directory path where to store the local upload metadata file while the upload is in progress. This location must be writeable from this application. Default location: SpecialFolder.LocalApplicationData.</param>
        public UploadParameters(string inputFilePath, string targetStreamPath, string accountName, int threadCount = 1, bool isOverwrite = false, bool isResume = false, bool isBinary = true, long maxSegmentLength = 256*1024*1024, string localMetadataLocation = null)
        {
            this.InputFilePath = inputFilePath;
            this.TargetStreamPath = targetStreamPath;
            this.ThreadCount = threadCount;
            this.AccountName = accountName;
            this.IsOverwrite = isOverwrite;
            this.IsResume = isResume;
            this.IsBinary = isBinary;
            this.MaxSegementLength = maxSegmentLength;

            if (string.IsNullOrWhiteSpace(localMetadataLocation))
            {
                localMetadataLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }
            this.LocalMetadataLocation = localMetadataLocation;

            this.UseSegmentBlockBackOffRetryStrategy = true;
        }

        /// <summary>
        /// Creates a new set of parameters for the DataLake Uploader.
        /// </summary>
        /// <param name="inputFilePath">The full path to the file to be uploaded.</param>
        /// <param name="targetStreamPath">The full stream path where the file will be uploaded to.</param>
        /// <param name="accountName">Name of the account to upload to.</param>
        /// <param name="useSegmentBlockBackOffRetryStrategy">if set to <c>true</c> [use segment block back off retry strategy].</param>
        /// <param name="threadCount">(Optional) The maximum number of parallel threads to use for the upload.</param>
        /// <param name="isOverwrite">(Optional) Whether to overwrite the target stream or not.</param>
        /// <param name="isResume">(Optional) Indicates whether to resume a previously interrupted upload.</param>
        /// <param name="isBinary">(Optional) Indicates whether to treat the input file as a binary file (true), or whether to align upload blocks to record boundaries (false).</param>
        /// <param name="localMetadataLocation">(Optional) Indicates the directory path where to store the local upload metadata file while the upload is in progress. This location must be writeable from this application. Default location: SpecialFolder.LocalApplicationData.</param>
        internal UploadParameters(string inputFilePath, string targetStreamPath, string accountName, bool useSegmentBlockBackOffRetryStrategy, int threadCount = 1, bool isOverwrite = false, bool isResume = false, bool isBinary = true, long maxSegmentLength = 256*1024*1024, string localMetadataLocation = null) :
            this(inputFilePath, targetStreamPath, accountName, threadCount, isOverwrite, isResume, isBinary, maxSegmentLength, localMetadataLocation)
        {
            this.UseSegmentBlockBackOffRetryStrategy = useSegmentBlockBackOffRetryStrategy;
        }

        /// <summary>
        /// Gets a value indicating whether [to use segment block back off retry strategy].
        /// </summary>
        /// <value>
        /// <c>true</c> if [to use segment block back off retry strategy]; otherwise, <c>false</c>.
        /// </value>
        internal bool UseSegmentBlockBackOffRetryStrategy {get; private set; }

        /// <summary>
        /// Gets a value indicating the full path to the file to be uploaded.
        /// </summary>
        /// <value>
        /// The input file path.
        /// </value>
        public string InputFilePath { get; private set; }

        /// <summary>
        /// Gets a value indicating the full stream path where the file will be uploaded to.
        /// </summary>
        /// <value>
        /// The target stream path.
        /// </value>
        public string TargetStreamPath { get; private set; }

        /// <summary>
        /// Gets a value indicating the name of the account to upload to.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; private set; }

        /// <summary>
        /// Gets a value indicating the maximum number of parallel threads to use for the upload.
        /// </summary>
        /// <value>
        /// The thread count.
        /// </value>
        public int ThreadCount { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether to overwrite the target stream if it already exists.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is overwrite; otherwise, <c>false</c>.
        /// </value>
        public bool IsOverwrite { get; private set; }

        /// <summary>
        /// Gets a value indicating whether to resume a previously interrupted upload.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is resume; otherwise, <c>false</c>.
        /// </value>
        public bool IsResume { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the input file should be treated as a binary (true) or a delimited input (false).
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is binary; otherwise, <c>false</c>.
        /// </value>
        public bool IsBinary { get; private set; }

        /// <summary>
        /// Gets the maximum length of each segement.
        /// </summary>
        /// <value>
        /// The maximum length of each segement.
        /// </value>
        public long MaxSegementLength { get; private set; }

        /// <summary>
        /// Gets a value indicating the directory path where to store the metadata for the upload.
        /// </summary>
        /// <value>
        /// The local metadata location.
        /// </value>
        public string LocalMetadataLocation { get; private set; }
    }
}
