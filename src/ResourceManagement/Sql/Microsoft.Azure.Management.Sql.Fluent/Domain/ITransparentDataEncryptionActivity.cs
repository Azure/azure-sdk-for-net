// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's TransparentDataEncryptionActivity.
    /// </summary>
    public interface ITransparentDataEncryptionActivity  :
        IWrapper<Models.TransparentDataEncryptionActivity>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string DatabaseName { get; }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string SqlServerName { get; }

        /// <return>
        /// The percent complete of the transparent data encryption scan for a
        /// Azure SQL Database.
        /// </return>
        double PercentComplete { get; }

        /// <return>The status transparent data encryption of the Azure SQL Database.</return>
        string Status { get; }
    }
}