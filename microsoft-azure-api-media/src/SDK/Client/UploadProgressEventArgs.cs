// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Describes the status of an upload operation.
    /// </summary>
	public class UploadProgressEventArgs : EventArgs
	{
        /// <summary>
        /// Constructs an UploadProgressEventArgs object that describes the status of uploading files.
        /// </summary>
        /// <param name="currentFile">Current file being uploaded.</param>
        /// <param name="totalFiles">Number of files uploaded.</param>
        /// <param name="bytesSent">Number of Bytes uploaded.</param>
        /// <param name="totalBytes">Total number of Bytes to upload.</param>
		internal UploadProgressEventArgs(string currentFile, int totalFiles, long bytesSent, long totalBytes)
		{
            if(string.IsNullOrEmpty(currentFile))
            {
                throw new ArgumentNullException("currentFile");
            }
			CurrentFile = currentFile;
			BytesSent = bytesSent;
			TotalBytes = totalBytes;
		    TotalFiles = totalFiles;
		}

        /// <summary>
        /// Gets the file that is being uploaded.
        /// </summary>
		public string CurrentFile { get; private set; }

        /// <summary>
        /// Gets the number of files being uploaded.
        /// </summary>
        public int TotalFiles { get; private set; }

        /// <summary>
        /// Gets the number of Bytes sent for the current file.
        /// </summary>
		public long BytesSent { get; private set; }

        /// <summary>
        /// Gets the total number of Bytes to be uploaded.
        /// </summary>
		public long TotalBytes { get; private set; }

        /// <summary>
        /// Gets the percentage of bytes uploaded.
        /// </summary>
		public double Progress
		{
			get
			{
				return 100.0 * (double)BytesSent / (double)TotalBytes;
			}
		}
	}
}
