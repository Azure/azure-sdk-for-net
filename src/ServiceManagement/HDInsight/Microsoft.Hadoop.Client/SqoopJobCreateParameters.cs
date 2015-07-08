// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client
{
    /// <summary>
    /// Provides creation details for a new Sqoop job.
    /// </summary>
    public sealed class SqoopJobCreateParameters : QueryJobCreateParameters
    {
        /// <summary>
        /// Gets or sets the query to use for a sqoop job.
        /// </summary>
        public string Command { get; set; }

        internal override string GetQuery()
        {
            return this.Command;
        }

        internal override void SetQuery(string queryText)
        {
            this.Command = queryText;
        }
    }
}
