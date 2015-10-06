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
    /// A copy activity Azure table sink.
    /// </summary>
    public class AzureTableSink : CopySink
    {
        /// <summary>
        /// Azure table default partition key value.
        /// </summary>
        public string AzureTableDefaultPartitionKeyValue { get; set; }

        /// <summary>
        /// Azure table partition key name.
        /// </summary>
        public string AzureTablePartitionKeyName { get; set; }

        /// <summary>
        /// Azure table row key name.
        /// </summary>
        public string AzureTableRowKeyName { get; set; }

        /// <summary>
        /// Azure table insert type.
        /// </summary>
        public string AzureTableInsertType { get; set; }

        public AzureTableSink()
        {
        }

        public AzureTableSink(int writeBatchSize, TimeSpan writeBatchTimeout)
            : base(writeBatchSize, writeBatchTimeout)
        {
        }
    }
}
