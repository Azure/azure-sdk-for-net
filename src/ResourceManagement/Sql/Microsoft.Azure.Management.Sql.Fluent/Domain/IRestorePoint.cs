// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's Restore Point.
    /// </summary>
    public interface IRestorePoint  :
        IWrapper<Models.RestorePointInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string DatabaseName { get; }

        /// <return>
        /// Restore point creation time (ISO8601 format). Populated when
        /// restorePointType = CONTINUOUS. Null otherwise.
        /// </return>
        System.DateTime RestorePointCreationDate { get; }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string SqlServerName { get; }

        /// <return>The restore point type of the Azure SQL Database restore point.</return>
        Models.RestorePointTypes RestorePointType { get; }

        /// <return>
        /// Earliest restore time (ISO8601 format). Populated when restorePointType
        /// = DISCRETE. Null otherwise.
        /// </return>
        System.DateTime EarliestRestoreDate { get; }
    }
}