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

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// A copy activity source for a Cassandra database.
    /// </summary>
    public class CassandraSource : CopySource
    {
        /// <summary>
        /// Optional. Should be a SQL-92 query expression or Cassandra Query Language (CQL) command.
        /// CQL reference: https://docs.datastax.com/en/cql/3.1/cql/cql_reference/cqlReferenceTOC.html.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Optional. The consistency level specifies how many Cassandra servers must respond to a read request before returning data to the client application. 
        /// Cassandra checks the specified number of Cassandra servers for data to satisfy the read request. 
        /// Must be one of <see cref="CassandraSourceReadConsistencyLevel"/>.
        /// The default value is "ONE".
        /// It is case-insensitive.
        /// Reference: http://docs.datastax.com/en/cassandra/2.0/cassandra/dml/dml_config_consistency_c.html.
        /// </summary>
        public string ConsistencyLevel { get; set; }
    }
}
