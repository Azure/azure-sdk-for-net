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

using System;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A copy activity blob sink.
    /// </summary>
    public class BlobSink : CopySink
    {
        /// <summary>
        /// Blob writer overwrite files.
        /// </summary>
        public bool? BlobWriterOverwriteFiles { get; set; }

        /// <summary>
        /// Blob writer date time format.
        /// </summary>
        public string BlobWriterDateTimeFormat { get; set; }

        /// <summary>
        /// Blob writer add header.
        /// </summary>
        public bool? BlobWriterAddHeader { get; set; }

        /// <summary>
        /// Optional. The type of copy behavior for copy sink.
        /// <see cref="CopyBehaviorType"/>
        /// </summary>
        public string CopyBehavior { get; set; }

        public BlobSink()
        {
        }

        public BlobSink(int writeBatchSize, TimeSpan writeBatchTimeout)
            : base(writeBatchSize, writeBatchTimeout)
        {
        }
    }
}
