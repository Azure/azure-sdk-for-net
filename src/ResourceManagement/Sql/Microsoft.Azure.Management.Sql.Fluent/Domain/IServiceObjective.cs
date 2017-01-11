// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Models;

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
        /// <summary>
        /// Gets whether the service level objective is a system service objective.
        /// </summary>
        bool IsSystem { get; }

        /// <summary>
        /// Gets whether the service level objective is the default service
        /// objective.
        /// </summary>
        bool IsDefault { get; }

        /// <summary>
        /// Gets name of the SQL Server to which this replication belongs.
        /// </summary>
        string SqlServerName { get; }

        /// <summary>
        /// Gets the name for the service objective.
        /// </summary>
        string ServiceObjectiveName { get; }

        /// <summary>
        /// Gets the description for the service level objective.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets whether the service level objective is enabled.
        /// </summary>
        bool Enabled { get; }
    }
}