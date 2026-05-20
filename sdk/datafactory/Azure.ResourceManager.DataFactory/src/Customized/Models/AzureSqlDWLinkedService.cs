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
    public partial class AzureSqlDWLinkedService
    {
        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactoryKeyVaultSecret Password { get; set; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret ServicePrincipalCredential { get; set; }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret ServicePrincipalKey { get; set; }

        /// <summary> Back-compat constructor restoring the previously published single-arg shape. </summary>
        /// <param name="connectionString"> The connection string. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AzureSqlDWLinkedService(DataFactoryElement<string> connectionString) : this()
        {
            ConnectionString = connectionString;
        }
    }
}
