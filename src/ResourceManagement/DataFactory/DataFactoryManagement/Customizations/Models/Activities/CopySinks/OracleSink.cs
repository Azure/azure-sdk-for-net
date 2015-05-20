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
    /// A copy activity Oracle sink.
    /// </summary>
    public class OracleSink : CopySink
    {
        /// <summary>
        /// Oracle writer stored procedure name.
        /// </summary>
        public string OracleWriterStoredProcedureName { get; set; }

        /// <summary>
        /// Oracle writer table type.
        /// </summary>
        public string OracleWriterTableType { get; set; }

        /// <summary>
        /// Initializes a new instance of the OracleSink class.
        /// </summary>
        public OracleSink()
        {
        }

        /// <summary>
        /// Initializes a new instance of the OracleSink class with required
        /// arguments.
        /// </summary>
        public OracleSink(int writeBatchSize, TimeSpan writeBatchTimeout)
            : base(writeBatchSize, writeBatchTimeout)
        {
        }
    }
}
