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
using System.ComponentModel;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Describes the progress of a blob tranfer, used by <see cref="TransferProgressChanged"/> event.
    /// </summary>
    public class BlobTransferProgressChangedEventArgs : ProgressChangedEventArgs
    {
        /// <summary>
        /// Constructs a BlobTransferProgressChangedEventArgs object.
        /// </summary>
        /// <param name="bytesSent">Number of bytes transferred.</param>
        /// <param name="totalBytesToSend">Total number of bytes to transfer.</param>
        /// <param name="progressPercentage">Percentage of bytes that finished transfering.</param>
        /// <param name="speed">Average speed of transfer in bytes per second.</param>
        /// <param name="uri">Uri of the blob location to transfer the data.</param>
        /// <param name="localfile">Name of the file being transferred.</param>
        /// <param name="userState">User state information to be passed through.</param>
        public BlobTransferProgressChangedEventArgs(long bytesSent, long totalBytesToSend, int progressPercentage, double speed, Uri uri, string localfile, object userState) : base(progressPercentage, userState)
        {
            if(uri==null)
            {
                throw new ArgumentNullException("uri");
            }
            if(string.IsNullOrEmpty(localfile))
            {
                throw new ArgumentException(StringTable.ErrorLocalFilenameIsNullOrEmpty);
            }
            BytesSent = bytesSent;
            TotalBytesToSend = totalBytesToSend;
            TransferRateBytesPerSecond = speed;
            Uri = uri;
            LocalFile = localfile;
        }

        /// <summary>
        /// Gets the bytes sent.
        /// </summary>
        public long BytesSent { get; private set; }

        /// <summary>
        /// Gets the total bytes to send.
        /// </summary>
        public long TotalBytesToSend { get; private set; }

        /// <summary>
        /// Gets the transfer speed.
        /// </summary>
        public double TransferRateBytesPerSecond { get; private set; }

        /// <summary>
        /// Gets the time remaining.
        /// </summary>
        public TimeSpan TimeRemaining
        {
            get
            {
                var time = new TimeSpan(0, 0, (int) ((TotalBytesToSend - BytesSent)/(TransferRateBytesPerSecond == 0 ? 1 : TransferRateBytesPerSecond)));
                return time;
            }
        }

        /// <summary>
        /// Gets the URL.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the full path of local file.
        /// </summary>
        public string LocalFile { get; private set; }
    }
}
