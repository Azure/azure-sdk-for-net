// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core.Expressions.DataFactory;

namespace Azure.ResourceManager.DataFactory.Models
{
    /// <summary> SQL Server linked service. </summary>
    public partial class SqlServerLinkedService : DataFactoryLinkedServiceProperties
    {
        /// <summary> Initializes a new instance of <see cref="SqlServerLinkedService"/>. </summary>
        /// <param name="connectionString"> The connection string. Type: string, SecureString or AzureKeyVaultSecretReference. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SqlServerLinkedService(DataFactoryElement<string> connectionString)
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            ConnectionString = connectionString;
            LinkedServiceType = "SqlServer";
        }
    }
}
