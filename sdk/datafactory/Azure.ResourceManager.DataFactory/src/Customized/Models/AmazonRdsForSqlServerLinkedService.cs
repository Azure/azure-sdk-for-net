// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/59298 :
    // identity-aliased Azure.Core.Expressions.DataFactory model types can be omitted from generated
    // model surfaces. This partial restores the GA API surface for compatibility.
    // TODO: remove once the generator preserves members whose types use @@alternateType identity (#59298).
    public partial class AmazonRdsForSqlServerLinkedService
    {
        /// <summary> Initializes a new instance of <see cref="AmazonRdsForSqlServerLinkedService"/>. </summary>
        /// <param name="connectionString"> The connection string. Type: string, SecureString or AzureKeyVaultSecretReference. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        public AmazonRdsForSqlServerLinkedService(DataFactoryElement<string> connectionString) : this()
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            ConnectionString = connectionString;
        }

        /// <summary> Property restored as workaround for issue #59298. </summary>
        public DataFactorySecret Password { get; set; }
    }
}
