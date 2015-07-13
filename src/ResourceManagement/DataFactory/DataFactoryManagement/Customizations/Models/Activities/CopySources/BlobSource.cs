﻿//
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
    /// A copy activity blob source. 
    /// </summary>
    public class BlobSource : CopySource
    {
        /// <summary>
        /// Blob column separators.
        /// </summary>
        public string BlobColumnSeparators { get; set; }

        /// <summary>
        /// Treat empty as null.
        /// </summary>
        public bool? TreatEmptyAsNull { get; set; }

        /// <summary>
        /// Null values.
        /// </summary>
        public string NullValues { get; set; }

        /// <summary>
        /// Number of header lines to skip from each blob.
        /// </summary>
        public int? SkipHeaderLineCount { get; set; }
    }
}
