// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Models;

    internal partial class RestorePointImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>
        /// Earliest restore time (ISO8601 format). Populated when restorePointType
        /// = DISCRETE. Null otherwise.
        /// </return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRestorePoint.EarliestRestoreDate
        {
            get
            {
                return this.EarliestRestoreDate();
            }
        }

        /// <return>The restore point type of the Azure SQL Database restore point.</return>
        Models.RestorePointTypes Microsoft.Azure.Management.Sql.Fluent.IRestorePoint.RestorePointType
        {
            get
            {
                return this.RestorePointType();
            }
        }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IRestorePoint.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IRestorePoint.DatabaseName
        {
            get
            {
                return this.DatabaseName() as string;
            }
        }

        /// <return>
        /// Restore point creation time (ISO8601 format). Populated when
        /// restorePointType = CONTINUOUS. Null otherwise.
        /// </return>
        System.DateTime Microsoft.Azure.Management.Sql.Fluent.IRestorePoint.RestorePointCreationDate
        {
            get
            {
                return this.RestorePointCreationDate();
            }
        }

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }

        /// <return>The resource ID string.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id() as string;
            }
        }
    }
}