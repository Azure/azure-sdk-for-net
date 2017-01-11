// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's Restore Point.
    /// </summary>
    public interface IRestorePoint  :
        IWrapper<Models.RestorePointInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets restore point creation time (ISO8601 format). Populated when
        /// restorePointType = CONTINUOUS. Null otherwise.
        /// </summary>
        System.DateTime RestorePointCreationDate { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the restore point type of the Azure SQL Database restore point.
        /// </summary>
        Models.RestorePointTypes RestorePointType { get; }

        /// <summary>
        /// Gets earliest restore time (ISO8601 format). Populated when restorePointType
        /// = DISCRETE. Null otherwise.
        /// </summary>
        System.DateTime EarliestRestoreDate { get; }
    }
}