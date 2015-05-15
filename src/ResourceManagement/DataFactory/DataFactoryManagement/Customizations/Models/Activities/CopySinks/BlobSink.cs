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
    /// A copy activity blob sink.
    /// </summary>
    public class BlobSink : CopySink
    {
        /// <summary>
        /// Block writer block size.
        /// </summary>
        public int? BlockWriterBlockSize { get; set; }

        /// <summary>
        /// Blob writer overwrite files.
        /// </summary>
        public bool? BlobWriterOverwriteFiles { get; set; }

        /// <summary>
        /// Blob writer partition columns.
        /// </summary>
        public string BlobWriterPartitionColumns { get; set; }

        /// <summary>
        /// Blob writer partition format.
        /// </summary>
        public string BlobWriterPartitionFormat { get; set; }

        /// <summary>
        /// Blob writer date time format.
        /// </summary>
        public string BlobWriterDateTimeFormat { get; set; }

        /// <summary>
        /// Blob writer separator.
        /// </summary>
        public string BlobWriterSeparator { get; set; }

        /// <summary>
        /// Blob writer row suffix.
        /// </summary>
        public string BlobWriterRowSuffix { get; set; }

        /// <summary>
        /// Blob writer add header.
        /// </summary>
        public bool? BlobWriterAddHeader { get; set; }
    }
}
