// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's TransparentDataEncryptionActivity.
    /// </summary>
    public interface ITransparentDataEncryptionActivity  :
        IWrapper<Models.TransparentDataEncryptionActivity>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the percent complete of the transparent data encryption scan for a
        /// Azure SQL Database.
        /// </summary>
        double PercentComplete { get; }

        /// <summary>
        /// Gets the status transparent data encryption of the Azure SQL Database.
        /// </summary>
        string Status { get; }
    }
}