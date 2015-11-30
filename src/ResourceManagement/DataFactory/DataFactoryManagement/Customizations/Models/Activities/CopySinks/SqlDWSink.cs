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
    /// A copy activity SQL data warehouse sink.
    /// </summary>
    public class SqlDWSink : CopySink
    {
        /// <summary>
        /// Optional. Name of the SQL column which is used to save slice
        /// identifier information, to support idempotent copy.
        /// </summary>
        public string SliceIdentifierColumnName { get; set; }

        /// <summary>
        /// Optional. SQL writer cleanup script.
        /// </summary>
        public string SqlWriterCleanupScript { get; set; }

        /// <summary>
        /// Initializes a new instance of the SqlDWSink class.
        /// </summary>
        public SqlDWSink()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SqlDWSink class with required arguments.
        /// </summary>
        public SqlDWSink(int writeBatchSize, TimeSpan writeBatchTimeout)
            : base(writeBatchSize, writeBatchTimeout)
        {
        }
    }
}
