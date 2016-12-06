// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System;

    /// <summary>
    /// Implementation for Upgrade hint interface.
    /// </summary>
    internal partial class UpgradeHintImpl :
        Wrapper<Models.UpgradeHintInner>,
        IUpgradeHint
    {
        public Guid TargetServiceLevelObjectiveId()
        {
            return this.Inner.TargetServiceLevelObjectiveId.GetValueOrDefault();
        }

        internal UpgradeHintImpl(UpgradeHintInner innerObject)
            : base(innerObject)
        {
        }

        public string TargetServiceLevelObjective()
        {
            return this.Inner.TargetServiceLevelObjective;
        }
    }
}