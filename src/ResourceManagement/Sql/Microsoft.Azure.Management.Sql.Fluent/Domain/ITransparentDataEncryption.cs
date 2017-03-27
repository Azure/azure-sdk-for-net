// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's TransparentDataEncryption.
    /// </summary>
    public interface ITransparentDataEncryption  :
        IHasInner<Models.TransparentDataEncryptionInner>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>An Azure SQL Database Transparent Data Encryption Activities.</return>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> ListActivities();

        /// <summary>
        /// Gets name of the SQL Database to which this replication belongs.
        /// </summary>
        string DatabaseName { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Updates the state of the transparent data encryption status.
        /// </summary>
        /// <param name="transparentDataEncryptionState">State of the data encryption to set.</param>
        /// <return>The new encryption settings after modifyState.</return>
        Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption UpdateStatus(TransparentDataEncryptionStates transparentDataEncryptionState);

        /// <summary>
        /// Gets the status of the Azure SQL Database Transparent Data Encryption.
        /// </summary>
        Models.TransparentDataEncryptionStates Status { get; }
    }
}