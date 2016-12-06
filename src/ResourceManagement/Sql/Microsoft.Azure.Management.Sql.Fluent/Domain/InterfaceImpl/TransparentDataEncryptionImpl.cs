// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{

    using Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class TransparentDataEncryptionImpl 
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>The status of the Azure SQL Database Transparent Data Encryption.</return>
        Models.TransparentDataEncryptionStates Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.SqlServerName
        {
            get
            {
                return this.SqlServerName() as string;
            }
        }

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.DatabaseName
        {
            get
            {
                return this.DatabaseName() as string;
            }
        }

        /// <summary>
        /// Updates the state of the transparent data encryption status.
        /// </summary>
        /// <param name="transparentDataEncryptionState">State of the data encryption to set.</param>
        /// <return>The new encryption settings after modifyState.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.UpdateStatus(TransparentDataEncryptionStates transparentDataEncryptionState)
        {
            return this.UpdateStatus(transparentDataEncryptionState) as Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption;
        }

        /// <return>An Azure SQL Database Transparent Data Encryption Activities.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.ListActivities()
        {
            return this.ListActivities() as System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity>;
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