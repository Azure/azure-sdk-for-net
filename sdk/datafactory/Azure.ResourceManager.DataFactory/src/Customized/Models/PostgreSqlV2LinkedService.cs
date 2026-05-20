// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customization added as a workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298
// The TypeSpec @@alternateType identity-aliasing on SecretBase / LinkedServiceReference / SecureString
// causes properties whose type is one of those externally-aliased models to be silently dropped during
// code generation. This partial restores the public API surface so that downstream consumers continue
// to compile. Wire serialization for the restored members is NOT preserved here (the generator fix in
// https://github.com/Azure/azure-sdk-for-net/issues/59298 is required for full round-trip).

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
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
