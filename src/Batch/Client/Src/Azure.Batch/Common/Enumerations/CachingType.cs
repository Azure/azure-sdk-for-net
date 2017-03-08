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

namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The caching type for an OS disk. For information about the caching options see: https://blogs.msdn.microsoft.com/windowsazurestorage/2012/06/27/exploring-windows-azure-drives-disks-and-images/
    /// </summary>
    public enum CachingType
    {
        /// <summary>
        /// No caching is enabled.
        /// </summary>
        None,

        /// <summary>
        /// The caching mode for the disk is read only.
        /// </summary>
        ReadOnly,

        /// <summary>
        /// The caching mode for the disk is read/write.
        /// </summary>
        ReadWrite
    }
}
