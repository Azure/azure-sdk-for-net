// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;

    internal partial class TransparentDataEncryptionImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
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

        /// <summary>
        /// Gets the status of the Azure SQL Database Transparent Data Encryption.
        /// </summary>
        Models.TransparentDataEncryptionStates Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.Status
        {
            get
            {
                return this.Status();
            }
        }

        /// <return>An Azure SQL Database Transparent Data Encryption Activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.ListActivities()
        {
            return this.ListActivities() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity>;
        }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.SqlServerName
        {
            get
            {
                return this.SqlServerName();
            }
        }

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption.DatabaseName
        {
            get
            {
                return this.DatabaseName();
            }
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource group.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasResourceGroup.ResourceGroupName
        {
            get
            {
                return this.ResourceGroupName();
            }
        }
    }
}