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
#if ADF_INTERNAL
    /// <summary>
    /// A copy activity MDS source.
    /// </summary>
    public class MdsSource : CopySource
    {
        /// <summary>
        /// MDS time span.
        /// </summary>
        public string MdsTimeSpan { get; set; }

        /// <summary>
        /// MDS start time.
        /// </summary>
        public string MdsStartTime { get; set; }

        /// <summary>
        /// MDS source window size.
        /// </summary>
        public TimeSpan? MdsSourceWindowSize { get; set; }

        /// <summary>
        /// Last table versions.
        /// </summary>
        public int? LastTableVersions { get; set; }

        /// <summary>
        /// Query string.
        /// </summary>
        public string QueryString { get; set; }

        /// <summary>
        /// Enable MDS debug log.
        /// </summary>
        public bool? EnableMdsDebugLog { get; set; }

        /// <summary>
        /// MDS source parallel reader count.
        /// </summary>
        public int? MdsSourceParallelReaderCount { get; set; }
    }
#endif
}
