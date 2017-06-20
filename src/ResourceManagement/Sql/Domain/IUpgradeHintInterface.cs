// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's Upgrade hint.
    /// </summary>
    public interface IUpgradeHintInterface  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.UpgradeHint>
    {
        /// <summary>
        /// Gets Target ServiceLevelObjectiveId for upgrade hint.
        /// </summary>
        System.Guid TargetServiceLevelObjectiveId { get; }

        /// <summary>
        /// Gets Target ServiceLevelObjective for upgrade hint.
        /// </summary>
        string TargetServiceLevelObjective { get; }
    }
}