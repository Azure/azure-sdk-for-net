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
    /// Consistency level when connecting to the Cassandra database.
    /// A property of <see cref="CassandraSource"/>.
    /// Reference: http://docs.datastax.com/en/cassandra/2.0/cassandra/dml/dml_config_consistency_c.html.
    /// </summary>
    public static class CassandraSourceReadConsistencyLevel
    {
        /// <summary>
        /// Returns the record after all replicas have responded.
        /// The read operation will fail if a replica does not respond.
        /// </summary>
        public const string All = "ALL";

        /// <summary>
        /// Returns the record once a quorum of replicas in each data center of the cluster has responded.
        /// </summary>
        public const string EachQuorum = "EACH_QUORUM";

        /// <summary>
        /// Returns the record after a quorum of replicas has responded from any data center.
        /// </summary>
        public const string Quorum = "QUORUM";

        /// <summary>
        /// Returns the record after a quorum of replicas in the current data center as the coordinator has reported.
        /// Avoids latency of inter-data center communication.
        /// </summary>
        public const string LocalQuorum = "LOCAL_QUORUM";

        /// <summary>
        /// Returns a response from the closest replica, as determined by the snitch.
        /// By default, a read repair runs in the background to make the other replicas consistent.
        /// </summary>
        public const string One = "ONE";

        /// <summary>
        /// Returns the most recent data from two of the closest replicas.
        /// </summary>
        public const string Two = "TWO";

        /// <summary>
        /// Returns the most recent data from three of the closest replicas.
        /// </summary>
        public const string Three = "THREE";

        /// <summary>
        /// Returns a response from the closest replica in the local data center.
        /// </summary>
        public const string LocalOne = "LOCAL_ONE";

        /// <summary>
        /// Allows reading the current (and possibly uncommitted) state of data without proposing a new addition or update.
        /// If a SERIAL read finds an uncommitted transaction in progress, it will commit the transaction as part of the read. Similar to QUORUM. 
        /// </summary>
        public const string Serial = "SERIAL";

        /// <summary>
        /// Same as SERIAL, but confined to the data center. Similar to LOCAL_QUORUM.
        /// </summary>
        public const string LocalSerial = "LOCAL_SERIAL";
    }
}
