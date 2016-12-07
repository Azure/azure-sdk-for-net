// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System;
    using Models;

    internal partial class UpgradeHintImpl 
    {
        /// <return>Target ServiceLevelObjectiveId for upgrade hint.</return>
        System.Guid Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint.TargetServiceLevelObjectiveId
        {
            get
            {
                return this.TargetServiceLevelObjectiveId();
            }
        }

        /// <return>Target ServiceLevelObjective for upgrade hint.</return>
        string Microsoft.Azure.Management.Sql.Fluent.IUpgradeHint.TargetServiceLevelObjective
        {
            get
            {
                return this.TargetServiceLevelObjective() as string;
            }
        }
    }
}