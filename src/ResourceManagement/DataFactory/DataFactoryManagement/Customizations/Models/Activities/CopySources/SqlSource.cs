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

using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A copy activity SQL source.
    /// </summary>
    public class SqlSource : CopySource
    {
        /// <summary>
        /// SQL reader query.
        /// </summary>
        public string SqlReaderQuery { get; set; }

        /// <summary>
        /// Optional. Name of the stored procedure for a SQL Azure source. This cannot be used at the same time as SqlReaderQuery.
        /// </summary>
        public string SqlReaderStoredProcedureName { get; set; }

        /// <summary>
        /// Optional. Value and type setting for stored procedure parameters. Example: "{Parameter1: {value: "1", type: "int"}}".
        /// </summary>
        public IDictionary<string, IDictionary<string, string>> StoredProcedureParameters { get; set; }
    }
}
