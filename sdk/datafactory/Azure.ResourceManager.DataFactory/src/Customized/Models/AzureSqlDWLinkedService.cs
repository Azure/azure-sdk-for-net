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
