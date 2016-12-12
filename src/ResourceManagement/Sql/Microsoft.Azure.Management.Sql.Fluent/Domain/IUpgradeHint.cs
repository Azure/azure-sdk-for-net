// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure SQL database's Upgrade hint.
    /// </summary>
    public interface IUpgradeHint  :
        IWrapper<Models.UpgradeHint>
    {
        /// <return>Target ServiceLevelObjectiveId for upgrade hint.</return>
        System.Guid TargetServiceLevelObjectiveId { get; }

        /// <return>Target ServiceLevelObjective for upgrade hint.</return>
        string TargetServiceLevelObjective { get; }
    }
}