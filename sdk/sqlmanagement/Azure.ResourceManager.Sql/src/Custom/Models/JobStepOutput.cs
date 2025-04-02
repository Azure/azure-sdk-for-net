// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class JobStepOutput
    {
        /// <summary> Initializes a new instance of <see cref="JobStepOutput"/>. </summary>
        /// <param name="serverName"> The output destination server name. </param>
        /// <param name="databaseName"> The output destination database. </param>
        /// <param name="tableName"> The output destination table. </param>
        /// <param name="credential"> The resource ID of the credential to use to connect to the output destination. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serverName"/>, <paramref name="databaseName"/>, <paramref name="tableName"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JobStepOutput(string serverName, string databaseName, string tableName, string credential)
        {
            Argument.AssertNotNull(serverName, nameof(serverName));
            Argument.AssertNotNull(databaseName, nameof(databaseName));
            Argument.AssertNotNull(tableName, nameof(tableName));

            ServerName = serverName;
            DatabaseName = databaseName;
            TableName = tableName;
            Credential = credential;
        }
    }
}
