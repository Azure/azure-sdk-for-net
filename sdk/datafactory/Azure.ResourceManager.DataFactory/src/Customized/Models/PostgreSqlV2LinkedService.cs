// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> Linked service for PostgreSQLV2 data source. </summary>
    public partial class PostgreSqlV2LinkedService : DataFactoryLinkedServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlV2LinkedService"/>. </summary>
        /// <param name="server"> Server name for connection. Type: string. </param>
        /// <param name="username"> Username for authentication. Type: string. </param>
        /// <param name="database"> Database name for connection. Type: string. </param>
        /// <param name="sslMode"> SSL mode for connection. Type: integer. 0: disable, 1:allow, 2: prefer, 3: require, 4: verify-ca, 5: verify-full. Type: integer. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="server"/>, <paramref name="username"/>, <paramref name="database"/> or <paramref name="sslMode"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlV2LinkedService(DataFactoryElement<string> server, DataFactoryElement<string> username, DataFactoryElement<string> database, DataFactoryElement<int> sslMode)
        {
            Argument.AssertNotNull(server, nameof(server));
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(database, nameof(database));
            Argument.AssertNotNull(sslMode, nameof(sslMode));

            Server = server;
            Username = username;
            Database = database;
            SslMode = sslMode;
            LinkedServiceType = "PostgreSqlV2";
        }
    }
}
