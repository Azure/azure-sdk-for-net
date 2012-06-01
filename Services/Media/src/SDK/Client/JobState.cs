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

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Specifies the possible Job states.
    /// </summary>
    public enum JobState
    {
        /// <summary>
        /// Specifies that the Job is queued and waiting to be scheduled.
        /// </summary>
        /// <remarks>This is the initial state for a new Job.</remarks>
        Queued,
        /// <summary>
        /// Specifies that the Job is scheduled for processing when resources become available.
        /// </summary>
        Scheduled,
        /// <summary>
        /// Specifies that the Job is currently processing.
        /// </summary>
        Processing,
        /// <summary>
        /// Specifies that the Job is finished processing and outputs have been produced.
        /// </summary>
        Finished,
        /// <summary>
        /// Specifies that an error occurred while processing the Job.
        /// </summary>
        Error,
        /// <summary>
        /// Specifies that the job was canceled.
        /// </summary>
        Canceled,
        /// <summary>
        /// Specifies that cancel Job has been requested and should stop processing.
        /// </summary>
        Canceling
    }
}
