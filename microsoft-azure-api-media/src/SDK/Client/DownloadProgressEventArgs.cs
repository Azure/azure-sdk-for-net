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
    /// Describes the status of a download operation.
    /// </summary>
	public class DownloadProgressEventArgs : EventArgs
	{    
        /// <summary>
        /// Constructs an DownloadProgressEventArgs object that describes the status of downloading files.
        /// </summary>
        /// <param name="bytesDownloaded">Number of bytes downloaded.</param>
        /// <param name="totalBytes">Total number of bytes to download.</param>
        public DownloadProgressEventArgs(long bytesDownloaded, long totalBytes)
		{
            BytesDownloaded = bytesDownloaded;
			TotalBytes = totalBytes;
		}

        /// <summary>
        /// Gets the total number of bytes downloaded.
        /// </summary>
		public long BytesDownloaded { get; private set; }

        /// <summary>
        /// Gets the total number of bytes to be downloaded.
        /// </summary>
		public long TotalBytes { get; private set; }

        /// <summary>
        /// Gets the percentage of bytes uploaded.
        /// </summary>
		public double Progress
		{
			get
			{
                return 100.0 * (double)BytesDownloaded / (double)TotalBytes;
			}
		}
	}
}
