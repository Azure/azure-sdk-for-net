// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // identity-aliased Azure.Core.Expressions.DataFactory model types can be omitted from generated
    // model surfaces. This partial restores the GA API surface for compatibility.
    // TODO: remove once the generator preserves members whose types use @@alternateType identity (#59298).
    public partial class PostgreSqlV2LinkedService
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactoryKeyVaultSecret Password { get; set; }

        /// <summary> Back-compat constructor restoring the previously published 4-arg shape (no authenticationType). </summary>
        /// <param name="server"> Server name for connection. Type: string. </param>
        /// <param name="username"> Username for authentication. Type: string. </param>
        /// <param name="database"> Database name for connection. Type: string. </param>
        /// <param name="sslMode"> SSL mode for connection. Type: integer. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlV2LinkedService(DataFactoryElement<string> server, DataFactoryElement<string> username, DataFactoryElement<string> database, DataFactoryElement<int> sslMode)
            : this(server, username, database, default, sslMode)
        {
        }
    }
}
