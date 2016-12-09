// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's TransparentDataEncryption.
    /// </summary>
    public interface ITransparentDataEncryption  :
        IWrapper<Models.TransparentDataEncryptionInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>An Azure SQL Database Transparent Data Encryption Activities.</return>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> ListActivities();

        /// <return>Name of the SQL Database to which this replication belongs.</return>
        string DatabaseName { get; }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string SqlServerName { get; }

        /// <summary>
        /// Updates the state of the transparent data encryption status.
        /// </summary>
        /// <param name="transparentDataEncryptionState">State of the data encryption to set.</param>
        /// <return>The new encryption settings after modifyState.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption UpdateStatus(TransparentDataEncryptionStates transparentDataEncryptionState);

        /// <return>The status of the Azure SQL Database Transparent Data Encryption.</return>
        Models.TransparentDataEncryptionStates Status { get; }
    }
}