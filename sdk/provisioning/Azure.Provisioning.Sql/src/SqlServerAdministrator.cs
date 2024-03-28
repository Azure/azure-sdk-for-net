// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Provisioning.Sql
{
    /// <summary>
    /// Represents a SQL Server administrator.
    /// </summary>
    public readonly struct SqlServerAdministrator
    {
        internal Parameter ObjectId { get; }
        internal Parameter LoginName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerAdministrator"/>.
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="objectId"></param>
        public SqlServerAdministrator(
            Parameter loginName,
            Parameter objectId)
        {
            LoginName = loginName;
            ObjectId = objectId;
        }
    }
}
