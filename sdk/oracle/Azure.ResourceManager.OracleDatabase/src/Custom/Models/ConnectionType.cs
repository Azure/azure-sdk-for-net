// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public readonly partial struct ConnectionType
    {
        /// <summary> A MongoDB Connection. </summary>
        public static ConnectionType MongoDBConnection { get; } = new ConnectionType("MONGODB");

        /// <summary> A MongoDB Connection. </summary>
        // Retain the previous spelling alongside the regenerated MongoDBConnection member.
        public static ConnectionType MongoDbConnection => MongoDBConnection;
    }
}
