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

namespace Microsoft.Azure.Management.DataLake.StoreUploader
{
    /// <summary>
    /// Defines various states that a segment upload can have
    /// </summary>
    public enum SegmentUploadStatus
    {

        /// <summary>
        /// Indicates that the segment is currently scheduled for upload.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Indicates that the segment is currently being uploaded.
        /// </summary>
        InProgress = 1,

        /// <summary>
        /// Indicates that the segment was not uploaded successfully.
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Indicates that the segment was successfully uploaded.
        /// </summary>
        Complete = 3
    }
}
