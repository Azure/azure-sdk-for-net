// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL Service Objective.
    /// </summary>
    public interface IServiceObjective  :
        IWrapper<Models.ServiceObjectiveInner>,
        IRefreshable<Microsoft.Azure.Management.Sql.Fluent.IServiceObjective>,
        IHasResourceGroup,
        IHasName,
        IHasId
    {
        /// <return>Whether the service level objective is a system service objective.</return>
        bool IsSystem { get; }

        /// <return>
        /// Whether the service level objective is the default service
        /// objective.
        /// </return>
        bool IsDefault { get; }

        /// <return>Name of the SQL Server to which this replication belongs.</return>
        string SqlServerName { get; }

        /// <return>The name for the service objective.</return>
        string ServiceObjectiveName { get; }

        /// <return>The description for the service level objective.</return>
        string Description { get; }

        /// <return>Whether the service level objective is enabled.</return>
        bool Enabled { get; }
    }
}