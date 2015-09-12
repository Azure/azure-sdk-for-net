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
    /// A copy activity sink.
    /// </summary>
    public abstract class CopySink : CopyLocation
    {
        /// <summary>
        /// Write batch size.
        /// </summary>
        [AdfRequired]
        public int WriteBatchSize { get; set; }

        /// <summary>
        /// Write batch timeout.
        /// </summary>
        [AdfRequired]
        public TimeSpan WriteBatchTimeout { get; set; }

        /// <summary>
        /// Sink retry count.
        /// </summary>
        public int? SinkRetryCount { get; set; }

        /// <summary>
        /// Sink retry wait.
        /// </summary>
        public TimeSpan? SinkRetryWait { get; set; }

        protected CopySink()
        {
        }

        protected CopySink(int writeBatchSize, TimeSpan writeBatchTimeout) 
            : this()
        {
            this.WriteBatchSize = writeBatchSize;
            this.WriteBatchTimeout = writeBatchTimeout;
        }
    }
}