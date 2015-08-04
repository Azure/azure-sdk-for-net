//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// All available types of copy behavior.
    /// </summary>
    public class CopyBehaviorType
    {
        /// <summary>
        /// Preserve the file hierarchy in the target folder. This is the default behavior for FileSystemSink.
        /// <see cref="FileSystemSink"/>
        /// </summary>
        public const string PreserveHierarchy = "PreserveHierarchy";

        /// <summary>
        /// All files from the source folder will be in the first level of target folder. This is the default behavior for blobSink with binary data.
        /// <see cref="BlobSink"/>
        /// </summary>
        public const string FlattenHierarchy = "FlattenHierarchy";

        /// <summary>
        /// Merge all files from the source folder into one file. This is the default behavior for blobSink with tabular data.
        /// <see cref="BlobSink"/>
        /// </summary>
        public const string MergeFiles = "MergeFiles";
    }
}