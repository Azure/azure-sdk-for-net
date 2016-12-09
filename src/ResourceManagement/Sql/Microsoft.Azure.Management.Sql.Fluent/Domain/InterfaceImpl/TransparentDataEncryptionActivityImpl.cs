// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;


    internal partial class TransparentDataEncryptionActivityImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
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

        /// <return>The name of the resource group.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName() as string;
            }
        }

        /// <return>The status transparent data encryption of the Azure SQL Database.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.Status
        {
            get
            {
                return this.Status() as string;
            }
        }

        /// <return>
        /// The percent complete of the transparent data encryption scan for a
        /// Azure SQL Database.
        /// </return>
        double Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.PercentComplete
        {
            get
            {
                return this.PercentComplete();
            }
        }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity.DatabaseName
        {
            get
            {
                return this.DatabaseName() as string;
            }
        }
    }
}