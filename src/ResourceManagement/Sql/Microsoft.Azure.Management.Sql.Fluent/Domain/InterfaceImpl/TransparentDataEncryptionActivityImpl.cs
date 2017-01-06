// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    internal partial class TransparentDataEncryptionActivityImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }

        /// <summary>
        /// Gets the status transparent data encryption of the Azure SQL Database.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <summary>
        /// Gets the percent complete of the transparent data encryption scan for a
        /// Azure SQL Database.
        /// </summary>
        double Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }
    }
}