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
using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A copy activity SQL sink.
    /// </summary>
    public class SqlSink : CopySink
    {
        /// <summary>
        /// SQL writer stored procedure name.
        /// </summary>
        public string SqlWriterStoredProcedureName { get; set; }

        /// <summary>
        /// SQL writer table type.
        /// </summary>
        public string SqlWriterTableType { get; set; }

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
        /// SQL stored procedure parameters.
        /// </summary>
        public IDictionary<string, StoredProcedureParameter> StoredProcedureParameters { get; set; }

#if ADF_INTERNAL
        /// <summary>
        /// Create staging table stored procedure name.
        /// </summary>
        public string CreateStagingTableStoredProcedureName { get; set; }

        /// <summary>
        /// Merge staging table to target table stored procedure name.
        /// </summary>
        public string MergeStagingTableToTargetTableStoredProcedureName { get; set; }

        /// <summary>
        /// Cleanup staging table stored procedure name.
        /// </summary>
        public string CleanupStagingTableStoredProcedureName { get; set; }
#endif

        public SqlSink()
        {
        }

        public SqlSink(int writeBatchSize, TimeSpan writeBatchTimeout)
            : base(writeBatchSize, writeBatchTimeout)
        {
        }
    }
}
