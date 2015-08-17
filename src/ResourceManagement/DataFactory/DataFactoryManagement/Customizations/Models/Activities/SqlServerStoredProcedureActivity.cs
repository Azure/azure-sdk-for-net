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
    /// SQL Stored Procedure activity.
    /// </summary>
    [AdfTypeName("SqlServerStoredProcedure")]
    public class SqlServerStoredProcedureActivity : ActivityTypeProperties
    {
        /// <summary>
        /// Stored Procedure Name.
        /// </summary>
        [AdfRequired]
        public string StoredProcedureName { get; set; }

        /// <summary>
        /// User specified property bag used in Stored Procedure. There is no restriction on the
        /// keys or values that can be used. User needs to consume and interpret the content accordingly in
        /// their customized Stored Procedure.
        /// </summary>
        public IDictionary<string, string> StoredProcedureParameters { get; set; }

        public SqlServerStoredProcedureActivity()
        {
        }

        public SqlServerStoredProcedureActivity(
            string storedProcedureName,
            IDictionary<string, string> storedProcedureActivityParameters = null)
            : this()
        {
            Ensure.IsNotNullOrEmpty(storedProcedureName, "storedProcedureName");

            this.StoredProcedureName = storedProcedureName;
            this.StoredProcedureParameters = storedProcedureActivityParameters;
        }
    }
}
