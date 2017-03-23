// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using System;

    internal partial class UpgradeHintImpl 
    {
        /// <summary>
        /// Gets Target ServiceLevelObjectiveId for upgrade hint.
        /// </summary>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint.TargetServiceLevelObjectiveId
        {
            get
            {
                return this.TargetServiceLevelObjectiveId();
            }
        }

        /// <summary>
        /// Gets Target ServiceLevelObjective for upgrade hint.
        /// </summary>
        string Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint.TargetServiceLevelObjective
        {
            get
            {
                return this.TargetServiceLevelObjective();
            }
        }
    }
}